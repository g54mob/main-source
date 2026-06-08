using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCreateAppliance : IComponentData
	{
		public int ID;

		public OccupancyLayer ForceLayer;

		public static implicit operator CCreateAppliance(int t)
		{
			return new CCreateAppliance
			{
				ID = t
			};
		}

		public static implicit operator int(CCreateAppliance h)
		{
			return h.ID;
		}
	}
}
