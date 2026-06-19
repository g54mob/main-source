using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
	public class PlayerHandsCameraSetup : MonoBehaviour
	{
		[SerializeField]
		private Camera _handsCamera;

		private void Awake()
		{
			Setup();
		}

		private void OnEnable()
		{
			Setup();
		}

		private void Setup()
		{
			Camera main = Camera.main;
			if (!(main == null) && !(_handsCamera == null))
			{
				UniversalAdditionalCameraData universalAdditionalCameraData = main.GetUniversalAdditionalCameraData();
				_handsCamera.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
				if (!universalAdditionalCameraData.cameraStack.Contains(_handsCamera))
				{
					universalAdditionalCameraData.cameraStack.Add(_handsCamera);
				}
				Debug.Log($"Stack count: {universalAdditionalCameraData.cameraStack.Count}");
			}
		}
	}
}
