using UnityEngine;

namespace Cainos.PixelArtTopDown_Village
{
	public class CameraZoom : MonoBehaviour
	{
		public Vector2 OrthoSizeRange;

		public KeyCode keyZoomIn;

		public KeyCode keyZoomOut;

		public float lerp;

		private float curSize;

		private float targetSize;

		private Camera cam;

		private Camera Camera => null;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
