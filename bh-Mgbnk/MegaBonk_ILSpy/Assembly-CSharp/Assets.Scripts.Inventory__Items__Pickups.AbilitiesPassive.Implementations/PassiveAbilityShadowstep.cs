using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityShadowstep : PassiveAbility
{
	private float evadePerLevel = 0.005f;

	public const string damageSource = "Shadowstep";

	private DamageContainer reuseDc;

	public override void Init()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<int> b = OnLevelup;
		Delegate obj = Delegate.Combine(PlayerXp.A_LevelUp, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
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
				obj4 = 0;
				goto IL_020d;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ca;
			}
		}
		Action<Enemy> b2 = OnEvade;
		Delegate obj6 = Delegate.Combine(PlayerHealth.A_Evaded, b2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_Evaded = (Action<Enemy>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action2 = default(Action<Enemy>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<Enemy>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerHealth.A_Evaded = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<Enemy>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ca;
	}

	public override void Cleanup()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<int> value = OnLevelup;
		Delegate obj = Delegate.Remove(PlayerXp.A_LevelUp, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
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
				obj4 = 0;
				goto IL_020d;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ca;
			}
		}
		Action<Enemy> value2 = OnEvade;
		Delegate obj6 = Delegate.Remove(PlayerHealth.A_Evaded, value2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_Evaded = (Action<Enemy>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action2 = default(Action<Enemy>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<Enemy>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerHealth.A_Evaded = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<Enemy>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ca;
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
	{
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * evadePerLevel;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Evasion;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	private void OnEvade(Enemy enemy)
	{
		if (!(enemy != null))
		{
			return;
		}
		reuseDc.Reuse(0.1f, "Shadowstep");
		DamageContainer damageContainer = reuseDc;
		damageContainer.enemy = enemy;
		DamageContainer damageContainer2 = reuseDc;
		damageContainer2.damageEffect = EDamageEffect.Execute;
		damageContainer2.isExecute = true;
		bool flag = damageContainer2.enemy.IsBoss();
		Enemy enemy2 = damageContainer2.enemy;
		float damage;
		if (!flag)
		{
			EnemyData enemyData = enemy2._003CenemyData_003Ek__BackingField;
			if (enemyData.canBeExecuted)
			{
				damage = enemy2._003Chp_003Ek__BackingField;
				goto IL_012e;
			}
		}
		damage = enemy2.maxHp * 0.02f;
		goto IL_012e;
		IL_012e:
		damageContainer2.damage = damage;
		enemy.DamageFromPlayerOther(reuseDc);
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Shadowstep;
	}

	public unsafe override string GetDescription(LocalizedString localizedString)
	{
		//IL_0098: Expected O, but got Ref
		//IL_00e9: Expected I, but got O
		//IL_0102: Expected O, but got I
		//IL_01df: Expected O, but got I
		//IL_01df: Expected O, but got I4
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Evasion);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
		float num = evadePerLevel * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		string text2 = LocalizationUtility.GetLocalizedString("DamageSources", key);
		if (text2 == null)
		{
			text2 = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"Execute", (object)text2);
		object[] array = new object[1];
		if (array != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, text2);
			object obj2 = default(object);
			if (obj2 == null)
			{
				IntPtr intPtr = default(IntPtr);
				((Dictionary<string, object>)5).Add("stat1", (nint)intPtr);
				object obj3 = default(object);
				throw obj3;
			}
			array[0] = dictionary;
			if (localizedString != null)
			{
				return localizedString.GetLocalizedString(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public PassiveAbilityShadowstep()
	{
		DamageContainer damageContainer = new DamageContainer(0.1f, "Shadowstep");
		reuseDc = damageContainer;
		base._002Ector();
	}
}
