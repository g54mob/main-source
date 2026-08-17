using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DominusInvisible_Projectile : Projectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileHoly1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(10f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
	}

	public void SetBodyRadius(float radius)
	{
		//IL_0022: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(radius, (float?)(object)1, (float?)(object)1);
	}
}
