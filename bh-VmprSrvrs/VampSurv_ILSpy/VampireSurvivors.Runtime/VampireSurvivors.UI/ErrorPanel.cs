using Cpp2ILInjected;

namespace VampireSurvivors.UI;

public class ErrorPanel : BaseAccountPagePanel
{
	public ErrorPanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D9C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string accountTranslation = AccountPage.GetAccountTranslation("error_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("error_message");
		base._accountPage.AddLabel(accountTranslation2);
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}
}
