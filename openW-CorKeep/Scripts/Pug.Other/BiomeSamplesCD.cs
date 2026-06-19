using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[AssumeReadOnly]
public struct BiomeSamplesCD : IComponentData, IQueryTypeParameter
{
	public NativeReference<int2> BasePosition;

	public int SamplesPerDimension;

	public NativeArray<byte> Samples;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Biome GetBiome(int2 worldPosition)
	{
		return (Biome)Samples[PositionToIndex(worldPosition)];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsOnlyBiomeInRange(int2 worldPosition, int range, Biome biome)
	{
		int num = (int)math.ceil((float)(2 * range + 1) / 16f);
		int2 int5 = worldPosition - range;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				int2 worldPosition2 = int5 + new int2(j, i) * 16;
				if (GetBiome(worldPosition2) != biome)
				{
					return false;
				}
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetRandomPositionInBiome(Biome biome, ref Random rng, out int2 result, int minDistanceFromCore = 0, int maxDistanceFromCore = int.MaxValue, int maxAttempts = 100)
	{
		maxDistanceFromCore = math.min(maxDistanceFromCore, SamplesPerDimension * 16 / 2);
		for (int i = 0; i < maxAttempts; i++)
		{
			int2 int5 = PugRandom.UniformDiskSample(ref rng, minDistanceFromCore, maxDistanceFromCore).RoundToInt2();
			if (GetBiome(int5) == biome)
			{
				result = int5;
				return true;
			}
		}
		result = default(int2);
		return false;
	}

	private int PositionToIndex(int2 worldPosition)
	{
		worldPosition -= BasePosition.Value;
		worldPosition >>= 4;
		worldPosition = math.clamp(worldPosition, int2.zero, SamplesPerDimension - 1);
		return worldPosition.y * SamplesPerDimension + worldPosition.x;
	}
}
