using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Universitas_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public TP_Universitas_Projectile _003C_003E4__this;

		public float spriteScaleX;

		internal void _003CExplode_003Eb__0()
		{
			//IL_004d: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._spriteCircle.setVisible(visible: true);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._spriteCircle.setScale(0.05f, (float?)(object)0);
			TP_Universitas_Projectile tP_Universitas_Projectile3 = _003C_003E4__this;
			PhaserSprite phaserSprite3 = tP_Universitas_Projectile3._spriteCircle.setAlpha(1f);
		}

		internal void _003CExplode_003Eb__1()
		{
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._spriteCircle.setVisible(visible: false);
		}

		internal void _003CExplode_003Eb__2()
		{
			//IL_0044: Expected O, but got I4
			//IL_00bc: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._sprite1.setVisible(visible: true);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._sprite1.setScale(spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile3 = _003C_003E4__this;
			PhaserSprite phaserSprite3 = tP_Universitas_Projectile3._sprite1.setAlpha(0.1f);
			TP_Universitas_Projectile tP_Universitas_Projectile4 = _003C_003E4__this;
			PhaserSprite phaserSprite4 = tP_Universitas_Projectile4._sprite2.setVisible(visible: true);
			TP_Universitas_Projectile tP_Universitas_Projectile5 = _003C_003E4__this;
			PhaserSprite phaserSprite5 = tP_Universitas_Projectile5._sprite2.setScale(spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile6 = _003C_003E4__this;
			PhaserSprite phaserSprite6 = tP_Universitas_Projectile6._sprite2.setAlpha(0.1f);
		}

		internal void _003CExplode_003Eb__3()
		{
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			if ((object)tP_Universitas_Projectile.trueWeapon != null)
			{
				tP_Universitas_Projectile.trueWeapon.FireMeteors();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public TP_Universitas_Projectile _003C_003E4__this;

		public float spriteScaleX;

		public float spriteScaleY;

		internal void _003CExplosionLoop_003Eb__0()
		{
			//IL_001e: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._sprite1.setScale(spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._sprite1.setAlpha(0.85f);
		}

		internal void _003CExplosionLoop_003Eb__1()
		{
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			if ((object)tP_Universitas_Projectile.trueWeapon != null)
			{
				tP_Universitas_Projectile.trueWeapon.FireMeteors();
			}
		}

		internal void _003CExplosionLoop_003Eb__2()
		{
			//IL_001e: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._sprite2.setScale(spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._sprite2.setAlpha(0.65f);
		}
	}

	private TP_Universitas_Weapon trueWeapon;

	private PhaserSprite _sprite1;

	private PhaserSprite _sprite2;

	private PhaserSprite _spriteCircle;

	private PhaserSprite _faderImage;

	private MultiTargetTween _circleTween;

	private MultiTargetTween _faderTween;

	private MultiTargetTween _explosionTween;

	private MultiTargetTween _explosionLoopTween;

	private MultiTargetTween _explosionLoop2Tween;

	private MultiTargetTween _fadeOutTween;

	private MultiTargetTween _fadeOut2Tween;

	private float wHeight;

	private float wWidth;

	protected override void Awake()
	{
		//IL_004f: Expected I4, but got I8
		//IL_00ec: Expected I4, but got I8
		//IL_01e0: Expected I4, but got I8
		//IL_02ae: Expected O, but got I4
		//IL_02e1: Expected O, but got I4
		//IL_02fc: Expected I4, but got I8
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setTintFill(isEnabled: true, 0u);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "ThosePeople", "TP_VFX_Universitas01");
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1992);
		PhaserSprite component = phaserSprite2.setVisible(visible: false);
		PhaserSprite phaserSprite3 = RenderingExtensions.SetScrollFactor(component, 0f);
		PhaserSprite sprite = phaserSprite3.setAlpha(0f);
		_sprite1 = sprite;
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite4 = instance2.AddPhaserSprite(pos, "ThosePeople", "TP_VFX_Universitas01");
		PhaserSprite phaserSprite5 = phaserSprite4.setDepth(-1991);
		PhaserSprite component2 = phaserSprite5.setVisible(visible: false);
		PhaserSprite phaserSprite6 = RenderingExtensions.SetScrollFactor(component2, 0f);
		PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
		PhaserSprite sprite2 = phaserSprite7.setBlendMode(BlendMode.Add);
		_sprite2 = sprite2;
		PhaserWorld instance3 = PhaserWorld.Instance;
		PhaserSprite phaserSprite8 = instance3.AddPhaserSprite(pos, "ThosePeople", "TP_VFX_Dominus41");
		PhaserSprite component3 = phaserSprite8.setVisible(visible: false);
		PhaserSprite phaserSprite9 = RenderingExtensions.SetScrollFactor(component3, 0f);
		PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(0f);
		PhaserSprite phaserSprite11 = phaserSprite10.setDepth(-1990);
		PhaserSprite phaserSprite12 = phaserSprite11.setVisible(visible: false);
		PhaserSprite spriteCircle = phaserSprite12.setTintFill(isEnabled: true, 16777215u);
		_spriteCircle = spriteCircle;
		PhaserWorld instance4 = PhaserWorld.Instance;
		PhaserSprite component4 = instance4.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite13 = RenderingExtensions.SetScrollFactor(component4, 0f);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float xScale = renderer.width * 100f;
		PhaserSprite phaserSprite14 = phaserSprite13.setScale(xScale, (float?)(object)1);
		PhaserSprite phaserSprite15 = phaserSprite14.setAlpha(0f);
		PhaserSprite phaserSprite16 = phaserSprite15.setOrigin(0f, (float?)(object)0);
		PhaserSprite faderImage = phaserSprite16.setDepth(-1993);
		_faderImage = faderImage;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		wWidth = renderer2.width;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		wHeight = renderer3.height;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00d9: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_Universitas_Weapon tP_Universitas_Weapon;
		if ((object)_weapon == null)
		{
			tP_Universitas_Weapon = null;
			goto IL_0185;
		}
		nint num = (nint)typeof(TP_Universitas_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Universitas_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Universitas_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v21+FFFFFFF8+v59 @ rax_v16*8]");
			if (0 == (nint)typeof(TP_Universitas_Weapon))
			{
				obj3 = 1;
				goto IL_0194;
			}
		}
		obj3 = 0;
		goto IL_0194;
		IL_0194:
		bool flag = obj3 == null;
		tP_Universitas_Weapon = null;
		if (!flag)
		{
			tP_Universitas_Weapon = (TP_Universitas_Weapon)_weapon;
		}
		goto IL_0185;
		IL_0185:
		trueWeapon = tP_Universitas_Weapon;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		_isCullable = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 190 Invalid \"Jump target not found in method: 0x187197FD0\"");
		throw new NullReferenceException();
	}

	private void DisplayDarkness()
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		if (_faderTween != null)
		{
			_faderTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_faderImage != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = Explode;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween faderTween = Tweens.Add(tweenConfig);
		_faderTween = faderTween;
	}

	private void Explode()
	{
		//IL_00ec: Expected I, but got O
		//IL_0150: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_025b: Expected I, but got O
		//IL_02b3: Expected I, but got O
		//IL_0309: Expected O, but got I4
		//IL_0333: Expected O, but got I4
		//IL_03e9: Expected O, but got I4
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		PhaserSprite sprite = _sprite1;
		Vector2 vector = sprite._spriteRenderer.size;
		float spriteScaleX = wWidth / (float)vector;
		CS_0024_003C_003E8__locals15.spriteScaleX = spriteScaleX;
		PhaserSprite sprite2 = _sprite1;
		Vector2 vector2 = sprite2._spriteRenderer.size;
		if (_circleTween != null)
		{
			_circleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_spriteCircle != null)
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
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_004d: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._spriteCircle.setVisible(visible: true);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._spriteCircle.setScale(0.05f, (float?)(object)0);
			TP_Universitas_Projectile tP_Universitas_Projectile3 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite3 = tP_Universitas_Projectile3._spriteCircle.setAlpha(1f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._spriteCircle.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween circleTween = Tweens.Add(tweenConfig);
		_circleTween = circleTween;
		if (_explosionTween != null)
		{
			_explosionTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_sprite1 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sprite2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.duration = 500f;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onComplete2 = ExplosionLoop;
		tweenConfig2.onComplete = onComplete2;
		TweenCallback onStart2 = delegate
		{
			//IL_0044: Expected O, but got I4
			//IL_00bc: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._sprite1.setVisible(visible: true);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._sprite1.setScale(CS_0024_003C_003E8__locals15.spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile3 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite3 = tP_Universitas_Projectile3._sprite1.setAlpha(0.1f);
			TP_Universitas_Projectile tP_Universitas_Projectile4 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite4 = tP_Universitas_Projectile4._sprite2.setVisible(visible: true);
			TP_Universitas_Projectile tP_Universitas_Projectile5 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite5 = tP_Universitas_Projectile5._sprite2.setScale(CS_0024_003C_003E8__locals15.spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile6 = CS_0024_003C_003E8__locals15._003C_003E4__this;
			PhaserSprite phaserSprite6 = tP_Universitas_Projectile6._sprite2.setAlpha(0.1f);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onUpdate = delegate
		{
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
			if ((object)tP_Universitas_Projectile.trueWeapon != null)
			{
				tP_Universitas_Projectile.trueWeapon.FireMeteors();
			}
		};
		tweenConfig2.onUpdate = onUpdate;
		MultiTargetTween explosionTween = Tweens.Add(tweenConfig2);
		_explosionTween = explosionTween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Universitas, soundConfig, 2000f, 1, time);
	}

	private void ExplosionLoop()
	{
		//IL_011a: Expected I, but got O
		//IL_019e: Expected I4, but got I8
		//IL_01ac: Expected O, but got I4
		//IL_029b: Expected I, but got O
		//IL_0314: Expected O, but got I4
		//IL_0342: Expected I4, but got I8
		//IL_0350: Expected O, but got I4
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		PhaserSprite sprite = _sprite1;
		Vector2 vector = sprite._spriteRenderer.size;
		float spriteScaleX = wWidth / (float)vector;
		CS_0024_003C_003E8__locals11.spriteScaleX = spriteScaleX;
		PhaserSprite sprite2 = _sprite1;
		Vector2 vector2 = sprite2._spriteRenderer.size;
		float num = wHeight * 0.5f;
		object obj = default(object);
		float spriteScaleY = num / (float)obj;
		CS_0024_003C_003E8__locals11.spriteScaleY = spriteScaleY;
		if (_explosionLoopTween != null)
		{
			_explosionLoopTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sprite1 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_001e: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._sprite1.setScale(CS_0024_003C_003E8__locals11.spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._sprite1.setAlpha(0.85f);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onUpdate = delegate
		{
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals11._003C_003E4__this;
			if ((object)tP_Universitas_Projectile.trueWeapon != null)
			{
				tP_Universitas_Projectile.trueWeapon.FireMeteors();
			}
		};
		tweenConfig.onUpdate = onUpdate;
		MultiTargetTween explosionLoopTween = Tweens.Add(tweenConfig);
		_explosionLoopTween = explosionLoopTween;
		if (_explosionLoop2Tween != null)
		{
			_explosionLoop2Tween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_sprite2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		float num4 = CS_0024_003C_003E8__locals11.spriteScaleY * 0.65f;
		tweenConfig2.duration = 150f;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = -1;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_001e: Expected O, but got I4
			TP_Universitas_Projectile tP_Universitas_Projectile = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite = tP_Universitas_Projectile._sprite2.setScale(CS_0024_003C_003E8__locals11.spriteScaleX, (float?)(object)1);
			TP_Universitas_Projectile tP_Universitas_Projectile2 = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite2 = tP_Universitas_Projectile2._sprite2.setAlpha(0.65f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween explosionLoop2Tween = Tweens.Add(tweenConfig2);
		_explosionLoop2Tween = explosionLoop2Tween;
		float num5 = _weapon.PDuration();
		Action onComplete = Disappear;
		float duration = num4 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void Disappear()
	{
		//IL_010a: Expected I, but got O
		//IL_0162: Expected I, but got O
		//IL_01c6: Expected O, but got I4
		//IL_01e2: Expected O, but got I4
		//IL_027b: Expected I, but got O
		//IL_02ed: Expected O, but got I4
		//IL_0308: Expected I, but got O
		Weapon weapon = _weapon;
		((Equipment)weapon)._003COwner_003Ek__BackingField.ClearFromSpecialAnims();
		PhaserSprite sprite = _sprite1;
		Vector2 vector = sprite._spriteRenderer.size;
		if (_explosionLoopTween != null)
		{
			_explosionLoopTween.Kill();
		}
		if (_explosionLoop2Tween != null)
		{
			_explosionLoop2Tween.Kill();
		}
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_sprite1 != null)
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
		if ((object)_sprite2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
		if (_fadeOut2Tween != null)
		{
			_fadeOut2Tween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_faderImage != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 1000f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Universitas_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num4 = (nint)this;
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween fadeOut2Tween = Tweens.Add(tweenConfig2);
		_fadeOut2Tween = fadeOut2Tween;
	}

	public override void Despawn()
	{
		if (_circleTween != null)
		{
			_circleTween.Kill();
		}
		if (_faderTween != null)
		{
			_faderTween.Kill();
		}
		if (_explosionTween != null)
		{
			_explosionTween.Kill();
		}
		if (_explosionLoopTween != null)
		{
			_explosionLoopTween.Kill();
		}
		if (_explosionLoop2Tween != null)
		{
			_explosionLoop2Tween.Kill();
		}
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		if (_fadeOut2Tween != null)
		{
			_fadeOut2Tween.Kill();
		}
		base.Despawn();
	}
}
