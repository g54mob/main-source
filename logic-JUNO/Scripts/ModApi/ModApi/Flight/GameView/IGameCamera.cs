using System;
using ModApi.Flight.GameView.Events;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.Flight.GameView
{
	public interface IGameCamera
	{
		double AltitudeAboveSeaLevel { get; }

		PositionBiomeData CameraBiomeData { get; }

		ICameraShake CameraShake { get; }

		Vector3d CameraTargetPlanetPosition { get; }

		Camera FarCamera { get; }

		float FieldOfView { get; set; }

		float FieldOfViewDefault { get; }

		Vector3 FramePosition { get; }

		bool IsOffCenter { get; }

		Camera NearCamera { get; }

		Vector3d PlanetPosition { get; }

		ICameraTarget Target { get; }

		Transform Transform { get; }

		event EventHandler<CameraUnderwaterStateChangedEventArgs> CameraUnderWaterStateChanged;

		void Recenter(bool immediate = false);

		void RegisterPositionOffset(CameraOffset offset);

		void RegisterRotationOffset(CameraOffset offset);

		void Rotate(Vector2 delta);

		void UnregisterPositionOffset(CameraOffset offset);

		void UnregisterRotationOffset(CameraOffset offset);

		void Zoom(float zoomPercentage);
	}
}
