using System;

namespace KitchenData
{
	public readonly struct ApplianceItemPair : IEquatable<ApplianceItemPair>
	{
		public readonly int Item;

		public readonly int Appliance;

		public ApplianceItemPair(int item, int appliance)
		{
			Item = item;
			Appliance = appliance;
		}

		public override bool Equals(object obj)
		{
			if (obj is ApplianceItemPair other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ApplianceItemPair other)
		{
			if (Item == other.Item)
			{
				return Appliance == other.Appliance;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (1969993502 * -1521134295 + Item.GetHashCode()) * -1521134295 + Appliance.GetHashCode();
		}
	}
}
