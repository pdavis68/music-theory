using System;
using System.Collections.Generic;

namespace music_theory
{
    public enum Mode
    {
        Ionian = 0,
        Dorian = 1,
        Phrygian = 2,
        Lydian = 3,
        Mixolydian = 4,
        Aeolian = 5,
        Locrian = 6
    }

    public class Key
    {

        private readonly string _chordTypes = "MmmMMmd";
        private readonly int[] _intervals = new int[] { 2, 2, 1, 2, 2, 2, 1 };

        private Note _root;
        public Note Root => _root;
        private Mode _mode = Mode.Ionian;
        public Mode Mode  { get  =>_mode; set => _mode = value; }

        public Key(Note root)
        {
            _root = root;
        }

        public Key(string root)
        {
            _root = Note.CreateNote(root);
        }

        public Key(Note root, Mode mode)
        {
            _root = root;
            _mode = mode;
        }

        public Key(string root, Mode mode)
        {
            _root = Note.CreateNote(root);
            _mode = mode;
        }

        #region Public Methods
        public void SetMode(Mode mode) 
        {
            _mode = mode;
        }

        public Note GetMinorSecond()
        {
            return new Note(_root.Value + 1);
        } 

        public Note GetMajorSecond()
        {
            return new Note(_root.Value + 2);
        } 

        public Note GetMinorThird()
        {
            return new Note(_root.Value + 3);
        } 

        public Note GetMajorThird()
        {
            return new Note(_root.Value + 4);
        } 

        public Note GetPerfectFourth()
        {
            return new Note(_root.Value + 5);
        } 

        public Note GetAugmentedFourth()
        {
            return new Note(_root.Value + 6);
        } 

        public Note GetDiminishedFifth()
        {
            return new Note(_root.Value + 6);
        } 

        public Note GetPerfectFifth()
        {
            return new Note(_root.Value + 7);
        } 

        public Note GetMinorSixth()
        {
            return new Note(_root.Value + 8);
        } 

        public Note GetMajorSixth()
        {
            return new Note(_root.Value + 9);
        } 

        public Note GetMinorSeventh()
        {
            return new Note(_root.Value + 10);
        } 

        public Note GetMajorSeventh()
        {
            return new Note(_root.Value + 11);
        } 

        public int GetInterval(int keyNote)
        {
            if (keyNote < 0 || keyNote > 7)
            {
                throw new ArgumentOutOfRangeException("keyNote must be between 1 and 7");
            }
            int interval = 0;
            for(int count = 0; count < keyNote; count++)
            {
                interval += _intervals[Normalize(count + (int) _mode, 7)];
            }
            return interval;
        }

        public Note GetKeyNote(int keyNote)
        {
            if (keyNote < 1 || keyNote > 7)
            {
                throw new ArgumentOutOfRangeException("keyNote must be between 1 and 7");
            }
            return new Note(_root.Value + GetInterval(keyNote));

        }

        public string GetChordDescriptor(int chordNumber)
        {
            int chordType = Normalize(chordNumber + (int) _mode, 7);
            switch(_chordTypes[chordType])
            {
                case 'M':
                    return RomanNumeral(chordNumber + 1, true);
                case 'm':
                    return RomanNumeral(chordNumber + 1, false);
                case 'd':
                    return RomanNumeral(chordNumber + 1, false) + "dim";
                default:
                throw new InvalidOperationException("Unknown chord type");
            }
        }

        private string RomanNumeral(int chordNumber, bool isMajor)
        {
            if (isMajor)
            {
                switch(chordNumber)
                {
                    case 1: return "I";
                    case 2: return "II";
                    case 3: return "III";
                    case 4: return "IV";
                    case 5: return "V";
                    case 6: return "VI";
                    case 7: return "VII";
                    default: throw new InvalidOperationException("Invalid chord number");
                    
                }
            }
            else
            {
                switch(chordNumber)
                {
                    case 1: return "i";
                    case 2: return "ii";
                    case 3: return "iii";
                    case 4: return "iv";
                    case 5: return "v";
                    case 6: return "vi";
                    case 7: return "vii";
                    default: throw new InvalidOperationException("Invalid chord number");
                    
                }
            }
        }

        public KeyChord[] GetChords()
        {
            List<KeyChord> _keyChords = new List<KeyChord>();
            for(int index = 1; index <=7; index++)
            {
                _keyChords.Add(new KeyChord(){ChordNumber = index, Descriptor = GetChordDescriptor(index - 1), Chord = GetChord(index - 1)});
            }
            return _keyChords.ToArray();
        }


        public Chord GetChord(int chordNumber)
        {
            int chordType = Normalize(chordNumber + (int) _mode, 7);
            Note chordRoot = new Note(_root.Value + GetInterval(chordNumber), _root.IsSharp);
            switch(ChordType(chordNumber))
            {
                case 'M':
                    return new Chord(new Key(chordRoot, _mode), BasicChord.Major);
                case 'm':
                    return new Chord(new Key(chordRoot, _mode), BasicChord.Minor);
                case 'd':
                    return new Chord(new Key(chordRoot, _mode), BasicChord.dim);
                default: throw new InvalidOperationException("Invalid chord number");
            }
        }

        private char ChordType(int chordNumber)
        {
            int chordType = Normalize(chordNumber + (int) _mode, 7);
            return _chordTypes[chordType];
        }

        public Chord GetSecondaryDominant(int keyNote)
        {
            Note newRoot = GetKeyNote(keyNote);
            return new Key(newRoot, Mode.Ionian).GetChord(4);
        }

        private int Normalize(int value, int normal)
        {
            while (value < 0)
            {
                value += normal;
            }
            while(value >= normal)
            {
                value -= normal;
            }
            return value;
        }


        #endregion

    }
}