using UnityEngine;

namespace Gh.Tk
{
	public class AdjustPixelateOnCamZoom : MonoBehaviour
	{
		public Material pixelateMaterial;

		public AnimationCurve pixelateRange;

		private float _camZoomInMax;

		private float _camZoomOutMax;

		private float _camZoomRange;

		private float _currentZ;

		private Transform _camT;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
