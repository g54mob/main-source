using System;
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

		public Color lightBackgroudColor = Color.white;

		public Color lightForegroudColor = Color.white;

		public Color lightTextColor = Color.white;

		public Color darkBackgroudColor = Color.black;

		public Color darkForegroudColor = Color.black;

		public Color darkTextColor = Color.black;

		public Graphic[] foregroudGraphic;

		public Text[] texts;

		private Camera cam;

		private void Start()
		{
			cam = Camera.main;
		}

		public void SetLightScheme(bool on)
		{
			SetColorScheme((!on) ? DemoColorScheme.Dark : DemoColorScheme.Light);
		}

		public void SetColorScheme(DemoColorScheme scheme)
		{
			Color backgroundColor;
			Color color;
			Color color2;
			switch (scheme)
			{
			case DemoColorScheme.Light:
				backgroundColor = lightBackgroudColor;
				color = lightForegroudColor;
				color2 = lightTextColor;
				break;
			case DemoColorScheme.Dark:
				backgroundColor = darkBackgroudColor;
				color = darkForegroudColor;
				color2 = darkTextColor;
				break;
			default:
				throw new ArgumentOutOfRangeException("scheme", scheme, null);
			}
			cam.backgroundColor = backgroundColor;
			Graphic[] array = foregroudGraphic;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = color;
			}
			Text[] array2 = texts;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].color = color2;
			}
		}
	}
}
