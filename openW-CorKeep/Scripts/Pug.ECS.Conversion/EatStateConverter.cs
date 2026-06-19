using Pug.Conversion;

public class EatStateConverter : SingleAuthoringComponentConverter<EatStateAuthoring>
{
	protected override void Convert(EatStateAuthoring authoring)
	{
		AddComponentData(new EatStateCD
		{
			duration = authoring.duration,
			eatPostDuration = authoring.eatPostDuration,
			sqDistanceToEat = authoring.distanceToEat * authoring.distanceToEat,
			maxFoodUntilFull = authoring.maxFoodUntilFull
		});
	}
}
