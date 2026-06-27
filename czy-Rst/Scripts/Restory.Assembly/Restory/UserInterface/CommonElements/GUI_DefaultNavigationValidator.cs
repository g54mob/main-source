namespace Restory.UserInterface.CommonElements
{
	public class GUI_DefaultNavigationValidator : INavigationValidator
	{
		public GUI_BaseNavigation ValidateNavigation(GUI_BaseNavigation navigation)
		{
			if (navigation != null && navigation.isActiveAndEnabled && navigation.IsInteractable())
			{
				return navigation;
			}
			return null;
		}
	}
}
