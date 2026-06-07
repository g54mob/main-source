using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Input;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Switch")]
	public class CockpitSwitchData : PartModifierData
	{
		public enum CockpitSwitchStyle
		{
			Default = 0,
			Flip = 1,
			Rocker = 2,
			Pivot = 3
		}

		public enum InteractionType
		{
			Toggle = 0,
			Continuous = 1,
			Once = 2
		}

		public class CockpitSwitchInput
		{
			public InteractionType DefaultInteractionType { get; }

			public string DefaultTooltip { get; }

			public string DisplayName { get; }

			public string InputId { get; }

			public CockpitSwitchInput(string inputId, InteractionType defaultInteractionType, string defaultTooltip = null)
			{
				InputId = inputId;
				DefaultInteractionType = defaultInteractionType;
				DisplayName = InputId.PascalCaseToDisplay();
				DefaultTooltip = defaultTooltip ?? DisplayName;
			}
		}

		public class StyleSettings
		{
			public float AngleOff = -30f;

			public float AngleOn = 30f;

			public Vector3 Axis = DefaultValues.Axis;

			public StyleSettings()
			{
			}

			public StyleSettings(XElement xml)
			{
				AngleOff = xml.GetFloatAttribute("angleOff", AngleOff);
				AngleOn = xml.GetFloatAttribute("angleOn", AngleOn);
				Axis = xml.GetVector3Attribute("axis", Axis);
			}
		}

		private static class DefaultValues
		{
			public const float AngleOff = -30f;

			public const float AngleOn = 30f;

			public const float SwitchPositionTransitionDelay = 0f;

			public const float SwitchPositionTransitionTime = 0.05f;

			public static readonly Vector3 Axis = Vector3.right;
		}

		private static List<CockpitSwitchInput> _inputs;

		private static Dictionary<string, CockpitSwitchInput> _inputsById;

		[SerializeField]
		private float _angleOff;

		[SerializeField]
		private float _angleOn;

		private CockpitSwitchInput _customInput;

		[SerializeField]
		private bool _disableTooltip;

		[SerializeField]
		private string _inputId;

		[DesignerPropertySpinner(-2.1474836E+09f, 2.1474836E+09f, 1f, Label = "Input", ExtraWidth = 75, WrapText = true, ShrinkText = true, Order = 10)]
		private int _inputSpinner;

		[SerializeField]
		private InteractionType? _interactionType;

		[SerializeField]
		private float _outputValue = 1f;

		[SerializeField]
		[DesignerPropertySpinner(0.05f, 1000f, 0.05f, Label = "Scale", Order = 50)]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { }, Label = "Style", Order = 20)]
		private CockpitSwitchStyle _style;

		private Dictionary<CockpitSwitchStyle, StyleSettings> _styleSettings;

		private StyleSettings _styleSettingsDefault = new StyleSettings();

		[SerializeField]
		private float _switchPositionTransitionDelay;

		[SerializeField]
		private float _switchPositionTransitionTime = 0.05f;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Tooltip", ExtraWidth = 45, Order = 15)]
		private string _tooltip;

		public float AngleOff => _angleOff;

		public float AngleOn => _angleOn;

		public Vector3 Axis => CurrentStyleSettings.Axis;

		public StyleSettings CurrentStyleSettings { get; private set; }

		public CockpitSwitchInput Input { get; private set; }

		public float OutputValue => _outputValue;

		public float Scale => _scale;

		public CockpitSwitchScript Script { get; private set; }

		public CockpitSwitchStyle Style => _style;

		public InteractionType SwitchInteractionType => _interactionType ?? Input?.DefaultInteractionType ?? InteractionType.Toggle;

		public float SwitchPositionTransitionDelay
		{
			get
			{
				return _switchPositionTransitionDelay;
			}
			set
			{
				_switchPositionTransitionDelay = value;
			}
		}

		public float SwitchPositionTransitionTime
		{
			get
			{
				return _switchPositionTransitionTime;
			}
			set
			{
				_switchPositionTransitionTime = value;
			}
		}

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

		protected List<CockpitSwitchInput> Inputs
		{
			get
			{
				if (_inputs == null)
				{
					_inputs = new List<CockpitSwitchInput>();
					GameInputs inputs = Game.Inputs;
					_inputs.Add(new CockpitSwitchInput(inputs.Activate1.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate2.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate3.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate4.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate5.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate6.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate7.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.Activate8.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput(inputs.LandingGear.Id, InteractionType.Toggle));
					_inputs.Add(new CockpitSwitchInput("None", InteractionType.Toggle, string.Empty));
				}
				return _inputs;
			}
		}

		protected Dictionary<string, CockpitSwitchInput> InputsById
		{
			get
			{
				if (_inputsById == null)
				{
					_inputsById = new Dictionary<string, CockpitSwitchInput>();
					foreach (CockpitSwitchInput input in Inputs)
					{
						_inputsById.Add(input.InputId, input);
					}
				}
				return _inputsById;
			}
		}

		public CockpitSwitchData(XElement element)
			: base(element)
		{
			_styleSettings = new Dictionary<CockpitSwitchStyle, StyleSettings>();
			foreach (XElement item in element.Elements("StyleSettings"))
			{
				string text = item.Attribute("style")?.Value;
				if (text != null && Enum.TryParse<CockpitSwitchStyle>(text, out var result))
				{
					_styleSettings.Add(result, new StyleSettings(item));
				}
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("inputId", Input?.InputId);
			xElement.SetAttributeValue("style", (_style == CockpitSwitchStyle.Default) ? ((CockpitSwitchStyle?)null) : new CockpitSwitchStyle?(_style));
			xElement.SetAttributeValue("scale", (_scale == 1f) ? ((float?)null) : new float?(_scale));
			xElement.SetAttributeValue("interactionType", _interactionType);
			xElement.SetAttributeValue("outputValue", (_outputValue == 1f) ? ((float?)null) : new float?(_outputValue));
			xElement.SetAttributeValue("tooltip", _tooltip);
			xElement.SetAttributeValue("disableTooltip", _disableTooltip ? new bool?(true) : ((bool?)null));
			xElement.SetAttributeValue("positionTransitionTime", (_switchPositionTransitionTime == 0.05f) ? ((float?)null) : new float?(_switchPositionTransitionTime));
			xElement.SetAttributeValue("positionTransitionDelay", (_switchPositionTransitionDelay == 0f) ? ((float?)null) : new float?(_switchPositionTransitionDelay));
			xElement.SetAttributeValue("angleOff", (_angleOff == CurrentStyleSettings.AngleOff) ? ((float?)null) : new float?(_angleOff));
			xElement.SetAttributeValue("angleOn", (_angleOn == CurrentStyleSettings.AngleOn) ? ((float?)null) : new float?(_angleOn));
			return xElement;
		}

		public override string GetGenericDesignerPropertySpinnerValueLabel(string propertyName, float spinnerValue)
		{
			if (!(propertyName == "_inputSpinner"))
			{
				if (propertyName == "_scale")
				{
					return Utilities.FormatPercentage(spinnerValue);
				}
				return base.GetGenericDesignerPropertySpinnerValueLabel(propertyName, spinnerValue);
			}
			return ConvertSpinnerValueToInput((int)spinnerValue).DisplayName;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<CockpitSwitchScript>();
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
			case "_scale":
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
				_style = stateElement.GetEnumAttribute("style", CockpitSwitchStyle.Default);
				_scale = ((float?)stateElement.Attribute("scale")) ?? _scale;
				UpdateStyleSettings();
				_interactionType = stateElement.GetEnumAttributeOrNull<InteractionType>("interactionType");
				_outputValue = ((float?)stateElement.Attribute("outputValue")) ?? 1f;
				_tooltip = (string)stateElement.Attribute("tooltip");
				_disableTooltip = (bool?)stateElement.Attribute("disableTooltip") == true;
				_switchPositionTransitionTime = ((float?)stateElement.Attribute("positionTransitionTime")) ?? _switchPositionTransitionTime;
				_switchPositionTransitionDelay = ((float?)stateElement.Attribute("positionTransitionDelay")) ?? _switchPositionTransitionDelay;
				_angleOff = ((float?)stateElement.Attribute("angleOff")) ?? CurrentStyleSettings.AngleOff;
				_angleOn = ((float?)stateElement.Attribute("angleOn")) ?? CurrentStyleSettings.AngleOn;
				if (InputsById.TryGetValue(_inputId, out var value))
				{
					Input = value;
					_inputSpinner = Inputs.IndexOf(value);
				}
				else
				{
					Input = (_customInput = new CockpitSwitchInput(_inputId, InteractionType.Continuous));
					_inputSpinner = Inputs.Count;
				}
			}
		}

		private CockpitSwitchInput ConvertSpinnerValueToInput(int spinnerValue)
		{
			List<CockpitSwitchInput> inputs = Inputs;
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
			bool num = _angleOff == CurrentStyleSettings.AngleOff;
			bool flag = _angleOn == CurrentStyleSettings.AngleOn;
			UpdateStyleSettings();
			if (num)
			{
				_angleOff = CurrentStyleSettings.AngleOff;
			}
			if (flag)
			{
				_angleOn = CurrentStyleSettings.AngleOn;
			}
			Script.OnStyleChanged(_style);
		}

		private void UpdateStyleSettings()
		{
			if (_styleSettings.TryGetValue(_style, out var value))
			{
				CurrentStyleSettings = value;
			}
			else
			{
				CurrentStyleSettings = _styleSettingsDefault;
			}
		}
	}
}
