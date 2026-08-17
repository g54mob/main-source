using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_InvisibleTimedProjectile : Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00bd: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00fb: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA63]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("ProjectileHoly1", "vfx");
			_renderer.sprite = sprite;
			ArcadeSprite sprite2 = _sprite;
			BaseBody baseBody = sprite2.body.setCircle(10f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			_isCullable = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_InvisibleTimedProjectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		throw new NullReferenceException();
	}

	public void SetBodyRadius(float radius)
	{
		//IL_0022: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(radius, (float?)(object)1, (float?)(object)1);
	}
}
