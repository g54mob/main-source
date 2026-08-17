using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Pickups;
using UnityEngine;
using UnityEngine.Pool;
using Utility;

public class PickupManager : MonoBehaviour
{
	public LayerMask whatIsPickups;

	public GameObject hastePrefab;

	public GameObject healthPrefab;

	public GameObject magnetPrefab;

	public GameObject nukePrefab;

	public GameObject ragePrefab;

	public GameObject shieldPrefab;

	public GameObject stonksPrefab;

	public GameObject timeFreezePrefab;

	private PickupStackableList xpList;

	private PickupStackableList goldList;

	private float stackRadius;

	private float stackRadiusMin;

	private float stackRadiusMax;

	private float stackRadiusMaxTime;

	public static int maxXpObjects;

	public static int maxGoldObjects;

	public static PickupManager Instance;

	private Vector3 hoverHeight;

	private EPickup[] powerups;

	private float lastPowerupAtTime;

	public static int maxPowerupsOnMap;

	private int numPowerupsOnMap;

	private static readonly Collider[] overlapResults;

	private void Awake()
	{
		//IL_00c8: Expected I, but got O
		//IL_0139: Expected I, but got O
		if (!(Instance == null))
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		Instance = this;
		PickupStackableList pickupStackableList = new PickupStackableList(maxXpObjects, EPickup.Xp);
		xpList = pickupStackableList;
		PickupStackableList pickupStackableList2 = new PickupStackableList(maxGoldObjects, EPickup.Gold);
		goldList = pickupStackableList2;
		InvokeRepeating("SlowUpdate", 0f, 10f);
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj2 = Delegate.Combine(Enemy.A_EnemyDied, b);
		if ((object)obj2 == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj2;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		bool flag = action == null;
		nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		if (!flag)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj3 = default(object);
			if (obj3 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00d3: Expected I, but got O
		//IL_00ac: Expected I, but got O
		if (!(Instance == this))
		{
			return;
		}
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void SlowUpdate()
	{
		//IL_0024: Invalid comparison between I4 and F4
		//IL_006f: Expected F4, but got I4
		//IL_00c7: Invalid comparison between I4 and F4
		//IL_00ab: Expected F4, but got I4
		GameManager instance = GameManager.Instance;
		float num = instance.gameTimer / stackRadiusMaxTime;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = stackRadiusMax - stackRadiusMin;
		float num3 = num2 * num;
		float num4 = num3 + stackRadiusMin;
		stackRadius = num4;
	}

	private unsafe void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_07a9: Expected O, but got I
		//IL_07b2: Expected O, but got I4
		//IL_07c2: Expected O, but got I
		//IL_07ef: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_0828: Expected O, but got Ref
		//IL_0170: Expected O, but got I
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_0198: Expected O, but got I
		//IL_01d2: Expected O, but got I
		//IL_01ee: Expected I, but got O
		//IL_01f6: Expected I, but got O
		//IL_0206: Expected O, but got I
		//IL_0258: Expected O, but got I
		//IL_0a71: Invalid comparison between I4 and F4
		//IL_04c1: Expected F4, but got I4
		//IL_02c4: Expected I, but got O
		//IL_08bb: Expected O, but got F4
		//IL_08d3: Invalid comparison between F4 and I4
		//IL_08e2: Invalid comparison between F4 and I4
		//IL_08f1: Invalid comparison between I4 and F4
		//IL_0562: Expected F4, but got I4
		//IL_0731: Expected O, but got Ref
		//IL_0964: Expected O, but got I4
		//IL_096c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0971: Expected O, but got Unknown
		//IL_04e4: Expected O, but got F4
		//IL_04f1: Expected O, but got F4
		//IL_0516: Invalid comparison between F4 and I4
		//IL_0525: Invalid comparison between F4 and I4
		//IL_05a4: Expected I, but got O
		//IL_05b4: Expected O, but got I
		//IL_066c: Expected O, but got Ref
		//IL_09ec: Expected I, but got O
		//IL_09f4: Expected O, but got Ref
		Vector3 position;
		int num;
		nint num2;
		nint num4 = default(nint);
		DamageContainer damageContainer;
		NullReferenceException ex;
		if ((object)enemy != null)
		{
			Transform transform = enemy.transform;
			if ((object)transform != null)
			{
				position = transform.position;
				MyPlayer instance = MyPlayer.Instance;
				bool flag = (object)MyPlayer.Instance == null;
				damageContainer = null;
				if (!flag)
				{
					PlayerInventory inventory = instance.inventory;
					bool flag2 = instance.inventory == null;
					damageContainer = null;
					if (!flag2)
					{
						ItemInventory itemInventory = inventory.itemInventory;
						bool flag3 = inventory.itemInventory == null;
						damageContainer = null;
						if (!flag3)
						{
							bool flag4 = itemInventory.items == null;
							damageContainer = null;
							if (!flag4)
							{
								bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)32);
								bool flag6 = !flag5;
								num = 1;
								num2 = 0;
								if (flag6)
								{
									goto IL_078f;
								}
								MyPlayer instance2 = MyPlayer.Instance;
								bool flag7 = (object)MyPlayer.Instance == null;
								damageContainer = (DamageContainer)0;
								if (!flag7)
								{
									PlayerInventory inventory2 = instance2.inventory;
									bool flag8 = instance2.inventory == null;
									damageContainer = (DamageContainer)0;
									if (!flag8)
									{
										ItemInventory itemInventory2 = inventory2.itemInventory;
										bool flag9 = inventory2.itemInventory == null;
										damageContainer = (DamageContainer)0;
										if (!flag9)
										{
											bool flag10 = itemInventory2.items == null;
											damageContainer = (DamageContainer)0;
											if (!flag10)
											{
												object obj = ((Dictionary<System.Int32Enum, object>)(object)itemInventory2.items).get_Item((System.Int32Enum)32);
												bool flag11 = obj == null;
												damageContainer = (DamageContainer)0;
												if (!flag11)
												{
													nint num3 = (nint)typeof(ItemEchoShard);
													num4 = (nint)obj;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ r8_v21 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemEchoShard>)+130]");
													object obj2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r9_v8 (Il2CppMethodInfo)+130]");
													nint num5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ r8_v21 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemEchoShard>)+130]");
													bool flag12 = num5 < 0;
													damageContainer = (DamageContainer)(object)typeof(ItemEchoShard);
													ex = (NullReferenceException)obj;
													if (!flag12)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r9_v8 (Il2CppMethodInfo)+C8]");
														object obj3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rcx_v65+FFFFFFF8+v487 @ rcx_v64*8]");
														bool flag13 = 0 != (nint)typeof(ItemEchoShard);
														damageContainer = (DamageContainer)(object)typeof(ItemEchoShard);
														ex = (NullReferenceException)obj;
														if (!flag13)
														{
															int extraShards = ((ItemEchoShard)obj).GetExtraShards();
															num = extraShards + 1;
															num2 = (nint)typeof(ItemEchoShard);
															goto IL_078f;
														}
													}
													goto IL_07fd;
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
		goto IL_0737;
		IL_083b:
		float x = default(float);
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			if (playerInventory != null && playerInventory.statusEffects != null)
			{
				if (!playerInventory.statusEffects.HasStatusEffect(EStatusEffect.Stonks))
				{
					return;
				}
				Transform transform2 = enemy.transform;
				bool flag14 = (object)transform2 == null;
				damageContainer = null;
				if (!flag14)
				{
					Vector3 position2 = transform2.position;
					bool flag15 = (object)EffectManager.Instance == null;
					damageContainer = null;
					if (!flag15)
					{
						EffectManager.Instance.GoldBurstEffect((Vector3)(&x));
						return;
					}
				}
			}
		}
		goto IL_0737;
		IL_07fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		throw new IndexOutOfRangeException();
		IL_078f:
		bool flag16 = num <= 0;
		damageContainer = (DamageContainer)num2;
		object obj4 = 0;
		nint num6 = num4;
		DamageContainer damageContainer2 = (DamageContainer)num2;
		if (!flag16)
		{
			bool useRandomOffsetPosition = default(bool);
			float pickupDelay = default(float);
			bool flag20;
			do
			{
				bool flag17 = ChallengesTracker.HasChallengeModifier("no_xp");
				num4 = num6;
				damageContainer = damageContainer2;
				if (flag17)
				{
					break;
				}
				int num7 = enemy.GetXp();
				if (obj4 != null)
				{
					num7 = 1;
				}
				Pickup pickup = SpawnPickup(EPickup.Xp, (Vector3)(&x), num7, useRandomOffsetPosition, pickupDelay);
				if (!(pickup != null) || obj4 == null)
				{
					goto IL_03e0;
				}
				bool flag18 = (object)pickup == null;
				num4 = num7;
				damageContainer = null;
				if (!flag18)
				{
					XpVisuals component = pickup.GetComponent<XpVisuals>();
					bool flag19 = (object)component == null;
					num4 = num7;
					damageContainer = null;
					if (!flag19)
					{
						component.SetEchoXp();
						goto IL_03e0;
					}
				}
				goto IL_0737;
				IL_03e0:
				obj4++;
				flag20 = (nint)obj4 < num;
				x = position.x;
				num4 = num7;
				damageContainer = null;
				x = position.x;
				num6 = num7;
				damageContainer2 = null;
			}
			while (flag20);
		}
		if ((object)EnemyManager.Instance != null)
		{
			if (EnemyManager.Instance.IsFinalSwarm() || numPowerupsOnMap >= maxPowerupsOnMap)
			{
				goto IL_083b;
			}
			if (MyRandom.random != null)
			{
				double num8 = MyRandom.random.NextDouble();
				float stat = PlayerStats.GetStat(EStat.PowerupChance);
				float num9 = MyTime.time - lastPowerupAtTime;
				float num10 = num9 / 120f;
				if (!(0f > num10))
				{
					if (num10 > 1f)
					{
						num10 = 1f;
					}
				}
				else
				{
					num10 = 0f;
				}
				float num11 = 0f - num10;
				object obj5 = num10 & num11;
				bool flag21 = (nint)obj5 < 0;
				bool flag22 = num11 < 0f;
				bool flag23 = num11 == 0f;
				if (!(0f > num10))
				{
					float num12 = num10 - 1f;
					object obj6 = num10 ^ 1f;
					object obj7 = num10 ^ num12;
					object obj8 = obj6 & obj7;
					flag21 = (nint)obj8 < 0;
					flag22 = num12 < 0f;
					flag23 = num12 == 0f;
					if (num10 > 1f)
					{
						num10 = 1f;
					}
				}
				else
				{
					num10 = 0f;
				}
				float num13 = num10 + num10;
				float num14 = enemy.basePowerupDropChance * stat;
				float num15 = num13 * num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm8\"");
				bool flag24 = flag22 == flag21;
				object obj9 = !flag24;
				object obj10 = obj9 | flag23;
				float num16 = 1f;
				if (obj10 != null)
				{
					goto IL_083b;
				}
				EPickup[] array = powerups;
				damageContainer = (DamageContainer)(object)powerups;
				bool flag25 = powerups == null;
				num16 = 1f;
				if (!flag25)
				{
					System.Random random = MyRandom.random;
					bool flag26 = MyRandom.random == null;
					num16 = 1f;
					if (!flag26)
					{
						nint num17 = (nint)random;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v11 (Assets.Scripts.Actors.DamageContainer)+18]");
						damageContainer = (DamageContainer)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v70 (Il2CppClass<System.Random>)+1A0]");
						num4 = 0;
						System.Random random2 = MyRandom.random;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r8_v11 (Assets.Scripts.Actors.DamageContainer)+18]");
						int num18 = random2.Next(0, 0);
						bool flag27 = powerups == null;
						num16 = 1f;
						if (!flag27)
						{
							Vector3 centerPosition = enemy.GetCenterPosition();
							bool flag28 = (object)EffectManager.Instance == null;
							num16 = 1f;
							damageContainer = null;
							if (!flag28)
							{
								num15 = centerPosition.x;
								EffectManager.Instance.SpawnPickupOrb((EPickup)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[num18]), (Vector3)(&x));
								lastPowerupAtTime = MyTime.time;
								num16 = 1f;
								x = centerPosition.x;
								num4 = unchecked((nint)null);
								damageContainer = (DamageContainer)(&x);
								goto IL_083b;
							}
						}
					}
				}
			}
		}
		goto IL_0737;
		IL_0737:
		ex = new NullReferenceException();
		goto IL_07fd;
	}

	private EPickup GetRandomPowerup()
	{
		//IL_006e: Expected I4, but got O
		EPickup[] array = powerups;
		EPickup[] array2 = powerups;
		int num = MyRandom.random.Next(0, array2.Length);
		if (num < array.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rbx_v1 (Assets.Scripts.Inventory__Items__Pickups.Pickups.EPickup[])+20+v77 @ rax_v10 (System.Int32)*4]");
			return EPickup.Xp;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (EPickup)ex;
	}

	private float GetPowerupDropChance(Enemy enemy)
	{
		//IL_010f: Invalid comparison between I4 and F4
		//IL_004a: Expected F4, but got I4
		//IL_0099: Invalid comparison between I4 and F4
		//IL_0086: Expected F4, but got I4
		float stat = PlayerStats.GetStat(EStat.PowerupChance);
		float num = MyTime.time - lastPowerupAtTime;
		float num2 = num / 120f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = enemy.basePowerupDropChance * stat;
		float num4 = num2 + num2;
		return num4 * num3;
	}

	private float GetPowerupTimeMultiplier()
	{
		//IL_00e6: Invalid comparison between I4 and F4
		//IL_003c: Expected F4, but got I4
		//IL_0093: Invalid comparison between I4 and F4
		//IL_0080: Expected F4, but got I4
		float num = MyTime.time - lastPowerupAtTime;
		float num2 = num / 120f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				return 1f + 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		return num2 + num2;
	}

	public unsafe Pickup SpawnPickup(EPickup ePickup, Vector3 pos, int value, bool useRandomOffsetPosition = true, float pickupDelay = 0f)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_009c: Expected native int or pointer, but got O
		//IL_00a9: Expected native int or pointer, but got O
		//IL_00b6: Expected native int or pointer, but got O
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_01d3: Expected O, but got I8
		//IL_01ed: Expected O, but got I8
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0199: Expected native int or pointer, but got O
		//IL_01a6: Expected native int or pointer, but got O
		//IL_01b3: Expected native int or pointer, but got O
		//IL_01c1: Expected O, but got I4
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0257: Expected F4, but got I
		_ = 0;
		_ = 0;
		float x = pos.x;
		object obj = default(object);
		Vector3 pos2 = (Vector3)(obj - 80);
		_ = pos.x;
		_ = pos.z;
		Vector3 vector = RaycastUtility.RayToGround(pos2);
		float num = (float)hoverHeight + vector.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PickupManager)+8C]");
		float num2 = 0f + vector.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PickupManager)+90]");
		float num3 = 0f + vector.z;
		((Vector3*)(nint)pos)->x = num;
		((Vector3*)(nint)pos)->y = num2;
		((Vector3*)(nint)pos)->z = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rsp+50]");
		if ((nint)0 != 0)
		{
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			object obj2 = obj - 80;
			object obj3 = obj - 64;
			_ = insideUnitSphere.x;
			_ = insideUnitSphere.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Vector3 v = (Vector3)(obj - 80);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v23+8]");
			_ = 0;
			vector = VectorExtensions.XZVector(v);
			float x2 = num + vector.x;
			float y = num2 + vector.y;
			float z = num3 + vector.z;
			((Vector3*)(nint)pos)->x = x2;
			((Vector3*)(nint)pos)->y = y;
			((Vector3*)(nint)pos)->z = z;
			Vector3 vector2 = (Vector3)0;
		}
		if (ePickup <= EPickup.Magnet)
		{
			object obj4 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v8+4DF15C+ePickup @ rdx (Assets.Scripts.Inventory__Items__Pickups.Pickups.EPickup)*4]");
			object obj5 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v131 @ rcx_v16 (should have been resolved before IL gen)");
		}
		if ((UnityEngine.Object)null != (UnityEngine.Object)null)
		{
			Vector3 pos3 = (Vector3)(obj - 80);
			_ = pos.x;
			_ = pos.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rsp+58]");
			((Pickup)null).Set(pos3, value, 0f);
		}
		return null;
	}

	public void CountAdd()
	{
		int num = numPowerupsOnMap + 1;
		numPowerupsOnMap = num;
	}

	public void PowerupCountRemove()
	{
		int num = numPowerupsOnMap - 1;
		numPowerupsOnMap = num;
	}

	public bool CanSpawnPowerup()
	{
		//IL_003a: Expected I4, but got O
		//IL_004f: Expected O, but got I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected I4, but got Unknown
		if ((object)EnemyManager.Instance != null)
		{
			if (EnemyManager.Instance.IsFinalSwarm())
			{
				return false;
			}
			object obj = numPowerupsOnMap - maxPowerupsOnMap;
			int num = numPowerupsOnMap ^ maxPowerupsOnMap;
			int num2 = numPowerupsOnMap ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			return flag2 != flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private Pickup SpawnPooledPickup(EPickup ePickup)
	{
		//IL_0051: Expected I, but got O
		//IL_007c: Expected I, but got O
		//IL_00b4: Expected I, but got O
		PoolManager instance = PoolManager.Instance;
		bool flag = (object)PoolManager.Instance == null;
		EPickup ePickup2 = ePickup;
		if (!flag)
		{
			bool flag2 = instance.powerupPool == null;
			ePickup2 = ePickup;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
				UnityEngine.Object obj = default(UnityEngine.Object);
				bool flag3 = obj != null;
				nint num = unchecked((nint)null);
				ePickup2 = EPickup.Xp;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					Exception ex = new Exception("Pickup is null? Need to fix this, shouldn't try to spawn a new powerup if max limit is already reached");
					ex._002Ector("Pickup is null? Need to fix this, shouldn't try to spawn a new powerup if max limit is already reached");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex;
				}
				bool flag4 = (object)obj == null;
				num = unchecked((nint)null);
				ePickup2 = EPickup.Xp;
				if (!flag4)
				{
					GenericPowerupPrefab component = ((GameObject)obj).GetComponent<GenericPowerupPrefab>();
					bool flag5 = (object)component == null;
					num = unchecked((nint)null);
					ePickup2 = EPickup.Xp;
					if (!flag5)
					{
						component.Set(ePickup);
						return ((GameObject)obj).GetComponent<Pickup>();
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void PickupTriggered(Pickup pickup)
	{
		EffectManager.Instance.PickupEffect();
		PickupStackableList pickupStackableList;
		if (pickup.ePickup == EPickup.Xp)
		{
			pickupStackableList = xpList;
		}
		else
		{
			if (pickup.ePickup != EPickup.Gold)
			{
				goto IL_013d;
			}
			pickupStackableList = goldList;
		}
		pickupStackableList.RemovePickup(pickup);
		goto IL_013d;
		IL_013d:
		ObjectPool<GameObject> objectPool;
		if (pickup.ePickup != EPickup.Xp)
		{
			if (pickup.ePickup != EPickup.Gold)
			{
				PoolManager instance = PoolManager.Instance;
				GameObject element = pickup.gameObject;
				instance.powerupPool.Release(element);
				int num = numPowerupsOnMap - 1;
				numPowerupsOnMap = num;
				return;
			}
			PoolManager instance2 = PoolManager.Instance;
			objectPool = instance2.goldPool;
		}
		else
		{
			PoolManager instance3 = PoolManager.Instance;
			objectPool = instance3.xpPool;
		}
		GameObject element2 = pickup.gameObject;
		objectPool.Release(element2);
	}

	public unsafe void PickupAllXp()
	{
		//IL_000e: Expected O, but got Ref
		LinkedList<object>.Enumerator enumerator2 = default(LinkedList<object>.Enumerator);
		LinkedList<object>.Enumerator enumerator = ((LinkedList<object>)(&enumerator2)).GetEnumerator();
		LinkedList<object>.Enumerator enumerator3 = default(LinkedList<object>.Enumerator);
		Pickup pickup = default(Pickup);
		while (true)
		{
			if (enumerator3.MoveNext())
			{
				if ((object)GameManager.Instance != null)
				{
					MyPlayer player = GameManager.Instance.GetPlayer();
					if ((object)player == null)
					{
						break;
					}
					Transform target = player.transform;
					pickup.StartFollowingPlayer(target);
					continue;
				}
				throw new NullReferenceException();
			}
			((LinkedList<Pickup>.Enumerator*)(&enumerator3))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe bool CheckOverlap(EPickup ePickup, Vector3 pos, out Pickup overlappingPickup)
	{
		//IL_001d: Expected O, but got Ref
		//IL_003c: Expected O, but got I4
		//IL_014e: Expected I4, but got O
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		ref Pickup reference = ref *(Pickup*)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj = default(object);
		int layerMask = default(int);
		int num = Physics.OverlapSphereNonAlloc((Vector3)(&obj), stackRadius, overlapResults, layerMask);
		bool flag = num <= 0;
		object obj2 = 0;
		if (!flag)
		{
			do
			{
				Collider[] array = overlapResults;
				if ((nint)obj2 < array.Length)
				{
					Pickup component = array[obj2].GetComponent<Pickup>();
					reference = ref *(Pickup*)component;
					if (overlappingPickup != null)
					{
						Pickup pickup = overlappingPickup;
						if (pickup.ePickup == ePickup)
						{
							return true;
						}
					}
					obj2++;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				return (byte)(int)ex != 0;
			}
			while ((nint)obj2 < num);
		}
		return false;
	}

	public unsafe GameObject GetNewPickup(EPickup pickup, Vector3 pos)
	{
		//IL_00b1: Expected O, but got Ref
		ObjectPool<GameObject> objectPool;
		if (pickup != EPickup.Xp)
		{
			if (pickup == EPickup.Gold)
			{
				PoolManager instance = PoolManager.Instance;
				if ((object)PoolManager.Instance != null)
				{
					objectPool = instance.goldPool;
					goto IL_010b;
				}
			}
		}
		else
		{
			PoolManager instance2 = PoolManager.Instance;
			if ((object)PoolManager.Instance != null)
			{
				objectPool = instance2.xpPool;
				goto IL_010b;
			}
		}
		goto IL_00b6;
		IL_00b6:
		return (GameObject)(object)new NullReferenceException();
		IL_010b:
		if (objectPool != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Transform transform = gameObject.transform;
				if ((object)transform != null)
				{
					object obj = default(object);
					transform.position = (Vector3)(&obj);
					return gameObject;
				}
			}
		}
		goto IL_00b6;
	}

	public void DespawnPickup(Pickup pickup)
	{
		ObjectPool<GameObject> objectPool;
		if (pickup.ePickup != EPickup.Xp)
		{
			if (pickup.ePickup != EPickup.Gold)
			{
				PoolManager instance = PoolManager.Instance;
				GameObject element = pickup.gameObject;
				instance.powerupPool.Release(element);
				int num = numPowerupsOnMap - 1;
				numPowerupsOnMap = num;
				return;
			}
			PoolManager instance2 = PoolManager.Instance;
			objectPool = instance2.goldPool;
		}
		else
		{
			PoolManager instance3 = PoolManager.Instance;
			objectPool = instance3.xpPool;
		}
		GameObject element2 = pickup.gameObject;
		objectPool.Release(element2);
	}

	public PickupManager()
	{
		//IL_004b: Expected I, but got O
		//IL_0079: Expected O, but got I
		stackRadius = 0.5f;
		stackRadiusMin = 0.5f;
		stackRadiusMax = 8f;
		stackRadiusMaxTime = 900f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		object obj = num3 + 0;
		Vector3 vector = default(Vector3);
		hoverHeight = vector;
		powerups = new EPickup[8]
		{
			EPickup.Haste,
			EPickup.Health,
			EPickup.Magnet,
			EPickup.Nuke,
			EPickup.Rage,
			EPickup.Shield,
			EPickup.Stonks,
			EPickup.Time
		};
		base._002Ector();
	}

	static PickupManager()
	{
		//IL_0032: Expected O, but got I4
		maxXpObjects = 300;
		maxGoldObjects = 300;
		maxPowerupsOnMap = 50;
		object obj = maxXpObjects + 1;
		Collider[] array = new Collider[obj];
		overlapResults = array;
	}
}
