using UnityEngine;

namespace ModApi.Flight.MapView
{
	public interface IMapView
	{
		Camera MapCamera { get; }

		IMapViewInspector MapViewInspector { get; }

		bool SyncCameraWithSelectedItem { get; set; }

		bool UiPanelsVisible { get; set; }

		bool Visible { get; }

		event MapViewHandler Initialized;

		void SetCameraFocus(ICameraFocusable cameraFocus, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition);

		void SetInspectorFocus(ICameraFocusable cameraFocus, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition);
	}
}
