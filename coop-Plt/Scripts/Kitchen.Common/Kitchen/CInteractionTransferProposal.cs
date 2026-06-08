using Unity.Entities;

namespace Kitchen
{
	public struct CInteractionTransferProposal : IComponentData
	{
		public Entity Interactor;

		public bool AllowGrab;

		public bool AllowAct;

		public bool RequireHeld;

		public bool RequirePress;
	}
}
