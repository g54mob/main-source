using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	public interface IBrushCubemapModifier
	{
		bool ApplyNoise { get; set; }

		bool CanApplyNoise { get; }

		bool CanSkipOctaves { get; }

		Gradient MapColorGradient { get; set; }

		string MapDisplayName { get; }

		string MapId { get; }

		int NoiseOctaveSkipCount { get; set; }

		double NoiseStrength { get; set; }

		byte[] GenerateMap(int size);
	}
}
