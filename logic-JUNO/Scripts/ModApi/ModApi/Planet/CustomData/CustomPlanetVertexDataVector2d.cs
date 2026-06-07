using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataVector2d : CustomPlanetVertexData<CustomPlanetVertexDataVector2d>
	{
		public Vector2d Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataVector2d planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * biomeStrength;
		}

		public override void Reset()
		{
			Value = Vector2d.zero;
		}
	}
}
