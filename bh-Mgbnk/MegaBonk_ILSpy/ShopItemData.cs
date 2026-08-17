using System;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class ShopItemData : UnlockableBase
{
	public EShopItem eShopItem;

	public Texture icon;

	public int maxLevel = 5;

	public MyAchievement unlockRequirement;

	public bool canRefund = true;

	public float value;

	public int sortingOrder;

	public int linearIncrease;

	public float exponentialMultiplier = 1f;

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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172191]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "SHOP_ITEM");
	}

	public unsafe override string GetInternalName()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		return ((Enum)(&obj)).ToString();
	}

	private int GetLevelPrice(int level)
	{
		//IL_0057: Expected O, but got I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected I4, but got Unknown
		if (level != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num = Math.Round(0.0);
			object obj = level * linearIncrease;
			return (int)(num + obj);
		}
		return price;
	}

	public override int GetPrice()
	{
		int level = GetLevel();
		return GetLevelPrice(level);
	}

	public int GetRefundPrice()
	{
		int level = GetLevel();
		int level2 = level - 1;
		return GetLevelPrice(level2);
	}

	public int GetLevel()
	{
		//IL_00ad: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.shopItems != null)
			{
				return progression.shopItems.get_Item(eShopItem);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public bool IsMaxLevel()
	{
		//IL_019e: Expected I4, but got O
		//IL_00cd: Expected O, but got I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected I4, but got Unknown
		//IL_01fd: Expected O, but got I4
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected I4, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.shopItems != null)
			{
				int num = progression.shopItems.get_Item(eShopItem);
				string achName;
				bool flag4;
				if (eShopItem != EShopItem.Weapons)
				{
					if (eShopItem != EShopItem.Tomes)
					{
						object obj = num - maxLevel;
						int num2 = num ^ maxLevel;
						int num3 = num ^ obj;
						int num4 = num2 & num3;
						bool flag = num4 < 0;
						bool flag2 = (nint)obj < 0;
						return flag2 == flag;
					}
					bool flag3 = MyAchievements.IsUnlockedInternalNameAch("a_tomeSlots");
					achName = "a_tomeSlots2";
					flag4 = flag3;
				}
				else
				{
					bool flag5 = MyAchievements.IsUnlockedInternalNameAch("a_weaponSlots");
					achName = "a_weaponSlots2";
					flag4 = flag5;
				}
				bool flag6 = MyAchievements.IsUnlockedInternalNameAch(achName);
				bool flag7 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
				if (!flag6)
				{
					flag7 = flag4;
				}
				object obj2 = num - (flag7 ? 1 : 0);
				int num5 = num ^ (flag7 ? 1 : 0);
				int num6 = num ^ obj2;
				int num7 = num5 & num6;
				bool flag8 = num7 < 0;
				bool flag9 = (nint)obj2 < 0;
				return flag9 == flag8;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public new bool CanBuy()
	{
		//IL_00f7: Expected I4, but got O
		//IL_0081: Expected O, but got I4
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected I4, but got Unknown
		if (!IsMaxLevel())
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
			{
				ProgressionSaveFile progression = saveManager.progression;
				if (saveManager.progression != null)
				{
					int num = GetPrice();
					object obj = progression.silver - num;
					int num2 = progression.silver ^ num;
					int num3 = progression.silver ^ obj;
					int num4 = num2 & num3;
					bool flag = num4 < 0;
					bool flag2 = (nint)obj < 0;
					return flag2 == flag;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool CanRefund()
	{
		if (!canRefund)
		{
			return false;
		}
		int level = GetLevel();
		int num = level ^ level;
		int num2 = level & num;
		bool flag = num2 < 0;
		bool flag2 = level < 0;
		bool flag3 = level == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}

	public int GetMaxLevel()
	{
		string achName;
		bool flag2;
		if (eShopItem != EShopItem.Weapons)
		{
			if (eShopItem != EShopItem.Tomes)
			{
				return maxLevel;
			}
			bool flag = MyAchievements.IsUnlockedInternalNameAch("a_tomeSlots");
			achName = "a_tomeSlots2";
			flag2 = flag;
		}
		else
		{
			bool flag3 = MyAchievements.IsUnlockedInternalNameAch("a_weaponSlots");
			achName = "a_weaponSlots2";
			flag2 = flag3;
		}
		bool flag4 = MyAchievements.IsUnlockedInternalNameAch(achName);
		bool result = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		if (!flag4)
		{
			result = flag2;
		}
		return result ? 1 : 0;
	}

	public unsafe override int CompareTo(UnlockableBase other)
	{
		//IL_027e: Expected I, but got O
		//IL_01f5: Expected I, but got O
		//IL_0205: Expected O, but got I
		//IL_0035: Expected I, but got O
		//IL_003d: Expected I, but got O
		//IL_004d: Expected O, but got I
		//IL_00e7: Expected I, but got O
		//IL_0089: Expected O, but got I
		//IL_00ae: Expected O, but got I4
		//IL_0108: Expected I, but got O
		//IL_0110: Expected I, but got O
		//IL_0120: Expected O, but got I
		//IL_016a: Expected O, but got I
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected I4, but got Unknown
		//IL_01dd: Expected I, but got O
		bool flag = (object)other == null;
		UnityEngine.Object obj = null;
		if (flag)
		{
			goto IL_0260;
		}
		nint num = (nint)typeof(ShopItemData);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v12 (Il2CppClass<ShopItemData>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v10 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v12 (Il2CppClass<ShopItemData>)+130]");
		UnityEngine.Object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v10 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v23+FFFFFFF8+v59 @ rax_v19*8]");
			bool flag2 = 0 == (nint)typeof(ShopItemData);
			obj4 = (UnityEngine.Object)1;
			if (flag2)
			{
				goto IL_028c;
			}
		}
		obj4 = null;
		goto IL_028c;
		IL_024f:
		throw new NullReferenceException();
		IL_01f0:
		nint num4 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v10 (Il2CppClass<ShopItemData>)+1B0]");
		UnityEngine.Object obj5 = (UnityEngine.Object)0;
		int num5 = GetPrice();
		if ((object)other != null)
		{
			int num6 = other.GetPrice();
			int num7 = default(int);
			return num7.CompareTo(num6);
		}
		goto IL_024f;
		IL_0260:
		bool flag3 = obj != null;
		bool flag4 = !flag3;
		nint num8 = unchecked((nint)null);
		if (flag4)
		{
			goto IL_01f0;
		}
		bool flag5 = (object)other == null;
		num8 = unchecked((nint)null);
		obj5 = null;
		if (!flag5)
		{
			nint num9 = (nint)typeof(ShopItemData);
			num8 = (nint)other;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v9 (Il2CppClass<ShopItemData>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r8_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v9 (Il2CppClass<ShopItemData>)+130]");
			bool flag6 = num10 < 0;
			obj5 = (UnityEngine.Object)(object)typeof(ShopItemData);
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r8_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v16+FFFFFFF8+v208 @ rax_v15*8]");
				bool flag7 = 0 != (nint)typeof(ShopItemData);
				obj5 = (UnityEngine.Object)(object)typeof(ShopItemData);
				if (!flag7)
				{
					int num11 = this + 120;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+78]");
					int num12 = ((int*)num11)->CompareTo(0);
					bool flag8 = num12 == 0;
					num8 = unchecked((nint)null);
					if (!flag8)
					{
						return num12;
					}
					goto IL_01f0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			int result = default(int);
			return result;
		}
		goto IL_024f;
		IL_028c:
		bool flag9 = (object)obj4 == null;
		obj = null;
		if (!flag9)
		{
			obj = other;
		}
		goto IL_0260;
	}
}
