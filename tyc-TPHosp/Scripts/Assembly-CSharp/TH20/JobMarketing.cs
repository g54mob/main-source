namespace TH20
{
	public class JobMarketing : JobRoom
	{
		public JobMarketing(StaffRequired staffRequired, Room room)
			: base(staffRequired, room)
		{
		}

		public override bool IsReadyForWork()
		{
			bool campaignActive = false;
			RoomAlgorithms.IterateRoomItemsWithComponent(_room, delegate(MarketingCampaignComponent component)
			{
				if (component.ActiveCampaign != null)
				{
					campaignActive = true;
				}
			});
			return campaignActive;
		}

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateMarketingJobScore(_room, staff, this);
		}
	}
}
