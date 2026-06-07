using ModApi.Planet.CustomData;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataFloat : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataFloat>
	{
		public float[] Values;

		public CustomCreateQuadDataFloat(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new float[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataFloat vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
