using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class AchievementStateDto
{
	[Key(0)]
	public Dictionary<Achievement, AchievementDetailsStateDto> AchievementDetails;
}
