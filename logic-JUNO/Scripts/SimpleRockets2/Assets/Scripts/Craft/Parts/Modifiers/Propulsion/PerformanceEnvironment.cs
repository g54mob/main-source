using ModApi.Planet;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class PerformanceEnvironment
	{
		public double AtmosphereHeight { get; set; }

		public double GuesstimatedStarDistance { get; private set; }

		public double MeanMassPerMolecule { get; private set; }

		public double MeanGamma { get; private set; }

		public string Name { get; set; }

		public double ScaleHeight { get; set; }

		public double SurfaceAirDensity { get; }

		public double SurfaceGravity { get; }

		public double SurfaceTemperature { get; set; }

		public PerformanceEnvironment(PlanetDataScript planet)
		{
			Name = planet.Name;
			ScaleHeight = planet.AtmosphereData.ScaleHeight;
			AtmosphereHeight = planet.AtmosphereData.Height;
			SurfaceTemperature = planet.AtmosphereData.MeanSurfaceTemperature;
			MeanMassPerMolecule = planet.AtmosphereData.MeanMassPerMolecule;
			MeanGamma = planet.AtmosphereData.MeanGamma;
			SurfaceAirDensity = planet.AtmosphereData.SurfaceAirDensity;
			SurfaceGravity = planet.SurfaceGravity;
			GuesstimatedStarDistance = RecursiveSemiMajSum(planet);
		}

		public AtmosphereSample Sample(double altitudePercentage)
		{
			double num = altitudePercentage * AtmosphereHeight;
			AtmosphereSample result = new AtmosphereSample
			{
				SampleAltitude = (float)num,
				Temperature = (float)SurfaceTemperature,
				AtmosphereHeight = (float)AtmosphereHeight,
				ScaleHeight = (float)ScaleHeight,
				SurfaceAirDensity = (float)SurfaceAirDensity,
				SpeedOfSound = (float)PlanetAtmosphereData.CalculateSpeedOfSound(SurfaceTemperature, MeanGamma, MeanMassPerMolecule)
			};
			if (result.SampleAltitude < result.AtmosphereHeight)
			{
				result.AirDensity = (float)PlanetAtmosphereData.CalculateAirDensity(num, ScaleHeight, SurfaceAirDensity);
				result.AirPressure = (float)PlanetAtmosphereData.CalculateAirPressure(num, ScaleHeight, SurfaceAirDensity, SurfaceTemperature, MeanMassPerMolecule);
			}
			return result;
		}

		private double RecursiveSemiMajSum(PlanetDataScript planet)
		{
			if (!(planet.Parent == null))
			{
				return planet.OrbitData.SemiMajorAxis + RecursiveSemiMajSum(planet.Parent);
			}
			return 0.0;
		}
	}
}
