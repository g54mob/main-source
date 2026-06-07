namespace Gh.Tk
{
	public class SocialMeetingBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		[PersistenceOptIn]
		private bool _done;

		protected SocialMeetingBehaviour()
		{
		}

		public SocialMeetingBehaviour(Patron owner)
		{
		}

		public SocialMeetingBehaviour(Patron owner, string name, int priority)
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

		public override string GetBehaviourFilterString()
		{
			return null;
		}
	}
}
