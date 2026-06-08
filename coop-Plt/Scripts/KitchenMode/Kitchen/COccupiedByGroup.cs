using Unity.Entities;

namespace Kitchen
{
	public struct COccupiedByGroup : IComponentData
	{
		public Entity Group;

		public static implicit operator Entity(COccupiedByGroup h)
		{
			return h.Group;
		}
	}
}
