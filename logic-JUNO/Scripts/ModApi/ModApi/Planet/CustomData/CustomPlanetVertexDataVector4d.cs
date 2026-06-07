using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataVector4d : CustomPlanetVertexData<CustomPlanetVertexDataVector4d>
	{
		public Vector4d Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataVector4d planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * biomeStrength;
		}

		public override void Reset()
		{
			Value = Vector4d.zero;
		}
	}
}
