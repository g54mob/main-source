namespace MiscUtil
{
	internal interface INullOp<T>
	{
		bool HasValue(T value);

		bool AddIfNotNull(ref T accumulator, T value);
	}
}
