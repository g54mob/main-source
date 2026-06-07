namespace Mystery.Graphing
{
	public class FloatValueTransformer : ValueTransformer<float>
	{
		private static string floatFormat = "F4";

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

		public override string ValueFormat => floatFormat;

		public override bool IsInRange(float value, float lower, float upper)
		{
			if (!(value < lower))
			{
				return !(value > upper);
			}
			return false;
		}

		public override double GetTransformToRangeScale(float lower, float upper)
		{
			if (lower != upper)
			{
				return 1.0 / (double)(upper - lower);
			}
			return 1.0;
		}

		public override double ApplyTransformToRange(float value, float lower, double inverseDivisor)
		{
			return (double)(value - lower) * inverseDivisor;
		}

		public override float GetDistanceBetween(float a, float b)
		{
			float num = a - b;
			if (!(num < 0f))
			{
				return num;
			}
			return 0f - num;
		}

		public override void GetRange(float zoom, float pan, ref float min, ref float max)
		{
			float num = min;
			float num2 = max;
			float num3 = max - min;
			float num4 = num3 * pan;
			num += num4;
			num2 += num4;
			float num5 = num3 * zoom;
			num += num5;
			num2 -= num5;
			min = num;
			max = num2;
		}

		public override float ToFloat(float value)
		{
			return value;
		}

		public override string ToString(float value)
		{
			return value.ToString(ValueFormat);
		}

		public override object Parse(string value, object fallback)
		{
			if (float.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}

		public override float Lerp(float lower, float upper, float offset)
		{
			return lower + (upper - lower) * offset;
		}
	}
}
