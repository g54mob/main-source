namespace UltimateReplay.Core
{
	public interface IReplayPreparer
	{
		void PrepareForPlayback(ReplayObject replayObject);

		void PrepareForGameplay(ReplayObject replayObject);
	}
}
