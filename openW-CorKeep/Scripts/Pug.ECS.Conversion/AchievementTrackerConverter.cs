using Pug.Conversion;

public class AchievementTrackerConverter : SingleAuthoringComponentConverter<AchievementTrackerAuthoring>
{
	protected override void Convert(AchievementTrackerAuthoring authoring)
	{
		EnsureHasComponent<AchievementTrackerCD>();
	}
}
