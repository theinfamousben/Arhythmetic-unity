using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private TMP_Text noteCount;
        [SerializeField] private TMP_Text accuracyText;
        [SerializeField] private AudioClock audioClock;
        [SerializeField] private TMP_Text beatText;

        public static SongData SongData;
        public static float Accuracy;
        public HitAccuracy LastAccuracy { get; private set; }
        public bool LastHitWasEarly { get; private set; }
        public bool LastHitWasLate { get; private set; }
        public double LastDeltaSeconds { get; private set; }

        private readonly Queue<NoteEvent>[] noteQueues = new Queue<NoteEvent>[8];
        private int processedNotes;
        private int hitNotes;

        private void Awake()
        {
            if (Constants.DEV) SongData = new Levels().clubstep;
            
            ButtonManager.Init();
            
            if (audioClock == null)
                audioClock = GetComponent<AudioClock>();

            for (int i = 0; i < noteQueues.Length; i++)
                noteQueues[i] = new Queue<NoteEvent>();
        }

        private void Start()
        {
            if (SongData == null)
                return;

            SongData.PrepareEvents();
            foreach (var note in SongData.events)
            {
                int lane = note.note - Constants.BUTTON_1_NOTE;
                if (lane >= 0 && lane < noteQueues.Length)
                    noteQueues[lane].Enqueue(note);
            }

            processedNotes = 0;
            hitNotes = 0;
            UpdateUi();
            int measureBeats = SongData.timeSignature[0];
            int beatDenominator = SongData.timeSignature[1];
            audioClock?.StartPlayback(SongData.bpm, measureBeats, beatDenominator, SongData.pickupBeats);
        }

        private void Update()
        {
            if (audioClock == null)
                return;

            double songTime = audioClock.SongTime;
            for (int lane = 0; lane < noteQueues.Length; lane++)
            {
                while (noteQueues[lane].Count > 0 &&
                       songTime - noteQueues[lane].Peek().time > Constants.MISS_HIT_WINDOW)
                {
                    double targetTime = noteQueues[lane].Peek().time;
                    noteQueues[lane].Dequeue();
                    processedNotes++;
                    LastAccuracy = HitAccuracy.Miss;
                    LastDeltaSeconds = songTime - targetTime;
                    LastHitWasEarly = false;
                    LastHitWasLate = true;
                    UpdateUi(HitAccuracy.Miss);
                }
            }
            
        }

        private void AddInput(string input)
        {
            
            
            if (!Constants.BUTTON_NOTE_MAPPING.TryGetValue(input, out int note))
                return;

            EvaluateKeypress(note);
        }

        private void EvaluateKeypress(int midiNote)
        {
            int lane = midiNote - Constants.BUTTON_1_NOTE;
            if (lane < 0 || lane >= noteQueues.Length || noteQueues[lane].Count == 0)
                return;

            double delta = audioClock.SongTime - noteQueues[lane].Peek().time;
            if (delta < -Constants.MISS_HIT_WINDOW)
                return;

            noteQueues[lane].Dequeue();
            processedNotes++;

            HitAccuracy accuracy = GetAccuracy(System.Math.Abs(delta));
            LastAccuracy = accuracy;
            LastDeltaSeconds = delta;
            LastHitWasEarly = delta < 0d;
            LastHitWasLate = delta > 0d;
            if (accuracy != HitAccuracy.Miss)
                hitNotes++;

            UpdateUi(accuracy);
            Debug.Log($"{accuracy} ({(delta < 0d ? "Early" : "Late")}, {delta * 1000d:0.0}ms)");
        }

        private static HitAccuracy GetAccuracy(double absoluteDelta)
        {
            if (absoluteDelta <= Constants.PERFECT_HIT_WINDOW) return HitAccuracy.Perfect;
            if (absoluteDelta <= Constants.GREAT_HIT_WINDOW) return HitAccuracy.Great;
            if (absoluteDelta <= Constants.GOOD_HIT_WINDOW) return HitAccuracy.Good;
            if (absoluteDelta <= Constants.MISS_HIT_WINDOW) return HitAccuracy.Miss;
            return HitAccuracy.Miss;
        }

        private void UpdateUi(HitAccuracy accuracy = HitAccuracy.None)
        {
            if (noteCount != null)
                noteCount.text = processedNotes + "/" + (SongData?.events.Count ?? 0);
            if (accuracyText != null && accuracy != HitAccuracy.None)
                accuracyText.text = accuracy.ToString();
            Accuracy = processedNotes == 0 ? 0f : (float)hitNotes / processedNotes;
            
            beatText.text = $"{GetCurrentBar()}.{GetCurrentBeat()}";
        }

        public int GetCurrentBeat()
        {
            if (!TryGetBeatContext(out int beatsPerBar, out int currentBeatIndex))
                return 0;

            return currentBeatIndex % beatsPerBar + 1; // +1 to make it 1-indexed
        }

        public int GetCurrentBar()
        {
            if (!TryGetBeatContext(out int beatsPerBar, out int currentBeatIndex))
                return 0;

            return currentBeatIndex / beatsPerBar + 1; // +1 to make it 1-indexed
        }

        private bool TryGetBeatContext(out int beatsPerBar, out int currentBeatIndex)
        {
            beatsPerBar = 0;
            currentBeatIndex = 0;

            if (SongData == null || SongData.timeSignature == null || SongData.timeSignature.Length < 2)
                return false;

            beatsPerBar = SongData.timeSignature[0];
            if (beatsPerBar <= 0 || SongData.bpm <= 0f)
                return false;

            double songTime = audioClock?.SongTime ?? 0d;
            double secondsPerBeat = 60d / SongData.bpm;
            currentBeatIndex = (int)(songTime / secondsPerBeat) + SongData.pickupBeats;
            return true;
        }

        // ReSharper disable once UnusedMember.Global
        public void OnButton1(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button1");
                ButtonManager.Activate("Button1");
            }
            else
            {
                ButtonManager.Deactivate("Button1");
            }
        }
        
        // ReSharper disable once UnusedMember.Global
        public void OnButton2(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button2");
                ButtonManager.Activate("Button2");
            }
            else
            {
                ButtonManager.Deactivate("Button2");
            }
        }
        
        // ReSharper disable once UnusedMember.Global
        public void OnButton3(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button3");
                ButtonManager.Activate("Button3");
            }
            else
            {
                ButtonManager.Deactivate("Button3");
            }
        }

        // ReSharper disable once UnusedMember.Global
        public void OnButton4(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button4");
                ButtonManager.Activate("Button4");
            }
            else
            {
                ButtonManager.Deactivate("Button4");
            }
        }

        // ReSharper disable once UnusedMember.Global
        public void OnButton5(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button5");
                ButtonManager.Activate("Button5");
            }
            else
            {
                ButtonManager.Deactivate("Button5");
            }
        }
        
        // ReSharper disable once UnusedMember.Global
        public void OnButton6(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button6");
                ButtonManager.Activate("Button6");
            }
            else
            {
                ButtonManager.Deactivate("Button6");
            }
        }

        // ReSharper disable once UnusedMember.Global
        public void OnButton7(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button7");
                ButtonManager.Activate("Button7");
            }
            else
            {
                ButtonManager.Deactivate("Button7");
            }
        }

        // ReSharper disable once UnusedMember.Global
        public void OnButton8(InputValue value)
        {
            if (value.isPressed)
            {
                AddInput("Button8");
                ButtonManager.Activate("Button8");
            }
            else
            {
                ButtonManager.Deactivate("Button8");
            }
        }
    }
}
