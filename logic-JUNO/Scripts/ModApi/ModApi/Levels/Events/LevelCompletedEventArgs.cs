using ModApi.Levels.Scores;

namespace ModApi.Levels.Events
{
	public class LevelCompletedEventArgs : LevelEventArgs
	{
		public LevelScore Score { get; }

		public LevelCompletedEventArgs(ILevel level, LevelScore score)
			: base(level)
		{
			Score = score;
		}
	}
}
