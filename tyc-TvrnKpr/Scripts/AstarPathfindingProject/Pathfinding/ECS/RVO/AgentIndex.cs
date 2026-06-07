using Pathfinding.RVO;
using Unity.Collections;
using Unity.Entities;

namespace Pathfinding.ECS.RVO
{
	[WriteGroup(typeof(ResolvedMovement))]
	public readonly struct AgentIndex : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		private const int DeletedBit = -2147483648;

		private const int IndexMask = 16777215;

		private const int VersionOffset = 24;

		private const int VersionMask = 2130706432;

		private readonly int packedAgentIndex;

		internal int Index => 0;

		private int Version => 0;

		internal bool Valid => false;

		internal AgentIndex(int packedAgentIndex)
		{
			this.packedAgentIndex = 0;
		}

		internal AgentIndex(int version, int index)
		{
			packedAgentIndex = 0;
		}

		internal AgentIndex WithIncrementedVersion()
		{
			return default(AgentIndex);
		}

		internal AgentIndex WithDeleted()
		{
			return default(AgentIndex);
		}

		public bool Exists(ref SimulatorBurst.AgentData agentData)
		{
			return false;
		}

		public bool TryGetIndex(ref SimulatorBurst.AgentData agentData, out int index)
		{
			index = default(int);
			return false;
		}

		public bool TryGetIndex(ref NativeArray<AgentIndex> agentDataVersions, out int index)
		{
			index = default(int);
			return false;
		}
	}
}
