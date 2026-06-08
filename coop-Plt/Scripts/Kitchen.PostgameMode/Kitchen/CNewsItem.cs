using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CNewsItem : IComponentData
	{
		public NewsItemType Type;

		public int Reward;

		public LossReason LossReason;
	}
}
