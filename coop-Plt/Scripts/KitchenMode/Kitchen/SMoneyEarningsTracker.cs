using Unity.Entities;

namespace Kitchen
{
	public struct SMoneyEarningsTracker : IComponentData
	{
		public int OldAmount;
	}
}
