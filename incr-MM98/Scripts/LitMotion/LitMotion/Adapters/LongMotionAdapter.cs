using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct LongMotionAdapter : IMotionAdapter<long, IntegerOptions>
	{
		public long Evaluate(ref long startValue, ref long endValue, ref IntegerOptions options, in MotionEvaluationContext context)
		{
			double num = math.lerp((double)startValue, (double)endValue, (double)context.Progress);
			return options.RoundingMode switch
			{
				RoundingMode.AwayFromZero => (num >= 0.0) ? ((long)math.ceil(num)) : ((long)math.floor(num)), 
				RoundingMode.ToZero => (long)math.trunc(num), 
				RoundingMode.ToPositiveInfinity => (long)math.ceil(num), 
				RoundingMode.ToNegativeInfinity => (long)math.floor(num), 
				_ => (long)math.round(num), 
			};
		}

		long IMotionAdapter<long, IntegerOptions>.Evaluate(ref long startValue, ref long endValue, ref IntegerOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
