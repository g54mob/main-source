using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace KitchenData.Workshop
{
	public class AllDifferent : IWorkshopGroupCondition, IWorkshopCondition
	{
		public bool Matches(List<Appliance> apps)
		{
			if (apps.IsNullOrEmpty())
			{
				return false;
			}
			return new HashSet<int>(apps.Select((Appliance a) => a.ID)).Count == apps.Count;
		}
	}
}
