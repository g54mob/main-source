using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Common.Events;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.PlanetStudio
{
	public interface IPlanetarySystemDesigner
	{
		IReadOnlyList<CelestialFileDesignerInfo> CelestialBodyFiles { get; }

		SolarSystemDataScript CurrentPlanetarySystem { get; }

		GameObject GameObject { get; }

		bool UIVisible { get; set; }

		event SimpleNotificationDelegate PlanetarySystemLoaded;

		event SimpleNotificationDelegate PlanetarySystemModified;

		OperationResult AddCelestialBody(CelestialFile celestialBodyFile, string localId, string parentCelestialBodyLocalId, XElement orbitXml = null);

		OperationResult AddCelestialBodyFile(CelestialFileReference fileReference);

		OperationResult AddCelestialBodyFile(CelestialFile file, string localId);

		OperationResult LoadPlanetarySystem(CelestialFile planetarySystemFile);

		OperationResult RemoveCelestialBody(string celestialBodyLocalId);

		OperationResult ReplaceCelestialBody(CelestialFile file, string localId);

		OperationResult SavePlanetarySystem(string filePath, bool useFilePaths);

		void UnloadPlanetarySystem();

		OperationResult ViewPlanetarySystem(bool cleanGeneratedData, bool? resetView = null);
	}
}
