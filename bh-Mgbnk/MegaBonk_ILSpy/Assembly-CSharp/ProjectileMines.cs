using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ProjectileMines : ProjectileBase
{
	public Rigidbody rb;

	private float checkInterval = 0.5f;

	private float nextCheckTime;

	private float checkRadius = 2f;

	private float scaleInTime = 0.5f;

	private float spawnedAtTime;

	private float scaleMultiplier;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_012d: Expected I4, but got O
		//IL_0013: Expected O, but got Ref
		//IL_0119: Expected O, but got Ref
		spawnedAtTime = MyTime.time;
		Transform transform = base.transform;
		if ((object)transform == null)
		{
			goto IL_011f;
		}
		Vector3 vector = default(Vector3);
		transform.localScale = (Vector3)(&vector);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier - 1f;
		float num2 = num * 0.3f;
		float num3 = num2 + 1f;
		bool flag = 1f > num3;
		float num4 = 1f;
		if (!flag)
		{
			bool flag2 = !(num3 > 3f);
			num4 = 3f;
			if (flag2)
			{
				goto IL_014f;
			}
		}
		num3 = num4;
		goto IL_014f;
		IL_014f:
		scaleMultiplier = num3;
		float num5 = num3 + num3;
		checkRadius = num5;
		if ((object)MyPlayer.Instance != null)
		{
			Transform transform2 = MyPlayer.Instance.transform;
			if ((object)transform2 != null)
			{
				Vector3 position = transform2.position;
				if ((object)rb != null)
				{
					rb.MovePosition((Vector3)(&vector));
					return true;
				}
			}
		}
		goto IL_011f;
		IL_011f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Update()
	{
		//IL_0103: Invalid comparison between I4 and F4
		//IL_0074: Expected F4, but got I4
		//IL_014a: Invalid comparison between I4 and F4
		//IL_00b0: Expected F4, but got I4
		//IL_00c2: Expected O, but got Ref
		Transform transform = base.transform;
		if (!(transform.localScale.x < scaleMultiplier))
		{
			return;
		}
		float num = MyTime.time - spawnedAtTime;
		float num2 = num / scaleInTime;
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
		Transform transform2 = base.transform;
		float num3 = Easing.OutQuad(num2);
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
		float num4 = default(float);
		transform2.localScale = (Vector3)(&num4);
	}

	protected unsafe override void MyFixedUpdate()
	{
		//IL_0036: Expected O, but got Ref
		//IL_0055: Expected O, but got I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		float num = spawnedAtTime + scaleInTime;
		if (num > MyTime.time || MyTime.time < nextCheckTime)
		{
			return;
		}
		float num2 = MyTime.time + checkInterval;
		nextCheckTime = num2;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num3 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num3), checkRadius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		if (flag)
		{
			return;
		}
		Enemy enemy;
		while (!EnemyManager.Instance.GetEnemy(buffer[obj], out enemy) || enemy.IsDead())
		{
			obj++;
			if ((nint)obj >= enemiesInRadiusSafe)
			{
				return;
			}
		}
		Explode();
	}

	private unsafe void Explode()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0043: Expected O, but got Ref
		//IL_007e: Expected O, but got I4
		//IL_0330: Expected O, but got I
		//IL_00ac: Expected O, but got I
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_00da: Expected O, but got I
		//IL_02d5: Expected O, but got Ref
		//IL_012c: Expected O, but got Ref
		//IL_02f9: Expected O, but got Ref
		//IL_0161: Expected O, but got Ref
		//IL_0161: Expected O, but got I
		//IL_017f: Expected O, but got I
		//IL_018f: Expected O, but got I
		//IL_01cb: Expected O, but got Ref
		//IL_01cb: Expected O, but got I
		//IL_01fc: Expected I4, but got F4
		//IL_01fc: Expected O, but got Ref
		//IL_01fc: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), projectileRadius, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120)));
		float x2 = default(float);
		if (enemiesInRadiusSafe > 0)
		{
			num = position.x;
			object obj3 = 0;
			object obj7 = default(object);
			float num3 = default(float);
			float x = default(float);
			float num4 = default(float);
			object obj9 = default(object);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
				object obj4 = 0;
				ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
				EnemyManager instance = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r10_v5+20+v184 @ rbx_v10*8]");
				if (instance.GetEnemy((Collider)0, out enemy))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
					Transform transform2 = MyPlayer.Instance.transform;
					Vector3 position2 = transform2.position;
					float num2 = centerPosition.x - position2.x;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					WeaponBase obj6 = weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj6, this, (Enemy)0, (Vector3)(&obj7), num3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					((Enemy)0).DamageFromPlayerWeapon(damageContainer);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
					object obj8 = 0;
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v38+20+v184 @ rbx_v10*8]");
					Vector3 vector = ((Collider)0).ClosestPoint((Vector3)(&x));
					Vector3 movementDirection = GetMovementDirection();
					weaponAttack.ProjectileHit((Vector3)(&x2), (Vector3)(&num4), hitEnemy: true, (byte)(int)num3 != 0);
					x2 = vector.x;
					x = position3.x;
					obj7 = obj9;
					num = num2;
				}
				obj3++;
			}
			while ((nint)obj3 < enemiesInRadiusSafe);
		}
		PoolManager instance2 = PoolManager.Instance;
		GameObject gameObject = instance2.explosionPool.Get();
		if (gameObject != null)
		{
			Transform transform4 = gameObject.transform;
			Transform transform5 = base.transform;
			Vector3 position4 = transform5.position;
			transform4.position = (Vector3)(&x2);
			Transform transform6 = gameObject.transform;
			transform6.localScale = (Vector3)(&num);
		}
		ProjectileDone();
	}

	private void Timeout()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_0013: Expected I, but got O
		//IL_0031: Expected F4, but got O
		//IL_002c: Expected native int or pointer, but got O
		//IL_0046: Expected F4, but got I
		//IL_0041: Expected native int or pointer, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	protected override void StepMovement()
	{
	}
}
