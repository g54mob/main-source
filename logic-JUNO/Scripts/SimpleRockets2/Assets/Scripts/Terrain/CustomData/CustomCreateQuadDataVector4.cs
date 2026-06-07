using ModApi.Planet.CustomData;
using UnityEngine;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataVector4 : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataVector4>
	{
		public Vector4[] Values;

		public CustomCreateQuadDataVector4(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new Vector4[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataVector4 vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
