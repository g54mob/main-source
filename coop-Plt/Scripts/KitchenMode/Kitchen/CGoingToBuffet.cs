using Unity.Entities;

namespace Kitchen
{
	public struct CGoingToBuffet : IComponentData
	{
		public CMoveToLocation PreviousInstruction;

		public Entity Buffet;

		public bool IsConfirmed;
	}
}
