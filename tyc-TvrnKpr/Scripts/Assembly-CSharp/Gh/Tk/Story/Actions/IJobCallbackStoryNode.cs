namespace Gh.Tk.Story.Actions
{
	public interface IJobCallbackStoryNode
	{
		void OnJobCompleted(ActiveStory story, Job sourceJob);

		void OnJobFailed(ActiveStory story, Job sourceJob);
	}
}
