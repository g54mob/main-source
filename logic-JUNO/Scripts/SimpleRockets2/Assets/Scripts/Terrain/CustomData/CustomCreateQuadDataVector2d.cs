using ModApi.Planet.CustomData;
using UnityEngine;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataVector2d : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataVector2d>
	{
		public Vector2d[] Values;

		public CustomCreateQuadDataVector2d(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new Vector2d[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataVector2d vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
