using Gh.Tk.Story;

namespace Gh.Tk
{
	public class SimpleAdvisorCameraEvent : CameraEvent
	{
		private int _storyId;

		public static void TryFire(string adviceKey, string voTextKey = null, AdvisorState state = AdvisorState.Neutral, ActiveStory story = null, string eventId = null)
		{
		}

		protected SimpleAdvisorCameraEvent()
		{
		}

		public SimpleAdvisorCameraEvent(float displaySeconds, int storyId = -1, bool useUnscaledTime = true)
		{
		}

		public ActiveStory GetStory()
		{
			return null;
		}

		public override void EventCameraCallback(EventCamera eventCamera)
		{
		}
	}
}
