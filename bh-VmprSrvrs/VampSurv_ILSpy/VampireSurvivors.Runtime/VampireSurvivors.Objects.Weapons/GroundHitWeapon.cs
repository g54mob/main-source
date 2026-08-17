using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GroundHitWeapon : SwordWeapon
{
	public override float PAmount()
	{
		return 1f;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_005c: Expected I, but got O
		//IL_006a: Expected I, but got O
		//IL_007a: Expected O, but got I
		//IL_00fa: Expected O, but got I4
		//IL_00b6: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		Projectile projectile = _projectilePool.SpawnAt(pos, this);
		bool flag = (object)projectile == null;
		Projectile projectile2 = null;
		object obj3;
		if (!flag)
		{
			nint num = (nint)projectile;
			nint num2 = (nint)typeof(SwordFinisherProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordFinisherProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SwordFinisherProjectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v22+FFFFFFF8+v158 @ rax_v18*8]");
				if (0 == (nint)typeof(SwordFinisherProjectile))
				{
					obj3 = 1;
					goto IL_014d;
				}
			}
			obj3 = 0;
			goto IL_014d;
		}
		goto IL_0174;
		IL_0174:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			_ = 1051931443;
		}
		return;
		IL_014d:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0174;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0125: Expected I4, but got O
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
						goto IL_0142;
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
									base.DealDamageRetaliation(component);
								}
								goto IL_0142;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0142:
		return false;
	}

	public GroundHitWeapon()
	{
		base._maxFiringCounter = 5;
		((Weapon)this)._002Ector();
	}
}
