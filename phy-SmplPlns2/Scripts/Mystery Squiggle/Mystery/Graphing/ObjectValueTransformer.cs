namespace Mystery.Graphing
{
	public class ObjectValueTransformer<T> : ValueTransformer<T>
	{
		public override bool IsInRange(T value, T lower, T upper)
		{
			return false;
		}

		public override double GetTransformToRangeScale(T lower, T upper)
		{
			return 0.5;
		}

		public override double ApplyTransformToRange(T value, T lower, double inverseDivisor)
		{
			return 0.5;
		}

		public override void GetRange(float zoom, float pan, ref T min, ref T max)
		{
			min = default(T);
			max = default(T);
		}

		public override float ToFloat(T yValue)
		{
			return 0f;
		}

		public override T GetDistanceBetween(T a, T b)
		{
			return default(T);
		}

		public override object Parse(string value, object fallback)
		{
			return default(T);
		}

		public override string ToString(T value)
		{
			return value.ToString();
		}

		public override T Lerp(T lower, T upper, float offset)
		{
			return lower;
		}
	}
}
