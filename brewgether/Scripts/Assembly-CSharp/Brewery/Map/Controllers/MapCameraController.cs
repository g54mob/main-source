using UnityEngine;

namespace Brewery.Map.Controllers
{
	public class MapCameraController
	{
		public struct CameraState
		{
			public Vector3 position;

			public Quaternion rotation;

			public float fieldOfView;

			public float orthographicSize;

			public bool isOrthographic;
		}

		private readonly Camera camera;

		private readonly MapCameraSettings settings;

		private CameraState savedPlayerState;

		private LayerMask savedCullingMask;

		private CameraClearFlags savedClearFlags;

		private Color savedBackgroundColor;

		private float savedFarClipPlane;

		private float currentZoom;

		private float targetZoom;

		private float zoomVelocity;

		public float CurrentZoom => 0f;

		public float TargetZoom
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public CameraState SavedState => default(CameraState);

		public MapCameraController(Camera camera, MapCameraSettings settings)
		{
		}

		public void SaveCameraState(Transform cameraRig)
		{
		}

		public void ApplyMapRenderSettings()
		{
		}

		public void RestoreCameraState(Transform cameraRig)
		{
		}

		public void InitializeZoom()
		{
		}

		public void HandleZoomInput(float scrollDelta)
		{
		}

		public void UpdateZoom()
		{
		}

		public void ApplyZoomToCamera()
		{
		}

		public void SetCameraFOV(float value, bool forceOrthographic = false)
		{
		}

		public Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}

		public Camera GetCamera()
		{
			return null;
		}

		public float CalculateEquivalentFOV(float orthoSize, float viewDistance)
		{
			return 0f;
		}
	}
}
