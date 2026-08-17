using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Coherence;
using Coherence.Cloud;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_Death : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__48_0;

		public static Action _003C_003E9__49_0;

		public static Action _003C_003E9__52_0;

		public static Action _003C_003E9__52_1;

		public static Action _003C_003E9__52_2;

		public static Action _003C_003E9__52_3;

		public static Action _003C_003E9__52_4;

		public static Action _003C_003E9__52_5;

		public static TweenCallback _003C_003E9__75_0;

		public static TweenCallback _003C_003E9__75_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CEndSequence_003Eb__48_0()
		{
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		}

		internal void _003CDestructionEffects_003Eb__49_0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
		}

		internal void _003COnItemReceived_003Eb__52_0()
		{
			GM.Core.TogglePlayerHealthBar(visible: false);
		}

		internal void _003COnItemReceived_003Eb__52_1()
		{
			//IL_0030: Expected O, but got I4
			GM.Core.TogglePlayerHealthBar(visible: true);
			GameManager core = GM.Core;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}

		internal void _003COnItemReceived_003Eb__52_2()
		{
			GM.Core.TogglePlayerHealthBar(visible: false);
		}

		internal void _003COnItemReceived_003Eb__52_3()
		{
			//IL_0030: Expected O, but got I4
			GM.Core.TogglePlayerHealthBar(visible: true);
			GameManager core = GM.Core;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}

		internal void _003COnItemReceived_003Eb__52_4()
		{
			GM.Core.TogglePlayerHealthBar(visible: false);
		}

		internal void _003COnItemReceived_003Eb__52_5()
		{
			//IL_0030: Expected O, but got I4
			GM.Core.TogglePlayerHealthBar(visible: true);
			GameManager core = GM.Core;
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}

		internal void _003CScreenShake_003Eb__75_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -2f;
		}

		internal void _003CScreenShake_003Eb__75_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public Enemy_TP_Death _003C_003E4__this;

		public ParticleSystem pfxEmitter;

		public ParticleEmitterManager particleManager;

		public TweenCallback _003C_003E9__6;

		public TweenCallback _003C_003E9__7;

		public TweenCallback _003C_003E9__8;

		public Action _003C_003E9__4;

		public Action _003C_003E9__5;

		internal void _003CDestructionEffects_003Eb__2()
		{
			Enemy_TP_Death enemy_TP_Death = _003C_003E4__this;
			float extraScale = default(float);
			_003C_003E4__this.UpdateJoints(enemy_TP_Death._leftHand, -1f, enemy_TP_Death._leftArmSprites, extraScale);
		}

		internal void _003CDestructionEffects_003Eb__3()
		{
			Enemy_TP_Death enemy_TP_Death = _003C_003E4__this;
			float extraScale = default(float);
			_003C_003E4__this.UpdateJoints(enemy_TP_Death._rightHand, 1f, enemy_TP_Death._rightArmSprites, extraScale);
		}

		internal void _003CDestructionEffects_003Eb__1()
		{
			//IL_00bb: Expected I, but got O
			//IL_006b: Expected I, but got O
			//IL_00dd: Expected O, but got I4
			//IL_011d: Expected O, but got I4
			//IL_012b: Expected O, but got I4
			//IL_0180: Expected O, but got I4
			//IL_0262: Expected I, but got O
			//IL_0212: Expected I, but got O
			//IL_0284: Expected O, but got I4
			//IL_02c4: Expected O, but got I4
			//IL_02d2: Expected O, but got I4
			//IL_0327: Expected O, but got I4
			//IL_0409: Expected I, but got O
			//IL_03b9: Expected I, but got O
			//IL_042b: Expected O, but got I4
			//IL_046b: Expected O, but got I4
			//IL_0479: Expected O, but got I4
			//IL_04ce: Expected O, but got I4
			//IL_06dd: Expected I4, but got I8
			//IL_06e1: Expected O, but got I4
			//IL_0560: Expected F4, but got I4
			//IL_06f9: Expected I4, but got I8
			//IL_06fd: Expected O, but got I4
			//IL_072c: Expected F4, but got I4
			//IL_0748: Expected I4, but got I8
			//IL_074c: Expected O, but got I4
			//IL_077b: Expected F4, but got I4
			//IL_0797: Expected I4, but got I8
			//IL_079b: Expected O, but got I4
			//IL_07c9: Expected F4, but got I4
			//IL_0603: Expected I4, but got F4
			//IL_0603: Expected O, but got F4
			//IL_0603: Expected I4, but got O
			//IL_068e: Expected I4, but got F4
			//IL_068e: Expected O, but got F4
			//IL_068e: Expected I4, but got O
			pfxEmitter.Stop();
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Enemy_TP_Death enemy_TP_Death = _003C_003E4__this;
			if ((object)enemy_TP_Death._leftHand != null)
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
			nint num2 = (nint)enemy_TP_Death._leftHand;
			float2 position = _003C_003E4__this.position;
			tweenConfig.x = (float?)(object)1;
			float2 position2 = _003C_003E4__this.position;
			object obj2 = default(object);
			float num3 = (float)obj2 + 10f;
			tweenConfig.duration = 500f;
			tweenConfig.y = (float?)(object)1;
			tweenConfig.localAngle = (float?)(object)1;
			TweenCallback onUpdate = _003C_003E9__6;
			if (_003C_003E9__6 == null)
			{
				TweenCallback tweenCallback = (_003C_003E9__6 = delegate
				{
					Enemy_TP_Death enemy_TP_Death5 = _003C_003E4__this;
					float extraScale = default(float);
					_003C_003E4__this.UpdateJoints(enemy_TP_Death5._leftHand, -1f, enemy_TP_Death5._leftArmSprites, extraScale);
				});
				object obj3 = 0;
				num2 = 0;
				onUpdate = tweenCallback;
			}
			tweenConfig.onUpdate = onUpdate;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			Enemy_TP_Death enemy_TP_Death2 = _003C_003E4__this;
			if ((object)enemy_TP_Death2._rightHand != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			nint num5 = (nint)enemy_TP_Death2._rightHand;
			float2 position3 = _003C_003E4__this.position;
			tweenConfig2.x = (float?)(object)1;
			float2 position4 = _003C_003E4__this.position;
			float num6 = (float)obj2 + 10f;
			tweenConfig2.duration = 500f;
			tweenConfig2.y = (float?)(object)1;
			tweenConfig2.localAngle = (float?)(object)1;
			TweenCallback onUpdate2 = _003C_003E9__7;
			if (_003C_003E9__7 == null)
			{
				TweenCallback tweenCallback2 = (_003C_003E9__7 = delegate
				{
					Enemy_TP_Death enemy_TP_Death5 = _003C_003E4__this;
					float extraScale = default(float);
					_003C_003E4__this.UpdateJoints(enemy_TP_Death5._rightHand, 1f, enemy_TP_Death5._rightArmSprites, extraScale);
				});
				object obj3 = 0;
				num5 = 0;
				onUpdate2 = tweenCallback2;
			}
			tweenConfig2.onUpdate = onUpdate2;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			Enemy_TP_Death enemy_TP_Death3 = _003C_003E4__this;
			if ((object)enemy_TP_Death3._deathCape != null)
			{
				nint num7 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			nint num8 = (nint)enemy_TP_Death3._deathCape;
			float2 position5 = _003C_003E4__this.position;
			tweenConfig3.x = (float?)(object)1;
			float2 position6 = _003C_003E4__this.position;
			float num9 = (float)obj2 + 10f;
			tweenConfig3.duration = 500f;
			tweenConfig3.y = (float?)(object)1;
			tweenConfig3.localAngle = (float?)(object)1;
			TweenCallback onComplete = _003C_003E9__8;
			if (_003C_003E9__8 == null)
			{
				TweenCallback tweenCallback3 = (_003C_003E9__8 = delegate
				{
					Enemy_TP_Death enemy_TP_Death5 = _003C_003E4__this;
					PhaserSprite phaserSprite = enemy_TP_Death5._deathCape.setVisible(visible: false);
				});
				object obj3 = 0;
				num8 = 0;
				onComplete = tweenCallback3;
			}
			tweenConfig3.onComplete = onComplete;
			MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite frame = default(Sprite);
			ArcadeSprite arcadeSprite = _003C_003E4__this.setFrame(frame);
			object obj6 = UnityEngine.Random.RandomRangeInt(-200, 200);
			float? num10 = default(float?);
			float num11 = default(float);
			float num12 = default(float);
			bool flag = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, num10, num11, num12, flag, 1f);
			object obj7 = UnityEngine.Random.RandomRangeInt(-200, 200);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, num10, num11, num12, flag, 1f);
			object obj8 = UnityEngine.Random.RandomRangeInt(-200, 200);
			PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, num10, num11, num12, flag, 1f);
			object obj9 = UnityEngine.Random.RandomRangeInt(-200, 200);
			PlaySoundResult playSoundResult4 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, num10, num11, num12, flag, 1f);
			Enemy_TP_Death enemy_TP_Death4 = _003C_003E4__this;
			enemy_TP_Death4._SpriteAnimation.SetAnimation("ScreamLoop");
			Action onComplete2 = _003C_003E9__4;
			if (_003C_003E9__4 == null)
			{
				onComplete2 = (_003C_003E9__4 = delegate
				{
					//IL_002c: Expected I, but got O
					//IL_0090: Expected O, but got I4
					//IL_009e: Expected O, but got I4
					TweenConfig tweenConfig4 = new TweenConfig();
					object[] array4 = new object[1];
					if ((object)_003C_003E4__this != null)
					{
						nint num13 = (nint)array4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj10 = default(object);
						if (obj10 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig4.targets = array4;
					tweenConfig4.duration = 500f;
					tweenConfig4.scale = (float?)(object)1;
					tweenConfig4.localAngle = (float?)(object)1;
					MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
				});
			}
			Timer timer = Timers.Register(1f, onComplete2, null, isLooped: false, (byte)(int)num10 != 0, (MonoBehaviour)num11, (int)num12, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			Action onComplete3 = _003C_003E9__5;
			if (_003C_003E9__5 == null)
			{
				onComplete3 = (_003C_003E9__5 = delegate
				{
					UnityEngine.Object.Destroy(particleManager, 0f);
					GameObject gameObject = pfxEmitter.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
					_003C_003E4__this.ActuallyRemove();
				});
			}
			Timer timer2 = Timers.Register(4f, onComplete3, null, isLooped: false, (byte)(int)num10 != 0, (MonoBehaviour)num11, (int)num12, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		}

		internal void _003CDestructionEffects_003Eb__6()
		{
			Enemy_TP_Death enemy_TP_Death = _003C_003E4__this;
			float extraScale = default(float);
			_003C_003E4__this.UpdateJoints(enemy_TP_Death._leftHand, -1f, enemy_TP_Death._leftArmSprites, extraScale);
		}

		internal void _003CDestructionEffects_003Eb__7()
		{
			Enemy_TP_Death enemy_TP_Death = _003C_003E4__this;
			float extraScale = default(float);
			_003C_003E4__this.UpdateJoints(enemy_TP_Death._rightHand, 1f, enemy_TP_Death._rightArmSprites, extraScale);
		}

		internal void _003CDestructionEffects_003Eb__8()
		{
			Enemy_TP_Death enemy_TP_Death = _003C_003E4__this;
			PhaserSprite phaserSprite = enemy_TP_Death._deathCape.setVisible(visible: false);
		}

		internal void _003CDestructionEffects_003Eb__4()
		{
			//IL_002c: Expected I, but got O
			//IL_0090: Expected O, but got I4
			//IL_009e: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_003E4__this != null)
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
			tweenConfig.duration = 500f;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.localAngle = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CDestructionEffects_003Eb__5()
		{
			UnityEngine.Object.Destroy(particleManager, 0f);
			GameObject gameObject = pfxEmitter.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
			_003C_003E4__this.ActuallyRemove();
		}
	}

	private sealed class _003C_003Ec__DisplayClass83_0
	{
		public PickupRelic pickup;

		internal void _003CDoDropAnimation_003Eb__0()
		{
			PickupRelic pickupRelic = pickup;
			((Pickup)pickupRelic)._003CDisableGet_003Ek__BackingField = true;
			PickupRelic pickupRelic2 = pickup;
			((Pickup)pickupRelic2)._003CAutoSafeXY_003Ek__BackingField = false;
		}

		internal void _003CDoDropAnimation_003Eb__1()
		{
			PickupRelic pickupRelic = pickup;
			bool flag = pickupRelic._itemType == ItemType.TP_RELIC_MASK_SEAWINDS;
			((Pickup)pickupRelic)._003CDisableGet_003Ek__BackingField = false;
			if (!flag)
			{
				pickup.StartFloatTween();
				PickupRelic pickupRelic2 = pickup;
				((Pickup)pickupRelic2)._003CAutoSafeXY_003Ek__BackingField = true;
				return;
			}
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				pickup.GetOnlineTaken();
			}
			else
			{
				pickup.GetTaken();
			}
		}
	}

	private sealed class _003C_SpawnAllies_003Ed__89(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy_TP_Death _003C_003E4__this;

		private float _003CtimeBetweenSpawns_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			while (true)
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state > 18)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v1+76C2AC8+v34 @ rax_v2 (System.Int32)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ rcx_v3 (should have been resolved before IL gen)");
			}
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

	private Transform _cameraTarget;

	private PhaserSprite _deathMask;

	private PhaserSprite _deathSpine;

	private PhaserSprite _deathCape;

	private Enemy_TP_DeathArm _leftHand;

	private Enemy_TP_DeathArm _rightHand;

	private PhaserSprite _leftCracks;

	private PhaserSprite _rightCracks;

	private MultiTargetTween _leftCracksTween;

	private MultiTargetTween _rightCracksTween;

	private MultiTargetTween _screenShakeTween;

	private MultiTargetTween _droppedRelicTween;

	private List<PhaserSprite> _leftArmSprites;

	private List<PhaserSprite> _rightArmSprites;

	private ParticleSystem _rockParticles;

	private PhaserSprite _leftEye;

	private PhaserSprite _rightEye;

	private float _crawlTimer;

	private float _scytheTimer;

	private float _bigScytheTimer;

	private float _bigScytheScreamTime;

	private float _bigScythePostScreamThrowTime;

	public Enemy_TP_DeathScytheBig _currentBigScythe;

	private DeathFightDirecter _directer;

	private bool _isDirecterDead;

	private List<ItemType> _relicsToDrop;

	private PickupRelic _droppedRelic;

	private float _relicDropTimer;

	private ParticleSystem _deathZoneParticles;

	private int _003CDirecterRevivals_003Ek__BackingField;

	private bool _003CHasRemovedWeapons_003Ek__BackingField;

	private bool _hasSpawnedAllies;

	private bool _havingAChat;

	private bool _canDie;

	private bool _sentDeathCommand;

	private float _damageZoneTimer;

	[NonSerialized]
	public List<CharacterType> _Allies;

	[NonSerialized]
	public Dictionary<CharacterType, CharacterController> _AlliesControllers;

	public int DirecterRevivals
	{
		get
		{
			return _003CDirecterRevivals_003Ek__BackingField;
		}
		set
		{
			_003CDirecterRevivals_003Ek__BackingField = value;
		}
	}

	public bool HasRemovedWeapons
	{
		get
		{
			return _003CHasRemovedWeapons_003Ek__BackingField;
		}
		set
		{
			_003CHasRemovedWeapons_003Ek__BackingField = value;
		}
	}

	public bool HasSpawnedAllies => _hasSpawnedAllies;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_004d: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_04db: Expected O, but got I4
		//IL_0685: Expected O, but got Ref
		//IL_07f7: Expected O, but got I4
		//IL_0906: Expected O, but got I4
		//IL_0b22: Expected O, but got I4
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0c: Expected O, but got Unknown
		//IL_0d0a: Expected O, but got I4
		//IL_0dfb: Expected O, but got I4
		//IL_0e85: Expected O, but got I
		//IL_0e95: Expected O, but got I
		//IL_0f0f: Expected O, but got I
		//IL_131a: Expected O, but got I
		//IL_0f9f: Expected O, but got I
		//IL_1362: Expected O, but got I
		//IL_102f: Expected O, but got I
		//IL_13aa: Expected O, but got I
		//IL_10c5: Expected O, but got I
		//IL_1116: Unknown result type (might be due to invalid IL or missing references)
		//IL_111b: Expected O, but got Unknown
		//IL_1137: Expected O, but got I
		//IL_11b5: Expected O, but got I8
		//IL_142c->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_083c->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_0890->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_08bf->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_08ee->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_0924->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_0973->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_0a1a->IL11ba: Incompatible stack heights: 1 vs 0
		//IL_1449->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0a5d->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0aac->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0adb->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0b0a->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0b40->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0b8f->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0c27->IL12bd: Incompatible stack heights: 2 vs 0
		//IL_0c5c->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0c94->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0cc3->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0cf2->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0d4d->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0d85->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0db4->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0de3->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0e5d->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0eb5->IL11ba: Incompatible stack heights: 2 vs 0
		//IL_0ef9->IL12f7: Incompatible stack heights: 2 vs 3
		//IL_133a->IL11ba: Incompatible stack heights: 3 vs 0
		//IL_0f89->IL133f: Incompatible stack heights: 3 vs 4
		//IL_1382->IL11ba: Incompatible stack heights: 4 vs 0
		//IL_1019->IL1387: Incompatible stack heights: 4 vs 5
		//IL_13ca->IL11ba: Incompatible stack heights: 5 vs 0
		//IL_10af->IL13cf: Incompatible stack heights: 5 vs 6
		//IL_11ba->IL13fe: Incompatible stack heights: 7 vs 6
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		BaseBody baseBody = body;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		Vector2 pos = default(Vector2);
		if (body != null)
		{
			baseBody._immovable = true;
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
				Sprite sprite = default(Sprite);
				ArcadeSprite arcadeSprite2 = setFrame(sprite);
				if ((object)_SpriteAnimation != null)
				{
					_SpriteAnimation.CleanAnimations();
					SpriteAnimation spriteAnimation = _SpriteAnimation;
					if ((object)_SpriteAnimation != null)
					{
						spriteAnimation._originalSpriteSize = (float2)1121320960;
						_ = 1123287040;
						List<Sprite> list = new List<Sprite>();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
							if ((object)_SpriteAnimation != null)
							{
								bool flag = default(bool);
								bool startRandomFrame = default(bool);
								Action onComplete = default(Action);
								bool autoSetAnimation = default(bool);
								_SpriteAnimation.AddAnimation("Idle", list, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
								List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_Death_OpenMouth", 1, 2, "TP_Death", flag ? 1 : 0);
								if ((object)_SpriteAnimation != null)
								{
									_SpriteAnimation.AddAnimation("OpenMouth", animationFrames, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
									List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_Death_CloseMouth", 1, 2, "TP_Death", flag ? 1 : 0);
									if ((object)_SpriteAnimation != null)
									{
										_SpriteAnimation.AddAnimation("CloseMouth", animationFrames2, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
										List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_Death_ScreamLoop", 1, 2, "TP_Death", flag ? 1 : 0);
										if ((object)_SpriteAnimation != null)
										{
											_SpriteAnimation.AddAnimation("ScreamLoop", animationFrames3, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
											PhaserWorld instance = PhaserWorld.Instance;
											float2 float5 = base.position;
											if ((object)instance != null)
											{
												PhaserSprite deathMask = instance.AddPhaserSprite(pos, "TP_Death", "TP_Death_Mask");
												_deathMask = deathMask;
												PhaserWorld instance2 = PhaserWorld.Instance;
												float2 float6 = base.position;
												if ((object)instance2 != null)
												{
													PhaserSprite deathSpine = instance2.AddPhaserSprite(pos, "TP_Death", "TP_Death_Spine");
													_deathSpine = deathSpine;
													PhaserWorld instance3 = PhaserWorld.Instance;
													float2 float7 = base.position;
													if ((object)instance3 != null)
													{
														PhaserSprite deathCape = instance3.AddPhaserSprite(pos, "TP_Death", "TP_Death_Cape");
														_deathCape = deathCape;
														PhaserSprite deathCape2 = _deathCape;
														if ((object)_deathCape != null)
														{
															List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_Death_Cape", 1, 5, "TP_Death", flag ? 1 : 0);
															if ((object)deathCape2._spriteAnimation != null)
															{
																deathCape2._spriteAnimation.AddAnimation("Flutter", animationFrames4, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
																PhaserSprite deathCape3 = _deathCape;
																if ((object)_deathCape != null)
																{
																	SpriteAnimation spriteAnimation2 = deathCape3._spriteAnimation;
																	if ((object)deathCape3._spriteAnimation != null)
																	{
																		spriteAnimation2._originalSpriteSize = (float2)1128267776;
																		_ = 1125122048;
																		PhaserSprite deathCape4 = _deathCape;
																		if ((object)_deathCape != null && (object)deathCape4._spriteAnimation != null)
																		{
																			deathCape4._spriteAnimation.SetAnimation("Flutter");
																			float2 float8 = base.position;
																			PhaserSprite leftEye = RenderingExtensions.AddPhaserSprite(this, pos, "TP_Death", "TP_Death_Eye");
																			_leftEye = leftEye;
																			float2 float9 = base.position;
																			PhaserSprite rightEye = RenderingExtensions.AddPhaserSprite(this, pos, "TP_Death", "TP_Death_Eye");
																			_rightEye = rightEye;
																			if (!(_cameraTarget == null))
																			{
																				goto IL_0676;
																			}
																			GameObject gameObject = new GameObject("CameraTarget");
																			if ((object)gameObject != null)
																			{
																				Transform transform = gameObject.transform;
																				Transform parent = base.transform;
																				if ((object)transform != null)
																				{
																					transform.SetParent(parent, worldPositionStays: true);
																					Transform cameraTarget = gameObject.transform;
																					_cameraTarget = cameraTarget;
																					goto IL_0676;
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
		goto IL_11ba;
		IL_11ba:
		throw new NullReferenceException();
		IL_0676:
		float2 ret = default(float2);
		_cameraTarget.localPosition = (Vector3)(&ret);
		GameManager core = GM.Core;
		float2 float10 = base.position;
		if ((object)core._stage != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			Enemy_TP_DeathArm leftHand = default(Enemy_TP_DeathArm);
			_leftHand = leftHand;
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				float2 float11 = base.position;
				if ((object)core2._stage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					Enemy_TP_DeathArm rightHand = default(Enemy_TP_DeathArm);
					_rightHand = rightHand;
					GameObject owner = base.gameObject;
					if ((object)_leftHand != null)
					{
						_leftHand.SetOwner(owner);
						GameObject owner2 = base.gameObject;
						if ((object)_rightHand != null)
						{
							_rightHand.SetOwner(owner2);
							List<PhaserSprite> leftArmSprites = new List<PhaserSprite>();
							_leftArmSprites = leftArmSprites;
							List<PhaserSprite> rightArmSprites = new List<PhaserSprite>();
							_rightArmSprites = rightArmSprites;
							float? num = (float?)(object)0;
							while (true)
							{
								List<object> leftArmSprites2 = (List<object>)(object)_leftArmSprites;
								PhaserWorld instance4 = PhaserWorld.Instance;
								Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
								if ((object)cachedTrans == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v93 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v93 (UnityEngine.Transform)+10]");
								float2 ret2;
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
								if (body != null)
								{
									BaseBody baseBody3 = body;
									ArcadeTransform arcadeTransform = baseBody3._transform;
									if (baseBody3._transform == null)
									{
										break;
									}
									arcadeTransform.position = ret2;
									_ = 3238002688L;
								}
								if ((object)instance4 == null)
								{
									break;
								}
								PhaserSprite phaserSprite = instance4.AddPhaserSprite(pos, "TP_Death", "TP_Death_Joint2");
								if ((object)phaserSprite == null)
								{
									break;
								}
								PhaserSprite phaserSprite2 = phaserSprite.setTint(0u);
								if ((object)phaserSprite2 == null)
								{
									break;
								}
								PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
								if ((object)phaserSprite3 == null)
								{
									break;
								}
								PhaserSprite item = phaserSprite3.setScale(0.5f, (float?)(object)0);
								if (_leftArmSprites == null)
								{
									break;
								}
								int version = leftArmSprites2._version + 1;
								leftArmSprites2._version = version;
								object[] items = leftArmSprites2._items;
								if (leftArmSprites2._items == null)
								{
									break;
								}
								if (leftArmSprites2._size >= items.Length)
								{
									((List<object>)(object)_leftArmSprites).AddWithResize((object)item);
								}
								else
								{
									int num2 = leftArmSprites2._size + 1;
									leftArmSprites2._size = num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								List<object> rightArmSprites2 = (List<object>)(object)_rightArmSprites;
								PhaserWorld instance5 = PhaserWorld.Instance;
								Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
								if ((object)cachedTrans2 == null)
								{
									break;
								}
								bool flag3 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret));
								if (body != null)
								{
									BaseBody baseBody4 = body;
									ArcadeTransform arcadeTransform2 = baseBody4._transform;
									if (baseBody4._transform == null)
									{
										break;
									}
									arcadeTransform2.position = ret;
								}
								if ((object)instance5 == null)
								{
									break;
								}
								PhaserSprite phaserSprite4 = instance5.AddPhaserSprite(pos, "TP_Death", "TP_Death_Joint2");
								if ((object)phaserSprite4 == null)
								{
									break;
								}
								PhaserSprite phaserSprite5 = phaserSprite4.setTint(0u);
								if ((object)phaserSprite5 == null)
								{
									break;
								}
								PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
								if ((object)phaserSprite6 == null)
								{
									break;
								}
								PhaserSprite item2 = phaserSprite6.setScale(0.5f, (float?)(object)0);
								if (_rightArmSprites == null)
								{
									break;
								}
								int version2 = rightArmSprites2._version + 1;
								rightArmSprites2._version = version2;
								object[] items2 = rightArmSprites2._items;
								if (rightArmSprites2._items == null)
								{
									break;
								}
								if (rightArmSprites2._size >= items2.Length)
								{
									((List<object>)(object)_rightArmSprites).AddWithResize((object)item2);
								}
								else
								{
									int num3 = rightArmSprites2._size + 1;
									rightArmSprites2._size = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								num = (float?)(object)((_003F?)num + 1);
								if ((nint)num >= 20)
								{
									PhaserWorld instance6 = PhaserWorld.Instance;
									float2 float12 = base.position;
									if ((object)instance6 == null)
									{
										break;
									}
									PhaserSprite phaserSprite7 = instance6.AddPhaserSprite(pos, "vfx", "ground");
									if ((object)phaserSprite7 == null)
									{
										break;
									}
									PhaserSprite phaserSprite8 = phaserSprite7.setTint(0u);
									if ((object)phaserSprite8 == null)
									{
										break;
									}
									PhaserSprite phaserSprite9 = phaserSprite8.setAlpha(0f);
									if ((object)phaserSprite9 == null)
									{
										break;
									}
									PhaserSprite leftCracks = phaserSprite9.setScale(0.5f, (float?)(object)0);
									_leftCracks = leftCracks;
									PhaserWorld instance7 = PhaserWorld.Instance;
									float2 float13 = base.position;
									if ((object)instance7 == null)
									{
										break;
									}
									PhaserSprite phaserSprite10 = instance7.AddPhaserSprite(pos, "vfx", "ground");
									if ((object)phaserSprite10 == null)
									{
										break;
									}
									PhaserSprite phaserSprite11 = phaserSprite10.setTint(0u);
									if ((object)phaserSprite11 == null)
									{
										break;
									}
									PhaserSprite phaserSprite12 = phaserSprite11.setAlpha(0f);
									if ((object)phaserSprite12 == null)
									{
										break;
									}
									PhaserSprite rightCracks = phaserSprite12.setScale(0.5f, (float?)(object)0);
									_rightCracks = rightCracks;
									SetupParticles();
									_crawlTimer = 0f;
									_directer = null;
									_isDirecterDead = false;
									List<ItemType> list2 = new List<ItemType>();
									if (list2 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v70+18]");
									if (num4 >= 0)
									{
										((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)216);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										object obj3 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v70+18]");
										bool flag4 = num5 >= 0;
										_ = 216;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rdx_v72+18]");
									if (num6 >= 0)
									{
										((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)212);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										object obj5 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rdx_v72+18]");
										bool flag5 = num7 >= 0;
										_ = 212;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rdx_v74+18]");
									if (num8 >= 0)
									{
										((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)215);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										object obj7 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rdx_v74+18]");
										bool flag6 = num9 >= 0;
										_ = 215;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									object obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rdx_v76+18]");
									if (num10 >= 0)
									{
										((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)213);
										nint num11 = 0;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										object obj9 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v136 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										nint num12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rdx_v76+18]");
										bool flag7 = num12 >= 0;
										_ = 213;
										nint num11 = 0;
									}
									list2.Add(ItemType.TP_RELIC_MASK_CITY);
									list2.Add(ItemType.TP_RELIC_MASK_STONE);
									list2.Add(ItemType.TP_RELIC_MASK_BLACK);
									_relicsToDrop = list2;
									object obj10 = this + 816;
									_droppedRelic = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
									object obj11 = 0;
									_relicDropTimer = 0f;
									_003CDirecterRevivals_003Ek__BackingField = 0;
									_003CHasRemovedWeapons_003Ek__BackingField = false;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
										bool flag8 = obj11 == null;
										obj10 = 6573110936L;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2446 @ rax_v149 (should have been resolved before IL gen)");
									_damageZoneTimer = 10f;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_11ba;
	}

	public void OnBigScytheSpawned(CoherenceSync enemy)
	{
		Enemy_TP_DeathScytheBig component = enemy.GetComponent<Enemy_TP_DeathScytheBig>();
		_currentBigScythe = component;
		TriggerDirecterBlock();
	}

	private unsafe void SetupParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_032e: Expected O, but got Ref
		//IL_0355: Expected O, but got I
		//IL_036f: Expected native int or pointer, but got O
		//IL_0389: Expected O, but got I
		//IL_03a9: Expected O, but got Ref
		//IL_03c3: Expected native int or pointer, but got O
		//IL_03dd: Expected O, but got I
		//IL_03fd: Expected O, but got Ref
		//IL_0417: Expected native int or pointer, but got O
		//IL_0431: Expected O, but got I
		//IL_0451: Expected O, but got Ref
		//IL_046b: Expected native int or pointer, but got O
		//IL_0afd: Expected O, but got I4
		//IL_0483: Expected O, but got Ref
		//IL_049d: Expected native int or pointer, but got O
		//IL_0b1a: Expected O, but got I4
		//IL_04dd: Expected O, but got I4
		//IL_050f: Expected O, but got I
		//IL_0b54: Expected O, but got I
		//IL_089b: Expected O, but got Ref
		//IL_08c2: Expected O, but got I
		//IL_08dc: Expected native int or pointer, but got O
		//IL_08f6: Expected O, but got I
		//IL_0916: Expected O, but got Ref
		//IL_0930: Expected native int or pointer, but got O
		//IL_094a: Expected O, but got I
		//IL_096a: Expected O, but got Ref
		//IL_0984: Expected native int or pointer, but got O
		//IL_099e: Expected O, but got I
		//IL_09be: Expected O, but got Ref
		//IL_09d8: Expected native int or pointer, but got O
		//IL_0b8e: Expected O, but got I
		//IL_0a10: Expected O, but got Ref
		//IL_0a2a: Expected native int or pointer, but got O
		//IL_0bc8: Expected O, but got I
		//IL_0a7b: Expected O, but got I
		//IL_0bfa: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0000");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0010");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0020");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0030");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"rock0040");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 5;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(600f, 1100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+80]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 400f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = new ParticleSystem.MinMaxCurve(400f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 2891542;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig._tint = (uint?)(object)0;
		minMaxCurve6 = new ParticleSystem.MinMaxCurve(0.1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem rockParticles = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig);
		_rockParticles = rockParticles;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version6 = list2._version + 1;
		list2._version = version6;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"rock0000");
		}
		else
		{
			int num6 = list2._size + 1;
			list2._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list2._version + 1;
		list2._version = version7;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"rock0010");
		}
		else
		{
			int num7 = list2._size + 1;
			list2._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list2._version + 1;
		list2._version = version8;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"rock0020");
		}
		else
		{
			int num8 = list2._size + 1;
			list2._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list2._version + 1;
		list2._version = version9;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"rock0030");
		}
		else
		{
			int num9 = list2._size + 1;
			list2._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list2._version + 1;
		list2._version = version10;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"rock0040");
		}
		else
		{
			int num10 = list2._size + 1;
			list2._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(600f, 1100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(50f, 400f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+160]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+170]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		_ = 0;
		_ = 0;
		_ = 2891542;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig2._tint = (uint?)(object)0;
		minMaxCurve6 = new ParticleSystem.MinMaxCurve(0.1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		particleSystemConfig2._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._on = false;
		ParticleSystem deathZoneParticles = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2);
		_deathZoneParticles = deathZoneParticles;
	}

	public void StartSequence()
	{
		//IL_0318: Expected O, but got I4
		//IL_01e4: Expected O, but got F4
		//IL_01fa: Expected O, but got F4
		//IL_0247: Expected O, but got I4
		//IL_0247: Expected O, but got I
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_02e1: Expected O, but got I
		_havingAChat = false;
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = true;
		GameManager core3 = GM.Core;
		core3._canRunTickerTimer = false;
		GameManager core4 = GM.Core;
		Stage stage = core4._stage;
		if (stage._spawnTimer != null)
		{
			stage._spawnTimer.Cancel();
		}
		GameManager core5 = GM.Core;
		PlayerOptionsData config = core5._playerOptions.Config;
		if (config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core6 = GM.Core;
			float num = core6._eggManager.RemoveBonuses();
		}
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		SoundManager._003CCurrentBgm_003Ek__BackingField = BgmType.BGM_TP_hod_DanceOfIllusions;
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		mainGameConfig._003CMusicVolume_003Ek__BackingField = 0.5f;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		SoundManager.PlayMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, soundConfig);
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0.5f, 1500f);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Vector2 center = default(Vector2);
		GM.Core.StopCamera(center, 2f);
		ProCamera2D instance = ProCamera2D.Instance;
		float num2 = default(float);
		Vector2 targetOffset = default(Vector2);
		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.AddCameraTarget(_cameraTarget, 1f, 1f, num2, targetOffset);
		Action<UISignals.ReceivedNewItemSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2F80");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v5 (Il2CppMethodInfo)+38]");
		bool flag = (nint)0 != 0;
		Action<object> callback = (Action<object>)num2;
		if (!flag)
		{
			callback = (Action<object>)num2;
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ReceivedNewItemSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ReceivedNewItemSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v53 (System.Object)+10]");
		Type signalType = default(Type);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		HandleUnlocksAtStart();
	}

	public void EndSequence()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_025b: Expected O, but got I4
		HandleUnlocksAtEnd();
		base._003CIsDead_003Ek__BackingField = true;
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GM.Core.SetAllPlayersWeaponsActive(active: false);
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 1000f);
		Action onComplete = _003C_003Ec._003C_003E9__48_0;
		if (_003C_003Ec._003C_003E9__48_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__48_0 = delegate
			{
				SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
			});
		}
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1.0500001f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action<UISignals.ReceivedNewItemSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2F80");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		bool flag2 = default(bool);
		_signalBus.UnsubscribeInternal((Type)flag2, (object)null, (object)token, flag);
		Enemy_TP_DeathScytheBig currentBigScythe = _currentBigScythe;
		if ((object)_currentBigScythe != null && ((UnityEngine.Object)currentBigScythe).m_CachedPtr != (IntPtr)0)
		{
			_currentBigScythe.Disappear();
			_currentBigScythe = null;
		}
		GM.Core.EraseEnemies(showVfx: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 540 Invalid \"Jump target not found in method: 0x1876B21A0\"");
		throw new NullReferenceException();
	}

	private unsafe void DestructionEffects()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007e: Expected O, but got I
		//IL_0933: Expected O, but got Ref
		//IL_0956: Expected native int or pointer, but got O
		//IL_0970: Expected O, but got I
		//IL_0990: Expected O, but got Ref
		//IL_09aa: Expected native int or pointer, but got O
		//IL_09c4: Expected O, but got I
		//IL_09e4: Expected O, but got Ref
		//IL_09fe: Expected native int or pointer, but got O
		//IL_0a18: Expected O, but got I
		//IL_0a38: Expected O, but got Ref
		//IL_0a52: Expected native int or pointer, but got O
		//IL_1024: Expected O, but got I4
		//IL_0a77: Expected O, but got Ref
		//IL_0a9e: Expected O, but got I
		//IL_0ab8: Expected native int or pointer, but got O
		//IL_105e: Expected O, but got I
		//IL_0af0: Expected O, but got Ref
		//IL_0b17: Expected O, but got I
		//IL_0b31: Expected native int or pointer, but got O
		//IL_1098: Expected O, but got I
		//IL_0c39: Expected I, but got O
		//IL_0cca: Expected O, but got I
		//IL_0d30: Expected O, but got I
		//IL_0d51: Expected O, but got I
		//IL_0df4: Expected I, but got O
		//IL_0e9d: Expected O, but got I
		//IL_0f03: Expected O, but got I
		//IL_0f24: Expected O, but got I
		//IL_0c5c->IL0c5c: Incompatible stack heights: 2 vs 1
		//IL_0dc8->IL0fe9: Incompatible stack heights: 1 vs 0
		//IL_0e39->IL0fe9: Incompatible stack heights: 1 vs 0
		//IL_0e17->IL0e17: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals48 = new _003C_003Ec__DisplayClass49_0();
		if (CS_0024_003C_003E8__locals48 != null)
		{
			CS_0024_003C_003E8__locals48._003C_003E4__this = this;
			GameObject gameObject = base.gameObject;
			_ = 0;
			ParticleEmitterManager particleManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
				particleManager = (ParticleEmitterManager)0;
			}
			else
			{
				particleManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			CS_0024_003C_003E8__locals48.particleManager = particleManager;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 32f;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
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
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
					}
					else
					{
						int num = list._size + 1;
						list._size = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version2 = list._version + 1;
					list._version = version2;
					string[] items2 = list._items;
					if (list._items != null)
					{
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
						}
						else
						{
							int num2 = list._size + 1;
							list._size = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version3 = list._version + 1;
						list._version = version3;
						string[] items3 = list._items;
						if (list._items != null)
						{
							if (list._size >= items3.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire21");
							}
							else
							{
								int num3 = list._size + 1;
								list._size = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version4 = list._version + 1;
							list._version = version4;
							string[] items4 = list._items;
							if (list._items != null)
							{
								if (list._size >= items4.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire22");
								}
								else
								{
									int num4 = list._size + 1;
									list._size = num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version5 = list._version + 1;
								list._version = version5;
								string[] items5 = list._items;
								if (list._items != null)
								{
									if (list._size >= items5.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire23");
									}
									else
									{
										int num5 = list._size + 1;
										list._size = num5;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version6 = list._version + 1;
									list._version = version6;
									string[] items6 = list._items;
									if (list._items != null)
									{
										if (list._size >= items6.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire24");
										}
										else
										{
											int num6 = list._size + 1;
											list._size = num6;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version7 = list._version + 1;
										list._version = version7;
										string[] items7 = list._items;
										if (list._items != null)
										{
											if (list._size >= items7.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire25");
											}
											else
											{
												int num7 = list._size + 1;
												list._size = num7;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version8 = list._version + 1;
											list._version = version8;
											string[] items8 = list._items;
											if (list._items != null)
											{
												if (list._size >= items8.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire26");
												}
												else
												{
													int num8 = list._size + 1;
													list._size = num8;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version9 = list._version + 1;
												list._version = version9;
												string[] items9 = list._items;
												if (list._items != null)
												{
													if (list._size >= items9.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire27");
													}
													else
													{
														int num9 = list._size + 1;
														list._size = num9;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version10 = list._version + 1;
													list._version = version10;
													string[] items10 = list._items;
													if (list._items != null)
													{
														if (list._size >= items10.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire28");
														}
														else
														{
															int num10 = list._size + 1;
															list._size = num10;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version11 = list._version + 1;
														list._version = version11;
														string[] items11 = list._items;
														if (list._items != null)
														{
															if (list._size >= items11.Length)
															{
																((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire29");
															}
															else
															{
																int num11 = list._size + 1;
																list._size = num11;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															if (particleSystemConfig != null)
															{
																particleSystemConfig._frame = list;
																ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
																particleSystemConfig._fps = 16;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
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
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(400f, 600f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
																_ = 0;
																particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
																_ = 0;
																_ = 5;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																particleSystemConfig._quantity = (int?)(object)0;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 2f));
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
																_ = 1065353216;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
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
																ParticleSystem pfxEmitter = CS_0024_003C_003E8__locals48.particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
																CS_0024_003C_003E8__locals48.pfxEmitter = pfxEmitter;
																Transform transform = CS_0024_003C_003E8__locals48.pfxEmitter.transform;
																bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																Vector3 value = default(Vector3);
																Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
																int num12 = base.depth;
																int num13 = num12 + 100;
																RenderingExtensions.SetDepth(CS_0024_003C_003E8__locals48.pfxEmitter, num13);
																RenderingExtensions.Start(CS_0024_003C_003E8__locals48.pfxEmitter);
																TweenConfig tweenConfig = new TweenConfig();
																object[] array = new object[1];
																if ((object)_leftHand != null)
																{
																	nint num14 = (nint)array;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj3 = default(object);
																	bool flag2 = obj3 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																tweenConfig.targets = array;
																float2 float5 = base.position;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+118]");
																float num15 = 0f - 0.5f;
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																tweenConfig.x = (float?)(object)0;
																float2 float6 = base.position;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+11C]");
																float num16 = 0f - 1f;
																_ = 0;
																_ = 1;
																tweenConfig.duration = 1000f;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																tweenConfig.y = (float?)(object)0;
																_ = 1073741824;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																tweenConfig.scale = (float?)(object)0;
																TweenCallback onUpdate = delegate
																{
																	Enemy_TP_Death enemy_TP_Death = CS_0024_003C_003E8__locals48._003C_003E4__this;
																	float extraScale = default(float);
																	CS_0024_003C_003E8__locals48._003C_003E4__this.UpdateJoints(enemy_TP_Death._leftHand, -1f, enemy_TP_Death._leftArmSprites, extraScale);
																};
																tweenConfig.onUpdate = onUpdate;
																MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																TweenConfig tweenConfig2 = new TweenConfig();
																object[] array2 = new object[1];
																if (array2 != null)
																{
																	if ((object)_rightHand != null)
																	{
																		nint num17 = (nint)array2;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj4 = default(object);
																		bool flag3 = obj4 == null;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	if (tweenConfig2 != null)
																	{
																		tweenConfig2.targets = array2;
																		float2 float7 = base.position;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+118]");
																		float num18 = 0f + 0.5f;
																		_ = 0;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																		tweenConfig2.x = (float?)(object)0;
																		float2 float8 = base.position;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+11C]");
																		float num19 = 0f - 1f;
																		_ = 0;
																		_ = 1;
																		tweenConfig2.duration = 1000f;
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																		tweenConfig2.y = (float?)(object)0;
																		_ = 1073741824;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																		tweenConfig2.scale = (float?)(object)0;
																		TweenCallback onUpdate2 = delegate
																		{
																			Enemy_TP_Death enemy_TP_Death = CS_0024_003C_003E8__locals48._003C_003E4__this;
																			float extraScale = default(float);
																			CS_0024_003C_003E8__locals48._003C_003E4__this.UpdateJoints(enemy_TP_Death._rightHand, 1f, enemy_TP_Death._rightArmSprites, extraScale);
																		};
																		tweenConfig2.onUpdate = onUpdate2;
																		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																		Action onComplete = _003C_003Ec._003C_003E9__49_0;
																		if (_003C_003Ec._003C_003E9__49_0 == null)
																		{
																			onComplete = (_003C_003Ec._003C_003E9__49_0 = delegate
																			{
																				//IL_0033: Expected F4, but got I4
																				float? volume = default(float?);
																				float rate = default(float);
																				float detune = default(float);
																				bool loop = default(bool);
																				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
																			});
																		}
																		bool useRealTime = default(bool);
																		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																		int repeat = default(int);
																		TimerType type = default(TimerType);
																		Timer timer = Timers.Register(0.125f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																		Action onComplete2 = delegate
																		{
																			//IL_00bb: Expected I, but got O
																			//IL_006b: Expected I, but got O
																			//IL_00dd: Expected O, but got I4
																			//IL_011d: Expected O, but got I4
																			//IL_012b: Expected O, but got I4
																			//IL_0180: Expected O, but got I4
																			//IL_0262: Expected I, but got O
																			//IL_0212: Expected I, but got O
																			//IL_0284: Expected O, but got I4
																			//IL_02c4: Expected O, but got I4
																			//IL_02d2: Expected O, but got I4
																			//IL_0327: Expected O, but got I4
																			//IL_0409: Expected I, but got O
																			//IL_03b9: Expected I, but got O
																			//IL_042b: Expected O, but got I4
																			//IL_046b: Expected O, but got I4
																			//IL_0479: Expected O, but got I4
																			//IL_04ce: Expected O, but got I4
																			//IL_06dd: Expected I4, but got I8
																			//IL_06e1: Expected O, but got I4
																			//IL_0560: Expected F4, but got I4
																			//IL_06f9: Expected I4, but got I8
																			//IL_06fd: Expected O, but got I4
																			//IL_072c: Expected F4, but got I4
																			//IL_0748: Expected I4, but got I8
																			//IL_074c: Expected O, but got I4
																			//IL_077b: Expected F4, but got I4
																			//IL_0797: Expected I4, but got I8
																			//IL_079b: Expected O, but got I4
																			//IL_07c9: Expected F4, but got I4
																			//IL_0603: Expected I4, but got F4
																			//IL_0603: Expected O, but got F4
																			//IL_0603: Expected I4, but got O
																			//IL_068e: Expected I4, but got F4
																			//IL_068e: Expected O, but got F4
																			//IL_068e: Expected I4, but got O
																			CS_0024_003C_003E8__locals48.pfxEmitter.Stop();
																			TweenConfig tweenConfig3 = new TweenConfig();
																			object[] array3 = new object[1];
																			Enemy_TP_Death enemy_TP_Death = CS_0024_003C_003E8__locals48._003C_003E4__this;
																			if ((object)enemy_TP_Death._leftHand != null)
																			{
																				nint num20 = (nint)array3;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj5 = default(object);
																				if (obj5 == null)
																				{
																					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																					throw ex;
																				}
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			tweenConfig3.targets = array3;
																			nint num21 = (nint)enemy_TP_Death._leftHand;
																			float2 float9 = CS_0024_003C_003E8__locals48._003C_003E4__this.position;
																			tweenConfig3.x = (float?)(object)1;
																			float2 float10 = CS_0024_003C_003E8__locals48._003C_003E4__this.position;
																			object obj6 = default(object);
																			float num22 = (float)obj6 + 10f;
																			tweenConfig3.duration = 500f;
																			tweenConfig3.y = (float?)(object)1;
																			tweenConfig3.localAngle = (float?)(object)1;
																			TweenCallback onUpdate3 = CS_0024_003C_003E8__locals48._003C_003E9__6;
																			if (CS_0024_003C_003E8__locals48._003C_003E9__6 == null)
																			{
																				TweenCallback tweenCallback = (CS_0024_003C_003E8__locals48._003C_003E9__6 = delegate
																				{
																					Enemy_TP_Death enemy_TP_Death5 = CS_0024_003C_003E8__locals48._003C_003E4__this;
																					float extraScale = default(float);
																					CS_0024_003C_003E8__locals48._003C_003E4__this.UpdateJoints(enemy_TP_Death5._leftHand, -1f, enemy_TP_Death5._leftArmSprites, extraScale);
																				});
																				object obj7 = 0;
																				num21 = 0;
																				onUpdate3 = tweenCallback;
																			}
																			tweenConfig3.onUpdate = onUpdate3;
																			MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
																			TweenConfig tweenConfig4 = new TweenConfig();
																			object[] array4 = new object[1];
																			Enemy_TP_Death enemy_TP_Death2 = CS_0024_003C_003E8__locals48._003C_003E4__this;
																			if ((object)enemy_TP_Death2._rightHand != null)
																			{
																				nint num23 = (nint)array4;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj8 = default(object);
																				if (obj8 == null)
																				{
																					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																					throw ex2;
																				}
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			tweenConfig4.targets = array4;
																			nint num24 = (nint)enemy_TP_Death2._rightHand;
																			float2 float11 = CS_0024_003C_003E8__locals48._003C_003E4__this.position;
																			tweenConfig4.x = (float?)(object)1;
																			float2 float12 = CS_0024_003C_003E8__locals48._003C_003E4__this.position;
																			float num25 = (float)obj6 + 10f;
																			tweenConfig4.duration = 500f;
																			tweenConfig4.y = (float?)(object)1;
																			tweenConfig4.localAngle = (float?)(object)1;
																			TweenCallback onUpdate4 = CS_0024_003C_003E8__locals48._003C_003E9__7;
																			if (CS_0024_003C_003E8__locals48._003C_003E9__7 == null)
																			{
																				TweenCallback tweenCallback2 = (CS_0024_003C_003E8__locals48._003C_003E9__7 = delegate
																				{
																					Enemy_TP_Death enemy_TP_Death5 = CS_0024_003C_003E8__locals48._003C_003E4__this;
																					float extraScale = default(float);
																					CS_0024_003C_003E8__locals48._003C_003E4__this.UpdateJoints(enemy_TP_Death5._rightHand, 1f, enemy_TP_Death5._rightArmSprites, extraScale);
																				});
																				object obj7 = 0;
																				num24 = 0;
																				onUpdate4 = tweenCallback2;
																			}
																			tweenConfig4.onUpdate = onUpdate4;
																			MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
																			TweenConfig tweenConfig5 = new TweenConfig();
																			object[] array5 = new object[1];
																			Enemy_TP_Death enemy_TP_Death3 = CS_0024_003C_003E8__locals48._003C_003E4__this;
																			if ((object)enemy_TP_Death3._deathCape != null)
																			{
																				nint num26 = (nint)array5;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj9 = default(object);
																				if (obj9 == null)
																				{
																					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																					throw ex3;
																				}
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			tweenConfig5.targets = array5;
																			nint num27 = (nint)enemy_TP_Death3._deathCape;
																			float2 float13 = CS_0024_003C_003E8__locals48._003C_003E4__this.position;
																			tweenConfig5.x = (float?)(object)1;
																			float2 float14 = CS_0024_003C_003E8__locals48._003C_003E4__this.position;
																			float num28 = (float)obj6 + 10f;
																			tweenConfig5.duration = 500f;
																			tweenConfig5.y = (float?)(object)1;
																			tweenConfig5.localAngle = (float?)(object)1;
																			TweenCallback onComplete3 = CS_0024_003C_003E8__locals48._003C_003E9__8;
																			if (CS_0024_003C_003E8__locals48._003C_003E9__8 == null)
																			{
																				TweenCallback tweenCallback3 = (CS_0024_003C_003E8__locals48._003C_003E9__8 = delegate
																				{
																					Enemy_TP_Death enemy_TP_Death5 = CS_0024_003C_003E8__locals48._003C_003E4__this;
																					PhaserSprite phaserSprite = enemy_TP_Death5._deathCape.setVisible(visible: false);
																				});
																				object obj7 = 0;
																				num27 = 0;
																				onComplete3 = tweenCallback3;
																			}
																			tweenConfig5.onComplete = onComplete3;
																			MultiTargetTween multiTargetTween5 = Tweens.Add(tweenConfig5);
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
																			Sprite sprite = default(Sprite);
																			ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals48._003C_003E4__this.setFrame(sprite);
																			object obj10 = UnityEngine.Random.RandomRangeInt(-200, 200);
																			float? num29 = default(float?);
																			float num30 = default(float);
																			float num31 = default(float);
																			bool flag4 = default(bool);
																			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, num29, num30, num31, flag4, 1f);
																			object obj11 = UnityEngine.Random.RandomRangeInt(-200, 200);
																			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, num29, num30, num31, flag4, 1f);
																			object obj12 = UnityEngine.Random.RandomRangeInt(-200, 200);
																			PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, num29, num30, num31, flag4, 1f);
																			object obj13 = UnityEngine.Random.RandomRangeInt(-200, 200);
																			PlaySoundResult playSoundResult4 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, num29, num30, num31, flag4, 1f);
																			Enemy_TP_Death enemy_TP_Death4 = CS_0024_003C_003E8__locals48._003C_003E4__this;
																			enemy_TP_Death4._SpriteAnimation.SetAnimation("ScreamLoop");
																			Action onComplete4 = CS_0024_003C_003E8__locals48._003C_003E9__4;
																			if (CS_0024_003C_003E8__locals48._003C_003E9__4 == null)
																			{
																				onComplete4 = (CS_0024_003C_003E8__locals48._003C_003E9__4 = delegate
																				{
																					//IL_002c: Expected I, but got O
																					//IL_0090: Expected O, but got I4
																					//IL_009e: Expected O, but got I4
																					TweenConfig tweenConfig6 = new TweenConfig();
																					object[] array6 = new object[1];
																					if ((object)CS_0024_003C_003E8__locals48._003C_003E4__this != null)
																					{
																						nint num32 = (nint)array6;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																						object obj14 = default(object);
																						if (obj14 == null)
																						{
																							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
																							throw ex4;
																						}
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					tweenConfig6.targets = array6;
																					tweenConfig6.duration = 500f;
																					tweenConfig6.scale = (float?)(object)1;
																					tweenConfig6.localAngle = (float?)(object)1;
																					MultiTargetTween multiTargetTween6 = Tweens.Add(tweenConfig6);
																				});
																			}
																			Timer timer3 = Timers.Register(1f, onComplete4, null, isLooped: false, (byte)(int)num29 != 0, (MonoBehaviour)num30, (int)num31, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
																			Action onComplete5 = CS_0024_003C_003E8__locals48._003C_003E9__5;
																			if (CS_0024_003C_003E8__locals48._003C_003E9__5 == null)
																			{
																				onComplete5 = (CS_0024_003C_003E8__locals48._003C_003E9__5 = delegate
																				{
																					UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals48.particleManager, 0f);
																					GameObject obj14 = CS_0024_003C_003E8__locals48.pfxEmitter.gameObject;
																					UnityEngine.Object.Destroy(obj14, 0f);
																					CS_0024_003C_003E8__locals48._003C_003E4__this.ActuallyRemove();
																				});
																			}
																			Timer timer4 = Timers.Register(4f, onComplete5, null, isLooped: false, (byte)(int)num29 != 0, (MonoBehaviour)num30, (int)num31, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
																		};
																		Timer timer2 = Timers.Register(5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
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
		throw new NullReferenceException();
	}

	private void ActuallyRemove()
	{
		//IL_00bc: Expected F4, but got I4
		//IL_00f3: Expected I4, but got F4
		//IL_00f3: Expected O, but got F4
		//IL_00f3: Expected I4, but got O
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveCameraTarget(_cameraTarget, 2f);
		_gameManager.AddAllPlayersAsCameraTargets(2f);
		_gameManager.SetPlayerWorldBoundCollision(on: false);
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = false;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_StageClear, 10000f, 1, 0f, num, num2, num3, flag, 1f);
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 5000f);
		Action onComplete = delegate
		{
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
			FadeOut();
		};
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		Enemy_TP_DeathScytheBig currentBigScythe = _currentBigScythe;
		if ((object)_currentBigScythe != null && ((UnityEngine.Object)currentBigScythe).m_CachedPtr != (IntPtr)0)
		{
			Enemy_TP_DeathScytheBig currentBigScythe2 = _currentBigScythe;
			if (currentBigScythe2._swingTween != null)
			{
				currentBigScythe2._swingTween.Kill();
			}
			if (currentBigScythe2._warningTween != null)
			{
				currentBigScythe2._warningTween.Kill();
			}
			if (currentBigScythe2._swingFadeATween != null)
			{
				currentBigScythe2._swingFadeATween.Kill();
			}
			if (currentBigScythe2._swingFadeBTween != null)
			{
				currentBigScythe2._swingFadeBTween.Kill();
			}
		}
		GM.Core.EraseEnemies(showVfx: false);
		Cleanup();
		base.Despawn();
	}

	private void FadeOut()
	{
		//IL_00c3: Expected O, but got I4
		//IL_018d: Expected I, but got O
		//IL_01f1: Expected O, but got I4
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._003CCanPause_003Ek__BackingField = false;
		GameManager core3 = GM.Core;
		core3.BlockConnectionErrorPopups = true;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "WhiteDot");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		PhaserSprite phaserSprite2 = phaserSprite.setScale(renderer.screenWidthPixels, (float?)(object)1);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
		PhaserSprite phaserSprite4 = phaserSprite3.setTint(0u);
		Camera main = Camera.main;
		Transform parent = main.transform;
		Transform transform = phaserSprite4.transform;
		transform.SetParent(parent, worldPositionStays: true);
		PhaserSprite phaserSprite5 = phaserSprite4.setDepth(10000);
		phaserSprite5._spriteRenderer.sortingLayerName = "UI";
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 5000f;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = SwitchToCredits;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void OnItemReceived(UISignals.ReceivedNewItemSignal signal)
	{
		//IL_008e: Expected O, but got I4
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Expected O, but got Unknown
		//IL_0fd3: Expected O, but got I
		//IL_11be: Expected I, but got O
		//IL_01fa: Expected F4, but got I4
		//IL_0779: Expected O, but got I4
		//IL_08ad: Expected F4, but got I4
		//IL_08b2: Expected native int or pointer, but got F4
		//IL_08e6: Expected native int or pointer, but got F4
		//IL_0909: Invalid comparison between F4 and I
		//IL_0924: Expected native int or pointer, but got F4
		//IL_095b: Expected I, but got I8
		//IL_0968: Expected I, but got I8
		//IL_0971: Expected O, but got I4
		//IL_0988: Expected I, but got O
		//IL_099e: Expected O, but got I
		//IL_09a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ac: Expected O, but got Unknown
		//IL_0296: Expected I, but got O
		//IL_0a44: Expected I, but got I8
		//IL_09f0: Expected I, but got I8
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected F4, but got Unknown
		//IL_0646: Expected O, but got I4
		//IL_12d8: Expected I, but got O
		//IL_12f3: Expected O, but got I4
		//IL_130a: Expected I, but got I8
		//IL_1320: Expected I, but got I8
		//IL_1331: Expected O, but got I4
		//IL_0a0b: Expected I, but got I8
		//IL_0a18: Expected I, but got I8
		//IL_0a92: Expected I, but got O
		//IL_0aa8: Expected O, but got I
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab6: Expected O, but got Unknown
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Expected O, but got Unknown
		//IL_02cd: Expected O, but got I
		//IL_0b8f: Expected I, but got O
		//IL_0ba5: Expected O, but got I
		//IL_0bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb3: Expected O, but got Unknown
		//IL_0b34: Expected I, but got O
		//IL_0c8c: Expected I, but got O
		//IL_0ca2: Expected O, but got I
		//IL_0cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Expected O, but got Unknown
		//IL_0c31: Expected I, but got O
		//IL_0d89: Expected I, but got O
		//IL_0d9f: Expected O, but got I
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dad: Expected O, but got Unknown
		//IL_0d2e: Expected I, but got O
		//IL_02ff: Expected O, but got I
		//IL_0e86: Expected I, but got O
		//IL_0e9c: Expected O, but got I
		//IL_0ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaa: Expected O, but got Unknown
		//IL_0e2b: Expected I, but got O
		//IL_0334: Expected O, but got I
		//IL_0f0b: Expected I, but got O
		//IL_03ba: Expected O, but got I
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected F4, but got Unknown
		//IL_03fd: Expected O, but got I4
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_123b->IL161a: Incompatible stack heights: 2 vs 0
		//IL_00a4->IL0ff4: Incompatible stack heights: 2 vs 0
		//IL_09f9->IL12c6: Incompatible stack heights: 0 vs 1
		//IL_1336->IL0a49: Incompatible stack heights: 1 vs 0
		//IL_0a1d->IL12ea: Incompatible stack heights: 0 vs 1
		//IL_0af6->IL0b22: Incompatible stack heights: 0 vs 1
		//IL_13ca->IL0b46: Incompatible stack heights: 1 vs 0
		//IL_0bf3->IL0c1f: Incompatible stack heights: 0 vs 1
		//IL_0b08->IL13a2: Incompatible stack heights: 0 vs 1
		//IL_145e->IL0c43: Incompatible stack heights: 1 vs 0
		//IL_0cf0->IL0d1c: Incompatible stack heights: 0 vs 1
		//IL_0c05->IL1436: Incompatible stack heights: 0 vs 1
		//IL_14f2->IL0d40: Incompatible stack heights: 1 vs 0
		//IL_0ded->IL0e19: Incompatible stack heights: 0 vs 1
		//IL_0d02->IL14ca: Incompatible stack heights: 0 vs 1
		//IL_1586->IL0e3d: Incompatible stack heights: 1 vs 0
		//IL_0dff->IL155e: Incompatible stack heights: 0 vs 1
		//IL_0f10->IL15f2: Incompatible stack heights: 1 vs 0
		//IL_0eec->IL0eec: Incompatible stack heights: 0 vs 1
		bool flag3 = default(bool);
		float durationMillis;
		float volume;
		Action onComplete;
		nint extra_arg;
		Action action;
		nint num13;
		object obj11;
		if ((nint)signal == 216)
		{
			object core = GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v109 (System.Object)+2A0]");
				if ((nint)0 != 0)
				{
					List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
					while (enumerator.MoveNext())
					{
						UISignals.ReceivedNewItemSignal receivedNewItemSignal = (UISignals.ReceivedNewItemSignal)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rbx_v43 (VampireSurvivors.Signals.UISignals+ReceivedNewItemSignal)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rbx_v43 (VampireSurvivors.Signals.UISignals+ReceivedNewItemSignal)+10]");
						Behaviour.set_enabled_Injected((IntPtr)0, true);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rbx_v43 (VampireSurvivors.Signals.UISignals+ReceivedNewItemSignal)+D0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rbx_v43 (VampireSurvivors.Signals.UISignals+ReceivedNewItemSignal)+D0]");
						bool flag2 = (nint)0 == 0;
						_ = 0;
					}
					return;
				}
			}
		}
		else if ((nint)signal != 212)
		{
			if ((nint)signal != 215)
			{
				Vector2 pos = default(Vector2);
				if ((nint)signal != 213)
				{
					if ((nint)signal != 214)
					{
						if ((nint)signal != 217)
						{
							if ((nint)signal == 218)
							{
								BlackDiskCutscene._003C_BlackDiskCutscene_003Ed__0 obj2 = null;
								obj2._003C_003E1__state = 0;
								obj2.death = this;
								Coroutine coroutine = StartCoroutine(obj2);
							}
							return;
						}
						if (_signalBus != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0860");
							return;
						}
					}
					else
					{
						object core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r9_v102 (System.Object)+2A0]");
							if ((nint)0 != 0)
							{
								List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
								while (enumerator2.MoveNext())
								{
									float num = 0f;
									_ = 0;
									_ = 1;
								}
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null && core3._levelUpFactory != null)
								{
									core3._levelUpFactory.CalculateXpFactor();
									if (_signalBus != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA53D0");
										if ((object)GM.Core != null)
										{
											nint num2 = (nint)typeof(GM);
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v88 (Il2CppMethodInfo)+B8]");
												object obj3 = 0;
												if (obj3 != null)
												{
													object s_scene2 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r9_v104 (System.Object)+28]");
														object obj4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r9_v104 (System.Object)+28]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v88 (Il2CppMethodInfo)+B8]");
															object obj5 = 0;
															if (obj5 != null)
															{
																PhaserScene s_scene3 = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null)
																{
																	PhaserScene.Renderer renderer = s_scene3._renderer;
																	if (s_scene3._renderer != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rax_v308+10]");
																		float maxInclusive = 0f * 0.4f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rax_v308+10]");
																		nint num3 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																		object obj6 = num3 ^ 0;
																		float minInclusive = (float)obj6 * 0.4f;
																		float height = renderer.height;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
																		float num4 = height ^ 0;
																		float minInclusive2 = num4 * 0.8f;
																		UISignals.ReceivedNewItemSignal receivedNewItemSignal2 = (UISignals.ReceivedNewItemSignal)0;
																		while (true)
																		{
																			float num5 = UnityEngine.Random.Range(minInclusive, maxInclusive);
																			float num6 = UnityEngine.Random.Range(minInclusive2, num4);
																			if ((object)GM.Core == null)
																			{
																				break;
																			}
																			GM.Core.MakeGem(pos, 1f);
																			receivedNewItemSignal2 = (UISignals.ReceivedNewItemSignal)(receivedNewItemSignal2 + 1);
																			if ((nint)receivedNewItemSignal2 < 100)
																			{
																				continue;
																			}
																			goto IL_044b;
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
				else if ((object)GM.Core != null)
				{
					PhaserScene phaserScene = GM.Core.scene;
					if (phaserScene != null)
					{
						PhaserScene.Renderer renderer2 = phaserScene._renderer;
						if (phaserScene._renderer != null && (object)GM.Core != null)
						{
							PhaserScene phaserScene2 = GM.Core.scene;
							if (phaserScene2 != null)
							{
								PhaserScene.Renderer renderer3 = phaserScene2._renderer;
								if (phaserScene2._renderer != null && (object)GM.Core != null)
								{
									PhaserScene phaserScene3 = GM.Core.scene;
									if (phaserScene3 != null)
									{
										PhaserScene.Renderer renderer4 = phaserScene3._renderer;
										if (phaserScene3._renderer != null)
										{
											float maxInclusive2 = renderer3.width * 0.4f;
											float width = renderer3.width;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
											object obj7 = width ^ 0;
											float minInclusive3 = (float)obj7 * 0.4f;
											float height2 = renderer4.height;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
											float num7 = height2 ^ 0;
											float minInclusive4 = num7 * 0.8f;
											UISignals.ReceivedNewItemSignal receivedNewItemSignal3 = (UISignals.ReceivedNewItemSignal)0;
											while (true)
											{
												float num8 = UnityEngine.Random.Range(minInclusive3, maxInclusive2);
												float num9 = UnityEngine.Random.Range(minInclusive4, num7);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v277 (PhaserScene+Renderer)+38]");
												float num10 = 0f + num9;
												if ((object)GM.Core == null)
												{
													break;
												}
												GM.Core.MakeGem(pos, 1f);
												receivedNewItemSignal3 = (UISignals.ReceivedNewItemSignal)(receivedNewItemSignal3 + 1);
												if ((nint)receivedNewItemSignal3 < 100)
												{
													continue;
												}
												goto IL_068f;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj9 = default(object);
				object obj8 = obj9 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				UISignals.ReceivedNewItemSignal receivedNewItemSignal4 = default(UISignals.ReceivedNewItemSignal);
				UISignals.ReceivedNewItemSignal signalType = receivedNewItemSignal4;
				object obj10 = default(object);
				object signal2 = (IntPtr)obj10;
				_signalBus.InternalFire((Type)signalType, signal2, (object)null, flag3);
				if ((object)GM.Core != null)
				{
					GM.Core.SetAllPlayersWeaponsActive(active: true);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876C0040");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					BgmType bgmType = default(BgmType);
					SoundManager.PlayMusic(bgmType, soundConfig);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
					durationMillis = 5000f;
					volume = 0.125f;
					goto IL_11f8;
				}
			}
		}
		else
		{
			object core4 = GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ r9_v19 (System.Object)+2A0]");
				if ((nint)0 != 0)
				{
					List<CharacterController>.Enumerator enumerator3 = default(List<CharacterController>.Enumerator);
					while (enumerator3.MoveNext())
					{
						ArcadeSprite arcadeSprite = null;
						((ArcadeSprite)null).CheckRenderer();
						Enemy_TP_Death spriteRenderer = (Enemy_TP_Death)(object)arcadeSprite._spriteRenderer;
						bool flag4 = (object)arcadeSprite._spriteRenderer == null;
						bool flag5 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
						Renderer.set_enabled_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, true);
					}
					if ((object)GM.Core != null)
					{
						GM.Core.TogglePlayerHealthBar(visible: true);
						object core5 = GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v21 (System.Object)+2A0]");
							if ((nint)0 != 0)
							{
								List<CharacterController>.Enumerator enumerator4 = default(List<CharacterController>.Enumerator);
								while (enumerator4.MoveNext())
								{
									float num11 = 0f;
									float value = ((float*)(nint)num11)->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2595 @ rdx_v60 (System.Single)+558] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v21 (System.Object)+2A0]");
									float num12 = 0f * 0.5f;
									float value2 = ((float*)(nint)num11)->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2601 @ rdx_v62 (System.Single)+558] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v21 (System.Object)+2A0]");
									if (num12 > 0f)
									{
										float value3 = ((float*)(nint)num11)->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2630 @ rdx_v64 (System.Single)+558] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v21 (System.Object)+2A0]");
										_ = 0;
									}
								}
								onComplete = _003C_003Ec._003C_003E9__52_0;
								if (_003C_003Ec._003C_003E9__52_0 != null)
								{
									extra_arg = unchecked((nint)6447293568L);
									num13 = unchecked((nint)6447293664L);
									obj11 = 24;
									goto IL_0a49;
								}
								action = null;
								nint num14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2254 @ r10_v19 (Il2CppMethodInfo)+8]");
								((Delegate)action).method_ptr = (IntPtr)0;
								((Delegate)action).method = (nint)__ldftn(_003C_003Ec._003COnItemReceived_003Eb__52_0);
								((Delegate)action).m_target = _003C_003Ec._003C_003E9;
								((Delegate)action).method_code = (IntPtr)action;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2254 @ r10_v19 (Il2CppMethodInfo)+4C]");
								object obj12 = (nint)0 >> 4;
								object obj13 = obj12 & 1;
								nint num15;
								if (obj13 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2254 @ r10_v19 (Il2CppMethodInfo)+52]");
									bool flag6 = (nint)0 != 0;
									num13 = unchecked((nint)6447293664L);
									if (!flag6)
									{
										num13 = unchecked((nint)6447293664L);
										num15 = unchecked((nint)6447293664L);
										goto IL_12ea;
									}
								}
								else
								{
									bool flag7 = _003C_003Ec._003C_003E9 == null;
									num13 = unchecked((nint)6447293664L);
								}
								((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
								num15 = ((Delegate)action).method_ptr;
								goto IL_12ea;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_1143:
		BgmType bgmType2;
		SoundManager.FadeMusic(bgmType2, volume, durationMillis);
		return;
		IL_13a2:
		Action action2;
		((Delegate)action2).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__52_1 = action2;
		Action onComplete2 = action2;
		goto IL_0b46;
		IL_0f10:
		Action onComplete3;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1.5000001f, onComplete3, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_1436:
		Action action3;
		((Delegate)action3).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__52_2 = action3;
		Action onComplete4 = action3;
		goto IL_0c43;
		IL_0e3d:
		Action onComplete5;
		Timer timer2 = Timers.Register(1.25f, onComplete5, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		onComplete3 = _003C_003Ec._003C_003E9__52_5;
		if (_003C_003Ec._003C_003E9__52_5 != null)
		{
			goto IL_0f10;
		}
		Action action4 = null;
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3536 @ r10_v14 (Il2CppMethodInfo)+8]");
		((Delegate)action4).method_ptr = (IntPtr)0;
		((Delegate)action4).method = (nint)__ldftn(_003C_003Ec._003COnItemReceived_003Eb__52_5);
		((Delegate)action4).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action4).method_code = (IntPtr)action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3536 @ r10_v14 (Il2CppMethodInfo)+4C]");
		object obj14 = (nint)0 >> 4;
		object obj15 = obj14 & 1;
		if (obj15 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3536 @ r10_v14 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				goto IL_15f2;
			}
		}
		else
		{
			bool flag8 = _003C_003Ec._003C_003E9 == null;
		}
		num13 = ((Delegate)action4).method_ptr;
		((Delegate)action4).method_code = (IntPtr)((Delegate)action4).m_target;
		goto IL_15f2;
		IL_0a49:
		Timer timer3 = Timers.Register(0.25f, onComplete, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		onComplete2 = _003C_003Ec._003C_003E9__52_1;
		if (_003C_003Ec._003C_003E9__52_1 != null)
		{
			goto IL_0b46;
		}
		action2 = null;
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2505 @ r10_v18 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(_003C_003Ec._003COnItemReceived_003Eb__52_1);
		((Delegate)action2).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2505 @ r10_v18 (Il2CppMethodInfo)+4C]");
		object obj16 = (nint)0 >> 4;
		object obj17 = obj16 & 1;
		IntPtr intPtr;
		if (obj17 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2505 @ r10_v18 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				intPtr = num13;
				goto IL_13a2;
			}
		}
		else
		{
			bool flag9 = _003C_003Ec._003C_003E9 == null;
		}
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		intPtr = ((Delegate)action2).method_ptr;
		goto IL_13a2;
		IL_14ca:
		Action action5;
		((Delegate)action5).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__52_3 = action5;
		Action onComplete6 = action5;
		goto IL_0d40;
		IL_0d40:
		Timer timer4 = Timers.Register(1f, onComplete6, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		onComplete5 = _003C_003Ec._003C_003E9__52_4;
		if (_003C_003Ec._003C_003E9__52_4 != null)
		{
			goto IL_0e3d;
		}
		Action action6 = null;
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3231 @ r10_v15 (Il2CppMethodInfo)+8]");
		((Delegate)action6).method_ptr = (IntPtr)0;
		((Delegate)action6).method = (nint)__ldftn(_003C_003Ec._003COnItemReceived_003Eb__52_4);
		((Delegate)action6).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action6).method_code = (IntPtr)action6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3231 @ r10_v15 (Il2CppMethodInfo)+4C]");
		object obj18 = (nint)0 >> 4;
		object obj19 = obj18 & 1;
		IntPtr intPtr2;
		if (obj19 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3231 @ r10_v15 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				intPtr2 = num13;
				goto IL_155e;
			}
		}
		else
		{
			bool flag10 = _003C_003Ec._003C_003E9 == null;
		}
		((Delegate)action6).method_code = (IntPtr)((Delegate)action6).m_target;
		intPtr2 = ((Delegate)action6).method_ptr;
		goto IL_155e;
		IL_044b:
		bgmType2 = SoundManager._003CCurrentBgm_003Ek__BackingField;
		durationMillis = 5000f;
		volume = 0.5f;
		goto IL_1143;
		IL_0b46:
		Timer timer5 = Timers.Register(0.5f, onComplete2, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		onComplete4 = _003C_003Ec._003C_003E9__52_2;
		if (_003C_003Ec._003C_003E9__52_2 != null)
		{
			goto IL_0c43;
		}
		action3 = null;
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2723 @ r10_v17 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(_003C_003Ec._003COnItemReceived_003Eb__52_2);
		((Delegate)action3).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2723 @ r10_v17 (Il2CppMethodInfo)+4C]");
		object obj20 = (nint)0 >> 4;
		object obj21 = obj20 & 1;
		IntPtr intPtr3;
		if (obj21 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2723 @ r10_v17 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				intPtr3 = num13;
				goto IL_1436;
			}
		}
		else
		{
			bool flag11 = _003C_003Ec._003C_003E9 == null;
		}
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		intPtr3 = ((Delegate)action3).method_ptr;
		goto IL_1436;
		IL_11f8:
		BgmType bgmType3 = default(BgmType);
		bgmType2 = bgmType3;
		goto IL_1143;
		IL_068f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		durationMillis = 5000f;
		volume = 0.25f;
		goto IL_11f8;
		IL_155e:
		((Delegate)action6).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__52_4 = action6;
		onComplete5 = action6;
		goto IL_0e3d;
		IL_0c43:
		Timer timer6 = Timers.Register(0.75000006f, onComplete4, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		onComplete6 = _003C_003Ec._003C_003E9__52_3;
		if (_003C_003Ec._003C_003E9__52_3 != null)
		{
			goto IL_0d40;
		}
		action5 = null;
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2950 @ r10_v16 (Il2CppMethodInfo)+8]");
		((Delegate)action5).method_ptr = (IntPtr)0;
		((Delegate)action5).method = (nint)__ldftn(_003C_003Ec._003COnItemReceived_003Eb__52_3);
		((Delegate)action5).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action5).method_code = (IntPtr)action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2950 @ r10_v16 (Il2CppMethodInfo)+4C]");
		object obj22 = (nint)0 >> 4;
		object obj23 = obj22 & 1;
		IntPtr intPtr4;
		if (obj23 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2950 @ r10_v16 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				intPtr4 = num13;
				goto IL_14ca;
			}
		}
		else
		{
			bool flag12 = _003C_003Ec._003C_003E9 == null;
		}
		((Delegate)action5).method_code = (IntPtr)((Delegate)action5).m_target;
		intPtr4 = ((Delegate)action5).method_ptr;
		goto IL_14ca;
		IL_12ea:
		object obj24 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__52_0 = action;
		extra_arg = unchecked((nint)6447293568L);
		onComplete = action;
		obj11 = 24;
		goto IL_0a49;
		IL_15f2:
		((Delegate)action4).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__52_5 = action4;
		onComplete3 = action4;
		goto IL_0f10;
	}

	public void RunBlackDiskCutscene()
	{
		BlackDiskCutscene._003C_BlackDiskCutscene_003Ed__0 obj = null;
		obj._003C_003E1__state = 0;
		obj.death = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void SwitchToCredits()
	{
		OnlineErrorManager.CloseErrorPopupIfExists();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3060");
		SoundManager._003CAllowUIFades_003Ek__BackingField = true;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			mainGameConfig._003CShowTPCredits_003Ek__BackingField = true;
		}
		GameManager core2 = GM.Core;
		core2._hideLoadingVisuals = true;
		int num = DG.Tweening.Core.TweenManager.DespawnAll();
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		GameManager core3 = GM.Core;
		Stage stage = core3._stage;
		if (stage._lobbiesManager != null)
		{
			GameManager core4 = GM.Core;
			Stage stage2 = core4._stage;
			LobbiesManager lobbiesManager = stage2._lobbiesManager;
			if (lobbiesManager._activeLobby != null)
			{
				LobbySession activeLobby = lobbiesManager._activeLobby;
				if (!activeLobby._003CIsDisposed_003Ek__BackingField)
				{
					GameManager core5 = GM.Core;
					Stage stage3 = core5._stage;
					Task<bool> task = stage3._lobbiesManager.LeaveLobby();
				}
			}
		}
		GM.Core.ResetGameToMenu();
	}

	private void HandleUnlocksAtStart()
	{
		//IL_0154: Expected F4, but got I4
		if (!GM.Core.HasWeaponInPlay(WeaponType.TP_CLOCKTOWER_WEAPON))
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj != -1)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (core2._playerOptions.UnlockSecret(SecretType.tp_death, config2))
			{
				GameManager core3 = GM.Core;
				core3._playerOptions.UnlockCharacter(CharacterType.TP_DEATH);
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ThingFound, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				GameManager core4 = GM.Core;
				core4._playerOptions.Save();
			}
		}
	}

	private void HandleUnlocksAtEnd()
	{
		//IL_0598: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_05f2: Expected O, but got I
		//IL_014d: Expected O, but got I
		//IL_06c6: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0720: Expected O, but got I
		//IL_027b: Expected O, but got I
		//IL_031f: Expected O, but got I4
		//IL_033d: Expected O, but got I
		GameManager core = GM.Core;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			PlayerOptions playerOptions = core._playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			List<CharacterType> list = mainGameConfig._003CUnlockedCharacters_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					goto IL_07d2;
				}
			}
			List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)mainGameConfig._003CUnlockedCharacters_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v71 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v71 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v71 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r8_v37+18]");
			if (num >= 0)
			{
				list2.AddWithResize((System.Int32Enum)209);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v71 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj3 = (nint)0 + (nint)1;
				_ = 209;
			}
			goto IL_07d2;
		}
		PlayerOptions playerOptions2 = core._playerOptions;
		PlayerOptionsData currentAdventureSaveData = playerOptions2._currentAdventureSaveData;
		List<CharacterType> list3 = currentAdventureSaveData._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				goto IL_0800;
			}
		}
		List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)currentAdventureSaveData._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r8_v15+18]");
		if (num2 >= 0)
		{
			list4.AddWithResize((System.Int32Enum)209);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 209;
		}
		goto IL_0800;
		IL_03ad:
		GameManager core2 = GM.Core;
		PlayerOptions playerOptions3 = core2._playerOptions;
		PlayerOptionsData mainGameConfig2 = playerOptions3._mainGameConfig;
		int num3 = mainGameConfig2._003CRunItemsPickupCount_003Ek__BackingField.FindEntry(ItemType.TP_RELIC_BLACK_DISK);
		bool flag = num3 < 0;
		GameManager core3 = GM.Core;
		if (!flag)
		{
			PlayerOptions playerOptions4 = core3._playerOptions;
			PlayerOptionsData mainGameConfig3 = playerOptions4._mainGameConfig;
			int num4 = mainGameConfig3._003CRunItemsPickupCount_003Ek__BackingField.get_Item(ItemType.TP_RELIC_BLACK_DISK);
			int value = num4 + 1;
			bool flag2 = ((Dictionary<System.Int32Enum, int>)(object)mainGameConfig3._003CRunItemsPickupCount_003Ek__BackingField).TryInsert((System.Int32Enum)219, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
		else
		{
			PlayerOptions playerOptions5 = core3._playerOptions;
			PlayerOptionsData mainGameConfig4 = playerOptions5._mainGameConfig;
			bool flag3 = ((Dictionary<System.Int32Enum, int>)(object)mainGameConfig4._003CRunItemsPickupCount_003Ek__BackingField).TryInsert((System.Int32Enum)219, 1, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		goto IL_07a1;
		IL_07e0:
		GameManager core4 = GM.Core;
		PlayerOptions playerOptions6 = core4._playerOptions;
		PlayerOptionsData mainGameConfig5 = playerOptions6._mainGameConfig;
		_playerOptions.TrackEnemyKill(EnemyType.TP_BOSS_DEATH, playerOptions6._mainGameConfig);
		GameManager core5 = GM.Core;
		PlayerOptions playerOptions7 = core5._playerOptions;
		PlayerOptionsData mainGameConfig6 = playerOptions7._mainGameConfig;
		List<ItemType> list5 = mainGameConfig6._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag4 = (nint)0 == 0;
		object obj7 = 0;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj8 = default(object);
			bool flag5 = (nint)obj8 != -1;
			mainGameConfig5 = null;
			if (flag5)
			{
				goto IL_03ad;
			}
		}
		GameManager core6 = GM.Core;
		PlayerOptions playerOptions8 = core6._playerOptions;
		PlayerOptionsData mainGameConfig7 = playerOptions8._mainGameConfig;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
		goto IL_03ad;
		IL_080e:
		GameManager core7 = GM.Core;
		PlayerOptions playerOptions9 = core7._playerOptions;
		_playerOptions.TrackEnemyKill(EnemyType.TP_BOSS_DEATH, playerOptions9._currentAdventureSaveData);
		GameManager core8 = GM.Core;
		List<AchievementData> list6 = core8._achievementManager.CheckAllAchievements();
		GameManager core9 = GM.Core;
		core9._achievementManager.UnlockAchievementsAndGiveRewards();
		goto IL_07a1;
		IL_07d2:
		GameManager core10 = GM.Core;
		PlayerOptions playerOptions10 = core10._playerOptions;
		PlayerOptionsData mainGameConfig8 = playerOptions10._mainGameConfig;
		List<CharacterType> list7 = mainGameConfig8._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj9 = default(object);
			if ((nint)obj9 != -1)
			{
				goto IL_07e0;
			}
		}
		List<System.Int32Enum> list8 = (List<System.Int32Enum>)(object)mainGameConfig8._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v66 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v66 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v66 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ r8_v32+18]");
		if (num5 >= 0)
		{
			list8.AddWithResize((System.Int32Enum)209);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v66 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj11 = (nint)0 + (nint)1;
			_ = 209;
		}
		goto IL_07e0;
		IL_07a1:
		GameManager core11 = GM.Core;
		core11._playerOptions.Save();
		return;
		IL_0800:
		GameManager core12 = GM.Core;
		PlayerOptions playerOptions11 = core12._playerOptions;
		PlayerOptionsData currentAdventureSaveData2 = playerOptions11._currentAdventureSaveData;
		List<CharacterType> list9 = currentAdventureSaveData2._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj12 = default(object);
			if ((nint)obj12 != -1)
			{
				goto IL_080e;
			}
		}
		List<System.Int32Enum> list10 = (List<System.Int32Enum>)(object)currentAdventureSaveData2._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ r8_v10+18]");
		if (num6 >= 0)
		{
			list10.AddWithResize((System.Int32Enum)209);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 209;
		}
		goto IL_080e;
	}

	protected override void Die()
	{
		TriggerDeath();
	}

	public override void Disappear()
	{
		TriggerDeath();
	}

	private void TriggerDeath()
	{
		//IL_0101: Expected O, but got I4
		bool flag = !base._003CIsDead_003Ek__BackingField;
		object obj = _hasSpawnedAllies & flag;
		if (obj != null && _canDie && _coherenceSync.HasStateAuthority && !_sentDeathCommand)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				EndSequence();
				return;
			}
			_sentDeathCommand = true;
			Action action = EndSequence;
			bool flag2 = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
	}

	protected override void OnUpdate()
	{
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0482: Expected O, but got I
		//IL_04b7: Expected O, but got I
		//IL_14ab: Expected F4, but got I4
		//IL_14b3: Expected I4, but got F4
		//IL_0128: Expected O, but got I
		//IL_013b: Expected O, but got F4
		//IL_159e: Expected F4, but got I4
		//IL_03b8: Expected F4, but got I4
		//IL_03c0: Expected I4, but got F4
		//IL_1530: Expected O, but got I4
		//IL_0411: Expected F4, but got I4
		//IL_0a2a: Expected F4, but got I4
		//IL_01c1: Expected O, but got I8
		//IL_05cb: Expected F4, but got I4
		//IL_05f5: Expected F4, but got I4
		//IL_0a7f: Expected F4, but got I4
		//IL_0616: Expected I4, but got I8
		//IL_0a9e: Expected F4, but got I4
		//IL_064d: Expected F4, but got I4
		//IL_0664: Expected I4, but got I8
		//IL_078d: Expected I4, but got F4
		//IL_078d: Expected O, but got F4
		//IL_078d: Expected I4, but got O
		//IL_069b: Expected F4, but got I4
		//IL_06d7: Expected F4, but got I4
		//IL_06ea: Expected F4, but got I4
		//IL_0823: Expected I4, but got F4
		//IL_0260: Expected O, but got F4
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0e51: Expected O, but got I
		//IL_0e86: Expected O, but got I
		//IL_16c6: Expected O, but got I4
		//IL_0c74: Expected I4, but got O
		//IL_1637: Expected O, but got I
		//IL_1647: Expected O, but got I
		//IL_0c89: Expected O, but got I
		//IL_16f3: Expected O, but got I
		//IL_0fd6: Invalid comparison between I4 and F4
		//IL_0f15: Expected O, but got I
		//IL_0f8d: Expected O, but got I
		//IL_10f0: Expected O, but got F4
		//IL_1199: Expected O, but got F4
		//IL_11e9: Expected O, but got F4
		//IL_1548->IL09eb: Incompatible stack heights: 1 vs 0
		//IL_0715->IL0aa3: Incompatible stack heights: 1 vs 0
		//IL_0734->IL1313: Incompatible stack heights: 1 vs 0
		//IL_0588->IL1313: Incompatible stack heights: 1 vs 0
		//IL_06b9->IL1313: Incompatible stack heights: 1 vs 0
		//IL_07c3->IL1313: Incompatible stack heights: 1 vs 0
		//IL_0802->IL1313: Incompatible stack heights: 1 vs 0
		//IL_1579->IL0aa3: Incompatible stack heights: 1 vs 0
		//IL_0871->IL0aa3: Incompatible stack heights: 1 vs 0
		//IL_08a4->IL1313: Incompatible stack heights: 1 vs 0
		//IL_08ed->IL1313: Incompatible stack heights: 1 vs 0
		//IL_090f->IL1313: Incompatible stack heights: 1 vs 0
		//IL_16de->IL15ac: Incompatible stack heights: 1 vs 0
		//IL_0ed2->IL15ac: Incompatible stack heights: 1 vs 0
		//IL_0982->IL1313: Incompatible stack heights: 1 vs 0
		//IL_0948->IL0aa3: Incompatible stack heights: 1 vs 0
		//IL_0efb->IL1313: Incompatible stack heights: 1 vs 0
		//IL_09a1->IL1313: Incompatible stack heights: 1 vs 0
		//IL_09eb->IL0aa3: Incompatible stack heights: 1 vs 0
		//IL_0fe8->IL15ac: Incompatible stack heights: 1 vs 0
		//IL_0f35->IL1313: Incompatible stack heights: 1 vs 0
		//IL_1006->IL1313: Incompatible stack heights: 1 vs 0
		//IL_1031->IL1313: Incompatible stack heights: 1 vs 0
		//IL_172c->IL15ac: Incompatible stack heights: 1 vs 0
		//IL_1060->IL1313: Incompatible stack heights: 1 vs 0
		//IL_107e->IL1313: Incompatible stack heights: 1 vs 0
		//IL_10a9->IL1313: Incompatible stack heights: 1 vs 0
		//IL_10d8->IL1313: Incompatible stack heights: 1 vs 0
		//IL_1148->IL1313: Incompatible stack heights: 1 vs 0
		//IL_116a->IL1313: Incompatible stack heights: 1 vs 0
		//IL_11cc->IL1313: Incompatible stack heights: 1 vs 0
		//IL_1214->IL15ac: Incompatible stack heights: 1 vs 0
		BaseBody baseBody = body;
		float num4 = default(float);
		float? num5 = default(float?);
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
				UpdateCrawling();
				UpdateEyes();
				UpdateSpriteTrail();
				bool flag = !_hasSpawnedAllies;
				MessageTarget messageTarget = MessageTarget.All;
				object obj = 1;
				if (flag)
				{
					goto IL_02ae;
				}
				object obj2 = null;
				float num = 32f;
				while ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null)
					{
						break;
					}
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer == null || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene2._renderer == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj3 = 0;
					object obj4 = renderer.width ^ -0f;
					float num2 = renderer.width * 0.5f;
					float num3 = (float)obj4 * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj3 == null)
						{
							MissingMethodException ex = new MissingMethodException();
							throw ex;
						}
						s_scene2 = (PhaserScene)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1871 @ rax_v217 (should have been resolved before IL gen)");
					if ((object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene3._renderer == null || (object)GM.Core == null)
					{
						break;
					}
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene == null || s_scene4._renderer == null || (object)_gameManager == null)
					{
						break;
					}
					_gameManager.SpawnPickupEffectsParticles((Vector2)num4);
					obj2++;
					bool flag2 = (nint)obj2 < 5;
					messageTarget = MessageTarget.AuthorityOnly;
					obj = ArcadePhysics.s_scene;
					num5 = num5;
					num = num2;
					if (flag2)
					{
						continue;
					}
					goto IL_02ae;
				}
			}
		}
		else if (body != null)
		{
			baseBody._enable = false;
			Enemy_TP_DeathArm leftHand = _leftHand;
			if ((object)_leftHand != null)
			{
				BaseBody baseBody3 = leftHand.body;
				if (leftHand.body != null)
				{
					baseBody3._enable = false;
					Enemy_TP_DeathArm rightHand = _rightHand;
					if ((object)_rightHand != null)
					{
						BaseBody baseBody4 = rightHand.body;
						if (rightHand.body != null)
						{
							baseBody4._enable = false;
							return;
						}
					}
				}
			}
		}
		goto IL_1313;
		IL_0aa3:
		float num9;
		float num8;
		if (_isDirecterDead)
		{
			object droppedRelic = _droppedRelic;
			if ((object)_droppedRelic != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rbx_v14 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					if ((object)_droppedRelic == null)
					{
						goto IL_1313;
					}
					if (!_droppedRelic.active)
					{
						_droppedRelic = null;
					}
				}
			}
			object droppedRelic2 = _droppedRelic;
			if ((object)_droppedRelic != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rbx_v15 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					ArcadeSprite droppedRelic3 = _droppedRelic;
					if ((object)_droppedRelic != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v86 (ArcadeSprite)+131]");
						if ((nint)0 != 0)
						{
							goto IL_0d28;
						}
						float2 float5 = _droppedRelic.position;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene5 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene5._renderer;
								if (s_scene5._renderer != null && (object)GM.Core != null)
								{
									MessageTarget messageTarget = (MessageTarget)(int)typeof(ArcadePhysics);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ r8_v14 (Coherence.MessageTarget)+B8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v94+10]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v94+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v83+28]");
										object obj7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v83+28]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v95+24]");
											float num6 = 0f * 0.5f;
											float num7 = num6;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v91 (PhaserScene+Renderer)+38]");
											num8 = num7 + 0f;
											bool flag3 = !(num9 > num8);
											float num10 = num9;
											if (!flag3)
											{
												DoDropAnimation(_droppedRelic);
												num10 = num9;
												messageTarget = MessageTarget.AuthorityOnly;
											}
											goto IL_0d28;
										}
									}
								}
							}
						}
					}
					goto IL_1313;
				}
			}
			goto IL_0d28;
		}
		goto IL_15ac;
		IL_02ae:
		if (_havingAChat)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		num8 = ((!_isDirecterDead) ? 1f : 0.25f);
		float num11 = deltaTime * num8;
		if ((_scytheTimer = num11 + _scytheTimer) > 2f)
		{
			_scytheTimer = 0f;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				float2 float6 = base.position;
				if ((object)core._stage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					object obj8 = default(object);
					bool flag4 = obj8 == null;
					float num10 = num4;
					num8 = 1.1120148E+09f;
					MessageTarget messageTarget = (MessageTarget)(int)num4;
					object obj = null;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1793 @ rax_v194+10]");
						bool flag5 = (nint)0 == 0;
						num10 = num4;
						num8 = 1.1120148E+09f;
						messageTarget = (MessageTarget)(int)num4;
						obj = null;
						if (!flag5)
						{
							GameObject gameObject = base.gameObject;
							obj = obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r9_v11 (System.Object)+360]");
							messageTarget = MessageTarget.AuthorityOnly;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v321 @ r9_v11 (System.Object)+358] (should have been resolved before IL gen)");
							num10 = num4;
							num8 = 1.1120148E+09f;
						}
					}
					goto IL_14c7;
				}
			}
			goto IL_1313;
		}
		goto IL_14c7;
		IL_1313:
		throw new NullReferenceException();
		IL_09eb:
		object currentBigScythe = _currentBigScythe;
		bool flag6 = (object)_currentBigScythe == null;
		num9 = 1.1120148E+09f;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rbx_v24 (System.Object)+10]");
			bool flag7 = (nint)0 == 0;
			num9 = 1.1120148E+09f;
			if (!flag7)
			{
				Enemy_TP_DeathScytheBig currentBigScythe2 = _currentBigScythe;
				if ((object)_currentBigScythe == null)
				{
					goto IL_1313;
				}
				bool flag8 = !((EnemyController)currentBigScythe2)._003CIsDead_003Ek__BackingField;
				num9 = 1.1120148E+09f;
				if (!flag8)
				{
					_currentBigScythe = null;
					num9 = 1.1120148E+09f;
				}
			}
		}
		goto IL_0aa3;
		IL_0e1a:
		object core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v17 (System.Object)+E0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rbx_v17 (System.Object)+E0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rbx_v18 (System.Object)+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rbx_v18 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rbx_v19 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rbx_v19 (System.Object)+10]");
					object obj11 = Behaviour.get_enabled_Injected((IntPtr)0);
					if (obj11 == null || _hasSpawnedAllies)
					{
						goto IL_15ac;
					}
					object coherenceSync = _coherenceSync;
					if ((object)_coherenceSync != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rbx_v20 (System.Object)+160]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rbx_v20 (System.Object)+160]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v56+20]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v56+20]");
							if ((nint)0 == 0)
							{
								goto IL_1313;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v67+10]");
							bool flag10 = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v67+10]");
							if ((nint)0 != 1)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v67+10]");
								object obj14 = -3;
								bool flag11 = obj14 == null;
								flag10 = flag11;
							}
							if (!flag10)
							{
								goto IL_15ac;
							}
						}
						float deltaTime2 = PauseSystem.DeltaTime;
						if (!(0f > (_damageZoneTimer -= deltaTime2)))
						{
							goto IL_15ac;
						}
						if ((object)GM.Core != null)
						{
							PhaserScene phaserScene = GM.Core.scene;
							if (phaserScene != null)
							{
								PhaserScene.Renderer renderer3 = phaserScene._renderer;
								if (phaserScene._renderer != null && (object)GM.Core != null)
								{
									PhaserScene phaserScene2 = GM.Core.scene;
									if (phaserScene2 != null)
									{
										PhaserScene.Renderer renderer4 = phaserScene2._renderer;
										if (phaserScene2._renderer != null)
										{
											object obj15 = renderer3.width ^ -0f;
											float minInclusive = (float)obj15 * 0.4f;
											float maxInclusive = renderer4.width * 0.4f;
											float num12 = UnityEngine.Random.Range(minInclusive, maxInclusive);
											GameManager core3 = GM.Core;
											if ((object)GM.Core != null && core3._multiplayer != null)
											{
												if (!core3._multiplayer.IsOnlineMultiplayer)
												{
													CreateDamageZone((Vector2)num4);
												}
												else
												{
													Action<Vector2> action = null;
													((Enemy_TP_Death)(object)action).CreateDamageZone((Vector2)this);
													if ((object)_coherenceSync == null)
													{
														goto IL_1313;
													}
													bool flag12 = _coherenceSync.SendCommand(action, MessageTarget.All, (Vector2)num4);
												}
												float damageZoneTimer = UnityEngine.Random.Range(4f, 6f);
												_damageZoneTimer = damageZoneTimer;
												goto IL_15ac;
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
		goto IL_1313;
		IL_0d28:
		object droppedRelic4 = _droppedRelic;
		if ((object)_droppedRelic != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v16 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				goto IL_0e1a;
			}
		}
		List<ItemType> relicsToDrop = _relicsToDrop;
		if (_relicsToDrop != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v77 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 > (nint)0)
			{
				float deltaTime3 = PauseSystem.DeltaTime;
				if ((_relicDropTimer = deltaTime3 + _relicDropTimer) > 5f)
				{
					_relicDropTimer = 0f;
					DropNextRelic();
				}
			}
			goto IL_0e1a;
		}
		goto IL_1313;
		IL_14c7:
		Enemy_TP_DeathScytheBig currentBigScythe3 = _currentBigScythe;
		if ((object)_currentBigScythe != null && ((UnityEngine.Object)currentBigScythe3).m_CachedPtr != (IntPtr)0)
		{
			goto IL_09eb;
		}
		object core4 = GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rbx_v25 (System.Object)+E0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rbx_v25 (System.Object)+E0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v26 (System.Object)+10]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v26 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rbx_v27 (System.Object)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rbx_v27 (System.Object)+10]");
					object obj18 = Behaviour.get_enabled_Injected((IntPtr)0);
					if (obj18 == null)
					{
						goto IL_09eb;
					}
					float num13 = _bigScytheScreamTime + _bigScythePostScreamThrowTime;
					float num14 = _bigScytheScreamTime - 0.2f;
					float deltaTime4 = PauseSystem.DeltaTime;
					float num15 = (_bigScytheTimer = deltaTime4 + _bigScytheTimer);
					if (num14 > _bigScytheTimer && !(num15 < num14))
					{
						if ((object)_SpriteAnimation == null)
						{
							goto IL_1313;
						}
						_SpriteAnimation.SetAnimation("OpenMouth");
						MessageTarget messageTarget = MessageTarget.AuthorityOnly;
					}
					bool flag14 = !(_bigScytheScreamTime > _bigScytheTimer);
					num9 = 1.1120148E+09f;
					float num17 = default(float);
					float num18 = default(float);
					bool flag16 = default(bool);
					if (!flag14)
					{
						bool flag15 = _bigScytheTimer < _bigScytheScreamTime;
						num9 = 1.1120148E+09f;
						if (!flag15)
						{
							int num16 = UnityEngine.Random.Range(-200, 200);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, num5, num17, num18, flag16, 1f);
							int num19 = UnityEngine.Random.Range(-200, 200);
							PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, num5, num17, num18, flag16, 1f);
							if ((object)_SpriteAnimation == null)
							{
								goto IL_1313;
							}
							_SpriteAnimation.SetAnimation("ScreamLoop");
							num8 = 0f;
							MessageTarget messageTarget = MessageTarget.AuthorityOnly;
							num9 = 1.0737418E+09f;
						}
					}
					float num10 = _bigScytheTimer;
					if (!(_bigScytheTimer > num13))
					{
						goto IL_0aa3;
					}
					if ((object)_SpriteAnimation != null)
					{
						_SpriteAnimation.SetAnimation("CloseMouth");
						Action onComplete = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A60B6]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							_SpriteAnimation.SetAnimation("Idle");
						};
						Timer timer = Timers.Register(0.4f, onComplete, null, isLooped: false, (byte)(int)num5 != 0, (MonoBehaviour)num17, (int)num18, flag16 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
						_bigScytheTimer = 0f;
						object core5 = GM.Core;
						if ((object)GM.Core != null)
						{
							float2 float7 = base.position;
							num8 = num9 + 3f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rbx_v30 (System.Object)+B8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
								Enemy_TP_DeathScytheBig currentBigScythe4 = default(Enemy_TP_DeathScytheBig);
								_currentBigScythe = currentBigScythe4;
								MessageTarget messageTarget = (MessageTarget)(int)num4;
								Enemy_TP_DeathScytheBig currentBigScythe5 = _currentBigScythe;
								bool flag17 = (object)_currentBigScythe == null;
								num10 = num4;
								object obj = null;
								if (!flag17)
								{
									bool flag18 = ((UnityEngine.Object)currentBigScythe5).m_CachedPtr == (IntPtr)0;
									num10 = num4;
									obj = null;
									if (!flag18)
									{
										object currentBigScythe6 = _currentBigScythe;
										GameObject gameObject2 = base.gameObject;
										if ((object)_currentBigScythe != null)
										{
											obj = currentBigScythe6;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r9_v11 (System.Object)+360]");
											messageTarget = MessageTarget.AuthorityOnly;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v321 @ r9_v11 (System.Object)+358] (should have been resolved before IL gen)");
											GameManager core6 = GM.Core;
											if ((object)GM.Core != null && core6._multiplayer != null)
											{
												if (!core6._multiplayer.IsOnlineMultiplayer)
												{
													TriggerDirecterBlock();
													num10 = num4;
												}
												else
												{
													Action<CoherenceSync> action2 = OnBigScytheSpawned;
													Enemy_TP_DeathScytheBig currentBigScythe7 = _currentBigScythe;
													if ((object)_currentBigScythe == null || (object)_coherenceSync == null)
													{
														goto IL_1313;
													}
													obj = ((EnemyController)currentBigScythe7)._coherenceSync;
													bool flag19 = _coherenceSync.SendCommand((Action<object>)action2, MessageTarget.All, ((EnemyController)currentBigScythe7)._coherenceSync);
													num10 = num4;
													messageTarget = MessageTarget.All;
												}
												goto IL_0aa3;
											}
										}
										goto IL_1313;
									}
								}
								goto IL_0aa3;
							}
						}
					}
				}
			}
		}
		goto IL_1313;
		IL_15ac:
		UpdateDeathArea();
	}

	private unsafe void TriggerDirecterBlock()
	{
		//IL_004b: Expected O, but got Ref
		Enemy_TP_DeathScytheBig currentBigScythe = _currentBigScythe;
		if ((object)((EnemyController)currentBigScythe)._targetTransform != null)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		object arg3 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2, arg3);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Trying to trigger Directer Block. Has Scythe?: {0}, Directer revivals: {1}, Directer dead: {2}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		Enemy_TP_DeathScytheBig currentBigScythe2 = _currentBigScythe;
		Transform targetTransform = ((EnemyController)currentBigScythe2)._targetTransform;
		if ((object)((EnemyController)currentBigScythe2)._targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0 && _003CDirecterRevivals_003Ek__BackingField >= 2 && !_isDirecterDead)
		{
			Enemy_TP_DeathScytheBig currentBigScythe3 = _currentBigScythe;
			DeathFightDirecter directer = _directer;
			directer._protectionTarget = ((EnemyController)currentBigScythe3)._targetTransform;
			DeathFightDirecter directer2 = _directer;
			Transform projectileToBlock = currentBigScythe3.transform;
			directer2._projectileToBlock = projectileToBlock;
		}
	}

	public unsafe void CreateDamageZone(Vector2 spawnPositionOffset)
	{
		//IL_0081: Expected F4, but got O
		//IL_0081: Expected O, but got F4
		//IL_00f4: Expected O, but got Ref
		Camera main = Camera.main;
		DamageZoneFlexible damageZoneFlexible = DamageZoneFlexible.CreateZone(main);
		float num = default(float);
		float2 float5 = default(float2);
		damageZoneFlexible.InitDamageZone(12f, 2000f, 500f, num, float5);
		damageZoneFlexible._haveWarningMark = false;
		damageZoneFlexible._warningTimeMillis = 1000f;
		Camera main2 = Camera.main;
		Transform transform = main2.transform;
		damageZoneFlexible.InitDamageZoneBehaviour(lockX: false, lockY: true, following: false, (Transform)num, (float)float5);
		Camera main3 = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v16 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		float height = num2 * 100f;
		damageZoneFlexible.InitDamageZoneRectangle(100f, height);
		Vector3 vector = default(Vector3);
		SetupDamageZoneVisuals((Vector3)(&vector), damageZoneFlexible);
		damageZoneFlexible.EnableZone();
	}

	private unsafe void SetupDamageZoneVisuals(Vector3 pos, DamageZoneFlexible zone)
	{
		//IL_00ae: Expected O, but got Ref
		//IL_00d8: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_Death_Scythe_Small");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		object obj = default(object);
		ParticleSystemConfig particleSystemConfig = DamageZoneFlexible.BaseConfig((Vector3)(&obj), list, "TP_Death");
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, 360f);
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(0f, 360f);
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		zone.InitParticleVisuals(particleSystemConfig, DamageZoneFlexible.ZoneAlignment.Top);
	}

	private unsafe void UpdateEyes()
	{
		//IL_021f: Expected O, but got I4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0258->IL01c8: Incompatible stack heights: 1 vs 0
		//IL_0349->IL01c8: Incompatible stack heights: 2 vs 0
		//IL_018b->IL034e: Incompatible stack heights: 2 vs 0
		float2 float5 = base.position;
		if ((object)GM.Core != null)
		{
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			if ((object)closestPlayer != null)
			{
				((ArcadeSprite)closestPlayer).CheckRenderer();
				if ((object)((ArcadeSprite)closestPlayer)._spriteRenderer != null)
				{
					Transform transform = ((ArcadeSprite)closestPlayer)._spriteRenderer.transform;
					if ((object)transform != null)
					{
						if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
						{
							UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
						}
						else
						{
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							UnityEngine.Object obj = _leftEye;
							int num = (int)(&ret);
							object obj2 = 0;
							Vector3 vector = default(Vector3);
							object obj5 = default(object);
							object obj6 = default(object);
							object obj7 = default(object);
							while (true)
							{
								bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
								Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform2 == null)
								{
									break;
								}
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.TransformPoint_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref vector, out Vector3 ret2);
								object obj3 = ret - ret2;
								object obj4 = obj5 - obj6;
								float num2 = (float)obj3 * 0.025f;
								float num3 = (float)obj4 * 0.025f;
								float num4 = num2 * num2;
								float num5 = num3 * num3;
								float num6 = num4 + num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
								if (num6 > 0.09f)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186252410");
									num3 = (float)obj7 * 0.09f;
								}
								float num7 = (float)obj6 + num3;
								if ((object)obj == null)
								{
									break;
								}
								obj.SetName("Eye");
								float2 float6 = ((PhaserSprite)obj).position;
								float num8 = num7 - (float)obj7;
								float num9 = num8 * 0.1f;
								float num10 = (float)obj7 + num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								int num11 = base.depth;
								num = num11 + 1;
								PhaserSprite phaserSprite = ((PhaserSprite)obj).setDepth(num);
								obj = _rightEye;
								obj2++;
								if ((nint)obj2 >= 2)
								{
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateCrawling()
	{
		//IL_104b: Expected I, but got O
		//IL_006b: Expected O, but got I
		//IL_009e: Expected I, but got O
		//IL_0103: Expected O, but got I
		//IL_015f: Expected O, but got I
		//IL_01bb: Expected O, but got I
		//IL_02ea: Expected F4, but got I
		//IL_0312: Expected O, but got I4
		//IL_0326: Expected O, but got I4
		//IL_0378: Expected O, but got Ref
		//IL_0386: Expected I, but got O
		//IL_0364: Expected I4, but got I8
		//IL_03cf: Expected O, but got I
		//IL_03e2: Expected I, but got O
		//IL_042b: Expected O, but got I
		//IL_048b: Expected O, but got Ref
		//IL_0543: Expected O, but got I
		//IL_05df: Expected O, but got Ref
		//IL_0630: Expected O, but got Ref
		//IL_0662: Expected O, but got I
		//IL_06a4: Expected I, but got O
		//IL_0746: Expected I, but got O
		//IL_092d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0932: Expected F4, but got Unknown
		//IL_0959: Expected O, but got F4
		//IL_0959: Expected O, but got I4
		//IL_0959: Expected O, but got I4
		//IL_0959: Expected F4, but got O
		//IL_0985: Expected O, but got F4
		//IL_0985: Expected O, but got I4
		//IL_0985: Expected O, but got I4
		//IL_0985: Expected F4, but got O
		//IL_07ab: Expected O, but got I
		//IL_08c2: Expected I, but got O
		//IL_0a1c: Expected F4, but got I4
		//IL_08f9: Expected I, but got O
		//IL_0b88: Expected O, but got I4
		//IL_0af5: Expected F4, but got I
		//IL_0b75: Expected F4, but got I4
		//IL_1533: Expected O, but got I4
		//IL_0c33: Expected O, but got I4
		//IL_0b64: Expected O, but got I4
		//IL_0b64: Expected O, but got I
		//IL_0d82: Expected O, but got I4
		//IL_0f4c: Expected O, but got I4
		//IL_0492->IL0492: Incompatible stack heights: 3 vs 2
		//IL_1327->IL1036: Incompatible stack heights: 19 vs 0
		//IL_0612->IL1036: Incompatible stack heights: 19 vs 0
		//IL_137c->IL1036: Incompatible stack heights: 20 vs 0
		//IL_064d->IL1036: Incompatible stack heights: 20 vs 0
		//IL_13a3->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0691->IL1036: Incompatible stack heights: 20 vs 0
		//IL_06cd->IL1036: Incompatible stack heights: 20 vs 0
		//IL_13ca->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0701->IL1036: Incompatible stack heights: 20 vs 0
		//IL_076f->IL1036: Incompatible stack heights: 20 vs 0
		//IL_083d->IL1036: Incompatible stack heights: 20 vs 0
		//IL_099f->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0796->IL1036: Incompatible stack heights: 20 vs 0
		//IL_086c->IL1036: Incompatible stack heights: 20 vs 0
		//IL_09d2->IL1036: Incompatible stack heights: 20 vs 0
		//IL_07cb->IL1036: Incompatible stack heights: 20 vs 0
		//IL_089b->IL1036: Incompatible stack heights: 20 vs 0
		//IL_14f3->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0a4b->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0a6d->IL1036: Incompatible stack heights: 20 vs 0
		//IL_15e7->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0ab4->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0bb1->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0ad6->IL1036: Incompatible stack heights: 20 vs 0
		//IL_1599->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0bea->IL1036: Incompatible stack heights: 20 vs 0
		//IL_15be->IL1036: Incompatible stack heights: 20 vs 0
		//IL_154e->IL1553: Incompatible stack heights: 22 vs 20
		//IL_0c19->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0b6c->IL1553: Incompatible stack heights: 23 vs 20
		//IL_0c60->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0ca0->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0cd9->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0d05->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0d36->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0d68->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0daf->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0def->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0e28->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0e54->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0e85->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0eb7->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0f09->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0f32->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0f79->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0fb9->IL1036: Incompatible stack heights: 20 vs 0
		//IL_0ff2->IL1036: Incompatible stack heights: 20 vs 0
		//IL_101e->IL1036: Incompatible stack heights: 20 vs 0
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		float num8 = default(float);
		bool? flag = default(bool?);
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		float num17;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v74+28]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v74+28]");
				if ((nint)0 != 0)
				{
					nint num3 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ rax_v75 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num4 = 0;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
						object obj3 = default(object);
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rax_v76+28]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rax_v76+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
								object obj5 = default(object);
								if (obj5 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rax_v77+28]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rax_v77+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
										object obj7 = default(object);
										if (obj7 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v962 @ rax_v78+28]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v962 @ rax_v78+28]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v65+10]");
												float num5 = 0f * 0.5f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v62+34]");
												float x = 0f - num5;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v66+14]");
												float num6 = 0f * 0.5f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v64+38]");
												float y = 0f - num6;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
												object obj9 = default(object);
												if (obj9 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ rax_v79+18]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004430");
														World world = default(World);
														if (world != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v65+10]");
															nint num7 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v66+14]");
															World world2 = world.setBounds(x, y, num7, num8, flag, flag2, flag3, checkDown: false);
															ArcadeSprite arcadeSprite = setVisible(visible: true);
															ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
															ArcadeSprite arcadeSprite3 = setScale(2f, (float?)(object)0);
															bool flag4 = !_havingAChat;
															int num9 = 3001;
															if (!flag4)
															{
																num9 = -3001;
															}
															ArcadeSprite arcadeSprite4 = setDepth(num9);
															float2 ret = default(float2);
															_cameraTarget.localPosition = (Vector3)(&ret);
															nint num10 = (nint)typeof(GM);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1873 @ rax_v88 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
															nint num11 = 0;
															bool flag5 = (object)GM.Core == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1874 @ rax_v89+28]");
															object obj10 = 0;
															nint num12 = (nint)typeof(GM);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1875 @ rax_v90 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
															nint num13 = 0;
															bool flag6 = (object)GM.Core == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1171 @ rax_v91+28]");
															object obj11 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1788 @ rcx_v76+14]");
															nint num14 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1786 @ rcx_v74+10]");
															if (num14 > 0)
															{
																bool flag7 = (object)_cameraTarget == null;
																_cameraTarget.localPosition = (Vector3)(&ret);
															}
															CheckRenderer();
															object spriteRenderer = ((ArcadeSprite)this)._spriteRenderer;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rsi_v30 (System.Object)+10]");
															bool flag8 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rsi_v30 (System.Object)+10]");
															Color value = default(Color);
															SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
															PhaserSprite deathMask = _deathMask;
															object spriteRenderer2 = deathMask._spriteRenderer;
															CheckRenderer();
															object spriteRenderer3 = ((ArcadeSprite)this)._spriteRenderer;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ rsi_v31 (System.Object)+10]");
															bool flag9 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ rsi_v31 (System.Object)+10]");
															SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&ret));
															bool flag10 = (object)deathMask._spriteRenderer == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ r14_v32 (System.Object)+10]");
															bool flag11 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ r14_v32 (System.Object)+10]");
															Color value2 = default(Color);
															SpriteRenderer.set_color_Injected((IntPtr)0, ref value2);
															PhaserSprite deathCape = _deathCape;
															bool flag12 = (object)_deathCape == null;
															object spriteRenderer4 = deathCape._spriteRenderer;
															CheckRenderer();
															object spriteRenderer5 = ((ArcadeSprite)this)._spriteRenderer;
															bool flag13 = (object)((ArcadeSprite)this)._spriteRenderer == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ rsi_v33 (System.Object)+10]");
															bool flag14 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ rsi_v33 (System.Object)+10]");
															SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&ret));
															bool flag15 = (object)deathCape._spriteRenderer == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1344 @ r14_v34 (System.Object)+10]");
															bool flag16 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1344 @ r14_v34 (System.Object)+10]");
															SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
															object deathSpine = _deathSpine;
															bool flag17 = (object)_deathSpine == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3378 @ r14_v35 (System.Object)+28]");
															object obj12 = 0;
															CheckRenderer();
															object spriteRenderer6 = ((ArcadeSprite)this)._spriteRenderer;
															bool flag18 = (object)((ArcadeSprite)this)._spriteRenderer == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rsi_v35 (System.Object)+10]");
															bool flag19 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rsi_v35 (System.Object)+10]");
															SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&ret));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3378 @ r14_v35 (System.Object)+28]");
															bool flag20 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ r14_v36 (System.Object)+10]");
															bool flag21 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ r14_v36 (System.Object)+10]");
															SpriteRenderer.set_color_Injected((IntPtr)0, ref value2);
															bool flag22 = (object)_deathSpine == null;
															PhaserSprite phaserSprite = _deathSpine.setVisible(visible: false);
															CheckRenderer();
															object spriteRenderer7 = ((ArcadeSprite)this)._spriteRenderer;
															bool flag23 = (object)((ArcadeSprite)this)._spriteRenderer == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rsi_v37 (System.Object)+10]");
															bool flag24 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rsi_v37 (System.Object)+10]");
															SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&ret));
															if ((object)_leftHand != null)
															{
																ArcadeSprite arcadeSprite5 = _leftHand.setColor((Color)(&value));
																CheckRenderer();
																object spriteRenderer8 = ((ArcadeSprite)this)._spriteRenderer;
																if ((object)((ArcadeSprite)this)._spriteRenderer != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rsi_v38 (System.Object)+10]");
																	bool flag25 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rsi_v38 (System.Object)+10]");
																	SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&ret));
																	if ((object)_rightHand != null)
																	{
																		ArcadeSprite arcadeSprite6 = _rightHand.setColor((Color)(&value2));
																		if ((object)GM.Core != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AD90]");
																			CharacterController characterController = (CharacterController)0;
																			PhaserScene s_scene = ArcadePhysics.s_scene;
																			if (ArcadePhysics.s_scene != null)
																			{
																				PhaserScene.Renderer renderer = s_scene._renderer;
																				if (s_scene._renderer != null)
																				{
																					nint num15 = (nint)typeof(GM);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v142 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																					nint num16 = 0;
																					if ((object)GM.Core != null)
																					{
																						PhaserScene s_scene2 = ArcadePhysics.s_scene;
																						if (ArcadePhysics.s_scene != null)
																						{
																							PhaserScene.Renderer renderer2 = s_scene2._renderer;
																							if (s_scene2._renderer != null)
																							{
																								bool flag26 = !(renderer2.height > renderer.width);
																								num17 = 2.8f;
																								if (flag26)
																								{
																									goto IL_13cf;
																								}
																								nint num18 = (nint)typeof(GM);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rax_v227 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																								nint num19 = 0;
																								if ((object)GM.Core != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																									object obj13 = default(object);
																									if (obj13 != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rax_v228+28]");
																										characterController = (CharacterController)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rax_v228+28]");
																										if ((nint)0 != 0)
																										{
																											float num20 = (float)(nint)((UnityEngine.Object)characterController).m_CachedPtr * 0.5f;
																											bool flag27 = !(2.8f > num20);
																											num17 = 2.8f;
																											if (!flag27)
																											{
																												num17 = num20;
																											}
																											goto IL_13cf;
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
		goto IL_1036;
		IL_13cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float lastPhase = _crawlTimer / 20f;
		float num21 = _crawlTimer + 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float lastPhase2 = num21 / 20f;
		if (!_havingAChat)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null)
				{
					CharacterController characterController = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						bool flag28 = gameSessionData._activeCharacter.enabled;
						bool flag29 = !flag28;
						nint num16 = unchecked((nint)null);
						if (!flag29)
						{
							float deltaTime = PauseSystem.DeltaTime;
							float crawlTimer = deltaTime + _crawlTimer;
							_crawlTimer = crawlTimer;
							num16 = unchecked((nint)null);
							characterController = null;
						}
						goto IL_1439;
					}
				}
			}
			goto IL_1036;
		}
		goto IL_1439;
		IL_1036:
		throw new NullReferenceException();
		IL_1439:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float phase = _crawlTimer / 20f;
		float num22 = _crawlTimer + 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float phase2 = num22 / 20f;
		float num23 = _crawlTimer + 10f;
		float num24 = num23 * (float)Math.PI;
		float num25 = num24 + num24;
		float num26 = num25 / 20f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num27 = num26 * 5f;
		base.angle = num27;
		float num28 = num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float xOffset = num28 ^ 0;
		UpdateArm(phase, lastPhase, xOffset, num8, (float)flag, (Enemy_TP_DeathArm)flag2, (PhaserSprite)flag3, (List<PhaserSprite>)(-1f));
		UpdateArm(phase2, lastPhase2, num17, num8, (float)flag, (Enemy_TP_DeathArm)flag2, (PhaserSprite)flag3, (List<PhaserSprite>)(-1f));
		if ((object)_leftHand != null)
		{
			ArcadeSprite arcadeSprite7 = _leftHand.setFlipX(flipX: false);
			if ((object)_rightHand != null)
			{
				ArcadeSprite arcadeSprite8 = _rightHand.setFlipX(flipX: true);
				bool flag30 = !_havingAChat;
				float num29 = -0.3f;
				if (!flag30)
				{
					num29 = 0f;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData2 = core2._gameSessionData;
					if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
					{
						if (!gameSessionData2._activeCharacter.enabled)
						{
							GameManager core3 = GM.Core;
							if ((object)GM.Core == null || core3._mainCharacters == null)
							{
								goto IL_1036;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3946 @ rax_v212+10]");
							float num30 = 0f;
							List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
							while (enumerator.MoveNext())
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3946 @ rax_v212+10]");
								bool flag31 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3951 @ xmm1_v48 (System.Single)+10]");
								bool flag32 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3951 @ xmm1_v48 (System.Single)+10]");
								object obj14 = Behaviour.get_enabled_Injected((IntPtr)0);
								if (obj14 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3946 @ rax_v212+10]");
									bool flag33 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3946 @ rax_v212+10]");
									((ArcadeSprite)0).setVelocity(0f, (float?)(object)1);
								}
							}
							num29 = 0f;
						}
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._velocity = (float2)0;
							object leftHand = _leftHand;
							if ((object)_leftHand != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rsi_v40 (System.Object)+28]");
								if ((nint)0 != 0)
								{
									_ = 0;
									object rightHand = _rightHand;
									if ((object)_rightHand != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rsi_v41 (System.Object)+28]");
										if ((nint)0 != 0)
										{
											_ = 0;
											if ((object)_deathCape != null)
											{
												PhaserSprite phaserSprite2 = _deathCape.setScale(1f, (float?)(object)0);
												int num31 = base.depth;
												if ((object)_deathCape != null)
												{
													int num32 = num31 - 1;
													PhaserSprite phaserSprite3 = _deathCape.setDepth(num32);
													if ((object)_deathCape != null)
													{
														Transform transform = _deathCape.transform;
														CheckRenderer();
														if ((object)((ArcadeSprite)this)._spriteRenderer != null)
														{
															Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
															if ((object)transform != null)
															{
																transform.SetParent(parent, worldPositionStays: true);
																if ((object)_deathCape != null)
																{
																	float2 localPosition = default(float2);
																	PhaserSprite phaserSprite4 = _deathCape.setLocalPosition(localPosition);
																	if ((object)_deathSpine != null)
																	{
																		PhaserSprite phaserSprite5 = _deathSpine.setScale(1f, (float?)(object)0);
																		int num33 = base.depth;
																		if ((object)_deathSpine != null)
																		{
																			int num34 = num33 + 1;
																			PhaserSprite phaserSprite6 = _deathSpine.setDepth(num34);
																			if ((object)_deathSpine != null)
																			{
																				Transform transform2 = _deathSpine.transform;
																				CheckRenderer();
																				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
																				{
																					Transform parent2 = ((ArcadeSprite)this)._spriteRenderer.transform;
																					if ((object)transform2 != null)
																					{
																						transform2.SetParent(parent2, worldPositionStays: true);
																						if ((object)_deathSpine != null)
																						{
																							PhaserSprite phaserSprite7 = _deathSpine.setLocalPosition(localPosition);
																							if ((object)_deathMask != null)
																							{
																								PhaserSprite phaserSprite8 = _deathMask.setVisible(visible: false);
																								float2 float5 = base.position;
																								float num35 = num29 + 0.5f;
																								if ((object)_deathMask != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
																									if ((object)_deathMask != null)
																									{
																										PhaserSprite phaserSprite9 = _deathMask.setScale(1f, (float?)(object)0);
																										int num36 = base.depth;
																										if ((object)_deathMask != null)
																										{
																											int num37 = num36 + 3;
																											PhaserSprite phaserSprite10 = _deathMask.setDepth(num37);
																											if ((object)_deathMask != null)
																											{
																												Transform transform3 = _deathMask.transform;
																												CheckRenderer();
																												if ((object)((ArcadeSprite)this)._spriteRenderer != null)
																												{
																													Transform parent3 = ((ArcadeSprite)this)._spriteRenderer.transform;
																													if ((object)transform3 != null)
																													{
																														transform3.SetParent(parent3, worldPositionStays: true);
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
				}
			}
		}
		goto IL_1036;
	}

	private unsafe void UpdateSpriteTrail()
	{
		//IL_0070: Expected O, but got I
		//IL_010b: Expected O, but got F4
		//IL_011b: Expected O, but got I
		//IL_01b7: Expected I, but got O
		//IL_0134: Expected O, but got F4
		//IL_01f2: Expected F4, but got O
		//IL_01f2: Expected F4, but got I
		//IL_01f6: Expected O, but got F4
		//IL_0147: Expected F4, but got O
		//IL_0147: Expected F4, but got I
		//IL_014b: Expected O, but got F4
		//IL_0209: Expected F4, but got O
		//IL_0209: Expected F4, but got I
		//IL_020d: Expected O, but got F4
		//IL_015e: Expected F4, but got O
		//IL_015e: Expected F4, but got I
		//IL_0162: Expected O, but got F4
		//IL_022d: Expected O, but got Ref
		//IL_0254->IL0185: Incompatible stack heights: 1 vs 0
		CheckRenderer();
		SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
		int num = 0;
		object obj8 = default(object);
		object obj9 = default(object);
		for (int num2 = 0; num2 < component._MaxHistory; num2 = num)
		{
			List<Vector3> positionHistory = component._positionHistory;
			int num3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag = (nint)num3 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AC9A]");
			object obj = 0;
			if (!PauseSystem._paused)
			{
				object obj2 = Time.time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AC9A]");
				obj = 0;
			}
			nint num4 = (nint)typeof(PauseSystem);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v32 (Il2CppClass<PauseSystem>)+B8]");
			nint num5 = 0;
			if (!PauseSystem._paused)
			{
				object obj3 = Time.time;
			}
			object obj4 = Mathf.PerlinNoise(num5, (float)obj);
			object obj5 = Mathf.PerlinNoise(num5, (float)obj);
			object obj6 = Mathf.PerlinNoise(num5, (float)obj);
			object obj7 = Mathf.PerlinNoise(num5, (float)obj);
			if (_bigScytheTimer > _bigScytheScreamTime)
			{
				float num6 = _bigScytheTimer - _bigScytheScreamTime;
				float num7 = num6 / _bigScythePostScreamThrowTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
			}
			float deltaTime = PauseSystem.DeltaTime;
			SpriteTrail spriteTrail = component.SetPosition(num, (Vector3)(&obj8));
			num++;
			obj8 = obj9;
		}
	}

	private unsafe void UpdateDeathArea()
	{
		//IL_00c3: Expected O, but got I4
		//IL_00d9: Expected I, but got O
		//IL_03fe: Expected O, but got I
		//IL_03ad: Expected O, but got I
		//IL_0166: Expected O, but got F4
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_01a2: Expected I, but got O
		//IL_0113: Expected I, but got I8
		//IL_014d: Expected I, but got I8
		//IL_01da: Expected F4, but got I4
		//IL_0257: Expected O, but got F4
		//IL_02be: Expected O, but got F4
		//IL_02c6: Invalid comparison between O and F4
		//IL_02e7: Invalid comparison between O and F4
		//IL_0312: Expected O, but got F4
		//IL_034d: Expected I, but got O
		//IL_0118->IL037a: Incompatible stack heights: 1 vs 0
		//IL_0152->IL04b7: Incompatible stack heights: 1 vs 0
		//IL_02a2->IL0491: Incompatible stack heights: 3 vs 0
		//IL_0271->IL0478: Incompatible stack heights: 3 vs 2
		//IL_02d5->IL0491: Incompatible stack heights: 3 vs 0
		//IL_02f6->IL0491: Incompatible stack heights: 3 vs 0
		//IL_033f->IL0491: Incompatible stack heights: 3 vs 0
		//IL_0366->IL0491: Incompatible stack heights: 3 vs 0
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.screenWidth * 0.5f;
		float2 float5 = base.position;
		float2 float6 = base.position;
		Rectangle rectangle = new Rectangle();
		float width = num + num;
		float x = (float)float5 - num;
		rectangle._x = x;
		float num2 = default(float);
		rectangle._y = num2;
		rectangle._width = width;
		rectangle._height = 2f;
		object obj = 0;
		float num3 = num2;
		nint num4 = (nint)typeof(Rectangle);
		float num7 = default(float);
		bool flag3;
		do
		{
			float num5 = rectangle._width + rectangle._x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag = obj2 == null;
				num4 = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v425 @ rax_v23 (should have been resolved before IL gen)");
			float num6 = rectangle._height + rectangle._y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag2 = obj3 == null;
				num4 = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v466 @ rax_v26 (should have been resolved before IL gen)");
			RenderingExtensions.EmitParticleAt(_deathZoneParticles, (Vector2)num7, 1);
			obj++;
			flag3 = (nint)obj < 20;
			num3 = rectangle._y;
			width = num7;
			num4 = (nint)_deathZoneParticles;
		}
		while (flag3);
		GameManager core = GM.Core;
		List<CharacterController>.Enumerator characters = (List<CharacterController>.Enumerator)core._characters;
		float num8 = 0f;
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		object obj5 = default(object);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
			bool flag4 = (object)cachedTrans == null;
			bool flag5 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			object obj4;
			if (arcadeSprite.body != null)
			{
				BaseBody baseBody = arcadeSprite.body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				bool flag6 = baseBody._transform == null;
				arcadeTransform.position = (float2)ret;
				obj4 = obj5;
				num8 = ret;
			}
			else
			{
				obj4 = obj5;
				num8 = ret;
			}
			bool flag7 = rectangle == null;
			if (num8 < rectangle._x)
			{
				continue;
			}
			characters = (List<CharacterController>.Enumerator)(rectangle._width + rectangle._x);
			if (System.Runtime.CompilerServices.Unsafe.As<List<CharacterController>.Enumerator, UIntPtr>(ref characters) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rectangle._y))
			{
				characters = (List<CharacterController>.Enumerator)(rectangle._height + rectangle._y);
				if (System.Runtime.CompilerServices.Unsafe.As<List<CharacterController>.Enumerator, UIntPtr>(ref characters) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
				{
					nint num9 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1104 @ r8_v9 (Il2CppClass<ArcadeSprite>)+5F8] (should have been resolved before IL gen)");
					num8 = 1f;
				}
			}
		}
	}

	private float GetArmPhase(float timer, float period, float offset01)
	{
		float num = period * offset01;
		float num2 = num + timer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		return num2 / period;
	}

	private float FindNextJointT(float2 start, float2 end, float2 lastJointPos, float lastJointT, float desiredDistance, float iterationStep = -0.01f)
	{
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		float2 float5 = lastJointPos;
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = 0;
		object obj4 = 0;
		float num2 = default(float);
		float num = num2;
		object obj5 = default(object);
		object obj11 = default(object);
		bool flag;
		do
		{
			num += (float)obj5;
			float2 float6 = ArmSample(start, end, num);
			object obj6 = float6 - float5;
			object obj7 = obj2 - obj;
			object obj8 = obj6 * obj6;
			object obj9 = obj7 * obj7;
			object obj10 = obj8 + obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			obj3 += obj10;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
			{
				break;
			}
			obj4++;
			flag = (nint)obj4 < 100;
			float5 = float6;
			obj = obj2;
		}
		while (flag);
		return num;
	}

	private void UpdateArm(float phase01, float lastPhase01, float xOffset, float yOffset, float reachDistance, Enemy_TP_DeathArm arm, PhaserSprite crackSprite, List<PhaserSprite> armSprites)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I4
		//IL_00ef: Invalid comparison between F4 and I4
		//IL_0533: Invalid comparison between I4 and F4
		//IL_012e: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_0576: Expected F4, but got I4
		//IL_05a6: Expected O, but got I4
		//IL_0167: Expected I4, but got I8
		//IL_01df: Invalid comparison between F4 and I4
		//IL_020d: Expected F4, but got I4
		//IL_05ee: Invalid comparison between I4 and F4
		//IL_0229: Expected F4, but got I4
		//IL_02a1: Expected F4, but got I4
		//IL_02a1: Expected O, but got F4
		//IL_02d3: Expected F4, but got I4
		//IL_02d3: Expected O, but got F4
		//IL_031a: Expected O, but got I4
		//IL_0369: Expected I, but got O
		//IL_03db: Expected O, but got I4
		object obj = default(object);
		float num4;
		if (0.5f > phase01)
		{
			float num = phase01 + phase01;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
			float num2 = num * (float)obj;
			float num3 = num2 + num2;
			num4 = (float)obj - num3;
		}
		else
		{
			float num5 = phase01 - 0.5f;
			float num6 = num5 + num5;
			float num7 = num6 * (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = obj ^ 0;
			float num8 = num7 + num7;
			num4 = num8 + (float)obj2;
		}
		ArcadeSprite arcadeSprite2 = default(ArcadeSprite);
		ArcadeSprite arcadeSprite = arcadeSprite2.setOrigin(0.5f, (float?)(object)1);
		if (xOffset > 0f)
		{
		}
		if (0f > xOffset)
		{
		}
		BaseBody baseBody = arcadeSprite2.body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		bool flag = !_havingAChat;
		int num9 = 1000;
		if (!flag)
		{
			num9 = -4000;
		}
		ArcadeSprite arcadeSprite3 = arcadeSprite2.setDepth(num9);
		bool flag2 = !(0.5f > phase01);
		float num10 = 0f;
		if (!flag2)
		{
			float num11 = phase01 + phase01;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185EC5330");
			float num12 = num11 * (float)Math.PI;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
			num10 = num12;
		}
		float xScale = num10 + 2f;
		ArcadeSprite arcadeSprite4 = arcadeSprite2.setScale(xScale, (float?)(object)0);
		float2 float5 = base.position;
		IntPtr intPtr = default(IntPtr);
		float num13 = num4 + (float)(nint)intPtr;
		float num14 = 1.090519E+09f + num13;
		float2 pos = default(float2);
		arcadeSprite2.position = pos;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite5 = arcadeSprite2.setFrame(sprite);
		float num15 = ((!(xOffset > 0f)) ? 0f : 1f);
		float num16 = ((!(0f > xOffset)) ? 0f : 1f);
		float num17 = num15 - num16;
		float num18 = num17 * 10f;
		arcadeSprite2.angle = num18;
		List<PhaserSprite> armSprites2 = default(List<PhaserSprite>);
		float num19 = default(float);
		UpdateJoints((Enemy_TP_DeathArm)arcadeSprite2, xOffset, armSprites2, num19);
		if (!(0.5f > lastPhase01) || phase01 < 0.5f)
		{
			return;
		}
		ScreenShake(8);
		float num20 = UnityEngine.Random.Range(0.2f, 0.3f);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 0f, 10, 0f, (float?)(object)num19, rate, detune, loop, 1f);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 0f, 10, 0f, (float?)(object)num19, rate, detune, loop, 1f);
		float2 float6 = arcadeSprite2.position;
		RenderingExtensions.EmitParticleAt(_rockParticles, pos, 50);
		PhaserSprite phaserSprite2 = default(PhaserSprite);
		PhaserSprite phaserSprite = phaserSprite2.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num21 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 16000f;
			tweenConfig.ease = Ease.InCubic;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			bool flag3;
			if ((object)_leftCracks != null)
			{
				object obj4 = (object)phaserSprite2 - (object)_leftCracks;
				flag3 = obj4 == null;
			}
			else
			{
				flag3 = ((UnityEngine.Object)phaserSprite2).m_CachedPtr == (IntPtr)0;
			}
			if (flag3)
			{
				if (_leftCracksTween != null)
				{
					_leftCracksTween.Kill();
				}
				_leftCracksTween = multiTargetTween;
			}
			bool flag4;
			if ((object)_rightCracks != null)
			{
				object obj5 = (object)phaserSprite2 - (object)_rightCracks;
				flag4 = obj5 == null;
			}
			else
			{
				flag4 = ((UnityEngine.Object)phaserSprite2).m_CachedPtr == (IntPtr)0;
			}
			if (flag4)
			{
				if (_rightCracksTween != null)
				{
					_rightCracksTween.Kill();
				}
				_rightCracksTween = multiTargetTween;
			}
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void UpdateJoints(Enemy_TP_DeathArm arm, float xOffset, List<PhaserSprite> armSprites, float extraScale)
	{
		//IL_0034: Invalid comparison between F4 and I4
		//IL_0062: Expected F4, but got I4
		//IL_0413: Invalid comparison between I4 and F4
		//IL_007e: Expected F4, but got I4
		//IL_009b: Invalid comparison between F4 and I4
		//IL_00aa: Invalid comparison between F4 and I4
		//IL_00c3: Expected O, but got I4
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_018f: Expected O, but got I4
		//IL_01a0: Expected F4, but got I4
		//IL_04bf: Expected O, but got F4
		//IL_01f2: Expected O, but got F4
		//IL_0208: Expected O, but got F4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01d2: Expected F4, but got O
		//IL_056e: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected I4, but got Unknown
		//IL_0381: Expected I, but got O
		//IL_03b3: Expected F8, but got O
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_03e4: Expected F4, but got O
		//IL_03ca->IL03fa: Incompatible stack heights: 2 vs 0
		//IL_03fa->IL0640: Incompatible stack heights: 2 vs 0
		float2 start = base.position;
		float2 float5 = arm.position;
		float num2 = default(float);
		float num = ((!(num2 > 0f)) ? 0f : 1f);
		float num3 = ((!(0f > num2)) ? 0f : 1f);
		float num4 = num - num3;
		float num5 = num4 * 0f;
		float num6 = arm.scale;
		float num7 = num5 * num6;
		float num8 = num6 * 0.25f;
		float num9 = (float)float5 + num7;
		object obj = default(object);
		float num10 = (float)obj + num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		bool flag = num2 < 0f;
		bool flag2 = num2 == 0f;
		object obj2 = armSprites._size - 1;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		if ((nint)obj2 < 0)
		{
			return;
		}
		List<PhaserSprite> list = armSprites;
		float num11 = num9;
		float num12 = 1f;
		float num13 = 2f;
		object obj4 = default(object);
		float num22 = default(float);
		float value = default(float);
		Sprite sprite = default(Sprite);
		float num29 = default(float);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm13\"");
			double num14 = Math.Pow(0.0, 8.0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm14,xmm0\"");
			object obj3 = 0 * obj4;
			float num15 = (float)obj3 + num13;
			float num16 = num15 * 0.15f;
			float? num17 = (float?)(object)0;
			float num18 = num12;
			float num19 = 0f;
			bool flag6;
			do
			{
				num18 += -0.001f;
				float2 float6 = ArmSample(start, (float2)num9, num18);
				float num20 = (float)float6 - num11;
				float num21 = num22 - num10;
				float num23 = num20 * num20;
				float num24 = num21 * num21;
				float num25 = num23 + num24;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
				num19 += num25;
				if (num19 > num16)
				{
					break;
				}
				num17 = (float?)(object)((_003F?)num17 + 1);
				flag6 = (nint)num17 < 100;
				num10 = num22;
				num11 = (float)float6;
			}
			while (flag6);
			float2 float7 = ArmSample(start, (float2)num9, num18);
			float2 float8 = ArmSample(start, (float2)num9, num12);
			bool flag7 = (nint)obj2 >= armSprites._size;
			PhaserSprite[] items = armSprites._items;
			PhaserSprite phaserSprite = items[obj2];
			PhaserSprite phaserSprite2 = items[obj2].setFlipX(flag5);
			float num26 = ((!flag5) ? (-0.08f) : 0.08f);
			float originX = 0.5f - num26;
			PhaserSprite phaserSprite3 = items[obj2].setOrigin(originX, (float?)(object)1);
			object spriteRenderer = phaserSprite._spriteRenderer;
			((ArcadeSprite)arm).CheckRenderer();
			Color color = ((ArcadeSprite)arm)._spriteRenderer.color;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rsi_v9 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rsi_v9 (System.Object)+10]");
			SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
			PhaserSprite phaserSprite4 = items[obj2].setFrame(sprite);
			float num27 = (float)float8 - (float)float7;
			float num28 = num22 - num29;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
			float num30 = num28 * 57.29578f;
			float num31 = num30 + 90f;
			items[obj2].angle = num31;
			PhaserSprite phaserSprite5 = items[obj2].setScale(num15, (float?)(object)0);
			int num32 = arm.depth;
			object obj5 = num32 - obj2;
			int num33 = obj5 + armSprites._size;
			PhaserSprite phaserSprite6 = items[obj2].setDepth(num33);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 float9 = items[obj2].position;
			float2 float10 = items[obj2].position;
			nint num34 = (nint)typeof(VSDebug);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rcx_v37 (Il2CppClass<VSDebug>)+E4]");
			bool flag9 = (nint)0 < (nint)0;
			VSDebug.DrawDebugCircle((double)float9, num29, 0.02);
			obj2--;
			if (!flag9)
			{
				list = null;
				num10 = num29;
				num11 = (float)float7;
				num12 = num18;
				num13 = 2f;
				continue;
			}
			break;
		}
	}

	private float2 ArmSample(float2 start, float2 end, float t)
	{
		float2 result = default(float2);
		return result;
	}

	private void Cleanup()
	{
		//IL_027d->IL046f: Incompatible stack heights: 1 vs 0
		//IL_02b7->IL0501: Incompatible stack heights: 1 vs 0
		//IL_02fd->IL03ac: Incompatible stack heights: 1 vs 0
		//IL_033e->IL03ac: Incompatible stack heights: 2 vs 0
		//IL_037f->IL03ac: Incompatible stack heights: 3 vs 0
		Enemy_TP_DeathArm leftHand = _leftHand;
		Enemy_TP_DeathArm enemy_TP_DeathArm;
		if ((object)_leftHand != null && ((UnityEngine.Object)leftHand).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_leftHand == null)
			{
				goto IL_03ac;
			}
			_leftHand.Disappear();
			_leftHand = null;
			enemy_TP_DeathArm = null;
		}
		else
		{
			enemy_TP_DeathArm = null;
		}
		Enemy_TP_DeathArm rightHand = _rightHand;
		if ((object)_rightHand != null && ((UnityEngine.Object)rightHand).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_rightHand == null)
			{
				goto IL_03ac;
			}
			_rightHand.Disappear();
			_rightHand = enemy_TP_DeathArm;
		}
		if (_leftCracksTween != null)
		{
			_leftCracksTween.Kill();
		}
		if (_rightCracksTween != null)
		{
			_rightCracksTween.Kill();
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		if (_droppedRelicTween != null)
		{
			_droppedRelicTween.Kill();
		}
		if ((object)_leftCracks != null)
		{
			GameObject obj = _leftCracks.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			if ((object)_rightCracks != null)
			{
				GameObject obj2 = _rightCracks.gameObject;
				UnityEngine.Object.Destroy(obj2, 0f);
				if (_leftArmSprites != null)
				{
					List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
					while (enumerator.MoveNext())
					{
						object obj3 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdi_v27 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdi_v27 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						UnityEngine.Object.Destroy(obj4, 0f);
					}
					if (_rightArmSprites != null)
					{
						List<PhaserSprite>.Enumerator enumerator2 = default(List<PhaserSprite>.Enumerator);
						while (enumerator2.MoveNext())
						{
							object obj5 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ rdi_v25 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ rdi_v25 (System.Object)+10]");
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject obj6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							UnityEngine.Object.Destroy(obj6, 0f);
						}
						object leftEye = _leftEye;
						if ((object)_leftEye != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdi_v16 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdi_v16 (System.Object)+10]");
							IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject obj7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
							UnityEngine.Object.Destroy(obj7, 0f);
							object rightEye = _rightEye;
							if ((object)_rightEye != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v18 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v18 (System.Object)+10]");
								IntPtr gcHandlePtr4 = Component.get_gameObject_Injected((IntPtr)0);
								GameObject obj8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
								UnityEngine.Object.Destroy(obj8, 0f);
								object deathSpine = _deathSpine;
								if ((object)_deathSpine != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdi_v20 (System.Object)+10]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdi_v20 (System.Object)+10]");
									IntPtr gcHandlePtr5 = Component.get_gameObject_Injected((IntPtr)0);
									GameObject obj9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr5);
									UnityEngine.Object.Destroy(obj9, 0f);
									object deathCape = _deathCape;
									if ((object)_deathCape != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdi_v22 (System.Object)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdi_v22 (System.Object)+10]");
										IntPtr gcHandlePtr6 = Component.get_gameObject_Injected((IntPtr)0);
										GameObject obj10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr6);
										UnityEngine.Object.Destroy(obj10, 0f);
										_leftArmSprites = (List<PhaserSprite>)(object)enemy_TP_DeathArm;
										_rightArmSprites = (List<PhaserSprite>)(object)enemy_TP_DeathArm;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_03ac;
		IL_03ac:
		throw new NullReferenceException();
	}

	public void ScreenShake(int repeats = 6)
	{
		//IL_00b0: Expected I, but got O
		//IL_012f: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
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
		tweenConfig.duration = 32f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__75_0;
		if (_003C_003Ec._003C_003E9__75_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__75_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -2f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__75_1;
		if (_003C_003Ec._003C_003E9__75_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__75_1 = delegate
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

	public void SummonDirecter()
	{
		DeathFightDirecter directer = _directer;
		if ((object)_directer != null && ((UnityEngine.Object)directer).m_CachedPtr != (IntPtr)0)
		{
			Debug.LogWarning("We already have a directer!");
			return;
		}
		PhaserWorld instance = PhaserWorld.Instance;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdi_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		GameObject gameObject = instance._phaserSpritesParent.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183115F90");
		DeathFightDirecter directer2 = default(DeathFightDirecter);
		_directer = directer2;
		GameObject gameObject2 = _directer.gameObject;
		((UnityEngine.Object)gameObject2).SetName("Directer");
		DeathFightDirecter directer3 = _directer;
		directer3._death = this;
	}

	public bool HasDirecterBeenSummoned()
	{
		DeathFightDirecter directer = _directer;
		if ((object)_directer != null)
		{
			bool flag = ((UnityEngine.Object)directer).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public bool IsDirecterDead()
	{
		return _isDirecterDead;
	}

	public void DirecterStartBlocking(Transform target, EnemyController toBlock)
	{
		DeathFightDirecter directer = _directer;
		directer._protectionTarget = target;
		DeathFightDirecter directer2 = _directer;
		Transform projectileToBlock = toBlock.transform;
		directer2._projectileToBlock = projectileToBlock;
	}

	public void DoBlockingAnimation()
	{
		DeathFightDirecter._003C_BlockCutscene_003Ed__40 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = _directer;
		Coroutine coroutine = _directer.StartCoroutine(obj);
	}

	public void DirecterDied()
	{
		GameObject obj = _directer.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
		_directer = null;
		_isDirecterDead = true;
	}

	private void DropNextRelic()
	{
		//IL_006b: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected F4, but got Unknown
		//IL_01b2: Expected F4, but got I4
		//IL_01e0: Expected I, but got O
		//IL_01ee: Expected I, but got O
		//IL_01fe: Expected O, but got I
		//IL_027e: Expected O, but got I4
		//IL_023a: Expected O, but got I
		//IL_0270: Expected O, but got I4
		List<ItemType> relicsToDrop = _relicsToDrop;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		Pickup pickup;
		PickupRelic pickupRelic;
		object obj4;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj = -1;
				int num2 = default(int);
				if ((nint)obj > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
					Array.Copy((Array)num, 1, (Array)0, 0, num2);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer = s_scene._renderer;
					float num3 = renderer.width * 0.5f;
					if ((object)GM.Core != null && (object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float minInclusive = num3 ^ 0;
						float num4 = UnityEngine.Random.Range(minInclusive, num3);
						Vector2 pos = default(Vector2);
						ItemType relicType = default(ItemType);
						bool validatePickups = default(bool);
						pickup = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, num2, relicType, validatePickups);
						bool flag = (object)pickup == null;
						pickupRelic = null;
						if (!flag)
						{
							nint num5 = (nint)pickup;
							nint num6 = (nint)typeof(PickupRelic);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
							if (num7 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v49+FFFFFFF8+v583 @ rax_v45*8]");
								if (0 == (nint)typeof(PickupRelic))
								{
									obj4 = 1;
									goto IL_034c;
								}
							}
							obj4 = 0;
							goto IL_034c;
						}
						goto IL_0373;
					}
				}
				throw new NullReferenceException();
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0373:
		if ((object)pickupRelic != null && ((UnityEngine.Object)pickupRelic).m_CachedPtr != (IntPtr)0)
		{
			DoDropAnimation(pickupRelic);
		}
		else if (GM.Core.IsStageHost)
		{
			Debug.LogError("Death dropped pickup is null!");
		}
		return;
		IL_034c:
		bool flag2 = obj4 == null;
		pickupRelic = null;
		if (!flag2)
		{
			pickupRelic = (PickupRelic)pickup;
		}
		goto IL_0373;
	}

	private void DoDropAnimation(PickupRelic pickup)
	{
		//IL_00d8: Expected F4, but got I4
		//IL_01cb: Expected O, but got I
		//IL_053f: Expected O, but got I4
		//IL_0344: Expected I, but got O
		//IL_03bb: Expected O, but got I4
		//IL_03d7: Expected O, but got I4
		//IL_0585->IL044f: Incompatible stack heights: 1 vs 0
		//IL_0219->IL044f: Incompatible stack heights: 1 vs 0
		//IL_0248->IL044f: Incompatible stack heights: 1 vs 0
		//IL_02eb->IL044f: Incompatible stack heights: 1 vs 0
		//IL_026a->IL044f: Incompatible stack heights: 1 vs 0
		//IL_031a->IL044f: Incompatible stack heights: 1 vs 0
		//IL_0389->IL044f: Incompatible stack heights: 1 vs 0
		//IL_0367->IL0367: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass83_0();
		float duration;
		if (CS_0024_003C_003E8__locals14 != null)
		{
			CS_0024_003C_003E8__locals14.pickup = pickup;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						List<ItemType> relicsToDrop = _relicsToDrop;
						float num = renderer.width * 0.4f;
						if (_relicsToDrop != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							if ((nint)0 == 0)
							{
								num = 0f;
							}
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
								{
									PhaserScene s_scene3 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
									{
										float minInclusive = num ^ -0f;
										float num2 = UnityEngine.Random.Range(minInclusive, num);
										PickupRelic core = (PickupRelic)(object)GM.Core;
										if ((object)GM.Core != null)
										{
											PickupRelic mapTokenTexture = (PickupRelic)(object)core.MapTokenTexture;
											if (core.MapTokenTexture != null)
											{
												PickupRelic pickupRelic = (PickupRelic)(nint)((UnityEngine.Object)mapTokenTexture).m_CachedPtr;
												if (((UnityEngine.Object)mapTokenTexture).m_CachedPtr != (IntPtr)0)
												{
													bool flag = ((UnityEngine.Object)pickupRelic).m_CachedPtr == (IntPtr)0;
													object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)pickupRelic).m_CachedPtr);
													bool flag2 = obj != null;
													duration = 1750f;
													if (flag2)
													{
														goto IL_0568;
													}
													GameManager core2 = GM.Core;
													if ((object)GM.Core != null)
													{
														GameSessionData gameSessionData = core2._gameSessionData;
														if (core2._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
														{
															float2 float5 = gameSessionData._activeCharacter.position;
															duration = 2000f;
															goto IL_0568;
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
		goto IL_044f;
		IL_044f:
		throw new NullReferenceException();
		IL_0568:
		if ((object)CS_0024_003C_003E8__locals14.pickup != null)
		{
			CS_0024_003C_003E8__locals14.pickup.StopFloatTween();
			_droppedRelic = CS_0024_003C_003E8__locals14.pickup;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)CS_0024_003C_003E8__locals14.pickup != null)
			{
				Transform transform = CS_0024_003C_003E8__locals14.pickup.transform;
				if (array != null)
				{
					if ((object)transform != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						bool flag3 = obj2 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						tweenConfig.duration = duration;
						tweenConfig.x = (float?)(object)1;
						tweenConfig.ease = Ease.InOutSine;
						tweenConfig.y = (float?)(object)1;
						TweenCallback onStart = delegate
						{
							PickupRelic pickup2 = CS_0024_003C_003E8__locals14.pickup;
							((Pickup)pickup2)._003CDisableGet_003Ek__BackingField = true;
							PickupRelic pickup3 = CS_0024_003C_003E8__locals14.pickup;
							((Pickup)pickup3)._003CAutoSafeXY_003Ek__BackingField = false;
						};
						tweenConfig.onStart = onStart;
						TweenCallback onComplete = delegate
						{
							PickupRelic pickup2 = CS_0024_003C_003E8__locals14.pickup;
							bool flag4 = pickup2._itemType == ItemType.TP_RELIC_MASK_SEAWINDS;
							((Pickup)pickup2)._003CDisableGet_003Ek__BackingField = false;
							if (!flag4)
							{
								CS_0024_003C_003E8__locals14.pickup.StartFloatTween();
								PickupRelic pickup3 = CS_0024_003C_003E8__locals14.pickup;
								((Pickup)pickup3)._003CAutoSafeXY_003Ek__BackingField = true;
							}
							else
							{
								GameManager core3 = GM.Core;
								if (core3._multiplayer.IsOnlineMultiplayer)
								{
									CS_0024_003C_003E8__locals14.pickup.GetOnlineTaken();
								}
								else
								{
									CS_0024_003C_003E8__locals14.pickup.GetTaken();
								}
							}
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween droppedRelicTween = Tweens.Add(tweenConfig);
						_droppedRelicTween = droppedRelicTween;
						return;
					}
				}
			}
		}
		goto IL_044f;
	}

	public void SpawnAllies()
	{
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_01bb: Expected I, but got O
		//IL_00b5: Expected O, but got I
		//IL_010c: Expected I, but got O
		//IL_00eb: Expected O, but got I4
		_hasSpawnedAllies = true;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundTP_Basic fancyBg = (BackgroundTP_Basic)stage._fancyBg;
		BackgroundTP_Basic backgroundTP_Basic;
		if ((object)stage._fancyBg == null)
		{
			backgroundTP_Basic = null;
			goto IL_01d3;
		}
		nint num = (nint)typeof(BackgroundTP_Basic);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v35+FFFFFFF8+v113 @ rax_v31*8]");
			if (0 == (nint)typeof(BackgroundTP_Basic))
			{
				obj3 = 1;
				goto IL_019e;
			}
		}
		obj3 = 0;
		goto IL_019e;
		IL_019e:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(BackgroundTP_Basic);
		backgroundTP_Basic = null;
		if (!flag)
		{
			num4 = (nint)typeof(BackgroundTP_Basic);
			backgroundTP_Basic = (BackgroundTP_Basic)stage._fancyBg;
		}
		goto IL_01d3;
		IL_01d3:
		if ((object)backgroundTP_Basic != null && ((UnityEngine.Object)backgroundTP_Basic).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
			backgroundTP_Basic.SpawnDeathFightTile();
		}
		_003C_SpawnAllies_003Ed__89 obj4 = null;
		obj4._003C_003E1__state = 0;
		obj4._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj4);
	}

	private unsafe bool DoWeHaveThisAllyAlready(CharacterType type)
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public void PreSpawnAllies()
	{
		//IL_0255: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		bool manualLevelups = default(bool);
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-28_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-28_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-28_v3+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v10+20+v223 @ stack_-20_v2*4]");
						bool flag = DoWeHaveThisAllyAlready(CharacterType.VOID);
						obj4 = obj6;
						if (!flag)
						{
							GameManager core = GM.Core;
							CharacterController followedCharacter = VampireSurvivors.App.Tools.Extensions.PickRnd(core._mainCharacters);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v10+20+v534 @ rcx_v21*4]");
							CharacterController characterController = core.AddFollower(CharacterType.VOID, followedCharacter, AIType.DeathSequence, manualLevelups, everyXLevels, spawnWithoutAuthority);
							characterController.SetPermanentInvulnerability(on: true);
							characterController._003CTrackedByCamera_003Ek__BackingField = false;
							GameObject gameObject = characterController._healthBar.gameObject;
							gameObject.SetActive(value: false);
							characterController.DisableIfFollower();
							characterController._coherenceSync.enabled = false;
							GameObject gameObject2 = characterController._multiplayerOutliner.gameObject;
							gameObject2.SetActive(value: false);
							Dictionary<CharacterType, CharacterController> alliesControllers = _AlliesControllers;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v10+20+v534 @ rcx_v21*4]");
							bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)alliesControllers).TryInsert((System.Int32Enum)0, (object)characterController, System.Collections.Generic.InsertionBehavior.None);
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj == null;
		Enemy_TP_Death enemy_TP_Death = (Enemy_TP_Death)0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ stack_-28_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			enemy_TP_Death = null;
		}
		throw new NullReferenceException();
	}

	private IEnumerator _SpawnAllies()
	{
		_003C_SpawnAllies_003Ed__89 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SpawnAlly(CharacterType charType)
	{
		//IL_0253: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_0303: Expected O, but got I
		//IL_033a: Expected O, but got I
		//IL_023e->IL0387: Incompatible stack heights: 4 vs 0
		//IL_033f->IL0387: Incompatible stack heights: 8 vs 0
		if (_AlliesControllers != null)
		{
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)_AlliesControllers).TryGetValue((System.Int32Enum)charType, out object value);
			if (value == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene2._renderer;
						if (s_scene2._renderer != null && (object)GM.Core != null)
						{
							PhaserScene s_scene3 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer2 = s_scene3._renderer;
								if (s_scene3._renderer != null)
								{
									float minInclusive = renderer.width * -0.4f;
									float maxInclusive = renderer2.width * 0.4f;
									float num = UnityEngine.Random.Range(minInclusive, maxInclusive);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene4 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene4._renderer != null && value != null)
										{
											float2 float5 = default(float2);
											((ArcadeSprite)value).position = float5;
											if (value != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+10]");
												bool flag2 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+10]");
												IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
												Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
												float2 float6 = base.position;
												bool flag3 = (object)transform == null;
												bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												float2 value2 = default(float2);
												Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
												bool flag5 = value == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+64]");
												if ((nint)0 < (nint)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+C0]");
													CharacterWeaponsManager characterWeaponsManager = (CharacterWeaponsManager)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+C0]");
													bool flag6 = (nint)0 == 0;
													characterWeaponsManager._maxActiveCount = -1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+C0]");
													((CharacterWeaponsManager)0).SetMaxWeaponCount(characterWeaponsManager._maxActiveCount, characterWeaponsManager._maxHiddenCount);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+28]");
													bool flag7 = (nint)0 == 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+68]");
													bool flag8 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+68]");
													((Renderer)0).enabled = true;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+E0]");
													bool flag9 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_8_v8 (System.Object)+E0]");
													((Behaviour)0).enabled = true;
												}
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
		throw new NullReferenceException();
	}

	public Enemy_TP_Death()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_10c7: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_10ef: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_1117: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_113f: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_1167: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_118f: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_11b7: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_11df: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_1207: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_122f: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_1257: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_127f: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_12a7: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_12cf: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_12f7: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_131f: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_1347: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_136f: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_1397: Expected O, but got I
		//IL_0860: Expected O, but got I
		//IL_13bf: Expected O, but got I
		//IL_08ca: Expected O, but got I
		//IL_13e7: Expected O, but got I
		//IL_0934: Expected O, but got I
		//IL_140f: Expected O, but got I
		//IL_099e: Expected O, but got I
		//IL_1437: Expected O, but got I
		//IL_0a08: Expected O, but got I
		//IL_145f: Expected O, but got I
		//IL_0a72: Expected O, but got I
		//IL_1487: Expected O, but got I
		//IL_0adc: Expected O, but got I
		//IL_14af: Expected O, but got I
		//IL_0b46: Expected O, but got I
		//IL_14d7: Expected O, but got I
		//IL_0bb0: Expected O, but got I
		//IL_14ff: Expected O, but got I
		//IL_0c1a: Expected O, but got I
		//IL_1527: Expected O, but got I
		//IL_0c84: Expected O, but got I
		//IL_154f: Expected O, but got I
		//IL_0cee: Expected O, but got I
		//IL_1577: Expected O, but got I
		//IL_0d58: Expected O, but got I
		//IL_159f: Expected O, but got I
		//IL_0dc2: Expected O, but got I
		//IL_15c7: Expected O, but got I
		//IL_0e2c: Expected O, but got I
		//IL_15ef: Expected O, but got I
		//IL_0e96: Expected O, but got I
		//IL_1617: Expected O, but got I
		//IL_0f00: Expected O, but got I
		//IL_163f: Expected O, but got I
		//IL_0f6a: Expected O, but got I
		//IL_1667: Expected O, but got I
		//IL_0fd4: Expected O, but got I
		//IL_168f: Expected O, but got I
		//IL_103f: Expected O, but got I
		_bigScytheScreamTime = 5f;
		_bigScythePostScreamThrowTime = 1f;
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)222);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 222;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)234);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 234;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)239);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 239;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)238);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 238;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)213);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 213;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)214);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 214;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)202);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 202;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)241);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 241;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)232);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 232;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)221);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 221;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)224);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)231);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 231;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v28+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)218);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 218;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v30+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)211);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 211;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v32+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)217);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 217;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v34+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)206);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 206;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v36+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)219);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 219;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v38+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)233);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 233;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v40+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)240);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 240;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v42+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v44+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v46+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v48+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v50+18]");
		if (num24 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)22);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 22;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v52+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)11);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v54+18]");
		if (num26 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v56+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v58+18]");
		if (num28 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)13);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 13;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v60+18]");
		if (num29 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v62+18]");
		if (num30 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 14;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v64+18]");
		if (num31 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v66+18]");
		if (num32 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v68+18]");
		if (num33 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj66 = (nint)0 + (nint)1;
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v70+18]");
		if (num34 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj68 = (nint)0 + (nint)1;
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v72+18]");
		if (num35 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)18);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj70 = (nint)0 + (nint)1;
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v74+18]");
		if (num36 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)21);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj72 = (nint)0 + (nint)1;
			_ = 21;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj73 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v76+18]");
		if (num37 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj74 = (nint)0 + (nint)1;
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj75 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v78+18]");
		if (num38 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj76 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj77 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v80+18]");
		if (num39 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj78 = (nint)0 + (nint)1;
			_ = 40;
		}
		list.Add(CharacterType.TATANKA);
		list.Add(CharacterType.TP_DRACULA);
		_Allies = list;
		_AlliesControllers = new Dictionary<CharacterType, CharacterController>();
		base._002Ector();
	}

	private void _003CActuallyRemove_003Eb__50_0()
	{
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		FadeOut();
	}

	private void _003COnUpdate_003Eb__61_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A60B6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_SpriteAnimation.SetAnimation("Idle");
	}

	private void _003C_SpawnAllies_003Eb__89_0()
	{
		_canDie = true;
	}
}
