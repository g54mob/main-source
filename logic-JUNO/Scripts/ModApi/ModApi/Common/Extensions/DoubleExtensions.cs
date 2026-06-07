using ModApi.Math;

namespace ModApi.Common.Extensions
{
	public static class DoubleExtensions
	{
		public static double AsNegativePIToPI(this double value)
		{
			return MathUtils.LimitAngleNegPItoPI(value);
		}

		public static double AsZeroTo2PI(this double value)
		{
			return MathUtils.LimitAngle0to2PI(value);
		}
	}
}
