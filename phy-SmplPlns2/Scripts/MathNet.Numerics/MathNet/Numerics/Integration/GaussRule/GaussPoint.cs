namespace MathNet.Numerics.Integration.GaussRule
{
	internal class GaussPoint
	{
		internal double[] Abscissas { get; }

		internal double[] Weights { get; }

		internal double IntervalBegin { get; }

		internal double IntervalEnd { get; }

		internal int Order { get; }

		internal GaussPoint(double intervalBegin, double intervalEnd, int order, double[] abscissas, double[] weights)
		{
			Abscissas = abscissas;
			Weights = weights;
			IntervalBegin = intervalBegin;
			IntervalEnd = intervalEnd;
			Order = order;
		}

		internal GaussPoint(int order, double[] abscissas, double[] weights)
			: this(-1.0, 1.0, order, abscissas, weights)
		{
		}
	}
}
