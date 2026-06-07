using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Color Bands", "A planet modifier used to apply bands of color across a celestial body. This is typically used for gas giants.This modifier can manually define each color band, or it can define ranges for color bands and randomly generate the individual bands. Individual bands can still be manually tweaked after using the randomized bands approach.")]
	public class ColorBands : VertexDataCommonPassPlanetModifier, ICustomObjectInspectorModel
	{
		[Serializable]
		public class ColorBand : ICustomObjectInspectorModel
		{
			[SerializeField]
			public Color Color;

			[SerializeField]
			public int CoreWeight;

			[SerializeField]
			public int LowerBlendWeight;

			[SerializeField]
			public int UpperBlendWeight;

			public bool CreateGroup => false;

			public static ColorBand FromXElement(XElement xml)
			{
				ColorBand colorBand = new ColorBand();
				string[] array = (((string)xml.Attribute("color")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				Color color = default(Color);
				for (int i = 0; i < 4 && i < array.Length; i++)
				{
					if (DataIO.TryParseFloat(array[i], out var value))
					{
						color[i] = value;
					}
				}
				colorBand.Color = color;
				string[] array2 = (((string)xml.Attribute("weights")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length >= 1 && DataIO.TryParseInt(array2[0], out var value2))
				{
					colorBand.LowerBlendWeight = value2;
				}
				if (array2.Length >= 2 && DataIO.TryParseInt(array2[1], out value2))
				{
					colorBand.CoreWeight = value2;
				}
				if (array2.Length >= 3 && DataIO.TryParseInt(array2[2], out value2))
				{
					colorBand.UpperBlendWeight = value2;
				}
				return colorBand;
			}

			public void CreateModel(GroupModel model, IObjectInspector objectInspector)
			{
				TableRowModel tableRowModel = model.Add(new TableRowModel());
				tableRowModel.Add(new ColorModel(string.Empty, () => Color, delegate(Color x)
				{
					Color = x;
				}));
				tableRowModel.Add(new NumericInputModel(string.Empty, () => LowerBlendWeight, delegate(double x)
				{
					LowerBlendWeight = (int)x;
				})).Tooltip = "The lower blend weight of the band. This is the weight value used for blending half way to the band below it.";
				tableRowModel.Add(new NumericInputModel(string.Empty, () => CoreWeight, delegate(double x)
				{
					CoreWeight = (int)x;
				})).Tooltip = "The core weight of the band. This is the weight value used for the primary color only with no blending.";
				tableRowModel.Add(new NumericInputModel(string.Empty, () => UpperBlendWeight, delegate(double x)
				{
					UpperBlendWeight = (int)x;
				})).Tooltip = "The upper blend weight of the band. This is the weight value used for blending half way to the band above it.";
			}

			public XElement ToXElement()
			{
				return new XElement("ColorBand", new XAttribute("color", DataIO.ToString(Color.r) + "," + DataIO.ToString(Color.g) + "," + DataIO.ToString(Color.b) + "," + DataIO.ToString(Color.a)), new XAttribute("weights", DataIO.ToString(LowerBlendWeight) + "," + DataIO.ToString(CoreWeight) + "," + DataIO.ToString(UpperBlendWeight)));
			}
		}

		public class ColorBandItem
		{
			[SerializeField]
			public float BlendMax;

			[SerializeField]
			public float BlendMin;

			[SerializeField]
			public Color PrimaryColor;

			[SerializeField]
			public Color? SecondaryColor;

			public ColorBandItem(Color color)
			{
				PrimaryColor = color.linear;
				SecondaryColor = null;
				BlendMin = 1f;
				BlendMax = 1f;
			}

			public ColorBandItem(Color primary, Color secondary, float blendMin, float blendMax)
			{
				PrimaryColor = primary.linear;
				SecondaryColor = secondary.linear;
				BlendMin = blendMin;
				BlendMax = blendMax;
			}
		}

		[Serializable]
		public class RandomColorBandInput : ICustomObjectInspectorModel
		{
			[SerializeField]
			public Vector2i BandCountRange;

			[SerializeField]
			public Vector2i BlendWeightRange;

			[SerializeField]
			public Color Color;

			[SerializeField]
			public Vector2i CoreWeightRange;

			[SerializeField]
			public Vector3 HsvVariance;

			public bool CreateGroup => true;

			public static RandomColorBandInput FromXElement(XElement xml)
			{
				RandomColorBandInput randomColorBandInput = new RandomColorBandInput();
				string[] array = (((string)xml.Attribute("color")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				Color color = default(Color);
				for (int i = 0; i < 4 && i < array.Length; i++)
				{
					if (DataIO.TryParseFloat(array[i], out var value))
					{
						color[i] = value;
					}
				}
				randomColorBandInput.Color = color;
				randomColorBandInput.BandCountRange = (Vector2i)xml.Attribute("bandCount");
				randomColorBandInput.CoreWeightRange = (Vector2i)xml.Attribute("coreWeight");
				randomColorBandInput.BlendWeightRange = (Vector2i)xml.Attribute("blendWeight");
				randomColorBandInput.HsvVariance = Utilities.GetVectorAttribute(xml, "hsvVariance", Vector3.zero);
				return randomColorBandInput;
			}

			public void CreateModel(GroupModel model, IObjectInspector objectInspector)
			{
				model.AddAndBuild(new ColorModel("Color", () => Color, delegate(Color x)
				{
					Color = x;
				})).Build(delegate(ColorModel x)
				{
					x.Tooltip = "The base color of the color bands generated by this entry.";
				});
				model.AddAndBuild(new Vector3InputModel("HSV Variance", () => HsvVariance, delegate(Vector3 x)
				{
					HsvVariance = x;
				})).Build(delegate(Vector3InputModel x)
				{
					x.Tooltip = "The maximum HSV (Hue, Saturation, Value) color variance, relative to the base color, that is allowed in each random color band genereated by this entry.";
				});
				model.AddAndBuild(new Vector2IntInputModel("Band Count Range", () => BandCountRange, delegate(Vector2i x)
				{
					BandCountRange = x;
				})).Build(delegate(Vector2IntInputModel x)
				{
					x.Tooltip = "The minimum and maximum number of color bands to be generated by this input.";
				});
				model.AddAndBuild(new Vector2IntInputModel("Blend Weight Range", () => BlendWeightRange, delegate(Vector2i x)
				{
					BlendWeightRange = x;
				})).Build(delegate(Vector2IntInputModel x)
				{
					x.Tooltip = "The minimum and maximum blend weight for color bands generated by this input. Higher blend weights can result in larger areas of blending between two color bands. Lower blend weights result in sharper transitions between color bands.";
				});
				model.AddAndBuild(new Vector2IntInputModel("Core Weight Range", () => CoreWeightRange, delegate(Vector2i x)
				{
					CoreWeightRange = x;
				})).Build(delegate(Vector2IntInputModel x)
				{
					x.Tooltip = "The minimum and maximum core weight for color bands generated by this input. Higher core weights can result in larger areas non-blended color bands.";
				});
			}

			public XElement ToXElement()
			{
				return new XElement("RandomColorBand", new XAttribute("color", DataIO.ToString(Color.r) + "," + DataIO.ToString(Color.g) + "," + DataIO.ToString(Color.b) + "," + DataIO.ToString(Color.a)), new XAttribute("bandCount", BandCountRange.ToString()), new XAttribute("coreWeight", CoreWeightRange.ToString()), new XAttribute("blendWeight", BlendWeightRange.ToString()), new XAttribute("hsvVariance", Utilities.Vector3ToString(HsvVariance)));
			}
		}

		[SerializeField]
		private ColorBand[] _colorBands;

		private ColorBandItem[] _colorBandsLookup;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The input data value which identifies which color band(s) will be used. For gas giants, this is typically the y-coordinate on a Unit sphere.")]
		private int _dataIndex;

		private float _inputRange;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Max Input Value", Order = 10, Tooltip = "The maximum expected input value. This will be used, along with the minimum, to determine the expected range of the input data value in order to remap it into the zero to one range.")]
		private float _maxInputValue = 1f;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Min Input Value", Order = 0, Tooltip = "The minimum expected input value. This will be used, along with the maximum, to determine the expected range of the input data value in order to remap it into the zero to one range.")]
		private float _minInputValue = -1f;

		[SerializeField]
		private RandomColorBandInput[] _randomColorBandsInput;

		private int _totalWeight;

		public bool CreateGroup => false;

		public RandomColorBandInput[] RandomColorBandsInput
		{
			get
			{
				return _randomColorBandsInput;
			}
			set
			{
				_randomColorBandsInput = value;
			}
		}

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public ColorBands()
		{
			base.VisibleInBasicViewMode = true;
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			objectInspector.BuildModelForField(Utilities.GetField(() => _minInputValue), model, this);
			objectInspector.BuildModelForField(Utilities.GetField(() => _maxInputValue), model, this);
			model.Add(new TextButtonModel("Generate Color Bands", delegate
			{
				GenerateRandomBands();
				objectInspector.ForceRebuildModel();
			})).Style = ButtonModel.ButtonStyle.Primary;
			objectInspector.BuildModelForField(Utilities.GetField(() => _randomColorBandsInput), model, this, "Random Color Bands");
			objectInspector.BuildModelForField(Utilities.GetField(() => _colorBands), model, this);
		}

		public void GenerateRandomBands()
		{
			List<ColorBand> list = new List<ColorBand>();
			RandomColorBandInput[] randomColorBandsInput = _randomColorBandsInput;
			foreach (RandomColorBandInput randomColorBandInput in randomColorBandsInput)
			{
				Color.RGBToHSV(randomColorBandInput.Color, out var H, out var S, out var V);
				Vector3 hsvVariance = randomColorBandInput.HsvVariance;
				Func<float, float> func = Mathf.Clamp01;
				int num = UnityEngine.Random.Range(randomColorBandInput.BandCountRange.x, randomColorBandInput.BandCountRange.y + 1);
				for (int j = 0; j < num; j++)
				{
					list.Add(new ColorBand
					{
						Color = UnityEngine.Random.ColorHSV(func(H - hsvVariance.x), func(H + hsvVariance.x), func(S - hsvVariance.y), func(S + hsvVariance.y), func(V - hsvVariance.z), func(V + hsvVariance.z)),
						CoreWeight = UnityEngine.Random.Range(randomColorBandInput.CoreWeightRange.x, randomColorBandInput.CoreWeightRange.y + 1),
						LowerBlendWeight = UnityEngine.Random.Range(randomColorBandInput.BlendWeightRange.x, randomColorBandInput.BlendWeightRange.y + 1),
						UpperBlendWeight = UnityEngine.Random.Range(randomColorBandInput.BlendWeightRange.x, randomColorBandInput.BlendWeightRange.y + 1)
					});
				}
			}
			_colorBands = list.ToArray();
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			if (!data.DebugColorsOnly && _totalWeight > 0)
			{
				float num = (float)((data.Data[_dataIndex] - (double)_minInputValue) / (double)_inputRange * (double)_totalWeight);
				int num2 = Mathf.Clamp((int)num, 0, _colorBandsLookup.Length - 1);
				ColorBandItem colorBandItem = _colorBandsLookup[num2];
				if (colorBandItem.SecondaryColor.HasValue)
				{
					data.Color += Color.LerpUnclamped(colorBandItem.PrimaryColor, colorBandItem.SecondaryColor.Value, Mathf.LerpUnclamped(colorBandItem.BlendMin, colorBandItem.BlendMax, num - (float)num2));
				}
				else
				{
					data.Color += colorBandItem.PrimaryColor;
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			if (!data.CommonData.DebugColorsOnly && _totalWeight > 0)
			{
				float num = (float)((data.Data[_dataIndex] - (double)_minInputValue) / (double)_inputRange * (double)_totalWeight);
				int num2 = Mathf.Clamp((int)num, 0, _colorBandsLookup.Length - 1);
				ColorBandItem colorBandItem = _colorBandsLookup[num2];
				if (colorBandItem.SecondaryColor.HasValue)
				{
					data.Color += Color.LerpUnclamped(colorBandItem.PrimaryColor, colorBandItem.SecondaryColor.Value, Mathf.LerpUnclamped(colorBandItem.BlendMin, colorBandItem.BlendMax, num - (float)num2));
				}
				else
				{
					data.Color += colorBandItem.PrimaryColor;
				}
			}
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			if (_colorBands == null || _colorBands.Length == 0)
			{
				return;
			}
			_inputRange = _maxInputValue - _minInputValue;
			_colorBands[0].LowerBlendWeight = 0;
			_colorBands[_colorBands.Length - 1].UpperBlendWeight = 0;
			_totalWeight = 0;
			for (int i = 0; i < _colorBands.Length; i++)
			{
				ColorBand colorBand = _colorBands[i];
				_totalWeight += colorBand.LowerBlendWeight + colorBand.CoreWeight + colorBand.UpperBlendWeight;
			}
			_colorBandsLookup = new ColorBandItem[_totalWeight + 1];
			int num = 0;
			for (int j = 0; j < _colorBands.Length; j++)
			{
				ColorBand colorBand2 = _colorBands[j];
				if (colorBand2.LowerBlendWeight > 0)
				{
					float num2 = 0.5f / (float)colorBand2.LowerBlendWeight;
					for (int k = 0; k < colorBand2.LowerBlendWeight; k++)
					{
						_colorBandsLookup[num++] = new ColorBandItem(colorBand2.Color, _colorBands[j - 1].Color, 0.5f - (float)k * num2, 0.5f - (float)(k + 1) * num2);
					}
				}
				if (colorBand2.CoreWeight > 0)
				{
					ColorBandItem colorBandItem = new ColorBandItem(colorBand2.Color);
					for (int l = 0; l < colorBand2.CoreWeight; l++)
					{
						_colorBandsLookup[num++] = colorBandItem;
					}
				}
				if (colorBand2.UpperBlendWeight > 0)
				{
					float num3 = 0.5f / (float)colorBand2.UpperBlendWeight;
					for (int m = 0; m < colorBand2.UpperBlendWeight; m++)
					{
						_colorBandsLookup[num++] = new ColorBandItem(colorBand2.Color, _colorBands[j + 1].Color, (float)m * num3, (float)(m + 1) * num3);
					}
				}
			}
			_colorBandsLookup[_totalWeight] = _colorBandsLookup[_totalWeight - 1];
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndex", _dataIndex);
			xml.SetAttributeValue("minInputValue", _minInputValue);
			xml.SetAttributeValue("maxInputValue", _maxInputValue);
			XElement xElement = new XElement("ColorBands");
			if (_colorBands != null)
			{
				ColorBand[] colorBands = _colorBands;
				foreach (ColorBand colorBand in colorBands)
				{
					xElement.Add(colorBand.ToXElement());
				}
			}
			xml.Add(xElement);
			XElement xElement2 = new XElement("RandomColorBands");
			if (_randomColorBandsInput != null)
			{
				RandomColorBandInput[] randomColorBandsInput = _randomColorBandsInput;
				foreach (RandomColorBandInput randomColorBandInput in randomColorBandsInput)
				{
					xElement2.Add(randomColorBandInput.ToXElement());
				}
			}
			xml.Add(xElement2);
		}

		protected override void RestoreXml(XElement xml)
		{
			if (string.IsNullOrEmpty((string)xml.Attribute("pass")))
			{
				xml.SetAttributeValue("pass", VertexDataPlanetModifierPassType.Final);
			}
			base.RestoreXml(xml);
			_dataIndex = (int)xml.Attribute("dataIndex");
			_minInputValue = ((float?)xml.Attribute("minInputValue")) ?? (-1f);
			_maxInputValue = ((float?)xml.Attribute("maxInputValue")) ?? 1f;
			_colorBands = (from x in xml.Elements("ColorBands").Elements("ColorBand")
				select ColorBand.FromXElement(x)).ToArray();
			_randomColorBandsInput = (from x in xml.Elements("RandomColorBands").Elements("RandomColorBand")
				select RandomColorBandInput.FromXElement(x)).ToArray();
		}
	}
}
