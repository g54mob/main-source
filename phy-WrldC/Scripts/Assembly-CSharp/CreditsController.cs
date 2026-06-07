public class CreditsController : BaseController<CreditsView>
{
	private MainMenuView mainMenuView;

	public CreditsController(MainMenuView mainMenuView, CreditsView view)
		: base(view)
	{
		this.mainMenuView = mainMenuView;
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "CreditsView.BackEvent")
		{
			mainMenuView.GoBackToRootMenu();
		}
	}
}
