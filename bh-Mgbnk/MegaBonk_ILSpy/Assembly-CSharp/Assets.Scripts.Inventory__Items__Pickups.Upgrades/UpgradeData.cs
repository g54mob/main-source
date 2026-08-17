using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Upgrades;

public class UpgradeData : ScriptableObject
{
	public List<StatModifier> upgradeModifiers;

	public List<StatModifier> GetUpgradeOffer(ERarity rarity, EWeapon eWeapon)
	{
		//IL_0123: Expected O, but got I4
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected I4, but got Unknown
		//IL_01a8: Expected O, but got I4
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected I4, but got Unknown
		//IL_04a8: Expected O, but got I4
		//IL_024e: Expected O, but got I4
		//IL_0240: Expected O, but got I
		//IL_02c1: Expected O, but got I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		List<StatModifier> list = new List<StatModifier>();
		float multiplier = Rarity.GetMultiplier(rarity);
		List<StatModifier> list2 = (List<StatModifier>)(object)new List<object>(upgradeModifiers);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		if (((Dictionary<System.Int32Enum, object>)(object)weaponInventory.weapons).ContainsKey((System.Int32Enum)eWeapon))
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			WeaponInventory weaponInventory2 = inventory2.weaponInventory;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)weaponInventory2.weapons).get_Item((System.Int32Enum)eWeapon);
		}
		ERarity eRarity;
		if (rarity == ERarity.Common)
		{
			int num = UnityEngine.Random.Range(0, 2);
			bool flag = num != (int)rarity;
			eRarity = rarity;
			if (flag)
			{
				goto IL_049f;
			}
		}
		object obj2 = list2._size - 1;
		int num2 = list2._size ^ 1;
		int num3 = list2._size ^ obj2;
		int num4 = num2 & num3;
		bool flag2 = num4 < 0;
		bool flag3 = (nint)obj2 < 0;
		bool flag4 = obj2 == null;
		bool flag5 = flag3 == flag2;
		bool flag6 = !flag4;
		object obj3 = flag6 & flag5;
		eRarity = (ERarity)(obj3 + 1);
		goto IL_049f;
		IL_049f:
		object obj4 = 0;
		while (true)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			ItemInventory itemInventory = inventory3.itemInventory;
			object obj6;
			if (((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)41))
			{
				object obj5 = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).get_Item((System.Int32Enum)41);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v55 (System.Object)+18]");
				obj6 = 0;
			}
			else
			{
				obj6 = 0;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) || (int)eRarity >= list2._size)
			{
				break;
			}
			eRarity++;
			obj4++;
		}
		if (eRarity > ERarity.New)
		{
			object obj7 = 0;
			int num7 = default(int);
			do
			{
				System.Random random = MyRandom.random;
				int index = random.Next(0, list2._size);
				StatModifier statModifier = list2.get_Item(index);
				StatModifier statModifier2 = new StatModifier();
				statModifier2.stat = statModifier.stat;
				float num5 = statModifier.modification * multiplier;
				double num6 = Math.Round(num5, 2, MidpointRounding.ToEven);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
				statModifier2.modification = 0f;
				statModifier2.modifyType = statModifier.modifyType;
				int version = list._version + 1;
				list._version = version;
				StatModifier[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)statModifier2);
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					if (list._size >= items.Length)
					{
						return (List<StatModifier>)(object)new IndexOutOfRangeException();
					}
					items[num7] = statModifier2;
				}
				((List<object>)(object)list2).RemoveAt(index);
				obj7++;
			}
			while ((nint)obj7 < (nint)eRarity);
		}
		return list;
	}

	private StatModifier GetRandomModifier(StatModifier randomModifier, float multiplier)
	{
		StatModifier statModifier = new StatModifier();
		if (randomModifier != null && statModifier != null)
		{
			statModifier.stat = randomModifier.stat;
			float num = randomModifier.modification * multiplier;
			double num2 = Math.Round(num, 2, MidpointRounding.ToEven);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			statModifier.modification = 0f;
			statModifier.modifyType = randomModifier.modifyType;
			return statModifier;
		}
		return (StatModifier)(object)new NullReferenceException();
	}
}
