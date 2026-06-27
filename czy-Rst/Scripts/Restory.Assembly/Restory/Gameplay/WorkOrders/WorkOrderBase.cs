using System;
using Restory.Data.NPCs;
using Restory.Data.SaveLoad.Containers;

namespace Restory.Gameplay.WorkOrders
{
	[Serializable]
	public abstract class WorkOrderBase
	{
		public bool SkipVisit;

		public TimeSpan SkipDelayBeforeVisit;

		public DateTime AssignedDateTime;

		public bool RewardHasBeenGiven;

		public bool DeviceHasBeenGiven;

		public DeviceData SavedGivenDeviceData;

		public int SavedGivenRewardMoneyAmount;

		public INpcInfo NpcOriginalCustomer;

		public INpcInfo NpcToClaimCompletedOrder;

		public string OrderClaimingNpcTextureID;

		public string RewardID;

		public abstract bool IsOrderClaimingVisitAlreadyScheduled { get; }
	}
}
