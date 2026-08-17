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

public class ProjectileWhirlwind : ProjectileBase
{
	public Rigidbody rb;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	private Vector3 startDirection;

	private float maxSpeed;

	private float speed;

	private float nextCheckDamageTime;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0297: Expected I4, but got O
		//IL_0087: Expected O, but got Ref
		//IL_0150: Expected O, but got Ref
		//IL_026d: Expected O, but got Ref
		if (hitEnemies != null)
		{
			hitEnemies.Clear();
			if (enemyHitCooldowns != null)
			{
				enemyHitCooldowns.Clear();
				Transform transform = base.transform;
				if ((object)MyPlayer.Instance != null)
				{
					Vector3 feetPosition = MyPlayer.Instance.GetFeetPosition();
					if ((object)transform != null)
					{
						float num = default(float);
						transform.position = (Vector3)(&num);
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							Vector3 position = transform2.position;
							float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
							WeaponBase weaponBase = base.weaponBase;
							if (base.weaponBase != null)
							{
								WeaponData weaponData = weaponBase.weaponData;
								if ((object)weaponBase.weaponData != null)
								{
									GameObject exceptObject = default(GameObject);
									Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, projectileIndex, weaponData.useVision, exceptObject);
									if (!(enemy != null))
									{
										return false;
									}
									if ((object)enemy != null)
									{
										Vector3 centerPosition = enemy.GetCenterPosition();
										Transform transform3 = base.transform;
										if ((object)transform3 != null)
										{
											Vector3 position2 = transform3.position;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
											object obj = default(object);
											startDirection = (Vector3)obj;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v25+8]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileWhirlwind)+80]");
											if ((nint)0 > (nint)0)
											{
												_ = 0;
											}
											maxSpeed = projectileSpeed;
											speed = projectileSpeed;
											Transform transform4 = base.transform;
											if ((object)transform4 != null)
											{
												Vector3 position3 = transform4.position;
												if ((object)rb != null)
												{
													rb.MovePosition((Vector3)(&num));
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
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)startDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProjectileWhirlwind)+84]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected unsafe override void MyFixedUpdate()
	{
		//IL_0033: Expected O, but got Ref
		//IL_0052: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + hitCooldown;
		nextCheckDamageTime = num;
		Vector3 position = rb.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), projectileRadius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				bool flag2 = HitEnemy(buffer[obj]);
				obj++;
			}
			while ((nint)obj < enemiesInRadiusSafe);
		}
	}

	private unsafe Vector3 GetRaycastPosition()
	{
		//IL_0055: Expected I, but got O
		//IL_00e5: Expected native int or pointer, but got O
		//IL_00f2: Expected native int or pointer, but got O
		//IL_00ff: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			float num3 = projectileRadius * (float)Vector3.upVector;
			float num4 = projectileRadius;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num5 = num4 * 0f;
			object obj = default(object);
			float num6 = projectileRadius * (float)obj;
			float x = num3 + position.x;
			float z = num5 + position.z;
			float y = num6 + position.y;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	protected unsafe override void StepMovement()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Ref, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0093: Expected O, but got I4
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0309: Expected O, but got I
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0298: Expected I, but got O
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02df: Expected O, but got I
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		Vector3 raycastPosition = GetRaycastPosition();
		ref Collider[] buffer = ref *(Collider[]*)(obj + 103);
		Vector3 pos = (Vector3)(obj - 41);
		_ = raycastPosition.x;
		_ = raycastPosition.z;
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, projectileRadius, out buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		bool flag2 = false;
		object obj3 = 0;
		if (!flag)
		{
			bool flag4;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				object obj4 = 0;
				nint num = (nint)typeof(Vector3);
				Vector3 normal = (Vector3)(obj - 41);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v10 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v7+20+v112 @ rbx_v4*8]");
				bool flag3 = CheckCollision((Collider)0, normal);
				flag2 = flag3;
				if (flag3)
				{
					break;
				}
				obj3++;
				flag4 = (nint)obj3 < enemiesInRadiusSafe;
				flag2 = flag3;
			}
			while (flag4);
		}
		Vector3 movementDirection = GetMovementDirection();
		object obj5 = obj - 41;
		object obj6 = obj - 25;
		_ = movementDirection.x;
		_ = movementDirection.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		if (!flag2)
		{
			Vector3 raycastPosition2 = GetRaycastPosition();
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 vector = (Vector3)(obj - 41);
			Vector3 origin = (Vector3)(obj - 25);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v22+8]");
			_ = 0;
			_ = raycastPosition2.x;
			_ = raycastPosition2.z;
			float maxDistance = default(float);
			int layerMask = default(int);
			QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
			int num3 = Physics.SphereCastNonAlloc(origin, projectileRadius, vector, ProjectileBase.raycastBuffer, maxDistance, layerMask, queryTriggerInteraction);
			if (num3 > 0)
			{
				RaycastHit raycastHit = (RaycastHit)(ProjectileBase.raycastBuffer + 32);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				object obj7 = ProjectileBase.raycastBuffer + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Vector3 normal2 = (Vector3)(obj - 25);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v41+8]");
				_ = 0;
				bool flag5 = CheckCollision(collider, normal2);
			}
		}
		Vector3 movementDirection2 = GetMovementDirection();
		float num4 = speed * movementDirection2.x;
		float num5 = speed * movementDirection2.y;
		float num6 = speed * movementDirection2.z;
		Vector3 velocity = (Vector3)(obj - 41);
		rb.velocity = velocity;
	}

	private unsafe void CheckRadiusDamage()
	{
		//IL_0033: Expected O, but got Ref
		//IL_0052: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + hitCooldown;
		nextCheckDamageTime = num;
		Vector3 position = rb.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), projectileRadius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				bool flag2 = HitEnemy(buffer[obj]);
				obj++;
			}
			while ((nint)obj < enemiesInRadiusSafe);
		}
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_00c0: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172D90]");
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
		//IL_0008: Expected O, but got Ref
		//IL_03cf: Expected I4, but got O
		//IL_00c8: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_01d4: Expected O, but got Ref
		//IL_0208: Expected O, but got Ref
		//IL_023c: Expected O, but got I
		//IL_027a: Expected O, but got I
		//IL_02de: Expected O, but got Ref
		//IL_033a: Expected O, but got Ref
		//IL_0348: Expected O, but got Ref
		//IL_038c: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (enemyHitCooldowns != null)
		{
			if (enemyHitCooldowns.TryGetValue(collider, out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
			{
				float num = MyTime.time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
				float num2 = num - 0f;
				if (hitCooldown > num2)
				{
					goto IL_03b3;
				}
			}
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111))))
				{
					goto IL_03b3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
					if (((Enemy)0).IsDead())
					{
						goto IL_03b3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
						Transform transform = ((Component)0).transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							if ((object)MyPlayer.Instance != null)
							{
								Transform transform2 = MyPlayer.Instance.transform;
								if ((object)transform2 != null)
								{
									Vector3 position2 = transform2.position;
									float num3 = position.x - position2.x;
									float num4 = position.y - position2.y;
									float num5 = position.z - position2.z;
									Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
									Vector3 vector = VectorExtensions.XZVector(v);
									Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
									_ = vector.x;
									_ = vector.z;
									WeaponBase obj3 = weaponBase;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
									float num6 = default(float);
									DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj3, this, (Enemy)0, vector2, num6);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
										((Enemy)0).DamageFromPlayerWeapon(damageContainer);
										Transform transform3 = base.transform;
										if ((object)transform3 != null)
										{
											Vector3 position3 = transform3.position;
											if ((object)collider != null)
											{
												Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
												_ = position3.x;
												_ = position3.z;
												Vector3 vector3 = collider.ClosestPoint(position4);
												Vector3 movementDirection = GetMovementDirection();
												if ((object)weaponAttack != null)
												{
													Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													Vector3 hitPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
													_ = movementDirection.x;
													_ = movementDirection.z;
													_ = vector3.x;
													_ = vector3.z;
													weaponAttack.ProjectileHit(hitPos, moveDir, hitEnemy: true, (byte)(int)num6 != 0);
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
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03b3:
		return false;
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	public ProjectileWhirlwind()
	{
		Dictionary<Collider, float> dictionary = new Dictionary<Collider, float>();
		enemyHitCooldowns = dictionary;
		hitCooldown = 0.5f;
		base._002Ector();
	}
}
