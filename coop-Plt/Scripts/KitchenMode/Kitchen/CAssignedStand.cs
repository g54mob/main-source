using Unity.Entities;

namespace Kitchen
{
	public struct CAssignedStand : IComponentData
	{
		public Entity Stand;

		public static implicit operator Entity(CAssignedStand h)
		{
			return h.Stand;
		}
	}
}
