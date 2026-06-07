namespace Gh.Tk.Story.Actions
{
	public class SetTavernOnFireActionNode : ConnectedStoryNode
	{
		public FireEventDifficulty difficulty;

		public override void OnUpdate(ActiveStory story)
		{
		}

		private bool TrySetFires()
		{
			return false;
		}

		private int GetTargetNumberOfObjectsToSetOnFire()
		{
			return 0;
		}
	}
}
