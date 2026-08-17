using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

public class ItemProjectile : MonoBehaviour
{
	public bool ignoreGroundCollision;

	public float projectileSpeed = 0.5f;

	public float projectileRadius = 0.5f;

	private float damage;

	protected float spawnedAtTime;

	private float finalProjectileSpeed;

	private float upTime = 0.4f;

	protected float expirationTime;

	private string damageSource;

	protected int projectileIndex;

	protected int projectilesCount;

	private float range;

	private Vector3 startDirection;

	private Vector3 lastDirection;

	private Enemy targetEnemy;

	private Vector3 currentDir;

	private float nextFindTime;

	protected static readonly RaycastHit[] raycastBuffer;

	private float procCoefficient;

	private DamageContainer reuseDc;

	public ObjectPool<GameObject> projectilePool;

	public GameObject projectileHitEffect;

	public unsafe void Set(Vector3 pos, float damage, float procCoefficient, string damageSource, ObjectPool<GameObject> projectilePool, int projectileIndex, int totalProjectiles, float duration, float range)
	{
		//IL_00cc: Expected O, but got F4
		//IL_001d: Expected O, but got I
		//IL_00bd: Expected O, but got Ref
		//IL_0140: Expected I, but got O
		this.damageSource = (string)range;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		IntPtr intPtr = default(IntPtr);
		this.projectilePool = (ObjectPool<GameObject>)(nint)intPtr;
		this.damage = damage;
		int num = default(int);
		this.projectileIndex = num;
		int num2 = default(int);
		projectilesCount = num2;
		float num3 = default(float);
		this.range = num3;
		float stat = PlayerStats.GetStat(EStat.ProjectileSpeedMultiplier);
		float num4 = stat * projectileSpeed;
		finalProjectileSpeed = num4;
		float stat2 = PlayerStats.GetStat(EStat.ProjectileSpeedMultiplier);
		float num5 = 0.5f / stat2;
		upTime = num5;
		Transform transform = base.transform;
		float num6 = default(float);
		transform.position = (Vector3)(&num6);
		spawnedAtTime = MyTime.time;
		float stat3 = PlayerStats.GetStat(EStat.DurationMultiplier);
		object obj = default(object);
		float num7 = stat3 * (float)obj;
		float num8 = num7 + MyTime.time;
		expirationTime = num8;
		CheckSpawnCollision();
		this.procCoefficient = procCoefficient;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		float num11 = insideUnitSphere.z * 0.85f;
		float num12 = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num13 = num12 + 0f;
		float num14 = insideUnitSphere.y * 0.85f;
		object obj2 = default(object);
		float num15 = num14 + (float)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj3 = default(object);
		startDirection = (Vector3)obj3;
		lastDirection = (Vector3)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v20+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v20+8]");
		_ = 0;
		Init();
	}

	public void AddDamage(float damage)
	{
		float num = damage + this.damage;
		this.damage = num;
	}

	protected virtual void Init()
	{
	}

	private void FixedUpdate()
	{
		if (!MyTime.paused)
		{
			Step();
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy && !(MyTime.time < expirationTime))
			{
				ProjectileDone();
			}
		}
	}

	protected virtual void Step()
	{
		StepAttackMovement();
	}

	protected unsafe virtual Vector3 GetMovementDirection()
	{
		//IL_02e4: Invalid comparison between I4 and F4
		//IL_029e: Expected F4, but got O
		//IL_0299: Expected native int or pointer, but got O
		//IL_02b3: Expected F4, but got I
		//IL_02ae: Expected native int or pointer, but got O
		//IL_00d4: Expected F4, but got I4
		//IL_0174: Invalid comparison between I4 and F4
		//IL_01bf: Expected F4, but got I4
		//IL_0334: Expected O, but got I
		//IL_0372: Invalid comparison between F4 and I4
		if (targetEnemy != null)
		{
			if ((object)targetEnemy == null)
			{
				goto IL_027c;
			}
			if (!targetEnemy.IsDead())
			{
				goto IL_007a;
			}
		}
		FindTarget();
		goto IL_007a;
		IL_027c:
		return (Vector3)new NullReferenceException();
		IL_028f:
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)lastDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ItemProjectile)+68]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
		IL_007a:
		if (!(targetEnemy != null))
		{
			goto IL_028f;
		}
		float num = MyTime.time - spawnedAtTime;
		float num2 = num / upTime;
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
		if ((object)targetEnemy != null)
		{
			Vector3 centerPosition = targetEnemy.GetCenterPosition();
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				float num3 = 1f - num2;
				Vector3 position = transform.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				float fixedDeltaTime = Time.fixedDeltaTime;
				float num4 = fixedDeltaTime * 10f;
				float num5 = num4 * finalProjectileSpeed;
				if (!(0f > num5))
				{
					if (num5 > 1f)
					{
						num5 = 1f;
					}
				}
				else
				{
					num5 = 0f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v18+8]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ItemProjectile)+80]");
				object obj = num6 - 0;
				float num7 = (float)obj * num5;
				float num8 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ItemProjectile)+80]");
				float num9 = num8 + 0f;
				Vector3 vector2 = default(Vector3);
				currentDir = vector2;
				if (!(num3 > 0f))
				{
					lastDirection = vector2;
				}
				else
				{
					float num10 = 1f - num3;
					float num11 = num10 * (float)currentDir;
					float num12 = num3 * (float)startDirection;
					float num13 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ItemProjectile)+7C]");
					float num14 = num13 * 0f;
					float num15 = num11 + num12;
					float num16 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ItemProjectile)+58]");
					float num17 = num16 * 0f;
					float num18 = num14 + num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					object obj2 = default(object);
					lastDirection = (Vector3)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rax_v20+8]");
					_ = 0;
				}
				goto IL_028f;
			}
		}
		goto IL_027c;
	}

	private unsafe void FindTarget()
	{
		//IL_0051: Expected O, but got Ref
		//IL_0102: Expected O, but got Ref
		if (!(nextFindTime > MyTime.time))
		{
			float num = MyTime.time + 0.5f;
			nextFindTime = num;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			float num2 = range * 0.5f;
			bool useVision = projectileIndex == 0;
			float x = default(float);
			Enemy randomEnemyInRadius = EnemyTargeting.GetRandomEnemyInRadius((Vector3)(&x), num2, useVision, null);
			targetEnemy = randomEnemyInRadius;
			bool flag = targetEnemy == null;
			bool flag2 = !flag;
			GameObject gameObject = null;
			float num3 = num2;
			x = position.x;
			if (!flag2)
			{
				Transform transform2 = base.transform;
				Vector3 position2 = transform2.position;
				float num4 = range * 0.5f;
				bool useVision2 = projectileIndex == 0;
				Enemy randomEnemyInRadius2 = EnemyTargeting.GetRandomEnemyInRadius((Vector3)(&x), num4, useVision2, null);
				targetEnemy = randomEnemyInRadius2;
				gameObject = null;
				num3 = num4;
				x = position2.x;
			}
			if (targetEnemy == null)
			{
				Transform transform3 = MyPlayer.Instance.transform;
				Vector3 position3 = transform3.position;
				Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
				Transform transform4 = base.transform;
				Vector3 position4 = transform4.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				object obj = default(object);
				lastDirection = (Vector3)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rax_v28+8]");
				_ = 0;
			}
		}
	}

	protected unsafe virtual void StepAttackMovement()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_008b: Expected O, but got I4
		//IL_00b6: Expected O, but got Ref
		//IL_00c4: Expected O, but got Ref
		//IL_03cd: Expected O, but got Ref
		//IL_0417: Expected O, but got I
		//IL_022e: Expected O, but got Ref
		//IL_0280: Expected O, but got Ref
		//IL_0333: Expected I, but got O
		//IL_0341: Expected O, but got Ref
		//IL_037a: Expected O, but got I
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_012e: Expected O, but got Ref
		//IL_013c: Expected O, but got Ref
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01f7: Expected O, but got Ref
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
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
			Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v22+8]");
			_ = 0;
			_ = position2.x;
			_ = position2.z;
			float maxDistance = default(float);
			int layerMask = default(int);
			QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
			int num3 = Physics.SphereCastNonAlloc(origin, projectileRadius, direction, raycastBuffer, maxDistance, layerMask, queryTriggerInteraction);
			if (num3 > 0)
			{
				RaycastHit raycastHit = (RaycastHit)(raycastBuffer + 32);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				object obj7 = raycastBuffer + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Vector3 normal2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rax_v42+8]");
				_ = 0;
				bool flag5 = CheckCollision(collider, normal2);
			}
		}
		Transform transform3 = base.transform;
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v22+4]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v22+8]");
		_ = 0;
		Quaternion quaternion = Quaternion.LookRotation(forward);
		Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = quaternion.x;
		transform3.rotation = rotation;
		Transform transform4 = base.transform;
		Vector3 position3 = transform4.position;
		object obj8 = default(object);
		float num4 = (float)obj8 * finalProjectileSpeed;
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v22+4]");
		float num5 = 0f * finalProjectileSpeed;
		float num6 = num4 + position3.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v22+8]");
		float num7 = 0f * finalProjectileSpeed;
		float num8 = num5 + position3.y;
		float num9 = num7 + position3.z;
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

	protected virtual bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_025d: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172CB2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		if (gameObject.activeSelf)
		{
			GameObject gameObject2 = collider.gameObject;
			int layer = gameObject2.layer;
			if (ignoreGroundCollision)
			{
				goto IL_00ee;
			}
			int num = LayerMask.NameToLayer("Ground");
			if (layer != num)
			{
				int num2 = LayerMask.NameToLayer("Object");
				if (layer != num2)
				{
					goto IL_00ee;
				}
			}
			goto IL_0219;
		}
		goto IL_022d;
		IL_022d:
		return false;
		IL_0219:
		ProjectileDone();
		return true;
		IL_00ee:
		GameObject gameObject3 = collider.gameObject;
		int layer2 = gameObject3.layer;
		int num3 = LayerMask.NameToLayer("Enemy");
		if (layer2 == num3)
		{
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
				{
					goto IL_022d;
				}
				if ((object)enemy != null)
				{
					if (enemy.IsDead())
					{
						goto IL_022d;
					}
					Vector3 direction = default(Vector3);
					Enemy enemy2 = default(Enemy);
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, damage, procCoefficient, damageSource, direction, enemy2);
					reuseDc = damageContainer;
					if ((object)enemy != null)
					{
						enemy.DamageFromPlayerOther(reuseDc);
						goto IL_0219;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_022d;
	}

	private bool HitEnemy(Collider collider, Vector3 normal)
	{
		//IL_00f5: Expected I4, but got O
		if ((object)EnemyManager.Instance != null)
		{
			if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
			{
				goto IL_00e1;
			}
			if ((object)enemy != null)
			{
				if (enemy.IsDead())
				{
					goto IL_00e1;
				}
				Vector3 direction = default(Vector3);
				Enemy enemy2 = default(Enemy);
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, damage, procCoefficient, damageSource, direction, enemy2);
				reuseDc = damageContainer;
				if ((object)enemy != null)
				{
					enemy.DamageFromPlayerOther(reuseDc);
					ProjectileDone();
					return true;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_00e1:
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

	protected unsafe virtual void ProjectileDone()
	{
		//IL_0044: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Vector3 movementDirection = GetMovementDirection();
		object obj = default(object);
		object obj2 = default(object);
		string source = default(string);
		GameObject weaponHitEffect = default(GameObject);
		bool useSfx = default(bool);
		EffectManager.Instance.EnemyHitEffect((Vector3)(&obj), (Vector3)(&obj2), hitEnemy: true, source, weaponHitEffect, useSfx);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		GameObject element = base.gameObject;
		projectilePool.Release(element);
	}

	public ItemProjectile()
	{
		DamageContainer damageContainer = new DamageContainer(1f, "");
		reuseDc = damageContainer;
		base._002Ector();
	}

	static ItemProjectile()
	{
		RaycastHit[] array = new RaycastHit[1];
		raycastBuffer = array;
	}
}
