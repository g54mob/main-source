using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AlucardSpear1Pommel_Projectile : Projectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
	}
}
