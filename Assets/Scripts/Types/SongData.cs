using System;
using System.Collections.Generic;

namespace Types
{
    /**
     * Represents the data for a song, including its title, author, difficulty, and a list of note events.
     * Each note event contains information about the beat, note, and length of the note. The class also
     * includes methods to retrieve the current notes based on the given time.
     *
     * beats are measured in the denominator of the time signature, so a beat of 1 in 4/4 time is a quarter
     * note, while a beat of 1 in 3/8 time is an eighth note.
     *
     * Assuming a time signature of 4/4, a beat of 1 is a quarter note, a beat of 2 is a half note, and a
     * beat of 0.5 is an eighth note.
     */
    
    
    public class SongData
    {
        public string title;
        public string author;
        public Difficulty difficulty;
        public string songName;
        public string artist;
        public List<NoteEvent> events;
        public float bpm;
        public int[] timeSignature; // [numerator, denominator]
        public int pickupBeats; // how many notes before the first measure, should be less than timeSignature[0] 
        [Obsolete("Swing is not implemented yet", true)]
        public float swingAmount; 

        public void PrepareEvents()
        {
            events ??= new List<NoteEvent>();

            int denominator = timeSignature[1];
            double secondsPerBeat = 60d / bpm * 4d / denominator;
            foreach (var noteEvent in events)
            {
                // Existing beat-authored charts are converted once; explicit times are preserved.
                if (noteEvent.time == 0d && noteEvent.beat != 0f && secondsPerBeat > 0d)
                    noteEvent.time = noteEvent.beat * secondsPerBeat;
            }

            events.Sort((left, right) => left.time.CompareTo(right.time));
        }

        public List<NoteEvent> GetCurrentNotes(float time)
        {
            List<NoteEvent> notes = new();
            foreach (var noteEvent in events)
            {
                // TODO: finish logic
            }

            return notes;
        }
    }
    
    public class NoteEvent
    {
        public double time;
        public float beat;
        public int note;
        public int length; // how many beats the note lasts, 0 for a single note
    }
}