using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileLightningBolt : ProjectileBase
{
	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_01e3: Expected I4, but got O
		//IL_00a2: Expected O, but got Ref
		//IL_015a: Expected F4, but got O
		//IL_015a: Expected O, but got Ref
		//IL_01b9: Expected F4, but got O
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
					float num = default(float);
					GameObject gameObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, projectileIndex, weaponData.useVision, gameObject);
					if (!(enemy != null))
					{
						return false;
					}
					float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
					if ((object)enemy != null)
					{
						Vector3 centerPosition = enemy.GetCenterPosition();
						if ((object)MyPlayer.Instance != null)
						{
							Transform transform2 = MyPlayer.Instance.transform;
							if ((object)transform2 != null)
							{
								Vector3 position2 = transform2.position;
								DamageContainer damageContainer = WeaponUtility.GetDamageContainer(base.weaponBase, this, enemy, (Vector3)(&num), (float)gameObject);
								if (damageContainer != null)
								{
									float bounceRange = attackSizeMultiplier * 7f;
									damageContainer.element = EElement.Lightning;
									WeaponUtility.LightningStrike(enemy, maxBounces, damageContainer, bounceRange, (float)gameObject);
									return true;
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
