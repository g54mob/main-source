using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Dark2_Orbiting_Projectile : TP_Light2_Orbiting_Projectile
{
	public override void MakeTrailAndSprites()
	{
		//IL_02f1->IL027c: Incompatible stack heights: 1 vs 0
		//IL_0197->IL027c: Incompatible stack heights: 2 vs 0
		//IL_01b9->IL027c: Incompatible stack heights: 2 vs 0
		//IL_020e->IL027c: Incompatible stack heights: 2 vs 0
		//IL_0230->IL027c: Incompatible stack heights: 2 vs 0
		//IL_0262->IL027c: Incompatible stack heights: 2 vs 0
		Sprite sprite = SpriteManager.GetSprite("Ribbon2", "vfx");
		_cachedLightSprite = sprite;
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_LightTrail, _cachedLightSprite, false);
		if ((object)_LightTrail != null)
		{
			_LightTrail.emitting = false;
			if ((object)_LightTrail != null)
			{
				Material material = ((Renderer)_LightTrail).GetMaterial();
				RenderingExtensions.SetAlpha(material, 0f);
				if ((object)_LightTrail != null)
				{
					_LightTrail.time = 0.1f;
					Renderer lightTrail = _LightTrail;
					if ((object)_LightTrail != null)
					{
						bool flag = ((UnityEngine.Object)lightTrail).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)lightTrail).m_CachedPtr, 999);
						TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LightTrail);
						Renderer lightTrail2 = _LightTrail;
						if ((object)_LightTrail != null)
						{
							bool flag2 = ((UnityEngine.Object)lightTrail2).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)lightTrail2).m_CachedPtr);
							GameObject gameObject = base.gameObject;
							Vector2 pos = default(Vector2);
							PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Umbra01");
							_animatedSprite = animatedSprite;
							int num = default(int);
							List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Umbra", 25, 47, "ThosePeople", num);
							PhaserSprite animatedSprite2 = _animatedSprite;
							if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
							{
								bool startRandomFrame = default(bool);
								Action onComplete = default(Action);
								bool autoSetAnimation = default(bool);
								animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
								PhaserSprite animatedSprite3 = _animatedSprite;
								if ((object)_animatedSprite != null && (object)animatedSprite3._spriteAnimation != null)
								{
									animatedSprite3._spriteAnimation.SetAnimation("loop");
									if ((object)_animatedSprite != null)
									{
										PhaserSprite phaserSprite = _animatedSprite.setAlpha(0.65f);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public TP_Dark2_Orbiting_Projectile()
	{
		base._bodyRadius = 16f;
		((Projectile)this)._002Ector();
	}
}
