using Unity.Entities;

namespace Kitchen
{
	public struct CAssignedMenu : IComponentData
	{
		public Entity Menu;

		public static implicit operator Entity(CAssignedMenu h)
		{
			return h.Menu;
		}
	}
}
