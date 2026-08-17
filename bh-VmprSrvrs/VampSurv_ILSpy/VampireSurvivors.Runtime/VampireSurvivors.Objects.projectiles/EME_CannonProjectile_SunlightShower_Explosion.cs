using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile_SunlightShower_Explosion : Projectile
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
			followOffset.x = -2f;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset2 = main2.followOffset;
			followOffset2.y = -2f;
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

	private ParticleSystem _ExplosionBlueVFX;

	private ParticleSystem _ExplosionOrangeVFX;

	private const float Radius = 36f;

	private const float VFXScale = 1f;

	private const float VFXDurationMS = 700f;

	private const float TimeBetweenExplosionsMS = 200f;

	private const float BodyDuration = 600f;

	private List<ParticleSystem> _vfxList;

	private Timer _vfxTimer;

	private Timer _bodyTimer;

	private MultiTargetTween _screenShakeTween;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0146: Expected O, but got F4
		//IL_0170: Invalid comparison between F4 and I4
		//IL_0183: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected I4, but got Unknown
		//IL_00f5: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		SetScaleToArea();
		BaseBody baseBody = body.setCircle(36f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		Action onComplete = delegate
		{
			BaseBody baseBody3 = body;
			baseBody3._enable = false;
		};
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.6f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
		object obj = UnityEngine.Random.value;
		bool flag2 = 0.6f < 0.5f;
		float num = 0.6f - 0.5f;
		bool flag3 = num == 0f;
		object obj2 = flag2 | flag3;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -20f;
		soundConfig.Detune = detune;
		SfxType sfxType = (SfxType)(obj2 + 512);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 5, flag ? 1 : 0);
		DoFirstVFX();
		DoScreenShake();
	}

	private void LateUpdate()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void PlayVFX(ParticleSystem vfx)
	{
		//IL_00c4->IL0079: Incompatible stack heights: 1 vs 0
		if ((object)vfx != null && ((UnityEngine.Object)vfx).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = vfx.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			vfx.Play(withChildren: true);
		}
	}

	private void DoFirstVFX()
	{
		//IL_0137: Expected O, but got F4
		//IL_0140: Invalid comparison between O and F4
		List<ParticleSystem> vfxList = new List<ParticleSystem>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
		_vfxList = vfxList;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
		{
			((List<object>)(object)_vfxList).Reverse();
		}
		List<ParticleSystem> vfxList2 = _vfxList;
		bool flag = vfxList2._size <= 0;
		ParticleSystem[] items = vfxList2._items;
		PlayVFX(items[0]);
		if (_vfxTimer != null)
		{
			_vfxTimer.Cancel();
		}
		Action onComplete = DoSecondVFX;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer vfxTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_vfxTimer = vfxTimer;
	}

	private void DoSecondVFX()
	{
		//IL_009a: Expected I, but got O
		List<ParticleSystem> vfxList = _vfxList;
		if (vfxList._size > 1)
		{
			ParticleSystem[] items = vfxList._items;
			PlayVFX(items[1]);
			if (_vfxTimer != null)
			{
				_vfxTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShower_Explosion>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer vfxTimer = Timers.Register(0.70000005f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_vfxTimer = vfxTimer;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
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
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		float num = (float)obj2 - 0.5f;
		bool flag2 = num == 0f;
		object obj3 = flag | flag2;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -20f;
		soundConfig.Detune = detune;
		SfxType sfxType = (SfxType)(obj3 + 512);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 5, time);
	}

	public override void Despawn()
	{
		ParticleSystem explosionBlueVFX = _ExplosionBlueVFX;
		if ((object)_ExplosionBlueVFX != null && ((UnityEngine.Object)explosionBlueVFX).m_CachedPtr != (IntPtr)0)
		{
			_ExplosionBlueVFX.Clear(withChildren: true);
		}
		ParticleSystem explosionOrangeVFX = _ExplosionOrangeVFX;
		if ((object)_ExplosionOrangeVFX != null && ((UnityEngine.Object)explosionOrangeVFX).m_CachedPtr != (IntPtr)0)
		{
			_ExplosionOrangeVFX.Clear(withChildren: true);
		}
		if (_vfxTimer != null)
		{
			_vfxTimer.Cancel();
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
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
		TweenCallback onStart = _003C_003Ec._003C_003E9__19_0;
		if (_003C_003Ec._003C_003E9__19_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__19_0 = delegate
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

	private void _003CInitProjectile_003Eb__11_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
