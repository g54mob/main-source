using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile_BombardingFire_Explosion : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__14_0;

		public static TweenCallback _003C_003E9__14_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoScreenShake_003Eb__14_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -2f;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset2 = main2.followOffset;
			followOffset2.y = -2f;
		}

		internal void _003CDoScreenShake_003Eb__14_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private SpriteRenderer _GroundVFX;

	private ParticleSystem _ExplosionFX;

	private const float Radius = 48f;

	private const float VFXScale = 0.8f;

	private Tween _tween;

	private MultiTargetTween _screenShakeTween;

	private Timer _expireTimer;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00ba: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_0580: Expected O, but got F4
		//IL_05a8: Invalid comparison between F4 and I4
		//IL_05bb: Expected O, but got I4
		//IL_05e0: Expected O, but got I4
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected I4, but got Unknown
		//IL_0271->IL0416: Incompatible stack heights: 3 vs 0
		//IL_0217->IL0416: Incompatible stack heights: 3 vs 0
		//IL_0568->IL0416: Incompatible stack heights: 3 vs 0
		//IL_0257->IL0257: Incompatible stack heights: 6 vs 3
		//IL_03d8->IL0416: Incompatible stack heights: 3 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F66D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("circle", "vfx");
			if ((object)_GroundVFX != null)
			{
				_GroundVFX.sprite = sprite;
				ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(48f, (float?)(object)1, (float?)(object)1);
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._enable = false;
						_isCullable = false;
						if ((object)_GroundVFX != null)
						{
							Transform transform = _GroundVFX.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ rax_v46 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ rax_v46 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value);
							Transform transform2 = _GroundVFX.transform;
							bool flag2 = (object)transform2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v54 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v54 (UnityEngine.Transform)+10]");
							float value2 = default(float);
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundVFX, 1f);
							object explosionFX = _ExplosionFX;
							bool flag4 = (object)_ExplosionFX == null;
							float num2 = default(float);
							float num = num2;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rsi_v17 (System.Object)+10]");
								bool flag5 = (nint)0 == 0;
								num = num2;
								if (!flag5)
								{
									if ((object)_ExplosionFX == null)
									{
										goto IL_0416;
									}
									Transform transform3 = _ExplosionFX.transform;
									bool flag6 = (object)transform3 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1521 @ rax_v106 (UnityEngine.Transform)+10]");
									bool flag7 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1521 @ rax_v106 (UnityEngine.Transform)+10]");
									float value3 = default(float);
									Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value3));
									bool flag8 = (object)_ExplosionFX == null;
									_ExplosionFX.Play(withChildren: true);
									num = num2;
								}
							}
							if ((object)_weapon != null)
							{
								float num3 = _weapon.PArea();
								if (_tween != null)
								{
									TweenExtensions.Kill(_tween);
								}
								Transform target = base.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, num, 0.125f);
								TweenCallback tweenCallback = FadeOut;
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1524 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore != null)
								{
									_tween = tweenerCore;
									object obj = UnityEngine.Random.value;
									bool flag9 = num < 0.2f;
									float num4 = num - 0.2f;
									bool flag10 = num4 == 0f;
									object obj2 = flag9 | flag10;
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
									{
										Rate = 1f,
										Volume = (float?)(object)1
									};
									float detune = (float)_indexInWeapon * -20f;
									soundConfig.Detune = detune;
									SfxType sfxType = (SfxType)(obj2 + 509);
									float time = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 5, time);
									Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1148 Invalid \"Jump target not found in method: 0x1871D25A0\"");
								}
							}
						}
					}
				}
			}
		}
		goto IL_0416;
		IL_0416:
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void FadeOut()
	{
		if (_tween != null)
		{
			TweenExtensions.Kill(_tween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundVFX, 0f, 0.37500003f);
		TweenCallback tweenCallback = StartDespawn;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_tween = tweenerCore;
	}

	private void StartDespawn()
	{
		//IL_005d: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_BombardingFire_Explosion>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void Despawn()
	{
		ParticleSystem explosionFX = _ExplosionFX;
		if ((object)_ExplosionFX != null && ((UnityEngine.Object)explosionFX).m_CachedPtr != (IntPtr)0)
		{
			_ExplosionFX.Clear(withChildren: true);
		}
		if (_tween != null)
		{
			TweenExtensions.Kill(_tween);
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void PlaySfx()
	{
		//IL_0041: Expected O, but got F4
		//IL_004a: Invalid comparison between O and F4
		//IL_0069: Invalid comparison between F4 and I4
		//IL_007c: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected I4, but got Unknown
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2f);
		float num = (float)obj2 - 0.2f;
		bool flag2 = num == 0f;
		object obj3 = flag | flag2;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -20f;
		soundConfig.Detune = detune;
		SfxType sfxType = (SfxType)(obj3 + 509);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 5, time);
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
		tweenConfig.repeat = 2;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__14_0;
		if (_003C_003Ec._003C_003E9__14_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__14_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -2f;
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras3 = s_scene3.cameras;
				PhaserCamera main3 = cameras3.main;
				PhaserScene.BoxedVector2 followOffset2 = main3.followOffset;
				followOffset2.y = -2f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__14_1;
		if (_003C_003Ec._003C_003E9__14_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_1 = delegate
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
}
