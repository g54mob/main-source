using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Rumba1_Projectile : Projectile
{
	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0052: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		_speed = 4f;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		object obj = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj));
	}
}
