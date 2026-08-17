using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PrismCutlassCounterProjectile : FB_PrismCutlassProjectile
{
	protected override void Awake()
	{
		//IL_0052: Expected O, but got I4
		((Projectile)this).Awake();
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		base._anim = anim;
		SpriteAnimation anim2 = base._anim;
		anim2._originalSpriteSize = (float2)1124073472;
		_ = 1124073472;
		Sprite sprite = SpriteManager.GetSprite("ProjectileSword", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		MirrorFacingAngle = true;
	}

	public FB_PrismCutlassCounterProjectile()
	{
		Timer[] timers = new Timer[4];
		base._timers = timers;
		((Projectile)this)._002Ector();
	}
}
