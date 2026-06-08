using Unity.Entities;

namespace Kitchen
{
	public struct SGameOver : IComponentData
	{
		public LossReason Reason;
	}
}
