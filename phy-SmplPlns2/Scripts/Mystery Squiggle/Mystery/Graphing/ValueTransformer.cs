namespace Mystery.Graphing
{
	public abstract class ValueTransformer<T> : IValueTransformer
	{
		public virtual string ValueFormat => string.Empty;

		public abstract float ToFloat(T value);

		public abstract string ToString(T value);

		string IValueTransformer.ToString(object value)
		{
			return ToString((T)value);
		}

		public abstract bool IsInRange(T value, T lower, T upper);

		public abstract double GetTransformToRangeScale(T lower, T upper);

		public abstract double ApplyTransformToRange(T value, T lower, double inverseDivisor);

		double IValueTransformer.ApplyTransformToRange(object value, object lower, double inverseDivisor)
		{
			return ApplyTransformToRange((T)value, (T)lower, inverseDivisor);
		}

		public abstract T GetDistanceBetween(T a, T b);

		public abstract T Lerp(T a, T b, float offset);

		object IValueTransformer.Lerp(object min, object max, float offset)
		{
			return Lerp((T)min, (T)max, offset);
		}

		public T GetMid(T min, T max)
		{
			return Lerp(min, max, 0.5f);
		}

		object IValueTransformer.GetMid(object min, object max)
		{
			return GetMid((T)min, (T)max);
		}

		public abstract void GetRange(float scale, float offset, ref T min, ref T max);

		public abstract object Parse(string value, object fallback);
	}
}
