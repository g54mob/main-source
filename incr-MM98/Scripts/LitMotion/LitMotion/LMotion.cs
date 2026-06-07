using LitMotion.Adapters;
using Unity.Collections;
using UnityEngine;

namespace LitMotion
{
	public static class LMotion
	{
		public static class String
		{
			public static MotionBuilder<FixedString32Bytes, StringOptions, FixedString32BytesMotionAdapter> Create32Bytes(in FixedString32Bytes from, in FixedString32Bytes to, float duration)
			{
				return Create<FixedString32Bytes, StringOptions, FixedString32BytesMotionAdapter>(in from, in to, duration);
			}

			public static MotionBuilder<FixedString64Bytes, StringOptions, FixedString64BytesMotionAdapter> Create64Bytes(in FixedString64Bytes from, in FixedString64Bytes to, float duration)
			{
				return Create<FixedString64Bytes, StringOptions, FixedString64BytesMotionAdapter>(in from, in to, duration);
			}

			public static MotionBuilder<FixedString128Bytes, StringOptions, FixedString128BytesMotionAdapter> Create128Bytes(in FixedString128Bytes from, in FixedString128Bytes to, float duration)
			{
				return Create<FixedString128Bytes, StringOptions, FixedString128BytesMotionAdapter>(in from, in to, duration);
			}

			public static MotionBuilder<FixedString512Bytes, StringOptions, FixedString512BytesMotionAdapter> Create512Bytes(in FixedString512Bytes from, in FixedString512Bytes to, float duration)
			{
				return Create<FixedString512Bytes, StringOptions, FixedString512BytesMotionAdapter>(in from, in to, duration);
			}

			public static MotionBuilder<FixedString4096Bytes, StringOptions, FixedString4096BytesMotionAdapter> Create4096Bytes(in FixedString4096Bytes from, in FixedString4096Bytes to, float duration)
			{
				return Create<FixedString4096Bytes, StringOptions, FixedString4096BytesMotionAdapter>(in from, in to, duration);
			}
		}

		public static class Punch
		{
			public static MotionBuilder<float, PunchOptions, FloatPunchMotionAdapter> Create(float startValue, float strength, float duration)
			{
				return Create<float, PunchOptions, FloatPunchMotionAdapter>(in startValue, in strength, duration).WithOptions(PunchOptions.Default);
			}

			public static MotionBuilder<Vector2, PunchOptions, Vector2PunchMotionAdapter> Create(Vector2 startValue, Vector2 strength, float duration)
			{
				return Create<Vector2, PunchOptions, Vector2PunchMotionAdapter>(in startValue, in strength, duration).WithOptions(PunchOptions.Default);
			}

			public static MotionBuilder<Vector3, PunchOptions, Vector3PunchMotionAdapter> Create(Vector3 startValue, Vector3 strength, float duration)
			{
				return Create<Vector3, PunchOptions, Vector3PunchMotionAdapter>(in startValue, in strength, duration).WithOptions(PunchOptions.Default);
			}
		}

		public static class Shake
		{
			public static MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> Create(float startValue, float strength, float duration)
			{
				return Create<float, ShakeOptions, FloatShakeMotionAdapter>(in startValue, in strength, duration).WithOptions(ShakeOptions.Default);
			}

			public static MotionBuilder<Vector2, ShakeOptions, Vector2ShakeMotionAdapter> Create(Vector2 startValue, Vector2 strength, float duration)
			{
				return Create<Vector2, ShakeOptions, Vector2ShakeMotionAdapter>(in startValue, in strength, duration).WithOptions(ShakeOptions.Default);
			}

			public static MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> Create(Vector3 startValue, Vector3 strength, float duration)
			{
				return Create<Vector3, ShakeOptions, Vector3ShakeMotionAdapter>(in startValue, in strength, duration).WithOptions(ShakeOptions.Default);
			}
		}

		public static MotionBuilder<float, NoOptions, FloatMotionAdapter> Create(float from, float to, float duration)
		{
			return Create<float, NoOptions, FloatMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<double, NoOptions, DoubleMotionAdapter> Create(double from, double to, float duration)
		{
			return Create<double, NoOptions, DoubleMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<int, IntegerOptions, IntMotionAdapter> Create(int from, int to, float duration)
		{
			return Create<int, IntegerOptions, IntMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<long, IntegerOptions, LongMotionAdapter> Create(long from, long to, float duration)
		{
			return Create<long, IntegerOptions, LongMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> Create(Vector2 from, Vector2 to, float duration)
		{
			return Create<Vector2, NoOptions, Vector2MotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> Create(Vector3 from, Vector3 to, float duration)
		{
			return Create<Vector3, NoOptions, Vector3MotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<Vector4, NoOptions, Vector4MotionAdapter> Create(Vector4 from, Vector4 to, float duration)
		{
			return Create<Vector4, NoOptions, Vector4MotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> Create(Quaternion from, Quaternion to, float duration)
		{
			return Create<Quaternion, NoOptions, QuaternionMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<Color, NoOptions, ColorMotionAdapter> Create(Color from, Color to, float duration)
		{
			return Create<Color, NoOptions, ColorMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<Rect, NoOptions, RectMotionAdapter> Create(Rect from, Rect to, float duration)
		{
			return Create<Rect, NoOptions, RectMotionAdapter>(in from, in to, duration);
		}

		public static MotionBuilder<TValue, TOptions, TAdapter> Create<TValue, TOptions, TAdapter>(in TValue from, in TValue to, float duration) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			MotionBuilderBuffer<TValue, TOptions> motionBuilderBuffer = MotionBuilderBuffer<TValue, TOptions>.Rent();
			motionBuilderBuffer.StartValue = from;
			motionBuilderBuffer.EndValue = to;
			motionBuilderBuffer.Duration = duration;
			return new MotionBuilder<TValue, TOptions, TAdapter>(motionBuilderBuffer);
		}

		public static MotionBuilder<float, NoOptions, FloatMotionAdapter> Create(MotionSettings<float, NoOptions> settings)
		{
			return Create<float, NoOptions, FloatMotionAdapter>(settings);
		}

		public static MotionBuilder<double, NoOptions, DoubleMotionAdapter> Create(MotionSettings<double, NoOptions> settings)
		{
			return Create<double, NoOptions, DoubleMotionAdapter>(settings);
		}

		public static MotionBuilder<int, IntegerOptions, IntMotionAdapter> Create(MotionSettings<int, IntegerOptions> settings)
		{
			return Create<int, IntegerOptions, IntMotionAdapter>(settings);
		}

		public static MotionBuilder<long, IntegerOptions, LongMotionAdapter> Create(MotionSettings<long, IntegerOptions> settings)
		{
			return Create<long, IntegerOptions, LongMotionAdapter>(settings);
		}

		public static MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> Create(MotionSettings<Vector2, NoOptions> settings)
		{
			return Create<Vector2, NoOptions, Vector2MotionAdapter>(settings);
		}

		public static MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> Create(MotionSettings<Vector3, NoOptions> settings)
		{
			return Create<Vector3, NoOptions, Vector3MotionAdapter>(settings);
		}

		public static MotionBuilder<Vector4, NoOptions, Vector4MotionAdapter> Create(MotionSettings<Vector4, NoOptions> settings)
		{
			return Create<Vector4, NoOptions, Vector4MotionAdapter>(settings);
		}

		public static MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> Create(MotionSettings<Quaternion, NoOptions> settings)
		{
			return Create<Quaternion, NoOptions, QuaternionMotionAdapter>(settings);
		}

		public static MotionBuilder<Color, NoOptions, ColorMotionAdapter> Create(MotionSettings<Color, NoOptions> settings)
		{
			return Create<Color, NoOptions, ColorMotionAdapter>(settings);
		}

		public static MotionBuilder<Rect, NoOptions, RectMotionAdapter> Create(MotionSettings<Rect, NoOptions> settings)
		{
			return Create<Rect, NoOptions, RectMotionAdapter>(settings);
		}

		public static MotionBuilder<TValue, TOptions, TAdapter> Create<TValue, TOptions, TAdapter>(MotionSettings<TValue, TOptions> settings) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			MotionBuilderBuffer<TValue, TOptions> motionBuilderBuffer = MotionBuilderBuffer<TValue, TOptions>.Rent();
			motionBuilderBuffer.StartValue = settings.StartValue;
			motionBuilderBuffer.EndValue = settings.EndValue;
			motionBuilderBuffer.Duration = settings.Duration;
			motionBuilderBuffer.Options = settings.Options;
			motionBuilderBuffer.Ease = settings.Ease;
			motionBuilderBuffer.AnimationCurve = settings.CustomEaseCurve;
			motionBuilderBuffer.Delay = settings.Delay;
			motionBuilderBuffer.DelayType = settings.DelayType;
			motionBuilderBuffer.Loops = settings.Loops;
			motionBuilderBuffer.LoopType = settings.LoopType;
			motionBuilderBuffer.CancelOnError = settings.CancelOnError;
			motionBuilderBuffer.SkipValuesDuringDelay = settings.SkipValuesDuringDelay;
			motionBuilderBuffer.ImmediateBind = settings.ImmediateBind;
			motionBuilderBuffer.Scheduler = settings.Scheduler;
			return new MotionBuilder<TValue, TOptions, TAdapter>(motionBuilderBuffer);
		}
	}
}
