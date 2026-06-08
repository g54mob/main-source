using Unity.Entities;

namespace Kitchen
{
	public struct CGroupReward : IComponentData
	{
		public int Amount;

		public static implicit operator CGroupReward(int t)
		{
			return new CGroupReward
			{
				Amount = t
			};
		}

		public static implicit operator int(CGroupReward h)
		{
			return h.Amount;
		}

		public static CGroupReward operator +(CGroupReward a, int b)
		{
			return (int)a + b;
		}
	}
}
