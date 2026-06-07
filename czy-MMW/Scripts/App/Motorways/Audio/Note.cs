using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public static class Note
	{
		public static readonly List<string> SCALE = Liszt.From<string>("C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B");

		public static readonly List<string> RANGE = GetFullRange();

		public static float GainFactor(string note)
		{
			float x = (float)RANGE.IndexOf(note) / (float)RANGE.Count;
			return Mathf.Lerp(Settings.Gain.KEYBOARD.x, Settings.Gain.KEYBOARD.y, Twerp.Ease.Out(x, 2));
		}

		public static List<string> TransposeRoot(int intervalDelta, params string[] notes)
		{
			List<string> list = new List<string>();
			foreach (string item in notes)
			{
				list.Add(SCALE.SafeGet(SCALE.IndexOf(item) + intervalDelta));
			}
			return list;
		}

		public static List<string> Transpose(int intervalDelta, List<string> notes)
		{
			if (intervalDelta == 0)
			{
				return notes;
			}
			List<string> list = new List<string>();
			foreach (string note in notes)
			{
				list.Add(Transpose(intervalDelta, note));
			}
			return list;
		}

		public static string Transpose(int intervalDelta, string note)
		{
			if (intervalDelta == 0)
			{
				return note;
			}
			int num = RANGE.IndexOf(note) + intervalDelta;
			if (num < 0)
			{
				int num2 = num;
				num = Maf.FloorMod(num, 12);
				AudioSystem.Log.Warn("Requested transposition of {2} at index {0} was too low. Replaced with {1}", num2, RANGE[num], intervalDelta);
			}
			if (num > RANGE.Count - 1)
			{
				int num3 = num;
				num = RANGE.Count - 12 + Maf.FloorMod(num - RANGE.Count, 12);
				AudioSystem.Log.Warn("Requested transposition of {2} at index {0} was too high. Replaced with {1}", num3, RANGE[num], intervalDelta);
			}
			return RANGE[num];
		}

		private static List<string> GetFullRange()
		{
			List<string> list = new List<string>();
			for (int i = 2; i <= 5; i++)
			{
				for (int j = 0; j < SCALE.Count; j++)
				{
					list.Add(SCALE[j] + i);
				}
			}
			return list;
		}
	}
}
