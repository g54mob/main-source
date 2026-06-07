using System.Collections.Concurrent;

namespace Coherence.Entities
{
	public struct OutgoingEntityUpdate
	{
		private static readonly ConcurrentBag<OutgoingEntityUpdate> Pool;

		public EntityOperation Operation;

		public long Priority;

		public DeltaComponents Components;

		public bool IsDestroy => false;

		public bool IsCreate => false;

		public bool IsUpdate => false;

		public bool HasExistenceOperation => false;

		public static OutgoingEntityUpdate New()
		{
			return default(OutgoingEntityUpdate);
		}

		public OutgoingEntityUpdate Clone()
		{
			return default(OutgoingEntityUpdate);
		}

		public void Return()
		{
		}

		private void Reset()
		{
		}

		public void Subtract(OutgoingEntityUpdate update, IComponentInfo definition)
		{
		}

		public void Add(OutgoingEntityUpdate update)
		{
		}

		public new string ToString()
		{
			return null;
		}
	}
}
