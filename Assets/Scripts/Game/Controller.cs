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
        
        public static float Timer;
        public static SongData SongData;
        public static float Accuracy;

        void Start()
        {
            noteCount.text = "0/" + SongData.events.Count;
            accuracyText.text = "[]";
            
            Timer = 0;
        }
        
        void Update()
        {
            Timer += Time.deltaTime;
        }

        private void AddInput(string input)
        {
            EvaluateKeypress(input);
            Debug.Log(input);
        }

        private List<NoteEvent> SeparateNotes()
        {
            var notes = new List<NoteEvent>();

            foreach (var note in SongData.events)
            {
                
            }

            return notes;
        }

        private void EvaluateKeypress(string input)
        {
            var keypress = Constants.BUTTON_NOTE_MAPPING[input];
            
            
        }

        void Awake()
        {
            OnButton1(new InputValue());
            OnButton2(new InputValue());
            OnButton3(new InputValue());
            OnButton4(new InputValue());
            OnButton5(new InputValue());
            OnButton6(new InputValue());
            OnButton7(new InputValue());
            OnButton8(new InputValue());
        }
        
        void OnButton1(InputValue value)
        {
            AddInput("Button1");
        }
        
        void OnButton2(InputValue value)
        {
            AddInput("Button2");
        }
        
        void OnButton3(InputValue value)
        {
            AddInput("Button3");
        }
        
        void OnButton4(InputValue value)
        {
            AddInput("Button4");
        }
        
        void OnButton5(InputValue value)
        {
            AddInput("Button5");
        }

        void OnButton6(InputValue value)
        {
            AddInput("Button6");
        }

        void OnButton7(InputValue value)
        {
            AddInput("Button7");
        }
        
        void OnButton8(InputValue value)
        {
            AddInput("Button8");
        }
        
        
        
    }
}
