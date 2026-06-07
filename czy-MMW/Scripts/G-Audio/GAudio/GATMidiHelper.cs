using UnityEngine;

namespace GAudio
{
	public static class GATMidiHelper
	{
		private static string[] __notesShatp = new string[12]
		{
			"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A",
			"A#", "B"
		};

		private static string[] __notesFlat = new string[12]
		{
			"C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A",
			"Bb", "B"
		};

		public static string MidiCodeToString(int midiCode, bool flats = false)
		{
			int num = midiCode / 12 - 1;
			if (num < 0)
			{
				return "";
			}
			int num2 = midiCode % 12;
			if (flats)
			{
				return $"{__notesFlat[num2]}-{num.ToString()}";
			}
			return $"{__notesShatp[num2]}-{num.ToString()}";
		}

		public static int FrequencyToClosestMidiCode(float frequency)
		{
			return Mathf.RoundToInt(69f + 12f * Mathf.Log(frequency / 440f, 2f));
		}

		public static float FrequencyToMidiCode(float frequency, float tuningA = 440f)
		{
			return 69f + 12f * Mathf.Log(frequency / tuningA, 2f);
		}

		public static float MidiCodeToFrequency(float midicode, float tuningA = 440f)
		{
			return tuningA / 32f * Mathf.Pow(2f, (midicode - 9f) / 12f);
		}
	}
}
