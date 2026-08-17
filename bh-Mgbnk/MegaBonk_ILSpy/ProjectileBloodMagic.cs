using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileBloodMagic : ProjectileBase
{
	private Enemy target;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0074: Expected O, but got Ref
		//IL_00ac: Expected O, but got Ref
		//IL_00e8: Expected O, but got Ref
		//IL_012d: Expected O, but got Ref
		//IL_0169: Expected O, but got I4
		//IL_037f: Expected I4, but got O
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_01e6: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_0259: Expected F4, but got O
		//IL_0259: Expected O, but got Ref
		//IL_0259: Expected O, but got I
		//IL_0277: Expected O, but got I
		//IL_0287: Expected O, but got I
		//IL_02c7: Expected O, but got Ref
		//IL_02c7: Expected O, but got I
		//IL_02fa: Expected I4, but got O
		//IL_02fa: Expected O, but got Ref
		//IL_02fa: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		float num = default(float);
		GameObject gameObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, projectileIndex, weaponData.useVision, gameObject);
		if (enemy != null)
		{
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
			Transform transform2 = base.transform;
			Vector3 feetPosition = enemy.GetFeetPosition();
			transform2.position = (Vector3)(&num);
			target = enemy;
			Transform transform3 = base.transform;
			Vector3 position2 = transform3.position;
			int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), projectileRadius, out var buffer);
			if (enemiesInRadiusSafe > 0)
			{
				num = position2.x;
				object obj3 = 0;
				float x = default(float);
				float num2 = default(float);
				float num3 = default(float);
				float num4 = default(float);
				do
				{
					if ((nint)obj3 < buffer.Length)
					{
						if (EnemyManager.Instance.GetEnemy(buffer[obj3], out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88))))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
							if (!((Enemy)0).IsDead())
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
								Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
								Transform transform4 = MyPlayer.Instance.transform;
								Vector3 position3 = transform4.position;
								WeaponBase obj4 = base.weaponBase;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
								DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj4, this, (Enemy)0, (Vector3)(&num), (float)gameObject);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
								((Enemy)0).DamageFromPlayerWeapon(damageContainer);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
								object obj5 = 0;
								Transform transform5 = MyPlayer.Instance.transform;
								Vector3 position4 = transform5.position;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v28+50]");
								Vector3 vector2 = ((Collider)0).ClosestPoint((Vector3)(&x));
								Vector3 movementDirection = GetMovementDirection();
								weaponAttack.ProjectileHit((Vector3)(&num2), (Vector3)(&num3), hitEnemy: true, (byte)(int)gameObject != 0);
								x = position4.x;
								num = num4;
							}
						}
						obj3++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					return (byte)(int)ex != 0;
				}
				while ((nint)obj3 < enemiesInRadiusSafe);
			}
			return true;
		}
		return false;
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

	protected override void MyFixedUpdate()
	{
	}

	protected unsafe override void MyUpdate()
	{
		//IL_0070: Expected O, but got Ref
		if (target != null && !target.IsDead())
		{
			Transform transform = base.transform;
			Vector3 feetPosition = target.GetFeetPosition();
			object obj = default(object);
			transform.position = (Vector3)(&obj);
		}
	}

	protected override void FindMovementDirection()
	{
	}

	protected override void StepMovement()
	{
	}
}
