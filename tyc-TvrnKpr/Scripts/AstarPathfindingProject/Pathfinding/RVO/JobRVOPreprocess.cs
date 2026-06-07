using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = false, FloatMode = FloatMode.Fast)]
	public struct JobRVOPreprocess<MovementPlaneWrapper> : IJob where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public SimulatorBurst.AgentOutputData previousOutput;

		[WriteOnly]
		public SimulatorBurst.TemporaryAgentData temporaryAgentData;

		public int startIndex;

		public int endIndex;

		public void Execute()
		{
		}
	}
}
