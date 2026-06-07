using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

namespace VampireSurvivors.App.Graphics
{
	public class PixelPerfectProCameraController : MonoBehaviour
	{
		private const float DEFAULT_SCALE = 0.5f;

		private const float DEFAULT_WIDTH = 1920f;

		private const float DEFAULT_HEIGHT = 1200f;

		private const float PHASER_DEFAULT_WIDTH = 1366f;

		private const float PHASER_DEFAULT_HEIGHT = 1024f;

		private ProCamera2DPixelPerfect _ppCam;

		private int _prevScreenHeight;

		private int _prevScreenWidth;

		private float _widthToHeightRatio;

		private float _heightToWidthRatio;

		private void Awake()
		{
		}

		private void FixedUpdate()
		{
		}

		private void UpdateCamera()
		{
		}
	}
}
