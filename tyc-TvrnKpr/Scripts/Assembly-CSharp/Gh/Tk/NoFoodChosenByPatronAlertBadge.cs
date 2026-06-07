namespace Gh.Tk
{
	public class NoFoodChosenByPatronAlertBadge : ChosenByPatronAlertBadge
	{
		public NoFoodChosenByPatronAlertBadge()
			: base(null, null)
		{
		}

		protected override bool CanUpdate()
		{
			return false;
		}

		protected override bool ShouldEvaluateItem(IngredientTemplate template)
		{
			return false;
		}
	}
}
