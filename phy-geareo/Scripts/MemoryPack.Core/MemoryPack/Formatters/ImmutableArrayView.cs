using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	internal struct ImmutableArrayView<T>
	{
		public T[]? array;
	}
}
