using System;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;

public class XpAndGoldHUD : MonoBehaviour
{
	public XpAndGoldText xpText;

	public XpAndGoldText goldText;

	public XpAndGoldText silverText;

	private void Awake()
	{
		//IL_02a8: Expected I, but got O
		//IL_02b9: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_020e: Expected I, but got O
		//IL_021f: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_0266: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		Action<PlayerInventory, int> b = OnGoldIncrease;
		Delegate obj = Delegate.Combine(PlayerInventory.A_GoldChange, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerInventory.A_GoldChange = (Action<PlayerInventory, int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory, int> action = default(Action<PlayerInventory, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerInventory, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0337;
			}
			PlayerInventory.A_GoldChange = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02cc;
			}
		}
		Action<int> b2 = OnSilverChange;
		Delegate obj6 = Delegate.Combine(ProgressionSaveFile.A_SilverChanged, b2);
		if ((object)obj6 == null)
		{
			ProgressionSaveFile.A_SilverChanged = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02d7;
			}
			ProgressionSaveFile.A_SilverChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_02e7;
			}
		}
		Action<PlayerXp, int> b3 = OnXpIncrease;
		Delegate obj8 = Delegate.Combine(PlayerXp.A_XpAdded, b3);
		if ((object)obj8 == null)
		{
			PlayerXp.A_XpAdded = (Action<PlayerXp, int>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerXp, int> action3 = default(Action<PlayerXp, int>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<PlayerXp, int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0327;
		}
		PlayerXp.A_XpAdded = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<PlayerXp, int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0337;
		IL_0337:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0327;
		IL_02cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02cc;
		IL_02e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02d7;
		IL_0327:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02e7;
	}

	private void OnDestroy()
	{
		//IL_02a8: Expected I, but got O
		//IL_02b9: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_020e: Expected I, but got O
		//IL_021f: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_0266: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		Action<PlayerInventory, int> value = OnGoldIncrease;
		Delegate obj = Delegate.Remove(PlayerInventory.A_GoldChange, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerInventory.A_GoldChange = (Action<PlayerInventory, int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory, int> action = default(Action<PlayerInventory, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerInventory, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0337;
			}
			PlayerInventory.A_GoldChange = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerInventory, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02cc;
			}
		}
		Action<int> value2 = OnSilverChange;
		Delegate obj6 = Delegate.Remove(ProgressionSaveFile.A_SilverChanged, value2);
		if ((object)obj6 == null)
		{
			ProgressionSaveFile.A_SilverChanged = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02d7;
			}
			ProgressionSaveFile.A_SilverChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_02e7;
			}
		}
		Action<PlayerXp, int> value3 = OnXpIncrease;
		Delegate obj8 = Delegate.Remove(PlayerXp.A_XpAdded, value3);
		if ((object)obj8 == null)
		{
			PlayerXp.A_XpAdded = (Action<PlayerXp, int>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerXp, int> action3 = default(Action<PlayerXp, int>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<PlayerXp, int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0327;
		}
		PlayerXp.A_XpAdded = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<PlayerXp, int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0337;
		IL_0337:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0327;
		IL_02cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02cc;
		IL_02e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02d7;
		IL_0327:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02e7;
	}

	private void OnGoldIncrease(PlayerInventory inv, int amount)
	{
		if (IsActive())
		{
			goldText.Add(amount);
		}
	}

	private void OnXpIncrease(PlayerXp pXp, int amount)
	{
		if (IsActive())
		{
			xpText.Add(amount);
		}
	}

	private void OnSilverChange(int amount)
	{
		if (IsActive())
		{
			silverText.Add(amount);
		}
	}

	private bool IsActive()
	{
		//IL_00c4: Expected I4, but got O
		//IL_00a2: Expected O, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
				if (config.cfVisualsSettings != null)
				{
					object obj = cfVisualsSettings.xp_gold_hud - 1;
					return obj == null;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
