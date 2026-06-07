using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataVector3 : CustomPlanetVertexData<CustomPlanetVertexDataVector3>
	{
		public Vector3 Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataVector3 planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * biomeStrength;
		}

		public override void Reset()
		{
			Value = Vector3.zero;
		}
	}
}
