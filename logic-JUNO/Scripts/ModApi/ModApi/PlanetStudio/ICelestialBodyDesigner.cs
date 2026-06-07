using System;
using System.Collections.Generic;
using ModApi.CelestialData;
using ModApi.Flight.GameView;
using ModApi.Planet;
using ModApi.PlanetStudio.Events;
using UnityEngine;

namespace ModApi.PlanetStudio
{
	public interface ICelestialBodyDesigner
	{
		ICelestialBodyViewer CelestialBodyViewer { get; }

		PlanetDataScript CurrentCelestialBody { get; }

		GameObject GameObject { get; }

		IGameView GameView { get; }

		bool RegenOnRandomize { get; set; }

		IReadOnlyList<CelestialFileDesignerInfo> SupportFiles { get; }

		event EventHandler<CelestialBodyLoadedEventArgs> CelestialBodyLoaded;

		event EventHandler<CelestialBodyLoadingEventArgs> CelestialBodyLoading;

		event EventHandler<CelestialBodyModifiedEventArgs> CelestialBodyModified;

		event EventHandler<CelestialBodyUnloadedEventArgs> CelestialBodyUnloaded;

		event EventHandler<CelestialBodyUnloadingEventArgs> CelestialBodyUnloading;

		event EventHandler<CelestialBodyViewRefreshedEventArgs> CelestialBodyViewRefreshed;

		event EventHandler<CelestialBodyViewRefreshedEventArgs> CelestialBodyViewRefreshing;

		OperationResult AddSupportFile(string filePath);

		OperationResult AddSupportFile(CelestialFileReference fileReference);

		OperationResult AddSupportFile(CelestialFile file, string localId);

		string GetOrCreateSupportFileReference(string fullPath);

		CelestialFile GetSupportFile(string localId);

		OperationResult LoadCelestialBody(CelestialFile celestialBodyFile);

		void RefreshQuadSphereRenderer();

		OperationResult RemoveSupportFile(string localId);

		OperationResult SaveCelestialBody(string filePath, bool useFilePaths);

		void UnloadCelestialBody();

		OperationResult ViewCelestialBody(bool cleanGeneratedData, bool? resetView = null);
	}
}
