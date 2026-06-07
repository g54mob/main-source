using Coherence.Entities;

namespace Coherence.Core
{
	public struct InteropOutgoingEntityUpdate
	{
		public InteropEntity ID;

		public unsafe ComponentDataContainer* Components;

		public int ComponentCount;

		public unsafe uint* DestroyedComponents;

		public int DestroyedCount;

		public long Priority;

		public EntityOperation Operation;
	}
}
