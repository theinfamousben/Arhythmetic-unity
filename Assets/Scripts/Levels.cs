using System.Collections.Generic;
using Types;
using UnityEngine;

namespace DefaultNamespace
{
    public class Levels
    {
        [Header("THEFATRAT - UNITY")] 
        public SongData unity = new()
        {
            title = "Unity",
            author = "benmu",
            difficulty = Difficulty.Easy,
            songName = "Unity",
            artist = "TheFatRat",
            bpm = 105f,
            events = new List<NoteEvent>
            {
                new() { beat = -1.25f, note = 65, length = 0 },
                new() { beat = -1f, note = 64, length = 0 },
            }
        };
    }
}