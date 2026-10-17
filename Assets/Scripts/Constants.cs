using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class Constants
{
    public const bool DEV = true;
    
    public const int BUTTON_1_NOTE = 60;
    public const int BUTTON_2_NOTE = 61;
    public const int BUTTON_3_NOTE = 62;
    public const int BUTTON_4_NOTE = 63;
    public const int BUTTON_5_NOTE = 64;
    public const int BUTTON_6_NOTE = 65;
    public const int BUTTON_7_NOTE = 66;
    public const int BUTTON_8_NOTE = 67;

    public static readonly Dictionary<string, int> BUTTON_NOTE_MAPPING = new()
    {
        { "Button1", BUTTON_1_NOTE },
        { "Button2", BUTTON_2_NOTE },
        { "Button3", BUTTON_3_NOTE },
        { "Button4", BUTTON_4_NOTE },
        { "Button5", BUTTON_5_NOTE },
        { "Button6", BUTTON_6_NOTE },
        { "Button7", BUTTON_7_NOTE },
        { "Button8", BUTTON_8_NOTE }
    };
    
    public const double PERFECT_HIT_WINDOW = 0.040; // 40ms
    public const double GREAT_HIT_WINDOW   = 0.080; // 80ms
    public const double GOOD_HIT_WINDOW    = 0.130; // 130ms
    public const double MISS_HIT_WINDOW    = 0.160; // 160ms
}