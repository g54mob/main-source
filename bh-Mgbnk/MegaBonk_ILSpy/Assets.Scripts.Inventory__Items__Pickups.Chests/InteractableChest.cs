using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Device;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Chests;

public class InteractableChest : BaseInteractable
{
	public EChest chestType;

	private float rotation = 10f;

	public Transform icon;

	public static Action A_ChestBought;

	public static Action A_ChestOpened;

	private bool opening;

	private bool isHoveringAndCantAfford;

	public bool isInCrypt;

	public bool isShownInDebug = true;

	public static string debugName = "Chests";

	public static string debugNameCrypt = "Crypt Chests";

	private void Awake()
	{
		//IL_0124: Expected I, but got O
		Action b = OnChestWindowClose;
		Delegate obj = Delegate.Combine(ChestWindowUi.A_Close, b);
		if ((object)obj == null)
		{
			ChestWindowUi.A_Close = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			ChestWindowUi.A_Close = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_012a: Expected I, but got O
		base.OnDestroy();
		Action value = OnChestWindowClose;
		Delegate obj = Delegate.Remove(ChestWindowUi.A_Close, value);
		if ((object)obj == null)
		{
			ChestWindowUi.A_Close = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			ChestWindowUi.A_Close = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new unsafe void Start()
	{
		//IL_00a1: Expected O, but got Ref
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected F4, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected F4, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected F4, but got Unknown
		//IL_014a: Expected O, but got Ref
		//IL_018b: Expected O, but got Ref
		//IL_0170: Expected O, but got Ref
		base.Start();
		if (ChallengesTracker.HasChallengeModifier("no_items"))
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
		if (chestType != EChest.FreeCrypt)
		{
			Transform transform = base.transform;
			int num = UnityEngine.Random.Range(0, 360);
			float num2 = default(float);
			transform.Rotate((Vector3)(&num2), Space.Self);
			Transform transform2 = base.transform;
			float num3 = rotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			float minInclusive = num3 ^ 0;
			float num4 = UnityEngine.Random.Range(minInclusive, rotation);
			float num5 = rotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			float minInclusive2 = num5 ^ 0;
			float num6 = UnityEngine.Random.Range(minInclusive2, rotation);
			float num7 = rotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			float minInclusive3 = num7 ^ 0;
			float num8 = UnityEngine.Random.Range(minInclusive3, rotation);
			transform2.Rotate((Vector3)(&num2), Space.Self);
			Transform transform3 = icon.transform;
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num2));
			Vector3 vector = default(Vector3);
			transform3.rotation = (Quaternion)(&vector);
		}
	}

	public unsafe override bool Interact()
	{
		//IL_0285: Expected I4, but got O
		//IL_0269: Expected O, but got Ref
		//IL_0269: Expected O, but got Ref
		if (CanAfford())
		{
			opening = true;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
			{
				ConfigSaveFile config = saveManager.config;
				if (saveManager.config != null)
				{
					CFGameSettings cfGameSettings = config.cfGameSettings;
					if (config.cfGameSettings != null)
					{
						if (cfGameSettings.skip_chest_animation == 1)
						{
							ChestUtility.OpenChestNoAnimation(chestType);
							OnChestWindowClose();
							goto IL_0146;
						}
						UiManager instance = UiManager.Instance;
						if ((object)UiManager.Instance != null)
						{
							EEncounter rewardWindowType = ChestUtility.ChestTypeToEncounter(chestType);
							if ((object)instance.encounterWindows != null)
							{
								instance.encounterWindows.AddEncounter(rewardWindowType);
								goto IL_0146;
							}
						}
					}
				}
			}
		}
		else
		{
			AlwaysUi instance2 = AlwaysUi.Instance;
			if ((object)AlwaysUi.Instance != null)
			{
				string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "CANT_AFFORD");
				int width = UnityEngine.Device.Screen.width;
				int height = UnityEngine.Device.Screen.height;
				if ((object)instance2.UiTextPopup != null)
				{
					object obj = default(object);
					object obj2 = default(object);
					float desiredScale = default(float);
					instance2.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0146:
		if (chestType != EChest.Free && chestType != EChest.FreeCrypt)
		{
			Action a_ChestBought = A_ChestBought;
			if (A_ChestBought != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v406.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		Action a_ChestOpened = A_ChestOpened;
		if (A_ChestOpened != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v458.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return true;
	}

	private void OpenChestImplementation()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		if (cfGameSettings.skip_chest_animation != 1)
		{
			UiManager instance = UiManager.Instance;
			EEncounter rewardWindowType = ChestUtility.ChestTypeToEncounter(chestType);
			instance.encounterWindows.AddEncounter(rewardWindowType);
		}
		else
		{
			ChestUtility.OpenChestNoAnimation(chestType);
			OnChestWindowClose();
		}
	}

	private unsafe void OnChestWindowClose()
	{
		//IL_03b8: Expected O, but got I4
		//IL_03c1: Expected O, but got I4
		//IL_01a7: Expected I, but got O
		//IL_01af: Expected I, but got O
		//IL_01bf: Expected O, but got I
		//IL_01eb: Expected I, but got O
		//IL_0211: Expected O, but got I
		//IL_023e: Expected I, but got O
		//IL_04f8: Expected I, but got O
		//IL_0294: Expected O, but got I
		//IL_02aa: Expected I, but got O
		//IL_052d: Expected I, but got O
		//IL_02e4: Expected I, but got O
		//IL_031a: Expected O, but got Ref
		//IL_031a: Expected O, but got Ref
		//IL_0327: Expected O, but got I4
		//IL_0337: Expected O, but got I
		//IL_0345: Expected O, but got Ref
		if (!opening)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		nint num2 = default(nint);
		NullReferenceException ex;
		object obj7;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				ItemInventory itemInventory = inventory.itemInventory;
				if (inventory.itemInventory != null && itemInventory.items != null)
				{
					bool flag = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)0);
					bool flag2 = !flag;
					IntPtr intPtr = default(IntPtr);
					nint num = intPtr;
					num2 = 0;
					if (flag2)
					{
						goto IL_0540;
					}
					MyPlayer instance2 = MyPlayer.Instance;
					bool flag3 = (object)MyPlayer.Instance == null;
					num2 = 0;
					if (!flag3)
					{
						PlayerInventory inventory2 = instance2.inventory;
						bool flag4 = instance2.inventory == null;
						num2 = 0;
						if (!flag4)
						{
							ItemInventory itemInventory2 = inventory2.itemInventory;
							bool flag5 = inventory2.itemInventory == null;
							num2 = 0;
							if (!flag5)
							{
								bool flag6 = itemInventory2.items == null;
								num2 = 0;
								if (!flag6)
								{
									object obj = ((Dictionary<System.Int32Enum, object>)(object)itemInventory2.items).get_Item((System.Int32Enum)0);
									bool flag7 = obj == null;
									num2 = 0;
									if (!flag7)
									{
										nint num3 = (nint)typeof(ItemKey);
										nint num4 = (nint)obj;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r8_v9 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemKey>)+130]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v6 (Il2CppClass<System.Object>)+130]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r8_v9 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemKey>)+130]");
										bool flag8 = num5 < 0;
										num2 = (nint)typeof(ItemKey);
										ex = (NullReferenceException)obj;
										if (!flag8)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v6 (Il2CppClass<System.Object>)+C8]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rcx_v38+FFFFFFF8+v426 @ rcx_v37*8]");
											bool flag9 = 0 != (nint)typeof(ItemKey);
											num2 = (nint)typeof(ItemKey);
											ex = (NullReferenceException)obj;
											if (!flag9)
											{
												bool flag10 = MyRandom.random == null;
												num2 = (nint)typeof(ItemKey);
												if (!flag10)
												{
													double num6 = MyRandom.random.NextDouble();
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
													bool flag11 = (nint)MyRandom.random <= 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v49 (System.Object)+34]");
													object obj4 = 0;
													num = num4;
													num2 = (nint)typeof(ItemKey);
													if (flag11)
													{
														goto IL_0540;
													}
													EffectManager instance3 = EffectManager.Instance;
													bool flag12 = (object)EffectManager.Instance == null;
													num2 = (nint)typeof(ItemKey);
													if (!flag12)
													{
														Transform transform = base.transform;
														bool flag13 = (object)transform == null;
														num2 = (nint)typeof(ItemKey);
														if (!flag13)
														{
															Vector3 position = transform.position;
															object obj5 = default(object);
															object obj6 = default(object);
															GameObject gameObject = UnityEngine.Object.Instantiate(instance3.wuiFreeChest, (Vector3)(&obj5), (Quaternion)(&obj6));
															obj7 = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v49 (System.Object)+34]");
															obj4 = 0;
															num = 0;
															Quaternion quaternion = (Quaternion)(&obj6);
															goto IL_03c6;
														}
													}
												}
												goto IL_0446;
											}
										}
										goto IL_04c8;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0446;
		IL_04c8:
		bool flag14 = ((Dictionary<EItem, ItemBase>)(object)ex).ContainsKey((EItem)num2);
		return;
		IL_0446:
		ex = new NullReferenceException();
		goto IL_04c8;
		IL_0540:
		MyPlayer instance4 = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			int num7 = ((chestType != EChest.Free && chestType != EChest.FreeCrypt) ? MoneyUtility.GetChestPrice() : 0);
			if (instance4.inventory != null)
			{
				int amount = -num7;
				instance4.inventory.ChangeGold(amount);
				obj7 = 0;
				Quaternion quaternion = (Quaternion)0;
				goto IL_03c6;
			}
		}
		goto IL_0446;
		IL_03c6:
		if (chestType != EChest.Free && chestType != EChest.FreeCrypt && obj7 == null)
		{
			int chestsPurchased = MoneyUtility.chestsPurchased + 1;
			MoneyUtility.chestsPurchased = chestsPurchased;
			Action a_ChestPriceIncreased = MoneyUtility.A_ChestPriceIncreased;
			if (MoneyUtility.A_ChestPriceIncreased != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v665.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		GameObject obj8 = base.gameObject;
		UnityEngine.Object.Destroy(obj8);
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317295D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!CanAfford())
		{
			if (chestType != EChest.Free && chestType != EChest.FreeCrypt)
			{
				int chestPrice = MoneyUtility.GetChestPrice();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			return $"<color=red>{arg}<sprite name=gold></color>";
		}
		if (chestType != EChest.Free && chestType != EChest.FreeCrypt)
		{
			int chestPrice2 = MoneyUtility.GetChestPrice();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg2 = default(object);
		return $"{arg2}<sprite name=gold></color>";
	}

	private void FixedUpdate()
	{
		if (detectInteractables != null)
		{
			if (!CanAfford())
			{
				isHoveringAndCantAfford = true;
			}
			if (isHoveringAndCantAfford && CanAfford())
			{
				isHoveringAndCantAfford = false;
				RefreshInteractable();
			}
		}
	}

	public unsafe override Color GetColor()
	{
		//IL_0048: Expected F4, but got O
		//IL_0043: Expected native int or pointer, but got O
		//IL_0035: Expected F4, but got O
		//IL_0030: Expected native int or pointer, but got O
		Color color = default(Color);
		if (!CanAfford())
		{
			((Color*)(nint)color)->r = (float)MyColorUtility.interactDisabledOutlineColor;
			return color;
		}
		((Color*)(nint)color)->r = (float)MyColorUtility.interactOutlineColor;
		return color;
	}

	private int GetPrice()
	{
		if (chestType != EChest.Free && chestType != EChest.FreeCrypt)
		{
			return MoneyUtility.GetChestPrice();
		}
		return 0;
	}

	private bool CanAfford()
	{
		//IL_0087: Expected I4, but got O
		//IL_00b8: Invalid comparison between F4 and I4
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				int num = ((chestType != EChest.Free && chestType != EChest.FreeCrypt) ? MoneyUtility.GetChestPrice() : 0);
				bool flag = inventory._003Cgold_003Ek__BackingField < (float)num;
				return !flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool ShowInDebug()
	{
		bool flag = !isShownInDebug;
		return !flag;
	}

	public override string GetDebugName()
	{
		if (!isInCrypt)
		{
			return debugName;
		}
		return debugNameCrypt;
	}

	private void OnDisable()
	{
		if (ShowInDebug() && !opening)
		{
			Action<string> a_DebugDisable = BaseInteractable.A_DebugDisable;
			if (BaseInteractable.A_DebugDisable != null)
			{
				string text = GetDebugName();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v90 @ rdi_v2 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public override bool CanInteract()
	{
		if (!ChallengesTracker.HasChallengeModifier("no_items"))
		{
			return base.CanInteract();
		}
		return false;
	}
}
