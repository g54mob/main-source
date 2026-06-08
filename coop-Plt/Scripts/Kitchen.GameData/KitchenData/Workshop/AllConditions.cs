using System.Collections.Generic;
using System.Linq;

namespace KitchenData.Workshop
{
	public class AllConditions : IWorkshopIndividualCondition, IWorkshopCondition
	{
		public List<IWorkshopIndividualCondition> Conditions = new List<IWorkshopIndividualCondition>();

		public bool Matches(Appliance app)
		{
			return Conditions.All((IWorkshopIndividualCondition c) => c.Matches(app));
		}
	}
}
