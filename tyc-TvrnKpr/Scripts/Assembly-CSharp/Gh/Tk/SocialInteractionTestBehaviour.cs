namespace Gh.Tk
{
	public class SocialInteractionTestBehaviour : SocialMeetingBehaviour
	{
		protected SocialInteractionTestBehaviour()
		{
		}

		public SocialInteractionTestBehaviour(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
