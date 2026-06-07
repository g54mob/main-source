namespace Gh.Tk
{
	public abstract class ChosenByPatronAlertBadge : AlertBadgeBase
	{
		protected ChosenByPatronAlertBadge(string title, string tooltip)
		{
		}

		protected override bool UpdateInternal()
		{
			return false;
		}

		protected virtual bool CanUpdate()
		{
			return false;
		}

		protected abstract bool ShouldEvaluateItem(IngredientTemplate template);

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
