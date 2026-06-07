using ModApi.Levels.Scores;
using ModApi.Math;

namespace Assets.Scripts.Levels.Scores
{
	public class LevelScoreFormatterStopwatch : ILevelScoreFormatter
	{
		public string FormatScore(LevelScore score)
		{
			return Units.GetStopwatchTimeString(score.Score);
		}
	}
}
