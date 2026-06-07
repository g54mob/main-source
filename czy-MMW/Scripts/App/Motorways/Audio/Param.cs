using UnityEngine;

namespace Motorways.Audio
{
	public static class Param
	{
		public class Data
		{
			public float Value;

			public Vector2 Range;

			public Data(float value, float valueMax = -1f)
			{
				Value = value;
				Range = new Vector2(value, (valueMax < 0f) ? value : valueMax);
			}

			public override string ToString()
			{
				return Range.ToString();
			}
		}

		public class LFO
		{
			public Data Freq;

			public Data Amp;

			public LFO(Data freq, Data amp)
			{
				Freq = freq;
				Amp = amp;
			}
		}

		public class Vibrato : LFO
		{
			public Vibrato(Data freq, int strengthInCents)
				: base(freq, new Data(0f, Tune.centsToFreqRatio(strengthInCents) - 1f))
			{
			}
		}

		public class Portamento
		{
			public Data StartingPitch;

			public Data Time;

			public Portamento(int startingPitchDeltaMinCents = 0, int startingPitchDeltaMaxCents = 0, double timeMin = 0.0, double timeMax = 0.0)
			{
				StartingPitch = new Data(Tune.centsToFreqRatio(startingPitchDeltaMinCents), Tune.centsToFreqRatio(startingPitchDeltaMaxCents));
				Time = new Data((float)timeMin, (float)timeMax);
			}
		}

		public class Group
		{
			public Data Pitch;

			public Data Gain;

			public Group(Data gain = null, Data pitch = null)
			{
				Gain = gain ?? new Data(1f);
				Pitch = pitch ?? new Data(1f);
			}

			public static Group Make(float gMin, float gMax, float pMin, float pMax)
			{
				return new Group(new Data(gMin, gMax), new Data(pMin, pMax));
			}

			public override string ToString()
			{
				return "Gain: [" + Gain.ToString() + "], Pitch: [" + Pitch.ToString() + "]";
			}
		}

		public static Group Gain(float gMin, float gMax = -1f)
		{
			return new Group(new Data(gMin, gMax));
		}

		public static Group Gain(this Group sp, float gMin, float gMax = -1f)
		{
			sp.Gain = new Data(gMin, gMax);
			return sp;
		}

		public static Group Pitch(float pMin, float pMax = -1f)
		{
			return new Group(null, new Data(pMin, pMax));
		}

		public static Group Pitch(this Group sp, float pMin, float pMax = -1f)
		{
			sp.Pitch = new Data(pMin, pMax);
			return sp;
		}
	}
}
