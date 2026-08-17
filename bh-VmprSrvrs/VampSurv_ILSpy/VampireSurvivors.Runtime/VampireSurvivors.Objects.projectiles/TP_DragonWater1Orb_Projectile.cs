using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DragonWater1Orb_Projectile : Projectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("bubbleSphere", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0050: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		float num = _weapon.PArea();
		object obj = default(object);
		float xScale = (float)obj + 4f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}

	public override void Despawn()
	{
		base.Despawn();
	}
}
