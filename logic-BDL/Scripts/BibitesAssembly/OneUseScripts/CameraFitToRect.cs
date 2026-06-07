using UnityEngine;

namespace OneUseScripts
{
	public class CameraFitToRect : MonoBehaviour
	{
		private Camera cam;

		private RectTransform rt;

		private void Awake()
		{
			cam = GetComponent<Camera>();
			rt = GetComponent<RectTransform>();
			cam.orthographicSize = rt.rect.height;
		}

		private void OnRectTransformDimensionsChange()
		{
			cam.orthographicSize = rt.rect.height;
		}
	}
}
