using System;
using Cpp2ILInjected;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI.Account;

public class PrivacyPolicyScrollerPanel : BaseAccountPagePanel
{
	public PrivacyPolicyScrollerPanel(AccountPage accountPage)
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
		string accountTranslation2 = AccountPage.GetAccountTranslation("privacy_policy_accept");
		Action leftButtonCallback = delegate
		{
			AccountPage accountPage3 = base._accountPage;
			accountPage3.accountPageState.ChangeStateTo(UIState.REGISTER);
			accountPage3.ClearAndBuild();
		};
		string accountTranslation3 = AccountPage.GetAccountTranslation("privacy_policy_decline");
		Action action = base.GoHome;
		Action rightButtonCallback = default(Action);
		bool textIsLocalizationTerm = default(bool);
		base._accountPage.AddPrivacyPolicyScroller(accountTranslation2, leftButtonCallback, accountTranslation3, rightButtonCallback, textIsLocalizationTerm);
		AddBackButtonListener();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}

	private void _003CBuild_003Eb__1_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.REGISTER);
		accountPage.ClearAndBuild();
	}
}
