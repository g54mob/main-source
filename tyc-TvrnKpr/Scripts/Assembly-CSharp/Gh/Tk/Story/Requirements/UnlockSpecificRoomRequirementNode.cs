namespace Gh.Tk.Story.Requirements
{
	public class UnlockSpecificRoomRequirementNode : RoomUnlockRequirementBaseNode
	{
		public int roomId;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
