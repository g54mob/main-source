using UnityEngine;

namespace CTS
{
	public class CameraRenderTimeControler : MonoBehaviour
	{
		[SerializeField]
		[Range(1f, 60f)]
		private float fps;

		private Camera cam;

		private float elapsed;

		private void Start()
		{
			cam = GetComponent<Camera>();
			cam.enabled = false;
		}

		private void Update()
		{
			elapsed += Time.unscaledDeltaTime;
			if (elapsed > 1f / fps)
			{
				elapsed = 0f;
				cam.Render();
			}
		}
	}
}
