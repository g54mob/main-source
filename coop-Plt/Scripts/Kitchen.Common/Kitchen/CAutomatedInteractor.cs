using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAutomatedInteractor : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public InteractionType Type;

		public bool IsHeld;

		public bool DoNotReceive;

		public bool TransferOnly;

		public TransferFlags RequiredFlags;
	}
}
