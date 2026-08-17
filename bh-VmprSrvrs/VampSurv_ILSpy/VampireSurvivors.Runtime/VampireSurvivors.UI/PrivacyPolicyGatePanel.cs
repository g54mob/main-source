using System;
using Cpp2ILInjected;

namespace VampireSurvivors.UI;

public class PrivacyPolicyGatePanel : BaseAccountPagePanel
{
	public PrivacyPolicyGatePanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("privacy_policy_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		AccountPage accountPage2 = base._accountPage;
		accountPage2._AccountStatus.enabled = false;
		string accountTranslation2 = AccountPage.GetAccountTranslation("privacy_policy_warning");
		string accountTranslation3 = AccountPage.GetAccountTranslation("privacy_policy_view_policy_button");
		Action centerButtonCallback = delegate
		{
			AccountPage accountPage3 = base._accountPage;
			accountPage3.accountPageState.ChangeStateTo(UIState.PRIVACY_POLICY_SCROLLER);
			accountPage3.ClearAndBuild();
		};
		bool textIsLocalizationTerm = default(bool);
		base._accountPage.AddPrivacyPolicyGate(accountTranslation2, accountTranslation3, centerButtonCallback, textIsLocalizationTerm);
		AddBackButtonListener();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}

	private void _003CBuild_003Eb__1_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.PRIVACY_POLICY_SCROLLER);
		accountPage.ClearAndBuild();
	}
}
