using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemPrefabUI : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_level;

	public GameObject lockedOverlay;

	public ToolTipObject toolTipObject;

	private UnlockableBase item;

	public GameObject banishedIcon;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<WeaponBase> b = OnWeaponToggled;
		Delegate obj = Delegate.Combine(WeaponInventory.A_WeaponToggled, b);
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponToggled = (Action<WeaponBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<WeaponBase> action = default(Action<WeaponBase>);
		if (action != null)
		{
			WeaponInventory.A_WeaponToggled = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<WeaponBase>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<WeaponBase>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<WeaponBase> value = OnWeaponToggled;
		Delegate obj = Delegate.Remove(WeaponInventory.A_WeaponToggled, value);
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponToggled = (Action<WeaponBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<WeaponBase> action = default(Action<WeaponBase>);
		if (action != null)
		{
			WeaponInventory.A_WeaponToggled = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<WeaponBase>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<WeaponBase>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnWeaponToggled(WeaponBase weaponBase)
	{
		if (weaponBase.weaponData == item)
		{
			RefreshEnabled(weaponBase._003Cenabled_003Ek__BackingField);
		}
	}

	public unsafe void SetBanished()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		//IL_0058: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rax_v3+B8]");
		object text = 0;
		t_level.text = (string)text;
		banishedIcon.SetActive(value: true);
		object obj2 = default(object);
		icon.color = (Color)(&obj2);
	}

	public unsafe void SetItem(UnlockableBase item)
	{
		//IL_007c: Expected O, but got Ref
		//IL_022c: Expected I, but got O
		//IL_0234: Expected I, but got O
		//IL_0244: Expected O, but got I
		//IL_0280: Expected O, but got I
		this.item = item;
		lockedOverlay.SetActive(value: false);
		if (banishedIcon != null)
		{
			banishedIcon.SetActive(value: false);
		}
		icon.enabled = true;
		object obj = default(object);
		icon.color = (Color)(&obj);
		if (item != null)
		{
			icon.enabled = true;
			Texture texture = item.GetIcon();
			icon.texture = texture;
			int level = GetLevel(item);
			string text;
			if (level <= 99)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				int level2 = GetLevel(item);
				int num = default(int);
				string value = num.ToString();
				((Dictionary<object, object>)(object)dictionary).Add((object)"level", (object)value);
				text = LocalizationUtility.GetLocalizedString("Game_HUD", "LEVEL", dictionary);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				text = $"{arg}";
			}
			t_level.text = text;
			if (this.toolTipObject != null)
			{
				ToolTipObject toolTipObject = this.toolTipObject;
				string text2 = item.GetName();
				string description = item.GetDescription();
				string text3 = "<size=120%>" + text2 + ":</size> " + description;
				toolTipObject.text = text3;
			}
			nint num2 = (nint)typeof(WeaponData);
			nint num3 = (nint)item;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v20 (Il2CppClass<WeaponData>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v17 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v20 (Il2CppClass<WeaponData>)+130]");
			if (num4 < 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v17 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rax_v31+FFFFFFF8+v642 @ rax_v29*8]");
			if (0 == (nint)typeof(WeaponData))
			{
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				WeaponInventory weaponInventory = inventory.weaponInventory;
				Dictionary<EWeapon, WeaponBase> weapons = weaponInventory.weapons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [item @ rdx (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+50]");
				bool isEnabled;
				if (!((Dictionary<System.Int32Enum, object>)(object)weapons).ContainsKey((System.Int32Enum)0))
				{
					isEnabled = true;
				}
				else
				{
					MyPlayer instance2 = MyPlayer.Instance;
					PlayerInventory inventory2 = instance2.inventory;
					WeaponInventory weaponInventory2 = inventory2.weaponInventory;
					Dictionary<EWeapon, WeaponBase> weapons2 = weaponInventory2.weapons;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [item @ rdx (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+50]");
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)weapons2).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v45 (System.Object)+40]");
					isEnabled = false;
				}
				RefreshEnabled(isEnabled);
			}
		}
		else
		{
			icon.enabled = false;
			t_level.text = "";
		}
	}

	private unsafe void RefreshEnabled(bool isEnabled)
	{
		//IL_010c: Expected O, but got Ref
		RawImage rawImage;
		if (this.toolTipObject != null)
		{
			ToolTipObject toolTipObject = this.toolTipObject;
			string text = item.GetName();
			string description = item.GetDescription();
			string text2 = "<size=120%>" + text + ":</size> " + description;
			toolTipObject.text = text2;
			if (!isEnabled)
			{
				ToolTipObject toolTipObject2 = this.toolTipObject;
				string text3 = toolTipObject2.text + " (Disabled)";
				toolTipObject2.text = text3;
				rawImage = icon;
				goto IL_00ff;
			}
		}
		rawImage = icon;
		if (isEnabled)
		{
		}
		goto IL_00ff;
		IL_00ff:
		object obj = default(object);
		rawImage.color = (Color)(&obj);
	}

	public void SetItem(EItem eItem)
	{
		ItemData itemData = DataManager.Instance.GetItem(eItem);
		if (itemData != null)
		{
			icon.enabled = true;
			Texture texture = itemData.GetIcon();
			icon.texture = texture;
			int level = GetLevel(itemData);
			if (level > 0)
			{
				int num = default(int);
				string text = num.ToString();
				string text2 = "x" + text;
				t_level.text = text2;
			}
			else
			{
				t_level.text = "";
			}
			if (this.toolTipObject != null)
			{
				ToolTipObject toolTipObject = this.toolTipObject;
				string text3 = itemData.GetName();
				string description = itemData.GetDescription();
				string text4 = "<size=120%>" + text3 + ":</size> " + description;
				toolTipObject.text = text4;
			}
		}
		else
		{
			icon.enabled = false;
			t_level.text = "";
		}
	}

	private int GetLevel(UnlockableBase item)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00b4: Expected I, but got O
		//IL_00c4: Expected O, but got I
		//IL_014d: Expected I, but got O
		//IL_015d: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_0100: Expected O, but got I
		//IL_0199: Expected O, but got I
		//IL_0253: Expected I4, but got O
		if ((object)item != null)
		{
			nint num = (nint)typeof(WeaponData);
			nint num2 = (nint)item;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<WeaponData>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppClass<WeaponData>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v22+FFFFFFF8+v43 @ rax_v4*8]");
				if (0 == (nint)typeof(WeaponData))
				{
					return ((WeaponData)item).GetLevel();
				}
			}
			nint num4 = (nint)typeof(TomeData);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v3 (Il2CppClass<TomeData>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v3 (Il2CppClass<TomeData>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v20+FFFFFFF8+v129 @ rax_v6*8]");
				if (0 == (nint)typeof(TomeData))
				{
					return ((TomeData)item).GetLevel();
				}
			}
			nint num6 = (nint)typeof(ItemData);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (Il2CppClass<ItemData>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4 (Il2CppClass<ItemData>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9+FFFFFFF8+v60 @ rax_v8*8]");
				if (0 == (nint)typeof(ItemData))
				{
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null && inventory.itemInventory != null)
						{
							ItemInventory itemInventory = inventory.itemInventory;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [item @ rdx (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+54]");
							return itemInventory.GetAmount(EItem.Key);
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
			}
		}
		return 1;
	}

	public void SetUnavailable()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172FCF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		lockedOverlay.SetActive(value: true);
		icon.enabled = false;
		t_level.text = "";
	}
}
