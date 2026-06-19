namespace TH20
{
	public class JobResearch : JobRoom
	{
		public JobResearch(StaffRequired staffRequired, Room room)
			: base(staffRequired, room)
		{
		}

		public override bool IsReadyForWork()
		{
			bool projectAssigned = false;
			RoomAlgorithms.IterateRoomItemsWithComponent(_room, delegate(ResearchProjectComponent component)
			{
				if (component.Project != null)
				{
					projectAssigned = true;
				}
			});
			return projectAssigned;
		}

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateResearchJobScore(_room, staff, this);
		}
	}
}
