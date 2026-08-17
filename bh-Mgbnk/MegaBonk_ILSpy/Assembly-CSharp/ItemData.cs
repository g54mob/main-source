using System;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ItemData : UnlockableBase
{
	public bool inItemPool = true;

	public EItem eItem;

	public Texture icon;

	public EItemRarity rarity;

	public MyAchievement unlockRequirement;

	public int maxAmount;

	public int maxAmountPerRun;

	public int itemTickPriority;

	private ItemBase dummyItem;

	public override string GetName()
	{
		if (localizedName != null)
		{
			return localizedName.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override string GetDescription()
	{
		if (dummyItem != null)
		{
			return dummyItem.GetDescription(localizedDescription);
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetShortDescription()
	{
		return GetDescription();
	}

	public ItemBase GetDummyItem()
	{
		if (dummyItem == null)
		{
			ItemBase itemBase = ItemFactory.CreateItem(eItem, null);
			dummyItem = itemBase;
			return dummyItem;
		}
		return dummyItem;
	}

	public override Texture GetIcon()
	{
		return icon;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return unlockRequirement;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172179]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "ITEM", "Item");
	}

	public unsafe override string GetInternalName()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		return ((Enum)(&obj)).ToString();
	}

	public unsafe Color GetColor()
	{
		//IL_0021: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->r = MyColorUtility.GetItemRarityColor(rarity).r;
		return color;
	}

	public unsafe override int CompareTo(UnlockableBase other)
	{
		//IL_013a: Expected I4, but got O
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ac: Expected I, but got O
		//IL_00bc: Expected O, but got I
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0160: Expected I4, but got O
		//IL_0171: Expected O, but got Ref
		int num5;
		if ((object)other != null)
		{
			nint num = (nint)typeof(ItemData);
			nint num2 = (nint)other;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<ItemData>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<ItemData>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5+FFFFFFF8+v44 @ rax_v4*8]");
				if (0 == (nint)typeof(ItemData))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<ItemData>)+130]");
					object obj3 = 0;
					nint num4 = (nint)other;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v6 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v4+FFFFFFF8+v86 @ rdx_v3*8]");
					object obj5 = 0 - typeof(ItemData);
					if (obj5 != null)
					{
						object obj6 = default(object);
						object target = (EItemRarity)obj6;
						IntPtr intPtr = default(IntPtr);
						num5 = ((Enum)(&intPtr)).CompareTo(target);
						if (num5 != 0)
						{
							goto IL_0127;
						}
					}
					int num6 = base.GetPrice();
					int value = other.GetPrice();
					int num7 = default(int);
					num5 = num7.CompareTo(value);
					goto IL_0127;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_0127:
		return num5;
	}
}
