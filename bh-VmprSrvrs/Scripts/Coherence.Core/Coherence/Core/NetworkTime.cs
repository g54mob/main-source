using System;
using System.Runtime.CompilerServices;
using Coherence.Common;
using Coherence.Log;
using Coherence.SimulationFrame;

namespace Coherence.Core
{
	public class NetworkTime : INetworkTime
	{
		private double accumulatedTime;

		private double accumulatedSyncTime;

		private double previousTime;

		private double timeScaleVelocity;

		private bool stopApplyingServerSimFrame;

		private AbsoluteSimulationFrame lastReceivedServerSimulationFrame;

		private Ping lastReceivedPing;

		private const double timeDilationFactor = 1.0;

		public const double maxTimeScale = 1.5;

		public const double minTimeScale = 0.5;

		public const double timeStep = 1.0 / 60.0;

		public const double timeStepMs = 16.666666666666668;

		public const double floatingPointTolerance = 1E-06;

		public const int maxFrameDiffForHoldingTimeScale = 3;

		public const long simulationFrameResetTreshold = 256L;

		private readonly Logger logger;

		public double TimeAsDouble => 0.0;

		public float SessionTime => 0f;

		public double SessionTimeAsDouble => 0.0;

		public float NetworkTimeScale => 0f;

		public double NetworkTimeScaleAsDouble { get; private set; }

		public double TargetTimeScale { get; private set; }

		public double FixedTimeStep { get; set; }

		public double MaximumDeltaTime { get; set; }

		public bool MultiClientMode { get; set; }

		public bool AccountForPing { get; set; }

		public bool SmoothTimeScaleChange { get; set; }

		public bool Pause { get; set; }

		public bool IsTimeSynced { get; private set; }

		public AbsoluteSimulationFrame ClientSimulationFrame { get; private set; }

		public AbsoluteSimulationFrame ClientFixedSimulationFrame { get; private set; }

		public AbsoluteSimulationFrame ServerSimulationFrame { get; private set; }

		public AbsoluteSimulationFrame ConnectionSimulationFrame { get; private set; }

		public event Action OnTimeReset
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

		public event Action OnFixedNetworkUpdate
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

		public event Action OnLateFixedNetworkUpdate
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

		public event Action<AbsoluteSimulationFrame, AbsoluteSimulationFrame> OnServerSimulationFrameReceived
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

		public NetworkTime(Logger logger = null)
		{
		}

		public void Step(double currentTime, bool stopApplyingServerSimFrame)
		{
		}

		private void ApplyServerSimulationFrame(AbsoluteSimulationFrame frame, Ping ping)
		{
		}

		public void SetServerSimulationFrame(AbsoluteSimulationFrame frame, Ping ping)
		{
		}

		public void Reset(AbsoluteSimulationFrame newClientAndServerFrame = default(AbsoluteSimulationFrame), bool notify = true)
		{
		}

		private bool IsOutOfSync()
		{
			return false;
		}

		private void CalculateTargetTimeScale(Ping ping)
		{
		}

		internal void UpdateTimeScale(double deltaTime)
		{
		}

		private static double SmoothDamp(double from, double to, ref double vel, double smoothTime, double maxSpeed, double dt)
		{
			return 0.0;
		}
	}
}
