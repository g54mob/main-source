using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.InGame.Rewards;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class ChestUtility
{
	public unsafe static EEncounter ChestTypeToEncounter(EChest chestType)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00d1: Expected O, but got Ref
		bool flag = chestType == EChest.Normal;
		if (!flag)
		{
			object obj = chestType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 == 1)
						{
							return EEncounter.ChestGhost;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
						object obj4 = default(object);
						string text = ((Enum)(&obj4)).ToString();
						string message = "Chest type not implemented: " + text;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						Exception ex = new Exception(message);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						throw ex;
					}
					return EEncounter.ChestFreeCrypt;
				}
				return EEncounter.ChestFree;
			}
			return EEncounter.ChestEvil;
		}
		return EEncounter.ChestNormal;
	}

	public unsafe static EChest EncounterToChestType(EEncounter encounter)
	{
		//IL_000e: Expected O, but got I4
		//IL_007e: Expected O, but got Ref
		//IL_0038: Expected O, but got I8
		//IL_0052: Expected O, but got I8
		object obj = encounter + -3;
		if ((nint)obj <= 8)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rdx_v6+451920+v2 @ rcx_v1*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ rcx_v13 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
		object obj4 = default(object);
		string text = ((Enum)(&obj4)).ToString();
		string message = "Chest type not implemented: " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Exception ex = new Exception(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public static void OpenChestNoAnimation(EChest chestType)
	{
		float stat = PlayerStats.GetStat(EStat.Luck);
		ItemData randomChestItem = ItemUtility.GetRandomChestItem(chestType, stat);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		inventory.itemInventory.AddItem(randomChestItem.eItem);
	}
}
