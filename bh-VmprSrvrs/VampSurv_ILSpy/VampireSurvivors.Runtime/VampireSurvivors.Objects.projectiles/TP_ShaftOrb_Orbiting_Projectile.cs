using System;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_ShaftOrb_Orbiting_Projectile : TP_Light2_Orbiting_Projectile
{
	public override void MakeTrailAndSprites()
	{
		//IL_01fb->IL0186: Incompatible stack heights: 1 vs 0
		//IL_016c->IL0186: Incompatible stack heights: 2 vs 0
		Sprite sprite = SpriteManager.GetSprite("Lightning2", "vfx");
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
					_LightTrail.time = 0.2f;
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
							PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_ShaftOrb_00");
							_animatedSprite = animatedSprite;
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
		throw new NullReferenceException();
	}

	public TP_ShaftOrb_Orbiting_Projectile()
	{
		base._bodyRadius = 16f;
		((Projectile)this)._002Ector();
	}
}
