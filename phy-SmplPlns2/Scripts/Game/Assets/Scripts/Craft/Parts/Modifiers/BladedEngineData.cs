using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public abstract class BladedEngineData : EngineData
	{
		public enum ControlTypes
		{
			Auto = 0,
			Fixed = 1,
			Manual = 2
		}

		private enum EnabledDisabled
		{
			Enabled = 0,
			Disabled = 1
		}

		protected const string BladeCountFieldName = "_bladeCount";

		protected const string BladePitchFieldName = "_bladePitch";

		protected const string BladePitchScaleFieldName = "_bladePitchScale";

		protected const string BladeStyleFieldName = "_bladeStyle";

		protected const string ChordScaleFieldName = "_chordScale";

		protected const string DesignerPowerFieldName = "_designerPowerSliderValue";

		protected const string DiameterFieldName = "_diameter";

		protected const string PitchControlTypeFieldName = "_pitchControlType";

		protected const string ReverseRotationFieldName = "_reverseRotation";

		protected const string ThrottleGovernorEngagePercentFieldName = "_throttleGovernorEngagePercent";

		protected const string ThrottleGovernorFieldName = "_throttleGovernorDesignerToggle";

		private const float DefaultMaxDiameter = 3.81f;

		private const float DefaultMinDiameter = 1.27f;

		private int _bladeBlurCount = 30;

		private float _bladeBlurSpread = 30f;

		[DesignerPropertyToggleButton(new string[] { "2", "3", "4", "5", "6" }, Label = "Blade Count", Order = 4)]
		private int _bladeCount;

		[DesignerPropertySlider(-1f, 1f, 21, Label = "Neutral Pitch", Order = 8)]
		private float _bladePitch;

		[DesignerPropertySlider(1f, 3f, 19, Label = "Blade Thickness", Order = 3)]
		private float _chordScale;

		[DesignerPropertySlider(1f, 1f, 10, Label = "Engine Power", Order = 1)]
		private float _designerPowerSliderValue;

		[DesignerPropertySlider(1.27f, 3.81f, 101, Label = "Blade Diameter", Order = 2)]
		private float _diameter;

		[DesignerPropertyToggleButton(new string[] { "Auto", "Fixed", "Manual" }, Label = "Pitch Control", Order = 7)]
		private ControlTypes _pitchControlType;

		private ControlTypes _throttleControlType;

		[DesignerPropertyToggleButton(new string[] { "Enabled", "Disabled" }, Label = "Throttle Governor", Order = 10)]
		private EnabledDisabled _throttleGovernorDesignerToggle;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Engage At", Order = 11)]
		private float _throttleGovernorEngagePercent;

		public int BladeBlurCount
		{
			get
			{
				return _bladeBlurCount;
			}
			set
			{
				_bladeBlurCount = value;
			}
		}

		public float BladeBlurSpread
		{
			get
			{
				return _bladeBlurSpread;
			}
			set
			{
				_bladeBlurSpread = value;
			}
		}

		public int BladeCount
		{
			get
			{
				return _bladeCount;
			}
			set
			{
				_bladeCount = value;
			}
		}

		public abstract string BladeStyle { get; set; }

		public float ChordScale
		{
			get
			{
				return _chordScale;
			}
			set
			{
				_chordScale = value;
			}
		}

		public float DefaultPower { get; set; }

		public float Diameter
		{
			get
			{
				return _diameter;
			}
			set
			{
				RecalculateMaxRpm(value);
				_diameter = value;
			}
		}

		public bool FixedPitch { get; set; }

		public Vector3 HubHeadScale { get; private set; }

		public bool IsMaxRpmAModdedValue { get; private set; }

		public virtual float MaxDiameter => 3.81f;

		public float MaxPower { get; set; }

		public float MaxRpm { get; private set; }

		public virtual float MinDiameter => 1.27f;

		public float MinPower { get; set; }

		public override Type ModifierScriptType => typeof(BladedEngineScript);

		public ControlTypes PitchControlType
		{
			get
			{
				return _pitchControlType;
			}
			set
			{
				_pitchControlType = value;
			}
		}

		public float PropellerPitch
		{
			get
			{
				return _bladePitch;
			}
			set
			{
				_bladePitch = Mathf.Clamp(value, -1f, 1f);
			}
		}

		public abstract float PropellerPitchScale { get; set; }

		public abstract bool ReverseRotation { get; set; }

		public ControlTypes ThrottleControlType
		{
			get
			{
				return _throttleControlType;
			}
			set
			{
				_throttleControlType = value;
			}
		}

		public float ThrottleGovernorEngagePercent
		{
			get
			{
				return _throttleGovernorEngagePercent;
			}
			private set
			{
				_throttleGovernorEngagePercent = value;
			}
		}

		public event PropertyChanged<BladedEngineData> BladeCountChanged;

		public event PropertyChanged<BladedEngineData> BladePitchChanged;

		public event PropertyChanged<BladedEngineData> BladePitchScaleChanged;

		public event PropertyChanged<BladedEngineData> BladeStyleChanged;

		public event PropertyChanged<BladedEngineData> ChordScaleChanged;

		public event PropertyChanged<BladedEngineData> DiameterChanged;

		public event PropertyChanged<BladedEngineData> PitchControlTypeChanged;

		public event PropertyChanged<BladedEngineData> PowerChanged;

		public event PropertyChanged<BladedEngineData> ReverseRotationChanged;

		public event PropertyChanged<BladedEngineData> ThrottleGovernorEnabledChanged;

		public BladedEngineData(XElement element)
			: base(element)
		{
			MaxPower = float.Parse(element.Attribute("maxPower").Value);
			MinPower = float.Parse(element.Attribute("minPower").Value);
			DefaultPower = float.Parse(element.Attribute("defaultPower").Value);
			_bladeBlurCount = element.GetIntAttribute("bladeBlurCount", _bladeBlurCount);
			_bladeBlurSpread = element.GetFloatAttribute("bladeBlurSpread", _bladeBlurSpread);
		}

		public static float CalculateMaxEngineRpm(float bladeDiameter)
		{
			return 6000f * (1f / bladeDiameter);
		}

		public override XElement GenerateStateXml()
		{
			if (PitchControlType == ControlTypes.Auto)
			{
				PropellerPitchScale = 1f;
				PropellerPitch = 0f;
			}
			return new XElement(StateElementName, GenerateVariableState(), (AllowDisableSymmetry && base.SymmetryDisabled) ? new XAttribute("symmetryDisabled", base.SymmetryDisabled) : null, new XAttribute("power", base.Power.ToString()), IsMaxRpmAModdedValue ? new XAttribute("maxRpm", MaxRpm.ToString()) : null, new XAttribute("propellerCount", BladeCount.ToString()), new XAttribute("diameter", Diameter.ToString()), new XAttribute("chordScale", ChordScale.ToString()), new XAttribute("pitchControlType", PitchControlType.ToString()), new XAttribute("propellerPitch", PropellerPitch.ToString()), new XAttribute("propellerPitchScale", PropellerPitchScale.ToString()), new XAttribute("throttleControlType", ThrottleControlType.ToString()), (ThrottleControlType == ControlTypes.Auto) ? new XAttribute("throttleGovernorEngagePercent", _throttleGovernorEngagePercent.ToString()) : null, new XAttribute("reverseRotation", ReverseRotation.ToString()), new XAttribute("propellerType", BladeStyle), new XAttribute("hubHeadScale", HubHeadScale.ToXAttributeValue()), new XAttribute("bladeBlurCount", BladeBlurCount), new XAttribute("bladeBlurSpread", BladeBlurSpread));
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_designerPowerSliderValue":
				return $"{(int)ConvertNewtonsToHp(sliderValue)}HP";
			case "_chordScale":
				return $"{sliderValue:0.0}x";
			case "_diameter":
				return $"{((int)(sliderValue * 39.3701f)).ToString()}in";
			case "_bladePitch":
				if (sliderValue == 0f)
				{
					return "Neutral";
				}
				return $"{Mathf.RoundToInt(sliderValue * 100f)}%".ToString();
			case "_bladePitchScale":
				return $"{((int)(sliderValue * 100f)).ToString()}%";
			case "_throttleGovernorEngagePercent":
				return $"{((int)(sliderValue * 100f)).ToString()}%";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			return property.Member.Name switch
			{
				"_throttleGovernorDesignerToggle" => () => PitchControlType == ControlTypes.Manual, 
				"_throttleGovernorEngagePercent" => () => PitchControlType == ControlTypes.Manual && ThrottleControlType == ControlTypes.Auto, 
				"_bladePitch" => () => PitchControlType != ControlTypes.Auto, 
				"_bladePitchScale" => () => PitchControlType != ControlTypes.Auto, 
				_ => base.GetGenericDesignerPropertyVisibilityCallback(property), 
			};
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject(base.EngineType);
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			BladedEngineScript bladedEngineScript = AddBladedEngineModifier(gameObject);
			bladedEngineScript.Engine = this;
			gameObject.name = GetType().Name;
			bladedEngineScript.OnModifierInitialized();
			return bladedEngineScript;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			_designerPowerSliderValue = base.Power;
			_throttleGovernorDesignerToggle = ((ThrottleControlType != ControlTypes.Auto) ? EnabledDisabled.Disabled : EnabledDisabled.Enabled);
			ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_designerPowerSliderValue");
			property.SliderAttribute.MinValue = MinPower;
			property.SliderAttribute.MaxValue = MaxPower;
			property.SliderAttribute.NumberOfSteps = (int)((MaxPower - MinPower) / 50f) + 1;
			property.Value = (base.Power - MinPower) / (MaxPower - MinPower);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_chordScale":
				this.ChordScaleChanged?.Invoke(this);
				break;
			case "_designerPowerSliderValue":
				base.Power = _designerPowerSliderValue;
				this.PowerChanged?.Invoke(this);
				break;
			case "_diameter":
				RecalculateMaxRpm(_diameter);
				this.DiameterChanged?.Invoke(this);
				break;
			case "_bladeCount":
				this.BladeCountChanged?.Invoke(this);
				break;
			case "_bladeStyle":
				this.BladeStyleChanged?.Invoke(this);
				break;
			case "_reverseRotation":
				this.ReverseRotationChanged?.Invoke(this);
				break;
			case "_pitchControlType":
				this.PitchControlTypeChanged?.Invoke(this);
				break;
			case "_throttleGovernorDesignerToggle":
				_throttleControlType = ((_throttleGovernorDesignerToggle != EnabledDisabled.Enabled) ? ControlTypes.Manual : ControlTypes.Auto);
				this.ThrottleGovernorEnabledChanged?.Invoke(this);
				break;
			case "_bladePitch":
				this.BladePitchChanged?.Invoke(this);
				break;
			case "_bladePitchScale":
				this.BladePitchScaleChanged?.Invoke(this);
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			RestoreVariables(stateElement);
			base.SymmetryDisabled = AllowDisableSymmetry && stateElement.GetBoolAttribute("symmetryDisabled");
			base.Power = stateElement.GetFloatAttribute("power", DefaultPower);
			PropellerPitch = stateElement.GetFloatAttribute("propellerPitch");
			PropellerPitchScale = stateElement.GetFloatAttribute("propellerPitchScale", 1f);
			ChordScale = stateElement.GetFloatAttribute("chordScale", 0.5f);
			BladeCount = stateElement.GetIntAttribute("propellerCount", 2);
			Diameter = stateElement.GetFloatAttribute("diameter", 80f);
			ReverseRotation = stateElement.GetBoolAttribute("reverseRotation");
			ThrottleGovernorEngagePercent = stateElement.GetFloatAttribute("throttleGovernorEngagePercent");
			BladeStyle = stateElement.GetStringAttribute("propellerType", "Cessna");
			PitchControlType = stateElement.GetEnumAttribute("pitchControlType", ControlTypes.Auto);
			ThrottleControlType = stateElement.GetEnumAttribute("throttleControlType", ControlTypes.Manual);
			HubHeadScale = stateElement.GetVector3Attribute("hubHeadScale", Vector3.one);
			BladeBlurCount = stateElement.GetIntAttribute("bladeBlurCount", _bladeBlurCount);
			BladeBlurSpread = stateElement.GetFloatAttribute("bladeBlurSpread", _bladeBlurSpread);
			if (stateElement.Attribute("maxRpm") != null)
			{
				MaxRpm = stateElement.GetFloatAttribute("maxRpm", 2500f);
				IsMaxRpmAModdedValue = true;
			}
			else
			{
				MaxRpm = CalculateMaxEngineRpm(Diameter);
				IsMaxRpmAModdedValue = false;
			}
			_throttleGovernorDesignerToggle = ((ThrottleControlType != ControlTypes.Auto) ? EnabledDisabled.Disabled : EnabledDisabled.Enabled);
		}

		protected abstract BladedEngineScript AddBladedEngineModifier(GameObject gameObject);

		private static float ConvertNewtonsToHp(float newtons)
		{
			return newtons * 0.5f;
		}

		private void RecalculateMaxRpm(float diameter)
		{
			if (!IsMaxRpmAModdedValue)
			{
				MaxRpm = CalculateMaxEngineRpm(diameter);
			}
		}
	}
}
