using System;
using System.Collections;
using System.Globalization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class AgeGatePanel : BaseAccountPagePanel
{
	private LabeledButtonUI _confirmButton;

	private DateOfBirthField _dob;

	private int _day = 1;

	private int _month = 1;

	private int _year;

	private bool _madeChange;

	public AgeGatePanel(AccountPage accountPage)
	{
		DateTime now = DateTime.Now;
		DateTime dateTime = default(DateTime);
		_year = dateTime.GetDatePart(0) - 1;
		base._002Ector(accountPage);
	}

	public override void Build()
	{
		//IL_00e7: Expected I, but got O
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Expected O, but got Unknown
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c2: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Expected O, but got Unknown
		string accountTranslation = AccountPage.GetAccountTranslation("age_gate_title");
		AccountPage accountPage = base._accountPage;
		if ((object)base._accountPage != null && (object)((ProgrammaticUI)accountPage)._Title != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			string accountTranslation2 = AccountPage.GetAccountTranslation("age_gate_description");
			AccountPage accountPage2 = base._accountPage;
			if ((object)base._accountPage != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(((ProgrammaticUI)accountPage2)._DateOfBirthPrefab, ((ProgrammaticUI)accountPage2)._Content);
				if ((object)gameObject != null)
				{
					DateOfBirthField component = gameObject.GetComponent<DateOfBirthField>();
					if ((object)component != null)
					{
						TextMeshProUGUI label = component._Label;
						if ((object)component._Label != null)
						{
							nint num = (nint)label;
							component._Label.text = accountTranslation2;
							if (((ProgrammaticUI)accountPage2)._spawnedSelectables != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
								DateOfBirthField component2 = gameObject.GetComponent<DateOfBirthField>();
								if ((object)component2 != null)
								{
									component2.Initialize();
									_dob = component2;
									DateOfBirthField dob = _dob;
									DateOfBirthField.OnValueChanged b = OnYearSet;
									if ((object)_dob != null)
									{
										Delegate obj = dob.YearChanged;
										object obj2 = _dob + 88;
										while (true)
										{
											Delegate obj3 = Delegate.Combine(obj, b);
											bool flag = (object)obj3 == null;
											Delegate obj4 = null;
											if (!flag)
											{
												bool flag2 = (object)obj3.GetType() != typeof(DateOfBirthField.OnValueChanged);
												obj4 = null;
												if (!flag2)
												{
													obj4 = obj3;
												}
												if ((object)obj4 == null)
												{
													break;
												}
											}
											bool flag3 = obj == obj2;
											Delegate obj5;
											if (obj == obj2)
											{
												obj2 = obj4;
												obj5 = obj;
											}
											else
											{
												obj5 = (Delegate)obj2;
											}
											Delegate obj6 = obj;
											if (!flag3)
											{
												obj6 = obj5;
											}
											bool flag4 = (object)obj6 != obj;
											obj = obj6;
											if (flag4)
											{
												continue;
											}
											goto IL_026f;
										}
										goto IL_07b5;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05a9;
		IL_07c1:
		InvalidCastException ex = new InvalidCastException();
		goto IL_07b5;
		IL_07b5:
		throw new InvalidCastException();
		IL_07d5:
		InvalidCastException ex2 = new InvalidCastException();
		goto IL_07c1;
		IL_0475:
		string accountTranslation3 = AccountPage.GetAccountTranslation("age_gate_confirm");
		Action callback = OnConfirmPressed;
		if ((object)base._accountPage != null)
		{
			bool textIsLocalizationTerm = default(bool);
			bool isEnabledByDefault = default(bool);
			LabeledButtonUI confirmButton = base._accountPage.AddLabeledButton("", accountTranslation3, callback, textIsLocalizationTerm, isEnabledByDefault);
			_confirmButton = confirmButton;
			LabeledButtonUI confirmButton2 = _confirmButton;
			if ((object)_confirmButton != null && (object)confirmButton2._Button != null)
			{
				confirmButton2._Button.interactable = false;
				AddBackButtonListener();
				if ((object)base._accountPage != null)
				{
					base._accountPage.GenerateNavigation();
					if ((object)base._accountPage != null)
					{
						base._accountPage.SelectFirstSelectable();
						return;
					}
				}
			}
		}
		goto IL_05a9;
		IL_05a9:
		NullReferenceException ex3 = new NullReferenceException();
		goto IL_07d5;
		IL_026f:
		DateOfBirthField dob2 = _dob;
		DateOfBirthField.OnValueChanged b2 = OnMonthSet;
		if ((object)_dob == null)
		{
			goto IL_05a9;
		}
		Delegate obj7 = dob2.MonthChanged;
		object obj8 = _dob + 80;
		while (true)
		{
			Delegate obj9 = Delegate.Combine(obj7, b2);
			bool flag5 = (object)obj9 == null;
			Delegate obj10 = null;
			if (!flag5)
			{
				bool flag6 = (object)obj9.GetType() != typeof(DateOfBirthField.OnValueChanged);
				obj10 = null;
				if (!flag6)
				{
					obj10 = obj9;
				}
				if ((object)obj10 == null)
				{
					break;
				}
			}
			bool flag7 = obj7 == obj8;
			Delegate obj11;
			if (obj7 == obj8)
			{
				obj8 = obj10;
				obj11 = obj7;
			}
			else
			{
				obj11 = (Delegate)obj8;
			}
			Delegate obj12 = obj7;
			if (!flag7)
			{
				obj12 = obj11;
			}
			bool flag8 = (object)obj12 != obj7;
			obj7 = obj12;
			if (flag8)
			{
				continue;
			}
			goto IL_0372;
		}
		goto IL_07c1;
		IL_0372:
		DateOfBirthField dob3 = _dob;
		DateOfBirthField.OnValueChanged b3 = OnDaySet;
		if ((object)_dob == null)
		{
			goto IL_05a9;
		}
		Delegate obj13 = dob3.DayChanged;
		object obj14 = _dob + 72;
		while (true)
		{
			Delegate obj15 = Delegate.Combine(obj13, b3);
			bool flag9 = (object)obj15 == null;
			Delegate obj16 = null;
			if (!flag9)
			{
				bool flag10 = (object)obj15.GetType() != typeof(DateOfBirthField.OnValueChanged);
				obj16 = null;
				if (!flag10)
				{
					obj16 = obj15;
				}
				if ((object)obj16 == null)
				{
					break;
				}
			}
			bool flag11 = obj13 == obj14;
			Delegate obj17;
			if (obj13 == obj14)
			{
				obj14 = obj16;
				obj17 = obj13;
			}
			else
			{
				obj17 = (Delegate)obj14;
			}
			Delegate obj18 = obj13;
			if (!flag11)
			{
				obj18 = obj17;
			}
			bool flag12 = (object)obj18 != obj13;
			obj13 = obj18;
			if (flag12)
			{
				continue;
			}
			goto IL_0475;
		}
		goto IL_07d5;
	}

	private void DisableButton()
	{
		LabeledButtonUI confirmButton = _confirmButton;
		confirmButton._Button.interactable = false;
	}

	private void EnableButton()
	{
		LabeledButtonUI confirmButton = _confirmButton;
		confirmButton._Button.interactable = true;
	}

	private void OnAllFieldsFilled()
	{
		LabeledButtonUI confirmButton = _confirmButton;
		confirmButton._Button.interactable = true;
	}

	private void OnDaySet(int i)
	{
		_day = i;
		_madeChange = true;
		bool flag = CheckAllSet();
	}

	private void OnMonthSet(int i)
	{
		_month = i;
		_madeChange = true;
		bool flag = CheckAllSet();
	}

	private void OnYearSet(int i)
	{
		_year = i;
		_madeChange = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x1871FE230\"");
	}

	private bool CheckAllSet()
	{
		//IL_00ff: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4922]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_madeChange)
		{
			long num = DateTime.DateToTicks(_year, _month, _day);
			DateOfBirthField dob = _dob;
			if ((object)_dob != null)
			{
				dob._ErrorLabel.text = "";
				LabeledButtonUI confirmButton = _confirmButton;
				confirmButton._Button.interactable = true;
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private unsafe void OnConfirmPressed()
	{
		//IL_00b0: Expected O, but got Ref
		AgeGateService ageGateService = new AgeGateService();
		if (!ageGateService.IsOldEnough(_year, _month, _day))
		{
			RegistrationAllowedService registrationAllowedService = new RegistrationAllowedService();
			DateTime now = DateTime.Now;
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime = dateTime2.Add(60.0, 1000);
			object arg = dateTime2;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string value = string.FormatHelper((IFormatProvider)CultureInfo.invariant_culture_info, "{0:O}", (System.ParamsArray)(&obj));
			string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(registrationAllowedService.key);
			PlayerPrefs.SetString(userSpecificKey, value);
			PlayerPrefs.Save();
			string accountTranslation = AccountPage.GetAccountTranslation("age_gate_failed_title");
			string accountTranslation2 = AccountPage.GetAccountTranslation("age_gate_failed_description");
			Action action = delegate
			{
				AccountPage accountPage2 = base._accountPage;
				accountPage2.accountPageState.ChangeStateTo(UIState.NOT_LOGGED_IN_HOME);
				accountPage2.ClearAndBuild();
			};
			action._002Ector(this, (nint)__ldftn(AgeGatePanel._003COnConfirmPressed_003Eb__15_0));
			IEnumerator routine = ShowOKRoutine(accountTranslation, accountTranslation2, action);
			Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
		}
		else
		{
			AccountPage accountPage = base._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.PRIVACY_POLICY_GATE);
			accountPage.ClearAndBuild();
		}
	}

	private void _003COnConfirmPressed_003Eb__15_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.NOT_LOGGED_IN_HOME);
		accountPage.ClearAndBuild();
	}
}
