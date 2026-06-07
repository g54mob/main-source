namespace Mystery.Graphing
{
	public class LongValueTransformer : ValueTransformer<long>
	{
		public override string ValueFormat => "F0";

		public override bool IsInRange(long value, long lower, long upper)
		{
			if (value >= lower)
			{
				return value <= upper;
			}
			return false;
		}

		public override double GetTransformToRangeScale(long lower, long upper)
		{
			if (lower != upper)
			{
				return 1.0 / (double)(upper - lower);
			}
			return 1.0;
		}

		public override double ApplyTransformToRange(long value, long lower, double inverseDivisor)
		{
			return (double)(value - lower) * inverseDivisor;
		}

		public override long GetDistanceBetween(long a, long b)
		{
			long num = a - b;
			if (num >= 0)
			{
				return num;
			}
			return -num;
		}

		public override void GetRange(float zoom, float pan, ref long min, ref long max)
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
			min = (long)num;
			max = (long)num2;
		}

		public override float ToFloat(long yValue)
		{
			return yValue;
		}

		public override object Parse(string value, object fallback)
		{
			if (long.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}

		public override string ToString(long value)
		{
			return value.ToString(ValueFormat);
		}

		public override long Lerp(long lower, long upper, float offset)
		{
			return lower + (long)((double)(upper - lower) * (double)offset);
		}
	}
}
