namespace KitchenData.Workshop
{
	public class Always : IWorkshopIndividualCondition, IWorkshopCondition
	{
		public bool Matches(Appliance app)
		{
			return true;
		}
	}
}
