using System;
using System.Collections;
using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public static class Twerp
	{
		public enum CurveType
		{
			None = 0,
			EaseIn = 1,
			EaseOut = 2,
			EaseInOut = 3,
			Boing = 4,
			Bounce = 5,
			ElasticIn = 6,
			ElasticOut = 7,
			ElasticInOut = 8,
			Volume = 9
		}

		public static class Ease
		{
			public static float In(float x, int pow)
			{
				while (pow > 1)
				{
					x *= x;
					pow--;
				}
				return x;
			}

			public static float Out(float x, int pow)
			{
				return 1f - In(1f - x, pow);
			}

			public static float InOut(float x, int pow)
			{
				if ((x *= 2f) < 1f)
				{
					return 0.5f * In(x, pow);
				}
				return 0.5f * Out(x, pow);
			}
		}

		public static class Elastic
		{
			public static float In(float x)
			{
				if (Mathf.Approximately(x, 0f))
				{
					return 0f;
				}
				if (Mathf.Approximately(x, 1f))
				{
					return 1f;
				}
				return (0f - Mathf.Pow(2f, 10f * (x - 1f))) * Mathf.Sin((x - 1.1f) * 5f * (float)Math.PI);
			}

			public static float Out(float x)
			{
				if (Mathf.Approximately(x, 0f))
				{
					return 0f;
				}
				if (Mathf.Approximately(x, 1f))
				{
					return 1f;
				}
				return Mathf.Pow(2f, -10f * x) * Mathf.Sin((x - 0.1f) * 5f * (float)Math.PI) + 1f;
			}

			public static float InOut(float x)
			{
				if (Mathf.Approximately(x, 0f))
				{
					return 0f;
				}
				if (Mathf.Approximately(x, 1f))
				{
					return 1f;
				}
				x *= 2f;
				if (x < 1f)
				{
					return -0.5f * Mathf.Pow(2f, 10f * (x - 1f)) * Mathf.Sin((x - 1.1f) * 5f * (float)Math.PI);
				}
				return 0.5f * Mathf.Pow(2f, -10f * (x - 1f)) * Mathf.Sin((x - 1.1f) * 5f * (float)Math.PI) + 1f;
			}
		}

		public static class Bounce
		{
			public static float In(float x)
			{
				return 1f - Out(1f - x);
			}

			public static float In2(float x)
			{
				return Mathf.Abs(x - Mathf.Abs(Mathf.Sin(6.28f * (x + 1f) * (x + 1f)) * (1f - x)));
			}

			public static float Out(float x)
			{
				if (x < 0.36363637f)
				{
					return 121f * x * x / 16f;
				}
				if (x < 0.72727275f)
				{
					return 9.075f * x * x - 9.9f * x + 3.4f;
				}
				if (x < 0.9f)
				{
					return 12.066482f * x * x - 19.635458f * x + 8.898061f;
				}
				return 10.8f * x * x - 20.52f * x + 10.72f;
			}

			public static float InOut(float x)
			{
				if (x < 0.5f)
				{
					return In(x * 2f) * 0.5f;
				}
				return Out(x * 2f - 1f) * 0.5f + 0.5f;
			}
		}

		public static Coroutine StartCoroutine(IEnumerator routine)
		{
			return GATManager.UniqueInstance.StartCoroutine(routine);
		}

		public static IEnumerator InterpolateFloatBoingInPlace(Action<float> val, float from, float duration, float freq, float amp, float phase = 0f, Action<bool> callback = null)
		{
			float elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				float x = elapsedTime / duration;
				x = BoingInPlace(x, freq, amp, phase);
				val(from + x * from);
				yield return new WaitForEndOfFrame();
			}
			callback?.Invoke(obj: true);
		}

		public static IEnumerator InterpolateFloat(Action<float> val, float from, float to, float duration, int pow = 1, CurveType curve = CurveType.None, Action<bool> callback = null)
		{
			if (Mathf.Approximately(from, to))
			{
				yield break;
			}
			float elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				float num = elapsedTime / duration;
				float t = num;
				if (curve == CurveType.None)
				{
					if (pow > 1)
					{
						curve = CurveType.EaseIn;
					}
					else if (pow < -1)
					{
						curve = CurveType.EaseOut;
					}
				}
				pow = Mathf.Abs(pow);
				switch (curve)
				{
				case CurveType.EaseIn:
					t = Ease.In(num, pow);
					break;
				case CurveType.EaseOut:
					t = Ease.Out(num, pow);
					break;
				case CurveType.EaseInOut:
					t = Ease.InOut(num, pow);
					break;
				case CurveType.Boing:
					t = Boing(num);
					break;
				case CurveType.Bounce:
					t = Bounce.In(num);
					break;
				case CurveType.ElasticIn:
					t = Elastic.In(num);
					break;
				case CurveType.ElasticOut:
					t = Elastic.Out(num);
					break;
				case CurveType.ElasticInOut:
					t = Elastic.InOut(num);
					break;
				case CurveType.Volume:
					t = ((from < to) ? Maf.VolCurve(num) : (1f - Maf.VolCurve(1f - num)));
					break;
				}
				val(Mathf.Lerp(from, to, t));
				yield return new WaitForEndOfFrame();
			}
			callback?.Invoke(obj: true);
		}

		public static float Boing(float x)
		{
			x = Mathf.Clamp01(x);
			x = (Mathf.Sin(x * (float)Math.PI * (0.2f + 2.5f * x * x * x)) * Mathf.Pow(1f - x, 2.2f) + x) * (1f + 1.2f * (1f - x));
			return x;
		}

		public static float BoingInPlace(float x, float freq, float amp, float phase = 0f)
		{
			return (1f - x) * amp * Mathf.Sin(x * (freq * (1f - x)) * 2f * (float)Math.PI + Mathf.Lerp(0f, (float)Math.PI * 2f, phase));
		}
	}
}
