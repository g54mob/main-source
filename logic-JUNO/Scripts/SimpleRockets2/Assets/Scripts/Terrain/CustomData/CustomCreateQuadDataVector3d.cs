using ModApi.Planet.CustomData;
using UnityEngine;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataVector3d : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataVector3d>
	{
		public Vector3d[] Values;

		public CustomCreateQuadDataVector3d(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new Vector3d[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataVector3d vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
