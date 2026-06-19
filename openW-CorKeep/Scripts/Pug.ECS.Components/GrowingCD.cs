using Pug.Properties;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct GrowingCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int currentStage;

	public float grownTimeToApplyToTimer;

	public bool hasGrownThisFrame;

	public bool HasFinishedGrowing(ObjectPropertiesCD properties)
	{
		return HasReachedFinalStage(properties);
	}

	public bool HasReachedFinalStage(ObjectPropertiesCD properties)
	{
		int num = properties.Get<int>(1963487001);
		return currentStage >= num;
	}
}
