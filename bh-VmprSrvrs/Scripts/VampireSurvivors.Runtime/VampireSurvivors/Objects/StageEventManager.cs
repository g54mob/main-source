using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using Zenject;

namespace VampireSurvivors.Objects
{
	[UsedImplicitly]
	public class StageEventManager : IInitializable, IDisposable
	{
		private enum CardinalTypeEnum
		{
			Cardinal = 0,
			SubCardinal = 1,
			All = 2
		}

		public class EventTargetInstace
		{
			public int _eventTargetIndex;

			public Vector2 _eventTargetPosition;

			public EventTargetInstace(int eventTargetIndex, Vector2 eventTargetPosition)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_FB_BigFuzz_Pointer_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public object moreY;

			public StageEventManager _003C_003E4__this;

			public Action<Vector2> onSuccess;

			public Action onFailure;

			private float _003CdurationLeft_003E5__2;

			private int _003ClastSecond_003E5__3;

			private PhaserText _003Ctext_003E5__4;

			private NewsFeed _003CnewsFeed_003E5__5;

			private Vector2 _003CtargetLocation_003E5__6;

			private EventTargetInstace _003CeventInstance_003E5__7;

			private PizzaCircle _003CtargetPizza_003E5__8;

			private CursorData _003CcursorData_003E5__9;

			private VampireSurvivors.Objects.Characters.CharacterController _003CplayerInPizza_003E5__10;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C_FB_BigFuzz_Pointer_003Ed__108(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_SabotageEMEWithCallbacks_003Ed__104 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StageEventManager _003C_003E4__this;

			public float duration;

			public object moreY;

			public Action<Vector2> onSuccess;

			public Action onFailure;

			private List<Vector2> _003CeventTargets_003E5__2;

			private float _003CdurationLeft_003E5__3;

			private int _003ClastSecond_003E5__4;

			private PhaserSprite _003CgreenOverlay_003E5__5;

			private PhaserText _003Ctext_003E5__6;

			private NewsFeed _003CnewsFeed_003E5__7;

			private Vector2 _003CtargetLocation_003E5__8;

			private EventTargetInstace _003CsabotageInstance_003E5__9;

			private PizzaCircle _003CtargetPizza_003E5__10;

			private CursorData _003CcursorData_003E5__11;

			private bool _003Csuccess_003E5__12;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C_SabotageEMEWithCallbacks_003Ed__104(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_SabotageWithCallbacks_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public object moreY;

			public int chosenEventTarget;

			public Vector2 targetLocation;

			public StageEventManager _003C_003E4__this;

			public Action<Vector2> onSuccess;

			public Action onFailure;

			private float _003CdurationLeft_003E5__2;

			private int _003ClastSecond_003E5__3;

			private PhaserSprite _003CredOverlay_003E5__4;

			private PhaserText _003Ctext_003E5__5;

			private NewsFeed _003CnewsFeed_003E5__6;

			private EventTargetInstace _003CsabotageInstance_003E5__7;

			private PizzaCircle _003CtargetPizza_003E5__8;

			private CursorData _003CcursorData_003E5__9;

			private bool _003Csuccess_003E5__10;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003C_SabotageWithCallbacks_003Ed__98(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private DestructibleFactory _destructibleFactory;

		private Stage _ourStage;

		private Camera _mainCamera;

		private ShootingStarsManager _shootingStarsManager;

		private ShootingStarsManager2 _shootingStarsManager2;

		private static int RandomEventId;

		private float _playDiamondGridStartX;

		private float _playDiamondGridStartY;

		private List<List<int>> _playDiamondGrid;

		private List<List<EnemyDiamond?>> _playDiamondEnemyGrid;

		private bool _playDiamondActive;

		private float _playDiamondDuration;

		private Timer _playDiamondDisappearTimer;

		private float _playDiamondPlayerAtGridPrevX;

		private float _playDiamondPlayerAtGridPrevY;

		private bool _stageEventsDisabled;

		private bool _isTeleportingToRemotePlayer;

		private bool _finishedTeleportingToRemotePlayer;

		private const float DontSpawnIfAbove = 500f;

		public EnemyType? _playDiamond_enemyType;

		private List<EventTargetInstace> _eventTargets;

		public int Spawned { get; set; }

		public bool IsTeleportingToRemotePlayer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool FinishedTeleportingToRemotePlayer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private Vector3 PlayerPos => default(Vector3);

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public virtual void Init(Stage stage)
		{
		}

		public void DisableStageEvents()
		{
		}

		public bool TriggerEvent(VampireSurvivors.Data.Stage.Event stageDataEvent, bool fromTrisection = false)
		{
			return false;
		}

		public void InternalUpdate()
		{
		}

		public void PlaySwarm(float duration, int moreX, EnemyType moreY, float moreZ = 0.9f)
		{
		}

		public void PlayDiamond_RandomPattern(float? duration, [Optional][DefaultParameterValue(0)] int moreX, [Optional] EnemyType? moreY, float moreZ = 0f)
		{
		}

		public void PlayDiamond_RandomPatternClear()
		{
		}

		public void PlayDiamondConcrete(float? duration, [Optional] float? moreX, [Optional] float? moreY, [Optional] EnemyType? moreZ)
		{
		}

		private void Cleanup()
		{
		}

		protected bool TriggerSwitchEvent(StageEventType eventType, float? chance, float? duration, int moreX, object moreY, float moreZ = 0f, bool fromTrisection = false)
		{
			return false;
		}

		private static EnemyType ConvertToEnemyType(object moreY, EnemyType defaultEnemyType)
		{
			return default(EnemyType);
		}

		public int GetRandomId()
		{
			return 0;
		}

		private void GenerateBoss(EnemyType enemyType = EnemyType.BATSWARM)
		{
		}

		private void GenerateEnemySwarm(float duration, int count, EnemyType enemyType = EnemyType.BATSWARM, float moreZ = 0.9f, float rndDiv = 500f)
		{
		}

		private void GenerateEnemyWall(float duration, int count = 100, EnemyType enemyType = EnemyType.FLOWER, float moreZ = 0.9f, float radiusMul = 0.8f, float rndDiv = 50f)
		{
		}

		private void GenerateEnemyCardinalSpawn(float duration, CardinalTypeEnum cardinalType = CardinalTypeEnum.Cardinal, EnemyType enemyType = EnemyType.BATSWARM, float moreZ = 0.9f, float rndDiv = 500f)
		{
		}

		private void SpawnCardinalDirections(List<float2> directions, EnemyType enemyType, float rndDiv = 500f)
		{
		}

		public void PlayCircle(float? duration, int moreX = 100, EnemyType moreY = EnemyType.FLOWER, float moreZ = 0.9f)
		{
		}

		private void PlayJellyfish(float? duration, int moreX = 80, EnemyType moreY = EnemyType.JELLYFISH)
		{
		}

		private void PlayBatSwarm(float? duration)
		{
		}

		private void PlayGhostSwarm(float? duration)
		{
		}

		public void PlayMedusaSwarm(float? duration, int moreX = 1, EnemyType enemyType = EnemyType.MEDUSA1)
		{
		}

		private void PlayVerticalSwarm(float? duration, int moreX = 1, EnemyType enemyType = EnemyType.XLSWORDIAN_V)
		{
		}

		private void PlayMedusaWall(float? duration, int moreX = 1, EnemyType enemyType = EnemyType.MEDUSA1)
		{
		}

		private void PlaySkullSwarm(float? duration, int moreX = 1, EnemyType moreY = EnemyType.SKULL2_SWARM)
		{
		}

		private void PlayPileAssault(float? duration, int moreX = 50, EnemyType enemyType = EnemyType.PILE1, float moreZ = 0.7f)
		{
		}

		private void PlayMinoRush(float? duration, int moreX = 50)
		{
		}

		private void PlayJellySwarm(float? duration, int moreX = 50)
		{
		}

		private void PlayEctoSwarm(float? duration, int moreX = 50)
		{
		}

		private void PlayGenericBoss(object moreY)
		{
		}

		private void PlayGenericSwarm(float? duration, int moreX, object moreY)
		{
		}

		private void PlayGenericCardinalSpawn(float? duration, int moreX, object moreY)
		{
		}

		private void PlayDragonStream(float? duration, int moreX = 12, EnemyType moreY = EnemyType.XLDRAGON1_FLAG, float moreZ = 4f)
		{
		}

		private void PlaySkeleStream(float? duration, int moreX = 12, EnemyType moreY = EnemyType.XLDRAGON3_FLAG, float moreZ = 4f)
		{
		}

		private void PlaySkullPilePile(float? duration, int moreX = 1, EnemyType moreY = EnemyType.PILE4_SCALED, float moreZ = 12f)
		{
		}

		private void PlayPolterRoulette(float? duration, int moreX = 50, EnemyType moreY = EnemyType.POLTER_DEST, float moreZ = 1f)
		{
		}

		private void PlayImpSwarm(float? duration, int moreX = 50)
		{
		}

		private void PlaySkeletonSwarm(float? duration, int moreX = 50, EnemyType moreY = EnemyType.BATSWARM)
		{
		}

		private void PlayShadeBomb(float? duration, int moreX = 1, EnemyType moreY = EnemyType.SHADERED)
		{
		}

		private void ShootStars(int moreX, object moreY, float moreZ)
		{
		}

		private void ShootStars2(int moreX, object moreY, float moreZ)
		{
		}

		private void SummonTimedEnemy(float? duration, int moreX, EnemyType enemyType)
		{
		}

		private void PlayStalker(float? duration, int moreX = 1)
		{
		}

		private void PlaySleeper(float? duration, int moreX = 1)
		{
		}

		private void PlayDrowner(float? duration, bool fromTrisection = false)
		{
		}

		private void PlayEraseEnemies()
		{
		}

		private void PlayCycleComplete()
		{
		}

		private void SpawnInSteps(float? duration, int moreX = 24, EnemyType moreY = EnemyType.EX_AXE_BAT3, float moreZ = 0.9f)
		{
		}

		private void PlayDiamondSquare(float? duration, [Optional][DefaultParameterValue(1)] int moreX, [Optional] EnemyType? moreY, float moreZ = 0f)
		{
		}

		private void PlayDiamondRoad(float? duration, [Optional][DefaultParameterValue(1)] int moreX, [Optional] EnemyType? moreY, float moreZ = 0f)
		{
		}

		public List<EventTargetInstace> GetCurrentEventTargets()
		{
			return null;
		}

		private void SabotagionEME(float? duration, int moreX, object moreY, float moreZ)
		{
		}

		private void Sabotagion(float? duration, int moreX, object moreY, float moreZ)
		{
		}

		private int GetTargetLocation(out Vector2 targetLocation)
		{
			targetLocation = default(Vector2);
			return 0;
		}

		private void Sabotage_PickleRush(float? duration, int moreX, object moreY, float moreZ)
		{
		}

		private int ChooseEventTargetIndex(List<Vector2> eventTargets)
		{
			return 0;
		}

		public void StartSabotagion(float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeed, bool isPickleRush)
		{
		}

		[IteratorStateMachine(typeof(_003C_SabotageWithCallbacks_003Ed__98))]
		private IEnumerator _SabotageWithCallbacks(float duration, int chosenEventTarget, Vector2 targetLocation, int moreX, object moreY, float moreZ, Action<Vector2> onSuccess, Action onFailure)
		{
			return null;
		}

		private void OnSabotagionSuccess(Vector2 targetLocation)
		{
		}

		private void OnSabotagionFailure()
		{
		}

		private void SpawnLava()
		{
		}

		private void OnSabotage_PickleRushFailure()
		{
		}

		private int ChooseEMEEventTargetIndex(List<Vector2> eventTargets)
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003C_SabotageEMEWithCallbacks_003Ed__104))]
		private IEnumerator _SabotageEMEWithCallbacks(float duration, int moreX, object moreY, float moreZ, Action<Vector2> onSuccess, Action onFailure)
		{
			return null;
		}

		private void OnSabotagionEMESuccess(Vector2 targetLocation)
		{
		}

		private void OnSabotagionEMEFailure()
		{
		}

		private void FB_BigFuzz_Pointer(float? duration, int moreX, object moreY, float moreZ)
		{
		}

		[IteratorStateMachine(typeof(_003C_FB_BigFuzz_Pointer_003Ed__108))]
		private IEnumerator _FB_BigFuzz_Pointer(float duration, int moreX, object moreY, float moreZ, Action<Vector2> onSuccess, Action onFailure)
		{
			return null;
		}

		private void SpawnCircleWave(EnemyType enemyType, int eventID, int durationMillis = -1)
		{
		}

		private static void InitEventEnemy(int eventID, EnemyController enemy, List<EnemyController> enemies)
		{
		}

		private void FB_Capsule_Event()
		{
		}

		private void fnRosary()
		{
		}

		public void fnPet()
		{
		}

		public void fnPetPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void fnChicken()
		{
		}

		private void fnGoldFever()
		{
		}

		private void fnPassive()
		{
		}

		private void fnLights()
		{
		}

		private void fnNduja()
		{
		}

		private void fnClover()
		{
		}

		private void fnSkull()
		{
		}

		private void fnUltraWave()
		{
		}

		private void fnSummonMolise()
		{
		}

		private void fnSummonNight()
		{
		}

		private void fnMinuteOfPanic()
		{
		}

		private void fnCandybox()
		{
		}

		private void fnHighGravity(float? duration)
		{
		}

		private void fnCrabFest()
		{
		}

		private void fnRemoveWalls()
		{
		}

		private void fnInvaders(float? duration, int moreX, object moreY, float moreZ)
		{
		}

		private void DebugAddConsoleCommands()
		{
		}
	}
}
