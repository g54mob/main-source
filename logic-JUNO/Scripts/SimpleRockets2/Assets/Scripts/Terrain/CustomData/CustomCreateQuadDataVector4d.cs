using ModApi.Planet.CustomData;
using UnityEngine;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataVector4d : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataVector4d>
	{
		public Vector4d[] Values;

		public CustomCreateQuadDataVector4d(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new Vector4d[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataVector4d vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
