using Types;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Controller : MonoBehaviour
    {
        public float timer;
        public SongData songData;
        public float accuracy;

        void Start()
        {
            timer = 0;
        }
        
        void Update()
        {
            timer += Time.deltaTime;
        }

        private void AddInput(string input)
        {
            Debug.Log(input);
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
