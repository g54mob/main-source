using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct IntMotionAdapter : IMotionAdapter<int, IntegerOptions>
	{
		public int Evaluate(ref int startValue, ref int endValue, ref IntegerOptions options, in MotionEvaluationContext context)
		{
			float num = math.lerp(startValue, endValue, context.Progress);
			return options.RoundingMode switch
			{
				RoundingMode.AwayFromZero => (num >= 0f) ? ((int)math.ceil(num)) : ((int)math.floor(num)), 
				RoundingMode.ToZero => (int)math.trunc(num), 
				RoundingMode.ToPositiveInfinity => (int)math.ceil(num), 
				RoundingMode.ToNegativeInfinity => (int)math.floor(num), 
				_ => (int)math.round(num), 
			};
		}

		int IMotionAdapter<int, IntegerOptions>.Evaluate(ref int startValue, ref int endValue, ref IntegerOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
