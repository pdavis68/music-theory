using System.ComponentModel.DataAnnotations;
namespace music_theory
{
    public class KeyChord
    {
        private int _chordNumber = 1;
        public int ChordNumber {get => _chordNumber; set => _chordNumber = value;}
        private string _descriptor = string.Empty;
        public string Descriptor {get => _descriptor; set => _descriptor = value;}
        private Chord _chord = null;
        public Chord Chord {get => _chord; set => _chord = value;}
    }
}