using System.Collections.Generic;

namespace Aggro.Core
{
	internal interface IComponentEntry
	{
		int Count { get; }

		void RemoveComponentData(int index);

		bool HasComponentData(int index);

		EntityKey GetKey(int index);

		void GetKeys(List<EntityKey> list);

		int CopyFrom(int copyIndex, IComponentEntry from);

		IComponentEntry CreateTypedEntry(int capacity);
	}
}
