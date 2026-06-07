namespace Mystery.Graphing
{
	public class StringValueTransformer : ValueTransformer<string>
	{
		public override bool IsInRange(string value, string lower, string upper)
		{
			return false;
		}

		public override double GetTransformToRangeScale(string lower, string upper)
		{
			return 0.5;
		}

		public override double ApplyTransformToRange(string value, string lower, double inverseDivisor)
		{
			return 0.5;
		}

		public override void GetRange(float zoom, float pan, ref string min, ref string max)
		{
			min = string.Empty;
			max = string.Empty;
		}

		public override float ToFloat(string yValue)
		{
			return 0f;
		}

		public override string GetDistanceBetween(string a, string b)
		{
			return string.Empty;
		}

		public override object Parse(string value, object fallback)
		{
			return string.Empty;
		}

		public override string ToString(string value)
		{
			return value;
		}

		public override string Lerp(string lower, string upper, float offset)
		{
			return lower;
		}
	}
}
