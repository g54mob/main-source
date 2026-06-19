using Pug.Conversion;

public class PheromoneConverter : SingleAuthoringComponentConverter<PheromoneAdderAuthoring>
{
	protected override void Convert(PheromoneAdderAuthoring authoring)
	{
		PheromoneAdderCD component = default(PheromoneAdderCD);
		foreach (PheromoneType pheromone in authoring.pheromones)
		{
			component.mask.SetType(pheromone);
		}
		AddComponentData(component);
	}
}
