using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PrototypeBExplosionProjectile : Projectile
{
	private PhaserSprite _explosionSprite;

	private PhaserSprite _bombSprite;

	private MultiTargetTween _tweenBomb;

	private Timer _timerEvent;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0065: Expected I4, but got O
		//IL_01ea: Expected I4, but got O
		//IL_036d: Expected O, but got I4
		//IL_014c->IL045a: Incompatible stack heights: 1 vs 0
		//IL_016e->IL045a: Incompatible stack heights: 1 vs 0
		//IL_01ad->IL01ad: Incompatible stack heights: 1 vs 0
		//IL_029f->IL045a: Incompatible stack heights: 1 vs 0
		//IL_03fd->IL045a: Incompatible stack heights: 1 vs 0
		//IL_059b->IL045a: Incompatible stack heights: 1 vs 0
		//IL_02d3->IL045a: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL045a: Incompatible stack heights: 1 vs 0
		//IL_032a->IL032a: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		Vector3 ret;
		Vector2 vector = default(Vector2);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._enable = false;
				int num = (int)_explosionSprite;
				if ((object)_explosionSprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rsi_v8 (System.Int32)+10]");
					if ((nint)0 != 0)
					{
						goto IL_01ad;
					}
				}
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v95 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v95 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					GameObject gameObject = base.gameObject;
					PhaserSprite explosionSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "firstBlood", "Crush Bomb-Explosion-F1");
					_explosionSprite = explosionSprite;
					int num2 = default(int);
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", num2);
					PhaserSprite explosionSprite2 = _explosionSprite;
					if ((object)_explosionSprite != null && (object)explosionSprite2._spriteAnimation != null)
					{
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						explosionSprite2._spriteAnimation.AddAnimation("play", animationFrames, 16, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
						Vector2 vector2 = vector;
						goto IL_01ad;
					}
				}
			}
		}
		goto IL_045a;
		IL_045a:
		throw new NullReferenceException();
		IL_01ad:
		if ((object)_explosionSprite != null)
		{
			PhaserSprite phaserSprite = _explosionSprite.setVisible(visible: false);
			int num3 = (int)_bombSprite;
			if ((object)_bombSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rsi_v10 (System.Int32)+10]");
				if ((nint)0 != 0)
				{
					goto IL_032a;
				}
			}
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v61 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v61 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				GameObject gameObject2 = base.gameObject;
				PhaserSprite bombSprite = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "firstBlood", "Crush Bomb-Bomb-F1");
				_bombSprite = bombSprite;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null && (object)_bombSprite != null)
						{
							int num4 = renderer.pixelHeight - 1;
							PhaserSprite phaserSprite2 = _bombSprite.setDepth(num4);
							Vector2 vector2 = vector;
							goto IL_032a;
						}
					}
				}
			}
		}
		goto IL_045a;
		IL_032a:
		if ((object)_bombSprite != null)
		{
			PhaserSprite phaserSprite3 = _bombSprite.setVisible(visible: true);
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				object obj = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				bool flag3 = obj2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					_ = 1148846080;
					_ = 1;
					TweenCallback tweenCallback = delegate
					{
						//IL_0029: Expected O, but got I4
						PhaserSprite phaserSprite4 = _bombSprite.setVisible(visible: false);
						ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
						PhaserSprite explosionSprite3 = _explosionSprite;
						explosionSprite3._spriteAnimation.SetAnimation("play");
						PhaserSprite phaserSprite5 = _explosionSprite.setVisible(visible: true);
						BaseBody baseBody3 = body;
						baseBody3._enable = true;
						Action onComplete2 = delegate
						{
							Despawn();
						};
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer timerEvent = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_timerEvent = timerEvent;
					};
					MultiTargetTween tweenBomb = Tweens.Add(tweenConfig);
					_tweenBomb = tweenBomb;
					return;
				}
			}
		}
		goto IL_045a;
	}

	public void explode()
	{
		//IL_0029: Expected O, but got I4
		PhaserSprite phaserSprite = _bombSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		PhaserSprite explosionSprite = _explosionSprite;
		explosionSprite._spriteAnimation.SetAnimation("play");
		PhaserSprite phaserSprite2 = _explosionSprite.setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
		Action onComplete = delegate
		{
			Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timerEvent = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timerEvent = timerEvent;
	}

	public override void Despawn()
	{
		if (_tweenBomb != null)
		{
			_tweenBomb.Kill();
		}
		if (_timerEvent != null)
		{
			_timerEvent.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__4_0()
	{
		//IL_0029: Expected O, but got I4
		PhaserSprite phaserSprite = _bombSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		PhaserSprite explosionSprite = _explosionSprite;
		explosionSprite._spriteAnimation.SetAnimation("play");
		PhaserSprite phaserSprite2 = _explosionSprite.setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
		Action onComplete = delegate
		{
			Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timerEvent = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timerEvent = timerEvent;
	}

	private void _003Cexplode_003Eb__5_0()
	{
		Despawn();
	}
}
