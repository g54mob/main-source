using System.Collections.Generic;
using System.Numerics;

namespace Coherence.Entities
{
	public struct ComponentUpdates
	{
		public Vector3 FloatingOriginDelta;

		public SortedValueMap<uint, ComponentChange> Store { get; private set; }

		public int Count => 0;

		public static ComponentUpdates New(int capacity)
		{
			return default(ComponentUpdates);
		}

		public static ComponentUpdates New(IDictionary<uint, ComponentChange> componentChanges)
		{
			return default(ComponentUpdates);
		}

		public static ComponentUpdates New(IReadOnlyList<ICoherenceComponentData> data)
		{
			return default(ComponentUpdates);
		}

		public ComponentUpdates Clone()
		{
			return default(ComponentUpdates);
		}

		public void ClearMask(ComponentChange change)
		{
		}

		public void Update(ComponentChange change)
		{
		}

		public void Reset()
		{
		}

		public void Remove(uint componentType)
		{
		}

		public bool ContainsOrderedComponent()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
