using UnityEngine;

namespace Libs
{
	public class CaptureScreenCamera : MonoBehaviour
	{
		private Camera _camera;

		private void Awake()
		{
		}

		public byte[] GetCaptureBytes()
		{
			return null;
		}

		public Texture2D Capture()
		{
			return null;
		}

		public Texture2D Capture(int newWidth, int newHeight)
		{
			return null;
		}

		private Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
		{
			return null;
		}

		public Camera GetCamera()
		{
			return null;
		}
	}
}
