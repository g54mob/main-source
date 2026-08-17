using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemMirror : ItemBase
{
	public static Action<bool> A_MirrorReady;

	public float cooldown;

	private float minCooldown;

	private float damageMultiplier;

	private float damagePerAmount;

	private float lastReflectedTime;

	private bool canReflect;

	private string damageSource;

	private DamageContainer reuseDc;

	protected override void OnInitOrAmountChanged()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		float num = 8f - (float)amount;
		if (num < minCooldown)
		{
			num = minCooldown;
		}
		object obj = amount * damagePerAmount;
		float num2 = (float)obj + 1f;
		cooldown = num;
		damageMultiplier = num2;
		Action<bool> a_MirrorReady = A_MirrorReady;
		if (A_MirrorReady != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ rax_v3 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<DamageContainer, bool> b = OnCheckStopDamage;
		Delegate obj = Delegate.Combine(PlayerHealth.A_CheckStopDamage, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_CheckStopDamage = (Action<DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<DamageContainer, bool> action = default(Action<DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_CheckStopDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00e7: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<DamageContainer, bool> value = OnCheckStopDamage;
		Delegate obj = Delegate.Remove(PlayerHealth.A_CheckStopDamage, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_CheckStopDamage = (Action<DamageContainer, bool>)obj;
			goto IL_0098;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<DamageContainer, bool> action = default(Action<DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_CheckStopDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<DamageContainer, bool>);
			if (!flag)
			{
				goto IL_0098;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0098:
		Action<bool> a_MirrorReady = A_MirrorReady;
		if (A_MirrorReady != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ rax_v12 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void Tick()
	{
		if (canReflect)
		{
			return;
		}
		float num = lastReflectedTime + cooldown;
		if (MyTime.time > num)
		{
			canReflect = true;
			Action<bool> a_MirrorReady = A_MirrorReady;
			if (A_MirrorReady != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v57 @ rax_v7 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private bool IsReady()
	{
		return canReflect;
	}

	private unsafe bool ReflectDamage(DamageContainer dc)
	{
		//IL_0bff: Expected O, but got I
		//IL_0c04: Expected I4, but got O
		//IL_0b5f: Expected I4, but got O
		//IL_0b67: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_0c3c: Expected O, but got I4
		//IL_0c6b: Expected O, but got I4
		//IL_0c74: Expected I4, but got O
		//IL_0138: Expected O, but got I4
		//IL_0141: Expected I4, but got O
		//IL_0160: Expected native int or pointer, but got F4
		//IL_016a: Invalid comparison between F4 and I4
		//IL_0189: Expected O, but got I4
		//IL_01c0: Expected native int or pointer, but got F4
		//IL_01d6: Expected O, but got Ref
		//IL_01d6: Expected O, but got Ref
		//IL_01d6: Expected O, but got F4
		//IL_01ee: Expected O, but got Ref
		//IL_01f6: Expected O, but got Ref
		//IL_01ff: Expected I4, but got O
		//IL_0237: Expected O, but got Ref
		//IL_0240: Expected I4, but got O
		//IL_0287: Expected O, but got Ref
		//IL_0287: Expected O, but got Ref
		//IL_02b3: Expected O, but got Ref
		//IL_02bc: Expected O, but got I4
		//IL_02ec: Expected F4, but got O
		//IL_02f2: Expected O, but got I
		//IL_0c9a: Expected I4, but got O
		//IL_0cb1: Expected O, but got I
		//IL_0e5d: Expected O, but got I
		//IL_0e66: Expected I4, but got O
		//IL_030e: Expected O, but got F4
		//IL_0326: Expected O, but got I4
		//IL_032e: Expected O, but got Ref
		//IL_0813: Expected I4, but got O
		//IL_036f: Expected O, but got F4
		//IL_0377: Expected O, but got Ref
		//IL_0860: Expected O, but got I4
		//IL_040e: Expected O, but got I4
		//IL_089e: Expected O, but got Ref
		//IL_089e: Expected O, but got Ref
		//IL_0d35: Expected I, but got O
		//IL_0d66: Expected O, but got Ref
		//IL_0d88: Expected O, but got Ref
		//IL_08b0: Expected I4, but got O
		//IL_08cc: Expected O, but got Ref
		//IL_08ee: Expected O, but got Ref
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_05a2: Expected O, but got I4
		//IL_0930: Expected O, but got Ref
		//IL_094e: Expected O, but got Ref
		//IL_0956: Expected I4, but got O
		//IL_09a5: Expected O, but got Ref
		//IL_09c3: Expected O, but got Ref
		//IL_09cb: Expected I4, but got O
		//IL_09e1: Expected I, but got O
		//IL_09f1: Expected O, but got I
		//IL_0a2b: Expected O, but got Ref
		//IL_0e1a: Expected O, but got I4
		//IL_0dc1: Expected I4, but got O
		//IL_0686: Expected O, but got I4
		//IL_0adb: Expected O, but got I4
		//IL_0ae3: Expected O, but got Ref
		//IL_0aeb: Expected I4, but got O
		//IL_06b3: Invalid comparison between F4 and I4
		//IL_06ed: Expected O, but got I4
		//IL_06f5: Expected O, but got Ref
		//IL_0b13: Expected O, but got I
		//IL_071d: Expected O, but got Ref
		//IL_071d: Expected O, but got F4
		//IL_0773: Expected O, but got Ref
		//IL_07ab: Expected O, but got I4
		//IL_07ab: Expected O, but got Ref
		//IL_07ab: Expected O, but got Ref
		//IL_07b3: Expected O, but got I4
		//IL_07c4: Expected O, but got Ref
		bool flag = dc == null;
		Enemy enemy = (Enemy)(object)dc;
		IntPtr intPtr = default(IntPtr);
		Vector3 vector = (Vector3)(nint)intPtr;
		EStat eStat = (EStat)this;
		Vector3 vector4 = default(Vector3);
		bool flag11;
		UnityEngine.Object instance;
		if (!flag)
		{
			if (!(dc.enemy != null))
			{
				return false;
			}
			canReflect = false;
			float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
			enemy = dc.enemy;
			bool flag2 = (object)dc.enemy == null;
			float num = stat;
			vector = (Vector3)0;
			eStat = EStat.SizeMultiplier;
			if (!flag2)
			{
				Vector3 feetPosition = dc.enemy.GetFeetPosition();
				float num2 = default(float);
				eStat = (EStat)(int)(&num2);
				bool flag3 = (object)MyPlayer.Instance == null;
				num = stat;
				enemy = (Enemy)(object)MyPlayer.Instance;
				vector = (Vector3)0;
				if (!flag3)
				{
					Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					enemy = (Enemy)(object)typeof(EffectManager);
					bool flag4 = (object)MyPlayer.Instance == null;
					num = stat;
					vector = (Vector3)0;
					eStat = (EStat)MyPlayer.Instance;
					if (!flag4)
					{
						float controlHp = enemy.controlHp;
						Transform transform = MyPlayer.Instance.transform;
						bool flag5 = (object)transform == null;
						num = stat;
						enemy = null;
						vector = (Vector3)0;
						eStat = (EStat)MyPlayer.Instance;
						if (!flag5)
						{
							Vector3 position = transform.position;
							bool flag6 = ((float*)(nint)controlHp)->m_value == 0f;
							num = stat;
							enemy = (Enemy)(object)transform;
							vector = (Vector3)0;
							eStat = (EStat)(int)(&num2);
							if (!flag6)
							{
								num = position.x;
								float size = stat * 5f;
								float num3 = default(float);
								Vector3 vector2 = default(Vector3);
								((EffectManager)((float*)(nint)controlHp)->m_value).SpawnMirrorFx((Vector3)(&num3), (Vector3)(&vector2), size);
								bool flag7 = (object)MyPlayer.Instance == null;
								enemy = (Enemy)(&num3);
								vector = (Vector3)(&vector2);
								eStat = (EStat)MyPlayer.Instance;
								if (!flag7)
								{
									Transform transform2 = MyPlayer.Instance.transform;
									bool flag8 = (object)transform2 == null;
									enemy = null;
									vector = (Vector3)(&vector2);
									eStat = (EStat)MyPlayer.Instance;
									if (!flag8)
									{
										Vector3 position2 = transform2.position;
										float num4 = stat * 10f;
										float num5 = default(float);
										Vector3 vector3 = default(Vector3);
										List<Collider> list = RaycastUtility.ConeCastAll((Vector3)(&num5), (Vector3)(&vector3), num4, 60f);
										bool flag9 = list == null;
										float num6 = num4;
										size = 60f;
										enemy = (Enemy)(&vector3);
										vector = (Vector3)0;
										eStat = (EStat)(int)(&num5);
										if (!flag9)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
											float num8 = default(float);
											float num7 = num8;
											List<object>.Enumerator enumerator = default(List<object>.Enumerator);
											num = (float)enumerator;
											vector = (Vector3)0;
											List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
											object direction = default(object);
											object obj = default(object);
											Vector3 vector6 = default(Vector3);
											int num10 = default(int);
											GameObject weaponHitEffect = default(GameObject);
											bool useSfx = default(bool);
											while (enumerator2.MoveNext())
											{
												bool flag10 = (object)EnemyManager.Instance == null;
												flag11 = (byte)(int)vector4 != 0;
												num6 = num4;
												size = 60f;
												Transform transform3 = (Transform)0;
												instance = EnemyManager.Instance;
												if (!flag10)
												{
													bool enemy2 = EnemyManager.Instance.GetEnemy((Collider)num8, out var enemy3);
													bool flag12 = !enemy2;
													vector4 = (Vector3)0;
													vector = (Vector3)(&enemy3);
													if (!flag12)
													{
														bool flag13 = reuseDc == null;
														flag11 = false;
														num6 = num4;
														size = 60f;
														transform3 = (Transform)num8;
														vector = (Vector3)(&enemy3);
														instance = (UnityEngine.Object)(object)reuseDc;
														if (flag13)
														{
															throw new NullReferenceException();
														}
														reuseDc.Reuse(1f, damageSource);
														DamageContainer damageContainer = reuseDc;
														num = PlayerStats.GetStat(EStat.DamageMultiplier);
														bool flag14 = reuseDc == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = null;
														vector = (Vector3)damageSource;
														instance = (UnityEngine.Object)12;
														if (flag14)
														{
															throw new NullReferenceException();
														}
														float num9 = damageMultiplier * dc.damage;
														float damage = num9 * num;
														damageContainer.damage = damage;
														instance = (UnityEngine.Object)(object)reuseDc;
														bool flag15 = reuseDc == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = null;
														vector = (Vector3)damageSource;
														if (flag15)
														{
															throw new NullReferenceException();
														}
														transform3 = (Transform)(object)dc.enemy;
														_ = dc.enemy;
														instance = (UnityEngine.Object)(instance + 40);
														DamageContainer damageContainer2 = reuseDc;
														bool flag16 = reuseDc == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														vector = (Vector3)damageSource;
														if (flag16)
														{
															throw new NullReferenceException();
														}
														damageContainer2.direction = (Vector3)direction;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1177 @ rax_v42+8]");
														_ = 0;
														DamageContainer damageContainer3 = reuseDc;
														num = PlayerStats.GetStat(EStat.KnockbackMultiplier);
														bool flag17 = reuseDc == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = null;
														vector = (Vector3)damageSource;
														instance = (UnityEngine.Object)24;
														if (flag17)
														{
															throw new NullReferenceException();
														}
														num *= 3f;
														damageContainer3.knockback = num;
														bool flag18 = (object)enemy3 == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = null;
														vector = (Vector3)damageSource;
														instance = enemy3;
														if (flag18)
														{
															throw new NullReferenceException();
														}
														enemy3.DamageFromPlayerWeapon(reuseDc);
														bool flag19 = (object)MyPlayer.Instance == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = (Transform)(object)reuseDc;
														vector = (Vector3)0;
														instance = MyPlayer.Instance;
														if (flag19)
														{
															throw new NullReferenceException();
														}
														Transform transform4 = MyPlayer.Instance.transform;
														bool flag20 = (object)transform4 == null;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = null;
														vector = (Vector3)0;
														instance = MyPlayer.Instance;
														if (flag20)
														{
															throw new NullReferenceException();
														}
														Vector3 position3 = transform4.position;
														bool flag21 = num8 == 0f;
														flag11 = false;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														transform3 = transform4;
														vector = (Vector3)0;
														instance = (UnityEngine.Object)(&obj);
														if (flag21)
														{
															throw new NullReferenceException();
														}
														num = position3.x;
														Vector3 vector5 = ((Collider)num8).ClosestPoint((Vector3)(&num3));
														bool flag22 = enemy3;
														bool flag23 = (object)EffectManager.Instance == null;
														flag11 = flag22;
														num7 = 1f;
														num6 = num4;
														size = 60f;
														enemy = null;
														vector = (Vector3)(&num3);
														instance = enemy3;
														if (flag23)
														{
															transform3 = (Transform)(object)enemy;
															throw new NullReferenceException();
														}
														EffectManager.Instance.EnemyHitEffect((Vector3)(&num2), (Vector3)(&vector6), flag22, (string)num10, weaponHitEffect, useSfx);
														vector4 = (Vector3)flag22;
														num7 = 1f;
														vector = (Vector3)(&vector6);
													}
													continue;
												}
												throw new NullReferenceException();
											}
											((List<Collider>.Enumerator*)(&enumerator2))->Dispose();
											bool flag24 = (object)MyPlayer.Instance == null;
											num6 = num4;
											size = 60f;
											enemy = (Enemy)0;
											eStat = (EStat)MyPlayer.Instance;
											if (!flag24)
											{
												Transform transform5 = MyPlayer.Instance.transform;
												bool flag25 = (object)transform5 == null;
												num6 = num4;
												size = 60f;
												enemy = null;
												eStat = (EStat)MyPlayer.Instance;
												if (!flag25)
												{
													Vector3 position4 = transform5.position;
													bool flag26 = (object)EffectManager.Instance == null;
													num6 = num4;
													size = 60f;
													enemy = (Enemy)(object)transform5;
													vector = (Vector3)0;
													object obj2 = default(object);
													eStat = (EStat)(int)(&obj2);
													if (!flag26)
													{
														num = position4.x;
														Color color = default(Color);
														EffectManager.Instance.PopupText("REFLECT", (Color)(&color), (Vector3)(&num2), num10);
														lastReflectedTime = MyTime.time;
														nint num11 = (nint)typeof(MyPlayer);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1633 @ rax_v75 (Il2CppClass<Assets.Scripts.Actors.Player.MyPlayer>)+B8]");
														nint num12 = 0;
														MyPlayer instance2 = MyPlayer.Instance;
														bool flag27 = (object)MyPlayer.Instance == null;
														vector4 = (Vector3)(&num2);
														num6 = num4;
														size = 60f;
														enemy = (Enemy)(object)"REFLECT";
														vector = (Vector3)(&color);
														eStat = (EStat)num12;
														if (!flag27)
														{
															eStat = (EStat)instance2.inventory;
															bool flag28 = instance2.inventory == null;
															vector4 = (Vector3)(&num2);
															num6 = num4;
															size = 60f;
															enemy = (Enemy)(object)"REFLECT";
															vector = (Vector3)(&color);
															if (!flag28)
															{
																StatModifier[] array = new StatModifier[1];
																StatModifier statModifier = new StatModifier();
																bool flag29 = statModifier == null;
																vector4 = (Vector3)(&num2);
																num6 = num4;
																size = 60f;
																enemy = null;
																vector = (Vector3)(&color);
																eStat = (EStat)statModifier;
																if (!flag29)
																{
																	statModifier.stat = EStat.DamageReductionMultiplier;
																	statModifier.modification = 1f;
																	statModifier.modifyType = EStatModifyType.Flat;
																	bool flag30 = array == null;
																	vector4 = (Vector3)(&num2);
																	num6 = num4;
																	size = 60f;
																	enemy = null;
																	vector = (Vector3)(&color);
																	eStat = (EStat)statModifier;
																	if (!flag30)
																	{
																		nint num13 = (nint)array;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ rdx_v39 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier[]>)+40]");
																		Transform transform3 = (Transform)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
																		object obj3 = default(object);
																		bool flag31 = obj3 == null;
																		flag11 = (byte)(&num2) != 0;
																		num6 = num4;
																		size = 60f;
																		vector = (Vector3)(&color);
																		instance = (UnityEngine.Object)(object)statModifier;
																		if (flag31)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
																			object obj4 = default(object);
																			throw obj4;
																		}
																		if (array.Length <= 0)
																		{
																			IndexOutOfRangeException ex = new IndexOutOfRangeException();
																			return (byte)(int)ex != 0;
																		}
																		array[0] = statModifier;
																		float expirationTime = default(float);
																		StatusEffect statusEffect = new StatusEffect(EStatusEffect.Invulnerability, expirationTime, array);
																		expirationTime = MyTime.time + 0.5f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1652 @ rax_v79 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatModifier)+38]");
																		bool flag32 = (nint)0 == 0;
																		vector4 = (Vector3)array;
																		num6 = expirationTime;
																		size = 60f;
																		enemy = (Enemy)5;
																		vector = (Vector3)(&color);
																		eStat = (EStat)statusEffect;
																		if (!flag32)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1698 @ rax_v83 (Assets.Scripts.Inventory__Items__Pickups.Stats.StatusEffect)+38]");
																			((PlayerStatusEffects)0).AddNewEffect(statusEffect, 0.5f);
																			Action<bool> a_MirrorReady = A_MirrorReady;
																			if (A_MirrorReady != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1707 @ rax_v87 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
																			}
																			return true;
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
						}
					}
				}
			}
		}
		flag11 = (byte)(int)vector4 != 0;
		instance = (UnityEngine.Object)eStat;
		throw new NullReferenceException();
	}

	private void OnCheckStopDamage(DamageContainer dc, bool shieldDamage)
	{
		//IL_0059: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		if (canReflect && ReflectDamage(dc))
		{
			object obj = dc.flags & DcFlags.BossDamage;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				dc.damage = 0f;
				return;
			}
			float damage = dc.damage * 0.25f;
			dc.damage = damage;
		}
	}

	public unsafe ItemMirror(ItemInventory itemInventoryRef)
	{
		//IL_006c: Expected O, but got Ref
		//IL_0083: Expected O, but got Ref
		cooldown = 8f;
		minCooldown = 4f;
		damageMultiplier = 1f;
		damagePerAmount = 0.25f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		reuseDc = new DamageContainer(1f, text2);
		base._002Ector(itemInventoryRef);
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}
}
