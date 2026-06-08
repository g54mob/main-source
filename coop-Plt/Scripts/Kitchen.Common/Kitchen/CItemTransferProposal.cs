using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemTransferProposal : IComponentData
	{
		public SystemReference ResolutionSystem;

		public SystemReference PrunedBy;

		public Entity Item;

		public ItemTransferStatus Status;

		public TransferFlags Flags;

		public Entity Source;

		public Entity Destination;

		public CItem ItemData;

		public int ItemType;

		public ItemList ItemComponents;

		public MergeCondition MergeCondition;

		public int RefuseMergeWith;
	}
}
