using Unity.Entities;
using Unity.Mathematics;

public struct ExtractorCD : IComponentData, IQueryTypeParameter
{
	public ObjectCategoryTag extractableType;

	public float defaultExtractionTime;

	public float2 defaultMinMaxRandomExtractedOutputAmount;
}
