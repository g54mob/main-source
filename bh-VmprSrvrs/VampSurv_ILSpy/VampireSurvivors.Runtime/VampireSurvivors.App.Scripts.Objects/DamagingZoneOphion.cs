using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.App.Scripts.Objects;

public class DamagingZoneOphion : ArcadeSprite
{
	private DamagingZonePool_Ophion _pool;

	private PhaserSprite _groundFx;

	private PhaserSprite _snakeSprite;

	private Circle _collider;

	private float _damage;

	private float _duration;

	private float _hitDelay;

	private bool _hasInit;

	private bool _activateDamage;

	private bool _hasHit;

	private Timer _hitboxTimer;

	private Timer _despawnTimer;

	private MultiTargetTween _snakeTween;

	private MultiTargetTween _displayScaleTween;

	private MultiTargetTween _displayScaleTween2;

	private MultiTargetTween _implosionTween;

	private MultiTargetTween _explosionTween;

	private const float EXPLO_1_DURATION = 500f;

	private const float EXPLO_2_DURATION = 100f;

	private const float EXPLO_3_DURATION = 200f;

	protected unsafe override void OnUpdate()
	{
		//IL_004a: Expected F4, but got O
		//IL_0127: Expected I, but got O
		//IL_010a->IL01b3: Incompatible stack heights: 2 vs 0
		//IL_0139->IL01b3: Incompatible stack heights: 2 vs 0
		if (_hasHit || !_activateDamage)
		{
			return;
		}
		Circle collider = _collider;
		float2 float5 = base.position;
		collider._x = (float)float5;
		float y = default(float);
		collider._y = y;
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator point = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
			bool flag = (object)cachedTrans == null;
			bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite.body != null)
			{
				BaseBody baseBody = arcadeSprite.body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				arcadeTransform.position = ret;
			}
			if (_collider.Contains((Vector2)point))
			{
				_hasHit = true;
				nint num = (nint)arcadeSprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v705 @ r8_v9 (Il2CppClass<ArcadeSprite>)+5F8] (should have been resolved before IL gen)");
			}
		}
	}

	public void Init(DamagingZonePool_Ophion pool)
	{
		//IL_00d7: Expected O, but got I4
		_pool = pool;
		if (!_hasInit)
		{
			Sprite sprite = SpriteManager.GetSprite("_OPBubble", "vfx");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			ArcadeSprite arcadeSprite2 = setVisible(visible: false);
			ArcadeSprite arcadeSprite3 = arcadeSprite2.setAlpha(0.2f);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, null, "UnityCircle");
			PhaserSprite phaserSprite2 = phaserSprite.setTint(16711680u);
			PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)0);
			PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
			PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
			PhaserSprite phaserSprite6 = phaserSprite5.setBlendMode(BlendMode.Add);
			GameObject gameObject = phaserSprite6.gameObject;
			((UnityEngine.Object)gameObject).SetName("GroundFX (DamagingZoneOphion)");
			_groundFx = phaserSprite6;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 1f;
			_collider = circle;
			if ((object)GM.Core == null)
			{
				goto IL_027d;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserSprite phaserSprite7 = RenderingExtensions.sprite(s_scene2.add, pos, "vfx", "Ophion0000");
			PhaserSprite snakeSprite = phaserSprite7.setVisible(visible: false);
			_snakeSprite = snakeSprite;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Ophion", 0, 31, "vfx", num);
			PhaserSprite snakeSprite2 = _snakeSprite;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			snakeSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite snakeSprite3 = _snakeSprite;
			snakeSprite3._spriteAnimation.SetAnimation("loop");
			_hasInit = true;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 661 Invalid \"Jump target not found in method: 0x186C42B90\"");
		goto IL_027d;
		IL_027d:
		throw new NullReferenceException();
	}

	public void OnRecycle()
	{
		//IL_001a: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0154: Expected I, but got O
		//IL_01d4: Expected O, but got I4
		//IL_028a: Expected O, but got I4
		//IL_02d6: Expected O, but got F4
		//IL_02b9: Expected F4, but got I4
		PhaserSprite phaserSprite = _groundFx.setOrigin(0.5f, (float?)(object)0);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _snakeSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _groundFx.setDepth(1f);
		_activateDamage = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_hasHit = false;
		};
		float num = _hitDelay * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_groundFx != null)
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
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 4;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite4 = _groundFx.setAlpha(0f);
			PhaserSprite phaserSprite5 = _groundFx.setVisible(visible: true);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete2 = Explode;
		tweenConfig.onComplete = onComplete2;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		_despawnTimer = null;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float detune = num * 500f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, flag ? 1 : 0);
	}

	public void SetExplosionSize(float x, float y, float radius)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		Circle collider = _collider;
		collider._x = x;
		collider._y = y;
		float2 float5 = default(float2);
		base.position = float5;
		Circle collider2 = _collider;
		float num = (collider2._radius = radius * 0.01f);
		float diameter = num + num;
		collider2._diameter = diameter;
		float num2 = radius + radius;
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_groundFx, num2);
	}

	public void SetExplosionDamage(float damage, float duration, float hitDelay)
	{
		_damage = damage;
		_duration = duration;
		_hitDelay = hitDelay;
	}

	public void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		DamagingZonePool_Ophion pool = _pool;
		ObjectPool pool2 = pool._pool;
		if ((object)pool._pool != null && ((UnityEngine.Object)pool2).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = base.gameObject;
			pool._pool.Release(obj);
		}
		_activateDamage = false;
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		_despawnTimer = null;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		PhaserSprite phaserSprite2 = _snakeSprite.setVisible(visible: false);
	}

	private void Explode()
	{
		//IL_037c: Expected O, but got I4
		//IL_0398: Expected O, but got F4
		//IL_00de: Expected I, but got O
		//IL_0130: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_021d: Expected I, but got O
		//IL_026f: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_0351: Expected I4, but got F4
		//IL_0101->IL0101: Incompatible stack heights: 1 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 500f;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, num2);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		PhaserSprite phaserSprite = _snakeSprite.setVisible(visible: true);
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		if (_snakeTween != null)
		{
			_snakeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_snakeSprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite2 = _snakeSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = _snakeSprite.setScale(0f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween snakeTween = Tweens.Add(tweenConfig);
		_snakeTween = snakeTween;
		if (_displayScaleTween != null)
		{
			_displayScaleTween.Kill();
		}
		if (_displayScaleTween2 != null)
		{
			_displayScaleTween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num4 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		bool flag2 = obj4 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 500f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onComplete = delegate
		{
			//IL_000d: Expected I, but got O
			//IL_0083: Expected I4, but got I8
			//IL_0091: Expected O, but got I4
			_activateDamage = true;
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			nint num5 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				tweenConfig3.duration = 100f;
				tweenConfig3.yoyo = true;
				tweenConfig3.repeat = -1;
				tweenConfig3.scale = (float?)(object)1;
				MultiTargetTween displayScaleTween2 = Tweens.Add(tweenConfig3);
				_displayScaleTween2 = displayScaleTween2;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween displayScaleTween = Tweens.Add(tweenConfig2);
		_displayScaleTween = displayScaleTween;
		Action onComplete2 = Implode;
		float duration = _duration * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete2, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	private void Implode()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		if (_implosionTween != null)
		{
			_implosionTween.Kill();
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
			tweenConfig.duration = 100f;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = Explode2;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween implosionTween = Tweens.Add(tweenConfig);
			_implosionTween = implosionTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void Explode2()
	{
		//IL_034b: Expected O, but got I4
		//IL_0367: Expected O, but got F4
		//IL_010b: Expected I, but got O
		//IL_015f: Expected I, but got O
		//IL_01b1: Expected O, but got I4
		//IL_01cd: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_02ba: Expected O, but got I4
		//IL_02d6: Expected O, but got I4
		//IL_0182->IL0182: Incompatible stack heights: 2 vs 1
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, time);
		if (_snakeTween != null)
		{
			_snakeTween.Kill();
		}
		if (_displayScaleTween != null)
		{
			_displayScaleTween.Kill();
		}
		if (_displayScaleTween2 != null)
		{
			_displayScaleTween2.Kill();
		}
		if (_explosionTween != null)
		{
			_explosionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		bool flag = obj3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_snakeSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite = _snakeSprite.setAlpha(1f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			_activateDamage = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween explosionTween = Tweens.Add(tweenConfig);
		_explosionTween = explosionTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num3 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		bool flag3 = obj5 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 200f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			ArcadeSprite arcadeSprite = setAlpha(0f);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onComplete2 = Despawn;
		tweenConfig2.onComplete = onComplete2;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
	}

	public DamagingZoneOphion()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003COnRecycle_003Eb__22_0()
	{
		_hasHit = false;
	}

	private void _003COnRecycle_003Eb__22_1()
	{
		PhaserSprite phaserSprite = _groundFx.setAlpha(0f);
		PhaserSprite phaserSprite2 = _groundFx.setVisible(visible: true);
	}

	private void _003CExplode_003Eb__26_0()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _snakeSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _snakeSprite.setScale(0f, (float?)(object)0);
	}

	private void _003CExplode_003Eb__26_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CExplode_003Eb__26_2()
	{
		//IL_000d: Expected I, but got O
		//IL_0083: Expected I4, but got I8
		//IL_0091: Expected O, but got I4
		_activateDamage = true;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.yoyo = true;
			tweenConfig.repeat = -1;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween displayScaleTween = Tweens.Add(tweenConfig);
			_displayScaleTween2 = displayScaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void _003CExplode2_003Eb__28_0()
	{
		PhaserSprite phaserSprite = _snakeSprite.setAlpha(1f);
	}

	private void _003CExplode2_003Eb__28_1()
	{
		_activateDamage = false;
	}

	private void _003CExplode2_003Eb__28_2()
	{
		ArcadeSprite arcadeSprite = setAlpha(0f);
	}
}
