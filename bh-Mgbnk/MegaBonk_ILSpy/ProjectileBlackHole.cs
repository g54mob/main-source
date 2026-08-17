using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ProjectileBlackHole : ProjectileBase
{
	public float collisionCooldown = 0.3f;

	private float forwardOffset;

	private float upOffset;

	private Vector3 pushDir;

	private Vector3 defaultSize;

	private float startFadeTime;

	private float maxSize = 35f;

	private Vector3 desiredPosition;

	private Vector3 startPosition;

	private float moveTime = 2f;

	private float nextCheckDamageTime;

	private HashSet<Enemy> suckedEnemies;

	private float moveTimer;

	private Vector3 startScaleSize;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0756: Expected I, but got O
		//IL_0793: Expected O, but got I
		//IL_07b0: Expected O, but got I
		//IL_07fa: Invalid comparison between F4 and O
		//IL_0629: Expected I4, but got O
		//IL_0065: Expected O, but got F4
		//IL_0675: Expected I, but got O
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_0451: Expected O, but got F4
		//IL_081f: Expected I, but got O
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected Ref, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_055e: Expected I4, but got O
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		_ = 0;
		_ = 0;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj3 = defaultSize - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBlackHole)+84]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj4 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBlackHole)+88]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj5 = num4 - 0;
		object obj6 = obj4 * obj4;
		object obj7 = obj3 * obj3;
		object obj8 = obj5 * obj5;
		object obj9 = obj6 + obj7;
		object obj10 = obj9 + obj8;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
		{
			Transform transform = base.transform;
			if ((object)transform == null)
			{
				goto IL_061b;
			}
			Vector3 localScale = transform.localScale;
			defaultSize = (Vector3)localScale.x;
			_ = localScale.z;
		}
		Transform transform2 = base.transform;
		if ((object)transform2 != null)
		{
			if (transform2.localScale.x > maxSize)
			{
				Transform transform3 = base.transform;
				nint num5 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v48 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num6 = 0;
				_ = Vector3.oneVector;
				float num7 = (float)Vector3.oneVector * maxSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
				float num8 = 0f * maxSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num9 = 0f * maxSize;
				if ((object)transform3 == null)
				{
					goto IL_061b;
				}
				Vector3 localScale2 = (Vector3)(obj - 89);
				transform3.localScale = localScale2;
			}
			Transform transform4 = base.transform;
			if ((object)transform4 != null)
			{
				Vector3 position = transform4.position;
				float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
				WeaponBase weaponBase = base.weaponBase;
				if (base.weaponBase != null)
				{
					WeaponData weaponData = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null)
					{
						_ = position.x;
						Vector3 position2 = (Vector3)(obj - 89);
						_ = position.z;
						GameObject gameObject = default(GameObject);
						Enemy enemy = EnemyTargeting.GetEnemy(position2, weaponRange, projectileIndex, weaponData.useVision, gameObject);
						if (!(enemy != null))
						{
							return false;
						}
						if ((object)enemy != null)
						{
							Vector3 feetPosition = enemy.GetFeetPosition();
							if ((object)MyPlayer.Instance != null)
							{
								Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
								float num10 = feetPosition.x - feetPosition2.x;
								float num11 = feetPosition.y - feetPosition2.y;
								float num12 = feetPosition.z - feetPosition2.z;
								object obj11 = obj - 89;
								object obj12 = obj - 73;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
								float num13 = projectileRadius * 1.1f;
								float num14 = num13 + 8f;
								forwardOffset = num14;
								Transform transform5 = base.transform;
								if ((object)MyPlayer.Instance != null)
								{
									Transform transform6 = MyPlayer.Instance.transform;
									if ((object)transform6 != null)
									{
										Vector3 position3 = transform6.position;
										if ((object)transform5 != null)
										{
											Vector3 position4 = (Vector3)(obj - 89);
											_ = position3.x;
											_ = position3.z;
											transform5.position = position4;
											Transform transform7 = base.transform;
											if ((object)transform7 != null)
											{
												Vector3 position5 = transform7.position;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v26+8]");
												float num15 = 0f * forwardOffset;
												float num16 = num15 + position5.z;
												moveTimer = 0f;
												Vector3 vector = default(Vector3);
												desiredPosition = vector;
												Transform transform8 = base.transform;
												if ((object)transform8 != null)
												{
													Vector3 position6 = transform8.position;
													startPosition = (Vector3)position6.x;
													_ = position6.z;
													nextCheckDamageTime = 0f;
													float num17 = maxSize * 0.5f;
													float num18 = projectileRadius;
													if (projectileRadius > num17)
													{
														num18 = num17;
													}
													float num19 = expirationTime - 0.3f;
													projectileRadius = num18;
													startFadeTime = num19;
													nint num20 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num21 = 0;
													startScaleSize = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v752 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													Transform transform9 = base.transform;
													if ((object)transform9 != null)
													{
														Vector3 position7 = transform9.position;
														GameManager instance = GameManager.Instance;
														if ((object)GameManager.Instance != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
															ref RaycastHit hitInfo = ref *(RaycastHit*)(obj - 57);
															Vector3 vector2 = (Vector3)(obj - 89);
															Vector3 origin = (Vector3)(obj - 73);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v26+8]");
															_ = 0;
															_ = position7.x;
															_ = position7.z;
															if (Physics.Raycast(origin, vector2, out hitInfo, forwardOffset, (int)gameObject))
															{
																object obj13 = obj - 57;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
																Transform transform10 = base.transform;
																if ((object)transform10 == null)
																{
																	goto IL_061b;
																}
																Vector3 forward = transform10.forward;
																float num22 = projectileRadius * forward.z;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v46+8]");
																float num23 = 0f - num22;
																desiredPosition = vector;
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
		goto IL_061b;
		IL_061b:
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

	protected override void MyFixedUpdate()
	{
		CheckDamage();
	}

	private unsafe void CheckDamage()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00aa: Expected O, but got Ref
		//IL_03d6: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_01c3: Expected O, but got Ref
		//IL_01fe: Expected O, but got Ref
		//IL_01fe: Expected O, but got I
		//IL_022f: Expected O, but got I
		//IL_0245: Expected O, but got I
		//IL_0415: Expected O, but got I
		//IL_0267: Expected O, but got I
		//IL_0290: Expected O, but got I
		//IL_02f1: Expected O, but got Ref
		//IL_02f1: Expected O, but got I
		//IL_02ac: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_032c: Expected O, but got Ref
		//IL_035e: Expected I4, but got F4
		//IL_035e: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + collisionCooldown;
		nextCheckDamageTime = num;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		if (1f > moveTimer)
		{
			float num2 = Easing.OutQuad(moveTimer);
		}
		Transform transform2 = base.transform;
		_ = 1;
		Vector3 position2 = transform2.position;
		float num3 = projectileRadius;
		float num4 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num4), projectileRadius, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120)));
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		num4 = position2.x;
		EWeapon eWeapon = EWeapon.FireStaff;
		float num6 = default(float);
		float num7 = default(float);
		float x = default(float);
		float num8 = default(float);
		GameObject weaponHitEffect = default(GameObject);
		bool useSfx = default(bool);
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
			object obj3 = 0;
			ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			EnemyManager instance = EnemyManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ r10_v6+20+v413 @ rbx_v8 (EWeapon)*8]");
			if (instance.GetEnemy((Collider)0, out enemy))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
				if (!((Enemy)0).IsDead())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					Transform transform3 = ((Component)0).transform;
					Vector3 position3 = transform3.position;
					Transform transform4 = MyPlayer.Instance.transform;
					Vector3 position4 = transform4.position;
					float num5 = position3.x - position4.x;
					Vector3 vector = VectorExtensions.XZVector((Vector3)(&num4));
					num3 = vector.x;
					WeaponBase obj4 = weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj4, null, (Enemy)0, (Vector3)(&num6), num7);
					damageContainer.knockback = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					((Enemy)0).DamageFromPlayerWeapon(damageContainer);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					if (!((Enemy)0).IsStageBoss())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
						object obj5 = 0;
						Transform target = base.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rax_v54+58]");
						((EnemyMovementRb)0).Suck(target);
						HashSet<Enemy> hashSet = suckedEnemies;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
						bool flag = hashSet.Add((Enemy)0);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
					object obj6 = 0;
					Transform transform5 = base.transform;
					Vector3 position5 = transform5.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rcx_v32+20+v413 @ rbx_v8 (EWeapon)*8]");
					Vector3 vector2 = ((Collider)0).ClosestPoint((Vector3)(&x));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					bool hitEnemy = (UnityEngine.Object)0;
					Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					_ = vector.z;
					EffectManager.Instance.EnemyHitEffect((Vector3)(&num8), moveDir, hitEnemy, (EWeapon)num7, weaponHitEffect, useSfx);
					_ = 0;
					x = position5.x;
					num6 = num3;
					num4 = num5;
				}
			}
			eWeapon++;
		}
		while ((int)eWeapon < enemiesInRadiusSafe);
	}

	private unsafe void OnDisable()
	{
		//IL_0095: Expected O, but got I
		if (suckedEnemies != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			UnityEngine.Object obj = default(UnityEngine.Object);
			while (enumerator.MoveNext())
			{
				if (obj != null)
				{
					if ((object)obj == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ stack_-30 (UnityEngine.Object)+58]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ stack_-30 (UnityEngine.Object)+58]");
					((EnemyMovementRb)0).StopSuck();
				}
			}
			((HashSet<Enemy>.Enumerator*)(&enumerator))->Dispose();
			if (suckedEnemies != null)
			{
				suckedEnemies.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void MyUpdate()
	{
		//IL_033b: Invalid comparison between I4 and F4
		//IL_0051: Expected F4, but got I4
		//IL_0063: Expected O, but got Ref
		//IL_0229: Expected I, but got O
		//IL_0266: Expected O, but got I
		//IL_0283: Expected O, but got I
		//IL_02cd: Invalid comparison between F4 and O
		//IL_0106: Invalid comparison between I4 and F4
		//IL_0151: Expected F4, but got I4
		//IL_00ba: Expected O, but got F4
		//IL_02fc: Invalid comparison between I4 and F4
		//IL_018d: Expected F4, but got I4
		//IL_019f: Expected O, but got Ref
		if (!(moveTimer < 1f))
		{
			return;
		}
		float num = MyTime.deltaTime / moveTime;
		if ((moveTimer = num + moveTimer) > 1f)
		{
			moveTimer = 1f;
		}
		Transform transform = base.transform;
		float num2 = Easing.OutQuad(moveTimer);
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
		float num3 = default(float);
		transform.position = (Vector3)(&num3);
		if (!(MyTime.time > startFadeTime))
		{
			return;
		}
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num5 = 0;
		object obj = startScaleSize - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBlackHole)+C8]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num6 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileBlackHole)+CC]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num7 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 + obj5;
		object obj8 = obj7 + obj6;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			Transform transform2 = base.transform;
			Vector3 localScale = transform2.localScale;
			startScaleSize = (Vector3)localScale.x;
			_ = localScale.z;
		}
		float num8 = expirationTime - startFadeTime;
		float num9 = MyTime.time - startFadeTime;
		float num10 = num9 / num8;
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
		Transform transform3 = base.transform;
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
		transform3.localScale = (Vector3)(&num3);
	}

	protected override void FindMovementDirection()
	{
	}

	private float GetRadius()
	{
		return projectileRadius;
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_002b: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		Gizmos.DrawWireSphere((Vector3)(&obj), projectileRadius);
	}

	public ProjectileBlackHole()
	{
		HashSet<Enemy> hashSet = (HashSet<Enemy>)(object)new HashSet<object>();
		suckedEnemies = hashSet;
		base._002Ector();
	}
}
