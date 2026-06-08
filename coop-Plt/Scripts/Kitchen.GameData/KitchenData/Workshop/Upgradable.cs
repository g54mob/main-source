namespace KitchenData.Workshop
{
	public class Upgradable : IWorkshopIndividualCondition, IWorkshopCondition
	{
		public bool Matches(Appliance app)
		{
			return app.HasUpgrades;
		}
	}
}
