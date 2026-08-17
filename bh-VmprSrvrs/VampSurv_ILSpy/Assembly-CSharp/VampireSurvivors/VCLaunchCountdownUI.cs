using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class VCLaunchCountdownUI : MonoBehaviour
{
	private enum CountdownState
	{
		Uninitialized,
		BeforeCountdown,
		DuringCountdown,
		DuringLaunchWindow,
		AfterLaunchWindow
	}

	private MainMenuPage MainMenu;

	private Selectable MainMenuPlayButton;

	private CanvasGroup _canvasGroup;

	private CanvasGroup _countdownCanvasGroup;

	private CanvasGroup _playNowCanvasGroup;

	private Image _countdownRadialFillImage;

	private Transform _countdownClockHandTransform;

	private TextMeshProUGUI _countdownText;

	private readonly DateTime _countdownStartTime;

	private readonly DateTime _crawlersLaunchTime;

	private readonly DateTime _launchEndTime;

	private const string ClosedCountdownPrefsKey = "ClosedCrawlersCountdown";

	private const string LinkToSteamPage = "https://store.steampowered.com/app/3265700/?utm_source=vampire_survivors&utm_medium=pc_in_game_button&utm_campaign=vc_launch";

	private CountdownState _currentCountdownState;

	private bool ClosedCountDown
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FDF]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag = PlayerPrefs.HasKey("ClosedCrawlersCountdown");
			if (!flag)
			{
				return flag;
			}
			int num = PlayerPrefs.GetInt("ClosedCrawlersCountdown", 0);
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag2 = num3 < 0;
			bool flag3 = num < 0;
			bool flag4 = num == 0;
			bool flag5 = flag3 == flag2;
			bool flag6 = !flag4;
			return flag6 & flag5;
		}
	}

	private bool ClosedPlayNow
	{
		get
		{
			//IL_0059: Expected O, but got I4
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected I4, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FE0]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag = PlayerPrefs.HasKey("ClosedCrawlersCountdown");
			if (!flag)
			{
				return flag;
			}
			int num = PlayerPrefs.GetInt("ClosedCrawlersCountdown", 0);
			object obj = num - 1;
			int num2 = num ^ 1;
			int num3 = num ^ obj;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			bool flag3 = (nint)obj < 0;
			bool flag4 = obj == null;
			bool flag5 = flag3 == flag2;
			bool flag6 = !flag4;
			return flag6 & flag5;
		}
	}

	private DateTime CountdownStartTime => _countdownStartTime;

	private DateTime CrawlersLaunchTime => _crawlersLaunchTime;

	private DateTime LaunchEndTime => _launchEndTime;

	private void Start()
	{
		MainMenuPage mainMenu = MainMenu;
		PlayerOptionsData config = mainMenu._playerOptions.Config;
		List<StageType> list = config._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		bool flag = (nint)0 == 0;
		VCLaunchCountdownUI vCLaunchCountdownUI = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			bool flag2 = (nint)obj == -1;
			vCLaunchCountdownUI = this;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 109 Invalid \"Jump target not found in method: 0x181B8F2D0\"");
				VCLaunchCountdownUI vCLaunchCountdownUI2 = default(VCLaunchCountdownUI);
				vCLaunchCountdownUI = vCLaunchCountdownUI2;
			}
		}
		vCLaunchCountdownUI._canvasGroup.interactable = false;
		vCLaunchCountdownUI._canvasGroup.blocksRaycasts = false;
		vCLaunchCountdownUI._canvasGroup.alpha = 0f;
	}

	private void SetInitialState()
	{
		//IL_00de: Expected F4, but got I4
		DateTime utcNow = DateTime.UtcNow;
		CanvasGroup canvasGroup2;
		float alpha;
		if (!(utcNow > _launchEndTime))
		{
			bool flag = utcNow > _crawlersLaunchTime;
			VCLaunchCountdownUI vCLaunchCountdownUI = this;
			if (!flag)
			{
				if (!(utcNow > _countdownStartTime))
				{
					if (_currentCountdownState != CountdownState.BeforeCountdown)
					{
						_currentCountdownState = CountdownState.BeforeCountdown;
						goto IL_02db;
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 167 Invalid \"Jump target not found in method: 0x181B8F520\"");
				VCLaunchCountdownUI vCLaunchCountdownUI2 = default(VCLaunchCountdownUI);
				vCLaunchCountdownUI = vCLaunchCountdownUI2;
			}
			if (vCLaunchCountdownUI._currentCountdownState == CountdownState.DuringLaunchWindow)
			{
				return;
			}
			vCLaunchCountdownUI._currentCountdownState = CountdownState.DuringLaunchWindow;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FE0]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			CanvasGroup canvasGroup;
			if (!PlayerPrefs.HasKey("ClosedCrawlersCountdown"))
			{
				canvasGroup = vCLaunchCountdownUI._canvasGroup;
			}
			else
			{
				int num = PlayerPrefs.GetInt("ClosedCrawlersCountdown", 0);
				canvasGroup = vCLaunchCountdownUI._canvasGroup;
				bool flag2 = num > 1;
				canvasGroup2 = vCLaunchCountdownUI._canvasGroup;
				if (flag2)
				{
					goto IL_00b4;
				}
			}
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
			canvasGroup.alpha = 1f;
			vCLaunchCountdownUI._countdownCanvasGroup.interactable = false;
			vCLaunchCountdownUI._countdownCanvasGroup.blocksRaycasts = false;
			vCLaunchCountdownUI._countdownCanvasGroup.alpha = 0f;
			canvasGroup2 = vCLaunchCountdownUI._playNowCanvasGroup;
			vCLaunchCountdownUI._playNowCanvasGroup.interactable = true;
			vCLaunchCountdownUI._playNowCanvasGroup.blocksRaycasts = true;
			alpha = 1f;
			goto IL_02c9;
		}
		if (_currentCountdownState == CountdownState.AfterLaunchWindow)
		{
			return;
		}
		_currentCountdownState = CountdownState.AfterLaunchWindow;
		goto IL_02db;
		IL_00b4:
		canvasGroup2.interactable = false;
		canvasGroup2.blocksRaycasts = false;
		alpha = 0f;
		goto IL_02c9;
		IL_02c9:
		canvasGroup2.alpha = alpha;
		return;
		IL_02db:
		canvasGroup2 = _canvasGroup;
		goto IL_00b4;
	}

	private void ChangeState(CountdownState newState)
	{
		//IL_0053: Expected O, but got I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_00f2: Expected F4, but got I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		if (newState == _currentCountdownState)
		{
			return;
		}
		_currentCountdownState = newState;
		bool flag = newState == CountdownState.Uninitialized;
		if (flag)
		{
			return;
		}
		object obj = newState - 1;
		CanvasGroup canvasGroup2;
		CanvasGroup canvasGroup3;
		float alpha;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FDF]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				CanvasGroup canvasGroup;
				if (!PlayerPrefs.HasKey("ClosedCrawlersCountdown"))
				{
					canvasGroup = _canvasGroup;
				}
				else
				{
					int num = PlayerPrefs.GetInt("ClosedCrawlersCountdown", 0);
					canvasGroup2 = _canvasGroup;
					bool flag2 = num > 0;
					canvasGroup = _canvasGroup;
					if (flag2)
					{
						goto IL_0228;
					}
				}
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				_countdownCanvasGroup.interactable = true;
				_countdownCanvasGroup.blocksRaycasts = true;
				_countdownCanvasGroup.alpha = 1f;
				canvasGroup3 = _playNowCanvasGroup;
				goto IL_00c8;
			}
			object obj3 = obj2 - 1;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FE0]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				CanvasGroup canvasGroup4;
				if (!PlayerPrefs.HasKey("ClosedCrawlersCountdown"))
				{
					canvasGroup4 = _canvasGroup;
				}
				else
				{
					int num2 = PlayerPrefs.GetInt("ClosedCrawlersCountdown", 0);
					canvasGroup4 = _canvasGroup;
					bool flag3 = num2 > 1;
					canvasGroup2 = _canvasGroup;
					if (flag3)
					{
						goto IL_0228;
					}
				}
				canvasGroup4.interactable = true;
				canvasGroup4.blocksRaycasts = true;
				canvasGroup4.alpha = 1f;
				_countdownCanvasGroup.interactable = false;
				_countdownCanvasGroup.blocksRaycasts = false;
				_countdownCanvasGroup.alpha = 0f;
				canvasGroup3 = _playNowCanvasGroup;
				_playNowCanvasGroup.interactable = true;
				_playNowCanvasGroup.blocksRaycasts = true;
				alpha = 1f;
				goto IL_0373;
			}
			if ((nint)obj3 != 1)
			{
				return;
			}
		}
		canvasGroup3 = _canvasGroup;
		goto IL_00c8;
		IL_0228:
		canvasGroup2.interactable = false;
		canvasGroup2.blocksRaycasts = false;
		canvasGroup2.alpha = 0f;
		return;
		IL_00c8:
		canvasGroup3.interactable = false;
		canvasGroup3.blocksRaycasts = false;
		alpha = 0f;
		goto IL_0373;
		IL_0373:
		canvasGroup3.alpha = alpha;
	}

	private void Update()
	{
		//IL_003d: Expected O, but got I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		DateTime utcNow = DateTime.UtcNow;
		bool flag = _currentCountdownState == CountdownState.Uninitialized;
		if (!flag)
		{
			object obj = _currentCountdownState - 1;
			CountdownState newState;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1 && utcNow > _launchEndTime && _currentCountdownState != CountdownState.AfterLaunchWindow)
					{
						_currentCountdownState = CountdownState.AfterLaunchWindow;
						goto IL_00e7;
					}
					return;
				}
				UpdateCountdownVisuals(utcNow);
				if (!(utcNow > _crawlersLaunchTime))
				{
					return;
				}
				newState = CountdownState.DuringLaunchWindow;
			}
			else
			{
				if (!(utcNow > _countdownStartTime))
				{
					return;
				}
				newState = CountdownState.DuringCountdown;
			}
			ChangeState(newState);
			return;
		}
		if (!(utcNow < _countdownStartTime) || _currentCountdownState == CountdownState.BeforeCountdown)
		{
			return;
		}
		_currentCountdownState = CountdownState.BeforeCountdown;
		goto IL_00e7;
		IL_00e7:
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.alpha = 0f;
	}

	public void OnCloseCountdownButtonClicked()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FE4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int value;
		if (_currentCountdownState == CountdownState.DuringCountdown)
		{
			value = 1;
		}
		else
		{
			if (_currentCountdownState != CountdownState.DuringLaunchWindow)
			{
				goto IL_00ab;
			}
			value = 2;
		}
		PlayerPrefs.SetInt("ClosedCrawlersCountdown", value);
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.alpha = 0f;
		goto IL_00ab;
		IL_00ab:
		MainMenuPlayButton.Select();
	}

	public void OpenCrawlersPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189978FE5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SteamFriends.OpenWebOverlay("https://store.steampowered.com/app/3265700/?utm_source=vampire_survivors&utm_medium=pc_in_game_button&utm_campaign=vc_launch");
	}

	private unsafe void UpdateCountdownVisuals(DateTime timeNow)
	{
		//IL_00a5: Expected O, but got I
		//IL_00d7: Expected O, but got Ref
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0141: Expected O, but got Ref
		//IL_0181: Expected O, but got Ref
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01f8: Expected O, but got Ref
		//IL_022f: Invalid comparison between F4 and I4
		//IL_02b1->IL0269: Incompatible stack heights: 1 vs 0
		TimeSpan timeSpan = _crawlersLaunchTime - timeNow;
		TimeSpan timeSpan2 = _crawlersLaunchTime - _countdownStartTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rdi\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm1,rbx\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rbx\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10010h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rbx\"");
		object obj2 = default(object);
		object obj = (nint)(&obj2) >> 26;
		object obj3 = obj >> 63;
		object obj4 = obj + obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8\"");
		object obj5 = (ref *(_003F*)(&obj2)) + (ref *(_003F*)obj4);
		object obj6 = obj5 >> 5;
		object obj7 = obj6 >> 63;
		object obj8 = obj6 + obj7;
		object obj9 = obj8 * 60;
		object obj10 = obj4 - obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rbx\"");
		object obj11 = (ref *(_003F*)timeSpan) + (ref *(_003F*)(&obj2));
		object obj12 = obj11 >> 23;
		object obj13 = obj12 >> 63;
		object obj14 = obj12 + obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8\"");
		object obj15 = (ref *(_003F*)(&obj2)) + (ref *(_003F*)obj14);
		object obj16 = obj15 >> 5;
		object obj17 = obj16 >> 63;
		object obj18 = obj16 + obj17;
		object obj19 = obj18 * 60;
		object obj20 = obj14 - obj19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		object arg3 = default(object);
		System.ParamsArray value = new System.ParamsArray(arg, arg2, arg3);
		Quaternion ret = default(Quaternion);
		string text = string.FormatHelper((IFormatProvider)null, "{0:00}:{1:00}:{2:00}", (System.ParamsArray)(&ret));
		_countdownText.text = text;
		_countdownRadialFillImage.fillAmount = 1f;
		if (1f > 0f)
		{
			string countdownClockHandTransform = (string)(object)_countdownClockHandTransform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret);
			bool flag = countdownClockHandTransform._stringLength == 0;
			Transform.set_rotation_Injected((IntPtr)countdownClockHandTransform._stringLength, ref *(Quaternion*)(&value));
		}
	}

	private void SetCanvasGroupActive(CanvasGroup canvasGroup, bool isActive)
	{
		//IL_002c: Expected F4, but got I4
		canvasGroup.interactable = isActive;
		canvasGroup.blocksRaycasts = isActive;
		canvasGroup.alpha = (isActive ? 1 : 0);
	}

	public unsafe VCLaunchCountdownUI()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_005a: Expected native int or pointer, but got O
		//IL_00a1: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		_ = 0;
		object obj = default(object);
		DateTime dateTime = (DateTime)(obj + 8);
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 16;
		_ = 0;
		int hour = default(int);
		int minute = default(int);
		int second = default(int);
		DateTimeKind kind = default(DateTimeKind);
		*(DateTime*)(nint)dateTime = new DateTime(2026, 4, 14, hour, minute, second, kind);
		DateTime countdownStartTime = default(DateTime);
		_countdownStartTime = countdownStartTime;
		countdownStartTime = new DateTime(2026, 4, 21, hour, minute, second, kind);
		_crawlersLaunchTime = (DateTime)0;
		countdownStartTime = new DateTime(2026, 5, 1, hour, minute, second, kind);
		_launchEndTime = (DateTime)0;
	}
}
