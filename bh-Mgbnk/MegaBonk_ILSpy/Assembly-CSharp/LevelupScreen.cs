using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class LevelupScreen : BaseEncounterWindow
{
	public static bool isLevelingUp;

	public GameObject window;

	public GameObject effects;

	public AudioSource audioLevel;

	public AudioSource audioShadyGuy;

	public GameObject button;

	public UpgradePicker upgradePicker;

	public UpgradeInventoryUI upgradeInventoryUi;

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public MyButtonOffersUtility b_skip;

	public MyButtonOffersUtility b_refresh;

	public MyButtonOffersUtility b_banish;

	public MyButtonNormal b_leave;

	public static Action A_LevelupEnabled;

	public static Action A_LevelUpClose;

	private int level;

	private int currentLevel;

	public Window windowScript;

	private static bool hasBanishes;

	private static bool hasRefreshes;

	private static bool hasSkips;

	private bool hasInitedThisStage;

	private EEncounter encounterType;

	public float refreshTime;

	private void TryInit()
	{
		if (!hasInitedThisStage && MapController.index == 0)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int num = inventory.banishes ^ inventory.banishes;
			int num2 = inventory.banishes & num;
			bool flag = num2 < 0;
			bool flag2 = inventory.banishes < 0;
			bool flag3 = inventory.banishes == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			bool flag6 = flag5 & flag4;
			hasBanishes = flag6;
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int num3 = inventory2.refreshes ^ inventory2.refreshes;
			int num4 = inventory2.refreshes & num3;
			bool flag7 = num4 < 0;
			bool flag8 = inventory2.refreshes < 0;
			bool flag9 = inventory2.refreshes == 0;
			bool flag10 = flag8 == flag7;
			bool flag11 = !flag9;
			bool flag12 = flag11 & flag10;
			hasRefreshes = flag12;
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			int num5 = inventory3.skips ^ inventory3.skips;
			int num6 = inventory3.skips & num5;
			bool flag13 = num6 < 0;
			bool flag14 = inventory3.skips < 0;
			bool flag15 = inventory3.skips == 0;
			bool flag16 = flag14 == flag13;
			bool flag17 = !flag15;
			bool flag18 = flag17 & flag16;
			hasSkips = flag18;
			hasInitedThisStage = true;
		}
	}

	public void ShowLevelupScreen()
	{
		//IL_068e: Expected I, but got O
		//IL_065f: Expected I, but got O
		//IL_04a7: Expected I, but got O
		if (!hasInitedThisStage && MapController.index == 0)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int num = inventory.banishes ^ inventory.banishes;
			int num2 = inventory.banishes & num;
			bool flag = num2 < 0;
			bool flag2 = inventory.banishes < 0;
			bool flag3 = inventory.banishes == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			bool flag6 = flag5 & flag4;
			hasBanishes = flag6;
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int num3 = inventory2.refreshes ^ inventory2.refreshes;
			int num4 = inventory2.refreshes & num3;
			bool flag7 = num4 < 0;
			bool flag8 = inventory2.refreshes < 0;
			bool flag9 = inventory2.refreshes == 0;
			bool flag10 = flag8 == flag7;
			bool flag11 = !flag9;
			bool flag12 = flag11 & flag10;
			hasRefreshes = flag12;
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			int num5 = inventory3.skips ^ inventory3.skips;
			int num6 = inventory3.skips & num5;
			bool flag13 = num6 < 0;
			bool flag14 = inventory3.skips < 0;
			bool flag15 = inventory3.skips == 0;
			bool flag16 = flag14 == flag13;
			bool flag17 = !flag15;
			bool flag18 = flag17 & flag16;
			hasSkips = flag18;
			hasInitedThisStage = true;
		}
		window.SetActive(value: true);
		int num7 = level + 1;
		level = num7;
		GameObject gameObject;
		bool active;
		if (encounterType != EEncounter.Levelup && encounterType != EEncounter.Moai)
		{
			audioShadyGuy.Play();
			gameObject = effects;
			active = false;
		}
		else
		{
			audioLevel.Play();
			gameObject = effects;
			active = true;
		}
		gameObject.SetActive(active);
		GameObject gameObject2 = b_refresh.gameObject;
		gameObject2.SetActive(value: true);
		GameObject gameObject3 = b_skip.gameObject;
		gameObject3.SetActive(value: true);
		GameObject gameObject4 = b_banish.gameObject;
		gameObject4.SetActive(value: false);
		GameObject gameObject5 = b_leave.gameObject;
		gameObject5.SetActive(value: false);
		Component component;
		nint num9;
		if (encounterType != EEncounter.Levelup)
		{
			if (encounterType != EEncounter.Moai)
			{
				if (encounterType == EEncounter.ShadyGuy)
				{
					TextMeshProUGUI textMeshProUGUI = t_title;
					string localizedString = LocalizationUtility.GetLocalizedString("Game_Ui", "HEADER_SHADY");
					t_title.text = localizedString;
					GameObject gameObject6 = t_description.gameObject;
					gameObject6.SetActive(value: true);
					TextMeshProUGUI textMeshProUGUI2 = t_description;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172FE3]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					int num8 = UnityEngine.Random.Range(0, 14);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string key = $"SHADY_GUY_{arg}";
					string localizedString2 = LocalizationUtility.GetLocalizedString("Game_ShadyGuy", key);
					num9 = (nint)textMeshProUGUI2;
					textMeshProUGUI2.text = localizedString2;
					GameObject gameObject7 = b_refresh.gameObject;
					gameObject7.SetActive(value: false);
					GameObject gameObject8 = b_skip.gameObject;
					gameObject8.SetActive(value: false);
					component = b_leave;
					goto IL_06d1;
				}
			}
			else
			{
				TextMeshProUGUI textMeshProUGUI3 = t_title;
				string localizedString3 = LocalizationUtility.GetLocalizedString("Game_Ui", "HEADER_MOAI");
				t_title.text = localizedString3;
				int num10 = UnityEngine.Random.Range(0, 3);
				float num11 = UnityEngine.Random.Range(0f, 1f);
				bool flag19 = 0.01f < num11;
				int moaiLuckMode = num10;
				if (!flag19)
				{
					moaiLuckMode = 3;
				}
				GameObject gameObject9 = t_description.gameObject;
				gameObject9.SetActive(value: true);
				TextMeshProUGUI textMeshProUGUI4 = t_description;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172FE2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				int num12 = UnityEngine.Random.Range(0, 3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg2 = default(object);
				object arg3 = default(object);
				string key2 = $"MOAI_{arg2}_{arg3}";
				string localizedString4 = LocalizationUtility.GetLocalizedString("Game_Moai", key2);
				t_description.text = localizedString4;
				UpgradePicker upgradePicker = this.upgradePicker;
				upgradePicker.moaiLuckMode = moaiLuckMode;
				num9 = (nint)textMeshProUGUI4;
			}
			goto IL_06f6;
		}
		TextMeshProUGUI textMeshProUGUI5 = t_title;
		string localizedString5 = LocalizationUtility.GetLocalizedString("Game_Ui", "HEADER_LEVELUP");
		num9 = (nint)textMeshProUGUI5;
		textMeshProUGUI5.text = localizedString5;
		GameObject gameObject10 = t_description.gameObject;
		gameObject10.SetActive(value: false);
		component = b_banish;
		goto IL_06d1;
		IL_06d1:
		GameObject gameObject11 = component.gameObject;
		gameObject11.SetActive(value: true);
		goto IL_06f6;
		IL_06f6:
		RefreshUtilityButtons();
		this.upgradePicker.ShuffleUpgrades(encounterType);
		isLevelingUp = false;
		if (encounterType == EEncounter.Levelup)
		{
			isLevelingUp = true;
			Action a_LevelupEnabled = A_LevelupEnabled;
			if (A_LevelupEnabled != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v960.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		UpgradePicker upgradePicker2 = this.upgradePicker;
		if (upgradePicker2.numUpgrades <= 0 && encounterType != EEncounter.ShadyGuy)
		{
			CloseLevelupScreen();
		}
	}

	private void Update()
	{
		if (window.activeInHierarchy && encounterType == EEncounter.ShadyGuy && MyInputManager.GetButtonDown(MyInputManager.UICancel))
		{
			UiManager instance = UiManager.Instance;
			instance.encounterWindows.RewardFinished();
			upgradePicker.StopBanishMode();
		}
	}

	public void CloseLevelupScreen()
	{
		UiManager instance = UiManager.Instance;
		instance.encounterWindows.RewardFinished();
		upgradePicker.StopBanishMode();
	}

	public override void Open(EEncounter encounterType)
	{
		this.encounterType = encounterType;
		ShowLevelupScreen();
	}

	public override void OnClose()
	{
		isLevelingUp = false;
		window.SetActive(value: false);
		effects.SetActive(value: false);
		MyTime.Unpause();
		if (encounterType == EEncounter.Levelup)
		{
			Action a_LevelUpClose = A_LevelUpClose;
			if (A_LevelUpClose != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v145.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public override void ChooseOffer(int index)
	{
	}

	public void Leave()
	{
		UiManager instance = UiManager.Instance;
		instance.encounterWindows.RewardFinished();
		upgradePicker.StopBanishMode();
	}

	public void Skip()
	{
		//IL_007d: Invalid comparison between I4 and F4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.skips > 0)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int skipsUsed = GetSkipsUsed();
			int shopToolPrice = GetShopToolPrice(skipsUsed);
			if (!((float)shopToolPrice > inventory2._003Cgold_003Ek__BackingField))
			{
				MyPlayer instance3 = MyPlayer.Instance;
				int skipsUsed2 = GetSkipsUsed();
				int shopToolPrice2 = GetShopToolPrice(skipsUsed2);
				int amount = -shopToolPrice2;
				instance3.inventory.ChangeGold(amount);
				MyPlayer instance4 = MyPlayer.Instance;
				PlayerInventory inventory3 = instance4.inventory;
				int skips = inventory3.skips - 1;
				inventory3.skips = skips;
				MyPlayer instance5 = MyPlayer.Instance;
				PlayerInventory inventory4 = instance5.inventory;
				int skipsUsed3 = inventory4.skipsUsed + 1;
				inventory4.skipsUsed = skipsUsed3;
				CloseLevelupScreen();
			}
		}
	}

	public void Refresh()
	{
		//IL_007d: Invalid comparison between I4 and F4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.refreshes > 0)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int refreshesUsed = GetRefreshesUsed();
			int shopToolPrice = GetShopToolPrice(refreshesUsed);
			if (!((float)shopToolPrice > inventory2._003Cgold_003Ek__BackingField))
			{
				MyPlayer instance3 = MyPlayer.Instance;
				int refreshesUsed2 = GetRefreshesUsed();
				int shopToolPrice2 = GetShopToolPrice(refreshesUsed2);
				int amount = -shopToolPrice2;
				instance3.inventory.ChangeGold(amount);
				MyPlayer instance4 = MyPlayer.Instance;
				PlayerInventory inventory3 = instance4.inventory;
				int refreshes = inventory3.refreshes - 1;
				inventory3.refreshes = refreshes;
				MyPlayer instance5 = MyPlayer.Instance;
				PlayerInventory inventory4 = instance5.inventory;
				int refreshesUsed3 = inventory4.refreshesUsed + 1;
				inventory4.refreshesUsed = refreshesUsed3;
				RefreshUtilityButtons();
				upgradePicker.ShuffleUpgrades(encounterType);
			}
		}
	}

	public void StartBanish()
	{
		//IL_007d: Invalid comparison between I4 and F4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.banishes > 0)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int banishesUsed = GetBanishesUsed();
			int shopToolPrice = GetShopToolPrice(banishesUsed);
			if (!((float)shopToolPrice > inventory2._003Cgold_003Ek__BackingField))
			{
				UpgradePicker upgradePicker = this.upgradePicker;
				upgradePicker.banisModeOverlay.SetActive(value: true);
				upgradePicker._003CbanishMode_003Ek__BackingField = true;
			}
		}
	}

	public void Banish()
	{
		//IL_007d: Invalid comparison between I4 and F4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.banishes > 0)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			int banishesUsed = GetBanishesUsed();
			int shopToolPrice = GetShopToolPrice(banishesUsed);
			if (!((float)shopToolPrice > inventory2._003Cgold_003Ek__BackingField))
			{
				MyPlayer instance3 = MyPlayer.Instance;
				int banishesUsed2 = GetBanishesUsed();
				int shopToolPrice2 = GetShopToolPrice(banishesUsed2);
				int amount = -shopToolPrice2;
				instance3.inventory.ChangeGold(amount);
				DecrementBanishes();
				upgradePicker.StopBanishMode();
				CloseLevelupScreen();
			}
		}
	}

	private int GetSkips()
	{
		//IL_004c: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				return inventory.skips;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int GetRefreshes()
	{
		//IL_004c: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				return inventory.refreshes;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetBanishes()
	{
		//IL_004c: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				return inventory.banishes;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int GetSkipsUsed()
	{
		//IL_004c: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				return inventory.skipsUsed;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private int GetRefreshesUsed()
	{
		//IL_004c: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				return inventory.refreshesUsed;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetBanishesUsed()
	{
		//IL_004c: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				return inventory.banishesUsed;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void DecrementBanishes()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int banishes = inventory.banishes - 1;
		inventory.banishes = banishes;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		int banishesUsed = inventory2.banishesUsed + 1;
		inventory2.banishesUsed = banishesUsed;
	}

	private void RefreshUtilityButtons()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.banishes > 0)
		{
			hasBanishes = true;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		if (inventory2.skips > 0)
		{
			hasSkips = true;
		}
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerInventory inventory3 = instance3.inventory;
		if (inventory3.refreshes > 0)
		{
			hasRefreshes = true;
		}
		if (!hasSkips)
		{
			GameObject gameObject = b_skip.gameObject;
			gameObject.SetActive(value: false);
		}
		if (!hasBanishes)
		{
			GameObject gameObject2 = b_banish.gameObject;
			gameObject2.SetActive(value: false);
		}
		if (!hasRefreshes)
		{
			GameObject gameObject3 = b_refresh.gameObject;
			gameObject3.SetActive(value: false);
		}
		MyPlayer instance4 = MyPlayer.Instance;
		PlayerInventory inventory4 = instance4.inventory;
		MyPlayer instance5 = MyPlayer.Instance;
		PlayerInventory inventory5 = instance5.inventory;
		int shopToolPrice = GetShopToolPrice(inventory5.skipsUsed);
		b_skip.SetAmount(inventory4.skips, shopToolPrice);
		MyPlayer instance6 = MyPlayer.Instance;
		PlayerInventory inventory6 = instance6.inventory;
		MyPlayer instance7 = MyPlayer.Instance;
		PlayerInventory inventory7 = instance7.inventory;
		int shopToolPrice2 = GetShopToolPrice(inventory7.refreshesUsed);
		b_refresh.SetAmount(inventory6.refreshes, shopToolPrice2);
		MyPlayer instance8 = MyPlayer.Instance;
		PlayerInventory inventory8 = instance8.inventory;
		MyPlayer instance9 = MyPlayer.Instance;
		PlayerInventory inventory9 = instance9.inventory;
		int shopToolPrice3 = GetShopToolPrice(inventory9.banishesUsed);
		b_banish.SetAmount(inventory8.banishes, shopToolPrice3);
	}

	public int GetShopToolPrice(int numUses)
	{
		//IL_002b: Expected O, but got I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0202: Expected I, but got O
		//IL_01ee: Expected I4, but got F8
		//IL_0199: Expected O, but got I4
		//IL_01b0: Expected F8, but got I4
		//IL_0145: Expected I4, but got F8
		//IL_010c: Expected F8, but got I4
		if (numUses != 0)
		{
			object obj = numUses - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
			object obj2 = obj * 15;
			float num = 2f * 5f;
			float num2 = num + (float)obj2;
			nint num3 = (nint)typeof(Math);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v2 (Il2CppClass<System.Math>)+E4]");
			int num6 = default(int);
			double num7;
			if ((nint)0 >= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018054EEEBh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v2 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
					double num4 = Math.Floor(num2);
					return (int)num4;
				}
				int num5 = num6 & 1;
				bool flag = num5 == 0;
				num7 = num6;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [18262EC98h]\"");
					return num6;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018054EF3Bh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v2 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 == 0)
				{
					object obj3 = num6 & 1;
					bool flag2 = obj3 == null;
					num7 = num6;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [18262EC98h]\"");
						return num6;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
					num7 = Math.Ceiling(num2);
				}
			}
			return (int)num7;
		}
		return 0;
	}

	private string GetMoaiText(int level)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172FE2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int num = UnityEngine.Random.Range(0, 3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string key = $"MOAI_{arg}_{arg2}";
		return LocalizationUtility.GetLocalizedString("Game_Moai", key);
	}

	private string GetShadyGuyText()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172FE3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = UnityEngine.Random.Range(0, 14);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string key = $"SHADY_GUY_{arg}";
		return LocalizationUtility.GetLocalizedString("Game_ShadyGuy", key);
	}
}
