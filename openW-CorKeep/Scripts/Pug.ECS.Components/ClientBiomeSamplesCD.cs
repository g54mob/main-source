using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ClientBiomeSamplesCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int2 BasePosition;

	[GhostField]
	public int LinearBaseIndex;

	[GhostField]
	public FixedArray64 Biomes;

	public static int2 GetBaseIndex(int linearBaseIndex)
	{
		return new int2(linearBaseIndex % 6, linearBaseIndex / 6);
	}

	public static int GetLinearIndex(int2 baseIndex, int2 position)
	{
		int2 int5 = baseIndex + position;
		if (int5.x >= 6)
		{
			int5.x -= 6;
		}
		if (int5.y >= 6)
		{
			int5.y -= 6;
		}
		return int5.y * 6 + int5.x;
	}
}
