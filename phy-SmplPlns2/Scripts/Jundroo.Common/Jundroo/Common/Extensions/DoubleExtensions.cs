using Jundroo.Common.Utils;

namespace Jundroo.Common.Extensions
{
	public static class DoubleExtensions
	{
		public static double AsNegativePIToPI(this double value)
		{
			return MathUtility.LimitAngleNegPItoPI(value);
		}

		public static double AsZeroTo2PI(this double value)
		{
			return MathUtility.LimitAngle0to2PI(value);
		}
	}
}
