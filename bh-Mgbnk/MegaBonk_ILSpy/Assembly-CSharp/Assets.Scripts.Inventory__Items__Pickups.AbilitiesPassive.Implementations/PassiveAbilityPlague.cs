using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityPlague : PassiveAbility
{
	private int levelsPerStack = 5;

	private float radius = 4f;

	private float maxRadius = 12f;

	private float radiusPerLevel = 0.05f;

	private float duration = 4f;

	private float poisonDamagePerLevel = 0.01f;

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
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy, DamageContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ca;
			}
		}
		Action<int> b2 = OnLevelup;
		Delegate obj6 = Delegate.Combine(PlayerXp.A_LevelUp, b2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action2 = default(Action<int>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<int>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerXp.A_LevelUp = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<int>);
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
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy, DamageContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ca;
			}
		}
		Action<int> value2 = OnLevelup;
		Delegate obj6 = Delegate.Remove(PlayerXp.A_LevelUp, value2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action2 = default(Action<int>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<int>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerXp.A_LevelUp = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<int>);
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

	private unsafe void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_0069: Expected F8, but got I4
		//IL_00b7: Expected O, but got Ref
		//IL_00d7: Expected F8, but got I4
		//IL_0154: Invalid comparison between F8 and I4
		//IL_01d7: Expected O, but got Ref
		//IL_01fb: Expected O, but got Ref
		if (!((Dictionary<System.Int32Enum, object>)(object)enemy.debuffs).ContainsKey((System.Int32Enum)1))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		int characterLevel = instance.inventory.GetCharacterLevel();
		int num = characterLevel / levelsPerStack;
		double num2 = Math.Floor((double)num);
		Vector3 centerPosition = enemy.GetCenterPosition();
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		float range = radius * stat;
		float num3 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num3), range, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		double num4 = 0.0;
		if (!flag)
		{
			int stacks = default(int);
			do
			{
				if (EnemyManager.Instance.GetEnemy(buffer[num4], out var enemy2))
				{
					enemy2.AddDebuff(EDebuff.Poison, null, duration, stacks);
				}
				num4++;
			}
			while (num4 < (double)enemiesInRadiusSafe);
		}
		PoolManager instance2 = PoolManager.Instance;
		GameObject gameObject = instance2.poisonPool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Vector3 centerPosition2 = enemy.GetCenterPosition();
			transform.position = (Vector3)(&num3);
			Transform transform2 = gameObject.transform;
			float stat2 = PlayerStats.GetStat(EStat.SizeMultiplier);
			transform2.localScale = (Vector3)(&num3);
		}
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
	{
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * poisonDamagePerLevel;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.PoisonDamageMultiplier;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Plague;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_01ff: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_00cc: Expected I, but got O
		//IL_00e2: Expected I, but got O
		//IL_00fb: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_012b: Expected I, but got O
		//IL_0230: Expected O, but got I
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.PoisonDamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 56;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = poisonDamagePerLevel * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text2;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num = (nint)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)num).Add((string)obj2, obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				num = (nint)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = text2;
				obj2 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
