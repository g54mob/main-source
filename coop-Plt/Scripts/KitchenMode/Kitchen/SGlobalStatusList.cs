using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct SGlobalStatusList : IComponentData
	{
		public DataObjectList StatusList;

		public DecorationType Theme;

		public bool Has(RestaurantStatus status)
		{
			return StatusList.Contains((int)status);
		}

		public void Add(RestaurantStatus status)
		{
			if (!Has(status))
			{
				StatusList.Add((int)status);
			}
		}

		public void Remove(RestaurantStatus status)
		{
			StatusList.Remove((int)status);
		}

		public SGlobalStatusList(SGlobalStatus old_status)
		{
			Theme = old_status.Theme;
			StatusList = default(DataObjectList);
			for (int i = 0; i < 32; i++)
			{
				if (((uint)(1 << i) & (uint)old_status.Status) != 0)
				{
					StatusList.Add(1 << i);
				}
			}
		}

		public override int GetHashCode()
		{
			return ((int)Theme * 397) ^ StatusList.GetHashCode();
		}
	}
}
