using System;
using System.Collections.Generic;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityEnduring : PassiveAbility
{
	private float sizePerLevel = 0.0075f;

	private float maxSize = 4f;

	private float damageMultiplierPerFrozenEnemy = 0.015f;

	private float maxDamageFromFrozenEnemies = 3f;

	private int lastNumFrozenEnemies;

	public override void Init()
	{
		//IL_01a1: Expected I, but got O
		//IL_01b2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_020c: Expected I, but got O
		//IL_021d: Expected O, but got I4
		//IL_0233: Expected I, but got O
		//IL_0259: Expected I, but got O
		//IL_026a: Expected O, but got I4
		//IL_0280: Expected I, but got O
		DebuffIce.numFrozenEnemies = 0;
		Action<int> b = OnLevelup;
		Delegate obj = Delegate.Combine(PlayerXp.A_LevelUp, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_02ad;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_01e9;
			}
		}
		Action action2 = OnStageStarted;
		Delegate obj6 = Delegate.Combine(GameManager.A_StageStarted, action2);
		if ((object)obj6 == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)GameManager.A_StageStarted;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_029d;
		}
		GameManager.A_StageStarted = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)GameManager.A_StageStarted;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_02ad;
		IL_029d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01e9;
		IL_01e9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_029d;
	}

	private void OnStageStarted()
	{
		DebuffIce.numFrozenEnemies = 0;
	}

	public override void Tick()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		if (lastNumFrozenEnemies != DebuffIce.numFrozenEnemies)
		{
			float modification = maxDamageFromFrozenEnemies;
			lastNumFrozenEnemies = DebuffIce.numFrozenEnemies;
			object obj = DebuffIce.numFrozenEnemies * damageMultiplierPerFrozenEnemy;
			float num = (float)obj + 1f;
			StatModifier statModifier = new StatModifier();
			if (maxDamageFromFrozenEnemies > num)
			{
				modification = num;
			}
			statModifier.stat = EStat.DamageMultiplier;
			statModifier.modifyType = EStatModifyType.Multiplication;
			statModifier.modification = modification;
			SetStat(statModifier);
		}
	}

	private void OnLevelup(int level)
	{
		float modification = maxSize;
		float num = (float)level * sizePerLevel;
		StatModifier statModifier = new StatModifier();
		if (maxSize > num)
		{
			modification = num;
		}
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.SizeMultiplier;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public override void Cleanup()
	{
		//IL_01a1: Expected I, but got O
		//IL_01b2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_01e4: Expected I, but got O
		//IL_01f5: Expected O, but got I4
		//IL_020b: Expected I, but got O
		//IL_0231: Expected I, but got O
		//IL_0242: Expected O, but got I4
		//IL_0258: Expected I, but got O
		Action<int> value = OnLevelup;
		Delegate obj = Delegate.Remove(PlayerXp.A_LevelUp, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_029e;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_01c1;
			}
		}
		Action action2 = OnStageStarted;
		Delegate obj6 = Delegate.Remove(GameManager.A_StageStarted, action2);
		if ((object)obj6 == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)GameManager.A_StageStarted;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_028e;
		}
		GameManager.A_StageStarted = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)GameManager.A_StageStarted;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_029e;
		IL_028e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01c1;
		IL_01c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_029e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_028e;
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Enduring;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_00d3: Expected I, but got O
		//IL_00ec: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_01c9: Expected O, but got I4
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.SizeMultiplier);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
		float num = sizePerLevel * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		string text2 = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text2 == null)
		{
			text2 = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"damage", (object)text2);
		object[] array = new object[1];
		if (array != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdx_v14 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, text2);
			object obj = default(object);
			if (obj == null)
			{
				IntPtr intPtr = default(IntPtr);
				((Dictionary<string, object>)9).Add("stat1", (nint)intPtr);
				object obj2 = default(object);
				throw obj2;
			}
			array[0] = dictionary;
			if (localizedString != null)
			{
				return localizedString.GetLocalizedString(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
