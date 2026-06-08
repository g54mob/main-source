namespace KitchenData.Workshop
{
	public class IsUpgrade : IWorkshopIndividualCondition, IWorkshopCondition
	{
		public bool Matches(Appliance app)
		{
			return app.IsAnUpgrade;
		}
	}
}
