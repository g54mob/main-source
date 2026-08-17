using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityZooma : PassiveAbility
{
	private float chargePerMeter = 0.006f;

	private float checkInterval = 0.5f;

	private float nextCheckTime;

	private Vector3 lastPos;

	private float accumulatedCharge;

	private float attractionAddPerLevel = 0.02f;

	private DamageContainer reuseDc;

	private string damageSource;

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
		Action<Enemy, DamageContainer> b = OnEnemyDamage;
		Delegate obj = Delegate.Combine(Enemy.A_Damage, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_Damage = (Action<Enemy, DamageContainer>)obj;
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
			Enemy.A_Damage = action;
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
		Action<Enemy, DamageContainer> value = OnEnemyDamage;
		Delegate obj = Delegate.Remove(Enemy.A_Damage, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_Damage = (Action<Enemy, DamageContainer>)obj;
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
			Enemy.A_Damage = action;
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

	private void OnLevelup(int level)
	{
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * attractionAddPerLevel;
		statModifier.stat = EStat.PickupRange;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	private unsafe void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
		//IL_0008: Expected O, but got Ref
		//IL_005e: Expected O, but got Ref
		//IL_00c6: Expected F4, but got I4
		//IL_02b7: Expected O, but got Ref
		//IL_0319: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_0290: Invalid comparison between F4 and I4
		//IL_01b7: Expected O, but got Ref
		//IL_01c5: Expected O, but got Ref
		//IL_0269: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (1f > accumulatedCharge)
		{
			return;
		}
		accumulatedCharge = 0f;
		Transform transform = enemy.transform;
		Vector3 position = transform.position;
		ref Collider[] buffer = ref System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = position.x;
		_ = position.z;
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, 6f, out buffer);
		if (enemiesInRadiusSafe > 0)
		{
			float num = 1f;
			float num2 = 6f;
			float num3 = 0f;
			Vector3 direction = default(Vector3);
			Enemy enemy3 = default(Enemy);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
				object obj3 = 0;
				ref Enemy enemy2 = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				EnemyManager instance = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r10_v6+20+v238 @ rdi_v8 (System.Single)*8]");
				if (instance.GetEnemy((Collider)0, out enemy2))
				{
					num = GetDamage();
					Transform transform2 = enemy.transform;
					Vector3 position2 = transform2.position;
					Transform transform3 = MyPlayer.Instance.transform;
					Vector3 position3 = transform3.position;
					float num4 = position2.x - position3.x;
					float num5 = position2.y - position3.y;
					float num6 = position2.z - position3.z;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rax_v33+8]");
					_ = 0;
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, num, 0.5f, damageSource, direction, enemy3);
					reuseDc = damageContainer;
					DamageContainer damageContainer2 = reuseDc;
					damageContainer2.element = EElement.Lightning;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
					((Enemy)0).DamageFromPlayerOther(reuseDc);
					num2 = 0.5f;
				}
				num3++;
			}
			while (num3 < (float)enemiesInRadiusSafe);
		}
		Vector3 centerPosition = enemy.GetCenterPosition();
		Vector3 pos2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = centerPosition.x;
		_ = centerPosition.z;
		EffectManager.Instance.ZapEffect(pos2);
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		return instance.baseDamage * 3f;
	}

	public override void Tick()
	{
		//IL_011b: Expected O, but got F4
		if (!(nextCheckTime > MyTime.time) && accumulatedCharge < 1f)
		{
			float num = MyTime.time + checkInterval;
			nextCheckTime = num;
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num2 = position.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma)+28]");
			float num3 = num2 - 0f;
			float num4 = position.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma)+2C]");
			float num5 = num4 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float num6 = num5 * chargePerMeter;
			if (!((accumulatedCharge = num6 + accumulatedCharge) < 1f))
			{
				accumulatedCharge = 1f;
			}
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			lastPos = (Vector3)position2.x;
			_ = position2.z;
		}
	}

	public float GetProgress()
	{
		return accumulatedCharge;
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Zap;
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
		string text = EnumUtility.EnumToReadable(EStat.PickupRange);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 29;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = attractionAddPerLevel * 100f;
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

	public PassiveAbilityZooma()
	{
		DamageContainer damageContainer = new DamageContainer(1f, "Zap");
		reuseDc = damageContainer;
		damageSource = "Zap";
		base._002Ector();
	}
}
