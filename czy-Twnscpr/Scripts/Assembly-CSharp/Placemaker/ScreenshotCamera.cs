using UnityEngine;

namespace Placemaker
{
	public class ScreenshotCamera : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Camera cam;

		[SerializeField]
		private Material noAlphaBlit;

		[SerializeField]
		private Material vignetteMaterial;

		[SerializeField]
		private Texture vignetteTexture;

		[SerializeField]
		private Material flipVertically;

		[SerializeField]
		private RenderTexture bigTex;

		[SerializeField]
		private RenderTexture smallTex;

		public void OnStart()
		{
		}

		public Texture2D Capture(RectTransform rt, int width, int height, int screenWidth, int screenHeight, Camera refCamera)
		{
			return null;
		}

		public void SaveImageToPath(Texture2D image, string path)
		{
		}
	}
}
