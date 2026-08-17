using Cpp2ILInjected;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI.Account;

public class HelpPanel : BaseAccountPagePanel
{
	public HelpPanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2EA5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string accountTranslation = AccountPage.GetAccountTranslation("help_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("help_general_text");
		string accountTranslation3 = AccountPage.GetAccountTranslation("help_privacy_policy_text");
		AccountHelpAndSupportUI accountHelpAndSupportUI = base._accountPage.AddHelpAndSupport(accountTranslation2, accountTranslation3);
		AddBackButtonListener();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}
}
