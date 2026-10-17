using System.Collections.Generic;
using Types;
using UnityEngine;

public class Levels
{
    [Header("DJ-NATE - CLUBSTEP")] 
    public readonly SongData clubstep = new()
    {
        title = "Clubstep",
        author = "benmu",
        difficulty = Difficulty.Easy,
        songName = "Clubstep",
        artist = "dj-nate",
        bpm = 128f,
        timeSignature = new[] { 4, 4 },
        pickupBeats = 0,
        events = new List<NoteEvent>
        {
            // Bar 1
            new(){ beat = 1f, note = 65, length = 0 },
            new(){ beat = 2f, note = 64, length = 0 },
            new(){ beat = 3f, note = 65, length = 0 },
            
            // Bar 2
            new(){ beat = 4f, note = 64, length = 0 },
            new(){ beat = 5f, note = 65, length = 0 },
            new(){ beat = 6f, note = 64, length = 0 },
            new(){ beat = 7f, note = 65, length = 0 },
            new(){ beat = 7.5f, note = 65, length = 0 },
            
            // Bar 3
            new(){ beat = 8f, note = 64, length = 0 },
            new(){ beat = 9f, note = 65, length = 0 },
            new(){ beat = 10f, note = 64, length = 0 },
            new(){ beat = 11f, note = 65, length = 0 },
            
            // Bar 4
            new(){ beat = 12f, note = 64, length = 0 },
            new(){ beat = 13f, note = 65, length = 0 },
            new(){ beat = 14f, note = 64, length = 0 },
            new(){ beat = 14.75f, note = 65, length = 0 },
            new(){ beat = 15f, note = 64, length = 0 },
            new(){ beat = 15.5f, note = 65, length = 0 },
            
            // Bar 5
            new(){ beat = 16f, note = 64, length = 0 },
        }
    };
}