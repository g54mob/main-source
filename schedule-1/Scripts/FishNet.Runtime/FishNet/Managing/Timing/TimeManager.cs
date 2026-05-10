using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Managing.Timing
{
	[DisallowMultipleComponent]
	[AddComponentMenu("FishNet/Manager/TimeManager")]
	public sealed class TimeManager : MonoBehaviour
	{
		private enum TimingType
		{
			Tick = 0,
			Variable = 1
		}

		private enum UpdateOrder : byte
		{
			BeforeTick = 0,
			AfterTick = 1
		}

		private enum TimingUpdateChange
		{
			JustRight = 0,
			TooFast = 1,
			TooSlow = -1
		}

		internal uint LastOrderedPacketTick;

		[Tooltip("When to invoke OnUpdate and other Unity callbacks relayed by the TimeManager.")]
		[SerializeField]
		private UpdateOrder _updateOrder;

		[SerializeField]
		[Tooltip("Timing for sending and receiving data.")]
		private TimingType _timingType;

		[SerializeField]
		[Tooltip("While true clients may drop local ticks if their devices are unable to maintain the tick rate. This could result in a temporary desynchronization but will prevent the client falling further behind on ticks by repeatedly running the logic cycle multiple times per frame.")]
		private bool _allowTickDropping;

		[SerializeField]
		[Tooltip("Maximum number of ticks which may occur in a single frame before remainder are dropped for the frame.")]
		[Range(1f, 25f)]
		private byte _maximumFrameTicks;

		[SerializeField]
		[Tooltip("How many times per second the server will simulate. This does not limit server frame rate.")]
		[Range(1f, 240f)]
		private ushort _tickRate;

		[Range(1f, 15f)]
		[SerializeField]
		[Tooltip("How often in seconds to a connections ping. This is also responsible for approximating server tick. This value does not affect prediction.")]
		private byte _pingInterval;

		[Tooltip("How to perform physics.")]
		[SerializeField]
		private PhysicsMode _physicsMode;

		private uint _clientTicks;

		private uint _lastUpdateTicks;

		private uint _localTick;

		private Stopwatch _pingStopwatch;

		private uint _pingTicks;

		private MovingAverage _pingAverage;

		private double _elapsedTickTime;

		private NetworkManager _networkManager;

		private double _adjustedTickDelta;

		private double[] _clientTimingRange;

		private int _lastIncomingIterationFrame;

		private bool _receivedPong;

		private float _lastMultipleTicksTime;

		private static uint _manualPhysics;

		private float _timingTooFastCount;

		private bool _fixedUpdateTimeStep;

		internal const float TIMING_INTERVAL = 1f;

		public const uint UNSET_TICK = 0u;

		private const float CLIENT_TIMING_PERCENT_RANGE = 0.5f;

		private const double CLIENT_SPEEDUP_VALUE = 0.035;

		private const double CLIENT_SLOWDOWN_VALUE = 0.02;

		private const string SAVED_FIXED_TIME_TEXT = "SavedFixedTimeFN";

		private TimingUpdateChange _timingUpdateChange;

		private float _updateChangeMultiplier;

		public long RoundTripTime { get; private set; }

		internal bool LowFrameRate => false;

		public uint LastPacketTick { get; private set; }

		public uint Tick { get; internal set; }

		[HideInInspector]
		public double TickDelta { get; private set; }

		public bool FrameTicked { get; private set; }

		public float ServerUptime { get; private set; }

		public float ClientUptime { get; private set; }

		public ushort TickRate
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public byte PingInterval => 0;

		public PhysicsMode PhysicsMode => default(PhysicsMode);

		public uint LocalTick
		{
			get
			{
				return 0u;
			}
			private set
			{
			}
		}

		internal byte RESET_ADJUSTMENT_THRESHOLD => 0;

		public event Action<long> OnRoundTripTimeUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnPreTick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnTick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> OnPrePhysicsSimulation
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> OnPostPhysicsSimulation
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnPostTick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnLateUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnFixedUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal void SetLastPacketTick(uint tick)
		{
		}

		internal void TickFixedUpdate()
		{
		}

		internal void TickUpdate()
		{
		}

		internal void TickLateUpdate()
		{
		}

		internal void InitializeOnce_Internal(NetworkManager networkManager)
		{
		}

		private void AddNetworkLoops()
		{
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
		{
		}

		private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
		{
		}

		private void SetInitialValues()
		{
		}

		private void UnsetSimulationSettings()
		{
		}

		private void SetAutomaticPhysicsSimulation(bool automatic)
		{
		}

		private void InitializePhysicsMode(PhysicsMode mode)
		{
		}

		public void SetPhysicsMode(PhysicsMode mode)
		{
		}

		internal void ModifyPing(uint clientTick)
		{
		}

		private void TrySendPing(uint? tickOverride = null)
		{
		}

		internal void SendPong(NetworkConnection conn, uint clientTick)
		{
		}

		private void IncreaseTick()
		{
		}

		public double GetTickPercent()
		{
			return 0.0;
		}

		public PreciseTick GetPreciseTick(uint tick)
		{
			return default(PreciseTick);
		}

		public PreciseTick GetPreciseTick(TickType tickType)
		{
			return default(PreciseTick);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double TicksToTime(TickType tickType = TickType.LocalTick)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double TicksToTime(PreciseTick pt)
		{
			return 0.0;
		}

		public double TicksToTime(uint ticks)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double TimePassed(uint currentTick, uint previousTick)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double TimePassed(PreciseTick preciseTick, bool allowNegative = false)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double TimePassed(uint previousTick, bool allowNegative = false)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint TimeToTicks(double time, TickRounding rounding = TickRounding.RoundNearest)
		{
			return 0u;
		}

		public uint TickToLocalTick(uint tick)
		{
			return 0u;
		}

		public uint LocalTickToTick(uint localTick)
		{
			return 0u;
		}

		private void TryIterateData(bool incoming)
		{
		}

		private void SendTimingAdjustment()
		{
		}

		internal void ParseTimingUpdate(PooledReader reader)
		{
		}

		public void SetTickRate(ushort value)
		{
		}

		private void OnValidate()
		{
		}
	}
}
