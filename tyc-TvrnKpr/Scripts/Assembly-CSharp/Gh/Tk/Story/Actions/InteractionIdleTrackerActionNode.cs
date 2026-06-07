using UnityEngine.Scripting;

namespace Gh.Tk.Story.Actions
{
	[InitializeOnGameStarted]
	public class InteractionIdleTrackerActionNode : ConnectedStoryNode
	{
		public float maxIdleMinutes;

		private const float PIXEL_THRESHOLD = 4f;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private void ResetIdleTime(ActiveStory activeStory)
		{
		}
	}
}
