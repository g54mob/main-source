namespace Gh.Tk.Story.Actions
{
	public class StopMusicActionNode : AudioActionBaseNode
	{
		public enum MusicFadeType
		{
			Instant = 0,
			QuickFade = 1,
			SlowFade = 2
		}

		public MusicFadeType fadeout;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
