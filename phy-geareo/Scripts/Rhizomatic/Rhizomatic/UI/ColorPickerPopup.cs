using System;
using Rhizomatic.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic.UI
{
	public class ColorPickerPopup : PoolObject
	{
		public Transform panel;

		public InputFieldAdapter hexCode;

		public Image oldColor;

		public Transform colorsRoot;

		public Image preview;

		public SliderAdapter hue;

		public SliderAdapter saturation;

		public SliderAdapter value;

		public RawImage hueImage;

		public RawImage saturationImage;

		public RawImage brightnessImage;

		public RawImage sVImage;

		public SVController controller;

		public Color[] colors;

		private Texture2D hueTexture;

		private Texture2D saturationTexture;

		private Texture2D brightnessTexture;

		private Texture2D sVTexture;

		private Action<Color> onSubmit;

		private BackHandlerItem item;

		private float lastHue;

		protected override void OnCreated()
		{
		}

		protected override void OnSpawned()
		{
		}

		protected override void OnPooled()
		{
		}

		public void Setup(ColorPicker picker, Action<Color> onSubmit)
		{
		}

		private void OnValueChanged()
		{
		}

		public void BuildHueTexture()
		{
		}

		public void BuildSaturationTexture()
		{
		}

		public void BuildBrightnessTexture()
		{
		}

		public void BuildSVTexture()
		{
		}

		public void Submit()
		{
		}

		public void Cancel()
		{
		}

		public void UpdateView()
		{
		}

		public void Write(Color color)
		{
		}

		public Color Read()
		{
			return default(Color);
		}

		public void SetHexCodeText(Color color)
		{
		}
	}
}
