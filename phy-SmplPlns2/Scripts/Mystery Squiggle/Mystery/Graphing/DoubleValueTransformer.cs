namespace Mystery.Graphing
{
	public class DoubleValueTransformer : ValueTransformer<double>
	{
		public override string ValueFormat => FloatValueTransformer.FloatFormat;

		public override bool IsInRange(double value, double lower, double upper)
		{
			if (!(value < lower))
			{
				return !(value > upper);
			}
			return false;
		}

		public override double GetTransformToRangeScale(double lower, double upper)
		{
			if (lower != upper)
			{
				return 1.0 / (upper - lower);
			}
			return 1.0;
		}

		public override double ApplyTransformToRange(double value, double lower, double inverseDivisor)
		{
			return (value - lower) * inverseDivisor;
		}

		public override double GetDistanceBetween(double a, double b)
		{
			double num = a - b;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0 - num;
		}

		public override void GetRange(float zoom, float pan, ref double min, ref double max)
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

		public override float ToFloat(double value)
		{
			return (float)value;
		}

		public override string ToString(double value)
		{
			return value.ToString(ValueFormat);
		}

		public override object Parse(string value, object fallback)
		{
			if (double.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}

		public override double Lerp(double lower, double upper, float offset)
		{
			return lower + (upper - lower) * (double)offset;
		}
	}
}
