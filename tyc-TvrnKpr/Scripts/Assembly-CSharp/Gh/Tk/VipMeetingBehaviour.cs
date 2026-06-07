namespace Gh.Tk
{
	public class VipMeetingBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		protected VipMeetingBehaviour()
		{
		}

		public VipMeetingBehaviour(Patron owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
