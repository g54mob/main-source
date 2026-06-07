using ModApi.Planet.CustomData;

namespace Assets.Scripts.Terrain.CustomData
{
	public class CustomCreateQuadDataDouble : CustomCreateQuadDataFromCustomVertexData<CustomPlanetVertexDataDouble>
	{
		public double[] Values;

		public CustomCreateQuadDataDouble(string customPlanetVertexDataId)
			: base(customPlanetVertexDataId)
		{
		}

		public override void Initialize(int terrainQuadVertexCount)
		{
			Values = new double[terrainQuadVertexCount];
		}

		protected override void OnQuadDataGenerated(int vertexIndex, CustomPlanetVertexDataDouble vertexData)
		{
			Values[vertexIndex] = vertexData.Value;
		}
	}
}
