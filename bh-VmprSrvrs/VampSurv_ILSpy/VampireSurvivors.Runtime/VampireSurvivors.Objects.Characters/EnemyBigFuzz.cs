using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters;

public class EnemyBigFuzz : EnemyController
{
	private enum FightPhase
	{
		AnimatingIn,
		ClawingIn,
		OpeningDoors,
		ShakingHeadPreLasers,
		GunnaFireLaser,
		DidFireLaser,
		ShakingHeadPreFire,
		FireBreathCharging,
		FireBreathRotation,
		ShakesSheadPostFire,
		ClosingDoors,
		Exploding,
		ChoppingHead,
		HeadFalling,
		Finished
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__53_3;

		public static Action _003C_003E9__62_1;

		public static Action _003C_003E9__62_0;

		public static TweenCallback _003C_003E9__64_0;

		public static TweenCallback _003C_003E9__64_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CStartClawingIn_003Eb__53_3()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_FB_K13_Rave;
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			GM.Core.SetupMusicBanger();
		}

		internal void _003CSpawnMinesAtTarget_003Eb__62_1()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzBomb, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
		}

		internal void _003CSpawnMinesAtTarget_003Eb__62_0()
		{
			//IL_0046: Expected O, but got F4
			//IL_0033: Expected F4, but got I4
			object obj = UnityEngine.Random.value;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_ExplosionLong, 150f, 3, 0f, volume, rate, detune, loop, 1f);
		}

		internal void _003CScreenShake_003Eb__64_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -5f;
		}

		internal void _003CScreenShake_003Eb__64_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public CharacterController character;

		public float2 targetPos;

		internal void _003CDoStartCameraTransition_003Eb__0()
		{
			float2 position = character.position;
			float2 obj = targetPos;
			bool flag = (byte)(position < obj) != 0;
			object obj2 = position - targetPos;
			bool flag2 = obj2 == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flipX = flag4 & flag3;
			ArcadeSprite arcadeSprite = character.setFlipX(flipX);
		}

		internal void _003CDoStartCameraTransition_003Eb__1()
		{
			CharacterController characterController = character;
			characterController._isAnimForced = false;
			CharacterController characterController2 = character;
			characterController2._canFlip = true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public PhaserSprite exp;

		public EnemyBigFuzz _003C_003E4__this;

		internal void _003CAddExplosionEffect_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
			EnemyBigFuzz enemyBigFuzz = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			EnemyBigFuzz enemyBigFuzz2 = _003C_003E4__this;
			bool flag = ((List<object>)(object)enemyBigFuzz2._explosionSprites).Remove((object)exp);
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public EnemyBigFuzz _003C_003E4__this;

		public bool firstTime;

		public Action _003C_003E9__3;

		public Action _003C_003E9__4;

		internal void _003COpenDoors_003Eb__0()
		{
			EnemyBigFuzz enemyBigFuzz = _003C_003E4__this;
			BaseBody body = enemyBigFuzz.body;
			body._enable = true;
			EnemyBigFuzz enemyBigFuzz2 = _003C_003E4__this;
			PhaserSprite phaserSprite = enemyBigFuzz2._leftEye.setVisible(visible: false);
			EnemyBigFuzz enemyBigFuzz3 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = enemyBigFuzz3._rightEye.setVisible(visible: false);
			if (firstTime)
			{
				GM.Core.SetAllPlayersWeaponsActive(active: true);
			}
			GameManager core = GM.Core;
			core._003CCanInterrupt_003Ek__BackingField = true;
			GameManager core2 = GM.Core;
			core2._003CCanPause_003Ek__BackingField = true;
		}

		internal void _003COpenDoors_003Eb__1()
		{
			EnemyBigFuzz enemyBigFuzz = _003C_003E4__this;
			enemyBigFuzz._phase = FightPhase.ShakingHeadPreLasers;
			Action onComplete = _003C_003E9__3;
			EnemyBigFuzz enemyBigFuzz2 = _003C_003E4__this;
			if (_003C_003E9__3 == null)
			{
				onComplete = (_003C_003E9__3 = delegate
				{
					EnemyBigFuzz enemyBigFuzz4 = _003C_003E4__this;
					enemyBigFuzz4._phase = FightPhase.GunnaFireLaser;
					Sprite sprite = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
					float2 originalSize = default(float2);
					ArcadeSprite arcadeSprite = _003C_003E4__this.setFrameIncludingOriginalSize(sprite, originalSize);
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			VampireSurvivors.Framework.TimerSystem.Timer laserChargeTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			enemyBigFuzz2._laserChargeTimer = laserChargeTimer;
			Action onComplete2 = _003C_003E9__4;
			EnemyBigFuzz enemyBigFuzz3 = _003C_003E4__this;
			if (_003C_003E9__4 == null)
			{
				onComplete2 = (_003C_003E9__4 = delegate
				{
					EnemyBigFuzz enemyBigFuzz4 = _003C_003E4__this;
					enemyBigFuzz4._phase = FightPhase.DidFireLaser;
					GameManager core = GM.Core;
					float2 eyePos = _003C_003E4__this.GetEyePos(left: true);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					GameManager core2 = GM.Core;
					float2 eyePos2 = _003C_003E4__this.GetEyePos(left: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				});
			}
			VampireSurvivors.Framework.TimerSystem.Timer laserFireTimer = Timers.Register(4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			enemyBigFuzz3._laserFireTimer = laserFireTimer;
			Action onComplete3 = _003C_003E4__this.StartPreFireShaking;
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(5f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003COpenDoors_003Eb__3()
		{
			EnemyBigFuzz enemyBigFuzz = _003C_003E4__this;
			enemyBigFuzz._phase = FightPhase.GunnaFireLaser;
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
			float2 originalSize = default(float2);
			ArcadeSprite arcadeSprite = _003C_003E4__this.setFrameIncludingOriginalSize(sprite, originalSize);
		}

		internal void _003COpenDoors_003Eb__4()
		{
			EnemyBigFuzz enemyBigFuzz = _003C_003E4__this;
			enemyBigFuzz._phase = FightPhase.DidFireLaser;
			GameManager core = GM.Core;
			float2 eyePos = _003C_003E4__this.GetEyePos(left: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			GameManager core2 = GM.Core;
			float2 eyePos2 = _003C_003E4__this.GetEyePos(left: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_1
	{
		public int index;

		public _003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals1;

		internal void _003COpenDoors_003Eb__2()
		{
			_003C_003Ec__DisplayClass54_0 obj = CS_0024_003C_003E8__locals1;
			float doorOpenAmount = (float)index / 7f;
			obj._003C_003E4__this.SetDoorOpenAmount(doorOpenAmount);
		}
	}

	private sealed class _003C_003Ec__DisplayClass58_0
	{
		public ParticleSystem pfxEmitter;

		public EnemyBigFuzz _003C_003E4__this;

		public Action _003C_003E9__6;

		internal void _003CStartPreFireShaking_003Eb__1()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			object obj = pfxEmitter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}

		internal void _003CStartPreFireShaking_003Eb__2()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			object obj = pfxEmitter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}

		internal void _003CStartPreFireShaking_003Eb__3()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			object obj = pfxEmitter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}

		internal void _003CStartPreFireShaking_003Eb__4()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			object obj = pfxEmitter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}

		internal void _003CStartPreFireShaking_003Eb__5()
		{
			//IL_0033: Expected F4, but got I4
			//IL_0065: Expected F4, but got I4
			//IL_015a: Expected I4, but got F4
			//IL_015a: Expected O, but got F4
			//IL_015a: Expected I4, but got O
			float? num = default(float?);
			float num2 = default(float);
			float num3 = default(float);
			bool flag = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Fireloop, 100f, 10, 0f, num, num2, num3, flag, 1f);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 100f, 10, 0f, num, num2, num3, flag, 1f);
			ParticleSystem particleSystem = pfxEmitter;
			if ((object)pfxEmitter != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
			{
				pfxEmitter.Emit(100);
				RenderingExtensions.StopEmitting(pfxEmitter);
			}
			Action onComplete = _003C_003E9__6;
			if (_003C_003E9__6 == null)
			{
				onComplete = (_003C_003E9__6 = delegate
				{
					ParticleSystem particleSystem2 = pfxEmitter;
					if ((object)pfxEmitter != null && ((UnityEngine.Object)particleSystem2).m_CachedPtr != (IntPtr)0)
					{
						GameObject gameObject = pfxEmitter.gameObject;
						UnityEngine.Object.Destroy(gameObject, 0f);
					}
				});
			}
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			EnemyBigFuzz enemyBigFuzz = _003C_003E4__this;
			enemyBigFuzz._phase = FightPhase.FireBreathRotation;
			EnemyBigFuzz enemyBigFuzz2 = _003C_003E4__this;
			enemyBigFuzz2._firebreathRotationDegrees = 0f;
		}

		internal void _003CStartPreFireShaking_003Eb__6()
		{
			ParticleSystem particleSystem = pfxEmitter;
			if ((object)pfxEmitter != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = pfxEmitter.gameObject;
				UnityEngine.Object.Destroy(gameObject, 0f);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass59_0
	{
		public int index;

		public EnemyBigFuzz _003C_003E4__this;

		internal void _003CCloseDoors_003Eb__1()
		{
			float num = (float)index / 7f;
			float doorOpenAmount = 1f - num;
			_003C_003E4__this.SetDoorOpenAmount(doorOpenAmount);
		}
	}

	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public int countdownTimer;

		public PhaserSprite mineSprite;

		public PhaserSprite lavaSprite;

		public EnemyBigFuzz _003C_003E4__this;

		public float2 location;

		public float circleRadius;

		public TweenCallback _003C_003E9__5;

		public Action _003C_003E9__3;

		internal void _003CSpawnMineToLocation_003Eb__1()
		{
			PhaserSprite phaserSprite = lavaSprite.setVisible(visible: true);
		}

		internal void _003CSpawnMineToLocation_003Eb__2()
		{
			_003C_003Ec__DisplayClass63_2 obj = new _003C_003Ec__DisplayClass63_2();
			obj.CS_0024_003C_003E8__locals2 = this;
			PhaserSprite phaserSprite = mineSprite.setVisible(visible: false);
			obj.explosionTimer = 0f;
			Action onComplete = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onComplete = (_003C_003E9__3 = delegate
				{
					//IL_002c: Expected I, but got O
					//IL_0082: Expected O, but got I4
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if ((object)lavaSprite != null)
					{
						nint num = (nint)array;
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
					tweenConfig.alpha = (float?)(object)1;
					tweenConfig.duration = 300f;
					TweenCallback onComplete2 = _003C_003E9__5;
					if (_003C_003E9__5 == null)
					{
						onComplete2 = (_003C_003E9__5 = delegate
						{
							GameObject gameObject = mineSprite.gameObject;
							UnityEngine.Object.Destroy(gameObject, 0f);
							GameObject gameObject2 = lavaSprite.gameObject;
							UnityEngine.Object.Destroy(gameObject2, 0f);
						});
					}
					tweenConfig.onComplete = onComplete2;
					MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
				});
			}
			Action<float> action = null;
			float time = default(float);
			((_003C_003Ec__DisplayClass63_2)(object)action)._003CSpawnMineToLocation_003Eb__4(time);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(2f, onComplete, action, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CSpawnMineToLocation_003Eb__3()
		{
			//IL_002c: Expected I, but got O
			//IL_0082: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)lavaSprite != null)
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
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = 300f;
			TweenCallback onComplete = _003C_003E9__5;
			if (_003C_003E9__5 == null)
			{
				onComplete = (_003C_003E9__5 = delegate
				{
					GameObject gameObject = mineSprite.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
					GameObject gameObject2 = lavaSprite.gameObject;
					UnityEngine.Object.Destroy(gameObject2, 0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CSpawnMineToLocation_003Eb__5()
		{
			GameObject gameObject = mineSprite.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
			GameObject gameObject2 = lavaSprite.gameObject;
			UnityEngine.Object.Destroy(gameObject2, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass63_1
	{
		public int index;

		public _003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CSpawnMineToLocation_003Eb__0()
		{
			//IL_003f: Expected O, but got Ref
			_003C_003Ec__DisplayClass63_0 obj = CS_0024_003C_003E8__locals1;
			int value = obj.countdownTimer - index;
			object obj2 = default(object);
			string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj2), CultureInfo.invariant_culture_info);
			string text2 = "fb_BF_Bomb" + text;
			_003C_003Ec__DisplayClass63_0 obj3 = CS_0024_003C_003E8__locals1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite frame = default(Sprite);
			PhaserSprite phaserSprite = obj3.mineSprite.setFrame(frame);
		}
	}

	private sealed class _003C_003Ec__DisplayClass63_2
	{
		public float explosionTimer;

		public _003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals2;

		internal unsafe void _003CSpawnMineToLocation_003Eb__4(float time)
		{
			//IL_023b: Invalid comparison between I4 and F4
			//IL_00bd: Expected F4, but got I4
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_01b7: Expected O, but got F4
			//IL_01bf: Invalid comparison between O and F4
			//IL_01de: Expected I, but got O
			//IL_01d1->IL02b0: Incompatible stack heights: 2 vs 0
			//IL_01f7->IL02b0: Incompatible stack heights: 2 vs 0
			float deltaTime = PauseSystem.DeltaTime;
			float num = explosionTimer - deltaTime;
			explosionTimer = num;
			float num2 = explosionTimer - deltaTime;
			if (!(0f < num2))
			{
				explosionTimer = 0.016f;
				_003C_003Ec__DisplayClass63_0 obj = CS_0024_003C_003E8__locals2;
				Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
				_003C_003Ec__DisplayClass63_0 obj2 = CS_0024_003C_003E8__locals2;
				object obj4 = default(object);
				object obj3 = obj4 * obj2.circleRadius;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v45 (VampireSurvivors.Objects.Characters.EnemyBigFuzz+<>c__DisplayClass63_0)+34]");
				float2 float5 = (float2)(obj3 + 0);
				float2 position = default(float2);
				obj._003C_003E4__this.AddExplosionEffect(position);
			}
			GameManager core = GM.Core;
			List<CharacterController>.Enumerator characters = (List<CharacterController>.Enumerator)core._characters;
			float num3 = 0f;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			object obj6 = default(object);
			while (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
				bool flag = (object)cachedTrans == null;
				bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				object obj5;
				float2 float5;
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform transform = body._transform;
					transform.position = ret;
					obj5 = obj6;
					float5 = ret;
				}
				else
				{
					obj5 = obj6;
					float5 = ret;
				}
				_003C_003Ec__DisplayClass63_0 obj7 = CS_0024_003C_003E8__locals2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v27 (VampireSurvivors.Objects.Characters.EnemyBigFuzz+<>c__DisplayClass63_0)+34]");
				object obj8 = 0 - obj5;
				object obj9 = obj7.location - float5;
				object obj10 = obj8 * obj8;
				object obj11 = obj9 * obj9;
				num3 = (float)obj11 + (float)obj10;
				characters = (List<CharacterController>.Enumerator)(obj7.circleRadius * obj7.circleRadius);
				if (System.Runtime.CompilerServices.Unsafe.As<List<CharacterController>.Enumerator, UIntPtr>(ref characters) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
				{
					nint num4 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v721 @ r8_v5 (Il2CppClass<ArcadeSprite>)+5F8] (should have been resolved before IL gen)");
					num3 = 10f;
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass75_0
	{
		public int index;

		public EnemyBigFuzz _003C_003E4__this;

		internal void _003CStartExploding_003Eb__1()
		{
			float num = (float)index / 7f;
			float doorOpenAmount = 1f - num;
			_003C_003E4__this.SetDoorOpenAmount(doorOpenAmount);
		}
	}

	private sealed class _003CWaitForStartCameraTransition_003Ed__44(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyBigFuzz _003C_003E4__this;

		public float2 mainPosition;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0122: Expected I4, but got O
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage = core._stage;
					if ((object)core._stage != null)
					{
						StageEventManager stageEventManager = stage._stageEventManager;
						if (stage._stageEventManager != null)
						{
							if (!stageEventManager._finishedTeleportingToRemotePlayer)
							{
								_003C_003E2__current = null;
								_003C_003E1__state = 1;
								return true;
							}
							if ((object)_003C_003E4__this != null)
							{
								float2 float5 = default(float2);
								_003C_003E4__this.DoStartCameraTransition(float5);
								goto IL_010e;
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_010e;
			IL_010e:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private PhaserSprite _body;

	private PhaserSprite _leftHand;

	private PhaserSprite _rightHand;

	private PhaserSprite _leftEye;

	private PhaserSprite _rightEye;

	private PhaserSprite _leftDoor;

	private PhaserSprite _rightDoor;

	private PhaserSprite _doorFrame;

	private PhaserSprite _doorSpace;

	private PhaserSprite _doorMask;

	private PhaserSprite _laserChargingLeft;

	private PhaserSprite _laserChargingRight;

	private FightPhase _phase;

	private float _doorOpenAmount;

	private float _firebreathRotationDegrees;

	private float _firebreathProjectileCooldown;

	private List<Sprite> _explosionFrames;

	private List<PhaserSprite> _explosionSprites;

	private List<PhaserSprite> _readyExplosionSprites;

	private float _explosionTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _laserHeadShakeTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _laserChargeTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _laserFireTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _fireHeadShakeTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _fireChargeTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _fireRotationTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _postFireHeadShakeTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _blinkTimer;

	private float2 _battleCenter;

	private float _scale;

	private List<StageEdge> _stageEdges;

	private List<float> _characterFallingTimers;

	private bool _usePolygonEdges;

	private float _shieldedDamage;

	private int _cycleCount;

	private List<EquipmentInfo> _removedEquipment;

	private float _relativeScale => _scale * 0.5f;

	public Vector2 BattleCenter
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			_battleCenter = value;
		}
	}

	private void CancelTimers()
	{
		if (_laserHeadShakeTimer != null)
		{
			_laserHeadShakeTimer.Cancel();
		}
		if (_laserChargeTimer != null)
		{
			_laserChargeTimer.Cancel();
		}
		if (_laserFireTimer != null)
		{
			_laserFireTimer.Cancel();
		}
		if (_fireHeadShakeTimer != null)
		{
			_fireHeadShakeTimer.Cancel();
		}
		if (_fireChargeTimer != null)
		{
			_fireChargeTimer.Cancel();
		}
		if (_fireRotationTimer != null)
		{
			_fireRotationTimer.Cancel();
		}
		if (_postFireHeadShakeTimer != null)
		{
			_postFireHeadShakeTimer.Cancel();
		}
		if (_blinkTimer != null)
		{
			_blinkTimer.Cancel();
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_1b9b: Expected O, but got I4
		//IL_00f8: Expected I4, but got O
		//IL_1910: Expected O, but got I
		//IL_0207: Expected O, but got F4
		//IL_0133: Expected O, but got I
		//IL_0228: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_01a7: Expected O, but got I
		//IL_19b0: Expected I4, but got I8
		//IL_1a34: Expected I4, but got I8
		//IL_1abd: Expected I4, but got I8
		//IL_05b2: Expected I4, but got I8
		//IL_0698: Expected I4, but got I8
		//IL_09a5: Expected I4, but got O
		//IL_09e6: Expected I, but got O
		//IL_0a03: Expected O, but got I
		//IL_0a83: Expected O, but got I4
		//IL_0a3f: Expected O, but got I
		//IL_0aa4: Expected O, but got I4
		//IL_0a95: Expected I4, but got O
		//IL_0a75: Expected O, but got I4
		//IL_10b8: Expected O, but got I
		//IL_0b2a: Expected O, but got I4
		//IL_10cf: Expected O, but got I
		//IL_10e1: Expected O, but got I
		//IL_10f8: Expected O, but got I
		//IL_110a: Expected O, but got I
		//IL_0b85: Expected I4, but got I8
		//IL_0c07: Expected O, but got I4
		//IL_0c62: Expected I4, but got I8
		//IL_1292: Expected O, but got I4
		//IL_0ce4: Expected O, but got I4
		//IL_0d3f: Expected I4, but got I8
		//IL_0dc1: Expected O, but got I4
		//IL_0e1c: Expected I4, but got I8
		//IL_0eae: Expected O, but got I4
		//IL_1455: Expected O, but got I4
		//IL_0f09: Expected I4, but got I8
		//IL_148a: Expected O, but got I4
		//IL_14bf: Expected O, but got I4
		//IL_14f4: Expected O, but got I4
		//IL_1529: Expected O, but got I4
		//IL_155e: Expected O, but got I4
		//IL_163d: Expected O, but got I
		//IL_16b6: Expected O, but got I
		//IL_194f->IL01c3: Incompatible stack heights: 4 vs 3
		//IL_18c5->IL18c5: Incompatible stack heights: 9 vs 0
		//IL_1194->IL1194: Incompatible stack heights: 43 vs 42
		//IL_11ed->IL11ed: Incompatible stack heights: 43 vs 42
		//IL_1246->IL1246: Incompatible stack heights: 43 vs 42
		//IL_108b->IL12a9: Incompatible stack heights: 68 vs 43
		//IL_16a0->IL1b14: Incompatible stack heights: 60 vs 61
		//IL_16fe->IL1b45: Incompatible stack heights: 62 vs 57
		int zeroPad = default(int);
		float2 float5 = default(float2);
		PhaserSprite phaserSprite;
		while (true)
		{
			_isImmuneToModification = true;
			base.InitEnemy(enemyType, asRemote);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fbDeathExplo_", 1, 6, "firstBloodEnemies", zeroPad);
			_explosionFrames = animationFrames;
			EnemyType height = (EnemyType)Screen.height;
			object obj = Screen.width;
			float num = (((nint)height <= (nint)obj) ? 2f : 1.7f);
			_scale = num;
			ProCamera2D instance = ProCamera2D.Instance;
			bool flag = (object)instance == null;
			instance.UpdateType = Com.LuisPedroFonseca.ProCamera2D.UpdateType.ManualUpdate;
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			bool flag2 = (object)_SpriteAnimation == null;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
			ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, float5);
			EnemyType enemyType2 = (EnemyType)_coherenceSync;
			base._003CSpeed_003Ek__BackingField = 0f;
			bool flag3 = (object)_coherenceSync == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rdi_v15 (VampireSurvivors.Data.EnemyType)+160]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rdi_v15 (VampireSurvivors.Data.EnemyType)+160]");
			bool num2;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rax_v51+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rax_v51+20]");
				bool flag4 = (nint)0 == 0;
				num2 = flag4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rcx_v266+10]");
				bool flag5 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rcx_v266+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rcx_v266+10]");
					object obj4 = -3;
					bool flag6 = obj4 == null;
					flag5 = flag6;
				}
				if (!flag5)
				{
					goto IL_1bba;
				}
			}
			Transform transform = base.transform;
			bool flag7 = (object)transform == null;
			num2 = flag7;
			_battleCenter = (float2)transform.position.x;
			goto IL_1bba;
			IL_1bba:
			float num3 = _scale * 0.5f;
			float num4 = num3 * -0.3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyBigFuzz)+344]");
			float num5 = 0f + num4;
			base.position = float5;
			StartSequence();
			bool flag8 = body == null;
			BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
			BaseBody baseBody2 = body;
			bool flag9 = body == null;
			baseBody2._immovable = true;
			BaseBody baseBody3 = body;
			bool flag10 = body == null;
			baseBody3._pushable = false;
			_usePolygonEdges = false;
			base._003CIsCullable_003Ek__BackingField = false;
			base._003CIsTeleportOnCull_003Ek__BackingField = false;
			GameObject gameObject = base.gameObject;
			phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, float5, "firstBloodEnemies", "BigFuzzBody");
			bool flag11 = (object)phaserSprite == null;
			Transform transform2 = phaserSprite.transform;
			bool flag12 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v64 (UnityEngine.Transform)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform2);
				continue;
			}
			break;
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2952 @ rcx_v54 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v64 (UnityEngine.Transform)+10]");
		Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1650);
		float2 float6 = base.position;
		bool flag13 = (object)phaserSprite2 == null;
		PhaserSprite phaserSprite3 = phaserSprite2.setPosition(float5);
		_body = phaserSprite3;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject2, float5, "firstBloodEnemies", "BigFuzzEye");
		bool flag14 = (object)phaserSprite4 == null;
		Transform transform3 = phaserSprite4.transform;
		bool flag15 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v79 (UnityEngine.Transform)+10]");
		bool flag16 = (nint)0 == 0;
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3120 @ rcx_v67 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v79 (UnityEngine.Transform)+10]");
		Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
		PhaserSprite phaserSprite5 = phaserSprite4.setDepth(-1630);
		float2 eyePos = GetEyePos(left: true);
		bool flag17 = (object)phaserSprite5 == null;
		PhaserSprite leftEye = phaserSprite5.setPosition(eyePos);
		_leftEye = leftEye;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject3, float5, "firstBloodEnemies", "BigFuzzEye");
		bool flag18 = (object)phaserSprite6 == null;
		Transform transform4 = phaserSprite6.transform;
		bool flag19 = (object)transform4 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v93 (UnityEngine.Transform)+10]");
		bool flag20 = (nint)0 == 0;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3283 @ rcx_v80 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v93 (UnityEngine.Transform)+10]");
		Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
		PhaserSprite phaserSprite7 = phaserSprite6.setDepth(-1630);
		float2 eyePos2 = GetEyePos(left: false);
		bool flag21 = (object)phaserSprite7 == null;
		PhaserSprite rightEye = phaserSprite7.setPosition(eyePos2);
		_rightEye = rightEye;
		PhaserSprite phaserSprite8 = RenderingExtensions.AddPhaserSprite(this, float5, "firstBloodEnemies", "BigFuzzHand");
		bool flag22 = (object)phaserSprite8 == null;
		Transform transform5 = phaserSprite8.transform;
		bool flag23 = (object)transform5 == null;
		transform5.SetParent(null, worldPositionStays: true);
		PhaserSprite phaserSprite9 = phaserSprite8.setVisible(visible: false);
		bool flag24 = (object)phaserSprite9 == null;
		PhaserSprite leftHand = phaserSprite9.setDepth(-100);
		_leftHand = leftHand;
		PhaserSprite phaserSprite10 = RenderingExtensions.AddPhaserSprite(this, float5, "firstBloodEnemies", "BigFuzzHand");
		bool flag25 = (object)phaserSprite10 == null;
		PhaserSprite phaserSprite11 = phaserSprite10.setFlipX(flipX: true);
		bool flag26 = (object)phaserSprite11 == null;
		Transform transform6 = phaserSprite11.transform;
		bool flag27 = (object)transform6 == null;
		transform6.SetParent(null, worldPositionStays: true);
		PhaserSprite phaserSprite12 = phaserSprite11.setVisible(visible: false);
		bool flag28 = (object)phaserSprite12 == null;
		PhaserSprite rightHand = phaserSprite12.setDepth(-100);
		_rightHand = rightHand;
		Material material = MaterialManager.GetMaterial(MaterialType.DefaultSpriteVariableTintFill);
		PhaserSprite phaserSprite13 = _body;
		bool flag29 = (object)_body == null;
		bool flag30 = (object)phaserSprite13._spriteRenderer == null;
		((Renderer)phaserSprite13._spriteRenderer).SetMaterial(material);
		CheckRenderer();
		bool flag31 = (object)((ArcadeSprite)this)._spriteRenderer == null;
		((Renderer)((ArcadeSprite)this)._spriteRenderer).SetMaterial(material);
		PhaserSprite phaserSprite14 = _body;
		bool flag32 = (object)_body == null;
		bool flag33 = (object)phaserSprite14._spriteRenderer == null;
		Material material2 = ((Renderer)phaserSprite14._spriteRenderer).GetMaterial();
		bool flag34 = (object)material2 == null;
		int num9 = Shader.PropertyToID("_TintFillAmount");
		material2.SetFloatImpl(num9, 0.5f);
		CheckRenderer();
		bool flag35 = (object)((ArcadeSprite)this)._spriteRenderer == null;
		Material material3 = ((Renderer)((ArcadeSprite)this)._spriteRenderer).GetMaterial();
		bool flag36 = (object)material3 == null;
		int num10 = Shader.PropertyToID("_TintFillAmount");
		material3.SetFloatImpl(num10, 0.5f);
		PhaserSprite phaserSprite15 = _body;
		bool flag37 = (object)_body == null;
		bool flag38 = (object)phaserSprite15._spriteRenderer == null;
		Material material4 = ((Renderer)phaserSprite15._spriteRenderer).GetMaterial();
		bool flag39 = (object)material4 == null;
		int num11 = Shader.PropertyToID("_TintFillMultiplier");
		material4.SetFloatImpl(num11, 0.75f);
		CheckRenderer();
		bool flag40 = (object)((ArcadeSprite)this)._spriteRenderer == null;
		Material material5 = ((Renderer)((ArcadeSprite)this)._spriteRenderer).GetMaterial();
		bool flag41 = (object)material5 == null;
		int num12 = Shader.PropertyToID("_TintFillMultiplier");
		material5.SetFloatImpl(num12, 0.75f);
		GameManager core = GM.Core;
		bool flag42 = (object)GM.Core == null;
		Stage stage = core._stage;
		bool flag43 = (object)core._stage == null;
		EnemyType enemyType3 = (EnemyType)stage._fancyBg;
		EnemyType enemyType4;
		if ((object)stage._fancyBg == null)
		{
			enemyType4 = EnemyType.BAT1;
			goto IL_0a9a;
		}
		nint num13 = (nint)typeof(BackgroundFBGaluga_Basic);
		int value__ = ((EnemyType*)(int)enemyType3)->value__;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3464 @ r8_v125 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFBGaluga_Basic>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3465 @ r9_v66 (System.Int32)+130]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3464 @ r8_v125 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFBGaluga_Basic>)+130]");
		object obj7;
		if (num14 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3465 @ r9_v66 (System.Int32)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3521 @ rax_v268+FFFFFFF8+v3466 @ rax_v264*8]");
			if (0 == (nint)typeof(BackgroundFBGaluga_Basic))
			{
				obj7 = 1;
				goto IL_1aee;
			}
		}
		obj7 = 0;
		goto IL_1aee;
		IL_0a9a:
		if ((UnityEngine.Object)enemyType4 == null)
		{
			PhaserSprite phaserSprite16 = RenderingExtensions.AddPhaserSprite(this, float5, "firstBlood", "DoorLeft");
			bool flag44 = (object)phaserSprite16 == null;
			PhaserSprite phaserSprite17 = phaserSprite16.setOrigin(float5);
			bool flag45 = (object)phaserSprite17 == null;
			PhaserSprite phaserSprite18 = phaserSprite17.setScale(_scale, (float?)(object)0);
			bool flag46 = (object)phaserSprite18 == null;
			PhaserSprite phaserSprite19 = phaserSprite18.setParent(null);
			bool flag47 = (object)phaserSprite19 == null;
			PhaserSprite leftDoor = phaserSprite19.setDepth(-1620);
			_leftDoor = leftDoor;
			PhaserSprite phaserSprite20 = RenderingExtensions.AddPhaserSprite(this, float5, "firstBlood", "DoorRight");
			bool flag48 = (object)phaserSprite20 == null;
			PhaserSprite phaserSprite21 = phaserSprite20.setOrigin(float5);
			bool flag49 = (object)phaserSprite21 == null;
			PhaserSprite phaserSprite22 = phaserSprite21.setScale(_scale, (float?)(object)0);
			bool flag50 = (object)phaserSprite22 == null;
			PhaserSprite phaserSprite23 = phaserSprite22.setParent(null);
			bool flag51 = (object)phaserSprite23 == null;
			PhaserSprite rightDoor = phaserSprite23.setDepth(-1620);
			_rightDoor = rightDoor;
			PhaserSprite phaserSprite24 = RenderingExtensions.AddPhaserSprite(this, float5, "firstBlood", "DoorFrame");
			bool flag52 = (object)phaserSprite24 == null;
			PhaserSprite phaserSprite25 = phaserSprite24.setOrigin(float5);
			bool flag53 = (object)phaserSprite25 == null;
			PhaserSprite phaserSprite26 = phaserSprite25.setScale(_scale, (float?)(object)0);
			bool flag54 = (object)phaserSprite26 == null;
			PhaserSprite phaserSprite27 = phaserSprite26.setParent(null);
			bool flag55 = (object)phaserSprite27 == null;
			PhaserSprite doorFrame = phaserSprite27.setDepth(-1610);
			_doorFrame = doorFrame;
			PhaserSprite phaserSprite28 = RenderingExtensions.AddPhaserSprite(this, float5, "firstBlood", "DoorSpace");
			bool flag56 = (object)phaserSprite28 == null;
			PhaserSprite phaserSprite29 = phaserSprite28.setOrigin(float5);
			bool flag57 = (object)phaserSprite29 == null;
			PhaserSprite phaserSprite30 = phaserSprite29.setScale(_scale, (float?)(object)0);
			bool flag58 = (object)phaserSprite30 == null;
			PhaserSprite phaserSprite31 = phaserSprite30.setParent(null);
			bool flag59 = (object)phaserSprite31 == null;
			PhaserSprite doorSpace = phaserSprite31.setDepth(-1700);
			_doorSpace = doorSpace;
			PhaserSprite phaserSprite32 = RenderingExtensions.AddPhaserSprite(this, float5, "vfx", "WhiteDot");
			bool flag60 = (object)phaserSprite32 == null;
			PhaserSprite phaserSprite33 = phaserSprite32.setOrigin(float5);
			bool flag61 = (object)phaserSprite33 == null;
			float xScale = _scale * 250f;
			PhaserSprite phaserSprite34 = phaserSprite33.setScale(xScale, (float?)(object)1);
			bool flag62 = (object)phaserSprite34 == null;
			PhaserSprite phaserSprite35 = phaserSprite34.setParent(null);
			bool flag63 = (object)phaserSprite35 == null;
			PhaserSprite phaserSprite36 = phaserSprite35.setDepth(-1700);
			bool flag64 = (object)phaserSprite36 == null;
			PhaserSprite doorMask = phaserSprite36.setVisible(visible: false);
			_doorMask = doorMask;
			bool flag65 = (object)_doorMask == null;
			GameObject gameObject4 = _doorMask.gameObject;
			bool flag66 = (object)gameObject4 == null;
			SpriteMask spriteMask = gameObject4.AddComponent<SpriteMask>();
			Sprite sprite2 = SpriteManager.GetSprite("WhiteDot", "vfx");
			bool flag67 = (object)spriteMask == null;
			spriteMask.sprite = sprite2;
			PhaserSprite leftDoor2 = _leftDoor;
			bool flag68 = (object)_leftDoor == null;
			bool flag69 = (object)leftDoor2._spriteRenderer == null;
			leftDoor2._spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
			PhaserSprite rightDoor2 = _rightDoor;
			bool flag70 = (object)_rightDoor == null;
			bool flag71 = (object)rightDoor2._spriteRenderer == null;
			rightDoor2._spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
		}
		else
		{
			bool flag72 = enemyType4 == EnemyType.BAT1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v32 (VampireSurvivors.Data.EnemyType)+E0]");
			_leftDoor = (PhaserSprite)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v32 (VampireSurvivors.Data.EnemyType)+E8]");
			_rightDoor = (PhaserSprite)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v32 (VampireSurvivors.Data.EnemyType)+F0]");
			_doorFrame = (PhaserSprite)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v32 (VampireSurvivors.Data.EnemyType)+F8]");
			_doorSpace = (PhaserSprite)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdi_v32 (VampireSurvivors.Data.EnemyType)+100]");
			_doorMask = (PhaserSprite)0;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[3];
			bool flag73 = array == null;
			if ((object)_leftDoor != null)
			{
				int value__2 = ((EnemyType*)(&array))->value__;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				bool flag74 = obj8 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_rightDoor != null)
			{
				int value__3 = ((EnemyType*)(&array))->value__;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				bool flag75 = obj9 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_doorFrame != null)
			{
				int value__4 = ((EnemyType*)(&array))->value__;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj10 = default(object);
				bool flag76 = obj10 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			bool flag77 = tweenConfig == null;
			tweenConfig.targets = array;
			tweenConfig.duration = 2000f;
			tweenConfig.tint = (uint?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
		PhaserSprite phaserSprite37 = RenderingExtensions.AddPhaserSprite(this, float5, "vfx", "blurredSharpStar");
		bool flag78 = (object)phaserSprite37 == null;
		PhaserSprite phaserSprite38 = phaserSprite37.setDepth(1001);
		bool flag79 = (object)phaserSprite38 == null;
		PhaserSprite phaserSprite39 = phaserSprite38.setTint(16755200u);
		bool flag80 = (object)phaserSprite39 == null;
		Transform transform7 = phaserSprite39.transform;
		bool flag81 = (object)transform7 == null;
		transform7.SetParent(null, worldPositionStays: true);
		_laserChargingLeft = phaserSprite39;
		PhaserSprite phaserSprite40 = RenderingExtensions.AddPhaserSprite(this, float5, "vfx", "blurredSharpStar");
		bool flag82 = (object)phaserSprite40 == null;
		PhaserSprite phaserSprite41 = phaserSprite40.setDepth(1001);
		bool flag83 = (object)phaserSprite41 == null;
		PhaserSprite phaserSprite42 = phaserSprite41.setTint(16755200u);
		bool flag84 = (object)phaserSprite42 == null;
		Transform transform8 = phaserSprite42.transform;
		bool flag85 = (object)transform8 == null;
		transform8.SetParent(null, worldPositionStays: true);
		_laserChargingRight = phaserSprite42;
		ArcadeSprite arcadeSprite2 = setScale(_scale, (float?)(object)0);
		bool flag86 = (object)_leftHand == null;
		PhaserSprite phaserSprite43 = _leftHand.setScale(_scale, (float?)(object)0);
		bool flag87 = (object)_rightHand == null;
		PhaserSprite phaserSprite44 = _rightHand.setScale(_scale, (float?)(object)0);
		bool flag88 = (object)_body == null;
		PhaserSprite phaserSprite45 = _body.setScale(_scale, (float?)(object)0);
		bool flag89 = (object)_leftEye == null;
		PhaserSprite phaserSprite46 = _leftEye.setScale(_scale, (float?)(object)0);
		bool flag90 = (object)_rightEye == null;
		PhaserSprite phaserSprite47 = _rightEye.setScale(_scale, (float?)(object)0);
		SetDoorOpenAmount(0f);
		CreateStageEdges(_scale);
		List<float> characterFallingTimers = new List<float>();
		_characterFallingTimers = characterFallingTimers;
		GameManager core2 = GM.Core;
		bool flag91 = (object)GM.Core == null;
		EnemyType enemyType5 = EnemyType.BAT1;
		EnemyType enemyType6 = EnemyType.BAT1;
		while (true)
		{
			List<CharacterController> characters = core2._characters;
			bool flag92 = core2._characters == null;
			if ((int)enemyType5 >= characters._size)
			{
				break;
			}
			List<float> characterFallingTimers2 = _characterFallingTimers;
			bool flag93 = _characterFallingTimers == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rcx_v171 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rcx_v171 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rcx_v171 (System.Collections.Generic.List`1<System.Single>)+10]");
			bool flag94 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rcx_v171 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ r8_v84+18]");
			if (num15 >= 0)
			{
				_characterFallingTimers.AddWithResize(0f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rcx_v171 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj12 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rcx_v171 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ r8_v84+18]");
				bool flag95 = num16 >= 0;
				_ = 0;
			}
			enemyType6++;
			core2 = GM.Core;
			bool flag96 = (object)GM.Core == null;
			enemyType5 = enemyType6;
		}
		bool flag97 = (object)_body == null;
		PhaserSprite phaserSprite48 = _body.setVisible(visible: false);
		ArcadeSprite arcadeSprite3 = setVisible(visible: false);
		bool flag98 = (object)_leftEye == null;
		PhaserSprite phaserSprite49 = _leftEye.setVisible(visible: false);
		bool flag99 = (object)_rightEye == null;
		PhaserSprite phaserSprite50 = _rightEye.setVisible(visible: false);
		bool flag100 = (object)_doorSpace == null;
		PhaserSprite phaserSprite51 = _doorSpace.setVisible(visible: false);
		GameManager core3 = GM.Core;
		bool flag101 = (object)GM.Core == null;
		Stage stage2 = core3._stage;
		bool flag102 = (object)core3._stage == null;
		StageEventManager stageEventManager = stage2._stageEventManager;
		bool flag103 = stage2._stageEventManager == null;
		if (!stageEventManager._isTeleportingToRemotePlayer)
		{
			DoStartCameraTransition(float5);
		}
		else
		{
			_003CWaitForStartCameraTransition_003Ed__44 obj13 = null;
			obj13._003C_003E1__state = 0;
			obj13._003C_003E4__this = this;
			obj13.mainPosition = _battleCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyBigFuzz)+344]");
			_ = 0;
			Coroutine coroutine = StartCoroutine(obj13);
		}
		_shieldedDamage = 0f;
		return;
		IL_1aee:
		bool flag104 = obj7 == null;
		enemyType4 = EnemyType.BAT1;
		if (!flag104)
		{
			enemyType4 = (EnemyType)stage._fancyBg;
		}
		goto IL_0a9a;
	}

	private IEnumerator WaitForStartCameraTransition(float2 mainPosition)
	{
		_003CWaitForStartCameraTransition_003Ed__44 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.mainPosition = mainPosition;
		return obj;
	}

	private unsafe void DoStartCameraTransition(float2 mainPosition)
	{
		//IL_0660: Expected I, but got O
		//IL_0680: Expected F4, but got I
		//IL_007d: Expected O, but got I4
		//IL_05ae: Expected I, but got O
		//IL_05c4: Expected O, but got I
		//IL_05cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_063b: Expected I, but got O
		//IL_07c2: Expected I, but got I8
		//IL_07f0: Expected I4, but got F4
		//IL_0105: Expected O, but got I4
		//IL_0624: Expected I, but got I8
		//IL_037c: Expected O, but got F4
		//IL_02ca: Expected I, but got O
		//IL_03be: Expected O, but got I4
		//IL_03ce: Expected O, but got I
		//IL_03dc: Expected O, but got I4
		//IL_06b8: Expected I, but got O
		//IL_06ce: Expected O, but got I
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected O, but got Unknown
		//IL_0469: Expected I, but got O
		//IL_0710: Expected I, but got I8
		//IL_072f: Expected I, but got O
		//IL_0745: Expected O, but got I
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Expected O, but got Unknown
		//IL_0452: Expected I, but got I8
		//IL_0516: Expected I, but got O
		//IL_0787: Expected I, but got I8
		//IL_04ff: Expected I, but got I8
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveAllCameraTargets(1f);
		ProCamera2D instance2 = ProCamera2D.Instance;
		Transform targetTransform = _doorFrame.transform;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v14 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		float num3 = 0f;
		float num4 = default(float);
		Vector2 vector = default(Vector2);
		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance2.AddCameraTarget(targetTransform, 1f, 1f, num4, vector);
		GameManager core = GM.Core;
		object obj = 24;
		bool flag = false;
		float num5 = 1f;
		object obj3 = default(object);
		object obj2 = obj3;
		bool flag2 = false;
		object obj6 = default(object);
		object obj7 = default(object);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			List<CharacterController> characters = core._characters;
			_003C_003Ec__DisplayClass45_0 obj4;
			TweenConfig tweenConfig;
			TweenCallback tweenCallback;
			if ((flag2 ? 1 : 0) < characters._size)
			{
				obj4 = new _003C_003Ec__DisplayClass45_0();
				GameManager core2 = GM.Core;
				List<CharacterController> characters2 = core2._characters;
				object obj5 = characters2._size - 1;
				float num6 = _scale * 0.5f;
				GameManager core3 = GM.Core;
				List<CharacterController> characters3 = core3._characters;
				float num7 = (float)obj5 * num6;
				float num8 = num7 * 0.5f;
				if ((flag ? 1 : 0) < characters3._size)
				{
					CharacterController[] items = characters3._items;
					obj4.character = items[flag ? 1u : 0u];
					CharacterController character = obj4.character;
					character._isAnimForced = true;
					CharacterController character2 = obj4.character;
					SpriteAnimation spriteAnimation = character2._spriteAnimation;
					((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
					CharacterController character3 = obj4.character;
					character3._spriteAnimation.SetAnimation(character3._003CCurrentWalkAnimName_003Ek__BackingField);
					CharacterController character4 = obj4.character;
					character4._canFlip = false;
					object[] array = new object[1];
					GameManager core4 = GM.Core;
					List<CharacterController> characters4 = core4._characters;
					if ((flag ? 1 : 0) < characters4._size)
					{
						CharacterController[] items2 = characters4._items;
						if ((object)items2[flag ? 1u : 0u] != null)
						{
							nint num9 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							if (obj6 == null)
							{
								break;
							}
						}
						array[0] = items2[flag ? 1u : 0u];
						float num10 = (float)mainPosition - num8;
						float num11 = _scale * 0.5f;
						float num12 = (float)(flag ? 1 : 0) * num6;
						num3 = num11 * 1.8f;
						num5 = num12 + num10;
						float num13 = (float)obj7 - num3;
						obj4.targetPos = (float2)num5;
						tweenConfig = new TweenConfig();
						tweenConfig.targets = array;
						tweenConfig.duration = 2000f;
						tweenConfig.x = (float?)(object)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v37 (VampireSurvivors.Objects.Characters.EnemyBigFuzz+<>c__DisplayClass45_0)+1C]");
						obj2 = 0;
						tweenConfig.y = (float?)(object)1;
						tweenCallback = null;
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1181 @ r10_v7 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass45_0._003CDoStartCameraTransition_003Eb__0);
						((Delegate)tweenCallback).m_target = obj4;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1181 @ r10_v7 (Il2CppMethodInfo)+4C]");
						object obj8 = (nint)0 >> 4;
						object obj9 = obj8 & 1;
						nint num15;
						if (obj9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1181 @ r10_v7 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num15 = unchecked((nint)6447293664L);
								goto IL_06f9;
							}
						}
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						num15 = ((Delegate)tweenCallback).method_ptr;
						goto IL_06f9;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Action action = null;
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(EnemyBigFuzz.StartClawingIn);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj10 = (nint)0 >> 4;
			object obj11 = obj10 & 1;
			nint num17;
			if (obj11 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num17 = unchecked((nint)6447293664L);
					goto IL_07ab;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num17 = ((Delegate)action).method_ptr;
			goto IL_07ab;
			IL_06f9:
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			tweenConfig.onUpdate = tweenCallback;
			tweenConfig.ease = Ease.InOutQuad;
			TweenCallback tweenCallback2 = null;
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v8 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass45_0._003CDoStartCameraTransition_003Eb__1);
			((Delegate)tweenCallback2).m_target = obj4;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v8 (Il2CppMethodInfo)+4C]");
			object obj12 = (nint)0 >> 4;
			object obj13 = obj12 & 1;
			nint num19;
			if (obj13 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v8 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num19 = unchecked((nint)6447293664L);
					goto IL_0770;
				}
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num19 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_0770;
			IL_0770:
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			tweenConfig.onComplete = tweenCallback2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			core = GM.Core;
			flag2 = flag;
			continue;
			IL_07ab:
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(2.5f, action, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void CreateStageEdges(float newScale)
	{
		float localScale = 2f / newScale;
		List<StageEdge> stageEdges = new List<StageEdge>();
		_stageEdges = stageEdges;
		StageEdge stageEdge = new StageEdge();
		List<float2> list = new List<float2>();
		float2 item = default(float2);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		Polygon polygon = CreatePhaserSpacePolygon(list, localScale);
		stageEdge._polygon = polygon;
		stageEdge._rotationAngle = 0f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge);
		StageEdge stageEdge2 = new StageEdge();
		List<float2> list2 = new List<float2>();
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		Polygon polygon2 = CreatePhaserSpacePolygon(list2, localScale);
		stageEdge2._polygon = polygon2;
		stageEdge2._rotationAngle = -27f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge2);
		StageEdge stageEdge3 = new StageEdge();
		List<float2> list3 = new List<float2>();
		list3.Add(item);
		list3.Add(item);
		list3.Add(item);
		list3.Add(item);
		Polygon polygon3 = CreatePhaserSpacePolygon(list3, localScale);
		stageEdge3._polygon = polygon3;
		stageEdge3._rotationAngle = -90f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge3);
		StageEdge stageEdge4 = new StageEdge();
		List<float2> list4 = new List<float2>();
		list4.Add(item);
		list4.Add(item);
		list4.Add(item);
		list4.Add(item);
		Polygon polygon4 = CreatePhaserSpacePolygon(list4, localScale);
		stageEdge4._polygon = polygon4;
		stageEdge4._rotationAngle = -153f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge4);
		StageEdge stageEdge5 = new StageEdge();
		List<float2> list5 = new List<float2>();
		list5.Add(item);
		list5.Add(item);
		list5.Add(item);
		list5.Add(item);
		Polygon polygon5 = CreatePhaserSpacePolygon(list5, localScale);
		stageEdge5._polygon = polygon5;
		stageEdge5._rotationAngle = -180f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge5);
		StageEdge stageEdge6 = new StageEdge();
		List<float2> list6 = new List<float2>();
		list6.Add(item);
		list6.Add(item);
		list6.Add(item);
		list6.Add(item);
		Polygon polygon6 = CreatePhaserSpacePolygon(list6, localScale);
		stageEdge6._polygon = polygon6;
		stageEdge6._rotationAngle = -207f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge6);
		StageEdge stageEdge7 = new StageEdge();
		List<float2> list7 = new List<float2>();
		list7.Add(item);
		list7.Add(item);
		list7.Add(item);
		list7.Add(item);
		Polygon polygon7 = CreatePhaserSpacePolygon(list7, localScale);
		stageEdge7._polygon = polygon7;
		stageEdge7._rotationAngle = -270f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge7);
		StageEdge stageEdge8 = new StageEdge();
		List<float2> list8 = new List<float2>();
		list8.Add(item);
		list8.Add(item);
		list8.Add(item);
		list8.Add(item);
		Polygon polygon8 = CreatePhaserSpacePolygon(list8, localScale);
		stageEdge8._polygon = polygon8;
		stageEdge8._rotationAngle = -333f;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge8);
		StageEdge stageEdge9 = new StageEdge();
		List<float2> list9 = new List<float2>();
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		Polygon polygon9 = CreatePhaserSpacePolygon(list9, localScale);
		stageEdge9._polygon = polygon9;
		stageEdge9._rotationAngle = 0f;
		stageEdge9._fallRegion = true;
		((List<float2>)(object)_stageEdges).Add((float2)stageEdge9);
	}

	private Polygon CreatePhaserSpacePolygon(List<float2> points, float localScale)
	{
		//IL_000e: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0057: Expected O, but got I
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0077->IL02ae: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL02ae: Incompatible stack heights: 1 vs 0
		//IL_0120->IL02ae: Incompatible stack heights: 1 vs 0
		//IL_014c->IL02ae: Incompatible stack heights: 1 vs 0
		//IL_031c->IL02ae: Incompatible stack heights: 2 vs 0
		//IL_0184->IL02ae: Incompatible stack heights: 2 vs 0
		//IL_0255->IL02ae: Incompatible stack heights: 3 vs 0
		//IL_0292->IL0321: Incompatible stack heights: 3 vs 0
		if (points != null)
		{
			object obj = 0;
			float num = localScale;
			object obj2 = 0;
			object obj7 = default(object);
			while (true)
			{
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				if ((nint)obj3 < 0)
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag = (nint)obj4 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v17+24+v89 @ rbx_v7*8]");
					object obj6 = 0 ^ -0f;
					float num2 = (float)obj6 * 0.01f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rcx_v17+20+v89 @ rbx_v7*8]");
					float num3 = 0f * 0.01f;
					if ((object)_doorFrame == null)
					{
						break;
					}
					float num4 = _doorFrame.scale;
					float num5 = num3 * num4;
					float num6 = num2 * num4;
					if ((object)_doorFrame == null)
					{
						break;
					}
					Transform transform = _doorFrame.transform;
					if ((object)transform == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					if ((object)_doorFrame == null)
					{
						break;
					}
					float width = _doorFrame.Width;
					if ((object)_doorFrame == null)
					{
						break;
					}
					float num7 = width * -0.25f;
					float num8 = num7 * localScale;
					float height = _doorFrame.Height;
					float num9 = (float)ret + num8;
					float num10 = height * 0.25f;
					float num11 = num9 + num5;
					float num12 = num10 * localScale;
					float num13 = (float)obj7 + num12;
					num = num13 + num6;
					object obj8 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
					bool flag3 = (nint)obj8 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+1C]");
					_ = (nint)0 + (nint)1;
					obj++;
					obj2 = obj;
					continue;
				}
				Polygon polygon = null;
				polygon._points = points;
				return polygon;
			}
		}
		throw new NullReferenceException();
	}

	private void AddExplosionEffect(float2 position)
	{
		//IL_018f: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_02b1: Expected I4, but got O
		//IL_01d9->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0251->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0298->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_015d->IL027e: Incompatible stack heights: 0 vs 1
		//IL_02ce->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0314->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_0336->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_036b->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_039a->IL03f2: Incompatible stack heights: 1 vs 0
		//IL_04a7->IL03f2: Incompatible stack heights: 2 vs 0
		//IL_03e2->IL03f2: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass48_0();
		if (CS_0024_003C_003E8__locals20 != null)
		{
			CS_0024_003C_003E8__locals20._003C_003E4__this = this;
			List<PhaserSprite> readyExplosionSprites = _readyExplosionSprites;
			if (_readyExplosionSprites != null)
			{
				if (readyExplosionSprites._size <= 0)
				{
					PhaserWorld instance = PhaserWorld.Instance;
					if ((object)instance != null)
					{
						PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "firstBlood", "Crush Bomb-Explosion-F1");
						if ((object)phaserSprite != null)
						{
							PhaserSprite exp = phaserSprite.setScale(_scale, (float?)(object)0);
							CS_0024_003C_003E8__locals20.exp = exp;
							PhaserSprite exp2 = CS_0024_003C_003E8__locals20.exp;
							if ((object)CS_0024_003C_003E8__locals20.exp != null)
							{
								Action action = delegate
								{
									PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals20.exp.setVisible(visible: false);
									EnemyBigFuzz enemyBigFuzz = CS_0024_003C_003E8__locals20._003C_003E4__this;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
									EnemyBigFuzz enemyBigFuzz2 = CS_0024_003C_003E8__locals20._003C_003E4__this;
									bool flag3 = ((List<object>)(object)enemyBigFuzz2._explosionSprites).Remove((object)CS_0024_003C_003E8__locals20.exp);
								};
								if ((object)exp2._spriteAnimation != null)
								{
									bool shouldLoop = default(bool);
									bool startRandomFrame = default(bool);
									Action onComplete = default(Action);
									bool autoSetAnimation = default(bool);
									exp2._spriteAnimation.AddAnimation("bang", _explosionFrames, 16, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
									goto IL_027e;
								}
							}
						}
					}
				}
				else if (_readyExplosionSprites != null)
				{
					object obj = readyExplosionSprites._size - 1;
					bool flag = (nint)obj >= readyExplosionSprites._size;
					PhaserSprite[] items = readyExplosionSprites._items;
					if (readyExplosionSprites._items != null)
					{
						object obj2 = readyExplosionSprites._size - 1;
						if ((nint)obj2 >= items.Length)
						{
							throw new IndexOutOfRangeException();
						}
						CS_0024_003C_003E8__locals20.exp = items[obj2];
						List<PhaserSprite> readyExplosionSprites2 = _readyExplosionSprites;
						if (_readyExplosionSprites != null)
						{
							int index = readyExplosionSprites2._size - 1;
							_readyExplosionSprites.RemoveAt(index);
							goto IL_027e;
						}
					}
				}
			}
		}
		goto IL_03f2;
		IL_027e:
		if (_explosionSprites != null)
		{
			_explosionSprites.RemoveAt((int)CS_0024_003C_003E8__locals20.exp);
			if ((object)CS_0024_003C_003E8__locals20.exp != null)
			{
				PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals20.exp.setVisible(visible: true);
				PhaserSprite exp3 = CS_0024_003C_003E8__locals20.exp;
				if ((object)CS_0024_003C_003E8__locals20.exp != null && (object)exp3._spriteAnimation != null)
				{
					exp3._spriteAnimation.SetAnimation("bang");
					if ((object)CS_0024_003C_003E8__locals20.exp != null)
					{
						Transform transform = CS_0024_003C_003E8__locals20.exp.transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							if ((object)CS_0024_003C_003E8__locals20.exp != null)
							{
								PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals20.exp.setDepth(3000);
								if ((object)CS_0024_003C_003E8__locals20.exp != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03f2;
		IL_03f2:
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_11e7: Invalid comparison between I4 and F4
		//IL_0087: Expected I4, but got O
		//IL_103b: Expected O, but got I4
		//IL_1044: Expected O, but got I4
		//IL_1166: Invalid comparison between I4 and F4
		//IL_0d47: Expected O, but got I4
		//IL_0d50: Expected O, but got I4
		//IL_0147: Invalid comparison between I4 and F4
		//IL_1756: Unknown result type (might be due to invalid IL or missing references)
		//IL_175b: Expected O, but got Unknown
		//IL_176e: Expected O, but got F4
		//IL_0192: Expected F4, but got I4
		//IL_0ec2: Invalid comparison between I4 and F4
		//IL_0ed3: Expected O, but got I4
		//IL_0edc: Expected O, but got I4
		//IL_1552: Unknown result type (might be due to invalid IL or missing references)
		//IL_1557: Expected O, but got Unknown
		//IL_1583: Expected O, but got F4
		//IL_158b: Expected O, but got F4
		//IL_1594: Expected O, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01f4: Invalid comparison between F4 and O
		//IL_1289: Expected I4, but got O
		//IL_0228: Invalid comparison between F4 and I4
		//IL_02bf: Expected O, but got F4
		//IL_1662: Expected O, but got F4
		//IL_16e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e5: Expected I4, but got Unknown
		//IL_170d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1712: Expected O, but got Unknown
		//IL_172f: Expected O, but got I4
		//IL_0423: Expected I4, but got I8
		//IL_14f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fd: Expected I4, but got Unknown
		//IL_1525: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Expected O, but got Unknown
		//IL_0ea2: Expected O, but got I4
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected F4, but got Unknown
		//IL_0a79: Expected O, but got I4
		//IL_1317: Invalid comparison between I4 and F4
		//IL_0b43: Expected O, but got I4
		//IL_0bc9: Invalid comparison between F4 and I4
		//IL_0bf2: Expected O, but got I4
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Expected F4, but got Unknown
		//IL_0c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Expected F4, but got Unknown
		//IL_0728: Expected O, but got F4
		//IL_075e: Expected I, but got O
		//IL_07ad: Expected O, but got I4
		//IL_07fd: Expected F4, but got I
		//IL_07fd: Expected F4, but got I4
		//IL_07fd: Expected F4, but got O
		//IL_07fd: Expected O, but got I4
		//IL_10c5->IL11a4: Incompatible stack heights: 1 vs 0
		//IL_10eb->IL11a4: Incompatible stack heights: 1 vs 0
		//IL_111e->IL11a4: Incompatible stack heights: 1 vs 0
		//IL_0df5->IL11a4: Incompatible stack heights: 1 vs 0
		//IL_0e1b->IL11a4: Incompatible stack heights: 1 vs 0
		//IL_0e4e->IL11a4: Incompatible stack heights: 1 vs 0
		//IL_1654->IL11a4: Incompatible stack heights: 2 vs 0
		//IL_0e75->IL11a4: Incompatible stack heights: 2 vs 0
		//IL_1748->IL1793: Incompatible stack heights: 5 vs 0
		//IL_1544->IL11a4: Incompatible stack heights: 5 vs 0
		//IL_115b->IL11a4: Incompatible stack heights: 5 vs 0
		//IL_0eb7->IL0d5e: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = obj2 - 24;
		float time = PauseSystem.Time;
		float num = time * 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num2 = num + 1.5f;
		if (0f > num2 || num2 > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num18;
		bool flag3 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num30 = default(int);
		TimerType timerType = default(TimerType);
		float num15;
		if ((object)_doorSpace != null)
		{
			object obj4 = default(object);
			object obj3 = obj4 << 8;
			object obj5 = obj3 | obj4;
			object obj6 = obj5 << 8;
			uint num3 = (uint)(obj6 | obj4);
			PhaserSprite phaserSprite = _doorSpace.setTint(num3);
			if (_phase == FightPhase.Finished)
			{
				return;
			}
			float num12 = default(float);
			Vector3 ret;
			Vector3 ret2;
			if (_phase != FightPhase.HeadFalling)
			{
				if (_phase == FightPhase.ChoppingHead)
				{
					return;
				}
				if (_phase != FightPhase.Exploding)
				{
					base.OnUpdate();
					float num4 = _doorOpenAmount - 0.8f;
					float num5 = num4 * 10f;
					if (!(0f > num5))
					{
						if (num5 > 1f)
						{
							num5 = 1f;
						}
					}
					else
					{
						num5 = 0f;
					}
					CheckRenderer();
					if ((object)((ArcadeSprite)this)._spriteRenderer != null)
					{
						Color color = ((ArcadeSprite)this)._spriteRenderer.color;
						float deltaTime = PauseSystem.DeltaTime;
						float num6 = deltaTime + deltaTime;
						float num7 = num5 - color.r;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj7 = num7 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
						{
							float num8 = num5 - color.r;
							if (num8 < 0f)
							{
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
						object obj8 = (object)color << 8;
						object obj9 = obj8 | (object)color;
						object obj10 = obj9 << 8;
						uint tint = (uint)(obj10 | (object)color);
						ArcadeSprite arcadeSprite = setTint(tint);
						if ((object)_body != null)
						{
							PhaserSprite phaserSprite2 = _body.setTint(tint);
							float time2 = PauseSystem.Time;
							float num9 = time2 * 12f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
							object obj11 = default(object);
							float num10 = (float)obj11 * (float)Math.PI;
							float num11 = num10 * 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							base.position = (float2)num12;
							float2 float5 = base.position;
							float num13 = _scale * 0.5f;
							float num14 = num13 * 0.125f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+24]");
							num15 = 0f + num14;
							if ((object)_body != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								float2 eyePos = GetEyePos(left: true);
								if ((object)_leftEye != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									float2 eyePos2 = GetEyePos(left: false);
									if ((object)_rightEye != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
										CheckRenderer();
										if ((object)((ArcadeSprite)this)._spriteRenderer != null)
										{
											bool flag = !(0.99f > ((ArcadeSprite)this)._spriteRenderer.color.r);
											int num16 = 1000;
											if (!flag)
											{
												num16 = -1640;
											}
											ArcadeSprite arcadeSprite2 = setDepth(num16);
											if (_phase != FightPhase.ShakingHeadPreLasers && _phase != FightPhase.ShakingHeadPreFire && _phase != FightPhase.ShakesSheadPostFire)
											{
												if (_phase == FightPhase.FireBreathRotation)
												{
													float deltaTime2 = PauseSystem.DeltaTime;
													float num17 = deltaTime2 * 60f;
													float firebreathRotationDegrees = _firebreathRotationDegrees - num17;
													_firebreathRotationDegrees = firebreathRotationDegrees;
													float deltaTime3 = PauseSystem.DeltaTime;
													float firebreathProjectileCooldown = _firebreathProjectileCooldown - deltaTime3;
													float firebreathRotationDegrees2 = _firebreathRotationDegrees;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
													num18 = firebreathRotationDegrees2 ^ 0;
													_firebreathProjectileCooldown = firebreathProjectileCooldown;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
													bool flag2;
													if (num18 > 45f && 135f > num18)
													{
														Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadTilted", "firstBloodEnemies");
														ArcadeSprite arcadeSprite3 = setFrame(sprite);
														flag2 = true;
													}
													else
													{
														string spriteName = ((!(num18 > 225f) || !(315f > num18)) ? "BigFuzzHeadOpen" : "BigFuzzHeadTilted");
														Sprite sprite2 = SpriteManager.GetSprite(spriteName, "firstBloodEnemies");
														ArcadeSprite arcadeSprite4 = setFrame(sprite2);
														flag2 = false;
													}
													base.SetFlipX(flag2);
													if (!(0f > _firebreathProjectileCooldown))
													{
														goto IL_080e;
													}
													_firebreathProjectileCooldown = 0.032f;
													GameManager core = GM.Core;
													if ((object)GM.Core != null)
													{
														float2 mouthPos = GetMouthPos();
														if ((object)core._stage != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
															ArcadeSprite arcadeSprite5 = default(ArcadeSprite);
															if ((object)arcadeSprite5 != null && ((UnityEngine.Object)arcadeSprite5).m_CachedPtr != (IntPtr)0)
															{
																float num19 = _firebreathRotationDegrees - 90f;
																float num20 = num19 * ((float)Math.PI / 180f);
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3522 @ rax_v217 (ArcadeSprite)+1A4]");
																float num21 = 0f * num20;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3522 @ rax_v217 (ArcadeSprite)+1A4]");
																float num22 = 0f * num20;
																float num23 = num21 * 0.01f;
																float num24 = num22 * 0.01f;
																BaseBody baseBody = arcadeSprite5.body;
																if (arcadeSprite5.body == null)
																{
																	goto IL_11a4;
																}
																baseBody._velocity = (float2)num24;
																float num25 = _firebreathRotationDegrees - 90f;
																arcadeSprite5.angle = num25;
																nint num26 = (nint)arcadeSprite5;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3658 @ rax_v228 (Il2CppClass<ArcadeSprite>)+3B8] (should have been resolved before IL gen)");
																float num27 = arcadeSprite5.scale;
																float num28 = _scale * 0.5f;
																float xScale = num28 * num27;
																ArcadeSprite arcadeSprite6 = arcadeSprite5.setScale(xScale, (float?)(object)0);
																_ = 0;
																_ = 1056964608;
																_ = 1;
																bool num29 = flag3;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
																PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FlameShot, 100f, 10, 0f, (float?)(object)num29, (float)monoBehaviour, num30, (byte)timerType != 0);
																flag3 = flag3;
															}
															goto IL_080e;
														}
													}
													goto IL_11a4;
												}
											}
											else
											{
												float time3 = PauseSystem.Time;
												float num31 = time3 * 8f;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
												string spriteName2 = "BigFuzzHeadOpen";
												Sprite sprite3 = SpriteManager.GetSprite(spriteName2, "firstBloodEnemies");
												ArcadeSprite arcadeSprite7 = setFrame(sprite3);
												bool flag4 = false;
												base.SetFlipX(flag4);
											}
											goto IL_12e3;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					float deltaTime4 = PauseSystem.DeltaTime;
					List<PhaserSprite> explosionSprites = _explosionSprites;
					float explosionTimer = _explosionTimer - deltaTime4;
					_explosionTimer = explosionTimer;
					bool flag5 = _explosionSprites == null;
					object obj12 = 0;
					object obj13 = 0;
					if (!flag5)
					{
						while (true)
						{
							if ((nint)obj13 < explosionSprites._size)
							{
								List<PhaserSprite> explosionSprites2 = _explosionSprites;
								if (_explosionSprites == null)
								{
									break;
								}
								bool flag6 = (nint)obj12 >= explosionSprites2._size;
								PhaserSprite[] items = explosionSprites2._items;
								if (explosionSprites2._items == null || (object)items[obj12] == null)
								{
									break;
								}
								Transform transform = items[obj12].transform;
								if ((object)transform == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v126 (UnityEngine.Transform)+10]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v126 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out ret);
								float deltaTime5 = PauseSystem.DeltaTime;
								Transform transform2 = items[obj12].transform;
								Transform transform3 = items[obj12].transform;
								if ((object)transform3 == null)
								{
									break;
								}
								bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret2);
								bool flag9 = (object)transform2 == null;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2442 @ rax_v132 (UnityEngine.Transform)+10]");
								bool flag10 = (nint)0 == 0;
								num3 = (uint)(obj - 128);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2442 @ rax_v132 (UnityEngine.Transform)+10]");
								Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)num3);
								explosionSprites = _explosionSprites;
								obj12++;
								if (_explosionSprites == null)
								{
									break;
								}
								object obj14 = 0;
								deltaTime4 = num12;
								obj13 = obj12;
								continue;
							}
							bool flag11 = !(0f > _explosionTimer);
							float2 float6 = (float2)num3;
							object obj15 = 0;
							if (!flag11)
							{
								_explosionTimer = 0.016f;
								float2 float7 = base.position;
								_ = 0;
								object obj16 = obj + 32;
								UnityEngine.Random.GetRandomUnitCircle(out *(Vector2*)obj16);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+24]");
								float num32 = 0f * _scale;
								AddExplosionEffect((float2)num12);
								float6 = (float2)num12;
								obj15 = 0;
							}
							float time4 = PauseSystem.Time;
							float num33 = time4 * 16f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
							string spriteName3 = "BigFuzzHeadOpen";
							Sprite sprite4 = SpriteManager.GetSprite(spriteName3, "firstBloodEnemies");
							ArcadeSprite arcadeSprite8 = setFrame(sprite4);
							bool flag12 = false;
							base.SetFlipX(flag12);
							return;
						}
					}
				}
			}
			else
			{
				float deltaTime6 = PauseSystem.DeltaTime;
				List<PhaserSprite> explosionSprites3 = _explosionSprites;
				float explosionTimer2 = _explosionTimer - deltaTime6;
				_explosionTimer = explosionTimer2;
				bool flag13 = _explosionSprites == null;
				object obj17 = 0;
				object obj18 = 0;
				if (!flag13)
				{
					bool flag19;
					do
					{
						if ((nint)obj18 < explosionSprites3._size)
						{
							List<PhaserSprite> explosionSprites4 = _explosionSprites;
							if (_explosionSprites == null)
							{
								break;
							}
							bool flag14 = (nint)obj17 >= explosionSprites4._size;
							PhaserSprite[] items2 = explosionSprites4._items;
							if (explosionSprites4._items == null || (object)items2[obj17] == null)
							{
								break;
							}
							Transform transform4 = items2[obj17].transform;
							if ((object)transform4 == null)
							{
								break;
							}
							bool flag15 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
							if (!PauseSystem._paused)
							{
								object obj19 = Time.deltaTime;
							}
							Transform transform5 = items2[obj17].transform;
							Transform transform6 = items2[obj17].transform;
							if ((object)transform6 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rax_v77 (UnityEngine.Transform)+10]");
							bool flag16 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rax_v77 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out ret2);
							bool flag17 = (object)transform5 == null;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rax_v76 (UnityEngine.Transform)+10]");
							bool flag18 = (nint)0 == 0;
							num3 = (uint)(obj - 128);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rax_v76 (UnityEngine.Transform)+10]");
							Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)num3);
							explosionSprites3 = _explosionSprites;
							obj17++;
							flag19 = _explosionSprites != null;
							object obj14 = 0;
							deltaTime6 = num12;
							obj18 = obj17;
							continue;
						}
						if (0f > _explosionTimer)
						{
							_explosionTimer = 0.016f;
							float2 float8 = base.position;
							_ = 0;
							object obj20 = obj + 32;
							UnityEngine.Random.GetRandomUnitCircle(out *(Vector2*)obj20);
							AddExplosionEffect((float2)num12);
						}
						return;
					}
					while (flag19);
				}
			}
		}
		goto IL_11a4;
		IL_11a4:
		throw new NullReferenceException();
		IL_12e3:
		if (_phase != FightPhase.GunnaFireLaser)
		{
			if ((object)_laserChargingLeft != null)
			{
				PhaserSprite phaserSprite3 = _laserChargingLeft.setVisible(visible: false);
				if ((object)_laserChargingRight != null)
				{
					PhaserSprite phaserSprite4 = _laserChargingRight.setVisible(visible: false);
					return;
				}
			}
		}
		else if ((object)_laserChargingLeft != null)
		{
			PhaserSprite phaserSprite5 = _laserChargingLeft.setVisible(visible: true);
			if ((object)phaserSprite5 != null)
			{
				float num34 = _scale * 0.5f;
				float xScale2 = num34 * 0.75f;
				PhaserSprite phaserSprite6 = phaserSprite5.setScale(xScale2, (float?)(object)0);
				float2 eyePos3 = GetEyePos(left: true);
				if ((object)phaserSprite6 != null)
				{
					PhaserSprite phaserSprite7 = phaserSprite6.setPosition(eyePos3);
					if ((object)_laserChargingRight != null)
					{
						PhaserSprite phaserSprite8 = _laserChargingRight.setVisible(visible: true);
						if ((object)phaserSprite8 != null)
						{
							float num35 = _scale * 0.5f;
							float xScale3 = num35 * 0.75f;
							PhaserSprite phaserSprite9 = phaserSprite8.setScale(xScale3, (float?)(object)0);
							float2 eyePos4 = GetEyePos(left: false);
							if ((object)phaserSprite9 != null)
							{
								PhaserSprite phaserSprite10 = phaserSprite9.setPosition(eyePos4);
								float time5 = PauseSystem.Time;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
								bool flag20 = time5 < 0.05f;
								float num36 = time5 - 0.05f;
								bool flag21 = num36 == 0f;
								bool flag22 = !flag20;
								bool flag23 = !flag21;
								object obj21 = flag23 & flag22;
								if ((object)_laserChargingLeft != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb edx,edx\"");
									float num37 = eyePos4 & 0x2D;
									_laserChargingLeft.angle = num37;
									if ((object)_laserChargingRight != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb edx,edx\"");
										float num38 = num37 & 0x2D;
										_laserChargingRight.angle = num38;
										bool flag24 = obj21 != null;
										uint tint2 = 16755200u;
										if (!flag24)
										{
											tint2 = 11184895u;
										}
										if ((object)_laserChargingLeft != null)
										{
											PhaserSprite phaserSprite11 = _laserChargingLeft.setTint(tint2);
											if ((object)_laserChargingRight != null)
											{
												PhaserSprite phaserSprite12 = _laserChargingRight.setTint(tint2);
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
		goto IL_11a4;
		IL_080e:
		bool flag25 = !(-720f > _firebreathRotationDegrees);
		num15 = num18;
		if (!flag25)
		{
			_phase = FightPhase.ShakesSheadPostFire;
			Action onComplete = delegate
			{
				Sprite sprite5 = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
				float2 originalSize = default(float2);
				ArcadeSprite arcadeSprite9 = setFrameIncludingOriginalSize(sprite5, originalSize);
				CloseDoors();
			};
			VampireSurvivors.Framework.TimerSystem.Timer postFireHeadShakeTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, flag3, monoBehaviour, num30, timerType, isOnlineTimer: false, canPause: false);
			_postFireHeadShakeTimer = postFireHeadShakeTimer;
			num15 = num18;
		}
		goto IL_12e3;
	}

	private void InitFireball(EnemyFBBulletFireball fireball, Vector2 velocity)
	{
		//IL_00ad: Expected O, but got I4
		//IL_00e4: Expected F4, but got I4
		BaseBody baseBody = fireball.body;
		baseBody._velocity = velocity;
		fireball._fixedVelocity = velocity;
		float num = _firebreathRotationDegrees - 90f;
		fireball.angle = num;
		fireball.SetFlipX(flip: false);
		float num2 = fireball.scale;
		float num3 = _scale * 0.5f;
		float xScale = num3 * num2;
		ArcadeSprite arcadeSprite = fireball.setScale(xScale, (float?)(object)0);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FlameShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private void SetDoorOpenAmount(float amount01)
	{
		//IL_002c: Invalid comparison between I4 and F4
		//IL_007f: Expected F4, but got I4
		float doorOpenAmount;
		if (!(0f > amount01))
		{
			bool flag = !(amount01 > 1f);
			doorOpenAmount = amount01;
			if (!flag)
			{
				doorOpenAmount = 1f;
			}
		}
		else
		{
			doorOpenAmount = 0f;
		}
		_doorOpenAmount = doorOpenAmount;
		float width = _leftDoor.Width;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float num = _scale * 0.5f;
		float num2 = num * 0.25f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyBigFuzz)+344]");
		float num4 = num3 + 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float width2 = _rightDoor.Width;
		float num5 = width2 * 0.25f;
		float num6 = _scale * 0.5f;
		float num7 = num5 / num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float num8 = _scale * 0.5f;
		float num9 = num8 * -0.4f;
		float num10 = num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyBigFuzz)+344]");
		float num11 = num10 + 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	private unsafe void StartSequence()
	{
		//IL_011b: Expected I4, but got I8
		//IL_0085: Expected O, but got Ref
		//IL_016e: Expected F4, but got O
		//IL_01af: Expected I, but got O
		//IL_01b3: Expected native int or pointer, but got F4
		//IL_01bc: Expected O, but got F4
		//IL_01cc: Expected O, but got I
		//IL_024c: Expected O, but got I4
		//IL_019c: Expected F4, but got I4
		//IL_06df: Expected F4, but got I4
		//IL_0208: Expected O, but got I
		//IL_025e: Expected F4, but got O
		//IL_023e: Expected O, but got I4
		//IL_06fb: Invalid comparison between F4 and I4
		//IL_0334: Expected O, but got I4
		//IL_04ef: Expected O, but got I4
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_065c: Expected O, but got I4
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Expected O, but got Unknown
		//IL_076e: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			stage._tilingTileset.SetTilemapCollisionsEnabled(isEnabled: false);
			object obj = default(object);
			stage._tilingTileset.TintAllLayers((Color)(&obj), 2000f);
		}
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		GM.Core.SetAllPlayersWeaponsActive(active: false);
		GameManager core2 = GM.Core;
		core2._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core3 = GM.Core;
		core3._003CCanPause_003Ek__BackingField = false;
		_doorOpenAmount = 0f;
		ArcadeSprite arcadeSprite = setTint(0u);
		ArcadeSprite arcadeSprite2 = setDepth(-10000);
		BaseBody baseBody = body;
		baseBody._enable = false;
		GameManager core4 = GM.Core;
		Stage stage2 = core4._stage;
		float num = (float)stage2._fancyBg;
		float num2;
		if ((object)stage2._fancyBg == null)
		{
			num2 = 0f;
			goto IL_06f2;
		}
		nint num3 = (nint)typeof(BackgroundFBHighway);
		Action action = (Action)((float*)(nint)num)->m_value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFBHighway>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ r9_v9 (System.Action)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundFBHighway>)+130]");
		object obj4;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ r9_v9 (System.Action)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rax_v100+FFFFFFF8+v808 @ rax_v96*8]");
			if (0 == (nint)typeof(BackgroundFBHighway))
			{
				obj4 = 1;
				goto IL_06c7;
			}
		}
		obj4 = 0;
		goto IL_06c7;
		IL_058e:
		GameManager core5 = GM.Core;
		List<Pickup> stagePickups = core5._stagePickups;
		int version = stagePickups._version + 1;
		stagePickups._version = version;
		stagePickups._size = 0;
		if (stagePickups._size > 0)
		{
			Array.Clear(stagePickups._items, 0, stagePickups._size);
		}
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 2000f);
		GameManager core6 = GM.Core;
		core6._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		GM.Core.TurnOnVacuum();
		GM.Core.TurnOnVacuumForGold();
		_phase = FightPhase.AnimatingIn;
		return;
		IL_06c7:
		bool flag = obj4 == null;
		num2 = 0f;
		if (!flag)
		{
			num2 = (float)stage2._fancyBg;
		}
		goto IL_06f2;
		IL_06f2:
		if (num2 != 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v5 (System.Single)+10]");
			if ((nint)0 != 0)
			{
				_ = 0;
			}
		}
		ProCamera2D instance2 = ProCamera2D.Instance;
		instance2.FollowVertical = true;
		GameManager core7 = GM.Core;
		core7._canRunTickerTimer = false;
		GameManager gameManager = _gameManager;
		Stage stage3 = gameManager._stage;
		List<EnemyController> spawnedEnemies = stage3._spawnedEnemies;
		bool flag2 = (nint)stage3._spawnedEnemies < 0;
		object obj5 = spawnedEnemies._size - 1;
		if (flag2)
		{
			goto IL_0461;
		}
		while (true)
		{
			GameManager gameManager2 = _gameManager;
			Stage stage4 = gameManager2._stage;
			List<EnemyController> spawnedEnemies2 = stage4._spawnedEnemies;
			if ((nint)obj5 >= spawnedEnemies2._size)
			{
				break;
			}
			EnemyController[] items = spawnedEnemies2._items;
			EnemyController enemyController = items[obj5];
			CoherenceSync coherenceSync = enemyController._coherenceSync;
			bool flag3 = (nint)enemyController._coherenceSync < 0;
			bool flag5;
			if ((object)enemyController._coherenceSync != null)
			{
				flag3 = (nint)((UnityEngine.Object)coherenceSync).m_CachedPtr < 0;
				if (((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
				{
					bool hasStateAuthority = enemyController._coherenceSync.HasStateAuthority;
					flag3 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
					bool flag4 = !hasStateAuthority;
					flag5 = flag3;
					if (flag4)
					{
						goto IL_0755;
					}
				}
			}
			enemyController.Disappear();
			flag5 = flag3;
			goto IL_0755;
			IL_0755:
			obj5--;
			object obj6 = !flag5;
			if (obj6 != null)
			{
				continue;
			}
			goto IL_0461;
		}
		goto IL_0714;
		IL_0461:
		GameManager core8 = GM.Core;
		Stage stage5 = core8._stage;
		if (stage5._spawnTimer != null)
		{
			stage5._spawnTimer.Cancel();
		}
		GameManager core9 = GM.Core;
		List<Pickup> stagePickups2 = core9._stagePickups;
		bool flag6 = (nint)core9._stagePickups < 0;
		object obj7 = stagePickups2._size - 1;
		if (flag6)
		{
			goto IL_058e;
		}
		while (true)
		{
			GameManager core10 = GM.Core;
			List<Pickup> stagePickups3 = core10._stagePickups;
			if ((nint)obj7 >= stagePickups3._size)
			{
				break;
			}
			Pickup[] items2 = stagePickups3._items;
			items2[obj7].Despawn();
			obj7--;
			if ((nint)items2[obj7] >= 0)
			{
				continue;
			}
			goto IL_058e;
		}
		goto IL_0714;
		IL_0714:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void StartClawingIn()
	{
		//IL_01da: Expected F4, but got I4
		//IL_01da: Expected F4, but got I4
		//IL_01da: Expected F4, but got O
		//IL_01da: Expected O, but got I4
		PhaserSprite phaserSprite = _body.setVisible(visible: true);
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		PhaserSprite phaserSprite2 = _leftEye.setVisible(visible: true);
		PhaserSprite phaserSprite3 = _rightEye.setVisible(visible: true);
		PhaserSprite phaserSprite4 = _doorSpace.setVisible(visible: true);
		_usePolygonEdges = true;
		_phase = FightPhase.ClawingIn;
		Action onComplete = delegate
		{
			//IL_004c: Expected F4, but got I4
			PhaserSprite phaserSprite5 = _rightHand.setVisible(visible: true);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzClaws, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		};
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num = default(int);
		TimerType timerType = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(2.5f, onComplete, null, isLooped: false, flag, monoBehaviour, num, timerType, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			//IL_004c: Expected F4, but got I4
			PhaserSprite phaserSprite5 = _leftHand.setVisible(visible: true);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzClaws, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(4f, onComplete2, null, isLooped: false, flag, monoBehaviour, num, timerType, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			//IL_0033: Expected F4, but got I4
			OpenDoors(firstTime: true);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzHeadChop, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer3 = Timers.Register(5.5000005f, onComplete3, null, isLooped: false, flag, monoBehaviour, num, timerType, isOnlineTimer: false, canPause: false);
		Action onComplete4 = _003C_003Ec._003C_003E9__53_3;
		if (_003C_003Ec._003C_003E9__53_3 == null)
		{
			onComplete4 = (_003C_003Ec._003C_003E9__53_3 = delegate
			{
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_FB_K13_Rave;
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
				GM.Core.SetupMusicBanger();
			});
		}
		VampireSurvivors.Framework.TimerSystem.Timer timer4 = Timers.Register(5.5000005f, onComplete4, null, isLooped: false, flag, monoBehaviour, num, timerType, isOnlineTimer: false, canPause: false);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 1000f, 10, 0f, (float?)(object)flag, (float)monoBehaviour, num, (byte)timerType != 0, 1f);
		ScreenShake(20);
	}

	private unsafe void OpenDoors(bool firstTime)
	{
		//IL_006a: Expected F4, but got I4
		//IL_0077: Expected O, but got I4
		//IL_00fb: Expected I, but got O
		//IL_0111: Expected O, but got I
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0188: Expected I, but got O
		//IL_0351: Expected I, but got I8
		//IL_038e: Expected I4, but got F4
		//IL_038e: Expected O, but got F4
		//IL_038e: Expected I4, but got O
		//IL_0171: Expected I, but got I8
		//IL_01e8: Expected I, but got O
		//IL_01fe: Expected O, but got I
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0275: Expected I, but got O
		//IL_03f0: Expected I, but got I8
		//IL_041e: Expected I4, but got F4
		//IL_041e: Expected O, but got F4
		//IL_041e: Expected I4, but got O
		//IL_0294: Expected I, but got O
		//IL_02aa: Expected O, but got I
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_0326: Expected I, but got O
		//IL_025e: Expected I, but got I8
		//IL_047a: Expected I, but got I8
		//IL_04a8: Expected I4, but got F4
		//IL_04a8: Expected O, but got F4
		//IL_04a8: Expected I4, but got O
		//IL_02f9: Expected I, but got I8
		_003C_003Ec__DisplayClass54_0 obj = new _003C_003Ec__DisplayClass54_0();
		obj._003C_003E4__this = this;
		obj.firstTime = firstTime;
		_phase = FightPhase.OpeningDoors;
		ScreenShake(55);
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzDoors, 2000f, 2, 0f, num, num2, num3, flag, 1f);
		object obj2 = 24;
		int num4 = 0;
		int num5 = 0;
		do
		{
			_003C_003Ec__DisplayClass54_1 obj3 = new _003C_003Ec__DisplayClass54_1();
			obj3.CS_0024_003C_003E8__locals1 = obj;
			obj3.index = num4;
			Action action = null;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass54_1._003COpenDoors_003Eb__2);
			((Delegate)action).m_target = obj3;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num7;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num7 = unchecked((nint)6447293664L);
					goto IL_033a;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num7 = ((Delegate)action).method_ptr;
			goto IL_033a;
			IL_033a:
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)num5 * 0.001f;
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			num4++;
			num5 += 280;
		}
		while (num5 < 2240);
		Action action2 = null;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ r10_v4 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass54_0._003COpenDoors_003Eb__0);
		((Delegate)action2).m_target = obj;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num9;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num9 = unchecked((nint)6447293664L);
				goto IL_03d9;
			}
		}
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		num9 = ((Delegate)action2).method_ptr;
		goto IL_03d9;
		IL_03d9:
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(2.24f, action2, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		Action action3 = null;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r10_v5 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(_003C_003Ec__DisplayClass54_0._003COpenDoors_003Eb__1);
		((Delegate)action3).m_target = obj;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r10_v5 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		nint num11;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r10_v5 (Il2CppMethodInfo)+52]");
			bool flag2 = (nint)0 == 0;
			num11 = unchecked((nint)6447293664L);
			if (flag2)
			{
				goto IL_0463;
			}
		}
		num11 = ((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_0463;
		IL_0463:
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		VampireSurvivors.Framework.TimerSystem.Timer laserHeadShakeTimer = Timers.Register(3.2400002f, action3, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		_laserHeadShakeTimer = laserHeadShakeTimer;
	}

	private float2 GetEyePos(bool left)
	{
		float2 float5 = base.position;
		float2 result = default(float2);
		return result;
	}

	private float2 GetMouthPos()
	{
		float2 float5 = base.position;
		float2 result = default(float2);
		return result;
	}

	private void FireLasers()
	{
		GameManager core = GM.Core;
		float2 eyePos = GetEyePos(left: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		GameManager core2 = GM.Core;
		float2 eyePos2 = GetEyePos(left: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
	}

	private unsafe void StartPreFireShaking()
	{
		_phase = FightPhase.ShakingHeadPreFire;
		Action onComplete = delegate
		{
			//IL_0008: Expected O, but got Ref
			//IL_00b9: Expected O, but got I
			//IL_02e3: Expected O, but got Ref
			//IL_02f8: Expected native int or pointer, but got O
			//IL_0312: Expected O, but got I
			//IL_0332: Expected O, but got Ref
			//IL_034c: Expected native int or pointer, but got O
			//IL_0366: Expected O, but got I
			//IL_0386: Expected O, but got Ref
			//IL_03a0: Expected native int or pointer, but got O
			//IL_03ba: Expected O, but got I
			//IL_03da: Expected O, but got Ref
			//IL_03f4: Expected native int or pointer, but got O
			//IL_07af: Expected O, but got I4
			//IL_0419: Expected O, but got Ref
			//IL_0440: Expected O, but got I
			//IL_045a: Expected native int or pointer, but got O
			//IL_07e9: Expected O, but got I
			//IL_0492: Expected O, but got Ref
			//IL_04b9: Expected O, but got I
			//IL_04d3: Expected native int or pointer, but got O
			//IL_0823: Expected O, but got I
			//IL_05cc: Expected F4, but got I
			//IL_08ae: Expected I, but got O
			//IL_08f0: Expected I4, but got F4
			//IL_08f0: Expected O, but got F4
			//IL_08f0: Expected I4, but got O
			//IL_0633: Expected I4, but got F4
			//IL_0633: Expected O, but got F4
			//IL_0633: Expected I4, but got O
			//IL_067e: Expected I4, but got F4
			//IL_067e: Expected O, but got F4
			//IL_067e: Expected I4, but got O
			//IL_06ce: Expected I4, but got F4
			//IL_06ce: Expected O, but got F4
			//IL_06ce: Expected I4, but got O
			//IL_0719: Expected I4, but got F4
			//IL_0719: Expected O, but got F4
			//IL_0719: Expected I4, but got O
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_003C_003Ec__DisplayClass58_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass58_0();
			if (CS_0024_003C_003E8__locals23 != null)
			{
				CS_0024_003C_003E8__locals23._003C_003E4__this = this;
				_phase = FightPhase.FireBreathCharging;
				Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadOpen", "firstBloodEnemies");
				ArcadeSprite arcadeSprite = setFrame(sprite);
				GameObject gameObject = base.gameObject;
				_ = 0;
				nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
				ParticleEmitterManager particleEmitterManager;
				if (gameObject.TryGetComponent<ParticleEmitterManager>(out *(ParticleEmitterManager*)num))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+138]");
					particleEmitterManager = (ParticleEmitterManager)0;
				}
				else
				{
					ParticleEmitterManager particleEmitterManager2 = gameObject.AddComponent<ParticleEmitterManager>();
					particleEmitterManager = particleEmitterManager2;
					num = 0;
				}
				float2 float5 = base.position;
				Circle circle = new Circle();
				circle._x = 0f;
				circle._radius = 8f;
				EmitZone emitZone = new EmitZone();
				emitZone._type = EmitZoneType.Random;
				emitZone._source = circle;
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
				List<string> list = new List<string>();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"flame001");
						}
						else
						{
							int num2 = list._size + 1;
							list._size = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version2 = list._version + 1;
						list._version = version2;
						string[] items2 = list._items;
						if (list._items != null)
						{
							if (list._size >= items2.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"flame002");
							}
							else
							{
								int num3 = list._size + 1;
								list._size = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(100f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 200f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
								_ = 0;
								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
								_ = 0;
								_ = 1;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 2f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
								_ = 0;
								_ = 1120403456;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
								particleSystemConfig._frequency = (float?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
								_ = 0;
								particleSystemConfig._emitZone = emitZone;
								particleSystemConfig._on = true;
								ParticleSystem pfxEmitter = particleEmitterManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
								CS_0024_003C_003E8__locals23.pfxEmitter = pfxEmitter;
								Transform transform = CS_0024_003C_003E8__locals23.pfxEmitter.transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v62 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v62 (UnityEngine.Transform)+10]");
								Vector3 value = default(Vector3);
								Transform.set_position_Injected((IntPtr)0, ref value);
								RenderingExtensions.SetDepth(CS_0024_003C_003E8__locals23.pfxEmitter, 1100);
								RenderingExtensions.Start(CS_0024_003C_003E8__locals23.pfxEmitter);
								_ = 0;
								_ = 1073741824;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
								float? num4 = default(float?);
								float num5 = default(float);
								float num6 = default(float);
								bool flag2 = default(bool);
								PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, num4, num5, num6, flag2);
								ParticleSystemConfig pfxEmitter2 = (ParticleSystemConfig)(object)CS_0024_003C_003E8__locals23.pfxEmitter;
								bool flag3 = (object)pfxEmitter2._x == null;
								ParticleSystem.Emit_Internal_Injected((IntPtr)pfxEmitter2._x, 10);
								Action onComplete2 = delegate
								{
									//IL_0033: Expected F4, but got I4
									float? volume = default(float?);
									float rate = default(float);
									float detune = default(float);
									bool loop = default(bool);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
									object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								};
								VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.4f, onComplete2, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								Action onComplete3 = delegate
								{
									//IL_0033: Expected F4, but got I4
									float? volume = default(float?);
									float rate = default(float);
									float detune = default(float);
									bool loop = default(bool);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
									object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								};
								VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(0.8f, onComplete3, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								Action onComplete4 = delegate
								{
									//IL_0033: Expected F4, but got I4
									float? volume = default(float?);
									float rate = default(float);
									float detune = default(float);
									bool loop = default(bool);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
									object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								};
								VampireSurvivors.Framework.TimerSystem.Timer timer3 = Timers.Register(1.2f, onComplete4, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								Action onComplete5 = delegate
								{
									//IL_0033: Expected F4, but got I4
									float? volume = default(float?);
									float rate = default(float);
									float detune = default(float);
									bool loop = default(bool);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
									object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								};
								VampireSurvivors.Framework.TimerSystem.Timer timer4 = Timers.Register(1.6f, onComplete5, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								Action onComplete6 = delegate
								{
									//IL_0033: Expected F4, but got I4
									//IL_0065: Expected F4, but got I4
									//IL_015a: Expected I4, but got F4
									//IL_015a: Expected O, but got F4
									//IL_015a: Expected I4, but got O
									float? num7 = default(float?);
									float num8 = default(float);
									float num9 = default(float);
									bool flag4 = default(bool);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Fireloop, 100f, 10, 0f, num7, num8, num9, flag4, 1f);
									PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 100f, 10, 0f, num7, num8, num9, flag4, 1f);
									ParticleSystem pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
									if ((object)CS_0024_003C_003E8__locals23.pfxEmitter != null && ((UnityEngine.Object)pfxEmitter3).m_CachedPtr != (IntPtr)0)
									{
										CS_0024_003C_003E8__locals23.pfxEmitter.Emit(100);
										RenderingExtensions.StopEmitting(CS_0024_003C_003E8__locals23.pfxEmitter);
									}
									Action onComplete7 = CS_0024_003C_003E8__locals23._003C_003E9__6;
									if (CS_0024_003C_003E8__locals23._003C_003E9__6 == null)
									{
										onComplete7 = (CS_0024_003C_003E8__locals23._003C_003E9__6 = delegate
										{
											ParticleSystem pfxEmitter4 = CS_0024_003C_003E8__locals23.pfxEmitter;
											if ((object)CS_0024_003C_003E8__locals23.pfxEmitter != null && ((UnityEngine.Object)pfxEmitter4).m_CachedPtr != (IntPtr)0)
											{
												GameObject obj3 = CS_0024_003C_003E8__locals23.pfxEmitter.gameObject;
												UnityEngine.Object.Destroy(obj3, 0f);
											}
										});
									}
									VampireSurvivors.Framework.TimerSystem.Timer timer5 = Timers.Register(1f, onComplete7, null, isLooped: false, (byte)(int)num7 != 0, (MonoBehaviour)num8, (int)num9, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
									EnemyBigFuzz enemyBigFuzz = CS_0024_003C_003E8__locals23._003C_003E4__this;
									enemyBigFuzz._phase = FightPhase.FireBreathRotation;
									EnemyBigFuzz enemyBigFuzz2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
									enemyBigFuzz2._firebreathRotationDegrees = 0f;
								};
								VampireSurvivors.Framework.TimerSystem.Timer fireRotationTimer = Timers.Register(2f, onComplete6, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								_fireRotationTimer = fireRotationTimer;
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer fireChargeTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_fireChargeTimer = fireChargeTimer;
	}

	private unsafe void CloseDoors()
	{
		//IL_02b9: Expected O, but got I4
		//IL_0115: Expected I, but got O
		//IL_012b: Expected O, but got I
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_01a2: Expected I, but got O
		//IL_02e7: Expected I, but got I8
		//IL_018b: Expected I, but got I8
		//IL_01ff: Expected I, but got O
		//IL_0215: Expected O, but got I
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_0291: Expected I, but got O
		//IL_0386: Expected I, but got I8
		//IL_0264: Expected I, but got I8
		BaseBody baseBody = body;
		_phase = FightPhase.ClosingDoors;
		baseBody._enable = false;
		PhaserSprite phaserSprite = _leftEye.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _rightEye.setVisible(visible: true);
		SpawnMines();
		if (++_cycleCount > 2)
		{
			float hp = _hp * 0.9f;
			_hp = hp;
		}
		object obj = 24;
		bool flag = false;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass59_0 obj2 = new _003C_003Ec__DisplayClass59_0();
			obj2._003C_003E4__this = this;
			obj2.index = (flag2 ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass59_0._003CCloseDoors_003Eb__1);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_02d0;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_02d0;
			IL_02d0:
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)(flag ? 1 : 0) * 0.001f;
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			flag = (byte)((flag ? 1u : 0u) + 100u) != 0;
		}
		while ((flag ? 1 : 0) < 800);
		Action action2 = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r10_v4 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(EnemyBigFuzz._003CCloseDoors_003Eb__59_0);
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		nint num4;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r10_v4 (Il2CppMethodInfo)+52]");
			bool flag3 = (nint)0 == 0;
			num4 = unchecked((nint)6447293664L);
			if (flag3)
			{
				goto IL_036f;
			}
		}
		num4 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_036f;
		IL_036f:
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(4f, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SpawnMines()
	{
		//IL_00dc: Expected O, but got I
		//IL_006f: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_0142: Expected O, but got I8
		//IL_022e: Expected O, but got I
		//IL_02ec: Expected O, but got I4
		//IL_0219: Expected O, but got I8
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v30 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v30 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v30 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		CharacterController characterController = Extensions.PickRnd(core._characters);
		float2 float5 = characterController.position;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		ArcadeSprite arcadeSprite = this;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			arcadeSprite = (ArcadeSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v439 @ rax_v16 (should have been resolved before IL gen)");
		GameManager core2 = GM.Core;
		Vector2 vector = default(Vector2);
		if (!core2._multiplayer.IsOnlineMultiplayer)
		{
			SpawnMinesAtTarget(vector, -(float)Math.PI / 4f);
			return;
		}
		Action<Vector2, float> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r10_v4 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		object obj5;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 2)
			{
				obj5 = 6447765328L;
				goto IL_02e3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v20 (System.Action`2<UnityEngine.Vector2, System.Single>)+10]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v20 (System.Action`2<UnityEngine.Vector2, System.Single>)+20]");
		_ = 0;
		goto IL_02e3;
		IL_02e3:
		object obj6 = 24;
		_ = 6447775312L;
		float param = default(float);
		bool flag4 = _coherenceSync.SendCommand(action, MessageTarget.All, vector, param);
	}

	public void SpawnMinesOnline(Vector2 target, float startAngleOffset)
	{
		SpawnMinesAtTarget(target, startAngleOffset);
	}

	private unsafe void SpawnMinesAtTarget(Vector2 toTarget, float startAngleOffset)
	{
		//IL_0100: Expected O, but got I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0190: Expected I, but got O
		//IL_01a6: Expected O, but got I
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_0244: Expected I, but got O
		//IL_04ae: Expected O, but got I4
		//IL_04c5: Expected I, but got I8
		//IL_0206: Expected I, but got I8
		//IL_00f2->IL03b2: Incompatible stack heights: 1 vs 0
		//IL_01f4->IL0225: Incompatible stack heights: 1 vs 2
		//IL_04db->IL0249: Incompatible stack heights: 2 vs 1
		//IL_020b->IL04a5: Incompatible stack heights: 1 vs 2
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
		float num = _scale * 0.5f;
		object obj = toTarget * toTarget;
		float num2 = num * ((float)Math.PI * 4f / 5f);
		object obj3 = default(object);
		object obj2 = obj3 * obj3;
		float num3 = num2 / 6f;
		float num4 = num2 * 0.5f;
		float num5 = (float)obj + (float)obj2;
		float num6 = (float)obj3 - num4;
		float num8 = default(float);
		float num7 = num6 - num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		float num9 = _scale * 0.5f;
		float num10 = num9 * 0.125f;
		float num11 = num10 + num5;
		bool flag = false;
		object obj4 = default(object);
		float2 location = default(float2);
		do
		{
			float num12 = (float)(flag ? 1 : 0) * num3;
			float num13 = num12 + num7;
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (body != null)
			{
				BaseBody baseBody = body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				arcadeTransform.position = ret;
			}
			double num14 = Math.Cos(num13);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
			double num15 = Math.Sin(num13);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm2,xmm0\"");
			num8 = 0f * num11;
			num4 = (float)obj4 + num8;
			SpawnMineToLocation(location, 3);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < 6);
		object obj5 = 500;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = _003C_003Ec._003C_003E9__62_1;
			if (_003C_003Ec._003C_003E9__62_1 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__62_1 = delegate
				{
					//IL_0033: Expected F4, but got I4
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzBomb, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
				});
			}
			float duration = (float)obj5 * 0.001f;
			VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			obj5 += 500;
		}
		while ((nint)obj5 <= 1500);
		Action onComplete2 = _003C_003Ec._003C_003E9__62_0;
		if (_003C_003Ec._003C_003E9__62_0 != null)
		{
			goto IL_0249;
		}
		Action action = null;
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ r10_v4 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec._003CSpawnMinesAtTarget_003Eb__62_0);
		((Delegate)action).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num17;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num17 = unchecked((nint)6447293664L);
				goto IL_04a5;
			}
		}
		else
		{
			bool flag3 = _003C_003Ec._003C_003E9 == null;
		}
		num17 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_04a5;
		IL_0249:
		VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_04a5:
		object obj8 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__62_0 = action;
		onComplete2 = action;
		goto IL_0249;
	}

	private unsafe void SpawnMineToLocation(float2 location, int countdownTimer)
	{
		//IL_014f: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_08c3: Expected O, but got I4
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected I4, but got Unknown
		//IL_0339: Expected O, but got I4
		//IL_034b: Expected O, but got I4
		//IL_04fc: Expected I, but got O
		//IL_03f9: Expected I, but got O
		//IL_040f: Expected O, but got I
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_0553: Expected I, but got O
		//IL_0486: Expected I, but got O
		//IL_08fc: Expected I, but got I8
		//IL_0954: Unknown result type (might be due to invalid IL or missing references)
		//IL_0959: Expected O, but got Unknown
		//IL_096a: Expected O, but got F4
		//IL_05bd: Expected O, but got I4
		//IL_05d9: Expected O, but got I4
		//IL_09a2: Expected I, but got O
		//IL_09b8: Expected O, but got I
		//IL_09c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c6: Expected O, but got Unknown
		//IL_046f: Expected I, but got I8
		//IL_0666: Expected I, but got O
		//IL_09fa: Expected I, but got I8
		//IL_064f: Expected I, but got I8
		//IL_074f: Expected I, but got O
		//IL_076d: Expected O, but got I4
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Expected O, but got Unknown
		//IL_0a19: Expected I, but got O
		//IL_0a2f: Expected O, but got I
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Expected O, but got Unknown
		//IL_081a: Expected I, but got O
		//IL_0a71: Expected I, but got I8
		//IL_0a7e: Expected I4, but got O
		//IL_07ed: Expected I, but got I8
		//IL_08e0->IL082d: Incompatible stack heights: 1 vs 0
		//IL_04cd->IL082d: Incompatible stack heights: 1 vs 0
		//IL_0387->IL082d: Incompatible stack heights: 1 vs 0
		//IL_0598->IL082d: Incompatible stack heights: 1 vs 0
		//IL_051f->IL051f: Incompatible stack heights: 2 vs 1
		//IL_0576->IL0576: Incompatible stack heights: 2 vs 1
		//IL_06c4->IL082d: Incompatible stack heights: 1 vs 0
		//IL_073d->IL082d: Incompatible stack heights: 1 vs 0
		//IL_071b->IL071b: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass63_0 obj = new _003C_003Ec__DisplayClass63_0();
		if (obj != null)
		{
			obj.countdownTimer = countdownTimer;
			obj._003C_003E4__this = this;
			float2 location2 = default(float2);
			obj.location = location2;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				float2 float5 = base.position;
				if ((object)core._stage != null)
				{
					GameObject gameObject = core._stage.gameObject;
					Vector2 vector = default(Vector2);
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "circle");
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite phaserSprite3 = phaserSprite2.setTint(16711680u);
							if ((object)phaserSprite3 != null)
							{
								float num = _scale * 0.5f;
								float xScale = num * 0.5f;
								PhaserSprite lavaSprite = phaserSprite3.setScale(xScale, (float?)(object)0);
								obj.lavaSprite = lavaSprite;
								if ((object)obj.lavaSprite != null)
								{
									float num2 = obj.lavaSprite.scale;
									float num3 = num2 * 128f;
									float circleRadius = num3 * 0.01f;
									obj.circleRadius = circleRadius;
									if ((object)obj.lavaSprite != null)
									{
										PhaserSprite phaserSprite4 = obj.lavaSprite.setVisible(visible: false);
										float2 float6 = base.position;
										GameObject gameObject2 = core._stage.gameObject;
										PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "firstBlood", "fb_BF_Bomb3");
										if ((object)phaserSprite5 != null)
										{
											PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(1f);
											if ((object)phaserSprite6 != null)
											{
												PhaserSprite mineSprite = phaserSprite6.setScale(_scale, (float?)(object)0);
												obj.mineSprite = mineSprite;
												EnemyBigFuzz lavaSprite2 = (EnemyBigFuzz)(object)obj.lavaSprite;
												if ((object)obj.lavaSprite != null)
												{
													EnemyBigFuzz enemyBigFuzz = (EnemyBigFuzz)(object)lavaSprite2.body;
													if (lavaSprite2.body != null)
													{
														bool flag = ((UnityEngine.Object)enemyBigFuzz).m_CachedPtr == (IntPtr)0;
														object obj2 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)enemyBigFuzz).m_CachedPtr);
														if ((object)obj.mineSprite != null)
														{
															int num4 = obj2 + 1;
															PhaserSprite phaserSprite7 = obj.mineSprite.setDepth(num4);
															object obj3 = 24;
															bool flag2 = false;
															object obj4 = 500;
															nint num5 = 1;
															Vector2 vector2 = vector;
															Action<float> action = null;
															object obj8 = default(object);
															object obj9 = default(object);
															bool useRealTime = default(bool);
															MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
															int repeat = default(int);
															TimerType type = default(TimerType);
															object obj12 = default(object);
															while (true)
															{
																Action action2;
																if (num5 <= obj.countdownTimer)
																{
																	_003C_003Ec__DisplayClass63_1 obj5 = new _003C_003Ec__DisplayClass63_1();
																	if (obj5 == null)
																	{
																		break;
																	}
																	obj5.CS_0024_003C_003E8__locals1 = obj;
																	((UnityEngine.Object)(object)obj5).m_CachedPtr = num5;
																	action2 = null;
																	nint num6 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ r10_v10 (Il2CppMethodInfo)+8]");
																	((Delegate)action2).method_ptr = (IntPtr)0;
																	((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass63_1._003CSpawnMineToLocation_003Eb__0);
																	((Delegate)action2).m_target = obj5;
																	((Delegate)action2).method_code = (IntPtr)action2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ r10_v10 (Il2CppMethodInfo)+4C]");
																	object obj6 = (nint)0 >> 4;
																	object obj7 = obj6 & 1;
																	nint num7;
																	if (obj7 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ r10_v10 (Il2CppMethodInfo)+52]");
																		if ((nint)0 == 0)
																		{
																			num7 = unchecked((nint)6447293664L);
																			goto IL_08e5;
																		}
																	}
																	((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
																	num7 = ((Delegate)action2).method_ptr;
																	goto IL_08e5;
																}
																TweenConfig tweenConfig = new TweenConfig();
																object[] array = new object[2];
																if (array == null)
																{
																	break;
																}
																if ((object)obj.lavaSprite != null)
																{
																	nint num8 = (nint)array;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	bool flag3 = obj8 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if ((object)obj.mineSprite != null)
																{
																	nint num9 = (nint)array;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	bool flag4 = obj9 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig == null)
																{
																	break;
																}
																tweenConfig.targets = array;
																tweenConfig.x = (float?)(object)1;
																tweenConfig.duration = 200f;
																tweenConfig.y = (float?)(object)1;
																TweenCallback tweenCallback = null;
																nint num10 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v8 (Il2CppMethodInfo)+8]");
																((Delegate)tweenCallback).method_ptr = (IntPtr)0;
																((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass63_0._003CSpawnMineToLocation_003Eb__1);
																((Delegate)tweenCallback).m_target = obj;
																((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v8 (Il2CppMethodInfo)+4C]");
																object obj10 = (nint)0 >> 4;
																object obj11 = obj10 & 1;
																nint num11;
																if (obj11 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r10_v8 (Il2CppMethodInfo)+52]");
																	if ((nint)0 == 0)
																	{
																		num11 = unchecked((nint)6447293664L);
																		goto IL_09e3;
																	}
																}
																((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
																num11 = ((Delegate)tweenCallback).method_ptr;
																goto IL_09e3;
																IL_0a5a:
																TweenCallback tweenCallback2;
																((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
																TweenConfig tweenConfig2;
																((PhaserGameObject)(object)tweenConfig2)._visible = (byte)(int)tweenCallback2 != 0;
																MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
																return;
																IL_08e5:
																((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
																float num12 = (float)obj4 * 0.001f;
																VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(num12, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																num5++;
																obj4 += 500;
																flag2 = false;
																vector2 = (Vector2)num12;
																action = null;
																continue;
																IL_09e3:
																((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
																tweenConfig.onComplete = tweenCallback;
																MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig);
																tweenConfig2 = new TweenConfig();
																object[] array2 = new object[1];
																if (array2 == null)
																{
																	break;
																}
																if ((object)obj.lavaSprite != null)
																{
																	void* value = ((IntPtr*)(&array2))->m_value;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	bool flag5 = obj12 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig2 == null)
																{
																	break;
																}
																((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
																_ = 1;
																object obj13 = obj.countdownTimer + 1;
																CancellationTokenSource cancellationTokenSource = (CancellationTokenSource)(obj13 * 500);
																((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = cancellationTokenSource;
																tweenCallback2 = null;
																nint num13 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v928 @ r10_v9 (Il2CppMethodInfo)+8]");
																((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
																((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass63_0._003CSpawnMineToLocation_003Eb__2);
																((Delegate)tweenCallback2).m_target = obj;
																((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v928 @ r10_v9 (Il2CppMethodInfo)+4C]");
																object obj14 = (nint)0 >> 4;
																object obj15 = obj14 & 1;
																nint num14;
																if (obj15 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v928 @ r10_v9 (Il2CppMethodInfo)+52]");
																	bool flag6 = (nint)0 == 0;
																	num14 = unchecked((nint)6447293664L);
																	if (flag6)
																	{
																		goto IL_0a5a;
																	}
																}
																num14 = ((Delegate)tweenCallback2).method_ptr;
																((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
																goto IL_0a5a;
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
		throw new NullReferenceException();
	}

	public void ScreenShake(int repeats = 6)
	{
		//IL_00b3: Expected I, but got O
		//IL_0132: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
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
		tweenConfig.duration = 40f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__64_0;
		if (_003C_003Ec._003C_003E9__64_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__64_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -5f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__64_1;
		if (_003C_003Ec._003C_003E9__64_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__64_1 = delegate
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
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void LateUpdate()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		if (_usePolygonEdges)
		{
			RunEdgeLogic();
		}
		ProCamera2D instance = ProCamera2D.Instance;
		float deltaTime = PauseSystem.DeltaTime;
		bool flag2 = (object)instance == null;
		instance.Move(deltaTime);
	}

	private unsafe void RunEdgeLogic()
	{
		//IL_105f: Expected I, but got O
		//IL_10d3: Expected I, but got O
		//IL_0076: Expected I, but got O
		//IL_020f: Expected I, but got O
		//IL_00d5: Expected I, but got O
		//IL_0116: Expected O, but got I
		//IL_0137: Expected I, but got O
		//IL_01ac: Expected O, but got I
		//IL_01dc: Expected I, but got O
		//IL_0275: Expected I, but got O
		//IL_0285: Expected O, but got I
		//IL_1092: Expected I, but got O
		//IL_02bc: Expected O, but got I
		//IL_0318: Expected O, but got I
		//IL_0359: Expected O, but got Ref
		//IL_0660: Expected F4, but got O
		//IL_067e: Expected O, but got I4
		//IL_0427: Expected I, but got O
		//IL_0cfe: Expected I, but got O
		//IL_069e: Expected I, but got O
		//IL_0d41: Expected I, but got O
		//IL_06bb: Expected F4, but got O
		//IL_06c4: Invalid comparison between F4 and O
		//IL_06d7: Expected I, but got O
		//IL_0d60: Expected O, but got I
		//IL_118b: Expected F4, but got O
		//IL_0487: Expected O, but got Ref
		//IL_0d95: Expected I, but got O
		//IL_0fca: Expected O, but got F4
		//IL_0fe1: Expected I, but got O
		//IL_06f3: Expected I, but got O
		//IL_071c: Expected F4, but got I
		//IL_0dd1: Expected I, but got O
		//IL_0759: Expected O, but got I4
		//IL_0a44: Expected F4, but got O
		//IL_0631: Expected O, but got I
		//IL_0639: Expected F4, but got O
		//IL_064b: Expected O, but got I
		//IL_0dec: Expected O, but got Ref
		//IL_0e14: Expected F4, but got I
		//IL_0e24: Expected F4, but got I
		//IL_0a64: Expected F4, but got O
		//IL_0a88: Expected I, but got O
		//IL_0e97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9c: Expected O, but got Unknown
		//IL_0ea5: Invalid comparison between O and F4
		//IL_0ebc: Expected I, but got O
		//IL_120a: Expected F4, but got O
		//IL_0774: Expected O, but got Ref
		//IL_0aa7: Expected O, but got I
		//IL_0ac5: Expected O, but got I
		//IL_0ed3: Invalid comparison between I4 and F4
		//IL_0ef2: Invalid comparison between F4 and I4
		//IL_0f30: Expected O, but got I
		//IL_0f4d: Expected I, but got O
		//IL_0aeb: Expected I, but got O
		//IL_0f82: Expected I, but got O
		//IL_0b27: Expected I, but got O
		//IL_0930: Expected O, but got I
		//IL_093c: Invalid comparison between O and F4
		//IL_094f: Expected F4, but got O
		//IL_0fa1: Expected O, but got I
		//IL_0faf: Expected I, but got O
		//IL_0989: Expected F4, but got O
		//IL_0b6e: Expected O, but got I
		//IL_09bc: Expected O, but got I
		//IL_09c6: Expected F4, but got O
		//IL_0bb6: Expected I, but got O
		//IL_0be8: Expected I, but got O
		//IL_0c03: Expected O, but got Ref
		//IL_0c14: Expected O, but got I
		//IL_0c2a: Expected I, but got O
		//IL_0c5e: Expected F4, but got O
		//IL_0c6b: Expected I, but got O
		//IL_0c9f: Expected F4, but got O
		//IL_0cc4: Expected O, but got I
		//IL_0cd6: Expected I, but got O
		List<float> characterFallingTimers = _characterFallingTimers;
		bool flag = _characterFallingTimers == null;
		nint num = (nint)this;
		if (!flag)
		{
			int num2 = 0;
			bool flag7;
			List<StageEdge>.Enumerator enumerator = default(List<StageEdge>.Enumerator);
			List<StageEdge>.Enumerator enumerator3 = default(List<StageEdge>.Enumerator);
			float2 float5 = default(float2);
			List<StageEdge>.Enumerator enumerator4 = default(List<StageEdge>.Enumerator);
			EnemyBigFuzz enemyBigFuzz2 = default(EnemyBigFuzz);
			List<StageEdge>.Enumerator enumerator6 = default(List<StageEdge>.Enumerator);
			List<StageEdge>.Enumerator enumerator7 = default(List<StageEdge>.Enumerator);
			List<StageEdge>.Enumerator enumerator8 = default(List<StageEdge>.Enumerator);
			List<StageEdge>.Enumerator enumerator9 = default(List<StageEdge>.Enumerator);
			do
			{
				GameManager core = GM.Core;
				bool flag2 = (object)GM.Core == null;
				num = (nint)typeof(GM);
				if (flag2)
				{
					break;
				}
				List<CharacterController> characters = core._characters;
				bool flag3 = core._characters == null;
				num = (nint)typeof(GM);
				if (flag3)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v32 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)0 < (nint)characters._size)
				{
					List<float> characterFallingTimers2 = _characterFallingTimers;
					bool flag4 = _characterFallingTimers == null;
					num = (nint)_characterFallingTimers;
					if (flag4)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+10]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+10]");
					bool flag5 = (nint)0 == 0;
					num = (nint)_characterFallingTimers;
					if (flag5)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r8_v23 (Il2CppMethodInfo)+18]");
					if (num4 >= 0)
					{
						_characterFallingTimers.AddWithResize(0f);
						num3 = 0;
						num2 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+18]");
						object obj2 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v73 (System.Collections.Generic.List`1<System.Single>)+18]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r8_v23 (Il2CppMethodInfo)+18]");
						bool flag6 = num5 >= 0;
						num = (nint)_characterFallingTimers;
						if (flag6)
						{
							goto IL_10a0;
						}
					}
					characterFallingTimers = _characterFallingTimers;
					flag7 = _characterFallingTimers == null;
					num = (nint)_characterFallingTimers;
					continue;
				}
				int num6 = num2;
				num = (nint)typeof(GM);
				EnemyBigFuzz enemyBigFuzz = this;
				while (true)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core == null)
					{
						break;
					}
					List<CharacterController> characters2 = core2._characters;
					if (core2._characters == null)
					{
						break;
					}
					if (num6 >= characters2._size)
					{
						return;
					}
					num = (nint)GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rcx_v8 (Il2CppClass<VampireSurvivors.Framework.GM>)+298]");
					object obj3 = 0;
					int num7 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ rbx_v15+18]");
					float num14;
					if ((nint)num7 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ rbx_v15+10]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ rbx_v15+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						int num8 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+18]");
						if ((nint)num8 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
							ArcadeSprite arcadeSprite = (ArcadeSprite)0;
							if (enemyBigFuzz._stageEdges == null)
							{
								break;
							}
							int num9 = num2;
							if (enumerator.MoveNext())
							{
								Component component = null;
								List<StageEdge>.Enumerator enumerator2 = (List<StageEdge>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							List<StageEdge>.Enumerator enumerator5;
							float2 float6;
							if (num9 == 0)
							{
								nint num10 = (nint)typeof(float2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ rax_v93 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
								nint num11 = 0;
								bool flag8 = enemyBigFuzz._stageEdges == null;
								num = num11;
								if (flag8)
								{
									break;
								}
								float num12 = 3.4028235E+38f;
								int num13 = 0;
								if (enumerator3.MoveNext())
								{
									Component component2 = null;
									ArcadeSprite arcadeSprite2 = (ArcadeSprite)(&enumerator3);
									throw new NullReferenceException();
								}
								bool flag9 = num13 == 0;
								num14 = (float)float5;
								if (flag9)
								{
									goto IL_0fb4;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
								bool flag10 = (nint)0 == 0;
								num = (nint)(&enumerator3);
								if (flag10)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
								((ArcadeSprite)0).position = (float2)enumerator4;
								num14 = (float)float5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rcx_v60 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
								enumerator5 = (List<StageEdge>.Enumerator)0;
								float6 = (float2)enumerator4;
							}
							else
							{
								num14 = (float)float5;
								int num13 = num9;
								enumerator5 = (List<StageEdge>.Enumerator)enemyBigFuzz._stageEdges;
								float6 = (float2)0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rsi_v18 (System.Int32)+1C]");
							if ((nint)0 != 0)
							{
								bool flag11 = _characterFallingTimers == null;
								num = (nint)_characterFallingTimers;
								if (flag11)
								{
									break;
								}
								_characterFallingTimers.AddWithResize((float)float6);
								bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) <= System.Runtime.CompilerServices.Unsafe.As<List<StageEdge>.Enumerator, UIntPtr>(ref enumerator5);
								num = (nint)_characterFallingTimers;
								if (!flag12)
								{
									nint num15 = (nint)typeof(float2);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v80 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
									nint num16 = 0;
									float2 zero = float2.zero;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v49 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
									float num12 = 0f;
									bool flag13 = enemyBigFuzz2._stageEdges == null;
									num = num16;
									if (flag13)
									{
										break;
									}
									num14 = 3.4028235E+38f;
									float6 = (float2)0;
									int num17 = 0;
									if (enumerator6.MoveNext())
									{
										Component component3 = null;
										ArcadeSprite arcadeSprite2 = (ArcadeSprite)(&enumerator6);
										throw new NullReferenceException();
									}
									bool flag14 = num17 == 0;
									float num18 = (float)zero;
									num = (nint)(&enumerator6);
									if (!flag14)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
										bool flag15 = (nint)0 == 0;
										num = (nint)(&enumerator6);
										if (flag15)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
										float2 float7 = ((ArcadeSprite)0).position;
										bool flag16 = System.Runtime.CompilerServices.Unsafe.As<List<StageEdge>.Enumerator, UIntPtr>(ref enumerator7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12);
										num18 = (float)zero;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
										num = 0;
										if (!flag16)
										{
											bool flag17 = !(0.1f > num14);
											num18 = (float)zero;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
											num = 0;
											if (!flag17)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
												((ArcadeSprite)0).position = (float2)enumerator4;
												num18 = (float)zero;
												int num13 = num17;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
												num = 0;
											}
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rsi_v18 (System.Int32)+1C]");
								bool flag18 = (nint)0 == 0;
								enemyBigFuzz = enemyBigFuzz2;
								if (!flag18)
								{
									if (enemyBigFuzz2._characterFallingTimers == null)
									{
										break;
									}
									enemyBigFuzz2._characterFallingTimers.AddWithResize((float)float6);
									float deltaTime = PauseSystem.DeltaTime;
									enemyBigFuzz2._characterFallingTimers.AddWithResize((float)float6);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									bool flag19 = (nint)0 == 0;
									num = (nint)enemyBigFuzz2._characterFallingTimers;
									if (flag19)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									((ArcadeSprite)0).CheckRenderer();
									Component spriteRenderer = arcadeSprite._spriteRenderer;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									((ArcadeSprite)0).CheckRenderer();
									bool flag20 = (object)arcadeSprite._spriteRenderer == null;
									num = (nint)arcadeSprite._spriteRenderer;
									if (flag20)
									{
										break;
									}
									Transform transform = arcadeSprite._spriteRenderer.transform;
									bool flag21 = (object)transform == null;
									num = (nint)arcadeSprite._spriteRenderer;
									if (flag21)
									{
										break;
									}
									float num18 = transform.localEulerAngles.z;
									float deltaTime2 = PauseSystem.DeltaTime;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									if (((ArcadeSprite)0).flipX)
									{
									}
									float num12 = deltaTime2 * 720f;
									bool flag22 = (object)spriteRenderer == null;
									num = (nint)typeof(RenderingExtensions);
									if (flag22)
									{
										break;
									}
									Transform transform2 = spriteRenderer.transform;
									bool flag23 = (object)transform2 == null;
									num = (nint)spriteRenderer;
									if (flag23)
									{
										break;
									}
									transform2.localEulerAngles = (Vector3)(&enumerator8);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									float2 float8 = ((ArcadeSprite)0).position;
									num = (nint)enemyBigFuzz2._characterFallingTimers;
									if (enemyBigFuzz2._characterFallingTimers == null)
									{
										break;
									}
									enemyBigFuzz2._characterFallingTimers.AddWithResize((float)float6);
									num = (nint)enemyBigFuzz2._characterFallingTimers;
									if (enemyBigFuzz2._characterFallingTimers == null)
									{
										break;
									}
									enemyBigFuzz2._characterFallingTimers.AddWithResize((float)float6);
									num14 = (float)enumerator4 * -0.5f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									((ArcadeSprite)0).position = (float2)enumerator4;
									enumerator8 = enumerator4;
									nint num3 = unchecked((nint)null);
									enemyBigFuzz = enemyBigFuzz2;
								}
							}
							else
							{
								bool flag24 = _characterFallingTimers == null;
								num = (nint)_characterFallingTimers;
								if (flag24)
								{
									break;
								}
								_characterFallingTimers.set_Item(num6, 0f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
								bool flag25 = (nint)0 == 0;
								num = (nint)_characterFallingTimers;
								if (flag25)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
								((ArcadeSprite)0).CheckRenderer();
								Component spriteRenderer = arcadeSprite._spriteRenderer;
								bool flag26 = (object)arcadeSprite._spriteRenderer == null;
								num = (nint)typeof(RenderingExtensions);
								if (flag26)
								{
									break;
								}
								Transform transform3 = arcadeSprite._spriteRenderer.transform;
								bool flag27 = (object)transform3 == null;
								num = (nint)arcadeSprite._spriteRenderer;
								if (flag27)
								{
									break;
								}
								transform3.localEulerAngles = (Vector3)(&enumerator9);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rsi_v18 (System.Int32)+18]");
								num14 = 0f * ((float)Math.PI / 180f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v17 (ArcadeSprite)+234]");
								float num12 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v17 (ArcadeSprite)+238]");
								float num18 = 0f;
								((List<float>)(object)transform3).set_Item((int)(&enumerator9), 0f);
								((List<float>)(object)transform3).set_Item((int)(&enumerator9), 0f);
								float num19 = num14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v17 (ArcadeSprite)+234]");
								float num20 = num19 * 0f;
								float num21 = num14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v17 (ArcadeSprite)+238]");
								float num22 = num21 * 0f;
								float num23 = num20 + num22;
								object obj5 = num23 & -2147483649L;
								bool flag28 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f);
								enumerator9 = enumerator4;
								nint num3 = unchecked((nint)null);
								if (!flag28)
								{
									bool flag29 = 0f < num23;
									float num24 = 0f - num23;
									bool flag30 = num24 == 0f;
									bool flag31 = !flag29;
									bool flag32 = !flag30;
									bool flag33 = flag32 & flag31;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
									ArcadeSprite arcadeSprite3 = ((ArcadeSprite)0).setFlipX(flag33);
									bool flag34 = (object)GM.Core == null;
									num = (nint)GM.Core;
									if (flag34)
									{
										break;
									}
									bool isMultiplayer = GM.Core.IsMultiplayer;
									bool flag35 = !isMultiplayer;
									enumerator9 = enumerator4;
									num3 = unchecked((nint)null);
									if (!flag35)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rbx_v16+20+v354 @ r12_v14 (System.Int32)*8]");
										((CharacterController)0).RefreshMultiplayerOutline();
										enumerator9 = enumerator4;
										num3 = unchecked((nint)null);
									}
								}
							}
							goto IL_0fb4;
						}
						goto IL_10a0;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
					IL_0fb4:
					num6++;
					float5 = (float2)num14;
					num2 = 0;
					num = (nint)typeof(GM);
				}
				break;
				IL_10a0:
				throw new IndexOutOfRangeException();
			}
			while (!flag7);
		}
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Clearup();
		base.OnDestroy();
	}

	public override void Despawn()
	{
		Clearup();
		base.Despawn();
	}

	private void Clearup()
	{
		PhaserSprite phaserSprite = _body;
		if ((object)_body != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0 && ProCamera2D.Exists)
		{
			ProCamera2D instance = ProCamera2D.Instance;
			instance.UpdateType = Com.LuisPedroFonseca.ProCamera2D.UpdateType.LateUpdate;
		}
		CancelTimers();
		DestroyComponentGO(_body);
		DestroyComponentGO(_leftHand);
		DestroyComponentGO(_rightHand);
		DestroyComponentGO(_leftDoor);
		DestroyComponentGO(_rightDoor);
		PhaserSprite doorFrame = _doorFrame;
		if ((object)_doorFrame != null && ((UnityEngine.Object)doorFrame).m_CachedPtr != (IntPtr)0 && ProCamera2D.Exists)
		{
			ProCamera2D instance2 = ProCamera2D.Instance;
			Transform targetTransform = _doorFrame.transform;
			instance2.RemoveCameraTarget(targetTransform);
		}
		DestroyComponentGO(_doorFrame);
		DestroyComponentGO(_doorSpace);
		DestroyComponentGO(_doorMask);
		DestroyComponentGO(_laserChargingLeft);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 393 Invalid \"Jump target not found in method: 0x18767B980\"");
		throw new NullReferenceException();
	}

	private void DestroyComponentGO(Component sprite)
	{
		if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = sprite.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj = sprite.gameObject;
				UnityEngine.Object.Destroy(obj, 0f);
			}
		}
	}

	public unsafe override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_005c: Invalid comparison between F4 and I4
		//IL_0160: Expected O, but got I4
		//IL_0533: Invalid comparison between I4 and F4
		//IL_01a3: Expected F4, but got I4
		//IL_01e1: Expected F4, but got I4
		//IL_0265: Expected O, but got F4
		//IL_02f7: Expected I4, but got O
		//IL_0140: Expected O, but got F4
		//IL_031c: Expected I4, but got O
		//IL_04d9: Expected I4, but got F4
		//IL_04d9: Expected O, but got F4
		//IL_03f2: Expected O, but got Ref
		//IL_0557: Expected I4, but got O
		//IL_0436: Expected I4, but got O
		//IL_03b2: Expected I4, but got O
		//IL_03bf: Expected I4, but got O
		//IL_05dc->IL043b: Incompatible stack heights: 2 vs 0
		if (body == null)
		{
			return;
		}
		BaseBody baseBody = body;
		if (!baseBody._enable || base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if (!(value > 0f))
		{
			goto IL_0146;
		}
		float num = default(float);
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CDamageNumbersEnabled_003Ek__BackingField)
				{
					goto IL_0146;
				}
				if ((object)_cachedTransform != null)
				{
					Vector3 vector = _cachedTransform.position;
					if ((object)_gameManager != null)
					{
						_gameManager.ShowDamageAt((Vector2)num, value);
						goto IL_0146;
					}
				}
			}
		}
		goto IL_04fc;
		IL_0146:
		float num2 = _shieldedDamage + value;
		object obj = 868;
		if (_cycleCount >= 1)
		{
			float hp = _hp - num2;
			_hp = hp;
			num2 = 0f;
		}
		if (!(0f < _hp))
		{
			Die();
		}
		float value2 = UnityEngine.Random.value;
		float? num3 = default(float?);
		float num4 = default(float);
		float num5 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_EnemyHit, 15f, 30, 0f, num3, num4, num5, flag, 1f);
		if (showHitVfx == HitVfxType.None)
		{
			goto IL_026e;
		}
		if ((object)_cachedTransform != null)
		{
			Vector3 vector2 = _cachedTransform.position;
			if ((object)_gameManager != null)
			{
				_gameManager.ShowHitVfxAt((Vector2)num, showHitVfx);
				goto IL_026e;
			}
		}
		goto IL_04fc;
		IL_04fc:
		throw new NullReferenceException();
		IL_026e:
		if (_receivingDamage)
		{
			return;
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2 != null)
			{
				bool flag2 = !config2._003CFlashingVFXEnabled_003Ek__BackingField;
				bool useRealTime = (byte)(int)num3 != 0;
				if (!flag2)
				{
					bool flag3 = showHitVfx == HitVfxType.None;
					useRealTime = (byte)(int)num3 != 0;
					if (!flag3)
					{
						HitVFXData data = VFXManager.GetData(showHitVfx);
						if (data == null)
						{
							goto IL_04fc;
						}
						Color value4 = default(Color);
						if (!data.HasTintFill)
						{
							if ((object)data.CachedTintColor == null)
							{
								CheckRenderer();
								HitVfxType hitVfxType = (HitVfxType)((ArcadeSprite)this)._spriteRenderer;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rbx_v14 (VampireSurvivors.Data.HitVfxType)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rbx_v14 (VampireSurvivors.Data.HitVfxType)+10]");
							Color value3 = default(Color);
							SpriteRenderer.set_color_Injected((IntPtr)0, ref value3);
							PhaserSprite phaserSprite = _body;
							HitVfxType hitVfxType2 = (HitVfxType)phaserSprite._spriteRenderer;
							useRealTime = (byte)(int)num3 != 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rbx_v16 (VampireSurvivors.Data.HitVfxType)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rbx_v16 (VampireSurvivors.Data.HitVfxType)+10]");
							SpriteRenderer.set_color_Injected((IntPtr)0, ref value4);
						}
						else
						{
							CheckRenderer();
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
							SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(((ArcadeSprite)this)._spriteRenderer, isEnabled: true, (Color?)(object)(&value4));
							if ((object)_body == null)
							{
								goto IL_04fc;
							}
							PhaserSprite phaserSprite2 = _body.setTintFill(isEnabled: true, 16777215u);
							useRealTime = (byte)(int)num3 != 0;
						}
					}
				}
				float num6 = ((!base._003CIsDead_003Ek__BackingField) ? 120f : 60f);
				if (_blinkTimer != null)
				{
					_blinkTimer.Cancel();
				}
				Action onComplete = RestoreBodyTint;
				float duration = num6 * 0.001f;
				VampireSurvivors.Framework.TimerSystem.Timer blinkTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, (MonoBehaviour)num4, (int)num5, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
				_blinkTimer = blinkTimer;
				_receivingDamage = true;
				return;
			}
		}
		goto IL_04fc;
	}

	private unsafe void RestoreBodyTint()
	{
		//IL_0023: Expected O, but got Ref
		CheckRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
		object obj = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(((ArcadeSprite)this)._spriteRenderer, isEnabled: false, (Color?)(object)(&obj));
		PhaserSprite phaserSprite = _body;
		if ((object)_body != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _body.setTintFill(isEnabled: false, 16777215u);
		}
		_receivingDamage = false;
	}

	protected override void Die()
	{
		if (_phase != FightPhase.Exploding && _phase != FightPhase.ChoppingHead && _phase != FightPhase.HeadFalling && !base._003CIsDead_003Ek__BackingField)
		{
			_phase = FightPhase.Exploding;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				StartExploding();
				return;
			}
			Action action = StartExplodingOnline;
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	public void StartExplodingOnline()
	{
		StartExploding();
	}

	private unsafe void StartExploding()
	{
		//IL_0023: Expected O, but got Ref
		//IL_01a2: Expected F4, but got I4
		//IL_01b4: Expected I, but got O
		//IL_024f: Expected I4, but got F4
		//IL_024f: Expected O, but got F4
		//IL_024f: Expected I4, but got O
		CheckRenderer();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
		object obj = default(object);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTintFill(((ArcadeSprite)this)._spriteRenderer, isEnabled: false, (Color?)(object)(&obj));
		PhaserSprite phaserSprite = _body;
		if ((object)_body != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _body.setTintFill(isEnabled: false, 16777215u);
		}
		_receivingDamage = false;
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
		ScreenShake(100);
		_phase = FightPhase.Exploding;
		PhaserSprite phaserSprite3 = _laserChargingLeft.setVisible(visible: false);
		PhaserSprite phaserSprite4 = _laserChargingRight.setVisible(visible: false);
		CancelTimers();
		GM.Core.SetAllPlayersWeaponsActive(active: false);
		List<EquipmentInfo> removedEquipment = GM.Core.RemoveAllEquipmentFromPlayers();
		_removedEquipment = removedEquipment;
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = false;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BossExplosions, 5000f, 1, 0f, num, num2, num3, flag, 1f);
		nint num4 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v33 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num5 = 0;
		BaseBody baseBody = body;
		baseBody._velocity = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rcx_v29 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		Action onComplete = delegate
		{
			//IL_0120: Expected I, but got O
			//IL_0136: Expected O, but got I
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_01ad: Expected I, but got O
			//IL_01d9: Expected O, but got I4
			//IL_01f0: Expected I, but got I8
			//IL_0196: Expected I, but got I8
			_phase = FightPhase.ChoppingHead;
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
			float2 originalSize = default(float2);
			ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, originalSize);
			ArcadeSprite arcadeSprite2 = setTint(16777215u);
			ArcadeSprite arcadeSprite3 = setDepth(1000);
			Action onComplete2 = ChopHead;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			bool flag2 = false;
			bool flag3 = false;
			do
			{
				_003C_003Ec__DisplayClass75_0 obj2 = new _003C_003Ec__DisplayClass75_0();
				obj2._003C_003E4__this = this;
				obj2.index = (flag3 ? 1 : 0);
				Action action = null;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass75_0._003CStartExploding_003Eb__1);
				((Delegate)action).m_target = obj2;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				nint num7;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num7 = unchecked((nint)6447293664L);
						goto IL_01d0;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num7 = ((Delegate)action).method_ptr;
				goto IL_01d0;
				IL_01d0:
				object obj5 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float duration = (float)(flag2 ? 1 : 0) * 0.001f;
				VampireSurvivors.Framework.TimerSystem.Timer timer3 = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
				flag2 = (byte)((flag2 ? 1u : 0u) + 50u) != 0;
			}
			while ((flag2 ? 1 : 0) < 400);
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(4.2000003f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
	}

	private void ChopHead()
	{
		//IL_0033: Expected F4, but got I4
		//IL_0061: Expected I, but got O
		//IL_00dd: Expected O, but got I4
		_phase = FightPhase.HeadFalling;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzHeadChop, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			float2 float5 = base.position;
			tweenConfig.ease = Ease.OutBounce;
			tweenConfig.y = (float?)(object)1;
			TweenCallback onComplete = HeadFallenOff;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void HeadFallenOff()
	{
		//IL_01c8: Expected I4, but got F4
		//IL_0132: Expected I4, but got F4
		//IL_017a: Expected I4, but got F4
		ProCamera2D instance = ProCamera2D.Instance;
		CheckRenderer();
		Transform targetTransform = ((ArcadeSprite)this)._spriteRenderer.transform;
		float num = default(float);
		Vector2 vector = default(Vector2);
		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.AddCameraTarget(targetTransform, 1f, 1f, num, vector);
		ProCamera2D instance2 = ProCamera2D.Instance;
		Transform targetTransform2 = _doorFrame.transform;
		instance2.RemoveCameraTarget(targetTransform2, 10f);
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = true;
		GameManager core3 = GM.Core;
		core3._WhiteHandManager.SummonWhiteHand(forceStageTimerEnd: true);
		GiveReward();
		Action onComplete = delegate
		{
			_phase = FightPhase.Finished;
		};
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(25.000002f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadTilted", "firstBloodEnemies");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			base.SetFlipX(flip: true);
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(30.000002f, onComplete2, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BossExplosions, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
			_phase = FightPhase.HeadFalling;
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer3 = Timers.Register(33f, onComplete3, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void ScheduleHighBrowGag()
	{
		Action onComplete = delegate
		{
			_phase = FightPhase.Finished;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(25.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadTilted", "firstBloodEnemies");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			base.SetFlipX(flip: true);
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(30.000002f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BossExplosions, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
			_phase = FightPhase.HeadFalling;
		};
		VampireSurvivors.Framework.TimerSystem.Timer timer3 = Timers.Register(33f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void CleanupFromStage()
	{
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: false);
		if (_removedEquipment != null)
		{
			GM.Core.GiveBackAllEquipmentToPlayers(_removedEquipment);
		}
	}

	public EnemyBigFuzz()
	{
		List<PhaserSprite> explosionSprites = new List<PhaserSprite>();
		_explosionSprites = explosionSprites;
		_readyExplosionSprites = new List<PhaserSprite>();
		_scale = 2f;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__49_0()
	{
		Sprite sprite = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
		float2 originalSize = default(float2);
		ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, originalSize);
		CloseDoors();
	}

	private void _003CStartClawingIn_003Eb__53_0()
	{
		//IL_004c: Expected F4, but got I4
		PhaserSprite phaserSprite = _rightHand.setVisible(visible: true);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzClaws, 100f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private void _003CStartClawingIn_003Eb__53_1()
	{
		//IL_004c: Expected F4, but got I4
		PhaserSprite phaserSprite = _leftHand.setVisible(visible: true);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzClaws, 100f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private void _003CStartClawingIn_003Eb__53_2()
	{
		//IL_0033: Expected F4, but got I4
		OpenDoors(firstTime: true);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BigFuzzHeadChop, 100f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private unsafe void _003CStartPreFireShaking_003Eb__58_0()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b9: Expected O, but got I
		//IL_02e3: Expected O, but got Ref
		//IL_02f8: Expected native int or pointer, but got O
		//IL_0312: Expected O, but got I
		//IL_0332: Expected O, but got Ref
		//IL_034c: Expected native int or pointer, but got O
		//IL_0366: Expected O, but got I
		//IL_0386: Expected O, but got Ref
		//IL_03a0: Expected native int or pointer, but got O
		//IL_03ba: Expected O, but got I
		//IL_03da: Expected O, but got Ref
		//IL_03f4: Expected native int or pointer, but got O
		//IL_07af: Expected O, but got I4
		//IL_0419: Expected O, but got Ref
		//IL_0440: Expected O, but got I
		//IL_045a: Expected native int or pointer, but got O
		//IL_07e9: Expected O, but got I
		//IL_0492: Expected O, but got Ref
		//IL_04b9: Expected O, but got I
		//IL_04d3: Expected native int or pointer, but got O
		//IL_0823: Expected O, but got I
		//IL_05cc: Expected F4, but got I
		//IL_08ae: Expected I, but got O
		//IL_08f0: Expected I4, but got F4
		//IL_08f0: Expected O, but got F4
		//IL_08f0: Expected I4, but got O
		//IL_0633: Expected I4, but got F4
		//IL_0633: Expected O, but got F4
		//IL_0633: Expected I4, but got O
		//IL_067e: Expected I4, but got F4
		//IL_067e: Expected O, but got F4
		//IL_067e: Expected I4, but got O
		//IL_06ce: Expected I4, but got F4
		//IL_06ce: Expected O, but got F4
		//IL_06ce: Expected I4, but got O
		//IL_0719: Expected I4, but got F4
		//IL_0719: Expected O, but got F4
		//IL_0719: Expected I4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass58_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass58_0();
		if (CS_0024_003C_003E8__locals23 != null)
		{
			CS_0024_003C_003E8__locals23._003C_003E4__this = this;
			_phase = FightPhase.FireBreathCharging;
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadOpen", "firstBloodEnemies");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			GameObject gameObject = base.gameObject;
			_ = 0;
			nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
			ParticleEmitterManager particleEmitterManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out *(ParticleEmitterManager*)num))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+138]");
				particleEmitterManager = (ParticleEmitterManager)0;
			}
			else
			{
				ParticleEmitterManager particleEmitterManager2 = gameObject.AddComponent<ParticleEmitterManager>();
				particleEmitterManager = particleEmitterManager2;
				num = 0;
			}
			float2 float5 = base.position;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 8f;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"flame001");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version2 = list._version + 1;
					list._version = version2;
					string[] items2 = list._items;
					if (list._items != null)
					{
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"flame002");
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						if (particleSystemConfig != null)
						{
							particleSystemConfig._frame = list;
							ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(100f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
							particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
							particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 200f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
							_ = 0;
							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
							_ = 0;
							_ = 1;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
							particleSystemConfig._quantity = (int?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 2f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
							_ = 0;
							_ = 1120403456;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
							particleSystemConfig._frequency = (float?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
							particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
							_ = 0;
							particleSystemConfig._emitZone = emitZone;
							particleSystemConfig._on = true;
							ParticleSystem pfxEmitter = particleEmitterManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
							CS_0024_003C_003E8__locals23.pfxEmitter = pfxEmitter;
							Transform transform = CS_0024_003C_003E8__locals23.pfxEmitter.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v62 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v62 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_position_Injected((IntPtr)0, ref value);
							RenderingExtensions.SetDepth(CS_0024_003C_003E8__locals23.pfxEmitter, 1100);
							RenderingExtensions.Start(CS_0024_003C_003E8__locals23.pfxEmitter);
							_ = 0;
							_ = 1073741824;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
							float? num4 = default(float?);
							float num5 = default(float);
							float num6 = default(float);
							bool flag2 = default(bool);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, num4, num5, num6, flag2);
							ParticleSystemConfig pfxEmitter2 = (ParticleSystemConfig)(object)CS_0024_003C_003E8__locals23.pfxEmitter;
							bool flag3 = (object)pfxEmitter2._x == null;
							ParticleSystem.Emit_Internal_Injected((IntPtr)pfxEmitter2._x, 10);
							Action onComplete = delegate
							{
								//IL_0033: Expected F4, but got I4
								float? volume = default(float?);
								float rate = default(float);
								float detune = default(float);
								bool loop = default(bool);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
								object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							};
							VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.4f, onComplete, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
							Action onComplete2 = delegate
							{
								//IL_0033: Expected F4, but got I4
								float? volume = default(float?);
								float rate = default(float);
								float detune = default(float);
								bool loop = default(bool);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
								object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							};
							VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(0.8f, onComplete2, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
							Action onComplete3 = delegate
							{
								//IL_0033: Expected F4, but got I4
								float? volume = default(float?);
								float rate = default(float);
								float detune = default(float);
								bool loop = default(bool);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
								object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							};
							VampireSurvivors.Framework.TimerSystem.Timer timer3 = Timers.Register(1.2f, onComplete3, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
							Action onComplete4 = delegate
							{
								//IL_0033: Expected F4, but got I4
								float? volume = default(float?);
								float rate = default(float);
								float detune = default(float);
								bool loop = default(bool);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
								object pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v2 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 94 ConditionalJump @-1, v106 @ ZF_v7 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							};
							VampireSurvivors.Framework.TimerSystem.Timer timer4 = Timers.Register(1.6f, onComplete4, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
							Action onComplete5 = delegate
							{
								//IL_0033: Expected F4, but got I4
								//IL_0065: Expected F4, but got I4
								//IL_015a: Expected I4, but got F4
								//IL_015a: Expected O, but got F4
								//IL_015a: Expected I4, but got O
								float? num7 = default(float?);
								float num8 = default(float);
								float num9 = default(float);
								bool flag4 = default(bool);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Fireloop, 100f, 10, 0f, num7, num8, num9, flag4, 1f);
								PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 100f, 10, 0f, num7, num8, num9, flag4, 1f);
								ParticleSystem pfxEmitter3 = CS_0024_003C_003E8__locals23.pfxEmitter;
								if ((object)CS_0024_003C_003E8__locals23.pfxEmitter != null && ((UnityEngine.Object)pfxEmitter3).m_CachedPtr != (IntPtr)0)
								{
									CS_0024_003C_003E8__locals23.pfxEmitter.Emit(100);
									RenderingExtensions.StopEmitting(CS_0024_003C_003E8__locals23.pfxEmitter);
								}
								Action onComplete6 = CS_0024_003C_003E8__locals23._003C_003E9__6;
								if (CS_0024_003C_003E8__locals23._003C_003E9__6 == null)
								{
									onComplete6 = (CS_0024_003C_003E8__locals23._003C_003E9__6 = delegate
									{
										ParticleSystem pfxEmitter4 = CS_0024_003C_003E8__locals23.pfxEmitter;
										if ((object)CS_0024_003C_003E8__locals23.pfxEmitter != null && ((UnityEngine.Object)pfxEmitter4).m_CachedPtr != (IntPtr)0)
										{
											GameObject obj3 = CS_0024_003C_003E8__locals23.pfxEmitter.gameObject;
											UnityEngine.Object.Destroy(obj3, 0f);
										}
									});
								}
								VampireSurvivors.Framework.TimerSystem.Timer timer5 = Timers.Register(1f, onComplete6, null, isLooped: false, (byte)(int)num7 != 0, (MonoBehaviour)num8, (int)num9, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								EnemyBigFuzz enemyBigFuzz = CS_0024_003C_003E8__locals23._003C_003E4__this;
								enemyBigFuzz._phase = FightPhase.FireBreathRotation;
								EnemyBigFuzz enemyBigFuzz2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
								enemyBigFuzz2._firebreathRotationDegrees = 0f;
							};
							VampireSurvivors.Framework.TimerSystem.Timer fireRotationTimer = Timers.Register(2f, onComplete5, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
							_fireRotationTimer = fireRotationTimer;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CCloseDoors_003Eb__59_0()
	{
		OpenDoors(firstTime: false);
	}

	private unsafe void _003CStartExploding_003Eb__75_0()
	{
		//IL_0120: Expected I, but got O
		//IL_0136: Expected O, but got I
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_01ad: Expected I, but got O
		//IL_01d9: Expected O, but got I4
		//IL_01f0: Expected I, but got I8
		//IL_0196: Expected I, but got I8
		_phase = FightPhase.ChoppingHead;
		Sprite sprite = SpriteManager.GetSprite("BigFuzzHead", "firstBloodEnemies");
		float2 originalSize = default(float2);
		ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, originalSize);
		ArcadeSprite arcadeSprite2 = setTint(16777215u);
		ArcadeSprite arcadeSprite3 = setDepth(1000);
		Action onComplete = ChopHead;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer timer = Timers.Register(0.4f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		bool flag = false;
		bool flag2 = false;
		do
		{
			_003C_003Ec__DisplayClass75_0 obj = new _003C_003Ec__DisplayClass75_0();
			obj._003C_003E4__this = this;
			obj.index = (flag2 ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass75_0._003CStartExploding_003Eb__1);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num2;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_01d0;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_01d0;
			IL_01d0:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)(flag ? 1 : 0) * 0.001f;
			VampireSurvivors.Framework.TimerSystem.Timer timer2 = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			flag = (byte)((flag ? 1u : 0u) + 50u) != 0;
		}
		while ((flag ? 1 : 0) < 400);
	}

	private void _003CScheduleHighBrowGag_003Eb__78_0()
	{
		_phase = FightPhase.Finished;
	}

	private void _003CScheduleHighBrowGag_003Eb__78_1()
	{
		Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadTilted", "firstBloodEnemies");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		base.SetFlipX(flip: true);
	}

	private void _003CScheduleHighBrowGag_003Eb__78_2()
	{
		//IL_0033: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_BossExplosions, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
		_phase = FightPhase.HeadFalling;
	}
}
