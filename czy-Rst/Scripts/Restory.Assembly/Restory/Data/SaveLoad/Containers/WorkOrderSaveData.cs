using System;
using Restory.Data.NPCs;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class WorkOrderSaveData
	{
		public int OrderID;

		public bool SkipVisit;

		public TimeSpan SkipDelayBeforeVisit;

		public DateTime AssignedDateTime;

		public bool RewardHasBeenGiven;

		public bool DeviceHasBeenGiven;

		public DeviceData SavedGivenDeviceData;

		public int SavedGivenRewardMoneyAmount;

		public StoryNpcInfo NpcOriginalCustomer;

		public StoryNpcInfo NpcToClaimCompletedOrder;

		public string ClaimingNpcTextureID;

		public string RewardID;
	}
}
