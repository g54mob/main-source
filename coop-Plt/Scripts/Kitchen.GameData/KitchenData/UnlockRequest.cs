using System;

namespace KitchenData
{
	[Serializable]
	public struct UnlockRequest
	{
		public readonly int Day;

		public readonly int Tier;

		public UnlockRequest(int day, int tier)
		{
			Day = day;
			Tier = tier;
		}
	}
}
