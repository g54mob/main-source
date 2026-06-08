using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockConditionRegular : IUnlockCondition
	{
		public int DayInterval = 3;

		public int DayOffset;

		public int DayMin = -1;

		public int DayMax = -1;

		public int TierRequired = -1;

		public bool ShouldProvide(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			if (request.Day > DayMax && DayMax > 0)
			{
				return false;
			}
			if (request.Day < DayMin && DayMin > 0)
			{
				return false;
			}
			if ((request.Day - DayOffset) % DayInterval != 0)
			{
				return false;
			}
			if (request.Tier != TierRequired && TierRequired > 0)
			{
				return false;
			}
			return true;
		}
	}
}
