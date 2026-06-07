using System;
using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Planet
{
	public interface ISolarSystemData
	{
		string Author { get; }

		string Description { get; }

		Color FlareColor { get; }

		Guid Id { get; }

		bool IsDefaultSystem { get; }

		double MapViewScale { get; }

		double MaximumMapViewZoom { get; }

		string Name { get; }

		PlanetCubemapManager PlanetCubemapManager { get; }

		IReadOnlyList<IPlanetData> Planets { get; }

		CelestialBodyScaleData Scale { get; }

		CelestialBodyScaleData ScaleDefaults { get; }

		Version Version { get; }

		string VersionTag { get; }

		void ApplyCustomSkybox();

		IPlanetData GetPlanetData(string planetName);
	}
}
