using ModApi.Craft;
using UnityEngine;

namespace ModApi.Flight.GameView
{
	public interface IReferenceFrame
	{
		Vector3d Center { get; }

		double DeltaRotation { get; }

		Vector3 FrameSurfaceVelocity { get; }

		bool IsSurfaceLocked { get; }

		bool RecenterEnabled { get; set; }

		double RotationAngle { get; }

		Vector3d SurfaceVelocity { get; }

		Vector3d Velocity { get; }

		Vector3d WaterWaveOffset { get; }

		Vector3d FrameToPlanetPosition(Vector3 framePosition);

		Quaterniond FrameToPlanetRotation(Quaternion frameRotation);

		Vector3d FrameToPlanetVector(Vector3 frameVector);

		Vector3d FrameToPlanetVelocity(Vector3 frameVelocity);

		double GetAltitudeAsl(Vector3 framePos, bool includeWaves, ICraftScript craft);

		Vector3 GetWaterPosBelowPoint(Vector3 framePos, bool includeWaves, ICraftScript craft);

		float GetWaterWaveOffset(Vector3 framePosition, ICraftScript craft);

		float GetWaterWaveOffset(Vector3 framePosition, float agl);

		Vector3 PlanetToFramePosition(Vector3d planetPosition);

		Vector3 PlanetToFramePositionAtTime(Vector3d planetPosition, double time);

		Vector3d PlanetToFramePositiond(Vector3d planetPosition);

		Quaternion PlanetToFrameRotation(Quaterniond planetRotation);

		Vector3 PlanetToFrameVector(Vector3d planetVector);

		Vector3 PlanetToFrameVelocity(Vector3d planetVelocity);
	}
}
