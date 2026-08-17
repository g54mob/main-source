using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.Combat.ConstantAttacks;

public class AegisAttack : ConstantAttack
{
	public RandomSfx shieldUseSfx;

	public RandomSfx shieldRegenSfx;

	public Transform renderer;

	public AegisRenderer aegisRenderer;

	public Transform[] particles;

	public ParticleSystem rootParticles;

	private bool isActive;

	private int currentAmount;

	private float minAegisCooldown = 0.2f;

	private float shieldReadyAtTime;

	public static Action<int> A_Used;

	public static Action<int> A_Regen;

	private float nextAmountTime;

	protected override void Init()
	{
		GameObject gameObject = renderer.gameObject;
		gameObject.SetActive(value: true);
		shieldRegenSfx.Play();
		isActive = true;
		currentAmount = 0;
		AmplifyShield();
	}

	private void FixedUpdate()
	{
		if (!isActive && MyTime.time > shieldReadyAtTime)
		{
			Init();
		}
		if (MyTime.time > nextAmountTime)
		{
			AmplifyShield();
		}
	}

	public void RegenShield()
	{
		GameObject gameObject = renderer.gameObject;
		gameObject.SetActive(value: true);
		shieldRegenSfx.Play();
		isActive = true;
		currentAmount = 0;
		AmplifyShield();
	}

	private void AmplifyShield()
	{
		ResetNextAmountTime();
		if (!isActive)
		{
			return;
		}
		int attackQuantity = WeaponUtility.GetAttackQuantity(weaponBase);
		if (currentAmount < attackQuantity)
		{
			int amount = ++currentAmount;
			aegisRenderer.SetAmount(amount);
			shieldRegenSfx.Play();
			Action<int> a_Regen = A_Regen;
			if (A_Regen != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v77 @ rax_v12 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void ResetNextAmountTime()
	{
		float weaponCooldown = WeaponUtility.GetWeaponCooldown(weaponBase);
		float num = weaponCooldown * 1.5f;
		float num2 = num + MyTime.time;
		nextAmountTime = num2;
	}

	private int GetMaxShields()
	{
		return WeaponUtility.GetAttackQuantity(weaponBase);
	}

	public unsafe void UseShield(Vector3 enemyFeetPosition)
	{
		//IL_00af: Expected O, but got Ref
		//IL_00c6: Expected O, but got I4
		//IL_00ce: Expected O, but got Ref
		//IL_00d7: Expected O, but got I4
		//IL_0223: Expected O, but got Ref
		//IL_0243: Expected O, but got Ref
		//IL_015c: Expected O, but got Ref
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_025e: Expected O, but got Ref
		//IL_02fc: Expected O, but got Ref
		//IL_02fc: Expected O, but got Ref
		//IL_0317: Expected O, but got Ref
		//IL_0388: Expected O, but got Ref
		//IL_03e7: Expected O, but got Ref
		//IL_0403: Expected O, but got Ref
		//IL_04a8: Expected I4, but got F4
		//IL_04a8: Expected O, but got Ref
		//IL_04a8: Expected O, but got Ref
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		Transform transform = base.transform;
		bool flag = (object)transform == null;
		Component component = this;
		if (!flag)
		{
			Vector3 localPosition = transform.localPosition;
			Transform transform2 = base.transform;
			bool flag2 = (object)transform2 == null;
			component = this;
			if (!flag2)
			{
				Vector3 position = transform2.position;
				Transform[] array = particles;
				bool flag3 = particles == null;
				Vector3 vector = default(Vector3);
				component = (Component)(&vector);
				if (!flag3)
				{
					object obj = 0;
					component = (Component)(&vector);
					object obj2 = 0;
					float num = default(float);
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					float num2 = default(float);
					List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
					Collider collider = default(Collider);
					float num3 = default(float);
					object obj3 = default(object);
					float num4 = default(float);
					object obj4 = default(object);
					GameObject weaponHitEffect = default(GameObject);
					bool useSfx = default(bool);
					while (true)
					{
						if ((nint)obj2 < array.Length)
						{
							if ((nint)obj < array.Length)
							{
								component = array[obj];
								if ((object)array[obj] == null)
								{
									break;
								}
								Transform transform3 = array[obj].transform;
								bool flag4 = (object)transform3 == null;
								component = (Component)(object)typeof(Vector3);
								if (flag4)
								{
									break;
								}
								transform3.localScale = (Vector3)(&num);
								obj++;
								component = transform3;
								obj2 = obj;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						component = rootParticles;
						if ((object)rootParticles == null)
						{
							break;
						}
						GameObject gameObject = rootParticles.gameObject;
						if ((object)gameObject == null)
						{
							break;
						}
						gameObject.SetActive(value: true);
						component = rootParticles;
						if ((object)rootParticles == null)
						{
							break;
						}
						Transform transform4 = rootParticles.transform;
						Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
						bool flag5 = (object)transform4 == null;
						component = (Component)(&enumerator);
						if (flag5)
						{
							break;
						}
						transform4.rotation = (Quaternion)(&enumerator);
						bool flag6 = (object)rootParticles == null;
						component = rootParticles;
						if (flag6)
						{
							break;
						}
						rootParticles.Play();
						Transform transform5 = base.transform;
						bool flag7 = (object)transform5 == null;
						component = this;
						if (flag7)
						{
							break;
						}
						Vector3 position2 = transform5.position;
						float maxDistance = attackSizeMultiplier * 10f;
						List<Collider> list = RaycastUtility.ConeCastAll((Vector3)(&num2), (Vector3)(&num), maxDistance, 60f);
						bool flag8 = list == null;
						component = (Component)(&num2);
						if (flag8)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						while (enumerator2.MoveNext())
						{
							bool flag9 = (object)EnemyManager.Instance == null;
							component = EnemyManager.Instance;
							if (!flag9)
							{
								if (EnemyManager.Instance.GetEnemy(collider, out var enemy))
								{
									DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, null, enemy, (Vector3)(&num), num3);
									bool flag10 = (object)enemy == null;
									component = enemy;
									if (flag10)
									{
										throw new NullReferenceException();
									}
									enemy.DamageFromPlayerWeapon(damageContainer);
									Transform transform6 = base.transform;
									bool flag11 = (object)transform6 == null;
									component = this;
									if (flag11)
									{
										throw new NullReferenceException();
									}
									Vector3 position3 = transform6.position;
									bool flag12 = (object)collider == null;
									component = (Component)(&obj3);
									if (flag12)
									{
										throw new NullReferenceException();
									}
									Vector3 vector2 = collider.ClosestPoint((Vector3)(&num2));
									bool hitEnemy = enemy;
									component = (Component)(object)weaponBase;
									if (weaponBase == null)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1035 @ rcx_v10 (UnityEngine.Component)+18]");
									if ((nint)0 == 0)
									{
										throw new NullReferenceException();
									}
									if ((object)EffectManager.Instance == null)
									{
										throw new NullReferenceException();
									}
									EffectManager.Instance.EnemyHitEffect((Vector3)(&num4), (Vector3)(&obj4), hitEnemy, (EWeapon)num3, weaponHitEffect, useSfx);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						((List<Collider>.Enumerator*)(&enumerator2))->Dispose();
						int amount = --currentAmount;
						bool flag13 = (object)aegisRenderer == null;
						component = aegisRenderer;
						if (flag13)
						{
							break;
						}
						aegisRenderer.SetAmount(amount);
						if (currentAmount <= 0)
						{
							if ((object)renderer == null)
							{
								break;
							}
							GameObject gameObject2 = renderer.gameObject;
							if ((object)gameObject2 == null)
							{
								break;
							}
							gameObject2.SetActive(value: false);
							isActive = false;
						}
						if ((object)shieldUseSfx == null)
						{
							break;
						}
						shieldUseSfx.Play();
						float weaponCooldown = WeaponUtility.GetWeaponCooldown(weaponBase);
						bool flag14 = weaponCooldown > minAegisCooldown;
						float num5 = weaponCooldown;
						if (!flag14)
						{
							num5 = minAegisCooldown;
						}
						float num6 = num5 + MyTime.time;
						shieldReadyAtTime = num6;
						float weaponCooldown2 = WeaponUtility.GetWeaponCooldown(weaponBase);
						float num7 = weaponCooldown2 * 1.5f;
						float num8 = num7 + MyTime.time;
						nextAmountTime = num8;
						Action<int> a_Used = A_Used;
						if (A_Used != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1478 @ rax_v59 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public bool IsActive()
	{
		return isActive;
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
	}

	protected override void OnStatUpdate(EStat stat)
	{
		if (stat == EStat.AttackSpeed)
		{
			float weaponCooldown = WeaponUtility.GetWeaponCooldown(weaponBase);
			float num = weaponCooldown * 1.5f;
			float num2 = num + MyTime.time;
			if (shieldReadyAtTime > num2)
			{
				shieldReadyAtTime = num2;
			}
			if (nextAmountTime > num2)
			{
				nextAmountTime = num2;
			}
		}
	}

	public override float GetAuraRotationSpeed()
	{
		return -3.5f;
	}
}
