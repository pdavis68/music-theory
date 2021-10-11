using System;
using System.Collections.Generic;

namespace music_theory
{
    public enum BasicChord
    {
        Major,
        Minor,
        d7,
        M7,
        m7,
        mM7,
        m6,
        dim,
        dim7,
        halfdim7,
        aug,
        aug7,
        sus2,
        sus4
    }

    public class Chord
    {
        private Key _key;
        public Key Key { get => _key; set => _key = value; }
        public Note Root { get => _key.Root; }
        private Note[] _notes;
        public Note[] Notes { get => _notes; set => _notes = value; }

        public Chord(params Note[] notes)
        {
            _key = new Key(notes[0]);
            _notes = notes;
        }

        public Chord(Key key, params Note[] notes)
        {
            _key = key;
            _notes = notes;
        }

        public Chord(Key key, BasicChord basicChord)
        {
            _key = key;
            _notes = GenerateChordNotes(key.Root, basicChord);
        }

        private Note[] GenerateChordNotes(Note root, BasicChord basicChord)
        {
            List<Note> notes = new List<Note>();

            switch (basicChord)
            {
                case BasicChord.Major:
                    notes.Add(root);
                    notes.Add(root.GetMajorThird());
                    notes.Add(root.GetPerfectFifth());
                break;

                case BasicChord.Minor:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetPerfectFifth());
                break;

                case BasicChord.dim:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetDiminishedFifth());
                break;

                case BasicChord.dim7:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetDiminishedFifth());
                break;

                case BasicChord.d7:
                    notes.Add(root);
                    notes.Add(root.GetMajorThird());
                    notes.Add(root.GetPerfectFifth());
                    notes.Add(root.GetMinorSeventh());
                break;

                case BasicChord.m7:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetPerfectFifth());
                    notes.Add(root.GetMinorSeventh());
                break;

                case BasicChord.M7:
                    notes.Add(root);
                    notes.Add(root.GetMajorThird());
                    notes.Add(root.GetPerfectFifth());
                    notes.Add(root.GetMajorSeventh());
                break;

                case BasicChord.mM7:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetPerfectFifth());
                    notes.Add(root.GetMajorSeventh());
                break;

                case BasicChord.aug:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetMinorSixth());
                break;

                case BasicChord.aug7:
                    notes.Add(root);
                    notes.Add(root.GetMinorThird());
                    notes.Add(root.GetMinorSixth());
                    notes.Add(root.GetMinorSeventh());
                break;

                case BasicChord.sus2:
                    notes.Add(root);
                    notes.Add(root.GetMajorSecond());
                    notes.Add(root.GetPerfectFifth());
                break;

                case BasicChord.sus4:
                    notes.Add(root);
                    notes.Add(root.GetPerfectFourth());
                    notes.Add(root.GetPerfectFifth());
                break;

                default:
                    throw new NotImplementedException();
            }

            return notes.ToArray();
        }


        public override string ToString()
        {
            string chord = $"{_key.Root} ({_key.Mode.ToString()}) - ";
            foreach(Note note in _notes)
            {
                chord += $"{note} ";
            }
            return chord;
        }
    }
}