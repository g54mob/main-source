namespace Helpers.Ranges
{
	public interface IRange<T>
	{
		T Min { get; }

		T Max { get; }

		T Magnitude { get; }

		T GetRandom();

		T Clamp(T targetValue);

		bool Contains(T targetValue);
	}
}
