using Pug.Conversion;

public class DeathStateConverter : SingleAuthoringComponentConverter<DeathStateAuthoring>
{
	protected override void Convert(DeathStateAuthoring authoring)
	{
		if (authoring.overrideTimeBeforeDestroy)
		{
			AddComponentData(new OverrideTimeBeforeDestroy
			{
				timeBeforeDestroy = authoring.timeBeforeDestroy
			});
		}
		if (authoring.timeBeforeLootDrop > 0f)
		{
			AddComponentData(new DropLootDelayCD
			{
				Value = authoring.timeBeforeLootDrop
			});
		}
		if (!authoring.skipDeathAnimation)
		{
			EnsureHasComponent<TriggerAnimationOnDeathCD>();
		}
	}
}
