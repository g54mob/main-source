namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataDouble : CustomPlanetVertexData<CustomPlanetVertexDataDouble>
	{
		public double Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataDouble planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * (double)biomeStrength;
		}

		public override void Reset()
		{
			Value = 0.0;
		}
	}
}
