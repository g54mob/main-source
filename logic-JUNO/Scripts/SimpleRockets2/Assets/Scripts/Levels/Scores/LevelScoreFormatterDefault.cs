using ModApi.Levels.Scores;

namespace Assets.Scripts.Levels.Scores
{
	public class LevelScoreFormatterDefault : ILevelScoreFormatter
	{
		public string Format { get; }

		public LevelScoreFormatterDefault()
		{
		}

		public LevelScoreFormatterDefault(string format)
		{
			Format = format;
		}

		public string FormatScore(LevelScore score)
		{
			if (Format != null)
			{
				return string.Format(Format, score.Score);
			}
			return score.Score.ToString();
		}
	}
}
