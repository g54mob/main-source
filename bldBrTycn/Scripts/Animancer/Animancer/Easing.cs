using System;
using UnityEngine;

namespace Animancer
{
	public static class Easing
	{
		public delegate float RangedDelegate(float start, float end, float value);

		public enum Function
		{
			Linear = 0,
			QuadraticIn = 1,
			QuadraticOut = 2,
			QuadraticInOut = 3,
			CubicIn = 4,
			CubicOut = 5,
			CubicInOut = 6,
			QuarticIn = 7,
			QuarticOut = 8,
			QuarticInOut = 9,
			QuinticIn = 10,
			QuinticOut = 11,
			QuinticInOut = 12,
			SineIn = 13,
			SineOut = 14,
			SineInOut = 15,
			ExponentialIn = 16,
			ExponentialOut = 17,
			ExponentialInOut = 18,
			CircularIn = 19,
			CircularOut = 20,
			CircularInOut = 21,
			BackIn = 22,
			BackOut = 23,
			BackInOut = 24,
			BounceIn = 25,
			BounceOut = 26,
			BounceInOut = 27,
			ElasticIn = 28,
			ElasticOut = 29,
			ElasticInOut = 30
		}

		public static class Quadratic
		{
			public static float In(float value)
			{
				return value * value;
			}

			public static float Out(float value)
			{
				value -= 1f;
				return (0f - value) * value + 1f;
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 0.5f * value * value;
				}
				value -= 2f;
				return 0.5f * ((0f - value) * value + 2f);
			}

			public static float InDerivative(float value)
			{
				return 2f * value;
			}

			public static float OutDerivative(float value)
			{
				return 2f - 2f * value;
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 2f * value;
				}
				value -= 1f;
				return 2f - 2f * value;
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Cubic
		{
			public static float In(float value)
			{
				return value * value * value;
			}

			public static float Out(float value)
			{
				value -= 1f;
				return value * value * value + 1f;
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 0.5f * value * value * value;
				}
				value -= 2f;
				return 0.5f * (value * value * value + 2f);
			}

			public static float InDerivative(float value)
			{
				return 3f * value * value;
			}

			public static float OutDerivative(float value)
			{
				value -= 1f;
				return 3f * value * value;
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 3f * value * value;
				}
				value -= 2f;
				return 3f * value * value;
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Quartic
		{
			public static float In(float value)
			{
				return value * value * value * value;
			}

			public static float Out(float value)
			{
				value -= 1f;
				return (0f - value) * value * value * value + 1f;
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 0.5f * value * value * value * value;
				}
				value -= 2f;
				return 0.5f * ((0f - value) * value * value * value + 2f);
			}

			public static float InDerivative(float value)
			{
				return 4f * value * value * value;
			}

			public static float OutDerivative(float value)
			{
				value -= 1f;
				return -4f * value * value * value;
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 4f * value * value * value;
				}
				value -= 2f;
				return -4f * value * value * value;
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Quintic
		{
			public static float In(float value)
			{
				return value * value * value * value * value;
			}

			public static float Out(float value)
			{
				value -= 1f;
				return value * value * value * value * value + 1f;
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 0.5f * value * value * value * value * value;
				}
				value -= 2f;
				return 0.5f * (value * value * value * value * value + 2f);
			}

			public static float InDerivative(float value)
			{
				return 5f * value * value * value * value;
			}

			public static float OutDerivative(float value)
			{
				value -= 1f;
				return 5f * value * value * value * value;
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 5f * value * value * value * value;
				}
				value -= 2f;
				return 5f * value * value * value * value;
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Sine
		{
			public static float In(float value)
			{
				return 0f - Mathf.Cos(value * (MathF.PI / 2f)) + 1f;
			}

			public static float Out(float value)
			{
				return Mathf.Sin(value * (MathF.PI / 2f));
			}

			public static float InOut(float value)
			{
				return -0.5f * (Mathf.Cos(MathF.PI * value) - 1f);
			}

			public static float InDerivative(float value)
			{
				return MathF.PI / 2f * Mathf.Sin(MathF.PI / 2f * value);
			}

			public static float OutDerivative(float value)
			{
				return MathF.PI / 2f * Mathf.Cos(value * (MathF.PI / 2f));
			}

			public static float InOutDerivative(float value)
			{
				return MathF.PI / 2f * Mathf.Sin(MathF.PI * value);
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Exponential
		{
			public static float In(float value)
			{
				return Mathf.Pow(2f, 10f * (value - 1f));
			}

			public static float Out(float value)
			{
				return 0f - Mathf.Pow(2f, -10f * value) + 1f;
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 0.5f * Mathf.Pow(2f, 10f * (value - 1f));
				}
				value -= 1f;
				return 0.5f * (0f - Mathf.Pow(2f, -10f * value) + 2f);
			}

			public static float InDerivative(float value)
			{
				return 6.931472f * Mathf.Pow(2f, 10f * (value - 1f));
			}

			public static float OutDerivative(float value)
			{
				return 3.465736f * Mathf.Pow(2f, 1f - 10f * value);
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 6.931472f * Mathf.Pow(2f, 10f * (value - 1f));
				}
				value -= 1f;
				return 3.465736f * Mathf.Pow(2f, 1f - 10f * value);
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Circular
		{
			public static float In(float value)
			{
				return 0f - (Mathf.Sqrt(1f - value * value) - 1f);
			}

			public static float Out(float value)
			{
				value -= 1f;
				return Mathf.Sqrt(1f - value * value);
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return -0.5f * (Mathf.Sqrt(1f - value * value) - 1f);
				}
				value -= 2f;
				return 0.5f * (Mathf.Sqrt(1f - value * value) + 1f);
			}

			public static float InDerivative(float value)
			{
				return value / Mathf.Sqrt(1f - value * value);
			}

			public static float OutDerivative(float value)
			{
				value -= 1f;
				return (0f - value) / Mathf.Sqrt(1f - value * value);
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return value / (2f * Mathf.Sqrt(1f - value * value));
				}
				value -= 2f;
				return (0f - value) / (2f * Mathf.Sqrt(1f - value * value));
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Back
		{
			private const float C = 1.758f;

			public static float In(float value)
			{
				return value * value * (2.758f * value - 1.758f);
			}

			public static float Out(float value)
			{
				value -= 1f;
				return value * value * (2.758f * value + 1.758f) + 1f;
			}

			public static float InOut(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 0.5f * value * value * (2.758f * value - 1.758f);
				}
				value -= 2f;
				return 0.5f * (value * value * (2.758f * value + 1.758f) + 2f);
			}

			public static float InDerivative(float value)
			{
				return 8.274f * value * value - 3.516f * value;
			}

			public static float OutDerivative(float value)
			{
				value -= 1f;
				return 2.758f * value * value + 2f * value * (2.758f * value + 1.758f);
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return 8.274f * value * value - 3.516f * value;
				}
				value -= 2f;
				return 2.758f * value * value + 2f * value * (2.758f * value + 1.758f);
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Bounce
		{
			public static float In(float value)
			{
				return 1f - Out(1f - value);
			}

			public static float Out(float value)
			{
				if (value != 0f)
				{
					if (value == 1f)
					{
						return 1f;
					}
					if (value < 0.36363637f)
					{
						return 7.5625f * value * value;
					}
					if (value < 0.72727275f)
					{
						value -= 0.54545456f;
						return 7.5625f * value * value + 0.75f;
					}
					if (value < 0.90909094f)
					{
						value -= 0.8181818f;
						return 7.5625f * value * value + 0.9375f;
					}
					value -= 21f / 22f;
					return 7.5625f * value * value + 63f / 64f;
				}
				return 0f;
			}

			public static float InOut(float value)
			{
				if (value < 0.5f)
				{
					return 0.5f * In(value * 2f);
				}
				return 0.5f + 0.5f * Out(value * 2f - 1f);
			}

			public static float InDerivative(float value)
			{
				return OutDerivative(1f - value);
			}

			public static float OutDerivative(float value)
			{
				if (value < 0.36363637f)
				{
					return 15.125f * value;
				}
				if (value < 0.72727275f)
				{
					value -= 0.54545456f;
					return 15.125f * value;
				}
				if (value < 0.90909094f)
				{
					value -= 0.8181818f;
					return 15.125f * value;
				}
				value -= 21f / 22f;
				return 15.125f * value;
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return OutDerivative(1f - value);
				}
				return OutDerivative(value - 1f);
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public static class Elastic
		{
			public const float TwoThirdsPi = MathF.PI * 2f / 3f;

			public static float In(float value)
			{
				if (value != 0f)
				{
					if (value == 1f)
					{
						return 1f;
					}
					return (0f - Mathf.Pow(2f, 10f * value - 10f)) * Mathf.Sin((value * 10f - 10.75f) * (MathF.PI * 2f / 3f));
				}
				return 0f;
			}

			public static float Out(float value)
			{
				if (value != 0f)
				{
					if (value == 1f)
					{
						return 1f;
					}
					return 1f + Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * -10f - 0.75f) * (MathF.PI * 2f / 3f));
				}
				return 0f;
			}

			public static float InOut(float value)
			{
				if (value != 0f)
				{
					if (value != 0.5f)
					{
						if (value == 1f)
						{
							return 1f;
						}
						value *= 2f;
						if (value <= 1f)
						{
							return 0.5f * ((0f - Mathf.Pow(2f, 10f * value - 10f)) * Mathf.Sin((value * 10f - 10.75f) * (MathF.PI * 2f / 3f)));
						}
						value -= 1f;
						return 0.5f + 0.5f * (1f + Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * -10f - 0.75f) * (MathF.PI * 2f / 3f)));
					}
					return 0.5f;
				}
				return 0f;
			}

			public static float InDerivative(float value)
			{
				return (0f - 5f * Mathf.Pow(2f, 10f * value - 9f) * (2.0794415f * Mathf.Sin(MathF.PI * (40f * value - 43f) / 6f) + MathF.PI * 2f * Mathf.Cos(MathF.PI * (40f * value - 43f) / 6f))) / 3f;
			}

			public static float OutDerivative(float value)
			{
				return (0f - (20.794415f * Mathf.Sin(MathF.PI * 2f * (10f * value - 0.75f) / 3f) - MathF.PI * 20f * Mathf.Cos(MathF.PI * 2f * (10f * value - 0.75f) / 3f))) / (3f * Mathf.Pow(2f, 10f * value));
			}

			public static float InOutDerivative(float value)
			{
				value *= 2f;
				if (value <= 1f)
				{
					return OutDerivative(1f - value);
				}
				return OutDerivative(value - 1f);
			}

			public static float In(float start, float end, float value)
			{
				return Lerp(start, end, In(UnLerp(start, end, value)));
			}

			public static float Out(float start, float end, float value)
			{
				return Lerp(start, end, Out(UnLerp(start, end, value)));
			}

			public static float InOut(float start, float end, float value)
			{
				return Lerp(start, end, InOut(UnLerp(start, end, value)));
			}

			public static float InDerivative(float start, float end, float value)
			{
				return InDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float OutDerivative(float start, float end, float value)
			{
				return OutDerivative(UnLerp(start, end, value)) * (end - start);
			}

			public static float InOutDerivative(float start, float end, float value)
			{
				return InOutDerivative(UnLerp(start, end, value)) * (end - start);
			}
		}

		public const float Ln2 = 0.6931472f;

		public const int FunctionCount = 31;

		private static Func<float, float>[] _FunctionDelegates;

		private static Func<float, float>[] _DerivativeDelegates;

		private static RangedDelegate[] _RangedFunctionDelegates;

		private static RangedDelegate[] _RangedDerivativeDelegates;

		public static Func<float, float> GetDelegate(this Function function)
		{
			Func<float, float> func;
			if (_FunctionDelegates == null)
			{
				_FunctionDelegates = new Func<float, float>[31];
			}
			else
			{
				func = _FunctionDelegates[(int)function];
				if (func != null)
				{
					return func;
				}
			}
			func = function switch
			{
				Function.Linear => Linear, 
				Function.QuadraticIn => Quadratic.In, 
				Function.QuadraticOut => Quadratic.Out, 
				Function.QuadraticInOut => Quadratic.InOut, 
				Function.CubicIn => Cubic.In, 
				Function.CubicOut => Cubic.Out, 
				Function.CubicInOut => Cubic.InOut, 
				Function.QuarticIn => Quartic.In, 
				Function.QuarticOut => Quartic.Out, 
				Function.QuarticInOut => Quartic.InOut, 
				Function.QuinticIn => Quintic.In, 
				Function.QuinticOut => Quintic.Out, 
				Function.QuinticInOut => Quintic.InOut, 
				Function.SineIn => Sine.In, 
				Function.SineOut => Sine.Out, 
				Function.SineInOut => Sine.InOut, 
				Function.ExponentialIn => Exponential.In, 
				Function.ExponentialOut => Exponential.Out, 
				Function.ExponentialInOut => Exponential.InOut, 
				Function.CircularIn => Circular.In, 
				Function.CircularOut => Circular.Out, 
				Function.CircularInOut => Circular.InOut, 
				Function.BackIn => Back.In, 
				Function.BackOut => Back.Out, 
				Function.BackInOut => Back.InOut, 
				Function.BounceIn => Bounce.In, 
				Function.BounceOut => Bounce.Out, 
				Function.BounceInOut => Bounce.InOut, 
				Function.ElasticIn => Elastic.In, 
				Function.ElasticOut => Elastic.Out, 
				Function.ElasticInOut => Elastic.InOut, 
				_ => throw new ArgumentOutOfRangeException("function"), 
			};
			_FunctionDelegates[(int)function] = func;
			return func;
		}

		public static Func<float, float> GetDerivativeDelegate(this Function function)
		{
			Func<float, float> func;
			if (_DerivativeDelegates == null)
			{
				_DerivativeDelegates = new Func<float, float>[31];
			}
			else
			{
				func = _DerivativeDelegates[(int)function];
				if (func != null)
				{
					return func;
				}
			}
			func = function switch
			{
				Function.Linear => LinearDerivative, 
				Function.QuadraticIn => Quadratic.InDerivative, 
				Function.QuadraticOut => Quadratic.OutDerivative, 
				Function.QuadraticInOut => Quadratic.InOutDerivative, 
				Function.CubicIn => Cubic.InDerivative, 
				Function.CubicOut => Cubic.OutDerivative, 
				Function.CubicInOut => Cubic.InOutDerivative, 
				Function.QuarticIn => Quartic.InDerivative, 
				Function.QuarticOut => Quartic.OutDerivative, 
				Function.QuarticInOut => Quartic.InOutDerivative, 
				Function.QuinticIn => Quintic.InDerivative, 
				Function.QuinticOut => Quintic.OutDerivative, 
				Function.QuinticInOut => Quintic.InOutDerivative, 
				Function.SineIn => Sine.InDerivative, 
				Function.SineOut => Sine.OutDerivative, 
				Function.SineInOut => Sine.InOutDerivative, 
				Function.ExponentialIn => Exponential.InDerivative, 
				Function.ExponentialOut => Exponential.OutDerivative, 
				Function.ExponentialInOut => Exponential.InOutDerivative, 
				Function.CircularIn => Circular.InDerivative, 
				Function.CircularOut => Circular.OutDerivative, 
				Function.CircularInOut => Circular.InOutDerivative, 
				Function.BackIn => Back.InDerivative, 
				Function.BackOut => Back.OutDerivative, 
				Function.BackInOut => Back.InOutDerivative, 
				Function.BounceIn => Bounce.InDerivative, 
				Function.BounceOut => Bounce.OutDerivative, 
				Function.BounceInOut => Bounce.InOutDerivative, 
				Function.ElasticIn => Elastic.InDerivative, 
				Function.ElasticOut => Elastic.OutDerivative, 
				Function.ElasticInOut => Elastic.InOutDerivative, 
				_ => throw new ArgumentOutOfRangeException("function"), 
			};
			_DerivativeDelegates[(int)function] = func;
			return func;
		}

		public static RangedDelegate GetRangedDelegate(this Function function)
		{
			RangedDelegate rangedDelegate;
			if (_RangedFunctionDelegates == null)
			{
				_RangedFunctionDelegates = new RangedDelegate[31];
			}
			else
			{
				rangedDelegate = _RangedFunctionDelegates[(int)function];
				if (rangedDelegate != null)
				{
					return rangedDelegate;
				}
			}
			rangedDelegate = function switch
			{
				Function.Linear => Linear, 
				Function.QuadraticIn => Quadratic.In, 
				Function.QuadraticOut => Quadratic.Out, 
				Function.QuadraticInOut => Quadratic.InOut, 
				Function.CubicIn => Cubic.In, 
				Function.CubicOut => Cubic.Out, 
				Function.CubicInOut => Cubic.InOut, 
				Function.QuarticIn => Quartic.In, 
				Function.QuarticOut => Quartic.Out, 
				Function.QuarticInOut => Quartic.InOut, 
				Function.QuinticIn => Quintic.In, 
				Function.QuinticOut => Quintic.Out, 
				Function.QuinticInOut => Quintic.InOut, 
				Function.SineIn => Sine.In, 
				Function.SineOut => Sine.Out, 
				Function.SineInOut => Sine.InOut, 
				Function.ExponentialIn => Exponential.In, 
				Function.ExponentialOut => Exponential.Out, 
				Function.ExponentialInOut => Exponential.InOut, 
				Function.CircularIn => Circular.In, 
				Function.CircularOut => Circular.Out, 
				Function.CircularInOut => Circular.InOut, 
				Function.BackIn => Back.In, 
				Function.BackOut => Back.Out, 
				Function.BackInOut => Back.InOut, 
				Function.BounceIn => Bounce.In, 
				Function.BounceOut => Bounce.Out, 
				Function.BounceInOut => Bounce.InOut, 
				Function.ElasticIn => Elastic.In, 
				Function.ElasticOut => Elastic.Out, 
				Function.ElasticInOut => Elastic.InOut, 
				_ => throw new ArgumentOutOfRangeException("function"), 
			};
			_RangedFunctionDelegates[(int)function] = rangedDelegate;
			return rangedDelegate;
		}

		public static RangedDelegate GetRangedDerivativeDelegate(this Function function)
		{
			RangedDelegate rangedDelegate;
			if (_RangedDerivativeDelegates == null)
			{
				_RangedDerivativeDelegates = new RangedDelegate[31];
			}
			else
			{
				rangedDelegate = _RangedDerivativeDelegates[(int)function];
				if (rangedDelegate != null)
				{
					return rangedDelegate;
				}
			}
			rangedDelegate = function switch
			{
				Function.Linear => LinearDerivative, 
				Function.QuadraticIn => Quadratic.InDerivative, 
				Function.QuadraticOut => Quadratic.OutDerivative, 
				Function.QuadraticInOut => Quadratic.InOutDerivative, 
				Function.CubicIn => Cubic.InDerivative, 
				Function.CubicOut => Cubic.OutDerivative, 
				Function.CubicInOut => Cubic.InOutDerivative, 
				Function.QuarticIn => Quartic.InDerivative, 
				Function.QuarticOut => Quartic.OutDerivative, 
				Function.QuarticInOut => Quartic.InOutDerivative, 
				Function.QuinticIn => Quintic.InDerivative, 
				Function.QuinticOut => Quintic.OutDerivative, 
				Function.QuinticInOut => Quintic.InOutDerivative, 
				Function.SineIn => Sine.InDerivative, 
				Function.SineOut => Sine.OutDerivative, 
				Function.SineInOut => Sine.InOutDerivative, 
				Function.ExponentialIn => Exponential.InDerivative, 
				Function.ExponentialOut => Exponential.OutDerivative, 
				Function.ExponentialInOut => Exponential.InOutDerivative, 
				Function.CircularIn => Circular.InDerivative, 
				Function.CircularOut => Circular.OutDerivative, 
				Function.CircularInOut => Circular.InOutDerivative, 
				Function.BackIn => Back.InDerivative, 
				Function.BackOut => Back.OutDerivative, 
				Function.BackInOut => Back.InOutDerivative, 
				Function.BounceIn => Bounce.InDerivative, 
				Function.BounceOut => Bounce.OutDerivative, 
				Function.BounceInOut => Bounce.InOutDerivative, 
				Function.ElasticIn => Elastic.InDerivative, 
				Function.ElasticOut => Elastic.OutDerivative, 
				Function.ElasticInOut => Elastic.InOutDerivative, 
				_ => throw new ArgumentOutOfRangeException("function"), 
			};
			_RangedDerivativeDelegates[(int)function] = rangedDelegate;
			return rangedDelegate;
		}

		public static float Lerp(float start, float end, float value)
		{
			return start + (end - start) * value;
		}

		public static float UnLerp(float start, float end, float value)
		{
			if (start != end)
			{
				return (value - start) / (end - start);
			}
			return 0f;
		}

		public static float ReScale(float start, float end, float value, Func<float, float> function)
		{
			return Lerp(start, end, function(UnLerp(start, end, value)));
		}

		public static float Linear(float value)
		{
			return value;
		}

		public static float LinearDerivative(float value)
		{
			return 1f;
		}

		public static float Linear(float start, float end, float value)
		{
			return value;
		}

		public static float LinearDerivative(float start, float end, float value)
		{
			return end - start;
		}
	}
}
