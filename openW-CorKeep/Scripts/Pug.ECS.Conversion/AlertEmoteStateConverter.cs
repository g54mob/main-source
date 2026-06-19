using Pug.Conversion;

public class AlertEmoteStateConverter : SingleAuthoringComponentConverter<AlertEmoteStateAuthoring>
{
	protected override void Convert(AlertEmoteStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		AddComponentData(new AlertEmoteStateCD
		{
			animations = authoring.animations,
			preAlertMinDuration = authoring.preAlertMinDuration,
			preAlertMaxDuration = authoring.preAlertMaxDuration,
			duration = authoring.duration,
			minCooldown = authoring.minCooldown,
			maxCooldown = authoring.maxCooldown
		});
	}
}
