namespace LaundryBear.Math
{
	public interface ISpan<T>
	{
		T Start { get; }

		T Duration { get; }

		bool ContainsPoint(T point);

		bool ContainsSpan(ISpan<T> span);

		bool Overlaps(ISpan<T> span);

		bool StartsBefore(ISpan<T> span);

		bool EndsAfter(ISpan<T> span);
	}
}
