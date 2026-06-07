using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Input.XR;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	[PartModifierDesignerHeader("Posed Grip")]
	public class PosedGripData : PartModifierData
	{
		public enum PreviewHand
		{
			None = 0,
			Left = 1,
			Right = 2
		}

		public class GripControlBinding
		{
			public const string PropertyNameAircraftControl = "_aircraftControl";

			[DesignerPropertyTextSpinner(new string[] { }, AllowManualEntry = true, ExtraWidth = 50, ShrinkText = true, WrapText = true)]
			private string _aircraftControl;

			public string AircraftControl
			{
				get
				{
					return _aircraftControl;
				}
				set
				{
					_aircraftControl = value;
				}
			}

			public bool AsButton { get; set; } = true;

			public string ControlPath { get; set; }

			public bool IsDefault => AircraftControl == "Default";

			public bool IsDisabled => AircraftControl == "Disabled";

			public bool IsValid
			{
				get
				{
					if (!string.IsNullOrEmpty(AircraftControl) && !string.IsNullOrEmpty(ControlPath))
					{
						return Processor != null;
					}
					return false;
				}
			}

			public string Processor { get; set; }

			public GripControlBinding(XElement xml)
			{
				AircraftControl = ((string)xml.Attribute("control")) ?? "Default";
				AsButton = ((bool?)xml.Attribute("asButton")) ?? true;
				ControlPath = (string)xml.Attribute("controlPath");
				Processor = ((string)xml.Attribute("processor")) ?? string.Empty;
			}

			public XElement Serialize()
			{
				if (IsValid)
				{
					return new XElement("ControlBinding", new XAttribute("control", AircraftControl), new XAttribute("asButton", AsButton), new XAttribute("controlPath", ControlPath), new XAttribute("processor", Processor));
				}
				return null;
			}
		}

		private static class XRControlGripTypeDescriptions
		{
			public const string Default = "Ungripped";

			public const string FlightStick = "Primary Grip";

			public const string Throttle = "Secondary Grip";
		}

		private static List<string> _aircraftControlSpinnerValues = new List<string> { "FireGuns", "FireWeapons", "LaunchCountermeasures", "PreviousWeapon", "NextWeapon", "PreviousTarget", "NextTarget", "CycleTargetingMode", "Disabled", "Default" };

		[DesignerPropertyClass(Order = 20)]
		private GripControlBinding[] _controlBindings = new GripControlBinding[0];

		[SerializeField]
		private bool _disableTooltip;

		[DesignerPropertyTextSpinner(new string[] { "Ungripped", "Primary Grip", "Secondary Grip" }, ExtraWidth = 50, ShrinkText = true, Label = "Control\nScheme", Order = 10)]
		private XRControlGripType _gripType;

		private Vector2? _screenAxisDeadzone;

		private Vector2? _screenAxisSize;

		private Vector3? _screenXPositionAxisMap;

		private Vector3? _screenXRotationAxisMap;

		private Vector3? _screenYPositionAxisMap;

		private Vector3? _screenYRotationAxisMap;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Tooltip", ExtraWidth = 30, Order = 30)]
		private string _tooltip;

		private string _tooltipDefault;

		public string[] ColliderPaths { get; set; } = new string[0];

		public GripControlBinding[] ControlBindings => _controlBindings;

		public string DefaultTooltip
		{
			get
			{
				if (_tooltipDefault == null)
				{
					ControlBaseData modifier = base.Part.GetModifier<ControlBaseData>();
					if (modifier != null)
					{
						List<string> list = new List<string>();
						ControlBaseScript.ControlAxis[] rotationAxes = modifier.RotationAxes;
						foreach (ControlBaseScript.ControlAxis controlAxis in rotationAxes)
						{
							if (!string.IsNullOrWhiteSpace(controlAxis.InputName))
							{
								list.Add(controlAxis.InputName);
							}
						}
						rotationAxes = modifier.MovementAxes;
						foreach (ControlBaseScript.ControlAxis controlAxis2 in rotationAxes)
						{
							if (!string.IsNullOrWhiteSpace(controlAxis2.InputName))
							{
								list.Add(controlAxis2.InputName);
							}
						}
						_tooltipDefault = string.Join("<br>", list);
					}
					else
					{
						_tooltipDefault = string.Empty;
					}
				}
				return _tooltipDefault;
			}
		}

		public string GripTargetPath { get; set; }

		public XRControlGripType GripType => _gripType;

		public bool HasScreenAxisMap { get; private set; }

		public Vector3 OutlineScale { get; }

		public string PoseName { get; set; }

		public PreviewHand PreviewPose { get; set; }

		public Vector2 ScreenAxisDeadzone => _screenAxisDeadzone ?? Vector2.zero;

		public Vector2 ScreenAxisSize => _screenAxisSize ?? new Vector2(0.15f, 0.15f);

		public Vector3 ScreenXPositionAxisMap => _screenXPositionAxisMap ?? Vector3.zero;

		public Vector3 ScreenXRotationAxisMap => _screenXRotationAxisMap ?? Vector3.zero;

		public Vector3 ScreenYPositionAxisMap => _screenYPositionAxisMap ?? Vector3.zero;

		public Vector3 ScreenYRotationAxisMap => _screenYRotationAxisMap ?? Vector3.zero;

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
					return DefaultTooltip;
				}
				return null;
			}
		}

		public float TooltipOffset { get; }

		public string TooltipTransformPath { get; }

		public PosedGripData(XElement element)
			: base(element)
		{
			_gripType = XRControlGripType.Default;
			OutlineScale = element.GetVector3Attribute("outlineScale", new Vector3(1.1f, 1.1f, 1.1f));
			TooltipTransformPath = (string)element.Attribute("tooltipTransformPath");
			TooltipOffset = ((float?)element.Attribute("tooltipOffset")) ?? 0.02f;
			if (element != null)
			{
				RestoreFromState(element);
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("pose", PoseName));
			xElement.Add(new XAttribute("gripTarget", GripTargetPath));
			xElement.Add(new XAttribute("gripType", GripType));
			xElement.Add(new XAttribute("colliders", string.Join(",", ColliderPaths)));
			xElement.Add(new XAttribute("previewPose", PreviewPose));
			xElement.SetAttributeValue("tooltip", _tooltip);
			xElement.SetAttributeValue("disableTooltip", _disableTooltip ? new bool?(true) : ((bool?)null));
			xElement.SetAttributeValue("screenXPositionAxisMap", (!_screenXPositionAxisMap.HasValue) ? null : _screenXPositionAxisMap.Value.ToXAttributeValue());
			xElement.SetAttributeValue("screenYPositionAxisMap", (!_screenYPositionAxisMap.HasValue) ? null : _screenYPositionAxisMap.Value.ToXAttributeValue());
			xElement.SetAttributeValue("screenXRotationAxisMap", (!_screenXRotationAxisMap.HasValue) ? null : _screenXRotationAxisMap.Value.ToXAttributeValue());
			xElement.SetAttributeValue("screenYRotationAxisMap", (!_screenYRotationAxisMap.HasValue) ? null : _screenYRotationAxisMap.Value.ToXAttributeValue());
			xElement.SetAttributeValue("screenAxisSize", (!_screenAxisSize.HasValue) ? null : _screenAxisSize.Value.ToXAttributeValue());
			xElement.SetAttributeValue("screenAxisDeadzone", (!_screenAxisDeadzone.HasValue) ? null : _screenAxisDeadzone.Value.ToXAttributeValue());
			for (int i = 0; i < ControlBindings.Length; i++)
			{
				if (ControlBindings[i].IsValid)
				{
					xElement.Add(ControlBindings[i].Serialize());
				}
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertyNameLabel(IConfigurableProperty property)
		{
			if (property.Member.Name == "_aircraftControl")
			{
				GripControlBinding gripControlBinding = (GripControlBinding)property.CurrentFieldTarget;
				if (gripControlBinding != null)
				{
					switch (gripControlBinding.ControlPath)
					{
					case "triggerPressed":
						return "Trigger";
					case "gripPressed":
						return "Grip";
					case "primaryButton":
						return "Button 1";
					case "secondaryButton":
						return "Button 2";
					case "thumbstickClicked":
						return "Thumbstick";
					case "joystickClicked":
						return "Joystick";
					case "touchpadClicked":
					case "touchpadClick":
						return "Touchpad";
					case "trackpadPressed":
					case "trackpadClicked":
						return "Trackpad";
					default:
						return gripControlBinding.ControlPath.PascalCaseToDisplay();
					}
				}
			}
			return base.GetGenericDesignerPropertyNameLabel(property);
		}

		public override string GetGenericDesignerPropertyTextSpinnerValueLabel(string propertyName, string spinnerValue)
		{
			if (propertyName == "_aircraftControl" && _aircraftControlSpinnerValues.Contains(spinnerValue))
			{
				return spinnerValue.PascalCaseToDisplay();
			}
			return base.GetGenericDesignerPropertyTextSpinnerValueLabel(propertyName, spinnerValue);
		}

		public override void GetGenericDesignerPropertyTextSpinnerValues(ITextSpinnerProperty textSpinnerProperty, List<string> values)
		{
			if (textSpinnerProperty.Member.Name == "_aircraftControl")
			{
				values.Clear();
				values.AddRange(_aircraftControlSpinnerValues);
			}
		}

		public override PartPropertyValueConverter GetGenericDesignerPropertyValueConverter(IConfigurableProperty property)
		{
			if (property.Member.Name == "_gripType")
			{
				return new PartPropertyValueConverter<XRControlGripType, string>((XRControlGripType gripType) => gripType switch
				{
					XRControlGripType.Default => "Ungripped", 
					XRControlGripType.FlightStick => "Primary Grip", 
					XRControlGripType.Throttle => "Secondary Grip", 
					_ => "Ungripped", 
				}, (string gripType) => gripType switch
				{
					"Ungripped" => XRControlGripType.Default, 
					"Primary Grip" => XRControlGripType.FlightStick, 
					"Secondary Grip" => XRControlGripType.Throttle, 
					_ => XRControlGripType.Default, 
				});
			}
			return base.GetGenericDesignerPropertyValueConverter(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			PosedGripScript posedGripScript = parentGameObject.transform.Find(GripTargetPath).gameObject.AddComponent<PosedGripScript>();
			posedGripScript.Initialize(this);
			return posedGripScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			PoseName = ((string)stateElement.Attribute("pose")) ?? PoseName;
			string text = (string)stateElement.Attribute("colliders");
			if (Enum.TryParse<PreviewHand>(((string)stateElement.Attribute("previewPose")) ?? string.Empty, out var result))
			{
				PreviewPose = result;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				ColliderPaths = text.Split(',');
			}
			GripTargetPath = ((string)stateElement.Attribute("gripTarget")) ?? GripTargetPath ?? "GripTargetDefault";
			_gripType = stateElement.GetEnumAttribute("gripType", GripType);
			_tooltip = (string)stateElement.Attribute("tooltip");
			_disableTooltip = (bool?)stateElement.Attribute("disableTooltip") == true;
			_screenXPositionAxisMap = stateElement.GetVector3AttributeOrNull("screenXPositionAxisMap") ?? _screenXPositionAxisMap;
			_screenYPositionAxisMap = stateElement.GetVector3AttributeOrNull("screenYPositionAxisMap") ?? _screenYPositionAxisMap;
			_screenXRotationAxisMap = stateElement.GetVector3AttributeOrNull("screenXRotationAxisMap") ?? _screenXRotationAxisMap;
			_screenYRotationAxisMap = stateElement.GetVector3AttributeOrNull("screenYRotationAxisMap") ?? _screenYRotationAxisMap;
			_screenAxisSize = stateElement.GetVector2AttributeOrNull("screenAxisSize") ?? _screenAxisSize;
			_screenAxisDeadzone = stateElement.GetVector2AttributeOrNull("screenAxisDeadzone") ?? _screenAxisDeadzone;
			HasScreenAxisMap = (_screenXPositionAxisMap.HasValue && _screenXPositionAxisMap != Vector3.zero) || (_screenYPositionAxisMap.HasValue && _screenYPositionAxisMap != Vector3.zero) || (_screenXRotationAxisMap.HasValue && _screenXRotationAxisMap != Vector3.zero) || (_screenYRotationAxisMap.HasValue && _screenYRotationAxisMap != Vector3.zero);
			XElement[] array = stateElement.Elements("ControlBinding").ToArray();
			_controlBindings = new GripControlBinding[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				_controlBindings[i] = new GripControlBinding(array[i]);
			}
		}
	}
}
