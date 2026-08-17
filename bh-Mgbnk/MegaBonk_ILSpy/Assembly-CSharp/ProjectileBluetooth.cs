using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileBluetooth : ProjectileBase
{
	protected Enemy target;

	private GameObject lastTarget;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_031a: Expected I4, but got O
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00e0: Expected O, but got Ref
		//IL_01a9: Expected O, but got Ref
		//IL_02bd: Expected O, but got Ref
		//IL_02f0: Expected O, but got Ref
		lastHitEnemy = null;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				Vector3 forward = transform2.forward;
				WeaponBase weaponBase = base.weaponBase;
				if (base.weaponBase != null)
				{
					WeaponData weaponData = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v7 (WeaponData)+C8]");
						object obj = 0 * forward.z;
						float num = (float)obj + position.z;
						float num2 = default(float);
						transform.position = (Vector3)(&num2);
						Transform transform3 = base.transform;
						if ((object)transform3 != null)
						{
							Vector3 position2 = transform3.position;
							float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
							WeaponBase weaponBase2 = base.weaponBase;
							if (base.weaponBase != null)
							{
								WeaponData weaponData2 = weaponBase2.weaponData;
								if ((object)weaponBase2.weaponData != null)
								{
									GameObject exceptObject = default(GameObject);
									Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num2), weaponRange, projectileIndex, weaponData2.useVision, exceptObject);
									target = enemy;
									if (!(target != null))
									{
										return false;
									}
									if ((object)target != null)
									{
										GameObject gameObject = target.gameObject;
										lastTarget = gameObject;
										if ((object)target != null)
										{
											Vector3 centerPosition = target.GetCenterPosition();
											Transform transform4 = base.transform;
											if ((object)transform4 != null)
											{
												Vector3 position3 = transform4.position;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
												object obj2 = default(object);
												direction = (Vector3)obj2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v27+8]");
												_ = 0;
												Transform transform5 = base.transform;
												Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num2));
												if ((object)transform5 != null)
												{
													object obj3 = default(object);
													transform5.rotation = (Quaternion)(&obj3);
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

	protected unsafe override void FindMovementDirection()
	{
		//IL_006c: Expected O, but got Ref
		//IL_013d: Expected I, but got O
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		float num = default(float);
		GameObject exceptObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, 1, weaponData.useVision, exceptObject);
		target = enemy;
		if (target != null)
		{
			Vector3 centerPosition = target.GetCenterPosition();
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj = default(object);
			direction = (Vector3)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v18+8]");
			_ = 0;
			GameObject gameObject = target.gameObject;
			lastTarget = gameObject;
		}
		else
		{
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			direction = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_00e6: Expected F4, but got O
		//IL_00e1: Expected native int or pointer, but got O
		//IL_00fb: Expected F4, but got I
		//IL_00f6: Expected native int or pointer, but got O
		//IL_00b0: Expected F4, but got O
		//IL_00ab: Expected native int or pointer, but got O
		//IL_00d2: Expected F4, but got I
		//IL_00cd: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		if (target != null)
		{
			if ((object)target != null)
			{
				Vector3 centerPosition = target.GetCenterPosition();
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Vector3 position = transform.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					object obj = default(object);
					direction = (Vector3)obj;
					((Vector3*)(nint)vector)->x = (float)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v11+8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v11+8]");
					((Vector3*)(nint)vector)->z = 0f;
					return vector;
				}
			}
			return (Vector3)new NullReferenceException();
		}
		((Vector3*)(nint)vector)->x = (float)direction;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProjectileBluetooth)+40]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected unsafe override void StepMovement()
	{
		//IL_024b: Expected O, but got Ref
		//IL_02ca: Expected I, but got O
		//IL_0268: Expected O, but got Ref
		//IL_038d: Expected O, but got Ref
		if (!(target != null) || target.IsDead())
		{
			FindMovementDirection();
			if (!(target != null))
			{
				ProjectileDone();
				return;
			}
		}
		Vector3 centerPosition = target.GetCenterPosition();
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = centerPosition.x - position.x;
		float num2 = centerPosition.y - position.y;
		float num3 = centerPosition.z - position.z;
		Vector3 movementDirection = GetMovementDirection();
		float num4 = projectileSpeed * movementDirection.x;
		float num5 = projectileSpeed * movementDirection.y;
		float num6 = projectileSpeed * movementDirection.z;
		float num7 = num5 * num5;
		float num8 = num4 * num4;
		float num9 = num6 * num6;
		float num10 = num7 + num8;
		float num11 = num2 * num2;
		float num12 = num * num;
		float num13 = num3 * num3;
		float num14 = num11 + num12;
		float num15 = num14 + num13;
		if (!(projectileRadius < num15))
		{
			HitTarget();
		}
		float num16 = num10 + num9;
		if (num16 > num15)
		{
			num5 = num2;
			num4 = num;
			num6 = num3;
		}
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		float num17 = default(float);
		transform2.position = (Vector3)(&num17);
		nint num18 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num19 = 0;
		float num20 = num4 - (float)Vector3.zeroVector;
		float num21 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		float num22 = num21 - 0f;
		float num23 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num24 = num23 - 0f;
		float num25 = num22 * num22;
		float num26 = num24 * num24;
		float num27 = num20 * num20;
		float num28 = num25 + num27;
		float num29 = num28 + num26;
		Transform transform4;
		if (!(9.9999994E-11f > num29))
		{
			Transform transform3 = base.transform;
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num17));
			transform4 = transform3;
		}
		else
		{
			Transform transform5 = base.transform;
			transform4 = transform5;
		}
		float num30 = default(float);
		transform4.rotation = (Quaternion)(&num30);
	}

	private unsafe void HitTarget()
	{
		//IL_001f: Expected O, but got Ref
		//IL_007a: Expected O, but got Ref
		//IL_00a9: Expected I4, but got F4
		//IL_00a9: Expected O, but got Ref
		//IL_00a9: Expected O, but got Ref
		//IL_0195: Expected I, but got O
		//IL_01d2: Expected O, but got I
		//IL_01ef: Expected O, but got I
		//IL_0239: Invalid comparison between F4 and O
		Vector3 movementDirection = GetMovementDirection();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num = default(float);
		float num2 = default(float);
		DamageContainer damageContainer = WeaponUtility.GetDamageContainer(base.weaponBase, this, target, (Vector3)(&num), num2);
		target.DamageFromPlayerWeapon(damageContainer);
		Enemy enemy = target;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Vector3 vector = enemy.collider.ClosestPointOnBounds((Vector3)(&num));
		Vector3 movementDirection2 = GetMovementDirection();
		object obj = default(object);
		weaponAttack.ProjectileHit((Vector3)(&obj), (Vector3)(&num), hitEnemy: true, (byte)(int)num2 != 0);
		int num3 = bounces + 1;
		bounces = num3;
		if (bounces >= maxBounces)
		{
			ProjectileDone();
		}
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		if (weaponData.amplificationMode == EAmplificationMode.Bounce && weaponData.canBounce)
		{
			FindMovementDirection();
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v27 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			object obj2 = direction - Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBluetooth)+3C]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
			object obj3 = num6 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBluetooth)+40]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			object obj4 = num7 - 0;
			object obj5 = obj3 * obj3;
			object obj6 = obj2 * obj2;
			object obj7 = obj4 * obj4;
			object obj8 = obj5 + obj6;
			object obj9 = obj8 + obj7;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
			{
				ProjectileDone();
			}
		}
	}

	protected override bool HitEnemy(Collider collider, Vector3 normal)
	{
		//IL_006a: Expected I4, but got O
		if (target != null)
		{
			if ((object)target == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = target.IsDead();
		}
		return false;
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void CheckSpawnCollision()
	{
	}

	protected override void HitOther(Collider collider, Vector3 normal)
	{
	}

	protected override void MyUpdate()
	{
	}

	protected override void MyFixedUpdate()
	{
	}
}
