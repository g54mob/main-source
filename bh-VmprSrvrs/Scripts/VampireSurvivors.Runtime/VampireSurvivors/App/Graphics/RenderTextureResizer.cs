using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.App.Graphics
{
	public class RenderTextureResizer : MonoBehaviour
	{
		[SerializeField]
		private AspectRatioFitter _AspectRatioFitter;

		private ProCamera2DPixelPerfect _ppCam;

		private int _prevScreenHeight;

		private int _prevScreenWidth;

		private Camera _mainCam;

		private RawImage _rawImage;

		private RenderTexture _currentRT;

		private ProCamera2DPixelPerfect _proCamera2DPixelPerfect;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateRT(bool force = false)
		{
		}
	}
}
