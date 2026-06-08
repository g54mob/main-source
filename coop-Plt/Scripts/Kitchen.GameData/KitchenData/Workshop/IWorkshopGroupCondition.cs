using System.Collections.Generic;

namespace KitchenData.Workshop
{
	public interface IWorkshopGroupCondition : IWorkshopCondition
	{
		bool Matches(List<Appliance> apps);
	}
}
