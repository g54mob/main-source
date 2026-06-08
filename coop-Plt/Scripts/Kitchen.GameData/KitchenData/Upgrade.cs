using System.Collections.Generic;

namespace KitchenData
{
	public class Upgrade : IWorkshopProduct
	{
		public bool GetResult(List<Appliance> inputs, out Appliance result)
		{
			result = null;
			foreach (Appliance input in inputs)
			{
				if (input.HasUpgrades)
				{
					result = input.Upgrades.Random();
				}
			}
			return result != null;
		}
	}
}
