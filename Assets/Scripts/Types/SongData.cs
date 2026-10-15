using System.Collections.Generic;

namespace Types
{
    public class SongData
    {
        public string title;
        public string author;
        public string songName;
        public string artist;
        public List<NoteEvent> events;
        public float bpm; // do we need this or should we just go from seconds?
    }
    
    public class NoteEvent
    {
        public float time;
        public int note;
        public int type;
    }
}