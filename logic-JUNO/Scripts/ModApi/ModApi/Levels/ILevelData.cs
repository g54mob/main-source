using ModApi.Levels.Scores;

namespace ModApi.Levels
{
	public interface ILevelData
	{
		string Category { get; }

		string ContractId { get; }

		string Description { get; }

		string DisplayName { get; }

		string FlightStateId { get; }

		string Icon { get; }

		string Id { get; }

		string LaunchCraftId { get; }

		LevelType LevelType { get; }

		ILevelScoreData ScoreData { get; }

		string Script { get; }

		string TutorialId { get; }
	}
}
