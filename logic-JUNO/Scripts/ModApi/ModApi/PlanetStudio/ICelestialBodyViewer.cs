using System;
using System.Collections.Generic;
using ModApi.Flight.GameView;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.PlanetStudio
{
	public interface ICelestialBodyViewer
	{
		double AltitudeGroundLevel { get; }

		double AltitudeSeaLevel { get; }

		Vector3d CameraPlanetPosition { get; set; }

		Vector3d CameraSolarPosition { get; }

		Quaterniond CameraSolarRotation { get; }

		Vector3d CameraSurfacePosition { get; set; }

		PlanetDataScript CelestialBodyData { get; }

		Camera FarCamera { get; }

		IGameView GameView { get; }

		IEnumerable<IGameViewObject> GameViewObjects { get; }

		double Latitude { get; }

		double Longitude { get; }

		Camera NearCamera { get; }

		IReferenceFrame ReferenceFrame { get; }

		event EventHandler ReferenceFrameRecentered;

		void ResetView(Vector3d? viewPosition = null);
	}
}
