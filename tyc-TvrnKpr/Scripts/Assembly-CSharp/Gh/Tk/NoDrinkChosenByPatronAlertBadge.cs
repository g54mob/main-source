namespace Gh.Tk
{
	public class NoDrinkChosenByPatronAlertBadge : ChosenByPatronAlertBadge
	{
		public NoDrinkChosenByPatronAlertBadge()
			: base(null, null)
		{
		}

		protected override bool ShouldEvaluateItem(IngredientTemplate template)
		{
			return false;
		}
	}
}
