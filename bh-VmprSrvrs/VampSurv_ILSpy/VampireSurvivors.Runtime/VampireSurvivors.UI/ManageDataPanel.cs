using System;
using Cpp2ILInjected;

namespace VampireSurvivors.UI;

public class ManageDataPanel : BaseAccountPagePanel
{
	public ManageDataPanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("manage_data_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("manage_data_save_label");
		string accountTranslation3 = AccountPage.GetAccountTranslation("manage_data_save_button");
		Action callback = delegate
		{
			AccountPage accountPage2 = base._accountPage;
			accountPage2.accountPageState.ChangeStateTo(UIState.MANAGE_SAVE_DATA);
			accountPage2.ClearAndBuild();
		};
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = base._accountPage.AddLabeledButton(accountTranslation2, accountTranslation3, callback, textIsLocalizationTerm, isEnabledByDefault);
		string accountTranslation4 = AccountPage.GetAccountTranslation("manage_data_load_label");
		string accountTranslation5 = AccountPage.GetAccountTranslation("manage_data_load_button");
		Action callback2 = delegate
		{
			AccountPage accountPage2 = base._accountPage;
			accountPage2.accountPageState.ChangeStateTo(UIState.MANAGE_LOAD_DATA);
			accountPage2.ClearAndBuild();
		};
		LabeledButtonUI labeledButtonUI2 = base._accountPage.AddLabeledButton(accountTranslation4, accountTranslation5, callback2, textIsLocalizationTerm, isEnabledByDefault);
		AddBackButtonListener();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}

	private void _003CBuild_003Eb__1_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_SAVE_DATA);
		accountPage.ClearAndBuild();
	}

	private void _003CBuild_003Eb__1_1()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_LOAD_DATA);
		accountPage.ClearAndBuild();
	}
}
