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

public class ProjectileHeroSword : ProjectileBase
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
		//IL_0a2c: Expected I4, but got O
		//IL_00a3: Expected O, but got Ref
		//IL_021b: Expected O, but got Ref
		//IL_0229: Expected O, but got Ref
		//IL_02e5: Expected O, but got Ref
		//IL_024f: Expected F4, but got O
		//IL_025f: Expected F4, but got I
		//IL_026f: Expected F4, but got I
		//IL_04e6: Expected I, but got O
		//IL_0513: Expected O, but got I
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected O, but got Unknown
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_0609: Expected O, but got Ref
		//IL_0647: Expected O, but got Ref
		//IL_065f: Expected O, but got Ref
		//IL_06b4: Expected O, but got Ref
		//IL_075d: Expected O, but got Ref
		//IL_0810: Expected O, but got Ref
		//IL_088e: Expected O, but got F4
		//IL_08a2: Expected O, but got F4
		//IL_0913: Expected O, but got F4
		//IL_095b: Expected O, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
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
					_ = position.z;
					Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					_ = position.x;
					GameObject exceptObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy(position2, weaponRange, projectileIndex, weaponData.useVision, exceptObject);
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
					{
						Transform transform2 = instance.playerRenderer.transform;
						if ((object)transform2 != null)
						{
							Vector3 forward = transform2.forward;
							float x = forward.x;
							float y = forward.y;
							float z = forward.z;
							if (!(enemy != null))
							{
								goto IL_0b76;
							}
							if ((object)enemy != null)
							{
								Vector3 feetPosition = enemy.GetFeetPosition();
								if ((object)MyPlayer.Instance != null)
								{
									Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
									float num = feetPosition.x - feetPosition2.x;
									float num2 = feetPosition.y - feetPosition2.y;
									float num3 = feetPosition.z - feetPosition2.z;
									object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
									object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
									object obj5 = default(object);
									x = (float)obj5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rax_v71+4]");
									y = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rax_v71+8]");
									z = 0f;
									goto IL_0b76;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a1e;
		IL_0a1e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0b76:
		MyPlayer instance2 = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && (object)instance2.playerRenderer != null)
		{
			Transform transform3 = instance2.playerRenderer.transform;
			if ((object)transform3 != null)
			{
				Vector3 up = transform3.up;
				Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				Vector3 vector = VectorExtensions.XZVector(v);
				float num4 = vector.x;
				float y2 = vector.y;
				float num5 = vector.z;
				float num6 = up.x * up.x;
				float num7 = up.y * up.y;
				float num8 = up.z * up.z;
				float num9 = num7 + num6;
				float num10 = num9 + num8;
				if (!(Mathf.Epsilon > num10))
				{
					float num11 = vector.y * up.y;
					float num12 = vector.x * up.x;
					float num13 = vector.z * up.z;
					float num14 = num11 + num12;
					float num15 = num14 + num13;
					float num16 = num15 * up.x;
					float num17 = num15 * up.y;
					float num18 = num15 * up.z;
					float num19 = num16 / num10;
					float num20 = num17 / num10;
					float num21 = num18 / num10;
					num4 -= num19;
					y2 -= num20;
					num5 -= num21;
				}
				WeaponBase weaponBase2 = base.weaponBase;
				if (base.weaponBase != null)
				{
					WeaponData weaponData2 = weaponBase2.weaponData;
					if ((object)weaponBase2.weaponData != null)
					{
						float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
						float num22 = attackSizeMultiplier;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v24 (WeaponData)+C8]");
						float num23 = num5 * (forwardOffset = num22 * 0f);
						WeaponBase weaponBase3 = base.weaponBase;
						if (base.weaponBase != null)
						{
							WeaponData weaponData3 = weaponBase3.weaponData;
							if ((object)weaponBase3.weaponData != null)
							{
								nint num24 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num25 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v13 (WeaponData)+C4]");
								nint num26 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								object obj6 = num26 * 0;
								float num27 = (float)obj6 + num23;
								Vector3 vector2 = default(Vector3);
								posOffset = vector2;
								Transform transform4 = base.transform;
								if ((object)MyPlayer.Instance != null)
								{
									Transform transform5 = MyPlayer.Instance.transform;
									if ((object)transform5 != null)
									{
										Vector3 position3 = transform5.position;
										object obj7 = posOffset + position3.x;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+BC]");
										object obj8 = 0 + position3.y;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+C0]");
										object obj9 = 0 + position3.z;
										if ((object)transform4 != null)
										{
											Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
											transform4.position = position4;
											Transform transform6 = base.transform;
											_ = up.x;
											Vector3 upwards = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
											_ = up.y;
											Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
											_ = up.z;
											Quaternion quaternion = Quaternion.LookRotation(forward2, upwards);
											if ((object)transform6 != null)
											{
												Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
												_ = quaternion.x;
												transform6.rotation = rotation;
												if ((object)movingProjectile != null)
												{
													Transform transform7 = movingProjectile.transform;
													Transform transform8 = base.transform;
													if ((object)transform8 != null)
													{
														Vector3 position5 = transform8.position;
														if ((object)transform7 != null)
														{
															Vector3 position6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
															_ = position5.x;
															_ = position5.z;
															transform7.position = position6;
															if ((object)movingProjectile != null)
															{
																Transform transform9 = movingProjectile.transform;
																Transform transform10 = base.transform;
																if ((object)transform10 != null)
																{
																	Quaternion rotation2 = transform10.rotation;
																	if ((object)transform9 != null)
																	{
																		Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
																		_ = rotation2.x;
																		transform9.rotation = rotation3;
																		if ((object)movingProjectile != null)
																		{
																			Transform transform11 = movingProjectile.transform;
																			if ((object)transform11 != null)
																			{
																				Vector3 position7 = transform11.position;
																				movingProjectilePosition = (Vector3)position7.x;
																				_ = position7.z;
																				movingProjectileDir = (Vector3)num4;
																				if ((object)movingProjectile != null)
																				{
																					Transform transform12 = movingProjectile.transform;
																					if ((object)transform12 != null)
																					{
																						movingProjectileRotation = (Quaternion)transform12.rotation.x;
																						Transform transform13 = base.transform;
																						if ((object)transform13 != null)
																						{
																							Vector3 position8 = transform13.position;
																							hitboxPos = (Vector3)position8.x;
																							_ = position8.z;
																							float attackSizeMultiplier2 = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
																							float num28 = attackSizeMultiplier2 - 1f;
																							float num29 = num28 * 0.5f;
																							float num30 = num29 + 1f;
																							float num31 = num30 * projectileSpeed;
																							actualProjectileSpeed = num31;
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
		goto IL_0a1e;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+78]");
		float num6 = num5 * 0f;
		float num7 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+84]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+78]");
		float num2 = num * 0f;
		float num3 = MyTime.deltaTime * num2;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+D8]");
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
		//IL_00b5: Expected O, but got I
		//IL_0137: Expected O, but got Ref
		//IL_0145: Expected O, but got Ref
		//IL_0176: Expected O, but got Ref
		//IL_01a8: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_021b: Expected O, but got Ref
		//IL_0253: Expected O, but got Ref
		//IL_0275: Expected O, but got Ref
		//IL_02a5: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		if (collider != null && !((HashSet<object>)(object)hitEnemies).Contains((object)collider) && EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111))))
		{
			bool flag = hitEnemies.Add(collider);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
			Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num = centerPosition.x - position.x;
			float num2 = centerPosition.y - position.y;
			float num3 = centerPosition.z - position.z;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v20+8]");
			_ = 0;
			WeaponBase obj5 = weaponBase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
			float num4 = default(float);
			DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, this, (Enemy)0, vector, num4);
			float damage = damageMultiplier * damageContainer.damage;
			damageContainer.damage = damage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
			((Enemy)0).DamageFromPlayerWeapon(damageContainer);
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = position2.x;
			_ = position2.z;
			Vector3 vector2 = collider.ClosestPointOnBounds(position3);
			Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = movingProjectileDir;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileHeroSword)+78]");
			_ = 0;
			Vector3 hitPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = vector2.x;
			_ = vector2.z;
			weaponAttack.ProjectileHit(hitPos, moveDir, hitEnemy: true, (byte)(int)num4 != 0);
		}
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

	public ProjectileHeroSword()
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
