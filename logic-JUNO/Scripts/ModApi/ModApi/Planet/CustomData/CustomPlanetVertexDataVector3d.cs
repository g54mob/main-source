using UnityEngine;

namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataVector3d : CustomPlanetVertexData<CustomPlanetVertexDataVector3d>
	{
		public Vector3d Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataVector3d planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * biomeStrength;
		}

		public override void Reset()
		{
			Value = Vector3d.zero;
		}
	}
}
