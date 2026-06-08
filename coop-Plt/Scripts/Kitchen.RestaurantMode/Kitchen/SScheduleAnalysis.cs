using Unity.Entities;

namespace Kitchen
{
	public struct SScheduleAnalysis : IComponentData
	{
		public int MinGroupSize;

		public int MaxGroupSize;

		public int TotalGroups;

		public int TotalExtraGroups;
	}
}
