using System.Collections.Generic;

namespace Motorways.Audio
{
	public static class QualityDatabase
	{
		public static readonly Quality MAJOR_TETRA = new Quality("Major Tetra", Liszt.From<int>(2, 2, 1, 7), Liszt.From<int>(0, 12, 24)).Modal("Major Lower Tetra", "Minor Cross Tetra", "Phrygian Cross Tetra", "Major Upper Tetra");

		public static readonly Quality MINOR_TETRA = new Quality("Minor Tetra", Liszt.From<int>(2, 1, 2, 7), Liszt.From<int>(0, 12, 24)).Modal("Minor Lower Tetra", "Locrian Cross Tetra", "Ionian Cross Tetra", "Minor Upper Tetra");

		public static readonly Quality PHRYGIAN_TETRA = new Quality("Phrygian Tetra", Liszt.From<int>(1, 2, 2, 7), Liszt.From<int>(0, 12, 24)).Modal("Phrygian Lower Tetra", "Lydian Cross Tetra", "Mixolydian Upper Cross Tetra", "Phrygian Upper Tetra");

		public static readonly Quality ALTERED_TETRA = new Quality("Altered Tetra", Liszt.From<int>(1, 2, 1, 8), Liszt.From<int>(0, 12, 24)).Modal("Altered Lower Tetra", "Harmonic Minor Cross Tetra", "Mixo b2 Cross Tetra", "Altered Upper Tetra");

		public static readonly Quality HARMONIC_TETRA = new Quality("Harmonic Tetra", Liszt.From<int>(1, 3, 1, 7), Liszt.From<int>(0, 12, 24)).Modal("Harmonic Lower Tetra", "Lydian #2 Cross Tetra", "Locrian bb7 Cross Tetra", "Harmonic Upper Tetra");

		public static readonly Quality LYDIAN_TETRA = new Quality("Lydian Tetra", Liszt.From<int>(2, 2, 2, 6), Liszt.From<int>(0, 12, 24)).Modal("Lydian Lower Tetra", "Mixolydian Lower Cross Tetra", "Aeolian Cross Tetra", "Lydian Upper Tetra");

		public static readonly List<Quality> HEXATONIC_PREINIT = Liszt.From<Quality>(new Quality("Hexatonic no1", Liszt.From<int>(2, 1, 2, 2, 2, 3), Liszt.From<int>(0, 12, 24)), new Quality("Hexatonic no2", Liszt.From<int>(4, 1, 2, 2, 2, 1), Liszt.From<int>(0, 12, 24)), new Quality("Hexatonic no3", Liszt.From<int>(2, 3, 2, 2, 2, 1), Liszt.From<int>(0, 12, 24)), new Quality("Hexatonic no4", Liszt.From<int>(2, 2, 3, 2, 2, 1), Liszt.From<int>(0, 12, 24)), new Quality("Hexatonic no5", Liszt.From<int>(2, 2, 1, 4, 2, 1), Liszt.From<int>(0, 12, 24)), new Quality("Hexatonic no6", Liszt.From<int>(2, 2, 1, 2, 4, 1), Liszt.From<int>(0, 12, 24)), new Quality("Hexatonic no7", Liszt.From<int>(2, 2, 1, 2, 2, 3), Liszt.From<int>(0, 12, 24)));

		public static readonly List<Quality> INTERVALS = Liszt.From<Quality>(new Quality("Wholetone", Liszt.From<int>(2)).Chromatic(), new Quality("Diminished Triad", Liszt.From<int>(3)).Chromatic(), new Quality("Augmented Triad", Liszt.From<int>(4)).Chromatic(), new Quality("Quartal", Liszt.From<int>(5)).Chromatic(), new Quality("Overtone", Liszt.From<int>(7)).Chromatic());

		public static readonly List<Quality> HEXATONIC_CHROMATIC = HEXATONIC_PREINIT.Chromatic();

		public static readonly List<Quality> HEXATONIC_MODAL = HEXATONIC_PREINIT.Modal("Modal");

		public static readonly List<Quality> HEXATONIC_CHROMODAL = HEXATONIC_MODAL.Chromatic("Chromodal");

		public static readonly List<Quality> SUHMM = Liszt.From<Quality>(new Quality("SUHMM Mixolydian", Liszt.From<int>(2, 2, 1), Liszt.From<int>(0, 12, 24)), new Quality("SUHMM Aeolian", Liszt.From<int>(2, 1, 2), Liszt.From<int>(0, 12, 24)), new Quality("SUHMM Phrygian", Liszt.From<int>(1, 2, 2, 2), Liszt.From<int>(0, 12, 24)), new Quality("SUHMM Lydian", Liszt.From<int>(2, 2, 2, 1), Liszt.From<int>(0, 12, 24)), new Quality("SUHMM Locrian", Liszt.From<int>(1, 2, 2), Liszt.From<int>(0, 12, 24))).Chromatic();

		public static readonly List<Quality> TETRA_MODES = Liszt.Flatten<Quality>(ALTERED_TETRA.ToModes(), HARMONIC_TETRA.ToModes(), LYDIAN_TETRA.ToModes(), MAJOR_TETRA.ToModes(), MINOR_TETRA.ToModes(), PHRYGIAN_TETRA.ToModes());

		public static readonly List<Quality> TETRA = Liszt.From<Quality>(MAJOR_TETRA, MINOR_TETRA, PHRYGIAN_TETRA, ALTERED_TETRA, HARMONIC_TETRA, LYDIAN_TETRA);

		public static readonly List<Quality> TETRA_CHROMODAL = TETRA.Chromatic("Chromodal");

		public static readonly Quality MAJOR = new Quality("Major", Liszt.From<int>(2, 2, 1, 2, 2, 2, 1), Liszt.From<int>(0, 12)).ModalVerbose(new Scale.Data("Ionian", 19), new Scale.Data("Dorian", 19), new Scale.Data("Phrygian", 19), new Scale.Data("Lydian", 18), new Scale.Data("Mixolydian", 19), new Scale.Data("Aeolian", 19), new Scale.Data("Locrian", 18));

		public static readonly Quality MELODIC_MINOR = new Quality("Melodic Minor", Liszt.From<int>(2, 1, 2, 2, 2, 2, 1), Liszt.From<int>(0, 12)).Modal("Melodic Minor", "Dorian b2", "Lydian Augmented", "Lydian Dominant", "Aeolian Dominant", "Half Diminished", "Altered");

		public static readonly Quality HARMONIC_MINOR = new Quality("Harmonic Minor", Liszt.From<int>(2, 1, 2, 2, 1, 3, 1)).Modal("Harmonic Minor", "Locrian Natural 6", "Major #5", "Dorian #4", "Phrygian Dominant", "Lydian #2", "Altered Dominant bb7");

		public static readonly Quality HARMONIC_MAJOR = new Quality("Harmonic Major", Liszt.From<int>(2, 2, 1, 2, 1, 3, 1)).Modal("Harmonic Major", "Dorian b5", "Phrygian b4", "Lydian Minor", "Mixolydian b2", "Lydian Augmented #2", "Locrian bb7");

		public static readonly Quality DOUBLE_HARMONIC = new Quality("Double Harmonic", Liszt.From<int>(1, 3, 1, 2, 1, 3, 1)).Modal("Double Harmonic", "Lydian #2 #6", "Ultraphrygian", "Hungarian Minor", "Mixolydian b2 b5", "Ionian #2 #5", "Locrian bb3 bb7");

		public static readonly Quality INSEN = new Quality("Insen", Liszt.From<int>(1, 4, 2, 3, 2)).Modal();

		public static readonly Quality IN = new Quality("In", Liszt.From<int>(1, 4, 2, 1, 4)).Modal();

		public static readonly Quality MAJOR_B6_PENTA = new Quality("Major b6 Penta", Liszt.From<int>(2, 2, 3, 1, 4)).Modal();

		public static readonly Quality SIX_NINE = new Quality("6/9", Liszt.From<int>(2, 2, 3, 2, 3));

		public static readonly Quality PENTA = Quality.Clone(SIX_NINE, "Penta").Modal("Major Pentatonic", "Penta 2", "Penta 3", "Yo", "Minor Pentatonic");

		public static readonly Quality NINE = new Quality("9", Liszt.From<int>(2, 2, 3, 3, 2));

		public static readonly Quality PENTA_DOM = Quality.Clone(NINE, "Dominant Penta").Modal();

		public static readonly List<Quality> ALL = Liszt.Flatten<Quality>(INTERVALS, SUHMM, HEXATONIC_MODAL, HEXATONIC_CHROMATIC, HEXATONIC_CHROMODAL, TETRA, TETRA_CHROMODAL, TETRA_MODES, MAJOR.ToModes(), MELODIC_MINOR.ToModes(), HARMONIC_MINOR.ToModes(), HARMONIC_MAJOR.ToModes(), DOUBLE_HARMONIC.ToModes(), INSEN.ToModes(), IN.ToModes(), MAJOR_B6_PENTA.ToModes(), PENTA.ToModes(), PENTA_DOM.ToModes(), Liszt.From<Quality>(MAJOR, Quality.Clone(MAJOR, "Major Chromodal").Chromatic(), DOUBLE_HARMONIC, Quality.Clone(DOUBLE_HARMONIC, "Double Harmonic Chromodal").Chromatic(), HARMONIC_MAJOR, Quality.Clone(HARMONIC_MAJOR, "Harmonic Major Chromodal").Chromatic(), HARMONIC_MINOR, Quality.Clone(HARMONIC_MINOR, "Harmonic Minor Chromodal").Chromatic(), MELODIC_MINOR, Quality.Clone(MELODIC_MINOR, "Melodic Minor Chromodal").Chromatic(), INSEN, Quality.Clone(INSEN, "Insen Chromodal").Chromatic(), IN, Quality.Clone(IN, "In Chromodal").Chromatic(), MAJOR_B6_PENTA, Quality.Clone(MAJOR_B6_PENTA, "Major b6 Penta Chromodal").Chromatic(), PENTA, Quality.Clone(PENTA, "Penta Chromodal").Chromatic(), PENTA_DOM, Quality.Clone(PENTA_DOM, "Dominant Penta Chromodal").Chromatic(), SIX_NINE.Chromatic(), NINE.Chromatic(), HEXATONIC_MODAL[6].GetMode(2, "Ritsu"), new Quality("Diminished", Liszt.From<int>(2, 1)).Chromatic(), new Quality("Aux Diminished", Liszt.From<int>(1, 2)).Chromatic(), new Quality("Augmented", Liszt.From<int>(3, 1)).Chromatic(), new Quality("Aux Augmented", Liszt.From<int>(1, 3)).Chromatic(), new Quality("7b5", Liszt.From<int>(4, 2)).Chromatic(), new Quality("5 (Power Chord)", Liszt.From<int>(7, 5), Liszt.From<int>(0, 12)).Chromatic(), new Quality("Petrushka", Liszt.From<int>(1, 3, 2)).Chromatic(), new Quality("5sus2", Liszt.From<int>(2, 5, 5), Liszt.From<int>(0, 12)).Chromatic(), new Quality("Minor Triad", Liszt.From<int>(3, 4, 5), Liszt.From<int>(0, 12)).Chromatic(), new Quality("Major Triad", Liszt.From<int>(4, 3, 5), Liszt.From<int>(0, 12)).Chromatic(), new Quality("Sus", Liszt.From<int>(5, 2, 5), Liszt.From<int>(0, 12)).Chromatic(), new Quality("Sus2Maj7", Liszt.From<int>(2, 5, 4, 1), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("Sus2Min7", Liszt.From<int>(2, 5, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("HalfDim", Liszt.From<int>(3, 3, 2, 4)).Chromatic(), new Quality("Min7b5", Liszt.From<int>(3, 3, 4, 2)).Chromatic(), new Quality("MinMaj6", Liszt.From<int>(3, 4, 2, 3)).Chromatic(), new Quality("Min7", Liszt.From<int>(3, 4, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("MinMaj7", Liszt.From<int>(3, 4, 4, 1)).Chromatic(), new Quality("Maj6", Liszt.From<int>(4, 3, 2, 3), Liszt.From<int>(0, 12)).Chromatic(), new Quality("7", Liszt.From<int>(4, 3, 3, 2), Liszt.From<int>(0, 12)).Chromatic(), new Quality("Maj7", Liszt.From<int>(4, 3, 4, 1), Liszt.From<int>(0, 12)).Chromatic(), new Quality("7#5", Liszt.From<int>(4, 4, 2, 2)).Chromatic(), new Quality("b7sus", Liszt.From<int>(5, 2, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("7b9", Liszt.From<int>(1, 3, 3, 3, 2)).Chromatic(), new Quality("Min9", Liszt.From<int>(2, 1, 4, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("7#9", Liszt.From<int>(3, 1, 3, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("11", Liszt.From<int>(4, 1, 2, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("Aug11", Liszt.From<int>(4, 2, 1, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("13", Liszt.From<int>(4, 3, 2, 1, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("Istrian", Liszt.From<int>(1, 2, 1, 2, 1, 5)).Chromatic(), new Quality("b9(13)", Liszt.From<int>(1, 3, 3, 2, 1, 2)).Chromatic(), new Quality("Min11", Liszt.From<int>(2, 1, 2, 2, 3, 2), Liszt.From<int>(0, 12, 19)).Chromatic(), new Quality("Mystic", Liszt.From<int>(2, 2, 2, 3, 1, 2)).Chromatic(), new Quality("Blues", Liszt.From<int>(3, 2, 1, 1, 3, 2)).Chromatic()));

		public static Quality Find(string name)
		{
			Quality quality = ALL.Find((Quality x) => x.Name == name);
			if (quality == null)
			{
				Dbug.Log.Error("Quality {0} Not Found.", name);
			}
			return quality;
		}

		public static List<Quality> Gather(params string[] names)
		{
			List<Quality> list = new List<Quality>();
			for (int i = 0; i < names.Length; i++)
			{
				list.Add(Find(names[i]));
			}
			return list;
		}
	}
}
