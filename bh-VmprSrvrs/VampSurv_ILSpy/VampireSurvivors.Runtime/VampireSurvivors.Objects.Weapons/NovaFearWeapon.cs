using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class NovaFearWeapon : NovaWeapon
{
	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01bc: Expected I4, but got O
		//IL_0145: Invalid comparison between O and F4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_01a8;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									base.DealDamage(component);
									object obj = default(object);
									if (!component._003CIsDead_003Ek__BackingField && ((object)component._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && component._003CSlow_003Ek__BackingField > 0.2f)
									{
										float num = component._003CSlow_003Ek__BackingField - 0.25f;
										component._003CSlow_003Ek__BackingField = num;
									}
									return true;
								}
								goto IL_01a8;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01a8:
		return false;
	}

	public void TrySlowEffect(EnemyController enemy)
	{
		//IL_0030: Invalid comparison between O and F4
		object obj = default(object);
		if (((object)enemy._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && enemy._003CSlow_003Ek__BackingField > 0.2f)
		{
			float num = enemy._003CSlow_003Ek__BackingField - 0.25f;
			enemy._003CSlow_003Ek__BackingField = num;
		}
	}
}
