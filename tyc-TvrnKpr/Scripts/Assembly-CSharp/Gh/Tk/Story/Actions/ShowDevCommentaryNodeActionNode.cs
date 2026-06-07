namespace Gh.Tk.Story.Actions
{
	public class ShowDevCommentaryNodeActionNode : ConnectedStoryNode
	{
		public string commentaryId;

		public bool setVisible;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private DevCommentaryMarkerMonoBehaviour FindMarker()
		{
			return null;
		}
	}
}
