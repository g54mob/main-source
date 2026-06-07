using System;
using Coherence.SimulationFrame;

namespace Coherence
{
	public interface INetworkTime
	{
		double TimeAsDouble { get; }

		float SessionTime { get; }

		double SessionTimeAsDouble { get; }

		float NetworkTimeScale { get; }

		double NetworkTimeScaleAsDouble { get; }

		double TargetTimeScale { get; }

		double FixedTimeStep { get; set; }

		double MaximumDeltaTime { get; set; }

		bool MultiClientMode { get; set; }

		bool AccountForPing { get; set; }

		bool SmoothTimeScaleChange { get; set; }

		bool Pause { get; set; }

		bool IsTimeSynced { get; }

		AbsoluteSimulationFrame ClientSimulationFrame { get; }

		AbsoluteSimulationFrame ClientFixedSimulationFrame { get; }

		AbsoluteSimulationFrame ServerSimulationFrame { get; }

		AbsoluteSimulationFrame ConnectionSimulationFrame { get; }

		event Action OnTimeReset;

		event Action OnFixedNetworkUpdate;

		event Action OnLateFixedNetworkUpdate;

		event Action<AbsoluteSimulationFrame, AbsoluteSimulationFrame> OnServerSimulationFrameReceived;

		void Step(double currentTime, bool stopApplyingServerSimFrame);

		void Reset(AbsoluteSimulationFrame newClientAndServerFrame = default(AbsoluteSimulationFrame), bool notify = true);
	}
}
