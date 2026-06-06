public readonly struct AchievementContext
{
	public readonly AchievementData Data;

	public readonly AchievementDetails Details;

	public readonly DatabaseState State;

	public readonly DatabaseCommands Commands;

	public readonly DatabaseCommands.AchievementCommands Achievements;

	public AchievementContext(AchievementData data, AchievementDetails details, DatabaseState state, DatabaseCommands commands, DatabaseCommands.AchievementCommands achievements)
	{
		Data = data;
		Details = details;
		State = state;
		Commands = commands;
		Achievements = achievements;
	}
}
