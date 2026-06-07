using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public class D20
	{
		public int Seed;

		public System.Random Rand;

		public D20(int seed = -1)
		{
			Rand = ((seed == -1) ? new System.Random() : new System.Random(seed));
			Seed = seed;
		}

		public float Roll()
		{
			return (float)Rand.NextDouble();
		}

		public float Range(float min, float max)
		{
			return Mathf.Lerp(min, max, (float)Rand.NextDouble());
		}

		public int Range(int min, int max)
		{
			return Rand.Next(min, max + 1);
		}

		public T Pick<T>(List<T> list)
		{
			return list[Rand.Next(list.Count)];
		}

		public T Pick<T>(params T[] options)
		{
			return options[Rand.Next(options.Length)];
		}

		public int Index<T>(List<T> list)
		{
			return Range(0, list.Count - 1);
		}

		public T EnumValue<T>(int truncateFromEnd = 0)
		{
			Array values = Enum.GetValues(typeof(T));
			return (T)values.GetValue(Rand.Next(values.Length - truncateFromEnd));
		}

		public float[] Frag(int nbSteps, float duration, float noise = 1f, float minFrag = -1f, float maxFrag = -1f)
		{
			float num = duration / (float)nbSteps;
			if (minFrag < 0f)
			{
				minFrag = num * 0.5f;
			}
			if (maxFrag < 0f)
			{
				maxFrag = duration * 0.75f;
			}
			float[] array = new float[nbSteps];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Range(duration * minFrag, duration * maxFrag);
			}
			float sum = array.Sum();
			array = array.Select((float x, int num3) => x / sum * duration).ToArray();
			array[array.Length - 1] -= array.Sum() - duration;
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				array[num2] = Mathf.Lerp(num, array[num2], noise);
			}
			return array;
		}

		public bool Luck(float chance = 0.05f)
		{
			return Roll() < Mathf.Clamp01(chance);
		}
	}
}
