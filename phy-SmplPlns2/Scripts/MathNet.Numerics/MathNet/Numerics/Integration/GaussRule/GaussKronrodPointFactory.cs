using System;

namespace MathNet.Numerics.Integration.GaussRule
{
	internal static class GaussKronrodPointFactory
	{
		[ThreadStatic]
		private static GaussPointPair _gaussKronrodPoint;

		public static GaussPointPair GetGaussPoint(int order)
		{
			if ((_gaussKronrodPoint == null || _gaussKronrodPoint.Order != order) && !GaussKronrodPoint.PreComputed.TryGetValue(order, out _gaussKronrodPoint))
			{
				_gaussKronrodPoint = GaussKronrodPoint.Generate(order, 1E-10);
			}
			return _gaussKronrodPoint;
		}
	}
}
