using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Longsword3Weapon : EME_Longsword2Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex3;

	protected override int GlimmerTier => 3;

	protected override int _comboIndex1 => 1;

	protected override int _comboIndex2 => 5;

	protected override int _comboIndex3 => 9;

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		object obj = default(object);
		if (obj != _glimmer3Pool)
		{
			base.Fire_FireGlimmerProjectile(pos, index, target, pool);
		}
		else
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}
}
