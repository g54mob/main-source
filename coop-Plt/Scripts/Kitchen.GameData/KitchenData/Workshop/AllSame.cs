using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace KitchenData.Workshop
{
	public class AllSame : IWorkshopGroupCondition, IWorkshopCondition
	{
		public bool Matches(List<Appliance> apps)
		{
			if (apps.IsNullOrEmpty())
			{
				return false;
			}
			int id = apps[0].ID;
			return apps.All((Appliance app) => app.ID == id);
		}
	}
}
