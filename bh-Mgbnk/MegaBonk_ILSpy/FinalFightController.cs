using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning.New.Timelines;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class FinalFightController : MonoBehaviour
{
	public Transform bossSpawnPoint;

	public Enemy boss;

	public BossPylon[] pylons;

	private List<BossPylon> activePylons;

	public GameObject orbFollowing;

	public GameObject orbShooty;

	public GameObject orbBleed;

	public GameObject stealWeaponWui;

	public AudioSource audioPylonsSpawn;

	public static Action<bool> A_BossDefeated;

	public static Action<float> A_BossDefeatedTime;

	public static bool isFightingFinalBoss;

	private int numWeaponsToTake;

	private int numWeaponsTaken;

	private float takeWeaponAtTime;

	private float weaponTakeInterval;

	private float healInterval;

	private float nextHealTime;

	private float bossDeadGracePeriod;

	private int _003CcurrentPhase_003Ek__BackingField;

	private float nextOrbsFollowingTime;

	private float nextOrbsShootyTime;

	private float nextOrbsBleedTime;

	private float lastSpecialAttackTime;

	private float goonsDeadAtTime;

	private float goonSpawnInterval;

	private List<Enemy> goons;

	public static Action A_PylonsStarted;

	public bool isBossDefeated => boss == null;

	public int currentPhase
	{
		get
		{
			return _003CcurrentPhase_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentPhase_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_033c: Expected I, but got O
		//IL_034d: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0113: Expected O, but got I4
		//IL_0156: Expected I, but got O
		//IL_0167: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_040d: Expected I, but got O
		//IL_0455: Expected O, but got I4
		//IL_046b: Expected I, but got O
		//IL_0499: Expected O, but got I4
		//IL_04af: Expected I, but got O
		isFightingFinalBoss = true;
		Action<BossPylon> b = OnPylonCharged;
		Delegate obj = Delegate.Combine(BossPylon.A_Charged, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			BossPylon.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BossPylon> action = default(Action<BossPylon>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<BossPylon>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_04cd;
			}
			BossPylon.A_Charged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<BossPylon>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0389;
			}
		}
		Action<Enemy, DamageContainer> b2 = OnEnemyDamage;
		Delegate obj6 = Delegate.Combine(Enemy.A_Damage, b2);
		if ((object)obj6 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action2 = default(Action<Enemy, DamageContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_03bc;
			}
			Enemy.A_Damage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_03cc;
			}
		}
		Action<Enemy> b3 = OnEnemyReleasedFromPool;
		Delegate obj8 = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b3);
		if ((object)obj8 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action3 = default(Action<Enemy>);
			bool flag4 = action3 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_03dc;
			}
			Enemy.A_EnemyReleasedFromPool = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_03f4;
			}
		}
		num = (nint)PlayerHealth.A_Died;
		Action action4 = OnPlayerDied;
		Delegate obj10 = Delegate.Combine(PlayerHealth.A_Died, action4);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_Died = null;
			return;
		}
		bool flag6 = (object)obj10.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag6)
		{
			obj11 = obj10;
		}
		bool flag7 = (object)obj11 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj10;
		nint num3 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_04bd;
		}
		PlayerHealth.A_Died = (Action)obj11;
		bool flag8 = (object)obj10.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag8)
		{
			obj12 = obj10;
		}
		bool flag9 = (object)obj12 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj10;
		nint num4 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_04cd;
		IL_0389:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04bd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f4;
		IL_04cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04bd;
		IL_03bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0389;
		IL_03f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03dc;
		IL_03cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03bc;
		IL_03dc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03cc;
	}

	private void OnDestroy()
	{
		//IL_033c: Expected I, but got O
		//IL_034d: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0113: Expected O, but got I4
		//IL_0156: Expected I, but got O
		//IL_0167: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_040d: Expected I, but got O
		//IL_0455: Expected O, but got I4
		//IL_046b: Expected I, but got O
		//IL_0499: Expected O, but got I4
		//IL_04af: Expected I, but got O
		isFightingFinalBoss = false;
		Action<BossPylon> value = OnPylonCharged;
		Delegate obj = Delegate.Remove(BossPylon.A_Charged, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			BossPylon.A_Charged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<BossPylon> action = default(Action<BossPylon>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<BossPylon>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_04cd;
			}
			BossPylon.A_Charged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<BossPylon>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0389;
			}
		}
		Action<Enemy, DamageContainer> value2 = OnEnemyDamage;
		Delegate obj6 = Delegate.Remove(Enemy.A_Damage, value2);
		if ((object)obj6 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action2 = default(Action<Enemy, DamageContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_03bc;
			}
			Enemy.A_Damage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_03cc;
			}
		}
		Action<Enemy> value3 = OnEnemyReleasedFromPool;
		Delegate obj8 = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value3);
		if ((object)obj8 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action3 = default(Action<Enemy>);
			bool flag4 = action3 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_03dc;
			}
			Enemy.A_EnemyReleasedFromPool = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<Enemy>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_03f4;
			}
		}
		num = (nint)PlayerHealth.A_Died;
		Action action4 = OnPlayerDied;
		Delegate obj10 = Delegate.Remove(PlayerHealth.A_Died, action4);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_Died = null;
			return;
		}
		bool flag6 = (object)obj10.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag6)
		{
			obj11 = obj10;
		}
		bool flag7 = (object)obj11 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj10;
		nint num3 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_04bd;
		}
		PlayerHealth.A_Died = (Action)obj11;
		bool flag8 = (object)obj10.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag8)
		{
			obj12 = obj10;
		}
		bool flag9 = (object)obj12 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj10;
		nint num4 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_04cd;
		IL_0389:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04bd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f4;
		IL_04cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04bd;
		IL_03bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0389;
		IL_03f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03dc;
		IL_03cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03bc;
		IL_03dc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03cc;
	}

	public unsafe void SpawnBoss()
	{
		//IL_005e: Expected O, but got Ref
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		StageTimeline stageTimeline = stageData.stageTimeline;
		EnemyData enemyData = stageTimeline.boss;
		Vector3 position = bossSpawnPoint.position;
		object obj = default(object);
		Vector3 vector = RaycastUtility.RayToGround((Vector3)(&obj), 10f);
		Vector3 pos = default(Vector3);
		float extraSizeMultiplier = default(float);
		Enemy enemy = EnemyManager.Instance.SpawnBoss(enemyData.enemyName, 0, (EEnemyFlag)36, pos, extraSizeMultiplier);
		boss = enemy;
		Enemy enemy2 = boss;
		enemy2.teleportTime = 3.5f;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int numWeapons = inventory.weaponInventory.GetNumWeapons();
		numWeaponsToTake = numWeapons;
		float num = MyTime.time + 4f;
		takeWeaponAtTime = num;
		float num2 = MyTime.time + 30f;
		nextOrbsFollowingTime = num2;
		float num3 = MyTime.time + 15f;
		nextOrbsShootyTime = num3;
		float num4 = MyTime.time + 45f;
		nextOrbsBleedTime = num4;
		goonsDeadAtTime = MyTime.time;
		isFightingFinalBoss = true;
	}

	private void FixedUpdate()
	{
		//IL_0040: Invalid comparison between I4 and F4
		if (!(boss != null))
		{
			return;
		}
		Enemy enemy = boss;
		if (!(0f < enemy._003Chp_003Ek__BackingField))
		{
			return;
		}
		if (!(nextHealTime > MyTime.time))
		{
			float num = MyTime.time + healInterval;
			nextHealTime = num;
			List<BossPylon> list = activePylons;
			if (activePylons != null && list._size > 0 && boss != null)
			{
				Enemy enemy2 = boss;
				if (enemy2.maxHp > enemy2._003Chp_003Ek__BackingField)
				{
					BossPylon[] array = pylons;
					float num2 = enemy2.maxHp * 0.023f;
					float num3 = num2 / 60f;
					float num4 = num3 * healInterval;
					float num5 = num4 * (float)array.Length;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
					int amount = default(int);
					enemy2.Heal(amount);
				}
			}
		}
		SpecialAttacks();
		if (numWeaponsTaken < numWeaponsToTake && !(takeWeaponAtTime > MyTime.time))
		{
			float num6 = MyTime.time + weaponTakeInterval;
			takeWeaponAtTime = num6;
			TakeWeapon();
			int num7 = numWeaponsTaken + 1;
			numWeaponsTaken = num7;
		}
	}

	private void TakeWeapons()
	{
		if (numWeaponsTaken < numWeaponsToTake && !(takeWeaponAtTime > MyTime.time))
		{
			float num = MyTime.time + weaponTakeInterval;
			takeWeaponAtTime = num;
			TakeWeapon();
			int num2 = numWeaponsTaken + 1;
			numWeaponsTaken = num2;
		}
	}

	private unsafe void OnEnemyReleasedFromPool(Enemy enemy)
	{
		//IL_0107: Expected I, but got O
		//IL_013a: Expected O, but got I
		//IL_0211: Expected O, but got I4
		//IL_06fa: Expected O, but got Ref
		//IL_031a: Expected O, but got I4
		//IL_0336: Expected O, but got I4
		//IL_0356: Expected O, but got I4
		//IL_037c: Expected O, but got Ref
		//IL_046d: Expected I, but got O
		//IL_049e: Expected O, but got I
		//IL_0446: Expected O, but got I4
		//IL_0536: Expected I, but got O
		//IL_0567: Expected O, but got I
		bool flag = goons == null;
		List<object> list = (List<object>)(object)goons;
		if (!flag)
		{
			if (!((List<object>)(object)goons).Contains((object)enemy))
			{
				goto IL_00d8;
			}
			list = (List<object>)(object)goons;
			if (goons != null)
			{
				bool flag2 = ((List<object>)(object)goons).Remove((object)enemy);
				List<Enemy> list2 = goons;
				if (goons != null)
				{
					if (list2._size <= 0)
					{
						goonsDeadAtTime = MyTime.time;
					}
					goto IL_00d8;
				}
			}
		}
		goto IL_05d9;
		IL_05d9:
		BossPylon bossPylon = (BossPylon)(object)list;
		throw new NullReferenceException();
		IL_076d:
		Action<bool> a_BossDefeated = A_BossDefeated;
		if (A_BossDefeated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v487 @ r9_v12 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
		Action<float> a_BossDefeatedTime = A_BossDefeatedTime;
		if (A_BossDefeatedTime != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v497 @ rdx_v32 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_00d8:
		if (!(enemy == boss))
		{
			return;
		}
		nint num = (nint)typeof(FinalFightController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v28 (Il2CppClass<FinalFightController>)+B8]");
		nint num2 = 0;
		isFightingFinalBoss = false;
		bool flag3 = activePylons == null;
		list = (List<object>)num2;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			BossPylon bossPylon2 = default(BossPylon);
			while (enumerator.MoveNext())
			{
				bool flag4 = (object)bossPylon2 == null;
				bossPylon = bossPylon2;
				if (!flag4)
				{
					bossPylon2.Despawn();
					continue;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			list = (List<object>)(object)activePylons;
			if (activePylons != null)
			{
				int version = list._version + 1;
				list._version = version;
				list._size = 0;
				if (list._size > 0)
				{
					Array.Clear(list._items, 0, list._size);
					object obj = 0;
				}
				List<object> list3 = Enumerable.ToList((IEnumerable<object>)goons);
				bool flag5 = list3 == null;
				list = (List<object>)(object)goons;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
					while (enumerator2.MoveNext())
					{
						if ((object)bossPylon2 != null)
						{
							((Enemy)(object)bossPylon2).Kill("Unkown");
							continue;
						}
						throw new NullReferenceException();
					}
					((List<Enemy>.Enumerator*)(&enumerator2))->Dispose();
					list = (List<object>)(&enumerator2);
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null)
						{
							list = (List<object>)(object)inventory.weaponInventory;
							if (inventory.weaponInventory != null)
							{
								bool flag6 = list._size == 0;
								list = (List<object>)list._size;
								if (!flag6)
								{
									Dictionary<EWeapon, WeaponBase>.ValueCollection values = ((Dictionary<EWeapon, WeaponBase>)list._size).Values;
									bool flag7 = values == null;
									list = (List<object>)list._size;
									if (!flag7)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
										Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator3 = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
										while (enumerator3.MoveNext())
										{
											WeaponInventory weaponInventory = (WeaponInventory)(&enumerator3);
											MyPlayer instance2 = MyPlayer.Instance;
											if ((object)MyPlayer.Instance != null)
											{
												PlayerInventory inventory2 = instance2.inventory;
												if (instance2.inventory != null)
												{
													if ((object)bossPylon2 != null)
													{
														CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)bossPylon2).m_CancellationTokenSource;
														if (((MonoBehaviour)bossPylon2).m_CancellationTokenSource != null)
														{
															if (inventory2.weaponInventory != null)
															{
																WeaponInventory weaponInventory2 = inventory2.weaponInventory;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rdx_v35 (System.Threading.CancellationTokenSource)+50]");
																weaponInventory2.ToggleWeapon(EWeapon.FireStaff, enable: true);
																object obj = 0;
																continue;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										enumerator3.Dispose();
										boss = null;
										nint num3 = (nint)typeof(MapController);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1034 @ rax_v55 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
										nint num4 = 0;
										StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
										bool flag8 = (object)MapController._003CcurrentStage_003Ek__BackingField == null;
										list = (List<object>)num4;
										if (!flag8)
										{
											bool flag9 = stageData.stageTimeline == null;
											list = (List<object>)(object)stageData.stageTimeline;
											if (!flag9)
											{
												float stageTime = stageData.stageTimeline.GetStageTime();
												float num5 = stageTime - bossDeadGracePeriod;
												if (!(num5 > MyTime.stageTimer))
												{
													goto IL_076d;
												}
												nint num6 = (nint)typeof(MapController);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1140 @ rax_v66 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
												nint num7 = 0;
												StageData stageData2 = MapController._003CcurrentStage_003Ek__BackingField;
												bool flag10 = (object)MapController._003CcurrentStage_003Ek__BackingField == null;
												list = (List<object>)num7;
												if (!flag10)
												{
													bool flag11 = stageData2.stageTimeline == null;
													list = (List<object>)(object)stageData2.stageTimeline;
													if (!flag11)
													{
														num5 = stageData2.stageTimeline.GetStageTime();
														float stageTimer = num5 - bossDeadGracePeriod;
														MyTime.stageTimer = stageTimer;
														goto IL_076d;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05d9;
	}

	private unsafe void OnPlayerDied()
	{
		//IL_0058: Expected O, but got Ref
		//IL_00b9: Expected O, but got I
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator2 = (Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator)(&enumerator);
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory2 = instance2.inventory;
					if (instance2.inventory != null)
					{
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ stack_-30+18]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ stack_-30+18]");
							if ((nint)0 == 0)
							{
								break;
							}
							WeaponInventory weaponInventory2 = inventory2.weaponInventory;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rdx_v10+50]");
							weaponInventory2.ToggleWeapon(EWeapon.FireStaff, enable: true);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private void StartPhase(int phase)
	{
		_003CcurrentPhase_003Ek__BackingField = phase;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x180494F80\"");
	}

	public unsafe void TakeWeapon()
	{
		//IL_01e3: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
		List<object> list = Enumerable.ToList((IEnumerable<object>)values);
		bool flag = (nint)list < 0;
		int num = list._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			if (num != 0)
			{
				WeaponBase weaponBase = ((List<WeaponBase>)(object)list).get_Item(num);
				if (!weaponBase._003Cenabled_003Ek__BackingField)
				{
					num--;
					if ((weaponBase._003Cenabled_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0))
					{
						return;
					}
					continue;
				}
				break;
			}
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		WeaponBase weaponBase2 = ((List<WeaponBase>)(object)list).get_Item(num);
		WeaponData weaponData = weaponBase2.weaponData;
		inventory2.weaponInventory.ToggleWeapon(weaponData.eWeapon, enable: false);
		WeaponBase weaponBase3 = ((List<WeaponBase>)(object)list).get_Item(num);
		Transform target = boss.transform;
		Vector3 centerPosition = boss.GetCenterPosition();
		Transform transform = boss.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		float hoverTime = default(float);
		float moveTime = default(float);
		float scale = default(float);
		EffectManager.Instance.TakeItem(weaponBase3.weaponData, target, (Vector3)(&obj), hoverTime, moveTime, scale);
	}

	private void GiveWeaponBack()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
		List<object> list = Enumerable.ToList((IEnumerable<object>)values);
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < list._size)
			{
				WeaponBase weaponBase = ((List<WeaponBase>)(object)list).get_Item(num);
				if (weaponBase._003Cenabled_003Ek__BackingField)
				{
					num++;
					num2 = num;
					continue;
				}
				break;
			}
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		WeaponBase weaponBase2 = ((List<WeaponBase>)(object)list).get_Item(num);
		WeaponData weaponData = weaponBase2.weaponData;
		inventory2.weaponInventory.ToggleWeapon(weaponData.eWeapon, enable: true);
		WeaponBase weaponBase3 = ((List<WeaponBase>)(object)list).get_Item(num);
		EffectManager.Instance.GiveItem(weaponBase3.weaponData);
	}

	private void SpecialAttacks()
	{
		if (MyTime.time > nextOrbsFollowingTime)
		{
			SpawnOrbsFollowing();
			float num = (float)_003CcurrentPhase_003Ek__BackingField * 6f;
			float num2 = 45f - num;
			float minInclusive = num2 * 0.6f;
			float maxInclusive = num2 * 1.4f;
			float num3 = UnityEngine.Random.Range(minInclusive, maxInclusive);
			float num4 = num3 + MyTime.time;
			nextOrbsFollowingTime = num4;
		}
		if (MyTime.time > nextOrbsShootyTime)
		{
			SpawnOrbsShooty();
			float num5 = (float)_003CcurrentPhase_003Ek__BackingField * 6f;
			float num6 = 45f - num5;
			float minInclusive2 = num6 * 0.6f;
			float maxInclusive2 = num6 * 1.4f;
			float num7 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
			float num8 = num7 + MyTime.time;
			nextOrbsShootyTime = num8;
		}
		if (MyTime.time > nextOrbsBleedTime)
		{
			SpawnOrbsBleed();
			float num9 = (float)_003CcurrentPhase_003Ek__BackingField * 6f;
			float num10 = 45f - num9;
			float minInclusive3 = num10 * 0.6f;
			float maxInclusive3 = num10 * 1.4f;
			float num11 = UnityEngine.Random.Range(minInclusive3, maxInclusive3);
			float num12 = num11 + MyTime.time;
			nextOrbsBleedTime = num12;
		}
		float num13 = goonSpawnInterval + goonsDeadAtTime;
		if (MyTime.time > num13)
		{
			List<Enemy> list = goons;
			if (list._size <= 0)
			{
				SpawnGoons();
			}
		}
	}

	private unsafe void SpawnOrbsFollowing()
	{
		//IL_01a4: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_01f8: Expected O, but got I4
		//IL_004b: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		List<GameObject> list = new List<GameObject>();
		object obj = 0;
		float x = default(float);
		Quaternion identityQuaternion = default(Quaternion);
		int numOrbs = default(int);
		int orbIndex = default(int);
		int num = default(int);
		while (true)
		{
			object obj2 = _003CcurrentPhase_003Ek__BackingField + 1;
			bool flag = (nint)obj2 >= 3;
			object obj3 = 3;
			if (!flag)
			{
				obj3 = obj2;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				break;
			}
			Transform transform = boss.transform;
			Vector3 position = transform.position;
			GameObject gameObject = UnityEngine.Object.Instantiate(orbFollowing, (Vector3)(&x), (Quaternion)(&identityQuaternion));
			BossOrb component = gameObject.GetComponent<BossOrb>();
			float startDelay = (float)obj * 0.5f;
			component.Set(startDelay, _003CcurrentPhase_003Ek__BackingField, boss, numOrbs, orbIndex);
			int version = list._version + 1;
			list._version = version;
			GameObject[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)gameObject);
				obj++;
				x = position.x;
				identityQuaternion = Quaternion.identityQuaternion;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				items[num] = gameObject;
				obj++;
				x = position.x;
				identityQuaternion = Quaternion.identityQuaternion;
			}
		}
		IgnoreCollisions(list);
	}

	private unsafe void SpawnOrbsShooty()
	{
		//IL_018e: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		//IL_01e2: Expected O, but got I4
		//IL_0039: Expected O, but got Ref
		//IL_0039: Expected O, but got Ref
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		List<GameObject> list = new List<GameObject>();
		object obj = 0;
		float x = default(float);
		Quaternion identityQuaternion = default(Quaternion);
		int orbIndex = default(int);
		int num = default(int);
		while (true)
		{
			object obj2 = _003CcurrentPhase_003Ek__BackingField + 1;
			bool flag = (nint)obj2 >= 3;
			object obj3 = 3;
			if (!flag)
			{
				obj3 = obj2;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				break;
			}
			Vector3 centerPosition = boss.GetCenterPosition();
			GameObject gameObject = UnityEngine.Object.Instantiate(orbShooty, (Vector3)(&x), (Quaternion)(&identityQuaternion));
			BossOrbShooty component = gameObject.GetComponent<BossOrbShooty>();
			int numOrbs = _003CcurrentPhase_003Ek__BackingField + 1;
			component.Set(boss, _003CcurrentPhase_003Ek__BackingField, numOrbs, orbIndex);
			int version = list._version + 1;
			list._version = version;
			GameObject[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)gameObject);
				obj++;
				x = centerPosition.x;
				identityQuaternion = Quaternion.identityQuaternion;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				items[num] = gameObject;
				obj++;
				x = centerPosition.x;
				identityQuaternion = Quaternion.identityQuaternion;
			}
		}
		IgnoreCollisions(list);
	}

	private unsafe void SpawnOrbsBleed()
	{
		//IL_01a0: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_004b: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		List<GameObject> list = new List<GameObject>();
		object obj = 0;
		float x = default(float);
		Quaternion identityQuaternion = default(Quaternion);
		int orbIndex = default(int);
		int num = default(int);
		while (true)
		{
			object obj2 = _003CcurrentPhase_003Ek__BackingField + 1;
			bool flag = (nint)obj2 >= 3;
			object obj3 = 3;
			if (!flag)
			{
				obj3 = obj2;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				break;
			}
			Transform transform = boss.transform;
			Vector3 position = transform.position;
			GameObject gameObject = UnityEngine.Object.Instantiate(orbBleed, (Vector3)(&x), (Quaternion)(&identityQuaternion));
			BossOrbBleed component = gameObject.GetComponent<BossOrbBleed>();
			int numOrbs = _003CcurrentPhase_003Ek__BackingField + 1;
			component.Set(boss, _003CcurrentPhase_003Ek__BackingField, numOrbs, orbIndex);
			int version = list._version + 1;
			list._version = version;
			GameObject[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)gameObject);
				obj++;
				x = position.x;
				identityQuaternion = Quaternion.identityQuaternion;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				items[num] = gameObject;
				obj++;
				x = position.x;
				identityQuaternion = Quaternion.identityQuaternion;
			}
		}
		IgnoreCollisions(list);
	}

	private int GetNumOrbs()
	{
		int num = _003CcurrentPhase_003Ek__BackingField + 1;
		bool flag = num >= 3;
		int result = 3;
		if (!flag)
		{
			result = num;
		}
		return result;
	}

	private void IgnoreCollisions(List<GameObject> orbs)
	{
		int num = 0;
		for (int num2 = 0; num2 < orbs._size; num2 = num)
		{
			GameObject gameObject = orbs.get_Item(num);
			Collider component = gameObject.GetComponent<Collider>();
			if (component != null)
			{
				for (int i = num + 1; i < orbs._size; i++)
				{
					GameObject gameObject2 = orbs.get_Item(i);
					Collider component2 = gameObject2.GetComponent<Collider>();
					if (component2 != null)
					{
						Physics.IgnoreCollision(component, component2);
					}
				}
			}
			num++;
		}
	}

	private void SpawnGoons()
	{
		//IL_0015: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		List<Enemy> list = new List<Enemy>();
		goons = list;
		object obj = _003CcurrentPhase_003Ek__BackingField + 2;
		if ((nint)obj <= 0)
		{
			return;
		}
		object obj2 = 0;
		EEnemyFlag flag = default(EEnemyFlag);
		bool useDirectionBias = default(bool);
		do
		{
			MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
			StageData[] stages = mapData.stages;
			StageData stageData = stages[0];
			StageTimeline stageTimeline = stageData.stageTimeline;
			EnemyData enemyData = stageTimeline.boss;
			EnemyData enemyData2 = DataManager.Instance.GetEnemyData(enemyData.enemyName);
			Enemy enemy = EnemyManager.Instance.SpawnEnemy(enemyData2, 0, forceSpawn: true, flag, useDirectionBias);
			if (enemy != null)
			{
				enemy.DisableSpecialAttacks();
				enemy.speedMultiplier = 0.6f;
				Enemy enemy2 = boss;
				enemy.SetMinibossGoon(enemy.maxHp = enemy2.maxHp * 0.06f);
				goons.Add(enemy);
			}
			obj2++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
	}

	private bool ArePylonsActive()
	{
		List<BossPylon> list = activePylons;
		if (activePylons != null && list._size > 0)
		{
			return boss != null;
		}
		return false;
	}

	private void OnPylonCharged(BossPylon pylon)
	{
		bool flag = ((List<object>)(object)activePylons).Remove((object)pylon);
		List<BossPylon> list = activePylons;
		if (list._size <= 0)
		{
			boss.MakeInvulnerable(invulnerable: false);
			GiveWeaponBack();
		}
	}

	private void PylonsDone()
	{
		boss.MakeInvulnerable(invulnerable: false);
		GiveWeaponBack();
	}

	private unsafe void StartPylons()
	{
		//IL_04a2: Expected O, but got I4
		//IL_00c2: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_0120: Expected I4, but got O
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0353: Expected O, but got I4
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_03f5: Expected I, but got O
		bool flag = (object)boss == null;
		List<int> list = (List<int>)(object)boss;
		if (!flag)
		{
			boss.MakeInvulnerable(invulnerable: true);
			List<BossPylon> list2 = new List<BossPylon>();
			activePylons = list2;
			List<int> list3 = new List<int>();
			BossPylon[] array = pylons;
			bool flag2 = pylons == null;
			list = list3;
			if (!flag2)
			{
				List<int> list4 = null;
				list = null;
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				BossPylon bossPylon = default(BossPylon);
				while (true)
				{
					if ((nint)list < array.Length)
					{
						if (list3 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+10]");
						list = (List<int>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32>)+18]");
						if (num >= 0)
						{
							list3.AddWithResize((int)list4);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32>)+18]");
							if (num2 >= 0)
							{
								goto IL_0449;
							}
						}
						list4 = (List<int>)(list4 + 1);
						array = pylons;
						bool flag3 = pylons == null;
						list = list4;
						if (flag3)
						{
							break;
						}
						list = list4;
						continue;
					}
					bool flag4 = list3 == null;
					object obj2 = 0;
					if (flag4)
					{
						break;
					}
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
						int index = UnityEngine.Random.Range(0, 0);
						int num3 = list3.get_Item(index);
						list3.RemoveAt(index);
						BossPylon[] array2 = pylons;
						if (pylons == null)
						{
							break;
						}
						if (num3 < array2.Length)
						{
							List<object> list5 = (List<object>)(object)activePylons;
							if (activePylons == null)
							{
								break;
							}
							int version = list5._version + 1;
							list5._version = version;
							object[] items = list5._items;
							if (list5._items == null)
							{
								break;
							}
							int size = list5._size;
							if (list5._size >= items.Length)
							{
								((List<object>)(object)activePylons).AddWithResize((object)array2[num3]);
							}
							else
							{
								int size2 = list5._size + 1;
								list5._size = size2;
								if (list5._size >= items.Length)
								{
									goto IL_0449;
								}
								items[size] = array2[num3];
								items = (object[])(items + 32);
								object obj3 = list5._size * 8;
								list = (List<int>)(object)((object)items + obj3);
							}
							obj2++;
							if ((nint)obj2 < 3)
							{
								continue;
							}
							goto IL_0390;
						}
						goto IL_0449;
					}
					break;
					IL_0390:
					if (activePylons == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					nint num4 = 0;
					while (enumerator.MoveNext())
					{
						if ((object)bossPylon != null)
						{
							bossPylon.Set(boss);
							num4 = unchecked((nint)null);
							continue;
						}
						throw new NullReferenceException();
					}
					((List<BossPylon>.Enumerator*)(&enumerator))->Dispose();
					if ((object)audioPylonsSpawn == null)
					{
						break;
					}
					audioPylonsSpawn.Play();
					Action a_PylonsStarted = A_PylonsStarted;
					if (A_PylonsStarted != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v579.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					return;
					IL_0449:
					throw new IndexOutOfRangeException();
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PylonHealing()
	{
		if (nextHealTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + healInterval;
		nextHealTime = num;
		List<BossPylon> list = activePylons;
		if (activePylons != null && list._size > 0 && boss != null)
		{
			Enemy enemy = boss;
			if (enemy.maxHp > enemy._003Chp_003Ek__BackingField)
			{
				BossPylon[] array = pylons;
				float num2 = enemy.maxHp * 0.023f;
				float num3 = num2 / 60f;
				float num4 = num3 * healInterval;
				float num5 = num4 * (float)array.Length;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
				int amount = default(int);
				enemy.Heal(amount);
			}
		}
	}

	private void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
		//IL_0066: Invalid comparison between I4 and F4
		if (!(enemy == boss) || !(boss != null))
		{
			return;
		}
		Enemy enemy2 = boss;
		if (!(0f < enemy2._003Chp_003Ek__BackingField))
		{
			return;
		}
		float num = enemy2._003Chp_003Ek__BackingField / enemy2.maxHp;
		if (_003CcurrentPhase_003Ek__BackingField <= 2 && !(0.25f < num))
		{
			_003CcurrentPhase_003Ek__BackingField = 3;
		}
		else if (_003CcurrentPhase_003Ek__BackingField <= 1 && !(0.5f < num))
		{
			_003CcurrentPhase_003Ek__BackingField = 2;
		}
		else
		{
			if (_003CcurrentPhase_003Ek__BackingField > 0 || 0.75f < num)
			{
				return;
			}
			_003CcurrentPhase_003Ek__BackingField = 1;
		}
		StartPylons();
	}

	public FinalFightController()
	{
		List<BossPylon> list = new List<BossPylon>();
		activePylons = list;
		weaponTakeInterval = 3f;
		healInterval = 0.5f;
		bossDeadGracePeriod = 10f;
		goonSpawnInterval = 60f;
		goons = new List<Enemy>();
		base._002Ector();
	}
}
