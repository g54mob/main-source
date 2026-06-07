using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Label")]
	public class LabelData : PartModifierData
	{
		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 180f, NumberOfSteps = 181, Label = "Curvature", Order = 48)]
		private float _curvatureAngle;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Horizontal", "Vertical" }, Label = "Curve Direction", Order = 49)]
		private LabelCurvatureDirection _curvatureDirection;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Text", SupportsInputDialog = true, ExtraWidth = 50, Order = 10)]
		private string _designText = "Text";

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 1f, NumberOfSteps = 21, Label = "Emission Day", Order = 28)]
		private float _emissionDay;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 1f, NumberOfSteps = 21, Label = "Emission Night", Order = 29)]
		private float _emissionNight;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Default", "Roboto", "Military", "14-Segment", "Stencil" }, Label = "Font", Order = 15)]
		private string _fontName = "Default";

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 2.5f, NumberOfSteps = 49, Label = "Font Size", Order = 20)]
		private float _fontSize = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "None", "Vertical", "Horizontal", "Diagonal", "Upper Left", "Upper Right", "Lower Left", "Lower Right" }, Label = "Gradient", Order = 45)]
		private LabelPartGradientType _gradient;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.05f, MaxValue = 2.5f, NumberOfSteps = 50, Label = "Height", Order = 60)]
		private float _height = 0.5f;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Left", "Center", "Right" }, Label = "Horizontal Anchor", SilenceEnumCountMismatch = true, Order = 30)]
		private HorizontalAlignmentOptions _horizontalAlignment = HorizontalAlignmentOptions.Center;

		private Vector3 _offset = new Vector3(0f, 0.006f, 0f);

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 0.5f, NumberOfSteps = 51, Label = "Outline Width", Order = 25)]
		private float _outlineWidth;

		private int _paintIndexShift;

		private string _parentPath;

		private string _partTypeParentPath;

		private Vector3 _rotation = new Vector3(90f, 0f, 0f);

		private LabelScript _script;

		private bool _supportsCurvature = true;

		private bool _supportsGradient = true;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Top", "Middle", "Bottom" }, Label = "Vertical Anchor", SilenceEnumCountMismatch = true, Order = 40)]
		private VerticalAlignmentOptions _verticalAlignment = VerticalAlignmentOptions.Middle;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 5f, NumberOfSteps = 50, Label = "Width", Order = 50)]
		private float _width = 1f;

		public float CurvatureAngle => _curvatureAngle;

		public LabelCurvatureDirection CurvatureDirection => _curvatureDirection;

		public string DesignText => _designText;

		public float EmissionDay => _emissionDay;

		public float EmissionNight => _emissionNight;

		public string FontName => _fontName;

		public float FontSize => _fontSize;

		public LabelPartGradientType Gradient
		{
			get
			{
				if (!_supportsGradient)
				{
					return LabelPartGradientType.None;
				}
				return _gradient;
			}
		}

		public float Height => _height;

		public HorizontalAlignmentOptions HorizontalAlignment => _horizontalAlignment;

		public float OutlineWidth => _outlineWidth;

		public int PaintIndexShift => _paintIndexShift;

		public override float PerformanceCost
		{
			get
			{
				string designText = _designText;
				if (designText == null || !designText.Contains('{'))
				{
					return 0f;
				}
				return 25.2f;
			}
		}

		public int RenderQueueOffset { get; private set; }

		public bool SupportsGradient => _supportsGradient;

		public VerticalAlignmentOptions VerticalAlignment => _verticalAlignment;

		public float Width => _width;

		public LabelData(XElement element)
			: base(element)
		{
			_designText = element.GetStringAttribute("designText", "Text");
			_fontSize = element.GetFloatAttribute("fontSize", 1f);
			_width = element.GetFloatAttribute("width", 1f);
			_height = element.GetFloatAttribute("height", 0.5f);
			_partTypeParentPath = element.GetStringAttribute("parentPath", string.Empty);
			_parentPath = _partTypeParentPath;
			_offset = element.GetVector3Attribute("offset", new Vector3(0f, 0.006f, 0f));
			_rotation = element.GetVector3Attribute("rotation", new Vector3(90f, 0f, 0f));
			_supportsCurvature = element.GetBoolAttribute("supportsCurvature", defaultValue: true);
			_supportsGradient = element.GetBoolAttribute("supportsGradient", defaultValue: true);
			_paintIndexShift = element.GetIntAttribute("paintIndexShift");
			_horizontalAlignment = element.GetEnumAttribute("horizontalAlignment", HorizontalAlignmentOptions.Center);
			_verticalAlignment = element.GetEnumAttribute("verticalAlignment", VerticalAlignmentOptions.Middle);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("designText", _designText), new XAttribute("fontName", _fontName), new XAttribute("fontSize", _fontSize), new XAttribute("horizontalAlignment", _horizontalAlignment), new XAttribute("verticalAlignment", _verticalAlignment), new XAttribute("width", _width), new XAttribute("height", _height), new XAttribute("outlineWidth", _outlineWidth), new XAttribute("emissionDay", _emissionDay), new XAttribute("emissionNight", _emissionNight), new XAttribute("offset", _offset.ToXAttributeValue()), new XAttribute("rotation", _rotation.ToXAttributeValue()), (RenderQueueOffset == 0) ? null : new XAttribute("renderQueueOffset", RenderQueueOffset));
			if (_supportsGradient)
			{
				xElement.Add(new XAttribute("gradient", _gradient));
			}
			if (_supportsCurvature)
			{
				xElement.Add(new XAttribute("curvature", _curvatureAngle));
				xElement.Add(new XAttribute("curvatureDirection", _curvatureDirection));
			}
			if (_parentPath != _partTypeParentPath)
			{
				xElement.Add(new XAttribute("parentPath", _parentPath));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return propertyName switch
			{
				"_fontSize" => Utilities.FormatPercentage(sliderValue), 
				"_outlineWidth" => Utilities.FormatPercentage(sliderValue * 2f), 
				"_emissionDay" => Utilities.FormatPercentage(sliderValue), 
				"_emissionNight" => Utilities.FormatPercentage(sliderValue), 
				"_curvatureAngle" => sliderValue.ToString("0"), 
				"_height" => sliderValue.ToString("0.0#"), 
				_ => base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue), 
			};
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_curvatureAngle":
			case "_curvatureDirection":
				return () => _supportsCurvature;
			case "_gradient":
				return () => _supportsGradient;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Transform transform = parentGameObject.transform;
			if (!string.IsNullOrEmpty(_parentPath))
			{
				transform = transform.Find(_parentPath);
				if (transform == null)
				{
					transform = parentGameObject.transform;
					Debug.LogError($"Label on Part-{base.Part.Id} specifies invalid parent path.");
				}
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Craft/Parts/LabelText"), transform, worldPositionStays: false);
			gameObject.transform.localPosition = _offset;
			gameObject.transform.localRotation = Quaternion.Euler(_rotation);
			_script = gameObject.AddComponent<LabelScript>();
			_script.Initialize(this);
			return _script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_designText":
				UpdateText(value);
				break;
			case "_horizontalAlignment":
			case "_verticalAlignment":
				UpdateAlignment();
				break;
			case "_fontName":
				_script.OnFontChanged();
				break;
			case "_fontSize":
				_script.UpdateFontSize(_fontSize);
				break;
			case "_width":
			case "_height":
				_script.UpdateSize(_width, _height);
				break;
			case "_outlineWidth":
				_script.UpdateOutlineWidth(_outlineWidth);
				break;
			case "_emissionDay":
			case "_emissionNight":
				_script.UpdateEmission(_emissionDay, _emissionNight);
				break;
			case "_gradient":
				_script.OnApplyMaterials();
				break;
			case "_curvatureAngle":
			case "_curvatureDirection":
				_script.OnCurvatureChanged();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_designText = stateElement.GetStringAttribute("designText", _designText);
			_fontName = stateElement.GetStringAttribute("fontName", "Default");
			_fontSize = stateElement.GetFloatAttribute("fontSize", _fontSize);
			_horizontalAlignment = stateElement.GetEnumAttribute("horizontalAlignment", _horizontalAlignment);
			_verticalAlignment = stateElement.GetEnumAttribute("verticalAlignment", _verticalAlignment);
			_width = stateElement.GetFloatAttribute("width", _width);
			_height = stateElement.GetFloatAttribute("height", _height);
			_offset = stateElement.GetVector3Attribute("offset", _offset);
			_rotation = stateElement.GetVector3Attribute("rotation", _rotation);
			_outlineWidth = stateElement.GetFloatAttribute("outlineWidth");
			float floatAttribute = stateElement.GetFloatAttribute("emission");
			_emissionDay = stateElement.GetFloatAttribute("emissionDay", floatAttribute);
			_emissionNight = stateElement.GetFloatAttribute("emissionNight", floatAttribute);
			_gradient = stateElement.GetEnumAttribute("gradient", LabelPartGradientType.None);
			_curvatureAngle = stateElement.GetFloatAttribute("curvature");
			_curvatureDirection = stateElement.GetEnumAttribute("curvatureDirection", LabelCurvatureDirection.Horizontal);
			RenderQueueOffset = stateElement.GetIntAttribute("renderQueueOffset");
			_parentPath = stateElement.GetStringAttribute("parentPath", _partTypeParentPath);
		}

		private void UpdateAlignment()
		{
			_script.UpdateAlignment((TextAlignmentOptions)((int)_horizontalAlignment + (int)_verticalAlignment));
		}

		private void UpdateText(string value)
		{
			_script.UpdateText(value);
		}
	}
}
