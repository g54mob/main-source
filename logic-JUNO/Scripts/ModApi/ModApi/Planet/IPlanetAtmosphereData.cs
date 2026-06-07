namespace ModApi.Planet
{
	public interface IPlanetAtmosphereData
	{
		double CrushAltitude { get; }

		string Description { get; }

		bool HasPhysicsAtmosphere { get; }

		double Height { get; }

		double MeanGamma { get; }

		double MeanMassPerMolecule { get; }

		double MeanSurfaceTemperature { get; }

		double MeanSurfaceTemperatureDay { get; }

		double MeanSurfaceTemperatureNight { get; }

		double ScaleHeight { get; }

		double SurfaceAirDensity { get; }

		AtmosphereSample SampleAltitude(double altitude);
	}
}
