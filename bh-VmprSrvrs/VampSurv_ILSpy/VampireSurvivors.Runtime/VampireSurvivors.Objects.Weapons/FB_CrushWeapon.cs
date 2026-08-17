using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_CrushWeapon : Weapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01eb: Expected I4, but got O
		EnemyController component;
		Projectile component2;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0208;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								float2 center = component2.getCenter();
								float2 position = component.position;
								object obj = center - position;
								object obj3 = default(object);
								object obj4 = default(object);
								object obj2 = obj3 - obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873E25E6h\"");
								if (obj == null)
								{
									bool flag = obj2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873E25E6h\"");
									if (flag)
									{
										goto IL_020e;
									}
								}
								object obj5 = obj2 * obj2;
								object obj6 = obj * obj;
								float num = (float)obj5 + (float)obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
								float deltaTime = PauseSystem.DeltaTime;
								if (deltaTime > num)
								{
									goto IL_01ce;
								}
								float2 position2 = component.position;
								float2 position3 = default(float2);
								component.position = position3;
								goto IL_020e;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01ce:
		base.DealDamage(component);
		goto IL_0208;
		IL_020e:
		if (!component2.HasAlreadyHitObject(component))
		{
			goto IL_01ce;
		}
		goto IL_0208;
		IL_0208:
		return false;
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		return base.FireOneProjectile(pos, index, target, pool);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}
}
