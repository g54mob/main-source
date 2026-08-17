using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundCoop : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__39_1;

		public static Action _003C_003E9__39_2;

		public static TweenCallback _003C_003E9__39_0;

		public static TweenCallback _003C_003E9__39_3;

		public static TweenCallback _003C_003E9__39_4;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CStartFinalSequence_003Eb__39_0()
		{
			//IL_00d1: Expected O, but got I4
			//IL_005d: Expected I4, but got F4
			//IL_0099: Expected I4, but got F4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Detune = -200f;
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig, 200f, 3, num);
			Action onComplete = _003C_003E9__39_1;
			if (_003C_003E9__39_1 == null)
			{
				onComplete = (_003C_003E9__39_1 = delegate
				{
					//IL_003d: Expected O, but got I4
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					soundConfig2.Volume = (float?)(object)1;
					soundConfig2.Detune = 200f;
					soundConfig2.Rate = 1f;
					float time = default(float);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig2, 200f, 3, time);
				});
			}
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.15f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete2 = _003C_003E9__39_2;
			if (_003C_003E9__39_2 == null)
			{
				onComplete2 = (_003C_003E9__39_2 = delegate
				{
					//IL_003d: Expected O, but got I4
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					soundConfig2.Volume = (float?)(object)1;
					soundConfig2.Detune = 100f;
					soundConfig2.Rate = 1f;
					float time = default(float);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig2, 200f, 3, time);
				});
			}
			Timer timer2 = Timers.Register(0.3f, onComplete2, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CStartFinalSequence_003Eb__39_1()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 200f;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig, 200f, 3, time);
		}

		internal void _003CStartFinalSequence_003Eb__39_2()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 100f;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig, 200f, 3, time);
		}

		internal void _003CStartFinalSequence_003Eb__39_3()
		{
		}

		internal void _003CStartFinalSequence_003Eb__39_4()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CPassedGaeaEvent_003Ek__BackingField = true;
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5510");
		}
	}

	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public SpriteAnimation spriteAnimation;

		public BackgroundCoop _003C_003E4__this;

		internal void _003CStartGaeaEvent_003Eb__0()
		{
			SpriteAnimation spriteAnimation = this.spriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			_003C_003E4__this.StartFinalSequence();
		}
	}

	public int zoneNum;

	private Timer _gaeaEventTimer;

	private bool _activated;

	private bool _hasSpeedUpClock;

	private BgmType _saveBgm;

	private BgmModType _saveBgmMod;

	private List<PhaserSprite> _barriers;

	private List<PhaserSprite> _brokenBarriers;

	private bool _firstEnemyKilled;

	private Bounds _pickupSafeAreaBounds;

	private PhaserSprite _AGaeaSprite;

	private PhaserSprite _eyeSpriteL;

	private PhaserSprite _eyeSpriteR;

	private MultiTargetTween faceTween;

	private MultiTargetTween fadeOutTween;

	private float _colorValue;

	private PhaserSprite _backgroundTile;

	private bool _changeBGColor = true;

	private bool _gaeaEventStarted;

	public override bool SpawnEnemiesOnStart => false;

	public override void Create()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0449: Expected I4, but got O
		//IL_0449: Expected F4, but got I4
		base.Create();
		_activated = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool hasSpeedUpClock;
		if ((nint)0 == 0)
		{
			hasSpeedUpClock = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag = obj == null;
			hasSpeedUpClock = !flag;
		}
		_hasSpeedUpClock = hasSpeedUpClock;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<AchievementType> list2 = config2._003CAchievements_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				goto IL_0209;
			}
		}
		GameManager core3 = GM.Core;
		bool flag2 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!core3._multiplayer.IsOnlineMultiplayer)
		{
			Action onComplete = CheckForGaeaEvent;
			Timer gaeaEventTimer = Timers.Register(60.000004f, onComplete, null, isLooped: false, flag2, monoBehaviour, repeat, type, isOnlineTimer: false, canPause: false);
			_gaeaEventTimer = gaeaEventTimer;
		}
		else if (GM.Core.IsStageHost)
		{
			Action onComplete2 = CheckForGaeaEvent;
			Timer gaeaEventTimer2 = Timers.Register(60.000004f, onComplete2, null, isLooped: false, flag2, monoBehaviour, repeat, type, isOnlineTimer: false, canPause: false);
			_gaeaEventTimer = gaeaEventTimer2;
		}
		goto IL_0209;
		IL_0209:
		GameManager core4 = GM.Core;
		if (!core4._multiplayer.IsOnlineMultiplayer || GM.Core.IsStageHost)
		{
			Action<GameplaySignals.RemoveEnemyFromStageSignal> action = null;
			((BackgroundCoop)(object)action).OnEnemyRemovedFromStage((GameplaySignals.RemoveEnemyFromStageSignal)this);
			((BackgroundCoop)(object)_signalBus).OnEnemyRemovedFromStage((GameplaySignals.RemoveEnemyFromStageSignal)action);
		}
		CharmMod = 0f;
		GameManager core5 = GM.Core;
		PlayerOptionsData config3 = core5._playerOptions.Config;
		if (config3._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core6 = GM.Core;
			float num = core6._eggManager.RemoveBonuses();
			GameManager core7 = GM.Core;
			core7._stage.RecalculateCurseAndCharm();
		}
		GameManager core8 = GM.Core;
		core8._stage.ResetStageMinimumSpawnToDefault();
		GameManager core9 = GM.Core;
		Stage stage = core9._stage;
		stage._maximum = stage._defaultMaximum;
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		ObjectPool pool = PickupManager._pickupFactory.GetPool(ItemType.ROAST);
		pool.Populate(50);
		GameManager core10 = GM.Core;
		PlayerOptionsData config4 = core10._playerOptions.Config;
		_saveBgm = config4._003CSelectedBGM_003Ek__BackingField;
		GameManager core11 = GM.Core;
		PlayerOptionsData config5 = core11._playerOptions.Config;
		_saveBgmMod = config5._003CSelectedBGMMod_003Ek__BackingField;
		GM.Core.SetHardBoundsMinMax(0f, 128f, 1024f, flag2 ? 1 : 0, (byte)(int)monoBehaviour != 0);
		CreateBarriers();
		GameManager core12 = GM.Core;
		Stage stage2 = core12._stage;
		GameManager core13 = GM.Core;
		Stage stage3 = core13._stage;
		GameManager core14 = GM.Core;
		Stage stage4 = core14._stage;
		GameManager core15 = GM.Core;
		Stage stage5 = core15._stage;
		if ((object)stage2._003CMinTreasureX_003Ek__BackingField != null && (object)stage4._003CMaxTreasureX_003Ek__BackingField != null && (object)stage3._003CMinTreasureY_003Ek__BackingField != null && (object)stage5._003CMaxTreasureY_003Ek__BackingField != null)
		{
			Bounds pickupSafeAreaBounds = default(Bounds);
			_pickupSafeAreaBounds = pickupSafeAreaBounds;
		}
	}

	private void OnEnemyRemovedFromStage(GameplaySignals.RemoveEnemyFromStageSignal obj)
	{
		//IL_0103: Expected O, but got I8
		//IL_00e2: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (VampireSurvivors.Signals.GameplaySignals+RemoveEnemyFromStageSignal)+19C]");
		if ((nint)0 == 870)
		{
			Action<GameplaySignals.RemoveEnemyFromStageSignal> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804A2950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3D00");
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				_firstEnemyKilled = true;
			}
			else if (GM.Core.IsStageHost)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				Action<long> action2 = null;
				long num = default(long);
				((OnlineStageManager)(object)action2).CoopSetFirstEnmemyKilled(num);
				long startingOnlineClientFrame = ((OnlineStageManager)num).GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v12 (System.Int64)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action2, MessageTarget.All, startingOnlineClientFrame);
			}
		}
	}

	public void SetFirstEnmemyKilled()
	{
		_firstEnemyKilled = true;
	}

	private unsafe void CreateBarriers()
	{
		//IL_0307: Expected I, but got O
		//IL_0063: Expected I4, but got I8
		//IL_007f: Expected O, but got Ref
		//IL_019b: Expected I4, but got I8
		//IL_0207: Expected O, but got I4
		//IL_0207: Expected I4, but got O
		List<PhaserSprite> barriers = new List<PhaserSprite>();
		_barriers = barriers;
		int num = 0;
		Vector2 vector = default(Vector2);
		object obj = default(object);
		do
		{
			PhaserWorld instance = PhaserWorld.Instance;
			nint num2 = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num3 = 0;
			PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "enemies2023", "coop_handrail");
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1998);
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
			string text2 = "CoopBarrier" + text;
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName(text2);
			if (num <= 0)
			{
			}
			PhaserSprite phaserSprite3 = phaserSprite.setPosition(vector);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			num++;
		}
		while (num < 17);
		List<PhaserSprite> brokenBarriers = new List<PhaserSprite>();
		_brokenBarriers = brokenBarriers;
		string text3 = default(string);
		int num4 = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("coop_handrail_broken0", 0, 15, vector, text3, num4, flag);
		int num5 = 0;
		bool autoSetAnimation = default(bool);
		bool flag2;
		do
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite4 = instance2.AddPhaserSprite(vector, "enemies2023", "coop_handrail_broken000");
			PhaserSprite phaserSprite5 = phaserSprite4.setDepth(-1997);
			PhaserSprite phaserSprite6 = phaserSprite4.setAlpha(0f);
			GameObject gameObject2 = phaserSprite4.gameObject;
			((UnityEngine.Object)gameObject2).SetName("coopBarrierBroken");
			phaserSprite4._spriteAnimation.AddAnimation("Explode", animationFrames, 16, (byte)(int)text3 != 0, (byte)num4 != 0, (Action)flag, autoSetAnimation);
			List<object> brokenBarriers2 = (List<object>)(object)_brokenBarriers;
			int version = brokenBarriers2._version + 1;
			brokenBarriers2._version = version;
			object[] items = brokenBarriers2._items;
			if (brokenBarriers2._size >= items.Length)
			{
				brokenBarriers2.AddWithResize((object)phaserSprite4);
			}
			else
			{
				int size = brokenBarriers2._size + 1;
				brokenBarriers2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num5++;
			flag2 = num5 < 10;
			text3 = text3;
		}
		while (flag2);
	}

	public override void OnInitCompleted()
	{
		base.OnInitCompleted();
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		if (stage._spawnTimer != null)
		{
			stage._spawnTimer.Cancel();
		}
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		if (_hasSpeedUpClock)
		{
			goto IL_025d;
		}
		GameManager core3 = GM.Core;
		PlayerOptions playerOptions = core3._playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_030d;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_030d;
		IL_025d:
		ChangeBGMRate(0.7f);
		return;
		IL_030d:
		playerOptionsData._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_TheCoop;
		GameManager core4 = GM.Core;
		PlayerOptions playerOptions2 = core4._playerOptions;
		PlayerOptionsData playerOptionsData2;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_034e;
					}
				}
				playerOptionsData2 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_034e;
		IL_034e:
		playerOptionsData2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GM.Core.SetupMusicBanger();
		goto IL_025d;
	}

	public override bool HasExtraSafeXYLogic()
	{
		return true;
	}

	public unsafe override float2 ExtraSafeXY(float2 position, float2 playerPosition)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0033: Expected O, but got I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		object obj = this + 180;
		float2 point = default(float2);
		object obj2 = Bounds.Contains_Injected(ref *(Bounds*)obj, ref *(Vector3*)(&point));
		if (obj2 != null)
		{
			return position;
		}
		object obj3 = this + 180;
		float2 point2 = default(float2);
		Bounds.ClosestPoint_Injected(ref *(Bounds*)obj3, ref *(Vector3*)(&point2), out Vector3 _);
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 8f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BE70");
		float2 result = default(float2);
		return result;
	}

	public override void CheckMinute(int minute)
	{
		ChangeZone(minute);
	}

	public void ChangeZone(int zone)
	{
		//IL_006a: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_00b1: Expected O, but got I8
		//IL_00e8: Expected O, but got I8
		//IL_0453: Expected O, but got I4
		//IL_0461: Expected F4, but got O
		//IL_01e9: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_0398: Expected O, but got I4
		//IL_04c8: Expected O, but got F4
		//IL_03e7: Expected O, but got I4
		//IL_02a7: Expected F4, but got O
		//IL_02cc: Expected O, but got I4
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		object obj = default(object);
		bool flag = (nint)obj < 0;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		object obj3 = (object?)stageModifiers._003CEndCycles_003Ek__BackingField & obj2;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		if (obj4 != null)
		{
			return;
		}
		object obj5 = 6442450944L;
		if (zone <= 10)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r12_v7+6F1848C+zone @ rdx (System.Int32)*4]");
			object obj6 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v506 @ rcx_v48 (should have been resolved before IL gen)");
		}
		float num5 = default(float);
		if (zone > 0)
		{
			List<PhaserSprite> barriers = _barriers;
			if (zone < barriers._size)
			{
				if (zone > 15)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				PhaserSprite phaserSprite = default(PhaserSprite);
				TweenerCore<Color, Color, ColorOptions> gameId = DOTweenModuleSprite.DOFade(phaserSprite._spriteRenderer, 0f, 0.3f);
				Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
				float2 position = phaserSprite.position;
				float2 position2 = phaserSprite.position;
				List<PhaserSprite> brokenBarriers = _brokenBarriers;
				float num = (float)obj - 1.4399999f;
				float? num2 = (float?)(object)0;
				float? num3 = (float?)(object)0;
				while ((nint)num3 < brokenBarriers._size)
				{
					List<PhaserSprite> brokenBarriers2 = _brokenBarriers;
					if ((nint)num2 < brokenBarriers2._size)
					{
						PhaserSprite[] items = brokenBarriers2._items;
						PhaserSprite phaserSprite2 = items[(object)num2];
						PhaserSprite phaserSprite3 = items[(object)num2].setAlpha(1f);
						float num4 = (float)num2 * 0.32f;
						float y = num4 + num;
						PhaserSprite phaserSprite4 = items[(object)num2].setPosition((float)position, y);
						PhaserSprite phaserSprite5 = items[(object)num2].setScale(1f, (float?)(object)0);
						Transform target = items[(object)num2].transform;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 2f, 0.3f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						phaserSprite2._spriteAnimation.SetAnimation("Explode");
						brokenBarriers = _brokenBarriers;
						num2 = (float?)(object)((_003F?)num2 + 1);
						num3 = num2;
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 2f;
				object obj7 = UnityEngine.Random.value;
				float detune = (float)obj * 200f;
				soundConfig.Detune = detune;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Carrello, soundConfig, 150f, 2, num5);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				soundConfig2.Detune = -500f;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Lid, soundConfig2, 150f, 2, num5);
				goto IL_0445;
			}
		}
		if (zone <= 15)
		{
			goto IL_0445;
		}
		return;
		IL_0445:
		object obj8 = zone + 1;
		float xMax = obj8 << 10;
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(0f, 128f, xMax, num5, skipInverseCalculation);
	}

	protected override void OnUpdate()
	{
		if (!_activated)
		{
			if (_firstEnemyKilled && !_gaeaEventStarted)
			{
				Activate();
				_activated = true;
			}
			if (_gaeaEventStarted)
			{
				GaeaEventUpdate();
			}
		}
		base.OnUpdate();
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = _saveBgm;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = _saveBgmMod;
	}

	private void Activate()
	{
		//IL_01d8: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		PickupMerchant trouserMerchant = stage.TrouserMerchant;
		if ((object)stage.TrouserMerchant != null && ((UnityEngine.Object)trouserMerchant).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			PickupMerchant trouserMerchant2 = stage2.TrouserMerchant;
			if (trouserMerchant2.body != null)
			{
				GameManager core3 = GM.Core;
				Stage stage3 = core3._stage;
				PickupMerchant trouserMerchant3 = stage3.TrouserMerchant;
				trouserMerchant3._spriteAnimation.CleanAnimations();
				int num = default(int);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("PantaloneRun_0", 1, 2, "items", num);
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				trouserMerchant3._spriteAnimation.AddAnimation("run", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
				trouserMerchant3._spriteAnimation.SetAnimation("run");
				BaseBody body = trouserMerchant3.body;
				body._velocity = (float2)1077936128;
			}
		}
		ChangeZone(0);
		CharmMod = 1f;
		CurseMod = 1f;
		GameManager core4 = GM.Core;
		core4._stage.RecalculateCurseAndCharm();
		GameManager core5 = GM.Core;
		core5._canRunTickerTimer = true;
		GameManager core6 = GM.Core;
		core6._stage.StartTimers();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private void ChangeBGMRate(float value)
	{
		if (SoundManager._003CCurrentBgm_003Ek__BackingField == BgmType.BGM_TheCoop)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
			SoundManager.SoundConfig config = default(SoundManager.SoundConfig);
			SoundManager.UpdateCurrentMusicWithConfig(config);
		}
	}

	protected override void OnDestroy()
	{
		if (_gaeaEventTimer != null)
		{
			_gaeaEventTimer.Cancel();
		}
		if (!_firstEnemyKilled)
		{
			Action<GameplaySignals.RemoveEnemyFromStageSignal> action = null;
			((BackgroundCoop)(object)action).OnEnemyRemovedFromStage((GameplaySignals.RemoveEnemyFromStageSignal)this);
			((BackgroundCoop)(object)_signalBus).OnEnemyRemovedFromStage((GameplaySignals.RemoveEnemyFromStageSignal)action);
		}
		base.OnDestroy();
	}

	private void InitBackground()
	{
		//IL_0160: Expected I4, but got I8
		GameManager core = GM.Core;
		TilingBackground bgMan = core._bgMan;
		TileSprite bgtile = bgMan._bgtile;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile._spriteRenderer, 0f);
		Camera main = Camera.main;
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(main);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float width = renderer.width * 100f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float height = renderer2.height * 100f;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		uint fillColor = default(uint);
		PhaserSprite backgroundTile = instance.AddRectangle(pos, width, height, fillColor);
		_backgroundTile = backgroundTile;
		PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(_backgroundTile, 0f);
		PhaserSprite phaserSprite2 = _backgroundTile.setAlpha(0f);
		PhaserSprite phaserSprite3 = _backgroundTile.setDepth(-32768);
		GameObject gameObject = _backgroundTile.gameObject;
		((UnityEngine.Object)gameObject).SetName("CoopBackgroundTile");
	}

	private unsafe void GaeaEventUpdate()
	{
		//IL_014b->IL0115: Incompatible stack heights: 1 vs 0
		bool flag = !_changeBGColor;
		float num = (_colorValue += 0.01f);
		if (flag)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num2 = num * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		PhaserSprite backgroundTile = _backgroundTile;
		if ((object)_backgroundTile != null)
		{
			PhaserSprite spriteRenderer = (PhaserSprite)(object)backgroundTile._spriteRenderer;
			if ((object)backgroundTile._spriteRenderer != null)
			{
				bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void CheckForGaeaEvent()
	{
		//IL_0102: Expected O, but got I8
		//IL_00d4: Expected O, but got I
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CRunEnemies_003Ek__BackingField == 0)
		{
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				StartGaeaEvent();
			}
			else if (GM.Core.IsStageHost)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				Action<long> action = null;
				long num = default(long);
				((OnlineStageManager)(object)action).StartCoopGaeaEvent(num);
				long startingOnlineClientFrame = ((OnlineStageManager)num).GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v13 (System.Int64)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		}
	}

	public unsafe void StartGaeaEvent()
	{
		//IL_0c3a: Expected I, but got O
		//IL_003e: Expected I, but got O
		//IL_04ac: Expected O, but got I
		//IL_04d2: Expected I, but got O
		//IL_053b: Expected O, but got I
		//IL_0575: Expected O, but got I
		//IL_05e8: Expected O, but got I4
		//IL_05e8: Expected O, but got I
		//IL_0627: Expected O, but got I
		//IL_066b: Expected O, but got I4
		//IL_066b: Expected O, but got I
		//IL_06aa: Expected O, but got I
		//IL_072a: Expected O, but got I
		//IL_0744: Expected O, but got I
		//IL_077f: Expected O, but got I4
		//IL_077f: Expected O, but got I
		//IL_079e: Expected O, but got I
		//IL_07c2: Expected O, but got I4
		//IL_07c2: Expected O, but got I
		//IL_07e1: Expected O, but got I
		//IL_0800: Expected O, but got I
		//IL_081a: Expected O, but got I
		//IL_083e: Expected O, but got I
		//IL_0858: Expected O, but got I
		//IL_0893: Expected O, but got I4
		//IL_0893: Expected O, but got I
		//IL_08b2: Expected O, but got I
		//IL_08d6: Expected O, but got I4
		//IL_08d6: Expected O, but got I
		//IL_08f5: Expected O, but got I
		//IL_0914: Expected O, but got I
		//IL_092e: Expected O, but got I
		//IL_0dbc: Expected O, but got I
		//IL_0952: Expected O, but got I
		//IL_09e7: Expected O, but got I
		//IL_0aad: Expected I, but got O
		//IL_0ac3: Expected O, but got I
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad1: Expected O, but got Unknown
		//IL_0b47: Expected I, but got O
		//IL_0dca: Expected O, but got I4
		//IL_0de1: Expected I, but got I8
		//IL_0b23: Expected I, but got I8
		_003C_003Ec__DisplayClass38_0 obj = new _003C_003Ec__DisplayClass38_0();
		bool flag = obj == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass38_0);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		TweenCallback tweenCallback;
		if (!flag)
		{
			obj._003C_003E4__this = this;
			bool flag2 = (object)GM.Core == null;
			num = (nint)GM.Core;
			if (!flag2)
			{
				GM.Core.SetAllPlayersWeaponsActive(active: false);
				_gaeaEventStarted = true;
				InitBackground();
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					core._canRunTickerTimer = false;
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage = core2._stage;
						if ((object)core2._stage != null)
						{
							if (stage._spawnTimer != null)
							{
								stage._spawnTimer.Cancel();
							}
							if ((object)GM.Core != null)
							{
								_ = 0;
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null)
								{
									core3._003CCanPause_003Ek__BackingField = false;
									GameManager core4 = GM.Core;
									if ((object)GM.Core != null)
									{
										PhysicsGroup enemies = core4.Enemies;
										if (core4.Enemies != null && ((Group)enemies).children != null)
										{
											Tilemap tilemap = null;
											HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
											if (enumerator.MoveNext())
											{
												Component component = null;
												throw new NullReferenceException();
											}
											GameManager core5 = GM.Core;
											if ((object)GM.Core != null)
											{
												Stage stage2 = core5._stage;
												if ((object)core5._stage != null)
												{
													TilingTileset tilingTileset = stage2._tilingTileset;
													if ((object)stage2._tilingTileset != null && tilingTileset._maps != null)
													{
														List<SuperTiled2Unity.SuperMap>.Enumerator enumerator2 = default(List<SuperTiled2Unity.SuperMap>.Enumerator);
														if (enumerator2.MoveNext())
														{
															ArrayTypeMismatchException ex = null;
															throw new NullReferenceException();
														}
														SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 1000f);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+28]");
														Bounds bounds = CameraExtensions.OrthographicBounds((Camera)0);
														PhaserWorld instance = PhaserWorld.Instance;
														bool flag3 = (object)instance == null;
														num = unchecked((nint)null);
														if (!flag3)
														{
															Vector2 pos = default(Vector2);
															PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "enemies2023", "AGaea_i01");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																Transform transform = ((Component)0).transform;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+28]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+28]");
																	Transform parent = ((Component)0).transform;
																	if ((object)transform != null)
																	{
																		transform.SetParent(parent, worldPositionStays: true);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																			PhaserSprite phaserSprite2 = ((PhaserSprite)0).setOrigin(0.5f, (float?)(object)1);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																				PhaserSprite phaserSprite3 = ((PhaserSprite)0).setFlipX(flipX: true);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																				if ((nint)0 != 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																					PhaserSprite phaserSprite4 = ((PhaserSprite)0).setScale(1.5f, (float?)(object)0);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																					if ((nint)0 != 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																						PhaserSprite phaserSprite5 = ((PhaserSprite)0).setDepth(10000);
																						PhaserWorld instance2 = PhaserWorld.Instance;
																						if ((object)instance2 != null)
																						{
																							PhaserSprite phaserSprite6 = instance2.AddPhaserSprite(pos, "vfx", "vfx_gEye2");
																							PhaserWorld instance3 = PhaserWorld.Instance;
																							PhaserSprite phaserSprite7 = instance3.AddPhaserSprite(pos, "vfx", "vfx_gEye2");
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							Transform transform2 = ((Component)0).transform;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+28]");
																							Transform parent2 = ((Component)0).transform;
																							transform2.SetParent(parent2, worldPositionStays: true);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							PhaserSprite phaserSprite8 = ((PhaserSprite)0).setOrigin(0.5f, (float?)(object)1);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							PhaserSprite phaserSprite9 = ((PhaserSprite)0).setFlipX(flipX: false);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							PhaserSprite phaserSprite10 = ((PhaserSprite)0).setScale(2f, (float?)(object)1);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							PhaserSprite phaserSprite11 = ((PhaserSprite)0).setAlpha(1f);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							PhaserSprite phaserSprite12 = ((PhaserSprite)0).setDepth(20000);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D8]");
																							Transform transform3 = ((Component)0).transform;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ rax_v99 (UnityEngine.Transform)+10]");
																							bool flag4 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ rax_v99 (UnityEngine.Transform)+10]");
																							Vector2 value = default(Vector2);
																							Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							Transform transform4 = ((Component)0).transform;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+28]");
																							Transform parent3 = ((Component)0).transform;
																							transform4.SetParent(parent3, worldPositionStays: true);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							PhaserSprite phaserSprite13 = ((PhaserSprite)0).setOrigin(0.5f, (float?)(object)1);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							PhaserSprite phaserSprite14 = ((PhaserSprite)0).setFlipX(flipX: true);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							PhaserSprite phaserSprite15 = ((PhaserSprite)0).setScale(2f, (float?)(object)1);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							PhaserSprite phaserSprite16 = ((PhaserSprite)0).setAlpha(1f);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							PhaserSprite phaserSprite17 = ((PhaserSprite)0).setDepth(20000);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+E0]");
																							Transform transform5 = ((Component)0).transform;
																							bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
																							Vector2 value2 = default(Vector2);
																							Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value2));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																							object obj2 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1684 @ rcx_v89+28]");
																							GameObject gameObject = ((Component)0).gameObject;
																							SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
																							obj.spriteAnimation = spriteAnimation;
																							bool flag6 = default(bool);
																							List<Sprite> animation = SpriteManager.GetAnimation("AGaea_i0", 1, 4, "enemies2023", flag6);
																							bool startRandomFrame = default(bool);
																							Action onComplete = default(Action);
																							bool autoSetAnimation = default(bool);
																							obj.spriteAnimation.AddAnimation("Idle", animation, 8, flag6, startRandomFrame, onComplete, autoSetAnimation);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ stack_8+D0]");
																							Transform target = ((Component)0).transform;
																							tweenerCore = ShortcutExtensions.DOLocalMoveY(target, -0.96f, 10f);
																							if (tweenerCore != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2742 @ rax_v124 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																								if ((nint)0 != 0)
																								{
																									_ = 1;
																									_ = 0;
																								}
																							}
																							tweenCallback = null;
																							nint num2 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ r10_v2 (Il2CppMethodInfo)+8]");
																							((Delegate)tweenCallback).method_ptr = (IntPtr)0;
																							((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass38_0._003CStartGaeaEvent_003Eb__0);
																							((Delegate)tweenCallback).m_target = obj;
																							((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ r10_v2 (Il2CppMethodInfo)+4C]");
																							object obj3 = (nint)0 >> 4;
																							object obj4 = obj3 & 1;
																							nint num3;
																							if (obj4 != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ r10_v2 (Il2CppMethodInfo)+52]");
																								if ((nint)0 == 0)
																								{
																									num3 = unchecked((nint)6447293664L);
																									goto IL_0dc1;
																								}
																							}
																							num3 = ((Delegate)tweenCallback).method_ptr;
																							((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
																							goto IL_0dc1;
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
		throw new NullReferenceException();
		IL_0dc1:
		object obj5 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2742 @ rax_v124 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GM.Core.ZoomZoomOnPlayer();
	}

	private unsafe void StartFinalSequence()
	{
		//IL_001c: Expected O, but got Ref
		//IL_00e5: Expected I, but got O
		//IL_0098: Expected I, but got O
		//IL_0122: Expected O, but got I4
		//IL_036a: Expected O, but got I4
		//IL_03ad: Expected O, but got I4
		//IL_01d7: Expected I, but got O
		//IL_022f: Expected I, but got O
		//IL_0285: Expected O, but got I4
		//IL_02bd: Expected O, but got I4
		PhaserSprite backgroundTile = _backgroundTile;
		_changeBGColor = false;
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOColor(backgroundTile._spriteRenderer, (Color)(&obj), 0.5f);
		if (fadeOutTween != null)
		{
			fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_AGaeaSprite != null)
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
		nint num2 = (nint)_AGaeaSprite;
		tweenConfig.duration = 500f;
		tweenConfig.delay = 500f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__39_0;
		bool flag = _003C_003Ec._003C_003E9__39_0 != null;
		object obj3 = 0;
		if (!flag)
		{
			TweenCallback tweenCallback = (_003C_003Ec._003C_003E9__39_0 = delegate
			{
				//IL_00d1: Expected O, but got I4
				//IL_005d: Expected I4, but got F4
				//IL_0099: Expected I4, but got F4
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Detune = -200f;
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float num5 = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig, 200f, 3, num5);
				Action onComplete2 = _003C_003Ec._003C_003E9__39_1;
				if (_003C_003Ec._003C_003E9__39_1 == null)
				{
					onComplete2 = (_003C_003Ec._003C_003E9__39_1 = delegate
					{
						//IL_003d: Expected O, but got I4
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Volume = (float?)(object)1;
						soundConfig2.Detune = 200f;
						soundConfig2.Rate = 1f;
						float time = default(float);
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig2, 200f, 3, time);
					});
				}
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.15f, onComplete2, null, isLooped: false, (byte)(int)num5 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				Action onComplete3 = _003C_003Ec._003C_003E9__39_2;
				if (_003C_003Ec._003C_003E9__39_2 == null)
				{
					onComplete3 = (_003C_003Ec._003C_003E9__39_2 = delegate
					{
						//IL_003d: Expected O, but got I4
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Volume = (float?)(object)1;
						soundConfig2.Detune = 100f;
						soundConfig2.Rate = 1f;
						float time = default(float);
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_bell2, soundConfig2, 200f, 3, time);
					});
				}
				Timer timer2 = Timers.Register(0.3f, onComplete3, null, isLooped: false, (byte)(int)num5 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			});
			num2 = 0;
			onStart = tweenCallback;
			obj3 = 0;
		}
		tweenConfig.onStart = onStart;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		fadeOutTween = multiTargetTween;
		if (faceTween != null)
		{
			faceTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_eyeSpriteL != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_eyeSpriteR != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.duration = 100f;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.delay = 4500f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = _003C_003Ec._003C_003E9__39_3;
		if (_003C_003Ec._003C_003E9__39_3 == null)
		{
			onStart2 = (_003C_003Ec._003C_003E9__39_3 = delegate
			{
			});
		}
		tweenConfig2.onStart = onStart2;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__39_4;
		if (_003C_003Ec._003C_003E9__39_4 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__39_4 = delegate
			{
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				config._003CPassedGaeaEvent_003Ek__BackingField = true;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5510");
			});
		}
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		faceTween = multiTargetTween2;
	}

	private unsafe void OnDrawGizmos()
	{
		Color value = default(Color);
		Gizmos.set_color_Injected(ref value);
		Bounds center = default(Bounds);
		Vector3 size = default(Vector3);
		Gizmos.DrawWireCube_Injected(ref *(Vector3*)(&center), ref size);
	}
}
