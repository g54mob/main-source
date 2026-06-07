using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = false, FloatMode = FloatMode.Fast)]
	public struct JobDestinationReached<MovementPlaneWrapper> : IJob where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		private struct TempAgentData
		{
			public bool blockedAndSlow;

			public float distToEndSq;
		}

		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public SimulatorBurst.TemporaryAgentData temporaryAgentData;

		public SimulatorBurst.AgentOutputData output;

		public int numAgents;

		private static readonly ProfilerMarker MarkerInvert;

		private static readonly ProfilerMarker MarkerAlloc;

		private static readonly ProfilerMarker MarkerFirstPass;

		public void Execute()
		{
		}
	}
}
