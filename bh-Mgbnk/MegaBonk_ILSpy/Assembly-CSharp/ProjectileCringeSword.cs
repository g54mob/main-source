using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ProjectileCringeSword : ProjectileBase
{
	public GameObject movingProjectile;

	private Vector3 movingProjectileDir;

	private Vector3 hitboxPos;

	private Quaternion movingProjectileRotation;

	private float movingProjectileDuration;

	private float startTime;

	public Vector3 colliderOffset;

	public float testMultiplier;

	private float forwardOffset;

	private float upOffset;

	private Vector3 posOffset;

	private float actualProjectileSpeed;

	private new HashSet<Collider> hitEnemies;

	private Vector3 movingProjectilePosition;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0ab9: Expected I4, but got O
		//IL_012a: Expected I, but got O
		//IL_0157: Expected O, but got I
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_0251: Expected O, but got Ref
		//IL_0327: Expected O, but got Ref
		//IL_03d1: Expected O, but got Ref
		//IL_0b40: Expected I, but got O
		//IL_0b4e: Expected O, but got Ref
		//IL_0b5c: Expected O, but got Ref
		//IL_0771: Expected I, but got O
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Expected O, but got Unknown
		//IL_07b4: Expected O, but got I
		//IL_07d1: Expected O, but got I
		//IL_082e: Expected O, but got Ref
		//IL_08a3: Expected O, but got Ref
		//IL_0925: Expected O, but got Ref
		//IL_0934: Expected O, but got F4
		//IL_0943: Expected O, but got F4
		//IL_0965: Expected O, but got Ref
		//IL_09f2: Expected O, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		WeaponBase weaponBase = base.weaponBase;
		if (base.weaponBase != null)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
				float num = attackSizeMultiplier;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v3 (WeaponData)+C8]");
				float num2 = (forwardOffset = num * 0f);
				MyPlayer instance = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
				{
					Transform transform = instance.playerRenderer.transform;
					if ((object)transform != null)
					{
						float num3 = num2 * transform.forward.z;
						WeaponBase weaponBase2 = base.weaponBase;
						if (base.weaponBase != null)
						{
							WeaponData weaponData2 = weaponBase2.weaponData;
							if ((object)weaponBase2.weaponData != null)
							{
								nint num4 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v5 (WeaponData)+C4]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								object obj3 = num6 * 0;
								float num7 = (float)obj3 + num3;
								Vector3 vector = default(Vector3);
								posOffset = vector;
								Transform transform2 = base.transform;
								if ((object)MyPlayer.Instance != null)
								{
									Transform transform3 = MyPlayer.Instance.transform;
									if ((object)transform3 != null)
									{
										Vector3 position = transform3.position;
										float num8 = position.y;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileCringeSword)+BC]");
										float num9 = num8 + 0f;
										float num10 = position.z;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileCringeSword)+C0]");
										float num11 = num10 + 0f;
										object obj4 = posOffset + position.x;
										if ((object)transform2 != null)
										{
											Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
											transform2.position = position2;
											Transform transform4 = base.transform;
											MyPlayer instance2 = MyPlayer.Instance;
											if ((object)MyPlayer.Instance != null && (object)instance2.playerRenderer != null)
											{
												Transform transform5 = instance2.playerRenderer.transform;
												if ((object)transform5 != null)
												{
													Quaternion rotation = transform5.rotation;
													if ((object)transform4 != null)
													{
														Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
														_ = rotation.x;
														transform4.rotation = rotation2;
														MyPlayer instance3 = MyPlayer.Instance;
														if ((object)MyPlayer.Instance != null && (object)instance3.playerRenderer != null)
														{
															Transform transform6 = instance3.playerRenderer.transform;
															if ((object)transform6 != null)
															{
																Vector3 up = transform6.up;
																Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
																_ = up.z;
																_ = up.x;
																Quaternion quaternion = Quaternion.AngleAxis(180f, axis);
																Quaternion rotation3 = transform6.rotation;
																float num12 = rotation3.w * quaternion.x;
																float num13 = rotation3.z * quaternion.y;
																float num14 = rotation3.x * quaternion.w;
																float num15 = rotation3.y * quaternion.w;
																float num16 = num14 + num12;
																float num17 = rotation3.z * quaternion.w;
																float num18 = rotation3.y * quaternion.z;
																float num19 = num16 + num13;
																float num20 = rotation3.x * quaternion.z;
																float num21 = num19 - num18;
																float num22 = rotation3.w * quaternion.y;
																float num23 = num15 + num22;
																float num24 = rotation3.z * quaternion.x;
																float num25 = rotation3.z * quaternion.z;
																float num26 = num23 + num20;
																float num27 = rotation3.y * quaternion.x;
																float num28 = rotation3.y * quaternion.y;
																float num29 = num26 - num24;
																float num30 = rotation3.w * quaternion.z;
																float num31 = rotation3.w * quaternion.w;
																float num32 = num17 + num30;
																float num33 = rotation3.x * quaternion.x;
																float num34 = rotation3.x * quaternion.y;
																float num35 = num31 - num33;
																float num36 = num32 + num27;
																float num37 = num35 - num28;
																float num38 = num36 - num34;
																float num39 = num37 - num25;
																nint num40 = (nint)typeof(Vector3);
																Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
																Quaternion quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rax_v28 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																nint num41 = 0;
																_ = Vector3.forwardVector;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rax_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
																_ = 0;
																Vector3 vector3 = quaternion2 * vector2;
																_ = vector3.x;
																_ = vector3.z;
																if ((object)movingProjectile != null)
																{
																	Transform transform7 = movingProjectile.transform;
																	Transform transform8 = base.transform;
																	if ((object)transform8 != null)
																	{
																		Vector3 position3 = transform8.position;
																		float num42 = forwardOffset * vector3.x;
																		float num43 = forwardOffset;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
																		float num44 = num43 * 0f;
																		float num45 = num42 + position3.x;
																		float num46 = forwardOffset * vector3.z;
																		float num47 = num44 + position3.y;
																		float num48 = num46 + position3.z;
																		WeaponBase weaponBase3 = base.weaponBase;
																		if (base.weaponBase != null)
																		{
																			WeaponData weaponData3 = weaponBase3.weaponData;
																			if ((object)weaponBase3.weaponData != null)
																			{
																				nint num49 = (nint)typeof(Vector3);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																				nint num50 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v23 (WeaponData)+C4]");
																				object obj5 = 0 * Vector3.upVector;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v23 (WeaponData)+C4]");
																				nint num51 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v36 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
																				object obj6 = num51 * 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v23 (WeaponData)+C4]");
																				nint num52 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v36 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
																				object obj7 = num52 * 0;
																				float num53 = (float)obj5 + num45;
																				float num54 = (float)obj6 + num47;
																				float num55 = (float)obj7 + num48;
																				if ((object)transform7 != null)
																				{
																					Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
																					transform7.position = position4;
																					if ((object)movingProjectile != null)
																					{
																						Transform transform9 = movingProjectile.transform;
																						if ((object)transform9 != null)
																						{
																							Quaternion rotation4 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
																							transform9.rotation = rotation4;
																							if ((object)movingProjectile != null)
																							{
																								Transform transform10 = movingProjectile.transform;
																								if ((object)transform10 != null)
																								{
																									Vector3 position5 = transform10.position;
																									object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
																									movingProjectilePosition = (Vector3)position5.x;
																									hitboxPos = (Vector3)position5.x;
																									_ = position5.z;
																									_ = position5.z;
																									object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
																									object obj10 = default(object);
																									movingProjectileDir = (Vector3)obj10;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v43+8]");
																									_ = 0;
																									if ((object)movingProjectile != null)
																									{
																										Transform transform11 = movingProjectile.transform;
																										if ((object)transform11 != null)
																										{
																											movingProjectileRotation = (Quaternion)transform11.rotation.x;
																											float attackSizeMultiplier2 = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
																											float num56 = attackSizeMultiplier2 - 1f;
																											float num57 = num56 * 0.5f;
																											float num58 = num57 + 1f;
																											float num59 = num58 * projectileSpeed;
																											actualProjectileSpeed = num59;
																											startTime = MyTime.time;
																											if (hitEnemies != null)
																											{
																												hitEnemies.Clear();
																												WeaponAttack weaponAttack = base.weaponAttack;
																												if ((object)base.weaponAttack != null)
																												{
																													CheckZone(base.weaponBase, projectileRadius, weaponAttack.prefabHit);
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
		//IL_0041: Expected native int or pointer, but got O
		//IL_0053: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 forward = transform.forward;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = forward.x;
			((Vector3*)(nint)vector)->z = forward.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	protected unsafe override void MyFixedUpdate()
	{
		//IL_001f: Expected O, but got Ref
		//IL_003e: Expected O, but got I4
		//IL_0050: Expected O, but got Ref
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00a4: Expected O, but got I4
		//IL_00fc: Expected O, but got Ref
		//IL_00fc: Expected O, but got Ref
		//IL_011b: Expected O, but got I4
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		float num = startTime + movingProjectileDuration;
		if (MyTime.time > num)
		{
			return;
		}
		Vector3 vector = default(Vector3);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&vector), projectileRadius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		float num2 = projectileRadius;
		object obj2 = (object)(&buffer);
		if (!flag)
		{
			bool flag2;
			do
			{
				CheckColliderCustom(buffer[obj], 0.5f);
				obj++;
				flag2 = (nint)obj < enemiesInRadiusSafe;
				num2 = 0.5f;
				obj2 = 0;
			}
			while (flag2);
		}
		object obj3 = this + 112;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		GameManager instance = GameManager.Instance;
		float num3 = MyTime.fixedDeltaTime * actualProjectileSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj4 = default(object);
		float maxDistance = default(float);
		int layerMask = default(int);
		QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
		int num4 = Physics.SphereCastNonAlloc((Vector3)(&obj4), projectileRadius, (Vector3)(&vector), ProjectileBase.raycastBuffer, maxDistance, layerMask, queryTriggerInteraction);
		bool flag3 = num4 <= 0;
		object obj5 = 0;
		if (!flag3)
		{
			do
			{
				object obj6 = ProjectileBase.raycastBuffer + 32;
				object obj7 = obj5 * 44;
				RaycastHit raycastHit = (RaycastHit)(obj7 + obj6);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				if (collider != null)
				{
					object obj8 = ProjectileBase.raycastBuffer + 32;
					object obj9 = obj5 * 44;
					RaycastHit raycastHit2 = (RaycastHit)(obj9 + obj8);
					Collider collider2 = ((RaycastHit*)raycastHit2)->collider;
					CheckColliderCustom(collider2, 0.5f);
					num2 = 0.5f;
				}
				obj5++;
			}
			while ((nint)obj5 < num4);
		}
		float num5 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileCringeSword)+78]");
		float num6 = num5 * 0f;
		float num7 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileCringeSword)+84]");
		float num8 = num7 + 0f;
		Vector3 vector2 = default(Vector3);
		hitboxPos = vector2;
	}

	protected unsafe override void MyUpdate()
	{
		//IL_0038: Expected O, but got Ref
		//IL_0078: Expected O, but got Ref
		//IL_009e: Expected O, but got Ref
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		Vector3 vector = default(Vector3);
		transform.position = (Vector3)(&vector);
		float num = actualProjectileSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileCringeSword)+78]");
		float num2 = num * 0f;
		float num3 = MyTime.deltaTime * num2;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileCringeSword)+D8]");
		float num5 = num4 + 0f;
		Vector3 vector2 = default(Vector3);
		movingProjectilePosition = vector2;
		Transform transform3 = movingProjectile.transform;
		transform3.position = (Vector3)(&vector);
		Transform transform4 = movingProjectile.transform;
		transform4.rotation = (Quaternion)(&vector);
	}

	public unsafe void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
		//IL_008f: Expected O, but got Ref
		//IL_00bc: Expected O, but got I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		Transform transform = base.transform;
		Vector3 right = transform.right;
		Transform transform2 = base.transform;
		Vector3 up = transform2.up;
		Transform transform3 = base.transform;
		Vector3 forward = transform3.forward;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		Transform transform4 = base.transform;
		Vector3 position = transform4.position;
		object obj = default(object);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&obj), radius, out var buffer);
		if (enemiesInRadiusSafe > 0)
		{
			object obj2 = 0;
			do
			{
				CheckColliderCustom(buffer[obj2], 1f);
				obj2++;
			}
			while ((nint)obj2 < enemiesInRadiusSafe);
		}
	}

	private unsafe void CheckColliderCustom(Collider collider, float damageMultiplier)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f5: Expected F4, but got I4
		//IL_0412: Invalid comparison between I4 and F4
		//IL_012d: Invalid comparison between I4 and F4
		//IL_0197: Expected F4, but got I4
		//IL_014d: Expected I4, but got F4
		//IL_01d0: Expected O, but got I
		//IL_0252: Expected O, but got Ref
		//IL_0260: Expected O, but got Ref
		//IL_0291: Expected O, but got Ref
		//IL_02c3: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_0345: Expected O, but got Ref
		//IL_037d: Expected O, but got Ref
		//IL_038b: Expected O, but got Ref
		//IL_03cd: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		if (!(collider != null) || ((HashSet<object>)(object)hitEnemies).Contains((object)collider) || !EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111))))
		{
			return;
		}
		bool flag = hitEnemies.Add(collider);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int combinedHp = inventory.playerHealth.GetCombinedHp();
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		int combinedMaxHp = inventory2.playerHealth.GetCombinedMaxHp();
		int num = combinedHp / combinedMaxHp;
		if (0 <= num)
		{
			if ((float)num > 1f)
			{
				num = 1;
			}
		}
		else
		{
			num = 0;
		}
		float num2 = Easing.OutQuad(num);
		float num3 = 1f - num2;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = num3 * 1.85f;
		float num5 = ((combinedHp != 1) ? (num4 + 0.4f) : 3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
		Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num6 = centerPosition.x - position.x;
		float num7 = centerPosition.y - position.y;
		float num8 = centerPosition.z - position.z;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v27+8]");
		_ = 0;
		WeaponBase obj5 = weaponBase;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
		float num9 = default(float);
		DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, this, (Enemy)0, vector, num9);
		float num10 = num5 * damageMultiplier;
		float damage = num10 * damageContainer.damage;
		damageContainer.damage = damage;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
		((Enemy)0).DamageFromPlayerWeapon(damageContainer);
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = position2.x;
		_ = position2.z;
		Vector3 vector2 = collider.ClosestPointOnBounds(position3);
		Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Vector3 hitPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = vector2.x;
		_ = vector2.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v27+8]");
		_ = 0;
		weaponAttack.ProjectileHit(hitPos, moveDir, hitEnemy: true, (byte)(int)num9 != 0);
	}

	private float GetRadius()
	{
		return projectileRadius;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void FindMovementDirection()
	{
	}

	public ProjectileCringeSword()
	{
		//IL_0027: Expected O, but got I4
		movingProjectileDuration = 0.3f;
		colliderOffset = (Vector3)0;
		_ = 1056964608;
		testMultiplier = 1f;
		HashSet<Collider> hashSet = (HashSet<Collider>)(object)new HashSet<object>();
		hitEnemies = hashSet;
		base._002Ector();
	}
}
