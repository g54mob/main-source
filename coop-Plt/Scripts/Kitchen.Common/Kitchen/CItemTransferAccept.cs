using Unity.Entities;

namespace Kitchen
{
	public struct CItemTransferAccept : IComponentData
	{
		public TransferFlags Flags;

		public SystemReference ResolutionSystem;

		public Entity Proposal;

		public ItemAcceptStatus Status;

		public SystemReference PrunedBy;
	}
}
