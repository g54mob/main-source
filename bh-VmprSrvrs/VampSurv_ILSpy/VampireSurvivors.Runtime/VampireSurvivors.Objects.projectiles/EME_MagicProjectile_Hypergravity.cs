using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MagicProjectile_Hypergravity : Projectile
{
	protected ParticleSystem _particleSystem;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private Transform target;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0080: Expected O, but got I4
		//IL_004f: Expected I4, but got I8
		//IL_037d: Expected O, but got I4
		//IL_01d4: Expected I, but got O
		//IL_0270: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.SetDepth(_particleSystem, -1998);
			_particleSystem.Play(withChildren: true);
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Eme_sfx_hypergravity, soundConfig, 200f, 1, time);
		_isCullable = false;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.width;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				if (!(renderer2.height > renderer.width))
				{
					num = renderer2.height;
				}
				float xScale = num / 7f;
				ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
				BaseBody baseBody = body;
				baseBody._enable = false;
				if (_despawnTween != null)
				{
					_despawnTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					tweenConfig.duration = 200f;
					tweenConfig.delay = 1100f;
					tweenConfig.ease = Ease.Linear;
					tweenConfig.yoyo = true;
					tweenConfig.repeat = 2;
					tweenConfig.scale = (float?)(object)1;
					TweenCallback onStart = delegate
					{
						HitEnemies();
					};
					tweenConfig.onStart = onStart;
					TweenCallback onComplete = delegate
					{
						FadeOut();
					};
					tweenConfig.onComplete = onComplete;
					MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
					_despawnTween = despawnTween;
					return;
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOut()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 500f;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void HitEnemies()
	{
		//IL_0094: Expected O, but got I4
		//IL_009c: Expected O, but got Ref
		float num = _weapon.PPower();
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

	private void LateUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	public override void Despawn()
	{
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesToFinish()
	{
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0 && (object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__7_0()
	{
		HitEnemies();
	}

	private void _003CInitProjectile_003Eb__7_1()
	{
		FadeOut();
	}

	private void _003CFadeOut_003Eb__8_0()
	{
		Despawn();
	}
}
