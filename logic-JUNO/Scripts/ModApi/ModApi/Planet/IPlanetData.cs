using System;
using System.Collections.Generic;
using ModApi.CelestialData;
using ModApi.Flight.Sim;
using ModApi.State;

namespace ModApi.Planet
{
	public interface IPlanetData
	{
		double AngularVelocity { get; }

		IPlanetAtmosphereData AtmosphereData { get; }

		string Author { get; }

		List<LaunchLocation> DefaultLaunchLocations { get; }

		string Description { get; }

		double EscapeVelocity { get; }

		CelestialBodyFileData FileData { get; }

		CelestialDatabaseGeneratedData GeneratedData { get; }

		bool HasTerrainPhysics { get; }

		bool HasWater { get; }

		Guid Id { get; }

		double ImpactRadius { get; }

		double ImpactRadiusSquared { get; }

		double Mass { get; }

		double MaxEstimatedTerrainElevation { get; }

		List<string> ModKeywords { get; }

		string[] MusicKeywords { get; }

		string MusicIntensityExpression { get; }

		string Name { get; }

		OrbitData OrbitData { get; }

		IPlanetData Parent { get; }

		CelestialBodyPlanetarySystemDefinedData PlanetarySystemDefinedData { get; }

		double QuadSphereActivationDistance { get; }

		double QuadSphereTransitionDistance { get; }

		double Radius { get; }

		double RadiusScaledSpace { get; }

		double RadiusSquared { get; }

		IPlanetRingsData RingsData { get; }

		CelestialBodyScaleData Scale { get; }

		CelestialBodyScaleData ScaleDefaults { get; }

		float SeaLevel { get; }

		bool SkyboxFadeDuringDaytime { get; }

		PlanetShaderData SkyShaderData { get; }

		bool SkyShaderEnabled { get; }

		ISolarSystemData SolarSystemData { get; }

		double? SphereOfInfluence { get; }

		List<StructureNodeData> StructureNodes { get; }

		double SurfaceGravity { get; }

		bool SyncPropertiesFromTerrain { get; }

		IPlanetTerrainData TerrainData { get; }

		PlanetShaderData TerrainShaderData { get; }

		bool UniformHeight { get; }

		Version Version { get; }

		string VersionTag { get; }

		double GetWaveTime(double gameTime);

		IPlanetTerrainData LoadTerrainData();

		PlanetCubemapsRequest RequestCubemaps(string requestName, int size, Action<PlanetCubemapsRequest> onCubemapsUpdated);

		void UnloadTerrainData();
	}
}
