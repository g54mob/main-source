namespace Mystery.Graphing
{
	public interface IValueTransformer
	{
		string ValueFormat { get; }

		string ToString(object yValue);

		object Parse(string value, object fallback);

		double ApplyTransformToRange(object value, object lower, double inverseDivisor);

		object GetMid(object min, object max);

		object Lerp(object a, object b, float offset);
	}
}
