using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools.Serialization.Xml;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Debug Visualize (Data)", "A planet modifier used in debugging that helps visualize the values in one of the data channels")]
	public class DebugVisualize : VertexDataCommonPassPlanetModifier, ICustomObjectInspectorModel
	{
		private class Preset
		{
			public Gradient Gradient { get; }

			public float InputMax { get; }

			public float InputMin { get; }

			public string Name { get; }

			public Preset(string name, float inputMin, float inputMax, params (float Time, Color Color)[] gradientKeys)
			{
				Name = name;
				InputMin = inputMin;
				InputMax = inputMax;
				Gradient = new Gradient();
				Gradient.SetKeys(gradientKeys.Select(((float Time, Color Color) x) => new GradientColorKey(x.Color, x.Time)).ToArray(), new GradientAlphaKey[0]);
			}
		}

		private static List<Preset> _presets = new List<Preset>
		{
			new Preset("Custom", -1f, 1f),
			new Preset("Default", -1f, 1f, (0f, new Color(0.5f, 0.5f, 1f)), (0.1f, new Color(0f, 0f, 1f)), (0.35f, new Color(0f, 1f, 1f)), (0.5f, new Color(0f, 0f, 0f)), (0.65f, new Color(1f, 1f, 0f)), (0.9f, new Color(1f, 0f, 0f)), (1f, new Color(1f, 0.5f, 0.5f))),
			new Preset("Black & White", -1f, 1f, (0f, new Color(0f, 0f, 0f)), (1f, new Color(1f, 1f, 1f))),
			new Preset("Blue & Red 1", -1f, 1f, (0f, new Color(0f, 0f, 1f)), (0.5f, new Color(0f, 0f, 0f)), (1f, new Color(1f, 0f, 0f))),
			new Preset("Blue & Red 2", -1f, 1f, (0f, new Color(0.5f, 0.5f, 1f)), (0.25f, new Color(0f, 0f, 1f)), (0.5f, new Color(0.1f, 0f, 0.1f)), (0.75f, new Color(1f, 0f, 0f)), (1f, new Color(1f, 0.5f, 0.5f))),
			new Preset("Rainbow", -1f, 1f, (0f, new Color(0f, 0f, 0f)), (0.1f, new Color(0.5f, 0f, 1f)), (0.25f, new Color(0f, 0f, 1f)), (0.4f, new Color(0f, 1f, 1f)), (0.6f, new Color(0f, 1f, 0f)), (0.75f, new Color(1f, 1f, 0f)), (0.9f, new Color(1f, 0f, 0f)), (1f, new Color(1f, 0.5f, 0.5f)))
		};

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input", false, true, Tooltip = "The input data to visualize. This value will be linearly interpolated between the min and max values specified by this modifier, then color will be applied based on the specified gradient.")]
		private int _dataIndex;

		[SerializeField]
		[ColorUsage(false, true)]
		private Gradient _gradient;

		private Gradient _gradientLinear;

		private GradientModel _gradientModel;

		[SerializeField]
		private float _maxInputValue = 1f;

		[SerializeField]
		private float _minInputValue = -1f;

		private float _oneOverRange;

		private Preset _preset;

		private DropdownModel _presetDropdown;

		public bool CreateGroup => false;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			if (_preset == null)
			{
				_preset = _presets[0];
			}
			model.AddAndBuild(_presetDropdown = new DropdownModel("Preset", () => _preset.Name, OnPresetChanged, _presets.Select((Preset x) => x.Name))).Build(delegate(DropdownModel x)
			{
				x.Tooltip = "An option to choose from a few preset color gradients, rather than building your own custom color gradient.";
			});
			model.AddAndBuild(new FloatInputModel("Min Input Value", () => _minInputValue, delegate(float x)
			{
				_minInputValue = x;
			})).Build(delegate(FloatInputModel x)
			{
				x.ValueChangedByUserInput += OnInputValueChanged;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The minimum value of the input. This is used to create the range of values to be represented by the color gradient.";
			});
			model.AddAndBuild(new FloatInputModel("Max Input Value", () => _maxInputValue, delegate(float x)
			{
				_maxInputValue = x;
			})).Build(delegate(FloatInputModel x)
			{
				x.ValueChangedByUserInput += OnInputValueChanged;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The maximum value of the input. This is used to create the range of values to be represented by the color gradient.";
			});
			model.AddAndBuild(_gradientModel = new GradientModel("Color", () => _gradient, OnGradientValueChanged, hasAlpha: false, allowHDR: true)).Build(delegate(GradientModel x)
			{
				x.Tooltip = "The color gradient to apply. Values at the min value or below will use the color to the left of the gradient. Values at the max value or beyond will use the color to the right of the gradient. Values in-between will be linearly interpolated on the color gradient.";
			});
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Color = _gradientLinear.Evaluate(((float)data.Data[_dataIndex] - _minInputValue) * _oneOverRange);
			data.DebugColorsOnly = true;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Color = _gradientLinear.Evaluate(((float)data.Data[_dataIndex] - _minInputValue) * _oneOverRange);
			data.CommonData.DebugColorsOnly = true;
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			float num = _maxInputValue - _minInputValue;
			_oneOverRange = ((num == 0f) ? 0f : (1f / num));
		}

		public override void OnCreatedInPlanetStudio(VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatedInPlanetStudio(parentModifier);
			OnPresetChanged(_presets[1].Name);
			_dataIndex = (parentModifier?.GetDataSlots().FirstOrDefault(delegate(DataSlotField x)
			{
				DataSlotAttribute attribute = x.Attribute;
				return attribute != null && attribute.DataSlotType == DataSlotType.Output && x.DataIndex >= 0;
			})?.DataIndex).GetValueOrDefault();
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndex", _dataIndex);
			if (_preset == null || _preset == _presets[0])
			{
				xml.SetAttributeValue("minInputValue", _minInputValue);
				xml.SetAttributeValue("maxInputValue", _maxInputValue);
				UnityXmlSerializer unityXmlSerializer = new UnityXmlSerializer();
				if (_gradient != null)
				{
					xml.Add(unityXmlSerializer.Serialize(_gradient));
				}
			}
			else
			{
				xml.SetAttributeValue("preset", _preset.Name);
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndex = (int)xml.Attribute("dataIndex");
			string presetName = (string)xml.Attribute("preset");
			_preset = _presets.FirstOrDefault((Preset x) => x.Name == presetName);
			if (_preset == null || _preset == _presets[0])
			{
				_preset = _presets[0];
				_minInputValue = ((float?)xml.Attribute("minInputValue")) ?? (-1f);
				_maxInputValue = ((float?)xml.Attribute("maxInputValue")) ?? 1f;
				UnityXmlSerializer unityXmlSerializer = new UnityXmlSerializer();
				XElement xElement = xml.Element("Gradient");
				if (xElement != null)
				{
					_gradient = unityXmlSerializer.Deserialize<Gradient>(xElement);
				}
				else
				{
					_gradient = new Gradient();
				}
			}
			else
			{
				_minInputValue = _preset.InputMin;
				_maxInputValue = _preset.InputMax;
				_gradient = _preset.Gradient.Clone();
			}
			_gradientLinear = _gradient.ToLinear();
		}

		private void OnGradientValueChanged(Gradient value)
		{
			_gradient = value;
			_preset = _presets[0];
		}

		private void OnInputValueChanged(ItemModel model, string name, bool finished)
		{
			_preset = _presets[0];
		}

		private void OnPresetChanged(string value)
		{
			_preset = _presets.FirstOrDefault((Preset x) => x.Name == value);
			if (_preset != null && _preset.Name != "Custom")
			{
				_minInputValue = _preset.InputMin;
				_maxInputValue = _preset.InputMax;
				_gradient = _preset.Gradient.Clone();
			}
			_gradientModel.UpdatePreview = true;
		}
	}
}
