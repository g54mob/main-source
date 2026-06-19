using Pug.Conversion;

public class FollowPheromoneStateConverter : SingleAuthoringComponentConverter<FollowPheromoneStateAuthoring>
{
	protected override void Convert(FollowPheromoneStateAuthoring authoring)
	{
		EnsureHasComponent<PheromoneSensorCD>();
		PheromoneMask mask = default(PheromoneMask);
		foreach (PheromoneType item in authoring.pheromonesToFollow)
		{
			mask.SetType(item);
		}
		AddComponentData(new FollowPheromoneStateCD
		{
			mask = mask
		});
	}
}
