using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Extra;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityBullseye : PassiveAbility
{
	private float critDamagePerLevel;

	public const int MAX_MARKERS = 20;

	private float markDuration;

	private float markCooldown;

	private float markReadyAtTime;

	private float explosionRadius;

	private float maxExplosionRadius;

	private float explosionDamage;

	private static float minCooldown = 0.75f;

	private static float maxCooldown = 5f;

	private float cooldownReductionPerLevel;

	private static Dictionary<Enemy, float> markedEnemies;

	public static string damageSource = "Bullseye";

	private DamageContainer reuseDc;

	private bool isExplosionDamage;

	public override void Init()
	{
		//IL_046c: Expected O, but got I4
		//IL_04d3: Expected O, but got I4
		//IL_04e9: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_056a: Expected I, but got O
		//IL_0171: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0214: Expected O, but got I4
		//IL_0227: Expected I, but got O
		//IL_0268: Expected O, but got I4
		//IL_030b: Expected O, but got I4
		//IL_035f: Expected O, but got I4
		//IL_03da: Expected O, but got I4
		//IL_042e: Expected O, but got I4
		Reset();
		Delegate obj = GameManager.A_StageStarted;
		Action action = OnStageStarted;
		Delegate obj2 = Delegate.Combine(GameManager.A_StageStarted, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_05c7;
			}
			GameManager.A_StageStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_05d7;
			}
		}
		Action<Enemy, DamageContainer> b = OnEnemyDamaged;
		Delegate obj7 = Delegate.Combine(Enemy.A_Damage, b);
		Delegate obj8;
		nint num2;
		if ((object)obj7 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
			bool flag4 = action3 == null;
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			if (flag4)
			{
				goto IL_051f;
			}
			Enemy.A_Damage = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			if (flag5)
			{
				goto IL_052f;
			}
		}
		Action<Enemy> b2 = OnEnemySpawned;
		Delegate obj10 = Delegate.Combine(Enemy.A_EnemySpawned, b2);
		if ((object)obj10 == null)
		{
			Enemy.A_EnemySpawned = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action4 = default(Action<Enemy>);
			bool flag6 = action4 == null;
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			num2 = (nint)typeof(Action<Enemy>);
			if (flag6)
			{
				goto IL_053f;
			}
			Enemy.A_EnemySpawned = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			action2 = (Action)obj10;
			obj4 = 0;
			obj5 = null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			if (flag7)
			{
				goto IL_054f;
			}
		}
		Action<Enemy> b3 = OnEnemyReleasedFromPool;
		Delegate obj12 = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b3);
		if ((object)obj12 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action5 = default(Action<Enemy>);
			bool flag8 = action5 == null;
			action2 = (Action)obj12;
			obj4 = 0;
			obj5 = null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			if (flag8)
			{
				goto IL_056f;
			}
			Enemy.A_EnemyReleasedFromPool = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag9 = obj13 == null;
			action2 = (Action)obj12;
			obj4 = 0;
			obj5 = null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			if (flag9)
			{
				goto IL_057f;
			}
		}
		Action<int> b4 = OnLevelup;
		Delegate obj14 = Delegate.Combine(PlayerXp.A_LevelUp, b4);
		if ((object)obj14 == null)
		{
			PlayerXp.A_LevelUp = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action6 = default(Action<int>);
		bool flag10 = action6 == null;
		action2 = (Action)obj14;
		obj4 = 0;
		obj5 = null;
		obj = (Delegate)(object)typeof(Action<int>);
		if (flag10)
		{
			goto IL_05b7;
		}
		PlayerXp.A_LevelUp = action6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj15 = default(object);
		bool flag11 = obj15 == null;
		action2 = (Action)obj14;
		obj4 = 0;
		obj5 = null;
		obj = (Delegate)(object)typeof(Action<int>);
		if (!flag11)
		{
			return;
		}
		goto IL_05c7;
		IL_054f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj8 = action2;
		num2 = (nint)obj;
		goto IL_053f;
		IL_05b7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_057f;
		IL_052f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_051f;
		IL_05c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05b7;
		IL_057f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_056f;
		IL_053f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_052f;
		IL_051f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05d7;
		IL_05d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_056f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_054f;
	}

	public override void Cleanup()
	{
		//IL_045a: Expected O, but got I4
		//IL_04cd: Expected O, but got I4
		//IL_04e3: Expected I, but got O
		//IL_0108: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_055c: Expected I, but got O
		//IL_015c: Expected I, but got O
		//IL_016d: Expected O, but got I4
		//IL_01ff: Expected I, but got O
		//IL_0210: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_035b: Expected O, but got I4
		//IL_03d6: Expected O, but got I4
		//IL_042a: Expected O, but got I4
		Delegate obj = GameManager.A_StageStarted;
		Action action = OnStageStarted;
		Delegate obj2 = Delegate.Remove(GameManager.A_StageStarted, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_05c1;
			}
			GameManager.A_StageStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_05d1;
			}
		}
		Action<Enemy, DamageContainer> value = OnEnemyDamaged;
		Delegate obj7 = Delegate.Remove(Enemy.A_Damage, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0519;
			}
			Enemy.A_Damage = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0529;
			}
		}
		Action<Enemy> value2 = OnEnemySpawned;
		Delegate obj10 = Delegate.Remove(Enemy.A_EnemySpawned, value2);
		if ((object)obj10 == null)
		{
			Enemy.A_EnemySpawned = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action4 = default(Action<Enemy>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag6)
			{
				goto IL_0539;
			}
			Enemy.A_EnemySpawned = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			action2 = (Action)obj10;
			obj4 = 0;
			obj5 = null;
			if (flag7)
			{
				goto IL_0549;
			}
		}
		Action<Enemy> value3 = OnEnemyReleasedFromPool;
		Delegate obj12 = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value3);
		if ((object)obj12 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action5 = default(Action<Enemy>);
			bool flag8 = action5 == null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			action2 = (Action)obj12;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_0569;
			}
			Enemy.A_EnemyReleasedFromPool = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag9 = obj13 == null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			action2 = (Action)obj12;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_0579;
			}
		}
		Action<int> value4 = OnLevelup;
		Delegate obj14 = Delegate.Remove(PlayerXp.A_LevelUp, value4);
		if ((object)obj14 == null)
		{
			PlayerXp.A_LevelUp = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action6 = default(Action<int>);
		bool flag10 = action6 == null;
		obj = (Delegate)(object)typeof(Action<int>);
		action2 = (Action)obj14;
		obj4 = 0;
		obj5 = null;
		if (flag10)
		{
			goto IL_05b1;
		}
		PlayerXp.A_LevelUp = action6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj15 = default(object);
		bool flag11 = obj15 == null;
		obj = (Delegate)(object)typeof(Action<int>);
		action2 = (Action)obj14;
		obj4 = 0;
		obj5 = null;
		if (!flag11)
		{
			return;
		}
		goto IL_05c1;
		IL_0549:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_0539;
		IL_05b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0579;
		IL_0529:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0519;
		IL_05c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05b1;
		IL_0579:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0569;
		IL_0539:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0529;
		IL_0519:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05d1;
		IL_05d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0569:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0549;
	}

	private void OnLevelup(int level)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		object obj = level * cooldownReductionPerLevel;
		float num = maxCooldown - (float)obj;
		if (!(minCooldown > num))
		{
			if (num > maxCooldown)
			{
				num = maxCooldown;
			}
		}
		else
		{
			num = minCooldown;
		}
		markCooldown = num;
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * critDamagePerLevel;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.CritDamage;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	private void OnStageStarted()
	{
		Reset();
	}

	private void OnEnemySpawned(Enemy enemy)
	{
		if (markedEnemies != null && !(MyTime.time < markReadyAtTime))
		{
			PoolManager instance = PoolManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
			UnityEngine.Object obj = default(UnityEngine.Object);
			if (obj != null)
			{
				float value = MyTime.time + markDuration;
				((Dictionary<object, float>)(object)markedEnemies).Add((object)enemy, value);
				float num = MyTime.time + markCooldown;
				markReadyAtTime = num;
				BullseyeMarker component = ((GameObject)obj).GetComponent<BullseyeMarker>();
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: true);
				component.markedEnemy = enemy;
				float doneAtTime = markDuration + MyTime.time;
				component.doneAtTime = doneAtTime;
			}
		}
	}

	private unsafe void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01de: Expected O, but got Ref
		//IL_020f: Expected O, but got I4
		//IL_0511: Expected O, but got I
		//IL_0245: Expected O, but got I
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_03ba: Expected O, but got Ref
		//IL_046e: Expected O, but got Ref
		//IL_02d2: Expected O, but got I
		//IL_02ee: Expected O, but got I
		//IL_0537: Expected I, but got O
		//IL_04af: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (!(enemy != null) || dc == null)
		{
			return;
		}
		bool flag = dc.enemy == null;
		if (flag || isExplosionDamage != flag || !markedEnemies.ContainsKey(enemy))
		{
			return;
		}
		float num = ((Dictionary<object, float>)(object)markedEnemies).get_Item((object)enemy);
		if (!(num > MyTime.time))
		{
			return;
		}
		bool flag2 = markedEnemies.Remove(enemy);
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		float num2 = maxExplosionRadius;
		float num3 = stat - 1f;
		float num4 = num3 * 0.5f;
		float num5 = num4 + 1f;
		float num6 = num5 * explosionRadius;
		if (!(maxExplosionRadius > num6))
		{
			num6 = maxExplosionRadius;
		}
		isExplosionDamage = true;
		Vector3 centerPosition = dc.enemy.GetCenterPosition();
		ref Collider[] buffer = ref System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = centerPosition.x;
		_ = centerPosition.z;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, num6, out buffer);
		bool flag3 = enemiesInRadiusSafe <= 0;
		object obj3 = 0;
		if (!flag3)
		{
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
				object obj4 = 0;
				ref Enemy enemy2 = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				EnemyManager instance = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ r10_v6+20+v459 @ rdi_v9*8]");
				if (instance.GetEnemy((Collider)0, out enemy2))
				{
					reuseDc.Reuse(0f, damageSource);
					DamageContainer damageContainer = reuseDc;
					num2 = explosionDamage * dc.damage;
					damageContainer.damage = num2;
					DamageContainer damageContainer2 = reuseDc;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
					damageContainer2.enemy = (Enemy)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
					((Enemy)0).DamageFromPlayerOther(reuseDc);
				}
				obj3++;
			}
			while ((nint)obj3 < enemiesInRadiusSafe);
		}
		isExplosionDamage = false;
		PoolManager instance2 = PoolManager.Instance;
		GameObject gameObject = instance2.explosionPool.Get();
		if (gameObject != null)
		{
			gameObject.SetActive(value: true);
			Transform transform = gameObject.transform;
			Vector3 centerPosition2 = dc.enemy.GetCenterPosition();
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = insideUnitSphere.x;
			_ = insideUnitSphere.z;
			Vector3 vector = VectorExtensions.XZVector(v);
			float num7 = vector.y * 0.4f;
			float num8 = vector.z * 0.4f;
			float num9 = vector.x * 0.4f;
			float num10 = num7 + centerPosition2.y;
			float num11 = num8 + centerPosition2.z;
			float num12 = num9 + centerPosition2.x;
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			transform.position = position;
			Transform transform2 = gameObject.transform;
			nint num13 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rcx_v49 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num14 = 0;
			float num15 = num6 * (float)Vector3.oneVector;
			float num16 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdx_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			float num17 = num16 * 0f;
			float num18 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdx_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num19 = num18 * 0f;
			Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			transform2.localScale = localScale;
		}
		AudioManager.Instance.Bullseye();
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
		if (markedEnemies != null && markedEnemies.ContainsKey(enemy))
		{
			bool flag = markedEnemies.Remove(enemy);
		}
	}

	private void Reset()
	{
		Dictionary<Enemy, float> dictionary = new Dictionary<Enemy, float>();
		markedEnemies = dictionary;
		float num = MyTime.time + markCooldown;
		markReadyAtTime = num;
	}

	public static bool IsMarkedEnemy(Enemy enemy)
	{
		//IL_00e9: Expected I4, but got O
		//IL_00a7: Invalid comparison between F4 and I4
		if (markedEnemies != null)
		{
			if (markedEnemies != null)
			{
				int count = markedEnemies.Count;
				if (count <= 0)
				{
					goto IL_00d5;
				}
				if (markedEnemies != null)
				{
					if (!markedEnemies.ContainsKey(enemy))
					{
						goto IL_00d5;
					}
					if (markedEnemies != null)
					{
						float num = ((Dictionary<object, float>)(object)markedEnemies).get_Item((object)enemy);
						bool flag = num < MyTime.time;
						float num2 = num - MyTime.time;
						bool flag2 = num2 == 0f;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						return flag4 & flag3;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_00d5;
		IL_00d5:
		return false;
	}

	public override void Tick()
	{
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Bullseye;
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
		string text = EnumUtility.EnumToReadable(EStat.CritDamage);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 19;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = critDamagePerLevel * 100f;
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

	public unsafe PassiveAbilityBullseye()
	{
		//IL_0071: Expected O, but got Ref
		critDamagePerLevel = 0.01f;
		markDuration = 30f;
		markCooldown = 5f;
		explosionRadius = 10f;
		maxExplosionRadius = 40f;
		explosionDamage = 1f;
		cooldownReductionPerLevel = 0.04f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		DamageContainer damageContainer = new DamageContainer(0f, text);
		reuseDc = damageContainer;
		base._002Ector();
	}
}
