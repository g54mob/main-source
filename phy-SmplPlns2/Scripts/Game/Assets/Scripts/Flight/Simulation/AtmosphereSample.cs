namespace Assets.Scripts.Flight.Simulation
{
	public struct AtmosphereSample
	{
		public float AirDensity { get; set; }

		public float AirDensityRatio { get; set; }

		public float AirPressure { get; set; }

		public float SampleAltitude { get; set; }

		public float SpeedOfSound { get; set; }

		public double SurfaceAirDensity { get; set; }

		public float Temperature { get; set; }
	}
}
