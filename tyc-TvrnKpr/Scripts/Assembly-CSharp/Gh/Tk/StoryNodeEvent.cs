using Gh.Tk.Story;

namespace Gh.Tk
{
	public abstract class StoryNodeEvent : GameEvent
	{
		protected int _sourceStoryId;

		protected bool _suppressStoryNullErrors;

		protected StoryNodeEvent()
		{
		}

		public StoryNodeEvent(ActiveStory sourceStory)
		{
		}

		public ActiveStory GetSourceStory()
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}
	}
}
