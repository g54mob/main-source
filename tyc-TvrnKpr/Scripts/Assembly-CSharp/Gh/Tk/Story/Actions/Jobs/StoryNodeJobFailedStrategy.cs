namespace Gh.Tk.Story.Actions.Jobs
{
	public enum StoryNodeJobFailedStrategy : sbyte
	{
		RetryThenContinue = 0,
		ContinueNormal = 1,
		ContinueWithFailedOutput = 2,
		StopStoryExecution = 3
	}
}
