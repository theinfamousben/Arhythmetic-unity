using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioClock : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField, Range(1f, 2f)] private double startDelay = 1.5d;
        [SerializeField] private double userOffset; // User-defined input offset in seconds

        private double dspStart;
        private double songOriginDsp;
        private double pausedDuration;
        private double pauseDspTime;
        private bool isPaused;

        private void Awake()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }

        public double UserOffset
        {
            get => userOffset;
            set => userOffset = value;
        }

        public double SongTime
        {
            get
            {
                if (dspStart <= 0d)
                    return 0d;

                double paused = pausedDuration;
                if (isPaused)
                    paused += AudioSettings.dspTime - pauseDspTime;

                return AudioSettings.dspTime - songOriginDsp - paused - userOffset;
            }
        }

        public void StartPlayback(float bpm, int measureBeats, int beatDenominator, int pickupBeats)
        {
            if (audioSource == null || audioSource.clip == null)
                return;

            if (bpm <= 0f)
            {
                Debug.LogError("Cannot start playback without a positive BPM.");
                return;
            }

            double secondsPerBeat = 60d / bpm * 4d / Mathf.Max(1, beatDenominator);
            double measureDuration = secondsPerBeat * Mathf.Max(1, measureBeats);
            double pickupDuration = secondsPerBeat * Mathf.Clamp(pickupBeats, 0, Mathf.Max(1, measureBeats));
            double countInDuration = measureDuration - pickupDuration;

            pausedDuration = 0d;
            isPaused = false;
            dspStart = AudioSettings.dspTime + startDelay + countInDuration;
            songOriginDsp = dspStart + pickupDuration;
            audioSource.PlayScheduled(dspStart);
        }

        public void Pause()
        {
            if (isPaused || dspStart <= 0d)
                return;

            pauseDspTime = AudioSettings.dspTime;
            isPaused = true;
            audioSource?.Pause();
        }

        public void Resume()
        {
            if (!isPaused)
                return;

            pausedDuration += AudioSettings.dspTime - pauseDspTime;
            isPaused = false;
            audioSource?.Play();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
                Resume();
            else
                Pause();
        }
    }
}
