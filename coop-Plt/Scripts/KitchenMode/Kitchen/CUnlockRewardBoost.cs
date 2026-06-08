using Unity.Entities;

namespace Kitchen
{
	public struct CUnlockRewardBoost : IComponentData
	{
		public int ItemID;

		public int Amount;
	}
}
