namespace VampireSurvivors.UI;

public class DebugPanel : BaseAccountPagePanel
{
	public DebugPanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		AddBackButtonListener();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}
}
