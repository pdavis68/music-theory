# music-theory

This is a very simple library to do some basic music theory. I threw this together in an evening. I'm not terribly happy with the design. I want to figure out how to work in octaves, handle more complex chords. Right now it doesn't do flats.  Secondary dominants should return dominant 7ths instead of major chords.

So it's lacking. But it does do the basics.

It has modes. It doesn't do major and minor scales separate from modes. So major scale is Ionian mode and minor scale is Aeolian mode.

Here are some of the things you can do:

- Create basic chords with new Chord(Key, BasicChord) where BasicChord is an enum with a variety of standard chords. 
- Get chords for a key/mode combination. So, for example, you can get 7 basic chords for C# Phrygian (see example below)
- Find secondary dominants - `var chord = key.GetSecondaryDominant(2)` gets V/iii (zero-based index).
- Get notes of a key. 
- Find intervals between degrees of a scale.



A simple example:

```c#
class Program
{
    static void Main(string[] args)
    {
        PrintEMajorChords();
    }

    public static void PrintEMajorChords()
    {
        var key = new Key("E", Mode.Ionian);
        var chords = key.GetChords();
        foreach(KeyChord chord in chords)
        {
            Console.WriteLine(chord.Chord);
        }
    }        
}

E (Ionian) - E G# B 
F# (Ionian) - F# A C# 
G# (Ionian) - G# B D#
A (Ionian) - A C# E
B (Ionian) - B D# F#
C# (Ionian) - C# E G#
D# (Ionian) - D# F# A
```