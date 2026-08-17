using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_GreatswordProjectile_Vandalize : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__19_0;

		public static TweenCallback _003C_003E9__19_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoScreenShake_003Eb__19_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset2 = main2.followOffset;
			followOffset2.y = -3f;
		}

		internal void _003CDoScreenShake_003Eb__19_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private SpriteRenderer _SwordSprite;

	private ParticleSystem GroundHitFX;

	private SpriteTrail _SpriteTrail;

	private const float ScaleModifier = 2f;

	private const float MaxAreaLimit = 2.5f;

	private int _smashCounter;

	private int _maxSmashes;

	private Tween _fadeTween;

	private MultiTargetTween _angleTween;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _screenShakeTween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		//IL_0072: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_smashCounter = 0;
		float num = _weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		int maxSmashes = (int)(num + 1);
		_maxSmashes = maxSmashes;
		object obj = default(object);
		_cachedTransform.eulerAngles = (Vector3)(&obj);
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon2 = _weapon;
		float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		TweenIn();
		EnableTrail(enable: true);
	}

	public override void InternalUpdate()
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_010b: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_00d7: Expected F4, but got I4
		//IL_0128: Expected O, but got I4
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			Vector3 eulerAngles = _cachedTransform.eulerAngles;
			float num = eulerAngles.z * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num & 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float x = ((!(90f > eulerAngles.z)) ? ((float)obj * -105f) : 0f);
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			BaseBody baseBody3 = body.setOffset(x, (float?)(object)1);
		}
	}

	private void TweenIn()
	{
		//IL_0237: Expected O, but got I4
		//IL_00a0: Expected I, but got O
		//IL_0104: Expected O, but got I4
		float num = _weapon.PArea();
		float num2 = default(float);
		bool flag = 2.5f > num2;
		float num3 = num2;
		if (!flag)
		{
			num3 = 2.5f;
		}
		float xScale = num3 + num3;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num4 = (nint)array;
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
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			BaseBody baseBody = body;
			baseBody._enable = true;
			DoSmash();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			if (_fadeTween != null)
			{
				TweenExtensions.Kill(_fadeTween);
			}
			TweenerCore<Color, Color, ColorOptions> fadeTween = DOTweenModuleSprite.DOFade(_SwordSprite, 1f, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_fadeTween = fadeTween;
		}
	}

	private void DoSmash()
	{
		//IL_01e3: Expected O, but got I4
		//IL_018c: Expected F4, but got I4
		//IL_007f: Expected I, but got O
		//IL_00fd: Expected O, but got I4
		bool flag = _maxSmashes >= 10;
		int num = 10;
		if (!flag)
		{
			num = _maxSmashes;
		}
		int num2 = _smashCounter & 1;
		bool flag2 = num2 == 0;
		float num3 = 1000f / (float)num;
		object obj = !flag2;
		if (obj == null)
		{
		}
		bool flag3 = _smashCounter == 0;
		float delay = 0f;
		if (!flag3)
		{
			delay = num3;
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num4 = (nint)array;
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
		tweenConfig.delay = delay;
		tweenConfig.duration = num3;
		tweenConfig.rotateMode = RotateMode.Fast;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_00aa: Expected O, but got I4
			DoScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_smashCounter * -100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_vandalize, soundConfig, 200f, 10, time);
			if (++_smashCounter >= _maxSmashes)
			{
				StartDespawn();
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				DoSmash();
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
	}

	private void UpdatePosition()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_smashCounter * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_vandalize, soundConfig, 200f, 10, time);
	}

	private void UpdateBody()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_00db: Expected O, but got I4
		//IL_00db: Expected O, but got I4
		//IL_00a7: Expected F4, but got I4
		//IL_00f8: Expected O, but got I4
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			Vector3 eulerAngles = _cachedTransform.eulerAngles;
			float num = eulerAngles.z * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num & 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float x = ((!(90f > eulerAngles.z)) ? ((float)obj * -105f) : 0f);
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			BaseBody baseBody3 = body.setOffset(x, (float?)(object)1);
		}
	}

	private void PlaySmashVfx()
	{
		ParticleSystem groundHitFX = GroundHitFX;
		if ((object)GroundHitFX != null && ((UnityEngine.Object)groundHitFX).m_CachedPtr != (IntPtr)0)
		{
			GroundHitFX.Play(withChildren: true);
		}
	}

	private void DoScreenShake()
	{
		//IL_00e2: Expected I, but got O
		//IL_0146: Expected O, but got I4
		//IL_0170: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
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
		tweenConfig.duration = 24f;
		tweenConfig.x = (float?)(object)1;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__19_0;
		if (_003C_003Ec._003C_003E9__19_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__19_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras3 = s_scene3.cameras;
				PhaserCamera main3 = cameras3.main;
				PhaserScene.BoxedVector2 followOffset2 = main3.followOffset;
				followOffset2.y = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__19_1;
		if (_003C_003Ec._003C_003E9__19_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__19_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}

	protected void EnableTrail(bool enable)
	{
		SpriteTrail spriteTrail = _SpriteTrail;
		if ((object)_SpriteTrail != null && ((UnityEngine.Object)spriteTrail).m_CachedPtr != (IntPtr)0)
		{
			SpriteTrail spriteTrail2 = _SpriteTrail.setVisible(enable);
		}
	}

	private void StartDespawn()
	{
		//IL_008b: Expected I, but got O
		//IL_00fd: Expected O, but got I4
		//IL_0140: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.delay = 200f;
		tweenConfig.duration = 200f;
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			EnableTrail(enable: false);
		};
		tweenConfig.onStart = onStart;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_Vandalize>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			if (_fadeTween != null)
			{
				TweenExtensions.Kill(_fadeTween);
			}
			TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_SwordSprite, 0f, 0.2f);
			TweenerCore<Color, Color, ColorOptions> fadeTween = TweenSettingsExtensions.SetDelay(t, 0.2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_fadeTween = fadeTween;
		}
	}

	public override void Despawn()
	{
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		base.Despawn();
	}

	private void _003CTweenIn_003Eb__13_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
		DoSmash();
	}

	private void _003CDoSmash_003Eb__14_0()
	{
		//IL_00aa: Expected O, but got I4
		DoScreenShake();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_smashCounter * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_vandalize, soundConfig, 200f, 10, time);
		if (++_smashCounter >= _maxSmashes)
		{
			StartDespawn();
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		DoSmash();
	}

	private void _003CStartDespawn_003Eb__21_0()
	{
		EnableTrail(enable: false);
	}
}
