using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public static class Riddim
	{
		public static List<Rhythm> And(this List<Rhythm> list, List<Rhythm> rhythms)
		{
			return list.Concat(rhythms).ToList();
		}

		public static Rhythm Crop(this Rhythm r, float duration)
		{
			float num = r.Duration - duration;
			if (Mathf.Approximately(num, 0f))
			{
				return r;
			}
			List<float> list = r.Steps.ToList();
			if (num <= 0f)
			{
				list[list.Count - 1] += Mathf.Abs(num);
			}
			else
			{
				while (num > 0f)
				{
					float num2 = Mathf.Min(num, list[list.Count - 1]);
					list[list.Count - 1] -= num2;
					if (Mathf.Approximately(list[list.Count - 1], 0f))
					{
						list.RemoveAt(list.Count - 1);
					}
					num -= num2;
				}
			}
			r = new Rhythm(r.Offset, list.ToArray());
			return r;
		}

		public static List<Rhythm> Crop(this List<Rhythm> list, float duration)
		{
			return list.Edit((Rhythm x) => x.Crop(duration));
		}

		public static Rhythm ToDuration(this Rhythm r, float duration)
		{
			if (Mathf.Approximately(r.Duration, duration))
			{
				return r;
			}
			List<float> list = r.Steps.ToList();
			float stretchFactor = duration / r.Duration;
			list.Edit((float x) => x *= stretchFactor);
			return new Rhythm(r.Offset, list.ToArray());
		}

		public static List<Rhythm> ToDuration(this List<Rhythm> list, float duration)
		{
			return list.Edit((Rhythm x) => x.ToDuration(duration));
		}

		public static Rhythm Scale(this Rhythm r, float factor, bool scaleOffset = false)
		{
			if (Mathf.Approximately(factor, 1f))
			{
				return r;
			}
			List<float> list = r.Steps.ToList();
			list.Edit((float x) => x *= factor);
			return new Rhythm(scaleOffset ? (r.Offset * factor) : r.Offset, list.ToArray());
		}

		public static List<Rhythm> Scale(this List<Rhythm> list, float factor)
		{
			return list.Edit((Rhythm x) => x.Scale(factor));
		}

		public static Rhythm Backwards(this Rhythm r)
		{
			List<float> list = r.Steps.ToList();
			list.Reverse();
			return new Rhythm(1f - r.Offset, list.ToArray());
		}

		public static List<Rhythm> Backwards(this List<Rhythm> list)
		{
			return list.Edit((Rhythm x) => x.Backwards());
		}

		public static Rhythm Palindrome(this Rhythm r)
		{
			return new Rhythm(r.Offset, r.Steps.ToList().Palindrome().ToArray());
		}

		public static List<Rhythm> Palindrome(this List<Rhythm> list)
		{
			return list.Edit((Rhythm x) => x.Palindrome());
		}

		public static List<Rhythm> Uniform(this Rhythm r, int size = 12)
		{
			return Liszt.Make(size, () => r);
		}

		public static List<Rhythm> Scatter(this List<Rhythm> list, int seed = -1)
		{
			D20 d = new D20(seed);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = new Rhythm(d.Roll(), list[i].Steps);
			}
			return list;
		}

		public static List<Rhythm> Spread(this List<Rhythm> list, float delta = 0.0625f)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = new Rhythm(Maf.FloorMod((float)i * delta, 1f), list[i].Steps);
			}
			return list;
		}

		public static List<Rhythm> Phase(this List<Rhythm> list, float phase = 0.0625f)
		{
			for (int i = 0; i < list.Count; i++)
			{
				float[] array = list[i].Steps.ToArray();
				for (int j = 0; j < array.Length; j++)
				{
					array[j] += (float)i * phase;
				}
				list[i] = new Rhythm(list[i].Offset, array);
			}
			return list;
		}

		public static Rhythm Steppiest(this List<Rhythm> rhythms)
		{
			return rhythms.Aggregate((Rhythm max, Rhythm r) => (max != null && !(r?.Steps?.Count() > max?.Steps?.Count())) ? max : r);
		}

		public static Rhythm Shortest(this List<Rhythm> rhythms)
		{
			return rhythms.Aggregate((Rhythm min, Rhythm r) => (min != null && !(r.Duration < min.Duration)) ? min : r);
		}
	}
}
