using System;
using Assets.Scripts.Actors.Enemies;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileHoming : ProjectileBase
{
	private Enemy enemyTarget;

	protected override bool TryInit(int projectileIndex)
	{
		enemyTarget = null;
		FindMovementDirection();
		bool flag = enemyTarget == null;
		return !flag;
	}

	protected unsafe override void FindMovementDirection()
	{
		//IL_01cc: Expected O, but got Ref
		//IL_01e3: Expected I, but got O
		//IL_019f: Expected O, but got F4
		if (enemyTarget != null)
		{
			GameObject gameObject = enemyTarget.gameObject;
		}
		bool useVision;
		float range;
		int projectileIndex;
		if (bounces <= 0)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
			WeaponBase weaponBase = base.weaponBase;
			WeaponData weaponData = weaponBase.weaponData;
			useVision = weaponData.useVision;
			range = weaponRange;
			projectileIndex = 0;
		}
		else
		{
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float weaponRange2 = WeaponUtility.GetWeaponRange(base.weaponBase);
			WeaponBase weaponBase2 = base.weaponBase;
			WeaponData weaponData2 = weaponBase2.weaponData;
			useVision = weaponData2.useVision;
			range = weaponRange2;
			projectileIndex = 1;
		}
		float num = default(float);
		GameObject exceptObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), range, projectileIndex, useVision, exceptObject);
		if (enemy == null)
		{
			ProjectileDone();
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			direction = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rcx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
		else
		{
			enemyTarget = enemy;
			Vector3 movementDirection = GetMovementDirection();
			direction = (Vector3)movementDirection.x;
			_ = movementDirection.z;
		}
	}

	private bool HasBounces()
	{
		//IL_0011: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected I4, but got Unknown
		object obj = bounces - maxBounces;
		int num = bounces ^ maxBounces;
		int num2 = bounces ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_0083: Expected F4, but got O
		//IL_007e: Expected native int or pointer, but got O
		//IL_0098: Expected F4, but got I
		//IL_0093: Expected native int or pointer, but got O
		if ((object)enemyTarget != null)
		{
			Vector3 centerPosition = enemyTarget.GetCenterPosition();
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 vector = default(Vector3);
				object obj = default(object);
				((Vector3*)(nint)vector)->x = (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v6+8]");
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	protected override void MyFixedUpdate()
	{
	}

	protected override void MyUpdate()
	{
	}

	private void DestroySelf()
	{
		ProjectileDone();
	}
}
