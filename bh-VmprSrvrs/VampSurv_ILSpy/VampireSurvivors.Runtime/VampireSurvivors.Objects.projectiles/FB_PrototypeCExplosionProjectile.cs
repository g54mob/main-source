using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
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

public class FB_PrototypeCExplosionProjectile : Projectile
{
	private PhaserSprite _explosionSprite;

	private PhaserSprite _bombSprite;

	private MultiTargetTween _tweenPositionBomb;

	private MultiTargetTween _tweenAngleBomb;

	private VampireSurvivors.Framework.TimerSystem.Timer _timerEvent;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_06ff: Expected O, but got I4
		//IL_0711: Expected O, but got F4
		//IL_03e0: Expected I, but got O
		//IL_0490: Expected O, but got I4
		//IL_0577: Expected I, but got O
		//IL_058a: Expected O, but got I4
		//IL_0598: Expected O, but got I4
		//IL_0149->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_016b->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_01aa->IL01aa: Incompatible stack heights: 1 vs 0
		//IL_0299->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_0425->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_06ea->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_02cd->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_02ec->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_0324->IL0324: Incompatible stack heights: 1 vs 0
		//IL_050e->IL05b5: Incompatible stack heights: 1 vs 0
		//IL_0565->IL05b5: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		Vector3 ret;
		Vector2 vector = default(Vector2);
		Vector2 vector2 = default(Vector2);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._enable = false;
				Weapon explosionSprite = (Weapon)(object)_explosionSprite;
				if ((object)_explosionSprite != null && ((UnityEngine.Object)explosionSprite).m_CachedPtr != (IntPtr)0)
				{
					goto IL_01aa;
				}
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					GameObject gameObject = base.gameObject;
					PhaserSprite explosionSprite2 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "firstBlood", "Crush Bomb-Explosion-F1");
					_explosionSprite = explosionSprite2;
					int num = default(int);
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", num);
					PhaserSprite explosionSprite3 = _explosionSprite;
					if ((object)_explosionSprite != null && (object)explosionSprite3._spriteAnimation != null)
					{
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						explosionSprite3._spriteAnimation.AddAnimation("play", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						vector2 = vector;
						goto IL_01aa;
					}
				}
			}
		}
		goto IL_05b5;
		IL_05b5:
		throw new NullReferenceException();
		IL_01aa:
		if ((object)_explosionSprite != null)
		{
			PhaserSprite phaserSprite = _explosionSprite.setVisible(visible: false);
			Weapon bombSprite = (Weapon)(object)_bombSprite;
			if ((object)_bombSprite != null && ((UnityEngine.Object)bombSprite).m_CachedPtr != (IntPtr)0)
			{
				goto IL_0324;
			}
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
				GameObject gameObject2 = base.gameObject;
				PhaserSprite bombSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "firstBlood", "Crush Bomb-Bomb-F3");
				_bombSprite = bombSprite2;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null && (object)_bombSprite != null)
						{
							int num2 = renderer.pixelHeight - 1;
							PhaserSprite phaserSprite2 = _bombSprite.setDepth(num2);
							vector2 = vector;
							goto IL_0324;
						}
					}
				}
			}
		}
		goto IL_05b5;
		IL_0324:
		base.angle = 0f;
		if ((object)_bombSprite != null)
		{
			bool flag3 = index == 0;
			PhaserSprite phaserSprite3 = _bombSprite.setFlipX(flag3);
			if ((object)_bombSprite != null)
			{
				PhaserSprite phaserSprite4 = _bombSprite.setVisible(visible: true);
				float num4 = default(float);
				TweenConfig tweenConfig = default(TweenConfig);
				object[] array = default(object[]);
				if (index == 0)
				{
					ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
					object obj = UnityEngine.Random.value;
					float num3 = (float)vector2 * 200f;
					num4 = num3 + 100f;
					tweenConfig = new TweenConfig();
					array = new object[1];
				}
				if (array != null)
				{
					nint num5 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj2 = default(object);
					bool flag4 = obj2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						float2 float5 = base.position;
						float num6 = num4 * 0.01f;
						float duration = num4 * 6f;
						object obj3 = default(object);
						float num7 = (float)obj3 - num6;
						tweenConfig.duration = duration;
						tweenConfig.y = (float?)(object)1;
						TweenCallback onComplete2 = delegate
						{
							//IL_0029: Expected O, but got I4
							base.angle = 0f;
							PhaserSprite phaserSprite5 = _bombSprite.setVisible(visible: false);
							ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
							PhaserSprite explosionSprite4 = _explosionSprite;
							explosionSprite4._spriteAnimation.SetAnimation("play");
							PhaserSprite phaserSprite6 = _explosionSprite.setVisible(visible: true);
							BaseBody baseBody3 = body;
							baseBody3._enable = true;
							Action onComplete3 = delegate
							{
								Despawn();
							};
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							VampireSurvivors.Framework.TimerSystem.Timer timerEvent = Timers.Register(0.5f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_timerEvent = timerEvent;
						};
						tweenConfig.onComplete = onComplete2;
						MultiTargetTween tweenPositionBomb = Tweens.Add(tweenConfig);
						_tweenPositionBomb = tweenPositionBomb;
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 != null)
						{
							void* value = ((IntPtr*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj4 = default(object);
							bool flag5 = obj4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
								((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)1140457472;
								((Weapon)(object)tweenConfig2)._lastShotTimer = (VampireSurvivors.Framework.TimerSystem.Timer)1;
								MultiTargetTween tweenAngleBomb = Tweens.Add(tweenConfig2);
								_tweenAngleBomb = tweenAngleBomb;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_05b5;
	}

	public void explode()
	{
		//IL_0029: Expected O, but got I4
		base.angle = 0f;
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
		VampireSurvivors.Framework.TimerSystem.Timer timerEvent = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timerEvent = timerEvent;
	}

	public override void Despawn()
	{
		if (_tweenPositionBomb != null)
		{
			_tweenPositionBomb.Kill();
		}
		if (_tweenAngleBomb != null)
		{
			_tweenAngleBomb.Kill();
		}
		if (_timerEvent != null)
		{
			_timerEvent.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__5_0()
	{
		//IL_0029: Expected O, but got I4
		base.angle = 0f;
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
		VampireSurvivors.Framework.TimerSystem.Timer timerEvent = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timerEvent = timerEvent;
	}

	private void _003Cexplode_003Eb__6_0()
	{
		Despawn();
	}
}
