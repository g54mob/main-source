using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public abstract class ProjectileBase : MonoBehaviour
{
	public WeaponBase weaponBase;

	protected WeaponAttack weaponAttack;

	public float projectileRadius = 0.5f;

	private float baseProjectileRadius;

	public Vector3 direction;

	public int bounces;

	public int maxBounces;

	protected bool timedOut;

	protected float expirationTime;

	protected float projectileSpeed;

	protected static readonly RaycastHit[] raycastBuffer;

	protected Collider lastHitEnemy;

	protected HashSet<Collider> hitEnemies;

	public void Set(WeaponBase weaponBase, WeaponAttack weaponAttack, int projectileIndex)
	{
		//IL_028f: Invalid comparison between I4 and F4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected I4, but got Unknown
		//IL_012d: Invalid comparison between F4 and I4
		if (!(0f < baseProjectileRadius))
		{
			baseProjectileRadius = projectileRadius;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		bounces = 0;
		float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)45);
		float stat = PlayerStats.GetStat(EStat.ProjectileBounces);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		timedOut = false;
		lastHitEnemy = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		object obj = default(object);
		int num2 = 45 + obj;
		maxBounces = num2;
		hitEnemies.Clear();
		this.weaponBase = weaponBase;
		this.weaponAttack = weaponAttack;
		WeaponBase weaponBase2 = this.weaponBase;
		float num3 = ((Dictionary<System.Int32Enum, float>)(object)weaponBase2.weaponStats).get_Item((System.Int32Enum)10);
		float stat2 = PlayerStats.GetStat(EStat.DurationMultiplier);
		WeaponData weaponData = weaponBase2.weaponData;
		float num4 = stat2 * num3;
		if (weaponData.maxDuration > 0f && num4 > weaponData.maxDuration)
		{
			num4 = weaponData.maxDuration;
		}
		float num5 = MyTime.time + num4;
		expirationTime = num5;
		float num6 = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)11);
		float stat3 = PlayerStats.GetStat(EStat.ProjectileSpeedMultiplier);
		float num7 = stat3 * num6;
		projectileSpeed = num7;
		float size = weaponAttack.GetSize();
		float num8 = size * baseProjectileRadius;
		projectileRadius = num8;
		if (!TryInit(projectileIndex))
		{
			GameObject gameObject2 = base.gameObject;
			if (gameObject2.activeInHierarchy)
			{
				GameObject gameObject3 = base.gameObject;
				gameObject3.SetActive(value: false);
				this.weaponAttack.ProjectileDone(this);
			}
		}
		else
		{
			weaponAttack.SuccessfullySpawnedProjectile(this);
			CheckSpawnCollision();
		}
	}

	protected float GetDuration()
	{
		//IL_009f: Invalid comparison between F4 and I4
		WeaponBase weaponBase = this.weaponBase;
		if (this.weaponBase != null && weaponBase.weaponStats != null)
		{
			float num = ((Dictionary<System.Int32Enum, float>)(object)weaponBase.weaponStats).get_Item((System.Int32Enum)10);
			float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float num2 = stat * num;
				if (weaponData.maxDuration > 0f && num2 > weaponData.maxDuration)
				{
					num2 = weaponData.maxDuration;
				}
				return num2;
			}
		}
		throw new NullReferenceException();
	}

	protected abstract bool TryInit(int projectileIndex);

	private void FixedUpdate()
	{
		if (!MyTime.paused)
		{
			MyFixedUpdate();
			StepMovement();
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy && !timedOut && !(MyTime.time < expirationTime))
			{
				timedOut = true;
				ProjectileDone();
			}
		}
	}

	protected unsafe virtual void CheckSpawnCollision()
	{
		//IL_002c: Expected O, but got Ref
		//IL_007d: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), projectileRadius, out var buffer);
		if (enemiesInRadiusSafe > 0)
		{
			bool flag = CheckCollision(buffer[0], (Vector3)(&num));
		}
	}

	protected abstract Vector3 GetMovementDirection();

	protected unsafe virtual void StepMovement()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_008b: Expected O, but got I4
		//IL_00e8: Expected O, but got Ref
		//IL_00f6: Expected O, but got Ref
		//IL_03a2: Expected O, but got I
		//IL_027e: Expected O, but got Ref
		//IL_0331: Expected I, but got O
		//IL_033f: Expected O, but got Ref
		//IL_0378: Expected O, but got I
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_0160: Expected O, but got Ref
		//IL_016e: Expected O, but got Ref
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0229: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		ref Collider[] buffer = ref System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		_ = position.x;
		_ = position.z;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, projectileRadius, out buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		bool flag2 = false;
		object obj3 = 0;
		if (!flag)
		{
			bool flag4;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				object obj4 = 0;
				nint num = (nint)typeof(Vector3);
				Vector3 normal = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v10+20+v149 @ rbx_v6*8]");
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
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = movementDirection.x;
		_ = movementDirection.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		if (!flag2)
		{
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v22+8]");
			_ = 0;
			_ = position2.x;
			_ = position2.z;
			float maxDistance = default(float);
			int layerMask = default(int);
			QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
			int num3 = Physics.SphereCastNonAlloc(origin, projectileRadius, vector, raycastBuffer, maxDistance, layerMask, queryTriggerInteraction);
			if (num3 > 0)
			{
				RaycastHit raycastHit = (RaycastHit)(raycastBuffer + 32);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				object obj7 = raycastBuffer + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Vector3 normal2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rax_v39+8]");
				_ = 0;
				bool flag5 = CheckCollision(collider, normal2);
			}
		}
		Transform transform3 = base.transform;
		Vector3 position3 = transform3.position;
		object obj8 = default(object);
		float num4 = (float)obj8 * projectileSpeed;
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v22+4]");
		float num5 = 0f * projectileSpeed;
		float num6 = num4 + position3.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v22+8]");
		float num7 = 0f * projectileSpeed;
		float num8 = num5 + position3.y;
		float num9 = num7 + position3.z;
		transform3.position = position4;
	}

	private void Update()
	{
		if (!MyTime.paused)
		{
			MyUpdate();
		}
	}

	private void CheckTimeout()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy && !timedOut && !(MyTime.time < expirationTime))
		{
			timedOut = true;
			ProjectileDone();
		}
	}

	protected void ProjectileDone()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			weaponAttack.ProjectileDone(this);
		}
	}

	protected abstract void MyFixedUpdate();

	protected abstract void MyUpdate();

	protected unsafe virtual bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_0178: Expected I4, but got O
		//IL_015c: Expected O, but got Ref
		//IL_0145: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831727AC]");
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
				int num = LayerMask.NameToLayer("Ground");
				object obj = default(object);
				if (layer != num)
				{
					int num2 = LayerMask.NameToLayer("Object");
					if (layer != num2)
					{
						GameObject gameObject2 = collider.gameObject;
						if ((object)gameObject2 != null)
						{
							int layer2 = gameObject2.layer;
							int num3 = LayerMask.NameToLayer("Enemy");
							if (layer2 != num3)
							{
								return false;
							}
							return HitEnemy(collider, (Vector3)(&obj));
						}
						goto IL_016a;
					}
				}
				HitOther(collider, (Vector3)(&obj));
				return true;
			}
		}
		goto IL_016a;
		IL_016a:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe virtual bool HitEnemy(Collider collider, Vector3 normal)
	{
		//IL_0578: Expected I4, but got O
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Ref, but got Unknown
		//IL_00cd: Expected O, but got I
		//IL_0120: Expected O, but got I
		//IL_0181: Expected O, but got I
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0238: Expected O, but got I
		//IL_0276: Expected O, but got I
		//IL_02ac: Expected O, but got I
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_03e2: Expected I4, but got F4
		//IL_05da: Expected I, but got O
		//IL_0617: Expected O, but got I
		//IL_0634: Expected O, but got I
		//IL_067e: Invalid comparison between F4 and O
		_ = 0;
		if (!(lastHitEnemy != collider))
		{
			goto IL_055c;
		}
		if (hitEnemies != null)
		{
			if (((HashSet<object>)(object)hitEnemies).Contains((object)collider))
			{
				goto IL_055c;
			}
			EnemyManager instance = EnemyManager.Instance;
			if ((object)EnemyManager.Instance != null && instance.collidersToEnemies != null)
			{
				object obj = default(object);
				bool flag = ((Dictionary<object, object>)(object)instance.collidersToEnemies).TryGetValue((object)collider, out *(object*)(obj + 48));
				if (!flag)
				{
					MyLogger.LogErrorInBuild("AAH COLLIDER TO ENEMY FAILED? WTF?");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
				if ((UnityEngine.Object)0 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
					if ((nint)0 == 0)
					{
						goto IL_056a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
					if (((Enemy)0).IsDeadOrDyingNextFrame())
					{
						goto IL_055c;
					}
				}
				if (!flag)
				{
					goto IL_055c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
					if (((Enemy)0).IsDead())
					{
						goto IL_055c;
					}
					lastHitEnemy = collider;
					Vector3 movementDirection = GetMovementDirection();
					Collider key = (Collider)(obj - 80);
					Dictionary<Collider, Enemy> dictionary = (Dictionary<Collider, Enemy>)(obj - 64);
					_ = movementDirection.x;
					_ = movementDirection.z;
					bool flag2 = dictionary.TryGetValue(key, out *(Enemy*)null);
					Vector3 vector = (Vector3)(obj - 80);
					_ = ((bool*)(flag2 ? 1 : 0))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rax_v24 (System.Boolean)+8]");
					_ = 0;
					WeaponBase obj2 = this.weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
					float num = default(float);
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj2, this, (Enemy)0, vector, num);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
						((Enemy)0).DamageFromPlayerWeapon(damageContainer);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
							if (((Enemy)0).IsDead())
							{
								lastHitEnemy = null;
							}
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								Vector3 position = transform.position;
								if ((object)collider != null)
								{
									Vector3 position2 = (Vector3)(obj - 80);
									_ = position.x;
									_ = position.z;
									Vector3 vector2 = collider.ClosestPoint(position2);
									Vector3 movementDirection2 = GetMovementDirection();
									if ((object)weaponAttack != null)
									{
										Vector3 moveDir = (Vector3)(obj - 80);
										Vector3 hitPos = (Vector3)(obj - 64);
										_ = movementDirection2.x;
										_ = movementDirection2.z;
										_ = vector2.x;
										_ = vector2.z;
										weaponAttack.ProjectileHit(hitPos, moveDir, hitEnemy: true, (byte)(int)num != 0);
										int num2 = bounces + 1;
										bounces = num2;
										if (bounces >= maxBounces)
										{
											ProjectileDone();
										}
										WeaponBase weaponBase = this.weaponBase;
										if (this.weaponBase != null)
										{
											WeaponData weaponData = weaponBase.weaponData;
											if ((object)weaponBase.weaponData != null)
											{
												if (weaponData.amplificationMode == EAmplificationMode.Bounce && weaponData.canBounce)
												{
													FindMovementDirection();
													nint num3 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ rax_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num4 = 0;
													object obj3 = direction - Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileBase)+3C]");
													nint num5 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rcx_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
													object obj4 = num5 - 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileBase)+40]");
													nint num6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rcx_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													object obj5 = num6 - 0;
													object obj6 = obj4 * obj4;
													object obj7 = obj3 * obj3;
													object obj8 = obj5 * obj5;
													object obj9 = obj6 + obj7;
													object obj10 = obj9 + obj8;
													if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
													{
														ProjectileDone();
														return true;
													}
												}
												else
												{
													WeaponData weaponData2 = weaponBase.weaponData;
													if (weaponData2.amplificationMode == EAmplificationMode.Pierce)
													{
														if (hitEnemies == null)
														{
															goto IL_056a;
														}
														bool flag3 = hitEnemies.Add(collider);
													}
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
		goto IL_056a;
		IL_055c:
		return false;
		IL_056a:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected abstract void FindMovementDirection();

	protected unsafe virtual void HitOther(Collider collider, Vector3 normal)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Expected O, but got Ref
		//IL_005e: Expected O, but got Ref
		//IL_005e: Expected O, but got Ref
		//IL_0151: Expected O, but got Ref
		//IL_0396: Expected I, but got O
		//IL_0479: Expected I, but got O
		//IL_053c: Invalid comparison between F4 and I4
		//IL_0565: Expected O, but got I4
		//IL_024a: Expected O, but got Ref
		//IL_01b9: Expected O, but got Ref
		//IL_01fa: Expected F4, but got O
		//IL_01f5: Expected native int or pointer, but got O
		//IL_020f: Expected F4, but got I
		//IL_020a: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		Vector3 vector = collider.ClosestPointOnBounds((Vector3)(&num));
		Vector3 movementDirection = GetMovementDirection();
		float num2 = default(float);
		bool useSfx = default(bool);
		weaponAttack.ProjectileHit((Vector3)(&num2), (Vector3)(&num), hitEnemy: false, useSfx);
		WeaponBase weaponBase = this.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		if (weaponData.canBounce)
		{
			int num3 = bounces + 1;
			bounces = num3;
			if (bounces < maxBounces)
			{
				Vector3 movementDirection2 = GetMovementDirection();
				Transform transform2 = base.transform;
				Vector3 position2 = transform2.position;
				float num4 = movementDirection2.y * projectileSpeed;
				float num5 = movementDirection2.z * projectileSpeed;
				float num6 = position2.y - num4;
				transform2.position = (Vector3)(&num);
				nint num7 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rax_v28 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num8 = 0;
				float num9 = normal.x - (float)Vector3.zeroVector;
				float num10 = normal.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
				float num11 = num10 - 0f;
				float num12 = normal.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				float num13 = num12 - 0f;
				float num14 = num11 * num11;
				float num15 = num9 * num9;
				float num16 = num13 * num13;
				float num17 = num14 + num15;
				float num18 = num17 + num16;
				bool flag = !(9.9999994E-11f > num18);
				float num19 = num6;
				if (!flag)
				{
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					GameManager instance = GameManager.Instance;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
					int layerMask = default(int);
					bool flag2 = Physics.Raycast((Ray)(&num2), out var _, 999f, layerMask);
					bool flag3 = !flag2;
					num19 = movementDirection2.y;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
						object obj3 = default(object);
						((Vector3*)(nint)normal)->x = (float)obj3;
						Vector3 vector2 = normal;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rax_v48+8]");
						((Vector3*)(nint)vector2)->z = 0f;
						num19 = movementDirection2.y;
					}
				}
				nint num20 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num21 = 0;
				float num22 = normal.x - (float)Vector3.zeroVector;
				object obj4 = default(object);
				float num23 = (float)obj4 - num19;
				float num24 = normal.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				float num25 = num24 - 0f;
				float num26 = num23 * num23;
				float num27 = num22 * num22;
				float num28 = num25 * num25;
				float num29 = num26 + num27;
				float num30 = num29 + num28;
				bool flag4 = 9.9999994E-11f < num30;
				float num31 = 9.9999994E-11f - num30;
				bool flag5 = num31 == 0f;
				bool flag6 = !flag4;
				bool flag7 = !flag5;
				object obj5 = flag7 & flag6;
				if (obj5 != null)
				{
					Transform transform4 = base.transform;
					Vector3 position4 = transform4.position;
					Vector3 vector3 = default(Vector3);
					transform4.position = (Vector3)(&vector3);
					return;
				}
				float num32 = normal.y * movementDirection2.y;
				float num33 = normal.x * movementDirection2.x;
				float num34 = normal.z * movementDirection2.z;
				float num35 = num32 + num33;
				float num36 = num35 + num34;
				float num37 = num36 * -2f;
				float num38 = normal.z * num37;
				float num39 = num38 + movementDirection2.z;
				Vector3 vector4 = default(Vector3);
				direction = vector4;
				return;
			}
		}
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			weaponAttack.ProjectileDone(this);
		}
	}

	protected ProjectileBase()
	{
		HashSet<Collider> hashSet = (HashSet<Collider>)(object)new HashSet<object>();
		hitEnemies = hashSet;
		base._002Ector();
	}

	static ProjectileBase()
	{
		//IL_0019: Expected O, but got I4
		object obj = EnemyManager.maxNumEnemiesPooled + 1;
		RaycastHit[] array = new RaycastHit[obj];
		raycastBuffer = array;
	}
}
