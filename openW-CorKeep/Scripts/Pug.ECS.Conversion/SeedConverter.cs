using Pug.Conversion;

public class SeedConverter : SingleAuthoringComponentConverter<SeedAuthoring>
{
	protected override void Convert(SeedAuthoring authoring)
	{
		SetProperty("isSeed");
		SetProperty("Seed/turnsIntoPlantID", authoring.turnsIntoPlantID);
		SetProperty("Seed/rarePlantVariation", authoring.rarePlantVariation);
		SetProperty("Seed/rareSeedVariation", authoring.rareSeedVariation);
		SetProperty("Growing/highestStage", authoring.growingSettings.highestStage);
		SetProperty("Growing/timeBetweenStages", authoring.growingSettings.timeBetweenStages);
		SetProperty("Growing/keepDamageReductionWhenRipe", authoring.growingSettings.keepDamageReductionWhenRipe);
		AddComponentData(new GrowingCD
		{
			currentStage = authoring.growingSettings.currentStage
		});
	}
}
