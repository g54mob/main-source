using Gh.Tk.Story;

namespace Gh.Tk
{
	internal interface IStoryGiverHandler
	{
		void PresentStory(ActiveStory story);

		void OnStoryGiverTimedOut(ActiveStory story);
	}
}
