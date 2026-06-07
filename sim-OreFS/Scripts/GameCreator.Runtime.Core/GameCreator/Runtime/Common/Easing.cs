using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class Easing
	{
		public enum Type
		{
			Linear = 0,
			QuadIn = 1,
			QuadOut = 2,
			QuadInOut = 3,
			QuadOutIn = 4,
			CubicIn = 5,
			CubicOut = 6,
			CubicInOut = 7,
			CubicOutIn = 8,
			QuartIn = 9,
			QuartOut = 10,
			QuartInOut = 11,
			QuartOutIn = 12,
			QuintIn = 13,
			QuintOut = 14,
			QuintInOut = 15,
			QuintOutIn = 16,
			SineIn = 17,
			SineOut = 18,
			SineInOut = 19,
			SineOutIn = 20,
			ExpoIn = 21,
			ExpoOut = 22,
			ExpoInOut = 23,
			ExpoOutIn = 24,
			CircIn = 25,
			CircOut = 26,
			CircInOut = 27,
			CircOutIn = 28,
			ElasticIn = 29,
			ElasticOut = 30,
			ElasticInOut = 31,
			ElasticOutIn = 32,
			BackIn = 33,
			BackOut = 34,
			BackInOut = 35,
			BackOutIn = 36,
			BounceIn = 37,
			BounceOut = 38,
			BounceInOut = 39,
			BounceOutIn = 40
		}

		public static float GetEase(Type type, float from, float to, float t)
		{
			return type switch
			{
				Type.Linear => Lerp(from, to, t), 
				Type.QuadIn => QuadIn(from, to, t), 
				Type.QuadOut => QuadOut(from, to, t), 
				Type.QuadInOut => QuadInOut(from, to, t), 
				Type.QuadOutIn => QuadOutIn(from, to, t), 
				Type.CubicIn => CubicIn(from, to, t), 
				Type.CubicOut => CubicOut(from, to, t), 
				Type.CubicInOut => CubicInOut(from, to, t), 
				Type.CubicOutIn => CubicOutIn(from, to, t), 
				Type.QuartIn => QuartIn(from, to, t), 
				Type.QuartOut => QuartOut(from, to, t), 
				Type.QuartInOut => QuartInOut(from, to, t), 
				Type.QuartOutIn => QuartOutIn(from, to, t), 
				Type.QuintIn => QuintIn(from, to, t), 
				Type.QuintOut => QuintOut(from, to, t), 
				Type.QuintInOut => QuintInOut(from, to, t), 
				Type.QuintOutIn => QuintOutIn(from, to, t), 
				Type.SineIn => SineIn(from, to, t), 
				Type.SineOut => SineOut(from, to, t), 
				Type.SineInOut => SineInOut(from, to, t), 
				Type.SineOutIn => SineOutIn(from, to, t), 
				Type.ExpoIn => ExpoIn(from, to, t), 
				Type.ExpoOut => ExpoOut(from, to, t), 
				Type.ExpoInOut => ExpoInOut(from, to, t), 
				Type.ExpoOutIn => ExpoOutIn(from, to, t), 
				Type.CircIn => CircIn(from, to, t), 
				Type.CircOut => CircOut(from, to, t), 
				Type.CircInOut => CircInOut(from, to, t), 
				Type.CircOutIn => CircOutIn(from, to, t), 
				Type.ElasticIn => ElasticIn(from, to, t), 
				Type.ElasticOut => ElasticOut(from, to, t), 
				Type.ElasticInOut => ElasticInOut(from, to, t), 
				Type.ElasticOutIn => ElasticOutIn(from, to, t), 
				Type.BackIn => BackIn(from, to, t), 
				Type.BackOut => BackOut(from, to, t), 
				Type.BackInOut => BackInOut(from, to, t), 
				Type.BackOutIn => BackOutIn(from, to, t), 
				Type.BounceIn => BounceIn(from, to, t), 
				Type.BounceOut => BounceOut(from, to, t), 
				Type.BounceInOut => BounceInOut(from, to, t), 
				Type.BounceOutIn => BounceOutIn(from, to, t), 
				_ => 0f, 
			};
		}

		public static float Lerp(float from, float to, float t)
		{
			return In(Linear, t, from, to - from);
		}

		public static float QuadIn(float from, float to, float t)
		{
			return In(Quad, t, from, to - from);
		}

		public static float QuadOut(float from, float to, float t)
		{
			return Out(Quad, t, from, to - from);
		}

		public static float QuadInOut(float from, float to, float t)
		{
			return InOut(Quad, t, from, to - from);
		}

		public static float QuadOutIn(float from, float to, float t)
		{
			return OutIn(Quad, t, from, to - from);
		}

		public static float CubicIn(float from, float to, float t)
		{
			return In(Cubic, t, from, to - from);
		}

		public static float CubicOut(float from, float to, float t)
		{
			return Out(Cubic, t, from, to - from);
		}

		public static float CubicInOut(float from, float to, float t)
		{
			return InOut(Cubic, t, from, to - from);
		}

		public static float CubicOutIn(float from, float to, float t)
		{
			return OutIn(Cubic, t, from, to - from);
		}

		public static float QuartIn(float from, float to, float t)
		{
			return In(Quart, t, from, to - from);
		}

		public static float QuartOut(float from, float to, float t)
		{
			return Out(Quart, t, from, to - from);
		}

		public static float QuartInOut(float from, float to, float t)
		{
			return InOut(Quart, t, from, to - from);
		}

		public static float QuartOutIn(float from, float to, float t)
		{
			return OutIn(Quart, t, from, to - from);
		}

		public static float QuintIn(float from, float to, float t)
		{
			return In(Quint, t, from, to - from);
		}

		public static float QuintOut(float from, float to, float t)
		{
			return Out(Quint, t, from, to - from);
		}

		public static float QuintInOut(float from, float to, float t)
		{
			return InOut(Quint, t, from, to - from);
		}

		public static float QuintOutIn(float from, float to, float t)
		{
			return OutIn(Quint, t, from, to - from);
		}

		public static float SineIn(float from, float to, float t)
		{
			return In(Sine, t, from, to - from);
		}

		public static float SineOut(float from, float to, float t)
		{
			return Out(Sine, t, from, to - from);
		}

		public static float SineInOut(float from, float to, float t)
		{
			return InOut(Sine, t, from, to - from);
		}

		public static float SineOutIn(float from, float to, float t)
		{
			return OutIn(Sine, t, from, to - from);
		}

		public static float ExpoIn(float from, float to, float t)
		{
			return In(Expo, t, from, to - from);
		}

		public static float ExpoOut(float from, float to, float t)
		{
			return Out(Expo, t, from, to - from);
		}

		public static float ExpoInOut(float from, float to, float t)
		{
			return InOut(Expo, t, from, to - from);
		}

		public static float ExpoOutIn(float from, float to, float t)
		{
			return OutIn(Expo, t, from, to - from);
		}

		public static float CircIn(float from, float to, float t)
		{
			return In(Circ, t, from, to - from);
		}

		public static float CircOut(float from, float to, float t)
		{
			return Out(Circ, t, from, to - from);
		}

		public static float CircInOut(float from, float to, float t)
		{
			return InOut(Circ, t, from, to - from);
		}

		public static float CircOutIn(float from, float to, float t)
		{
			return OutIn(Circ, t, from, to - from);
		}

		public static float ElasticIn(float from, float to, float t)
		{
			return In(Elastic, t, from, to - from);
		}

		public static float ElasticOut(float from, float to, float t)
		{
			return Out(Elastic, t, from, to - from);
		}

		public static float ElasticInOut(float from, float to, float t)
		{
			return InOut(Elastic, t, from, to - from);
		}

		public static float ElasticOutIn(float from, float to, float t)
		{
			return OutIn(Elastic, t, from, to - from);
		}

		public static float BackIn(float from, float to, float t)
		{
			return In(Back, t, from, to - from);
		}

		public static float BackOut(float from, float to, float t)
		{
			return Out(Back, t, from, to - from);
		}

		public static float BackInOut(float from, float to, float t)
		{
			return InOut(Back, t, from, to - from);
		}

		public static float BackOutIn(float from, float to, float t)
		{
			return OutIn(Back, t, from, to - from);
		}

		public static float BounceIn(float from, float to, float t)
		{
			return In(Bounce, t, from, to - from);
		}

		public static float BounceOut(float from, float to, float t)
		{
			return Out(Bounce, t, from, to - from);
		}

		public static float BounceInOut(float from, float to, float t)
		{
			return InOut(Bounce, t, from, to - from);
		}

		public static float BounceOutIn(float from, float to, float t)
		{
			return OutIn(Bounce, t, from, to - from);
		}

		private static float In(Func<float, float, float> ease_f, float t, float b, float c, float d = 1f)
		{
			if (t >= d)
			{
				return b + c;
			}
			if (t <= 0f)
			{
				return b;
			}
			return c * ease_f(t, d) + b;
		}

		private static float Out(Func<float, float, float> ease_f, float t, float b, float c, float d = 1f)
		{
			if (t >= d)
			{
				return b + c;
			}
			if (t <= 0f)
			{
				return b;
			}
			return b + c - c * ease_f(d - t, d);
		}

		private static float InOut(Func<float, float, float> ease_f, float t, float b, float c, float d = 1f)
		{
			if (t >= d)
			{
				return b + c;
			}
			if (t <= 0f)
			{
				return b;
			}
			if (t < d / 2f)
			{
				return In(ease_f, t * 2f, b, c / 2f, d);
			}
			return Out(ease_f, t * 2f - d, b + c / 2f, c / 2f, d);
		}

		private static float OutIn(Func<float, float, float> ease_f, float t, float b, float c, float d = 1f)
		{
			if (t >= d)
			{
				return b + c;
			}
			if (t <= 0f)
			{
				return b;
			}
			if (t < d / 2f)
			{
				return Out(ease_f, t * 2f, b, c / 2f, d);
			}
			return In(ease_f, t * 2f - d, b + c / 2f, c / 2f, d);
		}

		private static float Linear(float t, float d = 1f)
		{
			return t / d;
		}

		private static float Quad(float t, float d = 1f)
		{
			return (t /= d) * t;
		}

		private static float Cubic(float t, float d = 1f)
		{
			return (t /= d) * t * t;
		}

		private static float Quart(float t, float d = 1f)
		{
			return (t /= d) * t * t * t;
		}

		private static float Quint(float t, float d = 1f)
		{
			return (t /= d) * t * t * t * t;
		}

		private static float Sine(float t, float d = 1f)
		{
			return 1f - Mathf.Cos(t / d * (MathF.PI / 2f));
		}

		private static float Expo(float t, float d = 1f)
		{
			return Mathf.Pow(2f, 10f * (t / d - 1f));
		}

		private static float Circ(float t, float d = 1f)
		{
			return 0f - (Mathf.Sqrt(1f - (t /= d) * t) - 1f);
		}

		private static float Elastic(float t, float d = 1f)
		{
			t /= d;
			float num = d * 0.3f;
			float num2 = num / 4f;
			return 0f - Mathf.Pow(2f, 10f * (t -= 1f)) * Mathf.Sin((t * d - num2) * (MathF.PI * 2f) / num);
		}

		private static float Back(float t, float d = 1f)
		{
			return (t /= d) * t * (2.70158f * t - 1.70158f);
		}

		private static float Bounce(float t, float d = 1f)
		{
			t = d - t;
			if ((t /= d) < 0.36363637f)
			{
				return 1f - 7.5625f * t * t;
			}
			if (t < 0.72727275f)
			{
				return 1f - (7.5625f * (t -= 0.54545456f) * t + 0.75f);
			}
			if (t < 0.90909094f)
			{
				return 1f - (7.5625f * (t -= 0.8181818f) * t + 0.9375f);
			}
			return 1f - (7.5625f * (t -= 21f / 22f) * t + 63f / 64f);
		}
	}
}
