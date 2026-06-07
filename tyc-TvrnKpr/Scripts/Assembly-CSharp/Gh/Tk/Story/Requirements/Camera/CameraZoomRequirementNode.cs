namespace Gh.Tk.Story.Requirements.Camera
{
	public class CameraZoomRequirementNode : TimedRequirementNodeBase
	{
		protected string ZoomPercentageKey => null;

		protected override bool IsRequirementMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
