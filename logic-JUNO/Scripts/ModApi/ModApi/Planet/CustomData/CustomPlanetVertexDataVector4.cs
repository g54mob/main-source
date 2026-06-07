using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataVector4 : CustomPlanetVertexData<CustomPlanetVertexDataVector4>
	{
		public Vector4 Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataVector4 planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * biomeStrength;
		}

		public override void Reset()
		{
			Value = Vector4.zero;
		}
	}
}
