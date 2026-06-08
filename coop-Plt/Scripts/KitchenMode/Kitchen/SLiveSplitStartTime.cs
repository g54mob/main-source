using Unity.Entities;

namespace Kitchen
{
	public struct SLiveSplitStartTime : IComponentData
	{
		public long StartTime;

		public long FinishTime;
	}
}
