using Pug.Conversion;

public class PlantConverter : SingleAuthoringComponentConverter<PlantAuthoring>
{
	protected override void Convert(PlantAuthoring authoring)
	{
		AddComponentData(new PlantCD
		{
			numberOfPlantsToDrop = 1,
			objectToDropWhenHarvested = authoring.objectToDropWhenHarvested
		});
		SetProperty("Growing/highestStage", authoring.growingSettings.highestStage);
		SetProperty("Growing/timeBetweenStages", authoring.growingSettings.timeBetweenStages);
		SetProperty("Growing/keepDamageReductionWhenRipe", authoring.growingSettings.keepDamageReductionWhenRipe);
		AddComponentData(new GrowingCD
		{
			currentStage = authoring.growingSettings.currentStage
		});
	}
}
