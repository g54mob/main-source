namespace NSMedieval.Village.Map
{
	public struct TemperatureOutputStruct
	{
		private float temperature;

		private float shadow;

		private float light;

		public float Temperature => temperature;

		public float Shadow => shadow;

		public float Light => light;

		public void Set(float temperature, float shadow, float light)
		{
			this.temperature = temperature;
			this.shadow = shadow;
			this.light = light;
		}
	}
}
