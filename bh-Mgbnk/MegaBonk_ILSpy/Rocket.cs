using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	private float damage;

	private float spawnedAtTime;

	private float projectileSpeed;

	public float projectileRadius;

	private float upTime = 0.5f;

	private float expirationTime;

	private WeaponBase weaponBase;

	private bool useGenericPool;

	private string damageSource;

	public Action A_ProjectileDone;

	private Vector3 startDirection;

	private Vector3 lastDirection;

	private Enemy targetEnemy;

	private Vector3 currentDir;

	private float nextFindTime;

	protected static readonly RaycastHit[] raycastBuffer;

	private float procCoefficient;

	private DamageContainer reuseDc;

	public unsafe void Set(Vector3 pos, float damage, float procCoefficient, WeaponBase weaponBase, bool useGenericPool, string damageSource)
	{
		//IL_00dc: Expected O, but got Ref
		//IL_01d2: Expected I, but got O
		//IL_0139: Expected I, but got O
		string text = default(string);
		this.damageSource = text;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		bool flag = default(bool);
		this.useGenericPool = flag;
		WeaponBase weaponBase2 = default(WeaponBase);
		this.weaponBase = weaponBase2;
		this.damage = damage;
		float num = ((weaponBase2 == null) ? PlayerStats.GetStat(EStat.ProjectileSpeedMultiplier) : WeaponUtility.GetProjectileSpeed(weaponBase2));
		float num2 = num * 0.45f;
		projectileSpeed = num2;
		float stat = PlayerStats.GetStat(EStat.ProjectileSpeedMultiplier);
		float num3 = 0.5f / stat;
		upTime = num3;
		Transform transform = base.transform;
		float num4 = default(float);
		transform.position = (Vector3)(&num4);
		spawnedAtTime = MyTime.time;
		float num5 = MyTime.time + 3f;
		expirationTime = num5;
		CheckSpawnCollision();
		nint num6 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num7 = 0;
		lastDirection = Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		_ = 0;
		this.procCoefficient = procCoefficient;
		nint num8 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		float num10 = insideUnitSphere.y * 0.5f;
		object obj = default(object);
		float num11 = num10 + (float)obj;
		float num12 = insideUnitSphere.z * 0.5f;
		float num13 = num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num14 = num13 + 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj2 = default(object);
		startDirection = (Vector3)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v23+8]");
		_ = 0;
	}

	private void FixedUpdate()
	{
		if (!MyTime.paused)
		{
			StepMovement();
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy && !(MyTime.time < expirationTime))
			{
				ProjectileDone();
			}
		}
	}

	private unsafe Vector3 GetMovementDirection()
	{
		//IL_0370: Invalid comparison between I4 and F4
		//IL_032a: Expected F4, but got O
		//IL_0325: Expected native int or pointer, but got O
		//IL_033f: Expected F4, but got I
		//IL_033a: Expected native int or pointer, but got O
		//IL_0119: Expected F4, but got I4
		//IL_009a: Expected O, but got Ref
		//IL_01b9: Invalid comparison between I4 and F4
		//IL_0204: Expected F4, but got I4
		//IL_03c0: Expected O, but got I
		//IL_03fe: Invalid comparison between F4 and I4
		if (targetEnemy != null)
		{
			if ((object)targetEnemy == null)
			{
				goto IL_02c1;
			}
			if (!targetEnemy.IsDead())
			{
				goto IL_00bf;
			}
		}
		float num = nextFindTime;
		if (!(nextFindTime > MyTime.time))
		{
			num = MyTime.time + 0.5f;
			nextFindTime = num;
			Transform transform = base.transform;
			if ((object)transform == null)
			{
				goto IL_02c1;
			}
			Vector3 position = transform.position;
			float x = default(float);
			Enemy randomEnemyInRadius = EnemyTargeting.GetRandomEnemyInRadius((Vector3)(&x), 30f, useVision: true, null);
			targetEnemy = randomEnemyInRadius;
			x = position.x;
		}
		goto IL_00bf;
		IL_031b:
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)lastDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rocket)+6C]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
		IL_00bf:
		if (!(targetEnemy != null))
		{
			goto IL_031b;
		}
		float num2 = MyTime.time - spawnedAtTime;
		float num3 = num2 / upTime;
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
		if ((object)targetEnemy != null)
		{
			Vector3 centerPosition = targetEnemy.GetCenterPosition();
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				float num4 = 1f - num3;
				Vector3 position2 = transform2.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				float fixedDeltaTime = Time.fixedDeltaTime;
				float num5 = fixedDeltaTime * 10f;
				float num6 = num5 * projectileSpeed;
				if (!(0f > num6))
				{
					if (num6 > 1f)
					{
						num6 = 1f;
					}
				}
				else
				{
					num6 = 0f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v18+8]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rocket)+80]");
				object obj = num7 - 0;
				float num8 = (float)obj * num6;
				float num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rocket)+80]");
				float num10 = num9 + 0f;
				Vector3 vector2 = default(Vector3);
				currentDir = vector2;
				if (!(num4 > 0f))
				{
					lastDirection = vector2;
				}
				else
				{
					float num11 = 1f - num4;
					float num12 = num4 * (float)startDirection;
					float num13 = num11 * (float)currentDir;
					float num14 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rocket)+5C]");
					float num15 = num14 * 0f;
					float num16 = num12 + num13;
					float num17 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rocket)+7C]");
					float num18 = num17 * 0f;
					float num19 = num15 + num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					object obj2 = default(object);
					lastDirection = (Vector3)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v20+8]");
					_ = 0;
				}
				goto IL_031b;
			}
		}
		goto IL_02c1;
		IL_02c1:
		return (Vector3)new NullReferenceException();
	}

	public void SetTarget(Enemy targetEnemy)
	{
		this.targetEnemy = targetEnemy;
	}

	private unsafe void FindTarget()
	{
		//IL_0030: Expected O, but got Ref
		if (!(nextFindTime > MyTime.time))
		{
			float num = MyTime.time + 0.5f;
			nextFindTime = num;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			Enemy randomEnemyInRadius = EnemyTargeting.GetRandomEnemyInRadius((Vector3)(&obj), 30f, useVision: true, null);
			targetEnemy = randomEnemyInRadius;
		}
	}

	protected unsafe virtual void StepMovement()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_008b: Expected O, but got I4
		//IL_00b6: Expected O, but got Ref
		//IL_00ce: Expected O, but got Ref
		//IL_0431: Expected O, but got I
		//IL_03e7: Expected O, but got Ref
		//IL_0233: Expected O, but got Ref
		//IL_0338: Expected I, but got O
		//IL_0346: Expected O, but got Ref
		//IL_034b: Expected I, but got O
		//IL_0394: Expected O, but got I
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_0285: Expected O, but got Ref
		//IL_0133: Expected O, but got Ref
		//IL_0141: Expected O, but got Ref
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01fc: Expected O, but got Ref
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
				nint num2 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r10_v5 (Il2CppClass<Rocket>)+1A0]");
				buffer = ref *(Collider[]*)null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v10+20]");
				bool flag3 = CheckCollision((Collider)0, normal);
				obj3++;
				flag4 = (nint)obj3 < enemiesInRadiusSafe;
				flag2 = flag3;
			}
			while (flag4);
		}
		Vector3 movementDirection = GetMovementDirection();
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = movementDirection.z;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = movementDirection.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		if (!flag2)
		{
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v21+8]");
			_ = 0;
			_ = position2.x;
			_ = position2.z;
			float maxDistance = default(float);
			int layerMask = default(int);
			QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
			int num4 = Physics.SphereCastNonAlloc(origin, projectileRadius, direction, raycastBuffer, maxDistance, layerMask, queryTriggerInteraction);
			if (num4 > 0)
			{
				RaycastHit raycastHit = (RaycastHit)(raycastBuffer + 32);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				object obj7 = raycastBuffer + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Vector3 normal2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rax_v41+8]");
				_ = 0;
				bool flag5 = CheckCollision(collider, normal2);
			}
		}
		Transform transform3 = base.transform;
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v21+4]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v21+8]");
		_ = 0;
		Quaternion quaternion = Quaternion.LookRotation(forward);
		Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = quaternion.x;
		transform3.rotation = rotation;
		Transform transform4 = base.transform;
		Vector3 position3 = transform4.position;
		object obj8 = default(object);
		float num5 = (float)obj8 * projectileSpeed;
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v21+4]");
		float num6 = 0f * projectileSpeed;
		float num7 = num5 + position3.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v21+8]");
		float num8 = 0f * projectileSpeed;
		float num9 = num6 + position3.y;
		float num10 = num8 + position3.z;
		transform4.position = position4;
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

	protected unsafe virtual bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_0170: Expected I4, but got O
		//IL_0145: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172D17]");
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
							object obj = default(object);
							return HitEnemy(collider, (Vector3)(&obj));
						}
						goto IL_0162;
					}
				}
				ProjectileDone();
				return true;
			}
		}
		goto IL_0162;
		IL_0162:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool HitEnemy(Collider collider, Vector3 normal)
	{
		//IL_026c: Expected I4, but got O
		//IL_014a: Expected O, but got Ref
		GameObject gameObject = base.gameObject;
		DamageContainer damageContainer;
		Enemy enemy2;
		if ((object)gameObject != null)
		{
			if (!gameObject.activeSelf)
			{
				goto IL_0250;
			}
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
				{
					goto IL_0250;
				}
				if ((object)enemy != null)
				{
					if (enemy.IsDead())
					{
						goto IL_0250;
					}
					if (weaponBase != null)
					{
						if ((object)enemy != null)
						{
							Vector3 centerPosition = enemy.GetCenterPosition();
							if ((object)MyPlayer.Instance != null)
							{
								Transform transform = MyPlayer.Instance.transform;
								if ((object)transform != null)
								{
									Vector3 position = transform.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
									float num = default(float);
									float forceDamage = default(float);
									damageContainer = WeaponUtility.GetDamageContainer(weaponBase, null, enemy, (Vector3)(&num), forceDamage);
									if ((object)enemy != null)
									{
										enemy2 = enemy;
										goto IL_02cf;
									}
								}
							}
						}
					}
					else if (reuseDc != null)
					{
						reuseDc.Reuse(procCoefficient, damageSource);
						DamageContainer damageContainer2 = reuseDc;
						if (reuseDc != null)
						{
							damageContainer2.damage = damage;
							DamageContainer damageContainer3 = reuseDc;
							if (reuseDc != null)
							{
								damageContainer3.enemy = enemy;
								if ((object)enemy != null)
								{
									damageContainer = reuseDc;
									enemy2 = enemy;
									goto IL_02cf;
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02cf:
		enemy2.DamageFromPlayerWeapon(damageContainer);
		ProjectileDone();
		return true;
		IL_0250:
		return false;
	}

	private void HitOther(Collider collider, Vector3 normal)
	{
		ProjectileDone();
	}

	private void CheckTimeout()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy && !(MyTime.time < expirationTime))
		{
			ProjectileDone();
		}
	}

	protected unsafe void ProjectileDone()
	{
		//IL_0065: Expected I, but got O
		//IL_00cb: Expected O, but got Ref
		//IL_00de: Expected I, but got O
		GameObject gameObject = base.gameObject;
		if (gameObject.activeSelf)
		{
			PoolManager instance = PoolManager.Instance;
			GameObject gameObject2 = instance.explosionPool.Get();
			bool flag = gameObject2 != null;
			bool flag2 = !flag;
			nint num = unchecked((nint)null);
			if (!flag2)
			{
				Transform transform = gameObject2.transform;
				Transform transform2 = base.transform;
				Vector3 position = transform2.position;
				Transform transform3 = base.transform;
				Vector3 forward = transform3.forward;
				float num2 = default(float);
				transform.position = (Vector3)(&num2);
				gameObject2.SetActive(value: true);
				num = unchecked((nint)null);
			}
			if (useGenericPool)
			{
				GameObject gameObject3 = base.gameObject;
				gameObject3.SetActive(value: false);
				PoolManager instance2 = PoolManager.Instance;
				GameObject element = base.gameObject;
				instance2.rocketPool.Release(element);
				num = 0;
			}
			Action a_ProjectileDone = A_ProjectileDone;
			if (A_ProjectileDone != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v261.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public Rocket()
	{
		DamageContainer damageContainer = new DamageContainer(0f, "");
		reuseDc = damageContainer;
		base._002Ector();
	}

	static Rocket()
	{
		RaycastHit[] array = new RaycastHit[1];
		raycastBuffer = array;
	}
}
