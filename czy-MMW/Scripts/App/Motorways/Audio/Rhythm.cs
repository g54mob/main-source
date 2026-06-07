using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public class Rhythm
	{
		public class PletDef
		{
			public List<float> Offsets;

			public List<float> Ratios;

			public List<float> SubRatios;

			public PletDef(List<float> offsets, List<float> ratios, List<float> subRatios = null)
			{
				Offsets = offsets;
				Ratios = ratios;
				SubRatios = subRatios;
			}

			public Rhythm Pulse(int seed = -1)
			{
				D20 d = new D20(seed);
				return new Rhythm(d.Pick(Offsets), d.Pick(Ratios));
			}

			public List<Rhythm> Pulses(int seed = -1)
			{
				D20 d20 = new D20(seed);
				return Liszt.Make(12, (int r_i) => new Rhythm(d20.Pick(Offsets), d20.Pick(Ratios)));
			}

			public List<Rhythm> All(int seed = -1)
			{
				return Pulses(seed).And(Patterns(seed));
			}

			public Rhythm Pattern(int seed = -1)
			{
				D20 d20 = new D20(seed);
				List<float> ratios = ((SubRatios == null) ? Ratios : Ratios.Concat(SubRatios).ToList());
				return new Rhythm(d20.Pick(Offsets), Liszt.Make(d20.Range(3, 6), () => d20.Pick(ratios)).ToArray());
			}

			public List<Rhythm> Patterns(int seed = -1)
			{
				D20 d20 = new D20(seed);
				List<float> ratios = ((SubRatios == null) ? Ratios : Ratios.Concat(SubRatios).ToList());
				return Liszt.Make(12, (int r_i) => new Rhythm(d20.Pick(Offsets), Liszt.Make(d20.Range(3, 6), () => d20.Pick(ratios)).ToArray()));
			}
		}

		public const int DEFAULT_SIZE = 12;

		public float[] Steps;

		public float Offset;

		public string Id;

		public static List<Rhythm> Claves = Liszt.From<Rhythm>(new Rhythm(0f, 0.5f, 0.75f, 0.5f, 1f, 0.5f, 0.75f), new Rhythm(0f, 0.75f, 0.75f, 1f, 0.5f, 1f), new Rhythm(0f, 0.75f, 0.25f, 0.75f, 0.25f, 0.5f, 0.5f, 0.75f, 0.25f), new Rhythm(0f, 0.25f, 0.5f, 0.25f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f), new Rhythm(0f, 0.75f, 0.75f, 0.75f, 0.75f, 1f), new Rhythm(0f, 0.75f, 0.75f, 1f, 0.75f, 0.75f), new Rhythm(0f, 0.25f, 0.5f, 0.5f, 0.5f, 0.25f, 0.5f, 0.5f, 0.5f, 0.5f), new Rhythm(0.25f, 0.5f, 0.5f, 0.5f, 0.25f, 0.5f, 0.5f, 0.5f, 0.75f), new Rhythm(0.25f, 0.5f, 0.75f, 1f, 0.75f, 0.5f, 0.5f), new Rhythm(0f, 0.5f, 0.75f, 0.5f, 0.5f, 0.75f, 0.5f, 0.5f), new Rhythm(0f, 0.25f, 0.5f, 0.25f, 0.5f, 0.5f, 0.5f, 0.5f, 0.25f, 0.5f, 0.25f), new Rhythm(0f, 0.5f, 0.5f, 0.5f, 0.5f, 0.25f, 0.5f, 0.25f, 0.5f, 0.5f), new Rhythm(0f, 0.25f, 0.5f, 0.5f, 0.25f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f));

		public static PletDef Duplet = new PletDef(Liszt.From<float>(0f, 0.25f, 0.5f, 0.75f), Liszt.From<float>(0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f, 1.75f, 2f), Liszt.From<float>(0.125f, 0.375f));

		public static PletDef Triplet = new PletDef(Liszt.From<float>(0f, 1f / 3f, 2f / 3f), Liszt.From<float>(1f / 3f, 2f / 3f, 0.5f, 1f, 1.3333334f, 1.6666666f, 2f), Liszt.From<float>(1f / 6f));

		public static PletDef Quintuplet = new PletDef(Liszt.From<float>(0f, 0.2f, 0.4f, 0.6f, 0.6f), Liszt.From<float>(0.2f, 0.4f, 0.6f, 0.8f, 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f));

		public float Duration { get; private set; }

		public Rhythm(float offsetRatio, params float[] steps)
		{
			Steps = steps;
			Offset = offsetRatio;
			Id = "HyperPulse: o." + Offset + ".s." + string.Join(", ", Steps);
			Duration = steps.Sum();
		}

		public Rhythm InjectNoise(float noise = 0f)
		{
			float[] array = new D20().Frag(Steps.Length, Duration);
			for (int i = 0; i < Steps.Length; i++)
			{
				Steps[i] = Mathf.Lerp(Steps[i], array[i], noise);
			}
			return this;
		}

		public static List<float> FragRatios(int steps)
		{
			float[] obj = new float[7] { 0f, 1.25f, 1.3333334f, 1.5f, 1.6666666f, 1.75f, 2f };
			obj[0] = ((steps == 5) ? 2f : 1f);
			return Liszt.From(obj);
		}

		public static Rhythm Frag(float noise = 1f, int seed = -1)
		{
			D20 d = new D20(seed);
			int num = d.Pick<int>(3, 6);
			return new Rhythm(0f, d.Frag(num, (num == 6) ? 2f : d.Pick(FragRatios(num)), noise));
		}

		public static List<Rhythm> Frags(int seed = -1)
		{
			D20 d20 = new D20(seed);
			return Liszt.Make(12, (Func<int, Rhythm>)delegate
			{
				int num = d20.Pick<int>(3, 6);
				return new Rhythm(0f, d20.Frag(num, (num == 6) ? 2f : d20.Pick(FragRatios(num))));
			});
		}

		public static Rhythm Sine(int steps, float duration, float freq, float strength = 0.5f, float offsetRatio = 0f)
		{
			strength = Mathf.Clamp01(strength);
			List<float> list = new List<float>();
			for (int i = 0; i < steps; i++)
			{
				float t = Mathf.Sin((float)i / (float)(steps - 1) * freq * 2f * (float)Math.PI) * 0.5f + 0.5f;
				float item = (Mathf.Approximately(strength, 0f) ? 1f : Mathf.Lerp(1f - strength, 1f + strength, t));
				list.Add(item);
			}
			return new Rhythm(offsetRatio, list.ToArray()).ToDuration(duration);
		}

		public static List<Rhythm> AllPlets(int seed = -1)
		{
			return Duplet.All().And(Triplet.All()).And(Quintuplet.All());
		}

		public static List<Rhythm> AllPulses(int seed = -1)
		{
			return Duplet.Pulses().And(Triplet.Pulses()).And(Quintuplet.Pulses());
		}

		public static List<Rhythm> AllPatterns(int seed = -1)
		{
			return Duplet.Patterns().And(Triplet.Patterns()).And(Quintuplet.Patterns());
		}

		public override string ToString()
		{
			return Id;
		}
	}
}
