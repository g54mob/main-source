using UnityEngine;
using UnityEngine.UI;

namespace GRP
{
	public class CameraToRawImage : MonoBehaviour
	{
		public Camera camera;

		public RawImage rawImage;

		public float scale;

		public int rebuildTextureDelta;

		private RenderTexture renderTexture;

		private int _width;

		private int _height;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void BuildTexture()
		{
		}
	}
}
