using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_StarFlail1Body_Projectile : Projectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float num = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setAlpha(0f);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
