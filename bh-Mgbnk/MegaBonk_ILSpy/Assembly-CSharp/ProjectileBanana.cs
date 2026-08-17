using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileBanana : ProjectileBase
{
	public Transform renderer;

	public TrailRenderer trailRenderer;

	private float trailStartWidth;

	private Vector3 startDirection;

	private Vector3 movementVelocity;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	private float readyToCollectTime;

	private float sqrCollectDistance;

	private float maxSpeed;

	private float returnTime;

	private Vector3 dirToPlayer;

	public Rigidbody rb;

	private float nextCheckDamageTime;

	private static Dictionary<Collider, int> numTimesEnemiesHitThisTick;

	private static bool hasDamage;

	private static float damageThisTick;

	private float distToPlayer;

	private bool isCloseToPlayer;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0039: Invalid comparison between I4 and F4
		//IL_03a3: Expected I4, but got O
		//IL_01f0: Expected O, but got Ref
		//IL_034e: Expected O, but got Ref
		if (trailRenderer != null)
		{
			if (!(0f < trailStartWidth))
			{
				if ((object)trailRenderer == null)
				{
					goto IL_0395;
				}
				float startWidth = trailRenderer.startWidth;
				trailStartWidth = startWidth;
			}
			if ((object)trailRenderer != null)
			{
				trailRenderer.Clear();
				float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
				if ((object)trailRenderer != null)
				{
					float startWidth2 = trailStartWidth * attackSizeMultiplier;
					trailRenderer.startWidth = startWidth2;
					goto IL_03c7;
				}
			}
			goto IL_0395;
		}
		goto IL_03c7;
		IL_0395:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03c7:
		float num = MyTime.time + 0.5f;
		readyToCollectTime = num;
		if (hitEnemies != null)
		{
			hitEnemies.Clear();
			if (enemyHitCooldowns != null)
			{
				enemyHitCooldowns.Clear();
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Vector3 position = transform.position;
					float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
					WeaponBase weaponBase = base.weaponBase;
					if (base.weaponBase != null)
					{
						WeaponData weaponData = weaponBase.weaponData;
						if ((object)weaponBase.weaponData != null)
						{
							float num2 = default(float);
							GameObject exceptObject = default(GameObject);
							Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num2), weaponRange, projectileIndex, weaponData.useVision, exceptObject);
							if (!(enemy != null))
							{
								return false;
							}
							if ((object)enemy != null)
							{
								Vector3 centerPosition = enemy.GetCenterPosition();
								Transform transform2 = base.transform;
								if ((object)transform2 != null)
								{
									Vector3 position2 = transform2.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
									float num3 = projectileSpeed * 55f;
									object obj = default(object);
									startDirection = (Vector3)obj;
									maxSpeed = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v26+8]");
									_ = 0;
									returnTime = 0f;
									float num4 = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBanana)+84]");
									float num5 = num4 * 0f;
									Vector3 vector = default(Vector3);
									movementVelocity = vector;
									Transform transform3 = base.transform;
									if ((object)transform3 != null)
									{
										Vector3 position3 = transform3.position;
										if ((object)rb != null)
										{
											rb.MovePosition((Vector3)(&num2));
											float num6 = projectileRadius * 0.5f;
											float num7 = num6 * num6;
											sqrCollectDistance = num7;
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
		goto IL_0395;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)movementVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProjectileBanana)+90]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyFixedUpdate()
	{
		//IL_025f: Invalid comparison between I4 and F4
		//IL_01c5: Expected F4, but got I4
		//IL_0286: Invalid comparison between I4 and F4
		//IL_0201: Expected F4, but got I4
		//IL_02b7: Expected O, but got I
		float num = readyToCollectTime;
		if (!(readyToCollectTime > MyTime.time))
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float num2 = position.x - position2.x;
			float num3 = position.y - position2.y;
			float num4 = position.z - position2.z;
			num = sqrCollectDistance;
			float num5 = num3 * num3;
			float num6 = num2 * num2;
			float num7 = num4 * num4;
			float num8 = num5 + num6;
			float num9 = (distToPlayer = num8 + num7);
			if (sqrCollectDistance > num9)
			{
				ProjectileDone();
			}
		}
		CheckRadiusDamage();
		Transform transform3 = MyPlayer.Instance.transform;
		Vector3 position3 = transform3.position;
		Transform transform4 = base.transform;
		Vector3 position4 = transform4.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj = default(object);
		dirToPlayer = (Vector3)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v17+8]");
		_ = 0;
		float num10 = MyTime.fixedDeltaTime * 0.7f;
		float num11 = num10 + returnTime;
		if (!(0f > num11))
		{
			if (num11 > 1f)
			{
				num11 = 1f;
			}
		}
		else
		{
			num11 = 0f;
		}
		returnTime = num11;
		if (!(0f > num11))
		{
			if (num11 > 1f)
			{
				num11 = 1f;
			}
		}
		else
		{
			num11 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBanana)+BC]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBanana)+84]");
		object obj2 = num12 - 0;
		float num13 = (float)obj2 * num11;
		float num14 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBanana)+84]");
		float num15 = num14 + 0f;
		float num16 = num15 * maxSpeed;
		Vector3 vector = default(Vector3);
		movementVelocity = vector;
	}

	protected unsafe override void StepMovement()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_0082: Expected O, but got I4
		//IL_00ad: Expected O, but got Ref
		//IL_00bb: Expected O, but got Ref
		//IL_03e0: Expected O, but got I
		//IL_0333: Expected I, but got O
		//IL_0341: Expected O, but got Ref
		//IL_0346: Expected I, but got O
		//IL_038f: Expected O, but got I
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_0186: Expected O, but got Ref
		//IL_0194: Expected O, but got Ref
		//IL_02da: Expected O, but got Ref
		//IL_01f9: Expected O, but got Ref
		//IL_026b: Expected O, but got Ref
		//IL_0286: Expected O, but got Ref
		//IL_02a3: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		ref Collider[] buffer = ref System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		_ = position.x;
		_ = position.z;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, projectileRadius, out buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj3 = 0;
		if (!flag)
		{
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				object obj4 = 0;
				nint num = (nint)typeof(Vector3);
				Vector3 normal = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				nint num2 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r10_v4 (Il2CppClass<ProjectileBanana>)+1E0]");
				buffer = ref *(Collider[]*)null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v9+20+v104 @ rbx_v5*8]");
				bool flag2 = CheckCollision((Collider)0, normal);
				obj3++;
			}
			while ((nint)obj3 < enemiesInRadiusSafe);
		}
		Vector3 movementDirection = GetMovementDirection();
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = movementDirection.x;
		_ = movementDirection.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		int attackQuantity = WeaponUtility.GetAttackQuantity(weaponBase);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		if (attackQuantity < 7 || attackSizeMultiplier < 2.5f)
		{
			Transform transform2 = base.transform;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v21+8]");
			_ = 0;
			_ = 0;
			Vector3 position2 = transform2.position;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = position2.x;
			_ = position2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v31+8]");
			_ = 0;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			Ray ray = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			float maxDistance = MyTime.fixedDeltaTime * projectileSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			int layerMask = default(int);
			if (Physics.SphereCast(ray, projectileRadius, out hitInfo, maxDistance, layerMask))
			{
				RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Vector3 normal2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rax_v40+8]");
				_ = 0;
				bool flag3 = CheckCollision(collider, normal2);
			}
		}
		Vector3 velocity = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = movementVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBanana)+90]");
		_ = 0;
		rb.velocity = velocity;
	}

	private bool IsUsingSphereCast()
	{
		int attackQuantity = WeaponUtility.GetAttackQuantity(weaponBase);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		if (attackQuantity >= 7)
		{
			return attackSizeMultiplier < 2.5f;
		}
		return true;
	}

	private unsafe void CheckRadiusDamage()
	{
		//IL_0032: Expected O, but got Ref
		//IL_0051: Expected O, but got I4
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = (nextCheckDamageTime = MyTime.time + hitCooldown);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), projectileRadius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		if (flag)
		{
			return;
		}
		float num3 = default(float);
		bool flag3;
		do
		{
			float num4;
			float num5;
			if (enemyHitCooldowns.TryGetValue(buffer[obj], out var value))
			{
				num = hitCooldown;
				num3 = MyTime.time - value;
				bool flag2 = hitCooldown > num3;
				num4 = num3;
				num5 = hitCooldown;
				if (flag2)
				{
					goto IL_01f8;
				}
			}
			if (!numTimesEnemiesHitThisTick.ContainsKey(buffer[obj]))
			{
				((Dictionary<object, int>)(object)numTimesEnemiesHitThisTick).Add((object)buffer[obj], 0);
			}
			int num6 = numTimesEnemiesHitThisTick.get_Item(buffer[obj]);
			int value2 = num6 + 1;
			((Dictionary<object, int>)(object)numTimesEnemiesHitThisTick).set_Item((object)buffer[obj], value2);
			hasDamage = true;
			num4 = num3;
			num5 = num;
			goto IL_01f8;
			IL_01f8:
			obj++;
			flag3 = (nint)obj < enemiesInRadiusSafe;
			num3 = num4;
			num = num5;
		}
		while (flag3);
	}

	private void LateUpdate()
	{
		TryPopDamage();
	}

	private unsafe void TryPopDamage()
	{
		//IL_0401: Expected I, but got O
		//IL_0526: Expected I, but got O
		//IL_0135: Expected O, but got Ref
		//IL_015d: Expected O, but got Ref
		//IL_017a: Expected I, but got O
		//IL_01c0: Expected I, but got O
		//IL_04c6: Expected I, but got O
		//IL_04e9: Expected I, but got O
		//IL_025b: Expected O, but got Ref
		//IL_027d: Expected I, but got O
		//IL_0302: Expected I4, but got F4
		//IL_0302: Expected O, but got Ref
		//IL_0302: Expected O, but got Ref
		if (!hasDamage)
		{
			return;
		}
		hasDamage = false;
		nint num = (nint)typeof(ProjectileBanana);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v8 (Il2CppClass<ProjectileBanana>)+B8]");
		nint num2 = 0;
		if (numTimesEnemiesHitThisTick != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			bool flag = false;
			Dictionary<Collider, int>.Enumerator enumerator = default(Dictionary<Collider, int>.Enumerator);
			Collider collider = default(Collider);
			float num3 = default(float);
			object obj = default(object);
			float num4 = default(float);
			object obj2 = default(object);
			object obj3 = default(object);
			float x = default(float);
			float num6 = default(float);
			float x2 = default(float);
			GameObject weaponHitEffect = default(GameObject);
			bool useSfx = default(bool);
			while (enumerator.MoveNext())
			{
				if ((object)EnemyManager.Instance != null)
				{
					if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
					{
						continue;
					}
					bool flag2 = (object)enemy == null;
					EnemyManager enemyManager = (EnemyManager)(object)enemy;
					if (!flag2)
					{
						Transform transform = enemy.transform;
						bool flag3 = (object)transform == null;
						enemyManager = (EnemyManager)(object)enemy;
						if (!flag3)
						{
							Vector3 position = transform.position;
							bool flag4 = (object)MyPlayer.Instance == null;
							enemyManager = (EnemyManager)(object)MyPlayer.Instance;
							if (!flag4)
							{
								Transform transform2 = MyPlayer.Instance.transform;
								bool flag5 = (object)transform2 == null;
								enemyManager = (EnemyManager)(object)MyPlayer.Instance;
								if (!flag5)
								{
									Vector3 position2 = transform2.position;
									Vector3 vector = VectorExtensions.XZVector((Vector3)(&num3));
									DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, this, enemy, (Vector3)(&obj), num4);
									bool flag6 = damageContainer == null;
									num2 = (nint)weaponBase;
									if (!flag6)
									{
										float damage = (float)obj2 * damageContainer.damage;
										damageContainer.damage = damage;
										bool flag7 = (object)enemy == null;
										num2 = (nint)enemy;
										if (!flag7)
										{
											enemy.DamageFromPlayerWeapon(damageContainer);
											float num5 = damageThisTick + damageContainer.damage;
											damageThisTick = num5;
											num2 = (nint)typeof(ProjectileBanana);
											if (enemyHitCooldowns != null)
											{
												((Dictionary<object, float>)(object)enemyHitCooldowns).set_Item((object)collider, MyTime.time);
												if ((flag ? 1 : 0) < 5)
												{
													Transform transform3 = base.transform;
													bool flag8 = (object)transform3 == null;
													num2 = (nint)this;
													if (flag8)
													{
														throw new NullReferenceException();
													}
													Vector3 position3 = transform3.position;
													bool flag9 = (object)collider == null;
													num2 = (nint)(&obj3);
													if (flag9)
													{
														throw new NullReferenceException();
													}
													Vector3 vector2 = collider.ClosestPoint((Vector3)(&x));
													bool hitEnemy = enemy;
													num2 = (nint)weaponBase;
													if (weaponBase == null)
													{
														throw new NullReferenceException();
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1208 @ rcx_v14 (Il2CppStaticFields<ProjectileBanana>)+18]");
													if ((nint)0 == 0)
													{
														throw new NullReferenceException();
													}
													if ((object)EffectManager.Instance == null)
													{
														throw new NullReferenceException();
													}
													EffectManager.Instance.EnemyHitEffect((Vector3)(&num6), (Vector3)(&x2), hitEnemy, (EWeapon)num4, weaponHitEffect, useSfx);
													x2 = vector.x;
													x = position3.x;
												}
												flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
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
			enumerator.Dispose();
			bool flag10 = numTimesEnemiesHitThisTick == null;
			num2 = (nint)numTimesEnemiesHitThisTick;
			if (!flag10)
			{
				numTimesEnemiesHitThisTick.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void CheckHitPlayer()
	{
		if (!(readyToCollectTime > MyTime.time))
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float num = position.x - position2.x;
			float num2 = position.y - position2.y;
			float num3 = position.z - position2.z;
			float num4 = num2 * num2;
			float num5 = num * num;
			float num6 = num3 * num3;
			float num7 = num4 + num5;
			float num8 = (distToPlayer = num7 + num6);
			if (sqrCollectDistance > num8)
			{
				ProjectileDone();
			}
		}
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_00c0: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172D2C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)collider != null)
		{
			GameObject gameObject = collider.gameObject;
			if ((object)gameObject != null)
			{
				int layer = gameObject.layer;
				int num = LayerMask.NameToLayer("Enemy");
				if (layer != num)
				{
					return false;
				}
				return HitEnemy(collider);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool HitEnemy(Collider collider)
	{
		//IL_01c7: Expected I4, but got O
		//IL_008b: Expected O, but got Ref
		//IL_013b: Expected O, but got Ref
		//IL_0184: Expected I4, but got F4
		//IL_0184: Expected O, but got Ref
		//IL_0184: Expected O, but got Ref
		if (enemyHitCooldowns != null)
		{
			if (enemyHitCooldowns.TryGetValue(collider, out var value))
			{
				float num = MyTime.time - value;
				if (hitCooldown > num)
				{
					goto IL_01ab;
				}
			}
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
				{
					goto IL_01ab;
				}
				float num2 = default(float);
				float num3 = default(float);
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, this, enemy, (Vector3)(&num2), num3);
				if ((object)enemy != null)
				{
					enemy.DamageFromPlayerWeapon(damageContainer);
					if (damageContainer != null)
					{
						float num4 = damageThisTick + damageContainer.damage;
						damageThisTick = num4;
						Transform transform = base.transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							if ((object)collider != null)
							{
								Vector3 vector = collider.ClosestPoint((Vector3)(&num2));
								Vector3 movementDirection = GetMovementDirection();
								if ((object)weaponAttack != null)
								{
									object obj = default(object);
									weaponAttack.ProjectileHit((Vector3)(&obj), (Vector3)(&num2), hitEnemy: true, (byte)(int)num3 != 0);
									if (enemyHitCooldowns != null)
									{
										((Dictionary<object, float>)(object)enemyHitCooldowns).set_Item((object)collider, MyTime.time);
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01ab:
		return false;
	}

	protected unsafe override void MyUpdate()
	{
		//IL_002d: Expected O, but got Ref
		float deltaTime = Time.deltaTime;
		float angle = deltaTime * 1200f;
		object obj = default(object);
		renderer.Rotate((Vector3)(&obj), angle, Space.Self);
	}

	protected override void FindMovementDirection()
	{
	}

	public ProjectileBanana()
	{
		Dictionary<Collider, float> dictionary = new Dictionary<Collider, float>();
		enemyHitCooldowns = dictionary;
		hitCooldown = 0.24f;
		base._002Ector();
	}

	static ProjectileBanana()
	{
		Dictionary<Collider, int> dictionary = new Dictionary<Collider, int>();
		numTimesEnemiesHitThisTick = dictionary;
	}
}
