using System;
using System.Collections.Generic;

namespace Coherence.Entities
{
	public struct DeltaComponents
	{
		public ComponentUpdates Updates;

		public HashSet<uint> Destroys;

		public DateTime? OrderedUpdateTime;

		public int Count => 0;

		internal bool IsInitialized => false;

		public static DeltaComponents New(int capacity = 16)
		{
			return default(DeltaComponents);
		}

		internal void EnsureInitialized(int capacity = 16)
		{
		}

		public void CloneFrom(DeltaComponents other)
		{
		}

		public DeltaComponents Clone()
		{
			return default(DeltaComponents);
		}

		public void UpdateComponent(ComponentChange change)
		{
		}

		public void UpdateComponents(ComponentUpdates componentUpdates)
		{
		}

		public void RemoveComponent(uint comp)
		{
		}

		public void RemoveComponents(IReadOnlyList<uint> components)
		{
		}

		public void Merge(DeltaComponents other)
		{
		}

		public bool ContainsOrderedComponent(IComponentInfo componentInfo)
		{
			return false;
		}

		public bool HasUnackedOrderedComponents()
		{
			return false;
		}

		public void Reset()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static DateTime? MergeOrderedUpdateTime(DateTime? first, DateTime? second)
		{
			return null;
		}
	}
}
