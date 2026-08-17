using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Banana1_ExplosionProjectile : Projectile
{
	private const float Radius = 26f;

	private Tween _bodyTween;

	private PhaserSprite _explosionSprite;

	protected virtual float ExplosionTweenMillis => 150f;

	protected virtual int ExplosionFPS => 15;

	protected virtual float ExplosionAlpha => 1f;

	protected unsafe override void Awake()
	{
		//IL_0115: Expected O, but got I4
		//IL_0135: Expected F4, but got O
		//IL_02b8: Expected O, but got Ref
		//IL_022f: Expected I4, but got O
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F615]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			SpriteAnimationData spriteAnimationData = (SpriteAnimationData)"Burst1";
			GameObject gameObject = base.gameObject;
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "Burst1");
			PhaserSprite phaserSprite2 = phaserSprite.setScale(1.5f, (float?)(object)0);
			float explosionAlpha = ExplosionAlpha;
			PhaserSprite phaserSprite3 = phaserSprite2.setAlpha((float)vector);
			PhaserSprite phaserSprite4 = phaserSprite3.setDepth(10000f);
			PhaserSprite phaserSprite5 = phaserSprite4.setTint(16774522u);
			GameObject gameObject2 = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject2).SetName("BananaExplosionSprite");
			_explosionSprite = phaserSprite5;
			SpriteAnimations.SpriteAnimationsBase spriteAnimationsBase = SpriteAnimations.Base;
			if (spriteAnimationsBase.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6906]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				string text = default(string);
				spriteAnimationData = new SpriteAnimationData("Burst", 1, 6, text);
				object obj = default(object);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames((SpriteAnimationData)(&obj), vector);
				PhaserSprite explosionSprite = _explosionSprite;
				int explosionFPS = ExplosionFPS;
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				explosionSprite._spriteAnimation.AddAnimation("explode", animationFrames, explosionFPS, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0089: Expected O, but got F4
		//IL_00b7: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		SetScaleToArea();
		InitSprites();
		TweenBody();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_banana_explosion, soundConfig, 200f, 3, time);
	}

	private unsafe void InitSprites()
	{
		//IL_01bd: Expected O, but got F4
		//IL_000e: Invalid comparison between F4 and O
		//IL_002d: Invalid comparison between F4 and I4
		//IL_01a0: Expected O, but got F4
		//IL_0077: Invalid comparison between F4 and O
		//IL_0096: Invalid comparison between F4 and I4
		//IL_00e2: Expected O, but got I
		//IL_016f: Expected O, but got Ref
		//IL_0149: Expected O, but got I8
		//IL_014e->IL01a5: Incompatible stack heights: 1 vs 0
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		float num = 0.5f - (float)obj2;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		PhaserSprite phaserSprite = _explosionSprite.setFlipX(flag5);
		object obj3 = UnityEngine.Random.value;
		bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		float num2 = 0.5f - (float)obj2;
		bool flag7 = num2 == 0f;
		bool flag8 = !flag6;
		bool flag9 = !flag7;
		bool flag10 = flag9 & flag8;
		PhaserSprite phaserSprite2 = _explosionSprite.setFlipY(flag10);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag11 = (nint)0 != 0;
		PhaserSprite explosionSprite = _explosionSprite;
		if (!flag11)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag12 = obj4 == null;
			explosionSprite = (PhaserSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v349 @ rax_v13 (should have been resolved before IL gen)");
		Transform transform = _explosionSprite.transform;
		object obj5 = default(object);
		transform.localEulerAngles = (Vector3)(&obj5);
		PhaserSprite explosionSprite2 = _explosionSprite;
		explosionSprite2._spriteAnimation.SetAnimation("explode");
	}

	private void TweenBody()
	{
		BaseBody baseBody = body;
		baseBody._radius = 0f;
		baseBody._enable = true;
		if (_bodyTween != null)
		{
			TweenExtensions.Kill(_bodyTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float r = default(float);
		((LEM_Banana1_ExplosionProjectile)(object)dOSetter)._003CTweenBody_003Eb__12_1(r);
		float explosionTweenMillis = ExplosionTweenMillis;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 26f, duration);
		TweenCallback tweenCallback = StartDespawn;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_bodyTween = tweenerCore;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0079: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_banana_explosion, soundConfig, 200f, 3, time);
	}

	private void StartDespawn()
	{
		BaseBody baseBody = body;
		baseBody._radius = 26f;
		if (_bodyTween != null)
		{
			TweenExtensions.Kill(_bodyTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float r = default(float);
		((LEM_Banana1_ExplosionProjectile)(object)dOSetter)._003CStartDespawn_003Eb__14_1(r);
		float explosionTweenMillis = ExplosionTweenMillis;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, duration);
		TweenCallback tweenCallback = delegate
		{
			//IL_000a: Expected I, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_ExplosionProjectile>)+370]");
			Action action = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_ExplosionProjectile>)+370]");
			action._002Ector(this, (IntPtr)0);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.15f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_bodyTween = tweenerCore;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._radius = 0f;
		baseBody._enable = false;
		if (_bodyTween != null)
		{
			TweenExtensions.Kill(_bodyTween);
		}
		base.Despawn();
	}

	private float _003CTweenBody_003Eb__12_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CTweenBody_003Eb__12_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}

	private float _003CStartDespawn_003Eb__14_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CStartDespawn_003Eb__14_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}

	private void _003CStartDespawn_003Eb__14_2()
	{
		//IL_000a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_ExplosionProjectile>)+370]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_ExplosionProjectile>)+370]");
		action._002Ector(this, (IntPtr)0);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.15f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}
}
