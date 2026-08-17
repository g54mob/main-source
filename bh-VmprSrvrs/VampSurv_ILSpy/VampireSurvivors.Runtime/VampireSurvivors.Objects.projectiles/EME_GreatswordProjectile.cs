using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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

public class EME_GreatswordProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__34_0;

		public static TweenCallback _003C_003E9__34_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoScreenShake_003Eb__34_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.y = -2f;
		}

		internal void _003CDoScreenShake_003Eb__34_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	protected SpriteRenderer _SwordSprite;

	private ParticleSystem GroundHitFX;

	private SpriteTrail _SpriteTrail;

	protected const float Radius = 28f;

	protected const float ScaleModifier = 0.75f;

	protected const float Gravity = 6.25f;

	protected Sprite _swordSpriteFull;

	protected Sprite _swordSpriteGround;

	protected Vector2 _velocity;

	protected bool _hasLanded;

	protected float _timeToLand;

	protected Timer _landingTimer;

	protected bool _isFlipped;

	protected int _flipSwitch;

	protected Tween _angleTween;

	protected Tween _scaleTween;

	protected Tween _fadeTween;

	protected MultiTargetTween _screenShakeTween;

	protected virtual float MinTimeToLand => 1000f;

	protected virtual float MaxTimeToLand => 1400f;

	public bool HasLanded => _hasLanded;

	protected override void Awake()
	{
		base.Awake();
		SetupSwordSprites();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002b: Expected I4, but got I8
		//IL_0212: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_027a: Expected I4, but got I8
		//IL_005e: Expected O, but got I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected I4, but got Unknown
		//IL_00bb: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_02ad: Expected O, but got I4
		//IL_018a: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_hasLanded = false;
		float minTimeToLand = MinTimeToLand;
		float maxTimeToLand = MaxTimeToLand;
		float num = default(float);
		float timeToLand = UnityEngine.Random.Range(num, num);
		Weapon weapon2 = _weapon;
		_timeToLand = timeToLand;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		int num2 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
		{
			object obj = num2 - 1;
			object obj2 = obj | -2;
			num2 = obj2 + 1;
		}
		object obj3 = num2 - 1;
		bool flag = obj3 == null;
		object obj4 = (flag ? 1 : 0) - (characterController._isFlipped ? 1 : 0);
		bool flag2 = obj4 == null;
		bool isFlipped = !flag2;
		_isFlipped = isFlipped;
		bool flag3 = flag != characterController._isFlipped;
		int flipSwitch = -1;
		if (!flag3)
		{
			flipSwitch = 1;
		}
		_flipSwitch = flipSwitch;
		SetScaleToArea(0.75f);
		BaseBody baseBody = body;
		baseBody._enable = true;
		BaseBody baseBody2 = body.setCircle(28f, (float?)(object)1, (float?)(object)1);
		SetupSwordSprites();
		EnableTrail(enable: true);
		InitVelocity();
		StartSpinning();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float num3 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_greatsword_throw, soundConfig, 200f, 10, num3);
		if (_landingTimer != null)
		{
			_landingTimer.Cancel();
		}
		Action onComplete = Land;
		float duration = _timeToLand * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer landingTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num3 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_landingTimer = landingTimer;
	}

	private void SetupSwordSprites()
	{
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			Sprite sprite = SpriteManager.GetSprite("EME_Flamberge", "Emeralds_VFX");
			_swordSpriteFull = sprite;
			Sprite sprite2 = SpriteManager.GetSprite("EME_FlambergeGround", "Emeralds_VFX");
			_swordSpriteGround = sprite2;
			_SwordSprite.sprite = _swordSpriteFull;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_SwordSprite, 1f);
		}
	}

	public override void InternalUpdate()
	{
		if (!_hasLanded)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 6.25f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile)+FC]");
			float num2 = 0f - num;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody = sprite.body;
			baseBody._velocity = _velocity;
		}
	}

	protected virtual void InitVelocity()
	{
		//IL_00d1: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rcx+70h]\"");
		float num = 0f * 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rcx+114h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,dword ptr [rcx+70h]\"");
		float num2 = num + 5f;
		float num3 = 0f * 0.1f;
		float num4 = num3 + 3.3f;
		float num5 = num2 * 0f;
		float num6 = 90f - num5;
		float num7 = num6 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num8 = num7 * num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num9 = num7 * num4;
		_velocity = (Vector2)num8;
	}

	protected void UpdateVelocity()
	{
		if (!_hasLanded)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 6.25f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile)+FC]");
			float num2 = 0f - num;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody = sprite.body;
			baseBody._velocity = _velocity;
		}
	}

	protected unsafe void StartSpinning()
	{
		//IL_0042: Expected O, but got Ref
		float num = _timeToLand * 0.25f;
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		float duration = num * 0.001f;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&obj), duration, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
	}

	protected unsafe void Land()
	{
		//IL_018e: Expected I, but got O
		//IL_00aa: Expected O, but got Ref
		//IL_022a: Expected O, but got F4
		//IL_0259: Expected O, but got I4
		_hasLanded = true;
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v9 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody2 = sprite.body;
		baseBody2._velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		Transform transform = base.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			_SwordSprite.sprite = _swordSpriteGround;
		}
		ParticleSystem groundHitFX = GroundHitFX;
		if ((object)GroundHitFX != null && ((UnityEngine.Object)groundHitFX).m_CachedPtr != (IntPtr)0)
		{
			GroundHitFX.Play(withChildren: true);
		}
		DoScreenShake();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float num3 = (float)Vector3.zeroVector - 0.5f;
		float detune = num3 * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_greatsword_land, soundConfig, 200f, 10, time);
		DoGlimmerAttack();
	}

	protected virtual void DoGlimmerAttack()
	{
		StartDespawn();
	}

	protected void PlayLandingVfx()
	{
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			_SwordSprite.sprite = _swordSpriteGround;
		}
		ParticleSystem groundHitFX = GroundHitFX;
		if ((object)GroundHitFX != null && ((UnityEngine.Object)groundHitFX).m_CachedPtr != (IntPtr)0)
		{
			GroundHitFX.Play(withChildren: true);
		}
	}

	protected void DoScreenShake()
	{
		//IL_00e2: Expected I, but got O
		//IL_0162: Expected O, but got I4
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
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__34_0;
		if (_003C_003Ec._003C_003E9__34_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__34_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.y = -2f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__34_1;
		if (_003C_003Ec._003C_003E9__34_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__34_1 = delegate
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

	private void PlayThrowSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_greatsword_throw, soundConfig, 200f, 10, time);
	}

	private void PlayLandingSfx()
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
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_greatsword_land, soundConfig, 200f, 10, time);
	}

	public void StartDespawn()
	{
		//IL_00c7: Expected I, but got O
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScaleX(_cachedTransform, 0f, 0.25f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.75000006f);
		TweenCallback tweenCallback = delegate
		{
			EnableTrail(enable: false);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile>)+370]");
		TweenCallback tweenCallback2 = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			if (_fadeTween != null)
			{
				TweenExtensions.Kill(_fadeTween);
			}
			TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_SwordSprite, 0f, 0.25f);
			TweenerCore<Color, Color, ColorOptions> fadeTween = TweenSettingsExtensions.SetDelay(t2, 0.75000006f);
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
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		base.Despawn();
	}

	private void _003CStartDespawn_003Eb__38_0()
	{
		EnableTrail(enable: false);
	}
}
