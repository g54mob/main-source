using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_FireExplosionProjectile : Projectile
{
	private PhaserSprite _explosionSprite;

	private Timer _timerEvent;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_002e: Expected I4, but got O
		//IL_0184: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_0167: Expected I4, but got O
		//IL_0114->IL0243: Incompatible stack heights: 1 vs 0
		//IL_0136->IL0243: Incompatible stack heights: 1 vs 0
		//IL_0174->IL0174: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		bool flag2 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		TimerType timerType = default(TimerType);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
			int num = (int)_explosionSprite;
			if ((object)_explosionSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v5 (System.Int32)+10]");
				if ((nint)0 != 0)
				{
					goto IL_0174;
				}
			}
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v29 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v29 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite explosionSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "firstBlood", "Crush Bomb-Explosion-F1");
				_explosionSprite = explosionSprite;
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", flag2 ? 1 : 0);
				PhaserSprite explosionSprite2 = _explosionSprite;
				if ((object)_explosionSprite != null && (object)explosionSprite2._spriteAnimation != null)
				{
					explosionSprite2._spriteAnimation.AddAnimation("play", animationFrames, 16, flag2, (byte)(int)monoBehaviour != 0, (Action)num2, (byte)timerType != 0);
					flag2 = flag2;
					goto IL_0174;
				}
			}
		}
		goto IL_0243;
		IL_0243:
		throw new NullReferenceException();
		IL_0174:
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		PhaserSprite explosionSprite3 = _explosionSprite;
		if ((object)_explosionSprite != null && (object)explosionSprite3._spriteAnimation != null)
		{
			explosionSprite3._spriteAnimation.SetAnimation("play");
			Action onComplete = delegate
			{
				Despawn();
			};
			Timer timerEvent = Timers.Register(0.5f, onComplete, null, isLooped: false, flag2, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
			_timerEvent = timerEvent;
			return;
		}
		goto IL_0243;
	}

	public override void Despawn()
	{
		if (_timerEvent != null)
		{
			_timerEvent.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__2_0()
	{
		Despawn();
	}
}
