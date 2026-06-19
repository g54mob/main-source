using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

public struct BiomeLookup : IDisposable
{
	[MarshalAs(UnmanagedType.U1)]
	public bool UseSamples;

	public BiomeSamplesCD Samples;

	public FixedList512Bytes<BiomeRanges> Ranges;

	public BiomeLookup(BiomeSamplesCD biomeSamples)
	{
		UseSamples = true;
		Samples = biomeSamples;
		Ranges = default(FixedList512Bytes<BiomeRanges>);
	}

	public BiomeLookup(FixedList512Bytes<BiomeRanges> ranges, Allocator allocator)
	{
		UseSamples = false;
		Samples = default(BiomeSamplesCD);
		Samples.Samples = CollectionHelper.CreateNativeArray<byte>(0, allocator);
		Samples.BasePosition = new NativeReference<int2>(allocator);
		Ranges = ranges;
	}

	public void Dispose()
	{
		if (!UseSamples)
		{
			if (Samples.Samples.IsCreated)
			{
				Samples.Samples.Dispose();
			}
			if (Samples.BasePosition.IsCreated)
			{
				Samples.BasePosition.Dispose();
			}
		}
	}

	public Biome GetBiome(int2 worldPosition)
	{
		if (!UseSamples)
		{
			return BiomeRanges.GetBiomeAtPosition(worldPosition, Ranges);
		}
		return Samples.GetBiome(worldPosition);
	}

	public bool IsOnlyBiomeInRange(int2 worldPosition, int range, Biome biome)
	{
		if (!UseSamples)
		{
			return BiomeRanges.IsWithinBiome(worldPosition, Ranges[(int)biome], -range);
		}
		return Samples.IsOnlyBiomeInRange(worldPosition, range, biome);
	}

	public bool TryGetRandomPositionInBiome(Biome biome, ref Unity.Mathematics.Random rng, out int2 result, int minDistanceFromCore = 0, int maxDistanceFromCore = int.MaxValue, int maxAttempts = 100)
	{
		if (!UseSamples)
		{
			return BiomeRanges.TryGetRandomPositionInBiome(ref rng, Ranges[(int)biome], out result, minDistanceFromCore, maxDistanceFromCore);
		}
		return Samples.TryGetRandomPositionInBiome(biome, ref rng, out result, minDistanceFromCore, maxDistanceFromCore, maxAttempts);
	}

	public bool TryGetDistanceToBiome(int2 worldPosition, Biome biome, out float distance, int maxRange)
	{
		if (GetBiome(worldPosition) == biome)
		{
			distance = 0f;
			return true;
		}
		distance = float.PositiveInfinity;
		int num = (int)math.ceil((float)maxRange / 16f);
		for (int i = 0; i <= num; i++)
		{
			for (int j = -i; j <= i; j++)
			{
				int2 int5 = worldPosition + new int2(j * 16, i * 16);
				if (GetBiome(int5) == biome)
				{
					distance = math.min(distance, math.distance(worldPosition, int5));
				}
				int5 = worldPosition + new int2(j * 16, -i * 16);
				if (GetBiome(int5) == biome)
				{
					distance = math.min(distance, math.distance(worldPosition, int5));
				}
			}
			for (int k = -i + 1; k <= i - 1; k++)
			{
				int2 int6 = worldPosition + new int2(i * 16, k * 16);
				if (GetBiome(int6) == biome)
				{
					distance = math.min(distance, math.distance(worldPosition, int6));
				}
				int6 = worldPosition + new int2(-i * 16, k * 16);
				if (GetBiome(int6) == biome)
				{
					distance = math.min(distance, math.distance(worldPosition, int6));
				}
			}
			if (distance <= (float)maxRange)
			{
				return true;
			}
		}
		return false;
	}

	public bool TryFindNearbyBiomeFromSelection(int2 worldPosition, FixedList32Bytes<Biome> biomes, out Biome biome, int maxRange = 256)
	{
		biome = GetBiome(worldPosition);
		if (ListContainsBiome(biome, biomes))
		{
			return true;
		}
		for (int i = 16; i <= maxRange; i += 16)
		{
			biome = GetBiome(worldPosition + new int2(i, 0));
			if (ListContainsBiome(biome, biomes))
			{
				return true;
			}
			biome = GetBiome(worldPosition + new int2(-i, 0));
			if (ListContainsBiome(biome, biomes))
			{
				return true;
			}
			biome = GetBiome(worldPosition + new int2(0, i));
			if (ListContainsBiome(biome, biomes))
			{
				return true;
			}
			biome = GetBiome(worldPosition + new int2(0, -i));
			if (ListContainsBiome(biome, biomes))
			{
				return true;
			}
		}
		biome = Biome.None;
		return false;
	}

	private bool ListContainsBiome(Biome biome, FixedList32Bytes<Biome> biomes)
	{
		foreach (Biome item in biomes)
		{
			if (item == biome)
			{
				return true;
			}
		}
		return false;
	}
}
