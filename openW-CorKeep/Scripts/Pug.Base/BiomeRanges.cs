using System;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Mathematics;

public struct BiomeRanges
{
	public Biome biome;

	public float start;

	public float end;

	public float shaderStart;

	public float shaderEnd;

	public float startAngle;

	public float endAngle;

	public bool exists;

	public static BiomeRanges All => new BiomeRanges
	{
		start = 0f,
		end = float.PositiveInfinity,
		shaderStart = 0f,
		shaderEnd = float.PositiveInfinity,
		startAngle = 0f,
		endAngle = 360f,
		exists = true
	};

	[Obsolete("Use BiomeLookup instead to support full release worldgen.")]
	public static bool IsWithinBiome(int2 pos, BiomeRanges biomeRanges, float distancePadding = 0f, float anglePaddingInDegrees = 0f)
	{
		if (!biomeRanges.exists)
		{
			return false;
		}
		float num = math.length(pos);
		if (num < biomeRanges.start - distancePadding || num > biomeRanges.end + distancePadding)
		{
			return false;
		}
		return IsWithinBiomeSideAngles(pos, biomeRanges, anglePaddingInDegrees);
	}

	[Obsolete("Use BiomeLookup instead to support full release worldgen.")]
	public static bool IsWithinBiomeSideAngles(int2 pos, BiomeRanges biomeRanges, float anglePaddingInDegrees = 0f)
	{
		if (!biomeRanges.exists)
		{
			return false;
		}
		if (biomeRanges.startAngle == 0f && biomeRanges.endAngle == 360f)
		{
			return true;
		}
		float num = math.degrees(math.atan2(pos.y, pos.x)) + 180f;
		float num2 = biomeRanges.endAngle + anglePaddingInDegrees;
		float num3 = biomeRanges.startAngle - anglePaddingInDegrees;
		if (num2 > 360f)
		{
			if (num > num2 % 360f && num < num3)
			{
				return false;
			}
		}
		else if (num < num3 || num > num2)
		{
			return false;
		}
		return true;
	}

	[Obsolete("Use BiomeLookup instead to support full release worldgen.")]
	public static bool TryGetRandomPositionWithinBiomeRanges(ref Unity.Mathematics.Random rng, BiomeRanges biomeRanges, float anglePadding, out int2 result)
	{
		result = int2.zero;
		if (!biomeRanges.exists)
		{
			return false;
		}
		float x = rng.NextFloat(biomeRanges.startAngle + anglePadding, biomeRanges.endAngle - anglePadding) - 180f;
		float num = rng.NextFloat(biomeRanges.start, biomeRanges.end);
		result = (int2)math.round(new float2(math.cos(math.radians(x)), math.sin(math.radians(x))) * num);
		return true;
	}

	[Obsolete("Use BiomeLookup instead to support full release worldgen.")]
	public static bool TryGetRandomPositionInBiome(ref Unity.Mathematics.Random rng, BiomeRanges biomeRanges, out int2 result, int minDistanceFromCore = 0, int maxDistanceFromCore = int.MaxValue)
	{
		result = int2.zero;
		if (!biomeRanges.exists)
		{
			return false;
		}
		maxDistanceFromCore = ((maxDistanceFromCore == int.MaxValue) ? ((int)math.round(1.5f * (float)minDistanceFromCore)) : maxDistanceFromCore);
		result = PugRandom.UniformDiskSample(ref rng, minDistanceFromCore, maxDistanceFromCore, (biomeRanges.startAngle - 180f) * (MathF.PI / 180f), (biomeRanges.endAngle - 180f) * (MathF.PI / 180f)).RoundToInt2();
		return true;
	}

	[Obsolete("Use BiomeLookup instead to support full release worldgen.")]
	public static Biome GetBiomeAtPosition(int2 pos, FixedList512Bytes<BiomeRanges> biomeRanges)
	{
		foreach (BiomeRanges item in biomeRanges)
		{
			if (IsWithinBiome(pos, item))
			{
				return item.biome;
			}
		}
		return Biome.None;
	}

	public static float3 GetDirectionToMiddleOfBiome(BiomeRanges biomeRanges)
	{
		float num = (biomeRanges.startAngle + (biomeRanges.endAngle - biomeRanges.startAngle) / 2f + 180f) % 360f * (MathF.PI / 180f);
		return math.mul(quaternion.AxisAngle(math.up(), 0f - num), math.right());
	}
}
