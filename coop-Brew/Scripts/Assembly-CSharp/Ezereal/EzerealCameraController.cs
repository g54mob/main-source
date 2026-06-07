using UnityEngine;

namespace Ezereal
{
	public class EzerealCameraController : MonoBehaviour
	{
		[SerializeField]
		private CameraViews currentCameraView;

		[SerializeField]
		private GameObject[] cameras;

		private void Awake()
		{
		}

		private void OnSwitchCamera()
		{
		}

		private void SetCameraView(CameraViews view)
		{
		}
	}
}
