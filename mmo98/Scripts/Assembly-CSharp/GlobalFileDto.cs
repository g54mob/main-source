using MessagePack;

[MessagePackObject(false)]
public class GlobalFileDto
{
	[Key(0)]
	public AchievementStateDto Achievements;
}
