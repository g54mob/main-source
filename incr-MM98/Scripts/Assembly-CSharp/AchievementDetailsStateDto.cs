using MessagePack;

[MessagePackObject(false)]
public class AchievementDetailsStateDto
{
	[Key(0)]
	public bool Unlocked;

	[Key(1)]
	public double Progress;
}
