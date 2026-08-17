using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.UI.Menu.Windows;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{
	public UpgradeButton[] buttons;

	public LevelupScreen levelupScreen;

	private int numUpgrades;

	public TabsExplicitNavigation tabsExplicitNavigation;

	private EEncounter encounterType;

	public GameObject window;

	private float openedAtTime;

	public static Action A_ShadyGuyDone;

	private int moaiLuckMode;

	public GameObject banisModeOverlay;

	private bool _003CbanishMode_003Ek__BackingField;

	public float banishCooldownOverAtTime;

	public bool banishMode
	{
		get
		{
			return _003CbanishMode_003Ek__BackingField;
		}
		private set
		{
			_003CbanishMode_003Ek__BackingField = value;
		}
	}

	public void ShuffleUpgrades(EEncounter encounterType)
	{
		//IL_000e: Expected F4, but got I4
		//IL_0017: Expected F4, but got I4
		//IL_04ca: Invalid comparison between F4 and I4
		//IL_03c1: Expected F4, but got I4
		//IL_058d: Invalid comparison between F4 and I4
		//IL_02be: Expected F4, but got I4
		//IL_0469: Expected F4, but got I4
		//IL_055b: Invalid comparison between F4 and I4
		//IL_00e9: Expected F4, but got I4
		//IL_0537: Invalid comparison between F4 and I4
		//IL_0366: Expected F4, but got I4
		//IL_019b: Invalid comparison between F4 and I4
		//IL_0256: Expected F4, but got I4
		banishCooldownOverAtTime = 0f;
		float time = Time.time;
		UpgradeButton[] array = buttons;
		openedAtTime = time;
		this.encounterType = encounterType;
		numUpgrades = 0;
		float num = 0f;
		for (float num2 = 0f; num2 < (float)array.Length; num2 = num)
		{
			GameObject gameObject = array[num].gameObject;
			gameObject.SetActive(value: false);
			num++;
		}
		if (encounterType != EEncounter.Levelup)
		{
			if (encounterType != EEncounter.Moai)
			{
				if (encounterType == EEncounter.ShadyGuy)
				{
					InteractableShadyGuy currentlyInteracting = InteractableShadyGuy.currentlyInteracting;
					InteractableShadyGuy currentlyInteracting2 = InteractableShadyGuy.currentlyInteracting;
					List<ItemData> items = currentlyInteracting.items;
					int num3 = 0;
					object arg = default(object);
					for (float num4 = 0f; num4 < (float)items._size; num4 = num3)
					{
						UpgradeButton[] array2 = buttons;
						GameObject gameObject2 = array2[num3].gameObject;
						gameObject2.SetActive(value: true);
						UpgradeButton[] array3 = buttons;
						UpgradeButton upgradeButton = array3[num3];
						ItemData item = items.get_Item(num3);
						int num5 = currentlyInteracting2.prices.get_Item(num3);
						upgradeButton.canAfford = true;
						upgradeButton.SetItem(item);
						upgradeButton.price = num5;
						MyPlayer instance = MyPlayer.Instance;
						PlayerInventory inventory = instance.inventory;
						bool flag = inventory._003Cgold_003Ek__BackingField < (float)num5;
						bool active = (byte)(((upgradeButton.canAfford = !flag) ? 1u : 0u) ^ 1u) != 0;
						upgradeButton.overlayCantAfford.SetActive(active);
						TextMeshProUGUI t_level = upgradeButton.t_level;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
						string text = $"<color=white><sprite name=gold> {arg:N0}";
						t_level.text = text;
						int num6 = numUpgrades + 1;
						numUpgrades = num6;
						num3++;
						int num7 = num5;
					}
				}
			}
			else
			{
				List<ItemData> randomItemsMoai = InventoryUtility.GetRandomItemsMoai(moaiLuckMode);
				if (randomItemsMoai == null || randomItemsMoai._size <= 0)
				{
					LevelupScreen levelupScreen = this.levelupScreen;
					UiManager instance2 = UiManager.Instance;
					instance2.encounterWindows.RewardFinished();
					levelupScreen.upgradePicker.StopBanishMode();
					return;
				}
				int num8 = 0;
				for (float num9 = 0f; num9 < (float)randomItemsMoai._size; num9 = num8)
				{
					UpgradeButton[] array4 = buttons;
					GameObject gameObject3 = array4[num8].gameObject;
					gameObject3.SetActive(value: true);
					UpgradeButton[] array5 = buttons;
					ItemData item2 = randomItemsMoai.get_Item(num8);
					array5[num8].SetItem(item2);
					int num10 = numUpgrades + 1;
					numUpgrades = num10;
					num8++;
				}
			}
		}
		else
		{
			List<IUpgradable> randomUpgrades = InventoryUtility.GetRandomUpgrades();
			int num11 = 0;
			for (float num12 = 0f; num12 < (float)randomUpgrades._size; num12 = num11)
			{
				UpgradeButton[] array6 = buttons;
				GameObject gameObject4 = array6[num11].gameObject;
				gameObject4.SetActive(value: true);
				UpgradeButton[] array7 = buttons;
				IUpgradable upgrade = randomUpgrades.get_Item(num11);
				array7[num11].SetUpgrade(upgrade);
				int num13 = numUpgrades + 1;
				numUpgrades = num13;
				num11++;
			}
		}
		tabsExplicitNavigation.Refresh();
	}

	public void SetMoaiLuck(int luckMode)
	{
		moaiLuckMode = luckMode;
	}

	private void KeyboardInput()
	{
		//IL_0021: Expected O, but got I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_00a5: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0177: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_01a1: Expected O, but got I4
		bool activeInHierarchy = window.activeInHierarchy;
		object obj = activeInHierarchy ^ activeInHierarchy;
		object obj2 = activeInHierarchy & obj;
		bool flag = (nint)obj2 < 0;
		bool flag2 = (activeInHierarchy ? 1 : 0) < (false ? 1 : 0);
		bool flag3 = !activeInHierarchy;
		if (flag3)
		{
			return;
		}
		float time = Time.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [18262F138h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
		bool flag4 = flag2 == flag;
		object obj3 = !flag3;
		object obj4 = flag4 & obj3;
		if (obj4 != null)
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFControlSettings cfControlSettings = config.cfControlSettings;
		if (cfControlSettings.select_upgrades_with_number_keys != 1)
		{
			return;
		}
		bool keyDownInt = Input.GetKeyDownInt(KeyCode.Alpha1);
		object obj5 = ((!Input.GetKeyDownInt(KeyCode.Alpha2)) ? ((object)((keyDownInt ? 1 : 0) - 1)) : ((object)1));
		if (Input.GetKeyDownInt(KeyCode.Alpha3))
		{
			obj5 = 2;
		}
		if (Input.GetKeyDownInt(KeyCode.Alpha4))
		{
			obj5 = 3;
		}
		if (Input.GetKeyDownInt(KeyCode.Alpha5))
		{
			obj5 = 4;
		}
		else if ((nint)obj5 == -1)
		{
			return;
		}
		UpgradeButton[] array = buttons;
		if (array.Length > (nint)obj5)
		{
			GameObject gameObject = array[obj5].gameObject;
			if (gameObject.activeSelf)
			{
				UpgradeButton[] array2 = buttons;
				array2[obj5].SelectUpgrade();
			}
		}
	}

	public unsafe void SelectUpgrade(IUpgradable upgradable, List<StatModifier> upgradeOffer, UpgradeButton btn, ERarity rarity)
	{
		//IL_015a: Expected I, but got O
		//IL_0172: Expected O, but got I
		//IL_0071: Expected O, but got I4
		//IL_01c4: Expected O, but got I
		//IL_04f7: Expected O, but got I4
		//IL_0478: Expected O, but got Ref
		//IL_0478: Expected O, but got Ref
		//IL_00a0: Expected O, but got I4
		//IL_00db: Expected O, but got I4
		//IL_00fa: Expected O, but got I
		//IL_02bf: Expected I, but got O
		//IL_02d7: Expected O, but got I
		if (_003CbanishMode_003Ek__BackingField)
		{
			bool flag = upgradable == null;
			IUpgradable upgradable2 = upgradable;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				object obj = default(object);
				UpgradeButton upgradeButton = default(UpgradeButton);
				List<StatModifier> list;
				if ((nint)obj <= 0)
				{
					nint num = (nint)typeof(UnlockableBase);
					list = (List<StatModifier>)upgradable;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v11 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ r8_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>)+130]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v11 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
					bool flag2 = num2 < 0;
					List<StatModifier> typeFromHandle = (List<StatModifier>)(object)typeof(UnlockableBase);
					upgradable2 = upgradable;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ r8_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier>)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v19+FFFFFFF8+v379 @ rax_v18*8]");
						bool flag3 = 0 != (nint)typeof(UnlockableBase);
						typeFromHandle = (List<StatModifier>)(object)typeof(UnlockableBase);
						upgradable2 = upgradable;
						if (!flag3)
						{
							RunUnlockables.BanishUpgradable((UnlockableBase)upgradable);
							bool flag4 = (object)upgradeButton == null;
							upgradable2 = upgradable;
							if (!flag4)
							{
								GameObject gameObject = upgradeButton.gameObject;
								bool flag5 = (object)gameObject == null;
								upgradable2 = upgradable;
								if (!flag5)
								{
									gameObject.SetActive(value: false);
									bool flag6 = (object)levelupScreen == null;
									list = null;
									upgradable2 = upgradable;
									if (!flag6)
									{
										levelupScreen.Banish();
										bool flag7 = (object)EffectManager.Instance == null;
										list = null;
										upgradable2 = upgradable;
										if (!flag7)
										{
											nint num3 = (nint)typeof(UnlockableBase);
											upgradeButton = (UpgradeButton)upgradable;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r8_v10 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ r9_v2 (UpgradeButton)+130]");
											nint num4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r8_v10 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
											bool flag8 = num4 < 0;
											list = (List<StatModifier>)(object)typeof(UnlockableBase);
											upgradable2 = upgradable;
											if (!flag8)
											{
												bool isItem = upgradeButton.isItem;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v28 (System.Boolean)+FFFFFFF8+v333 @ rax_v27*8]");
												bool flag9 = 0 != (nint)typeof(UnlockableBase);
												list = (List<StatModifier>)(object)typeof(UnlockableBase);
												upgradable2 = upgradable;
												if (!flag9)
												{
													EffectManager.Instance.BanishItem((UnlockableBase)upgradable);
													return;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
											typeFromHandle = list;
											goto IL_0505;
										}
									}
								}
							}
							goto IL_0479;
						}
					}
					goto IL_0505;
				}
				StopBanishMode();
				AlwaysUi instance = AlwaysUi.Instance;
				bool flag10 = (object)AlwaysUi.Instance == null;
				list = (List<StatModifier>)upgradable;
				upgradable2 = upgradable;
				if (!flag10)
				{
					upgradable2 = (IUpgradable)instance.UiTextPopup;
					string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_BANISH");
					bool flag11 = (object)upgradeButton == null;
					list = null;
					if (!flag11)
					{
						Transform transform = upgradeButton.transform;
						bool flag12 = (object)transform == null;
						list = null;
						if (!flag12)
						{
							Vector3 position = transform.position;
							bool flag13 = (object)instance.UiTextPopup == null;
							list = null;
							if (!flag13)
							{
								object obj5 = default(object);
								object obj6 = default(object);
								float desiredScale = default(float);
								instance.UiTextPopup.SetText(localizedString, (Vector3)(&obj5), (Color)(&obj6), desiredScale);
								return;
							}
						}
					}
				}
			}
		}
		else
		{
			MyPlayer instance2 = MyPlayer.Instance;
			bool flag14 = (object)MyPlayer.Instance == null;
			IUpgradable upgradable2 = upgradable;
			if (!flag14)
			{
				bool flag15 = instance2.inventory == null;
				upgradable2 = upgradable;
				if (!flag15)
				{
					List<StatModifier> list = default(List<StatModifier>);
					ERarity eRarity = default(ERarity);
					instance2.inventory.AddUpgrade(upgradable, list, eRarity);
					upgradable2 = (IUpgradable)levelupScreen;
					bool flag16 = (object)levelupScreen == null;
					UpgradeButton upgradeButton = (UpgradeButton)eRarity;
					if (!flag16)
					{
						UiManager instance3 = UiManager.Instance;
						bool flag17 = (object)UiManager.Instance == null;
						upgradeButton = (UpgradeButton)eRarity;
						if (!flag17)
						{
							bool flag18 = (object)instance3.encounterWindows == null;
							upgradeButton = (UpgradeButton)eRarity;
							if (!flag18)
							{
								instance3.encounterWindows.RewardFinished();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbx_v3 (Assets.Scripts._Data.IUpgradable)+48]");
								bool flag19 = (nint)0 == 0;
								upgradeButton = (UpgradeButton)eRarity;
								if (!flag19)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbx_v3 (Assets.Scripts._Data.IUpgradable)+48]");
									((UpgradePicker)0).StopBanishMode();
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0479;
		IL_0505:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0479:
		throw new NullReferenceException();
	}

	public unsafe static void AutoSelectUpgrade()
	{
		//IL_00c9: Expected O, but got Ref
		//IL_0210: Expected O, but got I
		//IL_0162: Expected O, but got F4
		//IL_016c: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_02a0: Expected O, but got Ref
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0370: Expected O, but got I4
		List<IUpgradable> randomUpgrades = InventoryUtility.GetRandomUpgrades();
		bool flag = randomUpgrades == null;
		List<IUpgradable> list = null;
		if (!flag)
		{
			if (randomUpgrades._size <= 0)
			{
				return;
			}
			IUpgradable upgradable = randomUpgrades.get_Item(0);
			bool flag2 = upgradable == null;
			list = randomUpgrades;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
				List<ERarity> list2 = new List<ERarity>();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator = enumerator2;
				ERarity eRarity = ERarity.New;
				List<StatModifier> list3 = default(List<StatModifier>);
				List<StatModifier> upgradeOffer = list3;
				IUpgradable upgradable2 = upgradable;
				List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
				IUpgradable upgradable3 = default(IUpgradable);
				List<StatModifier> list4 = default(List<StatModifier>);
				while (enumerator3.MoveNext())
				{
					bool flag3 = upgradable3 == null;
					List<object>.Enumerator enumerator4 = (List<object>.Enumerator)(&enumerator3);
					if (!flag3)
					{
						int level = upgradable3.GetLevel();
						ERarity eRarity2;
						if (level <= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
							eRarity2 = ERarity.New;
							list = (List<IUpgradable>)5;
						}
						else
						{
							float stat = PlayerStats.GetStat(EStat.Luck);
							ERarity upgradeOfferRarity = Rarity.GetUpgradeOfferRarity(stat);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
							eRarity2 = upgradeOfferRarity;
							enumerator = (List<object>.Enumerator)stat;
							list = (List<IUpgradable>)5;
						}
						if (eRarity2 > eRarity)
						{
							eRarity = eRarity2;
							upgradeOffer = list4;
							upgradable2 = upgradable3;
						}
						if (list2 != null)
						{
							list2.Add(eRarity2);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				((List<IUpgradable>.Enumerator*)(&enumerator3))->Dispose();
				list = (List<IUpgradable>)(object)MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v3 (System.Collections.Generic.List`1<Assets.Scripts._Data.IUpgradable>)+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v3 (System.Collections.Generic.List`1<Assets.Scripts._Data.IUpgradable>)+90]");
						((PlayerInventory)0).AddUpgrade(upgradable2, upgradeOffer, eRarity);
						UiManager instance = UiManager.Instance;
						if ((object)UiManager.Instance != null)
						{
							string[] array = new string[5];
							bool flag4 = array == null;
							list = (List<IUpgradable>)(object)typeof(string[]);
							if (!flag4)
							{
								array[0] = "<color=#";
								Color color = MyColorUtility.RarityToColor(eRarity);
								float num = default(float);
								string text = MyColorUtility.ColorToHex((Color)(&num));
								array[1] = text;
								array[2] = ">";
								list = (List<IUpgradable>)(array + 48);
								if (upgradable2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									object obj = default(object);
									array[3] = (string)obj;
									array[4] = "+</color>";
									string text2 = string.Concat(array);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									bool flag5 = (object)instance.feed == null;
									list = (List<IUpgradable>)2;
									if (!flag5)
									{
										Texture icon = default(Texture);
										instance.feed.SetFeed(text2, 3f, icon);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SelectItem(ItemData itemData)
	{
		if (!_003CbanishMode_003Ek__BackingField)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			inventory.itemInventory.AddItem(itemData.eItem);
			if (encounterType == EEncounter.ShadyGuy)
			{
				Action a_ShadyGuyDone = A_ShadyGuyDone;
				if (A_ShadyGuyDone != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v275.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
			LevelupScreen levelupScreen = this.levelupScreen;
			UiManager instance2 = UiManager.Instance;
			instance2.encounterWindows.RewardFinished();
			levelupScreen.upgradePicker.StopBanishMode();
		}
		else
		{
			RunUnlockables.BanishItem(itemData);
			this.levelupScreen.Banish();
			EffectManager.Instance.BanishItem(itemData);
		}
	}

	public int GetNumUpgrades()
	{
		return numUpgrades;
	}

	public void StartBanishMode()
	{
		banisModeOverlay.SetActive(value: true);
		_003CbanishMode_003Ek__BackingField = true;
	}

	private void Banish()
	{
		levelupScreen.Banish();
	}

	public void StopBanishMode()
	{
		//IL_005b: Expected O, but got I4
		//IL_0064: Expected O, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		float time = Time.time;
		float num = time + 0.5f;
		banishCooldownOverAtTime = num;
		banisModeOverlay.SetActive(value: false);
		_003CbanishMode_003Ek__BackingField = false;
		UpgradeButton[] array = buttons;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			UpgradeButton upgradeButton = array[obj];
			upgradeButton.banishOverlay.SetActive(value: false);
			obj++;
			obj2 = obj;
		}
	}

	private void Update()
	{
		KeyboardInput();
		if (_003CbanishMode_003Ek__BackingField && MyInputManager.GetButtonDown(MyInputManager.UICancel))
		{
			StopBanishMode();
		}
	}
}
