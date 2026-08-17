using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PrototypeBProjectile : FB_RapidFireProjectile
{
	protected override void Awake()
	{
		((Projectile)this).Awake();
		Sprite sprite = SpriteManager.GetSprite("FB_ShortBulletBlue", "firstBlood");
		cachedSprite = sprite;
		ArcadeSprite arcadeSprite = setFrame(cachedSprite);
		Sprite sprite2 = SpriteManager.GetSprite("FB_ShortBulletOrange", "firstBlood");
		cachedSprite = sprite2;
		ArcadeSprite arcadeSprite2 = setFrame(cachedSprite);
	}
}
