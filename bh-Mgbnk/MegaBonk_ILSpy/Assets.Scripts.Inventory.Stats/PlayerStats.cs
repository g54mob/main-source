using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory.Stats;

public static class PlayerStats
{
	public unsafe static float GetStat(EStat stat)
	{
		//IL_0117: Expected I, but got O
		//IL_0027: Expected I, but got O
		//IL_0162: Expected O, but got Ref
		//IL_0189: Expected I, but got O
		//IL_0060: Expected I, but got O
		//IL_0087: Expected I, but got O
		nint num = (nint)typeof(GameManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<GameManager>)+B8]");
		nint num2 = 0;
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			bool flag = playerInventory == null;
			num2 = unchecked((nint)null);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
				object obj = default(object);
				string text = ((Enum)(&obj)).ToString();
				string message = "Failed to get stat: " + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Exception ex = new Exception(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
			MyPlayer instance = MyPlayer.Instance;
			bool flag2 = (object)MyPlayer.Instance == null;
			num2 = unchecked((nint)null);
			if (!flag2)
			{
				PlayerInventory inventory = instance.inventory;
				bool flag3 = instance.inventory == null;
				num2 = unchecked((nint)null);
				if (!flag3)
				{
					bool flag4 = inventory.playerStats == null;
					num2 = unchecked((nint)null);
					if (!flag4)
					{
						return inventory.playerStats.GetStat(stat);
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static float GetStatRaw(EStat stat)
	{
		//IL_0117: Expected I, but got O
		//IL_0027: Expected I, but got O
		//IL_0162: Expected O, but got Ref
		//IL_0189: Expected I, but got O
		//IL_0060: Expected I, but got O
		//IL_0087: Expected I, but got O
		nint num = (nint)typeof(GameManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<GameManager>)+B8]");
		nint num2 = 0;
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			bool flag = playerInventory == null;
			num2 = unchecked((nint)null);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
				object obj = default(object);
				string text = ((Enum)(&obj)).ToString();
				string message = "Failed to get raw stat: " + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Exception ex = new Exception(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
			MyPlayer instance = MyPlayer.Instance;
			bool flag2 = (object)MyPlayer.Instance == null;
			num2 = unchecked((nint)null);
			if (!flag2)
			{
				PlayerInventory inventory = instance.inventory;
				bool flag3 = instance.inventory == null;
				num2 = unchecked((nint)null);
				if (!flag3)
				{
					bool flag4 = inventory.playerStats == null;
					num2 = unchecked((nint)null);
					if (!flag4)
					{
						return inventory.playerStats.GetRawStat(stat);
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static StatComponents GetStatComponents(EStat stat)
	{
		//IL_0027: Expected I, but got O
		//IL_0178: Expected O, but got Ref
		//IL_019f: Expected I, but got O
		//IL_0060: Expected I, but got O
		//IL_0094: Expected I, but got O
		//IL_00bb: Expected I, but got O
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			bool flag = playerInventory == null;
			nint num = unchecked((nint)null);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
				object obj = default(object);
				string text = ((Enum)(&obj)).ToString();
				string message = "Failed to get stat: " + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Exception ex = new Exception(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
			MyPlayer instance = MyPlayer.Instance;
			bool flag2 = (object)MyPlayer.Instance == null;
			num = unchecked((nint)null);
			if (!flag2)
			{
				PlayerInventory inventory = instance.inventory;
				bool flag3 = instance.inventory == null;
				num = unchecked((nint)null);
				if (!flag3)
				{
					PlayerStatsNew playerStats = inventory.playerStats;
					bool flag4 = inventory.playerStats == null;
					num = unchecked((nint)null);
					if (!flag4)
					{
						bool flag5 = playerStats.statValuesMap == null;
						num = unchecked((nint)null);
						if (!flag5)
						{
							return (StatComponents)((Dictionary<System.Int32Enum, object>)(object)playerStats.statValuesMap).get_Item((System.Int32Enum)stat);
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static bool HasStats()
	{
		//IL_0080: Expected I4, but got O
		bool flag = GameManager.Instance != null;
		if (!flag)
		{
			return flag;
		}
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			bool flag2 = playerInventory == null;
			return !flag2;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
