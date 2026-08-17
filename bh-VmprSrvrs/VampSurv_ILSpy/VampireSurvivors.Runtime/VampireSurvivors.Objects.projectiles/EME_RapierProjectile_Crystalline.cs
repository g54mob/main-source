using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_RapierProjectile_Crystalline : Projectile
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public Projectile freezingBullet;

		public EME_RapierProjectile_Crystalline _003C_003E4__this;

		internal void _003CSetTarget_003Eb__0()
		{
			freezingBullet.Despawn();
		}

		internal void _003CSetTarget_003Eb__1()
		{
			//IL_0015: Expected O, but got I4
			//IL_0040: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(0.5f, (float?)(object)0);
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.crystalSprite.setScale(0f, (float?)(object)0);
		}

		internal unsafe void _003CSetTarget_003Eb__2()
		{
			//IL_0033: Expected O, but got I
			//IL_00a6: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this;
			float2 position = _003C_003E4__this.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (ArcadeSprite)+E8]");
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt((ParticleSystem)0, pos, 90);
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite crystalSprite = eME_RapierProjectile_Crystalline.crystalSprite;
			crystalSprite._spriteAnimation.SetAnimation("break");
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = _003C_003E4__this;
			SfxType[] sounds = eME_RapierProjectile_Crystalline2._sounds;
			int num = ++eME_RapierProjectile_Crystalline2._sfxIndex % sounds.Length;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sounds[num]), soundConfig, 150f, 1, time);
			_003C_003E4__this.Despawn();
		}

		internal void _003CSetTarget_003Eb__3()
		{
			//IL_0027: Expected O, but got I4
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.impactSprite.setScale(0f, (float?)(object)0);
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = eME_RapierProjectile_Crystalline2.impactSprite.setVisible(visible: true);
		}

		internal void _003CSetTarget_003Eb__4()
		{
			//IL_0027: Expected O, but got I4
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.impactSprite.setScale(0f, (float?)(object)0);
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = eME_RapierProjectile_Crystalline2.impactSprite.setVisible(visible: false);
		}

		internal void _003CSetTarget_003Eb__5()
		{
			//IL_0027: Expected O, but got I4
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.impactSprite.setScale(0f, (float?)(object)0);
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = eME_RapierProjectile_Crystalline2.impactSprite.setVisible(visible: false);
		}

		internal void _003CSetTarget_003Eb__6()
		{
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.impactSprite.setAlpha(0.65f);
		}

		internal void _003CSetTarget_003Eb__7()
		{
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.impactSprite.setAlpha(0f);
		}

		internal void _003CSetTarget_003Eb__8()
		{
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.impactSprite.setAlpha(0f);
		}

		internal void _003CSetTarget_003Eb__9()
		{
			EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = _003C_003E4__this;
			PhaserSprite phaserSprite = eME_RapierProjectile_Crystalline.crystalSprite.setTint(255u);
		}
	}

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_RapierWeapon _trueWeapon;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private readonly SfxType[] _sounds = new SfxType[25]
	{
		SfxType.Glass01,
		SfxType.Glass02,
		SfxType.Glass03,
		SfxType.Glass04,
		SfxType.Glass05,
		SfxType.Glass06,
		SfxType.Glass07,
		SfxType.Glass08,
		SfxType.Glass09,
		SfxType.Glass10,
		SfxType.Glass11,
		SfxType.Glass12,
		SfxType.Glass13,
		SfxType.Glass14,
		SfxType.Glass15,
		SfxType.Glass16,
		SfxType.Glass17,
		SfxType.Glass18,
		SfxType.Glass19,
		SfxType.Glass20,
		SfxType.Glass21,
		SfxType.Glass22,
		SfxType.Glass23,
		SfxType.Glass24,
		SfxType.Glass25
	};

	private int _sfxIndex;

	private PhaserSprite crystalSprite;

	private bool isInitialised;

	private PhaserSprite impactSprite;

	private MultiTargetTween _tween3;

	private MultiTargetTween _tween4;

	protected bool hasHit;

	protected virtual uint _pfxTint => 35071u;

	public virtual void makeSprites()
	{
		//IL_00ad: Expected O, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_0226: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("CrystalBig_", 0, 0, "vfx", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("CrystalBig_", 0, 12, "vfx", num);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "CrystalBig");
		GameObject gameObject = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject).SetName("_crystalSprite");
		PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.55f);
		PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite5 = phaserSprite4.setTint(37119u);
		PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
		PhaserSprite phaserSprite7 = phaserSprite6.setDepth(3000);
		PhaserSprite phaserSprite8 = phaserSprite7.setBlendMode(BlendMode.Add);
		crystalSprite = phaserSprite8;
		PhaserSprite phaserSprite9 = crystalSprite;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite9._spriteAnimation.AddAnimation("idle", animationFrames, 44, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite10 = crystalSprite;
		phaserSprite10._spriteAnimation.AddAnimation("break", animationFrames2, 44, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite11 = instance2.AddPhaserSprite(pos, "vfx", "blurredSharpStar");
		GameObject gameObject2 = phaserSprite11.gameObject;
		((UnityEngine.Object)gameObject2).SetName("_blurredSharpStar");
		PhaserSprite phaserSprite12 = phaserSprite11.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite13 = phaserSprite12.setAlpha(0.65f);
		PhaserSprite phaserSprite14 = phaserSprite13.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite15 = phaserSprite14.setVisible(visible: false);
		PhaserSprite phaserSprite16 = phaserSprite15.setDepth(3100);
		PhaserSprite phaserSprite17 = phaserSprite16.setBlendMode(BlendMode.Add);
		impactSprite = phaserSprite17;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001d: Expected O, but got I4
		//IL_007a: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_0112: Expected O, but got I4
		//IL_0067: Expected O, but got I4
		//IL_0530: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0104: Expected O, but got I4
		//IL_0281: Expected O, but got I
		//IL_029d: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_02b6: Expected O, but got Ref
		//IL_02d0: Expected native int or pointer, but got O
		//IL_054c: Expected O, but got I4
		//IL_02e8: Expected O, but got Ref
		//IL_0302: Expected native int or pointer, but got O
		//IL_031c: Expected O, but got I
		//IL_033c: Expected O, but got Ref
		//IL_0363: Expected O, but got I
		//IL_037d: Expected native int or pointer, but got O
		//IL_0569: Expected O, but got I4
		//IL_03af: Expected O, but got Ref
		//IL_03c9: Expected native int or pointer, but got O
		//IL_05a3: Expected O, but got I
		//IL_040f: Expected O, but got I4
		//IL_044a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		hasHit = false;
		if (isInitialised)
		{
			goto IL_04e7;
		}
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		makeSprites();
		float? weapon2 = (float?)_weapon;
		isInitialised = true;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0509;
		}
		nint num = (nint)typeof(EME_RapierWeapon);
		object obj3 = weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v57 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r9_v16+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v57 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj6;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r9_v16+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v114+FFFFFFF8+v229 @ rax_v109*8]");
			if (0 == (nint)typeof(EME_RapierWeapon))
			{
				obj6 = 1;
				goto IL_0518;
			}
		}
		obj6 = 0;
		goto IL_0518;
		IL_04e7:
		if (!_initialisedParticles)
		{
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 100;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(25f, 125f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(-400f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 0;
			uint pfxTint = _pfxTint;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+70]");
			particleSystemConfig._tint = (uint?)(object)0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			_pfxEmitter = pfxEmitter;
			_initialisedParticles = true;
		}
		return;
		IL_0518:
		bool flag = obj6 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0509;
		IL_0509:
		_trueWeapon = (EME_RapierWeapon)trueWeapon;
		Sprite sprite = SpriteManager.GetSprite("CrystalBig_0", "vfx");
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
		ArcadeSprite arcadeSprite3 = setVisible(visible: false);
		BaseBody baseBody = body.setCircle(36f, (float?)(object)0, (float?)(object)0);
		goto IL_04e7;
	}

	private unsafe void PlaySfx()
	{
		//IL_0030: Expected O, but got I4
		SfxType[] sounds = _sounds;
		int num = ++_sfxIndex % sounds.Length;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sounds[num]), soundConfig, 150f, 1, time);
	}

	public virtual void DespawnNow()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		PhaserSprite phaserSprite = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = impactSprite.setVisible(visible: false);
		base.Despawn();
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		if (_tween4 != null)
		{
			_tween4.Kill();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		Action onComplete = delegate
		{
			PhaserSprite phaserSprite = crystalSprite.setVisible(visible: false);
			PhaserSprite phaserSprite2 = impactSprite.setVisible(visible: false);
			base.Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void SetNullTarget()
	{
		DespawnNow();
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_01dd: Expected O, but got I4
		//IL_02de: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_0d8c: Expected F4, but got O
		//IL_0459: Expected F4, but got O
		//IL_04cb: Expected O, but got I4
		//IL_05d3: Expected I, but got O
		//IL_0653: Expected I, but got O
		//IL_06d9: Expected O, but got I4
		//IL_080c: Expected I, but got O
		//IL_08a0: Expected O, but got I4
		//IL_09d2: Expected I, but got O
		//IL_0a66: Expected O, but got I4
		//IL_0bc4: Expected I, but got O
		//IL_0c29: Expected O, but got I4
		//IL_0d66->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_00e5->IL0cb4: Incompatible stack heights: 1 vs 0
		//IL_013b->IL0cb4: Incompatible stack heights: 2 vs 0
		//IL_018b->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_01b9->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_020a->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_023d->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_025f->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0291->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_02c4->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_030b->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0334->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0367->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_03a9->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_03e4->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_05a9->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_049f->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_061a->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_05f6->IL05f6: Incompatible stack heights: 4 vs 3
		//IL_0698->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0676->IL0676: Incompatible stack heights: 4 vs 3
		//IL_07b6->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_07e2->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0851->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_082f->IL082f: Incompatible stack heights: 4 vs 3
		//IL_09a6->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0a17->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_09f5->IL09f5: Incompatible stack heights: 4 vs 3
		//IL_0b78->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0b95->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0c09->IL0cb4: Incompatible stack heights: 3 vs 0
		//IL_0be7->IL0be7: Incompatible stack heights: 4 vs 3
		//IL_0ca8->IL0ca8: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass21_0();
		if (CS_0024_003C_003E8__locals25 != null)
		{
			CS_0024_003C_003E8__locals25._003C_003E4__this = this;
			Transform transform = default(Transform);
			_targetTransform = transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
			object obj = (object)transform >> 31;
			object obj2 = (object)transform + obj;
			object obj3 = obj2 * 2;
			object obj4 = obj2 + obj3;
			object obj5 = obj4 + obj4;
			object obj6 = _indexInWeapon - obj5;
			if ((object)transform == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				DespawnNow();
				return;
			}
			hasHit = true;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			EME_RapierWeapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon != null)
			{
				int[] fireX = trueWeapon._FireX;
				if (trueWeapon._FireX != null)
				{
					bool flag2 = (nint)obj6 >= fireX.Length;
					EME_RapierWeapon trueWeapon2 = _trueWeapon;
					int[] fireY = trueWeapon2._FireY;
					if (trueWeapon2._FireY != null)
					{
						bool flag3 = (nint)obj6 >= fireY.Length;
						float2 float5 = default(float2);
						base.position = float5;
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._enable = true;
							if ((object)_trueWeapon != null)
							{
								float num = _trueWeapon.PArea();
								float num2 = default(float);
								ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
								float2 float6 = base.position;
								if ((object)crystalSprite != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									PhaserSprite phaserSprite = crystalSprite;
									if ((object)crystalSprite != null && (object)phaserSprite._spriteAnimation != null)
									{
										phaserSprite._spriteAnimation.SetAnimation("idle");
										if ((object)crystalSprite != null)
										{
											PhaserSprite phaserSprite2 = crystalSprite.setVisible(visible: true);
											if ((object)crystalSprite != null)
											{
												PhaserSprite phaserSprite3 = crystalSprite.setScale(0f, (float?)(object)0);
												float2 float7 = base.position;
												if ((object)impactSprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
													if ((object)impactSprite != null)
													{
														PhaserSprite phaserSprite4 = impactSprite.setVisible(visible: true);
														if ((object)impactSprite != null)
														{
															PhaserSprite phaserSprite5 = impactSprite.setScale(0f, (float?)(object)0);
															EME_RapierWeapon trueWeapon3 = _trueWeapon;
															if ((object)_trueWeapon != null)
															{
																float2 float8 = base.position;
																float2 float9 = base.position;
																if (trueWeapon3._freezeOnlyPool != null)
																{
																	Projectile freezingBullet = trueWeapon3._freezeOnlyPool.SpawnAt(float5, _trueWeapon);
																	CS_0024_003C_003E8__locals25.freezingBullet = freezingBullet;
																	Projectile freezingBullet2 = CS_0024_003C_003E8__locals25.freezingBullet;
																	bool flag4 = (object)CS_0024_003C_003E8__locals25.freezingBullet == null;
																	float num3 = (float)float5;
																	bool flag5 = false;
																	float num5 = default(float);
																	float num4 = num5;
																	Action<float> trueWeapon4 = (Action<float>)(object)_trueWeapon;
																	if (!flag4)
																	{
																		bool flag6 = ((UnityEngine.Object)freezingBullet2).m_CachedPtr == (IntPtr)0;
																		num3 = (float)float5;
																		flag5 = false;
																		num4 = num5;
																		trueWeapon4 = (Action<float>)(object)_trueWeapon;
																		if (!flag6)
																		{
																			if ((object)CS_0024_003C_003E8__locals25.freezingBullet == null)
																			{
																				goto IL_0cb4;
																			}
																			num4 = num2 * 3f;
																			ArcadeSprite arcadeSprite2 = CS_0024_003C_003E8__locals25.freezingBullet.setScale(num4, (float?)(object)0);
																			Action onComplete = delegate
																			{
																				CS_0024_003C_003E8__locals25.freezingBullet.Despawn();
																			};
																			bool useRealTime = default(bool);
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			num3 = 0.1f;
																			flag5 = false;
																			trueWeapon4 = null;
																		}
																	}
																	if (_tween != null)
																	{
																		_tween.Kill();
																	}
																	TweenConfig tweenConfig = new TweenConfig();
																	object[] array = new object[2];
																	Transform transform2 = base.transform;
																	if (array != null)
																	{
																		if ((object)transform2 != null)
																		{
																			nint num6 = (nint)array;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj7 = default(object);
																			bool flag7 = obj7 == null;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if ((object)crystalSprite != null)
																		{
																			Transform transform3 = crystalSprite.transform;
																			if ((object)transform3 != null)
																			{
																				nint num7 = (nint)array;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj8 = default(object);
																				bool flag8 = obj8 == null;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			if (tweenConfig != null)
																			{
																				tweenConfig.targets = array;
																				tweenConfig.duration = 250f;
																				tweenConfig.ease = Ease.OutSine;
																				tweenConfig.scale = (float?)(object)1;
																				TweenCallback onStart = delegate
																				{
																					//IL_0015: Expected O, but got I4
																					//IL_0040: Expected O, but got I4
																					ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals25._003C_003E4__this.setScale(0.5f, (float?)(object)0);
																					EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																					PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.crystalSprite.setScale(0f, (float?)(object)0);
																				};
																				tweenConfig.onStart = onStart;
																				TweenCallback onComplete2 = delegate
																				{
																					//IL_0033: Expected O, but got I
																					//IL_00a6: Expected O, but got I4
																					ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals25._003C_003E4__this;
																					float2 float10 = CS_0024_003C_003E8__locals25._003C_003E4__this.position;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (ArcadeSprite)+E8]");
																					Vector2 pos = default(Vector2);
																					RenderingExtensions.EmitParticleAt((ParticleSystem)0, pos, 90);
																					EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																					PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.crystalSprite;
																					phaserSprite7._spriteAnimation.SetAnimation("break");
																					EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
																					SfxType[] sounds = eME_RapierProjectile_Crystalline2._sounds;
																					int num11 = ++eME_RapierProjectile_Crystalline2._sfxIndex % sounds.Length;
																					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																					soundConfig.Volume = (float?)(object)1;
																					soundConfig.Rate = 1f;
																					float time = default(float);
																					PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref sounds[num11]), soundConfig, 150f, 1, time);
																					CS_0024_003C_003E8__locals25._003C_003E4__this.Despawn();
																				};
																				tweenConfig.onComplete = onComplete2;
																				MultiTargetTween tween = Tweens.Add(tweenConfig);
																				_tween = tween;
																				if (_tween2 != null)
																				{
																					_tween2.Kill();
																				}
																				TweenConfig tweenConfig2 = new TweenConfig();
																				object[] array2 = new object[1];
																				if ((object)impactSprite != null)
																				{
																					Transform transform4 = impactSprite.transform;
																					if (array2 != null)
																					{
																						if ((object)transform4 != null)
																						{
																							nint num8 = (nint)array2;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																							object obj9 = default(object);
																							bool flag9 = obj9 == null;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						if (tweenConfig2 != null)
																						{
																							tweenConfig2.targets = array2;
																							tweenConfig2.delay = 150f;
																							tweenConfig2.duration = 100f;
																							tweenConfig2.ease = Ease.Linear;
																							tweenConfig2.scale = (float?)(object)1;
																							TweenCallback onStart2 = delegate
																							{
																								//IL_0027: Expected O, but got I4
																								EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																								PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.impactSprite.setScale(0f, (float?)(object)0);
																								EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
																								PhaserSprite phaserSprite8 = eME_RapierProjectile_Crystalline2.impactSprite.setVisible(visible: true);
																							};
																							tweenConfig2.onStart = onStart2;
																							TweenCallback onComplete3 = delegate
																							{
																								//IL_0027: Expected O, but got I4
																								EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																								PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.impactSprite.setScale(0f, (float?)(object)0);
																								EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
																								PhaserSprite phaserSprite8 = eME_RapierProjectile_Crystalline2.impactSprite.setVisible(visible: false);
																							};
																							tweenConfig2.onComplete = onComplete3;
																							TweenCallback onStop = delegate
																							{
																								//IL_0027: Expected O, but got I4
																								EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																								PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.impactSprite.setScale(0f, (float?)(object)0);
																								EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline2 = CS_0024_003C_003E8__locals25._003C_003E4__this;
																								PhaserSprite phaserSprite8 = eME_RapierProjectile_Crystalline2.impactSprite.setVisible(visible: false);
																							};
																							tweenConfig2.onStop = onStop;
																							MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
																							_tween2 = tween2;
																							if (_tween3 != null)
																							{
																								_tween3.Kill();
																							}
																							TweenConfig tweenConfig3 = new TweenConfig();
																							object[] array3 = new object[1];
																							if (array3 != null)
																							{
																								if ((object)impactSprite != null)
																								{
																									nint num9 = (nint)array3;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																									object obj10 = default(object);
																									bool flag10 = obj10 == null;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								if (tweenConfig3 != null)
																								{
																									tweenConfig3.targets = array3;
																									tweenConfig3.delay = 150f;
																									tweenConfig3.duration = 100f;
																									tweenConfig3.ease = Ease.Linear;
																									tweenConfig3.alpha = (float?)(object)1;
																									TweenCallback onStart3 = delegate
																									{
																										EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																										PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.impactSprite.setAlpha(0.65f);
																									};
																									tweenConfig3.onStart = onStart3;
																									TweenCallback onComplete4 = delegate
																									{
																										EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																										PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.impactSprite.setAlpha(0f);
																									};
																									tweenConfig3.onComplete = onComplete4;
																									TweenCallback onStop2 = delegate
																									{
																										EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																										PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.impactSprite.setAlpha(0f);
																									};
																									tweenConfig3.onStop = onStop2;
																									MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
																									_tween3 = tween3;
																									if (_tween4 != null)
																									{
																										_tween4.Kill();
																									}
																									TweenConfig tweenConfig4 = new TweenConfig();
																									object[] array4 = new object[1];
																									PhaserSprite phaserSprite6 = crystalSprite;
																									if ((object)crystalSprite != null && array4 != null)
																									{
																										if ((object)phaserSprite6._spriteRenderer != null)
																										{
																											nint num10 = (nint)array4;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																											object obj11 = default(object);
																											bool flag11 = obj11 == null;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										if (tweenConfig4 != null)
																										{
																											tweenConfig4.targets = array4;
																											tweenConfig4.tint = (uint?)(object)1;
																											float duration = UnityEngine.Random.Range(200f, 300f);
																											tweenConfig4.duration = duration;
																											tweenConfig4.ease = Ease.Linear;
																											TweenCallback onStart4 = delegate
																											{
																												EME_RapierProjectile_Crystalline eME_RapierProjectile_Crystalline = CS_0024_003C_003E8__locals25._003C_003E4__this;
																												PhaserSprite phaserSprite7 = eME_RapierProjectile_Crystalline.crystalSprite.setTint(255u);
																											};
																											tweenConfig4.onStart = onStart4;
																											MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
																											_tween4 = tween4;
																											return;
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0cb4;
		IL_0cb4:
		throw new NullReferenceException();
	}

	private void _003CDespawn_003Eb__19_0()
	{
		PhaserSprite phaserSprite = crystalSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = impactSprite.setVisible(visible: false);
		base.Despawn();
	}
}
