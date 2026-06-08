using Unity.Entities;

namespace Kitchen
{
	public struct CBeingLookedAt : IComponentData
	{
		public Entity Interactor;
	}
}
