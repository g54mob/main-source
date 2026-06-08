using Unity.Entities;

namespace Kitchen
{
	public struct CBeingGrabbed : IComponentData
	{
		public Entity Interactor;
	}
}
