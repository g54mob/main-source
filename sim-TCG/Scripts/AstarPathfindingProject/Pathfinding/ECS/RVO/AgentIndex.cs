namespace Pathfinding.ECS.RVO
{
	public readonly struct AgentIndex
	{
		internal const int DeletedBit = int.MinValue;

		internal const int IndexMask = 16777215;

		internal const int VersionOffset = 24;

		internal const int VersionMask = 2130706432;

		public readonly int packedAgentIndex;

		public int Index => packedAgentIndex & 0xFFFFFF;

		public int Version => packedAgentIndex & 0x7F000000;

		public bool Valid => (packedAgentIndex & int.MinValue) == 0;

		public AgentIndex(int packedAgentIndex)
		{
			this.packedAgentIndex = packedAgentIndex;
		}

		public AgentIndex(int version, int index)
		{
			version <<= 24;
			packedAgentIndex = (version & 0x7F000000) | (index & 0xFFFFFF);
		}

		public AgentIndex WithIncrementedVersion()
		{
			return new AgentIndex((((packedAgentIndex & 0x7F000000) + 16777216) & 0x7F000000) | Index);
		}

		public AgentIndex WithDeleted()
		{
			return new AgentIndex(packedAgentIndex | int.MinValue);
		}
	}
}
