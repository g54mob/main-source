using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAppliance : IComponentData
	{
		public int ID;

		public OccupancyLayer Layer;

		public static implicit operator CAppliance(int t)
		{
			return new CAppliance
			{
				ID = t
			};
		}

		public static implicit operator int(CAppliance h)
		{
			return h.ID;
		}
	}
}
