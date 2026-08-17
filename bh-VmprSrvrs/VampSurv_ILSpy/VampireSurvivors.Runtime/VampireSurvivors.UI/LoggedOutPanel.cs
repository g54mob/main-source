using System;
using System.Collections;
using System.Globalization;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class LoggedOutPanel : BaseAccountPagePanel
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__0_1;

		public static Action _003C_003E9__1_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ector_003Eb__0_1()
		{
		}

		internal void _003CBuild_003Eb__1_3()
		{
		}
	}

	public LoggedOutPanel(AccountPage accountPage)
		: base(accountPage)
	{
		Action action = delegate
		{
			string accountTranslation = AccountPage.GetAccountTranslation("logged_out_help_title");
			string accountTranslation2 = AccountPage.GetAccountTranslation("logged_out_help_text");
			string accountTranslation3 = AccountPage.GetAccountTranslation("help_general_text");
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				Action action2 = delegate
				{
				};
				_003C_003Ec._003C_003E9__0_1 = action2;
			}
			Action callback = default(Action);
			IEnumerator routine = AccountErrorPopupRoutine(accountTranslation, accountTranslation2, accountTranslation3, callback);
			Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
		};
		accountPage.EnableSpecialButton(action, accountPage._infoSprite);
	}

	public override void Build()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("logged_out_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("logged_out_login_label");
		string accountTranslation3 = AccountPage.GetAccountTranslation("logged_out_login_button");
		Action callback = delegate
		{
			AccountPage accountPage2 = base._accountPage;
			accountPage2.accountPageState.ChangeStateTo(UIState.LOGIN);
			accountPage2.ClearAndBuild();
		};
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = base._accountPage.AddLabeledButton(accountTranslation2, accountTranslation3, callback, textIsLocalizationTerm, isEnabledByDefault);
		string accountTranslation4 = AccountPage.GetAccountTranslation("logged_out_register_label");
		string accountTranslation5 = AccountPage.GetAccountTranslation("logged_out_register_button");
		Action callback2 = delegate
		{
			RegistrationAllowedService registrationAllowedService = new RegistrationAllowedService();
			string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(registrationAllowedService.key);
			string text = PlayerPrefs.GetString(userSpecificKey, "");
			ref DateTime result = default(ref DateTime);
			if (text != null && text._stringLength > 0 && DateTime.TryParseExact(text, "O", null, DateTimeStyles.None, out result))
			{
				DateTime now = DateTime.Now;
				DateTime dateTime = default(DateTime);
				if (!(dateTime < now))
				{
					string accountTranslation8 = AccountPage.GetAccountTranslation("age_gate_failed_title");
					string accountTranslation9 = AccountPage.GetAccountTranslation("age_gate_failed_description");
					Action callback4 = _003C_003Ec._003C_003E9__1_3;
					if (_003C_003Ec._003C_003E9__1_3 == null)
					{
						callback4 = (_003C_003Ec._003C_003E9__1_3 = delegate
						{
						});
					}
					IEnumerator routine = ShowOKRoutine(accountTranslation8, accountTranslation9, callback4);
					Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
					return;
				}
			}
			AccountPage accountPage2 = base._accountPage;
			accountPage2.accountPageState.ChangeStateTo(UIState.AGE_GATE);
			accountPage2.ClearAndBuild();
		};
		LabeledButtonUI labeledButtonUI2 = base._accountPage.AddLabeledButton(accountTranslation4, accountTranslation5, callback2, textIsLocalizationTerm, isEnabledByDefault);
		string accountTranslation6 = AccountPage.GetAccountTranslation("logged_out_account_recovery_label");
		string accountTranslation7 = AccountPage.GetAccountTranslation("logged_out_account_recovery_button");
		Action callback3 = delegate
		{
			AccountPage accountPage2 = base._accountPage;
			accountPage2.accountPageState.ChangeStateTo(UIState.ACCOUNT_RECOVERY);
			accountPage2.ClearAndBuild();
		};
		LabeledButtonUI labeledButtonUI3 = base._accountPage.AddLabeledButton(accountTranslation6, accountTranslation7, callback3, textIsLocalizationTerm, isEnabledByDefault);
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}

	private void _003C_002Ector_003Eb__0_0()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("logged_out_help_title");
		string accountTranslation2 = AccountPage.GetAccountTranslation("logged_out_help_text");
		string accountTranslation3 = AccountPage.GetAccountTranslation("help_general_text");
		if (_003C_003Ec._003C_003E9__0_1 == null)
		{
			Action action = delegate
			{
			};
			_003C_003Ec._003C_003E9__0_1 = action;
		}
		Action callback = default(Action);
		IEnumerator routine = AccountErrorPopupRoutine(accountTranslation, accountTranslation2, accountTranslation3, callback);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	private void _003CBuild_003Eb__1_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.LOGIN);
		accountPage.ClearAndBuild();
	}

	private void _003CBuild_003Eb__1_1()
	{
		RegistrationAllowedService registrationAllowedService = new RegistrationAllowedService();
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(registrationAllowedService.key);
		string text = PlayerPrefs.GetString(userSpecificKey, "");
		ref DateTime result = default(ref DateTime);
		if (text != null && text._stringLength > 0 && DateTime.TryParseExact(text, "O", null, DateTimeStyles.None, out result))
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = default(DateTime);
			if (!(dateTime < now))
			{
				string accountTranslation = AccountPage.GetAccountTranslation("age_gate_failed_title");
				string accountTranslation2 = AccountPage.GetAccountTranslation("age_gate_failed_description");
				Action callback = _003C_003Ec._003C_003E9__1_3;
				if (_003C_003Ec._003C_003E9__1_3 == null)
				{
					callback = (_003C_003Ec._003C_003E9__1_3 = delegate
					{
					});
				}
				IEnumerator routine = ShowOKRoutine(accountTranslation, accountTranslation2, callback);
				Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
				return;
			}
		}
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.AGE_GATE);
		accountPage.ClearAndBuild();
	}

	private void _003CBuild_003Eb__1_2()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.ACCOUNT_RECOVERY);
		accountPage.ClearAndBuild();
	}
}
