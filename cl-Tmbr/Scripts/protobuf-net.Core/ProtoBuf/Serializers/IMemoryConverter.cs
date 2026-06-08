using System;

namespace ProtoBuf.Serializers
{
	public interface IMemoryConverter<TStorage, TElement>
	{
		TStorage NonNull(in TStorage value);

		int GetLength(in TStorage value);

		Memory<TElement> GetMemory(in TStorage value);

		Memory<TElement> Expand(ISerializationContext context, ref TStorage value, int additionalCapacity);
	}
}
