using UnityEngine;

namespace Crosstales.Common.Util
{
	public class RandomColor : MonoBehaviour
	{
		public bool UseInterval;

		public Vector2 ChangeInterval;

		public Vector2 HueRange;

		public Vector2 SaturationRange;

		public Vector2 ValueRange;

		public Vector2 AlphaRange;

		public bool GrayScale;

		public Material Material;

		public bool RandomColorAtStart;

		private float elapsedTime;

		private float changeTime;

		private Renderer currentRenderer;

		private Color32 startColor;

		private Color32 endColor;

		private float lerpProgress;

		private static readonly int colorID;

		private bool existsMaterial;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
