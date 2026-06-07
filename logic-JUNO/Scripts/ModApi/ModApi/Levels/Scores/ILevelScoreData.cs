using System.Collections.Generic;

namespace ModApi.Levels.Scores
{
	public interface ILevelScoreData
	{
		ILevelScoreComparer Comparer { get; }

		ILevelScoreFormatter Formatter { get; }

		ILevelData LevelData { get; }

		IReadOnlyList<LevelScore> Scores { get; }

		bool ShowTopScores { get; }
	}
}
