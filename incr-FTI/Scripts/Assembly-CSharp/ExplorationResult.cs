using System.Collections.Generic;
using System.Text;

public class ExplorationResult
{
	public int housingPlots;

	public int fertileGround;

	public ItemList cost;

	public readonly Dictionary<NaturalResource, float> resources;

	public ExplorationResult()
	{
		cost = new ItemList();
		resources = new Dictionary<NaturalResource, float>(new NaturalResourceEqualityComparer());
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Explore result: ");
		foreach (KeyValuePair<NaturalResource, float> resource in resources)
		{
			stringBuilder.Append(resource.Key.ToString() + ":" + resource.Value);
		}
		return stringBuilder.ToString();
	}
}
