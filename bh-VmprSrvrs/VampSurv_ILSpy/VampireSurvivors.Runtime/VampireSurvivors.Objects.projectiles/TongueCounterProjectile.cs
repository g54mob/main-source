using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class TongueCounterProjectile : TongueProjectile
{
	protected override void InitTrailSprite()
	{
		Sprite sprite = SpriteManager.GetSprite("TongueSilver", "vfx");
		_trailSprite = sprite;
	}
}
