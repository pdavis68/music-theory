using System;

namespace music_theory
{
    public class Note
    {
        #region Enums


        public enum NoteName
        {
            A = 0,
            AS = 1,
            B = 2,
            C = 3,
            CS = 4,
            D = 5,
            DS = 6,
            E = 7,
            ES = 8,
            F = 8,
            FS = 9,
            G = 10,
            GS = 11
        }

        #endregion
  
        #region Constructors 

        public Note(int value)
        {
            _value = NormalizeValue(value);
        }

        public Note(NoteName noteName)
        {
            _value = (int) noteName;
        }

        public Note(int value, bool isSharp) : this(value)
        {
            _isSharp = isSharp;
        }

        #endregion

        #region Fields & Properties

        private int _value;
        public int Value { get => _value;}

        private bool _isSharp = true;
        public bool IsSharp { get => _isSharp; set => _isSharp = value; }

        public NoteName Name 
        {
            get
            {
                return GetName(_value);
            }
        }

        #endregion

        #region Public Methods

        public void SetValue(int value) 
        {
            value = NormalizeValue(value);
            _value = value;
        }

        public Note GetMinorSecond()
        {
            return new Note(_value + 1);
        } 

        public Note GetMajorSecond()
        {
            return new Note(_value + 2);
        } 

        public Note GetMinorThird()
        {
            return new Note(_value + 3);
        } 

        public Note GetMajorThird()
        {
            return new Note(_value + 4);
        } 

        public Note GetPerfectFourth()
        {
            return new Note(_value + 5);
        } 

        public Note GetAugmentedFourth()
        {
            return new Note(_value + 6);
        } 

        public Note GetDiminishedFifth()
        {
            return new Note(_value + 6);
        } 

        public Note GetPerfectFifth()
        {
            return new Note(_value + 7);
        } 

        public Note GetMinorSixth()
        {
            return new Note(_value + 8);
        } 

        public Note GetMajorSixth()
        {
            return new Note(_value + 9);
        } 

        public Note GetMinorSeventh()
        {
            return new Note(_value + 10);
        } 

        public Note GetMajorSeventh()
        {
            return new Note(_value + 11);
        } 

        #endregion

        #region Private Methods

        private NoteName GetName(int value)
        {
                switch(NormalizeValue(value))
                {
                    case 0: 
                    case 1:
                        return NoteName.A;
                    case 2:
                        return NoteName.B;
                    case 3: 
                    case 4:
                        return NoteName.C;
                    case 5: 
                    case 6:
                        return NoteName.D;
                    case 7: 
                        return NoteName.E;
                    case 8:
                    case 9: 
                        return NoteName.F;
                    case 10: 
                    case 11:
                        return NoteName.G;
                    default:
                        throw new InvalidOperationException("NormalizeValue() must return a value between 0 and 11");;
                }

        }

        private int NormalizeValue(int value)
        {
            while (value > 11)
            {
                value -= 12;
            }
            while (value < 0)
            {
                value += 12;
            }
            return value;
        }

        #endregion

        #region Public Overrides

        public override string ToString()
        {
            string note = string.Empty;
            if (_isSharp)
            {
                note = GetName(_value).ToString();
                switch(_value)
                {
                    case 1:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                    note += "#";
                    break;
                    default:
                    break;
                }
            }
            else
            {
                note = GetName(_value - 1).ToString();
                switch(_value)
                {
                    case 0:
                    case 3:
                    case 5:
                    case 7:
                    case 10:
                    note += "\u266D";
                    break;
                    default:
                    break;
                }
           }
            return note;
        }

        #endregion

        #region Public Static

        public static Note CreateNote(string note)
        {
            return NoteFromString(note);
        }

        #endregion

        #region Private Static

        private static Note NoteFromString(string note)
        {
            note = note.ToUpper().Trim();
            if (note == "AB" || note == "A\u266D")
            {
                return new Note(0, false);
            }
            else if (note == "A")
            {
                return new Note(0, true);
            }
            else if (note == "A#")
            {
                return new Note(1, true);
            }
            else if (note == "B")
            {
                return new Note(2, true);
            }
            else if (note == "CB" || note == "C\u266D")
            {
                return new Note(3, false);
            }
            else if (note == "C")
            {
                return new Note(3, true);
            }
            else if (note == "C#")
            {
                return new Note(4, true);
            }
            else if (note == "DB" || note == "D\u266D")
            {
                return new Note(5, false);
            }
            else if (note == "D")
            {
                return new Note(5, true);
            }
            else if (note == "D#")
            {
                return new Note(6, true);
            }
            else if (note == "E")
            {
                return new Note(7, true);
            }
            else if (note == "FB" || note == "F\u266D")
            {
                return new Note(8, false);
            }
            else if (note == "F")
            {
                return new Note(8, true);
            }
            else if (note == "F#")
            {
                return new Note(9, true);
            }
            else if (note == "GB" || note == "G\u266D")
            {
                return new Note(10, false);
            }
            else if (note == "G")
            {
                return new Note(10, true);
            }
            else if (note == "G#")
            {
                return new Note(11, true);
            }
            throw new ArgumentException($"Unable to interpret note: {note}");
        }

        #endregion

    }
}