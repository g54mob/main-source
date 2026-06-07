namespace ModApi.Planet.CustomData
{
	public class CustomPlanetVertexDataFloat : CustomPlanetVertexData<CustomPlanetVertexDataFloat>
	{
		public float Value;

		public override void ApplyBiomeResults(CustomPlanetVertexDataFloat planetBiomeVertexData, float biomeStrength)
		{
			Value += planetBiomeVertexData.Value * biomeStrength;
		}

		public override void Reset()
		{
			Value = 0f;
		}
	}
}
