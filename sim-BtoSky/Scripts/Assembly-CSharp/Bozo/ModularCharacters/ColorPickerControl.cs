using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bozo.ModularCharacters
{
	public class ColorPickerControl : MonoBehaviour
	{
		private class OutfitPickerSettings
		{
			public bool maintainColors;

			public int copyIndex;
		}

		[Header("Picker Dependencies")]
		public CharacterCreator creator;

		public SVImageControl svContoller;

		[Header("Picker")]
		public float currentHue;

		public float currentSat;

		public float currentVal;

		public float currentColor;

		[SerializeField]
		private RawImage hueImage;

		[SerializeField]
		private RawImage satValImage;

		[SerializeField]
		private RawImage outputImage;

		[SerializeField]
		private Slider hueSlider;

		private Texture2D hueTexture;

		private Texture2D svTexture;

		private Texture2D outputTexture;

		public OutfitBase colorObject;

		public OutfitType outfitType;

		public Material colorMaterial;

		public int MaterialSlot;

		[Header("Editor")]
		[SerializeField]
		private OutfitSystem outfitSystem;

		[SerializeField]
		private TMP_Text objectName;

		[SerializeField]
		private TMP_Text channelText;

		[SerializeField]
		private Image Swatch;

		[SerializeField]
		private TMP_Text CopyCatagoryText;

		public List<string> outfitTypes = new List<string>();

		private int copyIndex;

		[SerializeField]
		private TextureType mode;

		[SerializeField]
		private int currentChannel;

		[SerializeField]
		private int maxChannel;

		[SerializeField]
		private string[] channelNames;

		[Header("Decal Editor")]
		[SerializeField]
		private GameObject decalContainer;

		[SerializeField]
		private Slider DecalXSlider;

		[SerializeField]
		private Slider DecalYSlider;

		private Vector2 outfitDefaultDecalSize;

		[Header("Pattern Editor")]
		[SerializeField]
		private GameObject patternContainer;

		[SerializeField]
		private Slider patternXSlider;

		[SerializeField]
		private Slider patternYSlider;

		private Vector2 outfitDefaultPatternSize;

		[Header("Swatch Editor")]
		[SerializeField]
		private GameObject swatchParentContainer;

		[SerializeField]
		private Transform swatchContainer;

		[SerializeField]
		private SwatchSelector swatchSelectorObject;

		private List<SwatchSelector> swatchSelectors = new List<SwatchSelector>();

		[Header("AdvancedEditor")]
		[SerializeField]
		private TMP_Text hexValueTex;

		[SerializeField]
		private List<Color> HeldColors = new List<Color>();

		[SerializeField]
		private bool maintainColors;

		[SerializeField]
		private Toggle maintainColorsToggle;

		[SerializeField]
		private TMP_InputField inputR;

		[SerializeField]
		private TMP_InputField inputG;

		[SerializeField]
		private TMP_InputField inputB;

		[SerializeField]
		private TMP_InputField inputH;

		[SerializeField]
		private TMP_InputField inputS;

		[SerializeField]
		private TMP_InputField inputV;

		private Dictionary<OutfitType, OutfitPickerSettings> outfitPickerSettings = new Dictionary<OutfitType, OutfitPickerSettings>();

		private void Awake()
		{
			CreateHueImage();
			CreateSVImage();
			CreateOutputImage();
			UpdateOutputImage();
			OutfitType[] array = creator.outfitTypes;
			foreach (OutfitType outfitType in array)
			{
				outfitTypes.Add(outfitType.name);
			}
			CopyCatagoryText.text = outfitTypes[0];
			if (colorObject == null)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void CreateHueImage()
		{
			hueTexture = new Texture2D(1, 16);
			hueTexture.wrapMode = TextureWrapMode.Clamp;
			hueTexture.name = "HueTexture";
			for (int i = 0; i < hueTexture.height; i++)
			{
				hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / (float)hueTexture.height, 1f, 1f));
			}
			hueTexture.Apply();
			currentHue = 0f;
			hueImage.texture = hueTexture;
		}

		private void CreateSVImage()
		{
			svTexture = new Texture2D(16, 16);
			svTexture.wrapMode = TextureWrapMode.Clamp;
			svTexture.name = "SVTexture";
			for (int i = 0; i < svTexture.height; i++)
			{
				for (int j = 0; j < svTexture.width; j++)
				{
					svTexture.SetPixel(j, i, Color.HSVToRGB(currentHue, (float)j / (float)svTexture.width, (float)i / (float)svTexture.height));
				}
			}
			svTexture.Apply();
			currentSat = 0f;
			currentVal = 0f;
			satValImage.texture = svTexture;
		}

		private void CreateOutputImage()
		{
			outputTexture = new Texture2D(1, 16);
			outputTexture.wrapMode = TextureWrapMode.Clamp;
			outputTexture.name = "OutputTexture";
			Color color = Color.HSVToRGB(currentHue, currentSat, currentVal);
			for (int i = 0; i < hueTexture.height; i++)
			{
				outputTexture.SetPixel(0, 1, color);
			}
			outputTexture.Apply();
			currentHue = 0f;
			outputImage.texture = outputTexture;
		}

		private void UpdateOutputImage()
		{
			Color color = Color.HSVToRGB(currentHue, currentSat, currentVal);
			for (int i = 0; i < outputTexture.height; i++)
			{
				outputTexture.SetPixel(0, i, color);
			}
			inputR.text = ((int)(color.r * 255f)).ToString();
			inputG.text = ((int)(color.g * 255f)).ToString();
			inputB.text = ((int)(color.b * 255f)).ToString();
			inputH.text = currentHue.ToString("F2");
			inputS.text = currentSat.ToString("F2");
			inputV.text = currentVal.ToString("F2");
			string text = ColorUtility.ToHtmlStringRGB(color);
			hexValueTex.text = "#" + text;
			outputTexture.Apply();
			if ((bool)colorObject)
			{
				Swatch.color = color;
				SetColor(color, currentChannel);
				channelText.color = new Color(1f - currentVal, 1f - currentVal, 1f - currentVal, 1f);
				svContoller.setPickerPosition(currentSat, currentVal);
			}
		}

		public void SetSV(float S, float V)
		{
			currentSat = S;
			currentVal = V;
			UpdateOutputImage();
		}

		public void SetHSV(float H, float S, float V)
		{
			currentHue = H;
			currentSat = S;
			currentVal = V;
			UpdateOutputImage();
		}

		public void SetHSV()
		{
			float.TryParse(inputH.text, out currentHue);
			float.TryParse(inputS.text, out currentSat);
			float.TryParse(inputV.text, out currentVal);
			UpdateOutputImage();
		}

		public void SetRGB()
		{
			byte result = 0;
			byte.TryParse(inputR.text, out result);
			byte result2 = 0;
			byte.TryParse(inputG.text, out result2);
			byte result3 = 0;
			byte.TryParse(inputB.text, out result3);
			Color.RGBToHSV(new Color32(result, result2, result3, byte.MaxValue), out var H, out var S, out var V);
			SetHSV(H, S, V);
		}

		public void UpdateSVImage()
		{
			currentHue = hueSlider.value;
			for (int i = 0; i < svTexture.height; i++)
			{
				for (int j = 0; j < svTexture.width; j++)
				{
					svTexture.SetPixel(j, i, Color.HSVToRGB(currentHue, (float)j / (float)svTexture.width, (float)i / (float)svTexture.height));
				}
			}
			svTexture.Apply();
			UpdateOutputImage();
		}

		private void SetColor(Color color, int channel)
		{
			switch (mode)
			{
			case TextureType.Base:
				colorObject.SetColor(color, channel);
				break;
			case TextureType.Decal:
				maxChannel = 3;
				colorObject.SetDecalColor(color, channel);
				break;
			case TextureType.Pattern:
				maxChannel = 3;
				colorObject.SetPatternColor(color, channel);
				break;
			}
		}

		public void SetDecal(Texture texture, Color[] colors, Vector2 maxScale)
		{
			SwitchMode("Decal");
			colorObject.SetDecal(texture);
			for (int i = 0; i < colors.Length; i++)
			{
				SetColor(colors[i], i + 1);
			}
			if (maxScale.x < 0f)
			{
				DecalXSlider.gameObject.SetActive(value: false);
				DecalXSlider.maxValue = 1f;
				DecalXSlider.value = 1f;
			}
			else
			{
				DecalXSlider.gameObject.SetActive(value: true);
				DecalXSlider.maxValue = maxScale.x;
				DecalXSlider.value = 1f;
			}
			if (maxScale.y < 0f)
			{
				DecalYSlider.gameObject.SetActive(value: false);
				DecalYSlider.maxValue = 1f;
				DecalYSlider.value = 1f;
			}
			else
			{
				DecalYSlider.gameObject.SetActive(value: true);
				DecalYSlider.maxValue = maxScale.y;
				DecalYSlider.value = 1f;
			}
			SetDecalSize();
		}

		public void SetPattern(Texture texture, Color[] colors, Vector2 maxScale)
		{
			SwitchMode("Pattern");
			colorObject.SetPattern(texture);
			for (int i = 0; i < colors.Length; i++)
			{
				SetColor(colors[i], i + 1);
			}
			if (maxScale.x < 0f)
			{
				patternXSlider.gameObject.SetActive(value: false);
				patternXSlider.maxValue = 1f;
				patternXSlider.value = 1f;
			}
			else
			{
				patternXSlider.gameObject.SetActive(value: true);
				patternXSlider.maxValue = maxScale.x;
				patternXSlider.value = 1f;
			}
			if (maxScale.y < 0f)
			{
				patternYSlider.gameObject.SetActive(value: false);
				patternYSlider.maxValue = 1f;
				patternYSlider.value = 1f;
			}
			else
			{
				patternYSlider.gameObject.SetActive(value: true);
				patternYSlider.maxValue = maxScale.y;
				patternYSlider.value = 1f;
			}
			SetPatternSize();
		}

		public void ChangeSwatch(int value)
		{
			currentChannel += value;
			if (currentChannel > maxChannel)
			{
				currentChannel = 1;
			}
			if (currentChannel < 1)
			{
				currentChannel = maxChannel;
			}
			Color color = Color.black;
			switch (mode)
			{
			case TextureType.Base:
				color = colorObject.GetColor(currentChannel);
				break;
			case TextureType.Decal:
				color = colorObject.GetDecalColor(currentChannel);
				break;
			case TextureType.Pattern:
				color = colorObject.GetPatternColor(currentChannel);
				break;
			}
			Swatch.color = color;
			SetChannelName();
			Color.RGBToHSV(color, out var H, out var S, out var V);
			hueSlider.value = H;
			SetHSV(H, S, V);
			UpdateSVImage();
		}

		public void ChangeObject(OutfitBase ob)
		{
			if (!ob)
			{
				RemoveObject();
				return;
			}
			Outfit component = ob.GetComponent<Outfit>();
			if (maintainColors && !component.customShader && colorObject != null)
			{
				HeldColors = colorObject.GetColors();
				if (component.Type == outfitType)
				{
					for (int i = 0; i < HeldColors.Count; i++)
					{
						component.SetColor(HeldColors[i], i + 1);
					}
				}
			}
			channelNames = new string[1] { "Base" };
			outfitType = component.Type;
			mode = TextureType.Base;
			colorObject = ob;
			if (!this.outfitPickerSettings.ContainsKey(component.Type))
			{
				OutfitPickerSettings value = new OutfitPickerSettings();
				this.outfitPickerSettings.Add(component.Type, value);
			}
			OutfitPickerSettings outfitPickerSettings = this.outfitPickerSettings[component.Type];
			SetMaintainColors(outfitPickerSettings.maintainColors);
			SetCopyIndex(outfitPickerSettings.copyIndex);
			if (colorObject.customShader)
			{
				decalContainer.SetActive(value: false);
				patternContainer.SetActive(value: false);
				swatchParentContainer.SetActive(value: true);
				maxChannel = 1;
				foreach (SwatchSelector swatchSelector2 in swatchSelectors)
				{
					UnityEngine.Object.Destroy(swatchSelector2.gameObject);
				}
				swatchSelectors.Clear();
				for (int j = 0; j < component.outfitSwatches.Count; j++)
				{
					SwatchSelector swatchSelector = UnityEngine.Object.Instantiate(swatchSelectorObject, swatchContainer);
					swatchSelector.Init(this, component.outfitSwatches[j], j);
					swatchSelectors.Add(swatchSelector);
				}
			}
			else
			{
				Color color = colorObject.GetColor(1);
				color.a = 1f;
				currentChannel = 1;
				Swatch.color = color;
				decalContainer.SetActive(value: true);
				patternContainer.SetActive(value: true);
				channelNames = component.ColorChannels;
				if ((bool)component)
				{
					maxChannel = component.ColorChannels.Length;
					if (!component.supportDecals)
					{
						decalContainer.SetActive(value: false);
					}
					if (!component.supportPatterns)
					{
						patternContainer.SetActive(value: false);
					}
					swatchParentContainer.SetActive(value: false);
				}
				else
				{
					maxChannel = 9;
				}
				Vector4 decalSize = colorObject.GetDecalSize();
				DecalXSlider.value = decalSize.x;
				DecalYSlider.value = decalSize.y;
				Vector4 patternSize = colorObject.GetPatternSize();
				patternXSlider.value = patternSize.x;
				patternYSlider.value = patternSize.y;
			}
			SetChannelName();
			ChangeSwatch(0);
			objectName.text = colorObject.name.Replace("(Clone)", "");
			if (colorObject == null)
			{
				base.gameObject.SetActive(value: false);
			}
			else
			{
				base.gameObject.SetActive(value: true);
			}
		}

		public void SetDecalSize()
		{
			Vector2 vector = new Vector2(DecalXSlider.value, DecalYSlider.value);
			colorObject.SetDecalSize(vector);
		}

		public void SetPatternSize()
		{
			Vector2 patternSize = new Vector2(patternXSlider.value, patternYSlider.value);
			colorObject.SetPatternSize(patternSize);
		}

		public void RemoveObject()
		{
			colorObject = null;
			SetMaintainColors(value: false);
			base.gameObject.SetActive(value: false);
		}

		public void SetBaseTexture(int textureIndex)
		{
			colorObject.GetComponent<Outfit>().SetSwatch(textureIndex);
		}

		public void SwitchMode(string mode)
		{
			TextureType textureType = (TextureType)Enum.Parse(typeof(TextureType), mode);
			this.mode = textureType;
			switch (this.mode)
			{
			case TextureType.Base:
				ChangeObject(colorObject);
				break;
			case TextureType.Decal:
			{
				maxChannel = 3;
				channelText.text = "Decal 1/" + maxChannel;
				Color decalColor = colorObject.GetDecalColor(1);
				decalColor.a = 1f;
				currentChannel = 1;
				Swatch.color = decalColor;
				break;
			}
			case TextureType.Pattern:
			{
				maxChannel = 3;
				channelText.text = "Pattern 1/" + maxChannel;
				Color patternColor = colorObject.GetPatternColor(1);
				patternColor.a = 1f;
				currentChannel = 1;
				Swatch.color = patternColor;
				break;
			}
			}
		}

		public void ChangeCopyIndex(int value)
		{
			copyIndex += value;
			if (copyIndex > outfitTypes.Count - 1)
			{
				copyIndex = 0;
			}
			else if (copyIndex < 0)
			{
				copyIndex = outfitTypes.Count - 1;
			}
			CopyCatagoryText.text = outfitTypes[copyIndex];
			if (outfitType != null)
			{
				outfitPickerSettings[outfitType].copyIndex = copyIndex;
			}
		}

		public void SetCopyIndex(int value)
		{
			copyIndex = value;
			CopyCatagoryText.text = outfitTypes[copyIndex];
			outfitPickerSettings[outfitType].copyIndex = copyIndex;
		}

		public void CopyColor(OutfitBase copyOutfit)
		{
			OutfitBase outfitBase = colorObject;
			for (int i = 1; i < 9; i++)
			{
				copyOutfit.SetColor(outfitBase.GetColor(i), i);
			}
		}

		public void CopyColor()
		{
			OutfitBase outfitBase = colorObject;
			Outfit outfit = outfitSystem.GetOutfit(CopyCatagoryText.text);
			if (!(outfit == null))
			{
				for (int i = 1; i < 9; i++)
				{
					outfit.SetColor(outfitBase.GetColor(i), i);
				}
			}
		}

		public void SetColorByHex(string hex)
		{
			if (hex[0].ToString() != "#")
			{
				hex = "#" + hex;
			}
			if (ColorUtility.TryParseHtmlString(hex, out var color))
			{
				MonoBehaviour.print(color);
				Color.RGBToHSV(color, out var H, out var S, out var V);
				SetHSV(H, S, V);
			}
			else
			{
				Debug.LogWarning("Invalid hex string!");
			}
		}

		public void CopyHex()
		{
			GUIUtility.systemCopyBuffer = hexValueTex.text;
			MonoBehaviour.print("Copied HEX to Clipboard: " + hexValueTex.text);
		}

		public void SetChannelName()
		{
			string text = "";
			switch (mode)
			{
			case TextureType.Base:
				if (!colorObject.customShader && currentChannel - 1 < channelNames.Length)
				{
					text = channelNames[currentChannel - 1];
				}
				break;
			case TextureType.Decal:
				text = "Decal";
				break;
			case TextureType.Pattern:
				text = "Pattern";
				break;
			}
			channelText.text = text + " " + currentChannel + "/" + maxChannel;
		}

		public void SetMaintainColors(bool value)
		{
			if (value && colorObject != null)
			{
				HeldColors = colorObject.GetColors();
			}
			maintainColors = value;
			maintainColorsToggle.isOn = maintainColors;
			if (outfitType != null)
			{
				outfitPickerSettings[outfitType].maintainColors = maintainColors;
			}
		}
	}
}
