using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Input Controller")]
	public class InputControllerData : PartModifierData
	{
		public delegate void PropertyChangedHandler(InputControllerData source);

		public const string AileronInputId = "Aileron";

		[DesignerPropertyToggleButton(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 0, AllowFunkyInput = true)]
		private string _activationGroup;

		private InvertType _defaultInvertType;

		private bool _defaultZeroOnDeactivate;

		[DesignerPropertyToggleButton(new string[] { "Trim", "VTOL", "Throttle", "Brake", "Roll", "Aileron", "Pitch", "Yaw", "Flaps", "Disabled" }, Label = "Input", AllowFunkyInput = true, Order = 1)]
		private string _input;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Invert", Order = 3)]
		private bool _invert;

		private InputControllerScript _script;

		public string ActivationGroup
		{
			get
			{
				return _activationGroup;
			}
			set
			{
				_activationGroup = value;
			}
		}

		public string Input
		{
			get
			{
				return _input;
			}
			set
			{
				_input = value;
			}
		}

		public bool Invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
				this.InvertChanged?.Invoke(this);
			}
		}

		public bool InvertOnMirror { get; set; }

		public InvertType InvertType { get; private set; }

		public float MaxValue { get; set; }

		public float MinValue { get; set; }

		public string Name { get; set; }

		public string PropertyEditorDesc { get; set; }

		public bool ZeroOnDeactivate { get; set; }

		public event PropertyChangedHandler InvertChanged;

		public InputControllerData(XElement element)
			: base(element)
		{
			Name = element.GetStringAttribute("name", "none");
			_defaultZeroOnDeactivate = element.GetBoolAttribute("zeroOnDeactivate");
			ActivationGroup = element.GetStringAttribute("defaultActivationGroup", "0");
			Input = element.GetStringAttribute("defaultInput", GameInputs.Instance.Throttle.Id);
			MinValue = element.GetFloatAttribute("defaultMin");
			MaxValue = element.GetFloatAttribute("defaultMax", 1f);
			InvertOnMirror = element.GetBoolAttribute("invertOnMirror");
			PropertyEditorDesc = element.GetStringAttribute("propertyEditorDesc");
			if (element.GetStringAttribute("invertType") == "output")
			{
				InvertType = InvertType.Output;
			}
			else
			{
				InvertType = InvertType.Axis;
			}
			_defaultInvertType = InvertType;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			xElement.Add(new XAttribute("invert", Invert.ToString().ToLower()));
			xElement.Add(new XAttribute("min", MinValue.ToString()));
			xElement.Add(new XAttribute("max", MaxValue.ToString()));
			xElement.Add(new XAttribute("input", Input));
			if (ZeroOnDeactivate != _defaultZeroOnDeactivate)
			{
				xElement.Add(new XAttribute("zeroOnDeactivate", ZeroOnDeactivate));
			}
			if (_defaultInvertType != InvertType)
			{
				if (InvertType == InvertType.Output)
				{
					xElement.Add(new XAttribute("invertType", "output"));
				}
				else if (InvertType == InvertType.Axis)
				{
					xElement.Add(new XAttribute("invertType", "axis"));
				}
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_activationGroup" && value == "0")
			{
				return "None";
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "_invert" && InvertOnMirror)
			{
				return !(bool)sourceValue;
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("InputController");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			_script = gameObject.AddComponent<InputControllerScript>();
			_script.InputController = this;
			return _script;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			if (!string.IsNullOrEmpty(PropertyEditorDesc))
			{
				genericPartPropertiesScript.SetModifierHeaderText(PropertyEditorDesc);
			}
			else
			{
				genericPartPropertiesScript.SetModifierHeaderText("Input Controller");
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			ActivationGroup = stateElement.GetStringAttribute("activationGroup", ActivationGroup);
			Input = stateElement.GetStringAttribute("input", Input);
			Invert = stateElement.GetBoolAttribute("invert");
			MinValue = stateElement.GetFloatAttribute("min", MinValue);
			MaxValue = stateElement.GetFloatAttribute("max", MaxValue);
			ZeroOnDeactivate = stateElement.GetBoolAttribute("zeroOnDeactivate", _defaultZeroOnDeactivate);
			string stringAttribute = stateElement.GetStringAttribute("invertType");
			if (stringAttribute != null)
			{
				if (stringAttribute == "output")
				{
					InvertType = InvertType.Output;
				}
				else
				{
					InvertType = InvertType.Axis;
				}
			}
			XElement xElement = ((stateElement.Document != null) ? stateElement.Document.Root : null);
			int num = ((xElement != null && xElement.Name == "Aircraft") ? ((int?)xElement.Attribute("xmlVersion")).GetValueOrDefault() : 23);
			if (num < 5)
			{
				GameInputs instance = GameInputs.Instance;
				if (Input == instance.LandingGear.Id || Input == instance.FireGuns.Id || Input == instance.FireWeapons.Id)
				{
					if (Invert)
					{
						MaxValue = 0f;
					}
					else
					{
						MinValue = 0f;
					}
				}
			}
			if (num < 6 && Invert && Mathf.Abs(MinValue) != Mathf.Abs(MaxValue))
			{
				float minValue = MinValue;
				MinValue = MaxValue;
				MaxValue = minValue;
				Invert = false;
			}
		}
	}
}
