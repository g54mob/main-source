using Assets.Scripts.Flight.MapView.Items;
using ModApi.Flight.MapView;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface ICurrentCameraTarget
	{
		float CurrentZoomPercent { get; }

		float DistanceFromTarget { get; }

		float DistanceFromTargetsAssociatedPlanet { get; }

		ICameraFocusable Target { get; }

		MapPlanet TargetsAssociatedPlanet { get; }

		event CurrentCameraTargetHandler TargetChanged;

		void SetTarget(ICameraFocusable target, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition);
	}
}
