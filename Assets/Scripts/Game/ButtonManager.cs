using TMPro;
using UnityEngine;

namespace Game
{
    public static class ButtonManager
    {
        static GameObject Button1;
        static GameObject Button2;
        static GameObject Button3;
        static GameObject Button4;
        static GameObject Button5;
        static GameObject Button6;
        static GameObject Button7;
        static GameObject Button8;

        public static void Init()
        {
            Button1 = GameObject.Find("Button 1");
            Button2 = GameObject.Find("Button 2");
            Button3 = GameObject.Find("Button 3");
            Button4 = GameObject.Find("Button 4");
            Button5 = GameObject.Find("Button 5");
            Button6 = GameObject.Find("Button 6");
            Button7 = GameObject.Find("Button 7");
            Button8 = GameObject.Find("Button 8");
        }
        
        public static void Activate(string buttonName)
        {
            switch (buttonName)
            {
                case "Button1":
                    Button1.GetComponentInChildren<TMP_Text>().text = "A";
                    break;
                case "Button2": 
                    Button2.GetComponentInChildren<TMP_Text>().text = "S";
                    break;
                case "Button3":
                    Button3.GetComponentInChildren<TMP_Text>().text = "D";
                    break;
                case "Button4":
                    Button4.GetComponentInChildren<TMP_Text>().text = "F";
                    break;
                case "Button5":
                    Button5.GetComponentInChildren<TMP_Text>().text = "J";
                    break;
                case "Button6":
                    Button6.GetComponentInChildren<TMP_Text>().text = "K";
                    break;
                case "Button7":
                    Button7.GetComponentInChildren<TMP_Text>().text = "L";
                    break;
                case "Button8":
                    Button8.GetComponentInChildren<TMP_Text>().text = ";";
                    break;
            }
        }
        
        public static void Deactivate(string buttonName)
        {
            switch (buttonName)
            {
                case "Button1":
                    Button1.GetComponentInChildren<TMP_Text>().text = "";
                    break;
                case "Button2":
                    Button2.GetComponentInChildren<TMP_Text>().text = "";
                    break;
                case "Button3":
                    Button3.GetComponentInChildren<TMP_Text>().text = "";
                    break;
                case "Button4":
                    Button4.GetComponentInChildren<TMP_Text>().text = "";
                    break;
                case "Button5":
                    Button5.GetComponentInChildren<TMP_Text>().text = "";
                    break;
                case "Button6":
                    Button6.GetComponentInChildren<TMP_Text>().text = "";
                    break;
                case "Button7":
                    Button7.GetComponentInChildren<TMP_Text>().text = "";
                    break;                
                case "Button8":
                    Button8.GetComponentInChildren<TMP_Text>().text = "";
                    break;
            }
        }
    }
}