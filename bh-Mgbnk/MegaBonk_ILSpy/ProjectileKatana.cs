using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileKatana : ProjectileBase
{
	public float testMultiplier = 1f;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0242: Expected I4, but got O
		//IL_00d8: Expected O, but got Ref
		//IL_01a6: Expected O, but got Ref
		//IL_01d4: Expected O, but got Ref
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			WeaponBase weaponBase = base.weaponBase;
			if (base.weaponBase != null)
			{
				WeaponData weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					float range = attackSizeMultiplier * 8f;
					float num = default(float);
					GameObject exceptObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), range, projectileIndex, weaponData.useVision, exceptObject);
					if (!(enemy != null))
					{
						return false;
					}
					if ((object)enemy != null)
					{
						Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
						Transform transform2 = base.transform;
						if ((object)MyPlayer.Instance != null)
						{
							Transform transform3 = MyPlayer.Instance.transform;
							if ((object)transform3 != null)
							{
								Vector3 position2 = transform3.position;
								if ((object)enemy.collider != null)
								{
									Vector3 vector = enemy.collider.ClosestPoint((Vector3)(&num));
									if ((object)transform2 != null)
									{
										transform2.position = (Vector3)(&num);
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
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
		//IL_002d: Expected O, but got Ref
		//IL_0068: Expected F4, but got I4
		//IL_017e: Invalid comparison between F4 and I4
		//IL_0139: Expected O, but got Ref
		//IL_0157: Expected F4, but got O
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), projectileRadius, out var buffer);
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		num = position.x;
		float num2 = 0f;
		float num4 = default(float);
		float forceDamage = default(float);
		object obj = default(object);
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[num2], out var enemy) && !enemy.IsDead())
			{
				Vector3 centerPosition = enemy.GetCenterPosition();
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position2 = transform2.position;
				float num3 = centerPosition.x - position2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, this, enemy, (Vector3)(&num4), forceDamage);
				enemy.DamageFromPlayerWeapon(damageContainer);
				num4 = (float)obj;
				num = num3;
			}
			num2++;
		}
		while (num2 < (float)enemiesInRadiusSafe);
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
	}

	protected override void MyUpdate()
	{
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
}
