using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Lemuria1Node_Projectile : Projectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0044: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 0f);
		_isCullable = false;
		BaseBody baseBody = body.setCircle(0.5f, (float?)(object)0, (float?)(object)0);
		float num = _weapon.PArea();
		object obj = default(object);
		float xScale = (float)obj + 4f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}

	public override void Despawn()
	{
		if (body != null)
		{
			base.Despawn();
		}
	}
}
