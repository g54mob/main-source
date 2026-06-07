namespace Mystery.Graphing
{
	public class FloatingPointLinearPlottableGraph : LinearPlottableGraphOverTime<double>
	{
		private static string floatFormat = "F4";

		private double minY = double.MaxValue;

		private double maxY = double.MinValue;

		private double normalizeDivisorY = 1.0;

		public static string FloatFormat
		{
			get
			{
				return floatFormat;
			}
			set
			{
				floatFormat = value;
			}
		}

		public override string YValueFormat => floatFormat;

		public override double MinY => minY;

		public override double MaxY => maxY;

		protected override void UpdateMinMaxY(double value)
		{
			if (value < minY)
			{
				minY = value;
				normalizeDivisorY = ((maxY == minY) ? 1.0 : (1.0 / (maxY - minY)));
			}
			if (value > maxY)
			{
				maxY = value;
				normalizeDivisorY = ((maxY == minY) ? 1.0 : (1.0 / (maxY - minY)));
			}
		}

		public override double NormalizeY(double value)
		{
			return (value - minY) * normalizeDivisorY;
		}

		public override double GetTransformYToRangeScale(double lower, double upper)
		{
			if (lower != upper)
			{
				return 1.0 / (upper - lower);
			}
			return 1.0;
		}

		public override double ApplyTransformYToRange(double value, double lower, double inverseDivisor)
		{
			return (value - lower) * inverseDivisor;
		}

		public override float YToFloat(double yValue)
		{
			return (float)yValue;
		}

		public override string YToString(double yValue)
		{
			return yValue.ToString(YValueFormat);
		}

		public override void GetYRange(float zoom, float pan, ref double min, ref double max)
		{
			double num = min;
			double num2 = max;
			double num3 = max - min;
			double num4 = num3 * (double)pan;
			num += num4;
			num2 += num4;
			double num5 = num3 * (double)zoom;
			num += num5;
			num2 -= num5;
			min = num;
			max = num2;
		}

		public override double CalcYAt(double lower, double upper, float offset)
		{
			return lower + (upper - lower) * (double)offset;
		}

		public override void Clear()
		{
			base.Clear();
			minY = double.MaxValue;
			maxY = double.MinValue;
			normalizeDivisorY = 1.0;
		}

		public override object ParseY(string value, object fallback)
		{
			if (double.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}
	}
}
