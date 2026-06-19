using Pug.UnityExtensions;
using Unity.Entities;

public struct BiomeDirectionCD : IComponentData, IQueryTypeParameter
{
	public FixedArray64 Value;
}
