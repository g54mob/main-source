namespace Mystery.Graphing
{
	public class BooleanValueTransformer : ValueTransformer<bool>
	{
		public override bool IsInRange(bool value, bool lower, bool upper)
		{
			if (value != lower)
			{
				return value == upper;
			}
			return true;
		}

		public override double GetTransformToRangeScale(bool lower, bool upper)
		{
			return 1.0;
		}

		public override double ApplyTransformToRange(bool value, bool lower, double inverseDivisor)
		{
			if (!value)
			{
				return 0.0;
			}
			return 1.0;
		}

		public override bool GetDistanceBetween(bool a, bool b)
		{
			if (a != b)
			{
				return true;
			}
			return false;
		}

		public override void GetRange(float zoom, float pan, ref bool min, ref bool max)
		{
			min = false;
			max = true;
		}

		public override float ToFloat(bool value)
		{
			if (!value)
			{
				return 0f;
			}
			return 1f;
		}

		public override object Parse(string value, object fallback)
		{
			if (bool.TryParse(value, out var result))
			{
				return result;
			}
			return fallback;
		}

		public override string ToString(bool value)
		{
			return value.ToString();
		}

		public override bool Lerp(bool lower, bool upper, float offset)
		{
			return lower;
		}
	}
}
