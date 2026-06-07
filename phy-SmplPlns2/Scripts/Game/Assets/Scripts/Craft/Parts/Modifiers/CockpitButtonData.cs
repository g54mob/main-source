using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Input;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Button")]
	public class CockpitButtonData : PartModifierData
	{
		public enum CockpitButtonStyle
		{
			Rectangular = 0,
			Circular = 1
		}

		public enum InteractionType
		{
			Toggle = 0,
			Continuous = 1,
			Once = 2
		}

		public class CockpitButtonInput
		{
			public InteractionType DefaultInteractionType { get; }

			public string DefaultTooltip { get; }

			public string DisplayName { get; }

			public string InputId { get; }

			public CockpitButtonInput(string inputId, InteractionType defaultInteractionType, string defaultTooltip = null)
			{
				InputId = inputId;
				DefaultInteractionType = defaultInteractionType;
				DisplayName = InputId.PascalCaseToDisplay();
				DefaultTooltip = defaultTooltip ?? DisplayName;
			}
		}

		private static class DefaultValues
		{
			public const float ButtonLightTransitionDelay = 0f;

			public const float ButtonLightTransitionTime = 0.15f;

			public const float ButtonPositionTransitionDelay = 0f;

			public const float ButtonPositionTransitionTime = 0.15f;

			public const float DepthBase = 10f;

			public const float DepthOff = 10f;

			public const float DepthOn = 2f;

			public const float Height = 85f;

			public const float Padding = 10f;

			public const float Width = 85f;
		}

		private static List<CockpitButtonInput> _inputs;

		private static Dictionary<string, CockpitButtonInput> _inputsById;

		[SerializeField]
		private float _buttonLightTransitionDelay;

		[SerializeField]
		private float _buttonLightTransitionTime = 0.15f;

		[SerializeField]
		private float _buttonPositionTransitionDelay;

		[SerializeField]
		private float _buttonPositionTransitionTime = 0.15f;

		private CockpitButtonInput _customInput;

		[SerializeField]
		[DesignerPropertySpinner(0f, 2.1474836E+09f, 1f, Label = "Depth (Base)", AllowManualEntry = true, Order = 140)]
		private float _depthBase = 10f;

		[SerializeField]
		[DesignerPropertySpinner(1f, 2.1474836E+09f, 1f, Label = "Depth (Off)", AllowManualEntry = true, Order = 150)]
		private float _depthOff = 10f;

		[SerializeField]
		[DesignerPropertySpinner(1f, 2.1474836E+09f, 1f, Label = "Depth (On)", AllowManualEntry = true, Order = 160)]
		private float _depthOn = 2f;

		[SerializeField]
		private bool _disableTooltip;

		[SerializeField]
		[DesignerPropertySpinner(1f, 2.1474836E+09f, 1f, Label = "Height", AllowManualEntry = true, Order = 120)]
		private float _height = 85f;

		[SerializeField]
		private string _inputId;

		[DesignerPropertySpinner(-2.1474836E+09f, 2.1474836E+09f, 1f, Label = "Input", ExtraWidth = 75, WrapText = true, ShrinkText = true, Order = 10)]
		private int _inputSpinner;

		[SerializeField]
		private InteractionType? _interactionType;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 21, Label = "Light Strength", Order = 30)]
		private float _lightStrength = 1f;

		[SerializeField]
		private float _outputValue = 1f;

		[SerializeField]
		[DesignerPropertySpinner(0f, 2.1474836E+09f, 1f, Label = "Padding", AllowManualEntry = true, Order = 130)]
		private float _padding = 10f;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { }, Label = "Style", Order = 20)]
		private CockpitButtonStyle _style;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Tooltip", ExtraWidth = 45, Order = 15)]
		private string _tooltip;

		[SerializeField]
		[DesignerPropertySpinner(1f, 2.1474836E+09f, 1f, Label = "Width", AllowManualEntry = true, Header = "Button Sizes", Order = 110)]
		private float _width = 85f;

		public InteractionType ButtonInteractionType => _interactionType ?? Input?.DefaultInteractionType ?? InteractionType.Continuous;

		public float ButtonLightTransitionDelay
		{
			get
			{
				return _buttonLightTransitionDelay;
			}
			set
			{
				_buttonLightTransitionDelay = value;
			}
		}

		public float ButtonLightTransitionTime
		{
			get
			{
				return _buttonLightTransitionTime;
			}
			set
			{
				_buttonLightTransitionTime = value;
			}
		}

		public float ButtonPositionTransitionDelay
		{
			get
			{
				return _buttonPositionTransitionDelay;
			}
			set
			{
				_buttonPositionTransitionDelay = value;
			}
		}

		public float ButtonPositionTransitionTime
		{
			get
			{
				return _buttonPositionTransitionTime;
			}
			set
			{
				_buttonPositionTransitionTime = value;
			}
		}

		public float DepthBase => _depthBase;

		public float DepthOff => _depthOff;

		public float DepthOn => _depthOn;

		public float Height => _height;

		public CockpitButtonInput Input { get; private set; }

		public float LightStrength => _lightStrength;

		public float OutputValue => _outputValue;

		public float Padding => _padding;

		public CockpitButtonScript Script { get; private set; }

		public CockpitButtonStyle Style => _style;

		public string Tooltip
		{
			get
			{
				if (!_disableTooltip)
				{
					if (!string.IsNullOrWhiteSpace(_tooltip))
					{
						return _tooltip;
					}
					return Input.DefaultTooltip;
				}
				return null;
			}
		}

		public float Width => _width;

		protected List<CockpitButtonInput> Inputs
		{
			get
			{
				if (_inputs == null)
				{
					_inputs = new List<CockpitButtonInput>();
					GameInputs inputs = Game.Inputs;
					_inputs.Add(new CockpitButtonInput(inputs.Activate1.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate2.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate3.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate4.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate5.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate6.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate7.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.Activate8.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.LandingGear.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitButtonInput(inputs.FireGuns.Id, InteractionType.Continuous));
					_inputs.Add(new CockpitButtonInput(inputs.FireWeapons.Id, InteractionType.Continuous));
					_inputs.Add(new CockpitButtonInput(inputs.LaunchCountermeasures.Id, InteractionType.Continuous));
					_inputs.Add(new CockpitButtonInput(inputs.Brake.Id, InteractionType.Continuous));
					_inputs.Add(new CockpitButtonInput(inputs.Interact.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.CycleTargetingMode.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.NextTarget.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.PreviousTarget.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.NextWeapon.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.PreviousWeapon.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.TrimReset.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.MaxThrottle.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput(inputs.ZeroThrottle.Id, InteractionType.Once));
					_inputs.Add(new CockpitButtonInput("None", InteractionType.Toggle, string.Empty));
				}
				return _inputs;
			}
		}

		protected Dictionary<string, CockpitButtonInput> InputsById
		{
			get
			{
				if (_inputsById == null)
				{
					_inputsById = new Dictionary<string, CockpitButtonInput>();
					foreach (CockpitButtonInput input in Inputs)
					{
						_inputsById.Add(input.InputId, input);
					}
				}
				return _inputsById;
			}
		}

		public CockpitButtonData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("inputId", Input?.InputId);
			xElement.SetAttributeValue("style", _style);
			xElement.SetAttributeValue("lightStrength", _lightStrength);
			xElement.SetAttributeValue("interactionType", _interactionType);
			xElement.SetAttributeValue("outputValue", (_outputValue == 1f) ? ((float?)null) : new float?(_outputValue));
			xElement.SetAttributeValue("tooltip", _tooltip);
			xElement.SetAttributeValue("disableTooltip", _disableTooltip ? new bool?(true) : ((bool?)null));
			xElement.SetAttributeValue("lightTransitionTime", (_buttonLightTransitionTime == 0.15f) ? ((float?)null) : new float?(_buttonLightTransitionTime));
			xElement.SetAttributeValue("lightTransitionDelay", (_buttonLightTransitionDelay == 0f) ? ((float?)null) : new float?(_buttonLightTransitionDelay));
			xElement.SetAttributeValue("positionTransitionTime", (_buttonPositionTransitionTime == 0.15f) ? ((float?)null) : new float?(_buttonPositionTransitionTime));
			xElement.SetAttributeValue("positionTransitionDelay", (_buttonPositionTransitionDelay == 0f) ? ((float?)null) : new float?(_buttonPositionTransitionDelay));
			xElement.SetAttributeValue("height", (_height == 85f) ? ((float?)null) : new float?(_height));
			xElement.SetAttributeValue("width", (_width == 85f) ? ((float?)null) : new float?(_width));
			xElement.SetAttributeValue("padding", (_padding == 10f) ? ((float?)null) : new float?(_padding));
			xElement.SetAttributeValue("depthOff", (_depthOff == 10f) ? ((float?)null) : new float?(_depthOff));
			xElement.SetAttributeValue("depthOn", (_depthOn == 2f) ? ((float?)null) : new float?(_depthOn));
			xElement.SetAttributeValue("depthBase", (_depthBase == 10f) ? ((float?)null) : new float?(_depthBase));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_lightStrength")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override string GetGenericDesignerPropertySpinnerValueLabel(string propertyName, float spinnerValue)
		{
			if (propertyName == "_inputSpinner")
			{
				return ConvertSpinnerValueToInput((int)spinnerValue).DisplayName;
			}
			return base.GetGenericDesignerPropertySpinnerValueLabel(propertyName, spinnerValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<CockpitButtonScript>();
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_inputSpinner":
				Input = ConvertSpinnerValueToInput(_inputSpinner);
				break;
			case "_style":
				OnStyleChanged();
				break;
			case "_height":
			case "_width":
			case "_padding":
			case "_depthOff":
			case "_depthOn":
			case "_depthBase":
				OnSizeChanged();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement != null)
			{
				base.RestoreFromState(stateElement);
				_inputId = ((string)stateElement.Attribute("inputId")) ?? Game.Inputs.Activate1.Id;
				_style = stateElement.GetEnumAttribute("style", CockpitButtonStyle.Rectangular);
				_lightStrength = ((float?)stateElement.Attribute("lightStrength")) ?? 1f;
				_interactionType = stateElement.GetEnumAttributeOrNull<InteractionType>("interactionType");
				_outputValue = ((float?)stateElement.Attribute("outputValue")) ?? 1f;
				_tooltip = (string)stateElement.Attribute("tooltip");
				_disableTooltip = (bool?)stateElement.Attribute("disableTooltip") == true;
				_buttonLightTransitionTime = ((float?)stateElement.Attribute("lightTransitionTime")) ?? _buttonLightTransitionTime;
				_buttonLightTransitionDelay = ((float?)stateElement.Attribute("lightTransitionDelay")) ?? _buttonLightTransitionDelay;
				_buttonPositionTransitionTime = ((float?)stateElement.Attribute("positionTransitionTime")) ?? _buttonPositionTransitionTime;
				_buttonPositionTransitionDelay = ((float?)stateElement.Attribute("positionTransitionDelay")) ?? _buttonPositionTransitionDelay;
				_height = ((float?)stateElement.Attribute("height")) ?? _height;
				_width = ((float?)stateElement.Attribute("width")) ?? _width;
				_padding = ((float?)stateElement.Attribute("padding")) ?? _padding;
				_depthOff = ((float?)stateElement.Attribute("depthOff")) ?? _depthOff;
				_depthOn = ((float?)stateElement.Attribute("depthOn")) ?? _depthOn;
				_depthBase = ((float?)stateElement.Attribute("depthBase")) ?? _depthBase;
				if (InputsById.TryGetValue(_inputId, out var value))
				{
					Input = value;
					_inputSpinner = Inputs.IndexOf(value);
				}
				else
				{
					Input = (_customInput = new CockpitButtonInput(_inputId, InteractionType.Continuous));
					_inputSpinner = Inputs.Count;
				}
			}
		}

		private CockpitButtonInput ConvertSpinnerValueToInput(int spinnerValue)
		{
			List<CockpitButtonInput> inputs = Inputs;
			int num = inputs.Count + ((_customInput != null) ? 1 : 0);
			int num2 = spinnerValue % num;
			if (num2 < 0)
			{
				num2 += num;
			}
			if (num2 == inputs.Count)
			{
				return _customInput;
			}
			return inputs[num2];
		}

		private void OnSizeChanged()
		{
			Script.OnSizeChanged();
		}

		private void OnStyleChanged()
		{
			Script.OnStyleChanged(_style);
		}
	}
}
