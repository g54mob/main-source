using System;
using Unity.Collections;

namespace LitMotion
{
	public static class MotionBuilderExtensions
	{
		public static MotionHandle Bind<TValue, TOptions, TAdapter, TState>(this MotionBuilder<TValue, TOptions, TAdapter> builder, TState state, Action<TValue, TState> action) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions> where TState : struct
		{
			return builder.Bind(Box.Create(state), action, delegate(TValue value, Box<TState> box, Action<TValue, TState> action2)
			{
				action2(value, box.Value);
			});
		}

		public static MotionBuilder<TValue, IntegerOptions, TAdapter> WithRoundingMode<TValue, TAdapter>(this MotionBuilder<TValue, IntegerOptions, TAdapter> builder, RoundingMode roundingMode) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, IntegerOptions>
		{
			IntegerOptions options = builder.buffer.Options;
			options.RoundingMode = roundingMode;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, PunchOptions, TAdapter> WithFrequency<TValue, TAdapter>(this MotionBuilder<TValue, PunchOptions, TAdapter> builder, int frequency) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, PunchOptions>
		{
			PunchOptions options = builder.buffer.Options;
			options.Frequency = frequency;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, PunchOptions, TAdapter> WithDampingRatio<TValue, TAdapter>(this MotionBuilder<TValue, PunchOptions, TAdapter> builder, float dampingRatio) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, PunchOptions>
		{
			PunchOptions options = builder.buffer.Options;
			options.DampingRatio = dampingRatio;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, ShakeOptions, TAdapter> WithFrequency<TValue, TAdapter>(this MotionBuilder<TValue, ShakeOptions, TAdapter> builder, int frequency) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, ShakeOptions>
		{
			ShakeOptions options = builder.buffer.Options;
			options.Frequency = frequency;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, ShakeOptions, TAdapter> WithDampingRatio<TValue, TAdapter>(this MotionBuilder<TValue, ShakeOptions, TAdapter> builder, float dampingRatio) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, ShakeOptions>
		{
			ShakeOptions options = builder.buffer.Options;
			options.DampingRatio = dampingRatio;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, ShakeOptions, TAdapter> WithRandomSeed<TValue, TAdapter>(this MotionBuilder<TValue, ShakeOptions, TAdapter> builder, uint seed) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, ShakeOptions>
		{
			ShakeOptions options = builder.buffer.Options;
			options.RandomSeed = seed;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, StringOptions, TAdapter> WithRichText<TValue, TAdapter>(this MotionBuilder<TValue, StringOptions, TAdapter> builder, bool richTextEnabled = true) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, StringOptions>
		{
			StringOptions options = builder.buffer.Options;
			options.RichTextEnabled = richTextEnabled;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, StringOptions, TAdapter> WithRandomSeed<TValue, TAdapter>(this MotionBuilder<TValue, StringOptions, TAdapter> builder, uint seed) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, StringOptions>
		{
			StringOptions options = builder.buffer.Options;
			options.RandomSeed = seed;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, StringOptions, TAdapter> WithScrambleChars<TValue, TAdapter>(this MotionBuilder<TValue, StringOptions, TAdapter> builder, ScrambleMode scrambleMode) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, StringOptions>
		{
			if (scrambleMode == ScrambleMode.Custom)
			{
				throw new ArgumentException("ScrambleMode.Custom cannot be specified explicitly. Use WithScrambleMode(FixedString64Bytes) instead.");
			}
			StringOptions options = builder.buffer.Options;
			options.ScrambleMode = scrambleMode;
			builder.buffer.Options = options;
			return builder;
		}

		public static MotionBuilder<TValue, StringOptions, TAdapter> WithScrambleChars<TValue, TAdapter>(this MotionBuilder<TValue, StringOptions, TAdapter> builder, FixedString64Bytes customScrambleChars) where TValue : unmanaged where TAdapter : unmanaged, IMotionAdapter<TValue, StringOptions>
		{
			StringOptions options = builder.buffer.Options;
			options.ScrambleMode = ScrambleMode.Custom;
			options.CustomScrambleChars = customScrambleChars;
			builder.buffer.Options = options;
			return builder;
		}
	}
}
