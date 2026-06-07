public interface ILegacyUserProfile : IJsonSerializableSaveData, IStorable
{
	Player Player { get; set; }

	bool IsVibrationEnabled { get; set; }

	bool IsAchievementCompleted(AchievementDefinition achievementDefinition);

	void CompleteAchievement(AchievementDefinition achievementDefinition, bool showNotification);

	void RecordGameStatistics(IGameStatistics gameStatistics);
}
