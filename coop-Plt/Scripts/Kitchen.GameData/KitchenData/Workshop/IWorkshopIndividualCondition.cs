namespace KitchenData.Workshop
{
	public interface IWorkshopIndividualCondition : IWorkshopCondition
	{
		bool Matches(Appliance app);
	}
}
