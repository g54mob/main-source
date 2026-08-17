using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Pendulum_Weapon : TP_Clockwork_Weapon
{
	private int activations;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		activations = 0;
	}

	public override void FireProjectiles(Vector2 pos)
	{
		int num = activations + 1;
		int num2 = num & 1;
		bool flag = num2 == 0;
		activations = num;
		if (!flag)
		{
			Projectile projectile = base.FireOneProjectile(pos, 1, _targetTransform);
		}
		else
		{
			Projectile projectile2 = base.FireOneProjectile(pos, 0, _targetTransform);
		}
	}
}
