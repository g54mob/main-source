using UnityEngine;

namespace DefaultNamespace
{
	public class ReflectionUpdater : MonoBehaviour
	{
		private CameraController cameraController;

		public Vector3 startScale;

		public float scaleMultiplier = 8f;

		private void Start()
		{
			cameraController = CameraController.Instance;
			startScale = base.transform.localScale;
		}

		private void Update()
		{
			base.transform.localScale = new Vector3(startScale.x, (1f - cameraController.cam.orthographicSize / 5f) * scaleMultiplier + startScale.y, startScale.z);
		}
	}
}
