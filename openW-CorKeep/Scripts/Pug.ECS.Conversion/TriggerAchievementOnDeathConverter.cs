using Pug.Conversion;

public class TriggerAchievementOnDeathConverter : SingleAuthoringComponentConverter<TriggerAchievementOnDeathAuthoring>
{
	protected override void Convert(TriggerAchievementOnDeathAuthoring authoring)
	{
		AddComponentData(new TriggerAchievementOnDeathCD
		{
			achievement = authoring.achievement
		});
	}
}
