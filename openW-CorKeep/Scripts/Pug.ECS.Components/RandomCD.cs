using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct RandomCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Random Value;

	public static implicit operator Random(RandomCD randomCD)
	{
		return randomCD.Value;
	}

	public static implicit operator RandomCD(Random random)
	{
		return new RandomCD
		{
			Value = random
		};
	}
}
