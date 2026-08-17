using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGrandmasSecretTonic : ItemBase
{
	private float critChanceTotal;

	private float baseRadius;

	private float radiusPerAmount;

	private float maxRadius;

	private float radius;

	private float damageSpreadMultiplier;

	private float procChance;

	private DamageContainer procDc;

	private string damageSource;

	private Dictionary<Collider, float> numTimesEnemiesHit;

	private float totalDamage;

	private readonly List<Collider> _tmpKeys;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		float num = (float)amount * radiusPerAmount;
		float num2 = num + baseRadius;
		float num3 = stat * num2;
		if (!(1f > num3))
		{
			if (num3 > maxRadius)
			{
				radius = maxRadius;
			}
			else
			{
				radius = num3;
			}
		}
		else
		{
			radius = 1f;
		}
	}

	public unsafe ItemGrandmasSecretTonic(ItemInventory itemInventoryRef)
	{
		//IL_000e: Expected O, but got Ref
		critChanceTotal = 0.02f;
		baseRadius = 3f;
		radiusPerAmount = 1f;
		maxRadius = 8f;
		damageSpreadMultiplier = 0.5f;
		procChance = 0.5f;
		DamageContainer damageContainer = new DamageContainer(0f, "");
		procDc = damageContainer;
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
		Dictionary<Collider, float> dictionary = (Dictionary<Collider, float>)(object)new Dictionary<object, float>(EnemyManager.maxNumEnemiesPooled);
		numTimesEnemiesHit = dictionary;
		_tmpKeys = new List<Collider>(EnemyManager.maxNumEnemiesPooled);
		maxProcsPerTick = 100;
		base._002Ector(itemInventoryRef);
	}

	public override void Init()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.CritChance;
		statModifier.modification = critChanceTotal;
		SetStat(statModifier);
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_00a3: Expected O, but got Ref
		//IL_00c2: Expected O, but got I4
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		if (numProcsThisTick >= maxProcsPerTick || !dc.crit || !ItemUtility.TryProc(procChance, dc.procCoefficient))
		{
			return;
		}
		int num = numProcsThisTick + 1;
		numProcsThisTick = num;
		Vector3 centerPosition = dc.enemy.GetCenterPosition();
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), radius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		if (flag)
		{
			return;
		}
		do
		{
			if (!numTimesEnemiesHit.TryGetValue(buffer[obj], out var value))
			{
				((Dictionary<object, float>)(object)numTimesEnemiesHit).set_Item((object)buffer[obj], 0f);
			}
			float value2 = value + dc.damage;
			((Dictionary<object, float>)(object)numTimesEnemiesHit).set_Item((object)buffer[obj], value2);
			obj++;
		}
		while ((nint)obj < enemiesInRadiusSafe);
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public unsafe override void LateFixedUpdate()
	{
		//IL_0083: Expected O, but got I
		//IL_070e: Expected O, but got Ref
		//IL_0497: Expected O, but got I
		//IL_04b6: Expected O, but got I
		//IL_056c: Expected O, but got Ref
		//IL_0589: Expected O, but got Ref
		//IL_05a4: Expected O, but got Ref
		totalDamage = 0f;
		Dictionary<Collider, float> tmpKeys = (Dictionary<Collider, float>)(object)_tmpKeys;
		if (_tmpKeys != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v19 (System.Collections.Generic.Dictionary`2<UnityEngine.Collider, System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v19 (System.Collections.Generic.Dictionary`2<UnityEngine.Collider, System.Single>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v19 (System.Collections.Generic.Dictionary`2<UnityEngine.Collider, System.Single>)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v19 (System.Collections.Generic.Dictionary`2<UnityEngine.Collider, System.Single>)+18]");
				Array.Clear((Array)num, 0, 0);
				int num2 = 0;
			}
			tmpKeys = numTimesEnemiesHit;
			if (numTimesEnemiesHit != null)
			{
				Dictionary<Collider, float>.KeyCollection keys = numTimesEnemiesHit.Keys;
				if (keys != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
					Dictionary<Collider, float>.KeyCollection.Enumerator enumerator = default(Dictionary<Collider, float>.KeyCollection.Enumerator);
					object obj = default(object);
					while (enumerator.MoveNext())
					{
						List<object> tmpKeys2 = (List<object>)(object)_tmpKeys;
						if (_tmpKeys != null)
						{
							int version = tmpKeys2._version + 1;
							tmpKeys2._version = version;
							object[] items = tmpKeys2._items;
							if (tmpKeys2._items != null)
							{
								int num2 = tmpKeys2._size;
								if (tmpKeys2._size >= items.Length)
								{
									((List<object>)(object)_tmpKeys).AddWithResize(obj);
									continue;
								}
								int size = tmpKeys2._size + 1;
								tmpKeys2._size = size;
								if (tmpKeys2._size < items.Length)
								{
									items[num2] = obj;
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					enumerator.Dispose();
					bool flag = _tmpKeys == null;
					tmpKeys = (Dictionary<Collider, float>)(&enumerator);
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
						float num5 = default(float);
						float num6 = default(float);
						float num7 = default(float);
						while (enumerator2.MoveNext())
						{
							if ((object)EnemyManager.Instance != null)
							{
								bool enemy = EnemyManager.Instance.GetEnemy((Collider)obj, out var enemy2);
								bool flag2 = !enemy;
								int num2 = 0;
								if (flag2)
								{
									continue;
								}
								bool flag3 = enemy2 != null;
								num2 = 0;
								if (!flag3)
								{
									continue;
								}
								if ((object)enemy2 != null)
								{
									GameObject gameObject = enemy2.gameObject;
									bool flag4 = gameObject != null;
									num2 = 0;
									if (!flag4)
									{
										continue;
									}
									bool flag5 = numTimesEnemiesHit == null;
									List<object> tmpKeys2 = (List<object>)(object)numTimesEnemiesHit;
									if (!flag5)
									{
										float num3 = ((Dictionary<object, float>)(object)numTimesEnemiesHit).get_Item(obj);
										bool flag6 = procDc == null;
										tmpKeys2 = (List<object>)(object)procDc;
										if (!flag6)
										{
											procDc.Reuse(0f, damageSource);
											DamageContainer damageContainer = procDc;
											bool flag7 = procDc == null;
											tmpKeys2 = (List<object>)(object)procDc;
											if (!flag7)
											{
												float damage = num3 * damageSpreadMultiplier;
												damageContainer.damage = damage;
												tmpKeys2 = (List<object>)(object)procDc;
												if (procDc != null)
												{
													bool flag8 = (object)enemy2 == null;
													tmpKeys2 = (List<object>)(object)enemy2;
													if (!flag8)
													{
														enemy2.DamageFromPlayerOther(procDc);
														DamageContainer damageContainer2 = procDc;
														bool flag9 = procDc == null;
														tmpKeys2 = (List<object>)(object)enemy2;
														if (!flag9)
														{
															float num4 = damageContainer2.damage + totalDamage;
															totalDamage = num4;
															tmpKeys2 = (List<object>)(object)PoolManager.Instance;
															if ((object)PoolManager.Instance != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rcx_v8 (System.Collections.Generic.List`1<System.Object>)+198]");
																bool flag10 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rcx_v8 (System.Collections.Generic.List`1<System.Object>)+198]");
																tmpKeys2 = (List<object>)0;
																if (!flag10)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rcx_v8 (System.Collections.Generic.List`1<System.Object>)+198]");
																	GameObject gameObject2 = ((ObjectPool<GameObject>)0).Get();
																	bool flag11 = gameObject2 != null;
																	bool flag12 = !flag11;
																	num2 = 0;
																	if (!flag12)
																	{
																		bool flag13 = (object)gameObject2 == null;
																		tmpKeys2 = (List<object>)(object)gameObject2;
																		if (flag13)
																		{
																			throw new NullReferenceException();
																		}
																		Transform transform = gameObject2.transform;
																		bool flag14 = (object)enemy2 == null;
																		tmpKeys2 = (List<object>)(object)gameObject2;
																		if (flag14)
																		{
																			throw new NullReferenceException();
																		}
																		Vector3 centerPosition = enemy2.GetCenterPosition();
																		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
																		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num5));
																		bool flag15 = (object)transform == null;
																		tmpKeys2 = (List<object>)(&num6);
																		if (flag15)
																		{
																			throw new NullReferenceException();
																		}
																		transform.position = (Vector3)(&num7);
																		gameObject2.SetActive(value: true);
																		num2 = 0;
																	}
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
						((List<Collider>.Enumerator*)(&enumerator2))->Dispose();
						bool flag16 = numTimesEnemiesHit == null;
						tmpKeys = numTimesEnemiesHit;
						if (!flag16)
						{
							numTimesEnemiesHit.Clear();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Tick()
	{
		numProcsThisTick = 0;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = procChance * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			float num2 = damageSpreadMultiplier * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
