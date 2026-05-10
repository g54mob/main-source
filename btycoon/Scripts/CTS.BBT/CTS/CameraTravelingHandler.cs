using CTS.Core;

namespace CTS
{
	public class CameraTravelingHandler : MonoSingleton<CameraTravelingHandler>
	{
		private MainCamera _mainCamera;

		private CameraMovements _cameraMovements;

		private CameraRotation _cameraRotation;

		private CameraZoom _cameraZoom;

		private CameraMouseControls _cameraMouseControls;

		private CameraFollowing _cameraFollowing;

		private CameraTravelingControler _cameraTravelingControler;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			_mainCamera = GetComponent<MainCamera>();
			_cameraMovements = GetComponent<CameraMovements>();
			_cameraRotation = GetComponent<CameraRotation>();
			_cameraZoom = GetComponent<CameraZoom>();
			_cameraMouseControls = GetComponent<CameraMouseControls>();
			_cameraFollowing = GetComponent<CameraFollowing>();
			_cameraTravelingControler = GetComponent<CameraTravelingControler>();
		}

		public void LockAll(bool p_toLockAll)
		{
			_mainCamera.enabled = !p_toLockAll;
			_cameraMovements.enabled = !p_toLockAll;
			_cameraRotation.enabled = !p_toLockAll;
			_cameraZoom.enabled = !p_toLockAll;
			_cameraMouseControls.enabled = !p_toLockAll;
			_cameraFollowing.enabled = !p_toLockAll;
		}
	}
}
