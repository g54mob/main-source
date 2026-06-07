using ModApi.Planet.CustomData;
using UnityEngine;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataVector3 : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataVector3>
	{
		public Vector3[] Values;

		public CustomCreateQuadDataVector3(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new Vector3[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataVector3 vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
