using System.Collections.Generic;
using Unity.Collections;

namespace Aggro.Core
{
	internal interface IJobComponentEntry
	{
		int Count { get; }

		void RemoveComponentData(int index);

		bool HasComponentData(int index);

		EntityKey GetKey(int index);

		void GetKeys(List<EntityKey> list);

		NativeArray<EntityKey> GetKeysRaw();

		int CopyFrom(int copyIndex, IJobComponentEntry from);

		IJobComponentEntry CreateTypedEntry(int capacity, Allocator allocator);
	}
}
