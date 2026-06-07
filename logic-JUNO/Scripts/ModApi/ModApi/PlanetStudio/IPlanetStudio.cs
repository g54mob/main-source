namespace ModApi.PlanetStudio
{
	public interface IPlanetStudio
	{
		ICelestialBodyDesigner CelestialBodyDesigner { get; }

		IPlanetarySystemDesigner PlanetarySystemDesigner { get; }

		IPlanetStudioUI PlanetStudioUI { get; }
	}
}
