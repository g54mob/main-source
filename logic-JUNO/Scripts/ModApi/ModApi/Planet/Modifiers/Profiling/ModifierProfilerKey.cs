using System;
using ModApi.Planet.Modifiers.VertexData;

namespace ModApi.Planet.Modifiers.Profiling
{
	public readonly struct ModifierProfilerKey : IEquatable<ModifierProfilerKey>
	{
		public readonly int BiomeIndex;

		public readonly int ModifierIndex;

		public readonly int PassIndex;

		public ModifierProfilerKey(int biomeIndex, int passIndex, int modifierIndex)
		{
			BiomeIndex = biomeIndex;
			PassIndex = passIndex;
			ModifierIndex = modifierIndex;
		}

		public ModifierProfilerKey(VertexDataPlanetModifier modifier)
		{
			BiomeIndex = modifier.Biome?.transform.GetSiblingIndex() ?? 255;
			PassIndex = (int)modifier.Pass;
			ModifierIndex = modifier.transform.GetSiblingIndex();
		}

		public static bool operator !=(ModifierProfilerKey left, ModifierProfilerKey right)
		{
			return !left.Equals(right);
		}

		public static bool operator ==(ModifierProfilerKey left, ModifierProfilerKey right)
		{
			return left.Equals(right);
		}

		public override bool Equals(object obj)
		{
			if (obj is ModifierProfilerKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ModifierProfilerKey other)
		{
			if (BiomeIndex == other.BiomeIndex && PassIndex == other.PassIndex)
			{
				return ModifierIndex == other.ModifierIndex;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (PassIndex << 24) + (BiomeIndex << 16) + ModifierIndex;
		}
	}
}
