using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class RelocateToActiveCameraScript : MonoBehaviour
	{
		[SerializeField]
		private CameraManagerScript _cameraManager;

		[SerializeField]
		private Transform _parentFlat;

		[SerializeField]
		private Transform _parentXR;

		protected virtual void Start()
		{
			if (_cameraManager?.XRCameraManager != null)
			{
				_cameraManager.XRCameraManager.OnXrCamerasEnabledChanged += OnOnXrCamerasEnabledChanged;
				RelocateToActiveCamera();
			}
		}

		private void OnOnXrCamerasEnabledChanged(bool enabled)
		{
			RelocateToActiveCamera();
		}

		private void RelocateToActiveCamera()
		{
			if (_cameraManager.XRCameraManager.XrCamerasEnabled)
			{
				base.transform.SetParent(_parentXR, worldPositionStays: false);
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
			}
			else
			{
				base.transform.SetParent(_parentFlat, worldPositionStays: false);
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
			}
		}
	}
}
