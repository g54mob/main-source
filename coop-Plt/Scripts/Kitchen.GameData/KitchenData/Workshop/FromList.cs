using System.Collections.Generic;

namespace KitchenData.Workshop
{
	public class FromList : IWorkshopIndividualCondition, IWorkshopCondition
	{
		public List<Appliance> Appliances = new List<Appliance>();

		public bool Matches(Appliance app)
		{
			return Appliances.Contains(app);
		}
	}
}
