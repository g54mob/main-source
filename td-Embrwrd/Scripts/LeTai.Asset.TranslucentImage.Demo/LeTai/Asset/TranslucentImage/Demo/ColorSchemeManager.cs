using UnityEngine;
using UnityEngine.UI;

namespace LeTai.Asset.TranslucentImage.Demo
{
	public class ColorSchemeManager : MonoBehaviour
	{
		public enum DemoColorScheme
		{
			Light = 0,
			Dark = 1
		}

		public Color lightBackgroudColor;

		public Color lightForegroudColor;

		public Color lightTextColor;

		public Color darkBackgroudColor;

		public Color darkForegroudColor;

		public Color darkTextColor;

		private float lightSpriteBlending;

		public float darkSpriteBlending;

		public TranslucentImage[] foregroundGraphic;

		public Text[] texts;

		private Camera cam;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetLightScheme(bool on)
		{
		}

		public void SetColorScheme(DemoColorScheme scheme)
		{
		}
	}
}
