using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MagicProjectile_ChaosDisaster : Projectile
{
	protected ParticleSystem _particleSystem;

	protected ParticleEventCall _particleEventCall;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private Transform target;

	private PhaserSprite _darkBGSprite;

	private MultiTargetTween _bgFadeTween;

	protected override void Awake()
	{
		//IL_00c9: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0167: Expected I4, but got I8
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Transform transform = base.transform;
		Camera main = Camera.main;
		Transform parent = main.transform;
		transform.SetParent(parent, worldPositionStays: true);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				float xScale = renderer.width * 100f;
				PhaserSprite phaserSprite4 = phaserSprite3.setScale(xScale, (float?)(object)1);
				PhaserSprite component = phaserSprite4.setDepth(-1998);
				PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component, 0f);
				GameObject gameObject = phaserSprite5.gameObject;
				((UnityEngine.Object)gameObject).SetName("darkSprite");
				_darkBGSprite = phaserSprite5;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0040: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0130: Expected O, but got I4
		//IL_015f: Expected F4, but got I4
		//IL_01db: Expected I, but got O
		//IL_023f: Expected O, but got I4
		//IL_02b9: Expected I, but got O
		//IL_032b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_particleSystem.Play(withChildren: true);
		_isCullable = false;
		BaseBody baseBody = body.setCircle(128f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num = hitBoxDelay + hitBoxDelay;
		float duration = num * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1.6f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_chaosdisaster, soundConfig, 300f, 5, flag ? 1 : 0);
		if (_bgFadeTween != null)
		{
			_bgFadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_darkBGSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween bgFadeTween = Tweens.Add(tweenConfig);
		_bgFadeTween = bgFadeTween;
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num3 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 1000f;
			tweenConfig2.delay = 2800f;
			tweenConfig2.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0088: Expected I, but got O
				//IL_00ec: Expected O, but got I4
				HitEnemies();
				_particleSystem.Stop();
				if (_bgFadeTween != null)
				{
					_bgFadeTween.Kill();
				}
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				if ((object)_darkBGSprite != null)
				{
					nint num4 = (nint)array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				tweenConfig3.duration = 300f;
				tweenConfig3.alpha = (float?)(object)1;
				MultiTargetTween bgFadeTween2 = Tweens.Add(tweenConfig3);
				_bgFadeTween = bgFadeTween2;
			};
			tweenConfig2.onStart = onStart;
			TweenCallback onComplete2 = delegate
			{
				Despawn();
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig2);
			_despawnTween = despawnTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private unsafe void HitEnemies()
	{
		//IL_0095: Expected O, but got I4
		//IL_009d: Expected O, but got Ref
		float num = _weapon.PPower();
		object obj = default(object);
		float num2 = (float)obj * 10f;
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		List<EnemyController> allEnemiesInScreenBounds = gameMan._stage.GetAllEnemiesInScreenBounds(0f);
		List<EnemyController> list = allEnemiesInScreenBounds;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<EnemyController>.Enumerator enumerator2 = (List<EnemyController>.Enumerator)0;
			List<EnemyController>.Enumerator enumerator3 = (List<EnemyController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public override void Despawn()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Stop();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesToFinish()
	{
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__10_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__10_1()
	{
		//IL_0088: Expected I, but got O
		//IL_00ec: Expected O, but got I4
		HitEnemies();
		_particleSystem.Stop();
		if (_bgFadeTween != null)
		{
			_bgFadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_darkBGSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween bgFadeTween = Tweens.Add(tweenConfig);
		_bgFadeTween = bgFadeTween;
	}

	private void _003CInitProjectile_003Eb__10_2()
	{
		Despawn();
	}
}
