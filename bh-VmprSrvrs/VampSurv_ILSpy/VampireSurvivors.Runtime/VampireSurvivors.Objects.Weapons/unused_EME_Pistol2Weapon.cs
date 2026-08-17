using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class unused_EME_Pistol2Weapon : unused_EME_Pistol1Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	protected override void MakeLevelOne()
	{
		_explosionType = WeaponType.FIREEXPLOSION;
		base.MakeLevelOne();
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		object obj = default(object);
		if (obj != _glimmer2Pool)
		{
			base.Fire_FireGlimmerProjectile(pos, index, target, pool);
		}
		else
		{
			Projectile projectile = base.FireOneProjectile(pos, index);
		}
	}
}
