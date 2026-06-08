using Unity.Entities;

namespace Kitchen
{
	public struct SGameLossReason : IComponentData
	{
		public LossReason Reason;
	}
}
