using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	[PartModifierDesignerHeader("Propellers")]
	public class PropellerAssemblyData : PartModifierData, ISelectPartPropertyModifier
	{
		public enum PitchControl
		{
			Auto = 0,
			Fixed = 1,
			Manual = 2
		}

		public const float MaxPitchDegrees = 40f;

		private const int MaxDesignerUIPitch = 90;

		private int _bladeBlurCount = 30;

		private float _bladeBlurSpread = 30f;

		[DesignerPropertySlider(2f, 8f, 7, Label = "Blade Count", Order = 21, Tooltip = "The number of propeller blades. More blades means more thrust given the same RPM, but also more drag and mass for the motor to spin.")]
		private int _bladeCount = 3;

		private float _chordRadiusRatio = 0.15f;

		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Blade Width", Order = 17, Tooltip = "The width (chord-length) of the propeller blades")]
		private float _chordScale = 1f;

		private float _defaultDiameter = 2f;

		private float _density = 2000f;

		private float _dragScalar = 1f;

		private IGenericPartProperties _genericPartPropertiesScript;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Hub Style", Order = 50)]
		private string _hub;

		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Hub Scale", Order = 51, Tooltip = "The scale of the propeller hub/cone")]
		private float _hubScale = 1f;

		private bool _isWaterProp;

		[DesignerPropertyPartId(Label = "Magic Engine", Order = 60, MustBeConnected = true, StartMessage = "Select an an engine, transmission, or gearbox to power this wheel.", NoOptionsMessage = "No engines are available for this wheel.", Tooltip = "Beams torque wirelessly from an engine/transmission/gearbox directly to this part. Ideal for when you need power but don't have the patience to connect drive shafts. Note: if a powertrain is physically connected to this part then it will not use magical torque beams.")]
		private int _magicEngineId;

		[DesignerPropertySlider(-90f, 90f, 181, Label = "Max Pitch", Order = 35, Tooltip = "In Fixed mode, this sets the constant blade angle. In Auto mode, this defines the maximum (coarse) pitch limit the governor can apply.")]
		private float _maxPitch;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Blade Control", Order = 30, Tooltip = "The pitch of the blades can either be fixed, automatically maintain a constant RPM, or controlled via an input controller during flight.")]
		private PitchControl _pitchControlType = PitchControl.Manual;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Blade Style", Order = 22)]
		private string _propeller;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Push Prop", Order = 22)]
		private bool _pushProp;

		private bool _refreshUI;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Reverse Blades", Order = 25, Tooltip = "Reverses the direction the propellers are facing as well.")]
		private bool _reverseBladeDirection;

		[DesignerPropertySlider(0.5f, 4f, 151, Label = "Diameter", Order = 15, Tooltip = "Changes the diameter of the propeller assembly")]
		private float _size = 1f;

		private float _thrustScalar = 1f;

		[DesignerPropertySlider(0f, 90f, 91, Label = "Twist Angle", Order = 20, Tooltip = "The amount of twist in the blade at the root.")]
		private float _twistAngleRoot = 30f;

		public float AutoMaxRpmPercent => 0.95f;

		public float AutoMinRpmPercent => 0.25f;

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

		public int BladeCount => _bladeCount;

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

		public float Diameter
		{
			get
			{
				return _defaultDiameter * _size;
			}
			set
			{
				_size = value / _defaultDiameter;
			}
		}

		public float DragScalar
		{
			get
			{
				return _dragScalar;
			}
			set
			{
				_dragScalar = value;
			}
		}

		public float HubMass => Mathf.Pow(HubScale * 0.1f * Radius, 2f) * _density * (float)((!IsManual) ? 1 : BladeCount);

		public PropellerPrefabs.HubPrefab HubPrefab { get; private set; }

		public float HubScale => _hubScale;

		public bool IsManual => _pitchControlType == PitchControl.Manual;

		public bool IsPushProp => _pushProp;

		public bool IsWaterProp => _isWaterProp;

		public int MagicEngineId => _magicEngineId;

		public override float Mass => (CalculateSingleBladeMass() * (float)BladeCount + HubMass) * 0.01f;

		public float MaxPitch
		{
			get
			{
				return _maxPitch;
			}
			set
			{
				_maxPitch = value;
			}
		}

		public float MaxPitchRate => 90f;

		public PitchControl PitchControlType
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

		public float PropellerPitchScale { get; internal set; } = 1f;

		public PropellerPrefabs.PropellerPrefab PropellerPrefab { get; private set; }

		public bool PropertiesOpen { get; private set; }

		public float Radius => Diameter * 0.5f;

		public bool ReverseBladeDirection
		{
			get
			{
				return _reverseBladeDirection;
			}
			set
			{
				_reverseBladeDirection = value;
			}
		}

		public float Scale => _size;

		public PropellerAssemblyScript Script { get; private set; }

		public float ThrustScalar
		{
			get
			{
				return _thrustScalar;
			}
			set
			{
				_thrustScalar = value;
			}
		}

		public float TwistAngleRoot => _twistAngleRoot;

		private PropellerPrefabs PropellerPrefabs => Game.Instance.CraftResourceData.PropellerPrefabs;

		public PropellerAssemblyData(XElement element)
			: base(element)
		{
			_bladeBlurCount = element.GetIntAttribute("bladeBlurCount", _bladeBlurCount);
			_bladeBlurSpread = element.GetFloatAttribute("bladeBlurSpread", _bladeBlurSpread);
		}

		public float CalculateSingleBladeMass()
		{
			float radius = Radius;
			float num = radius * _chordRadiusRatio * ChordScale;
			float num2 = 0.7f;
			float num3 = radius * num * num2;
			float num4 = 0.08f;
			float num5 = num * num4;
			return num3 * num5 * _density;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("bladeCount", _bladeCount);
			xElement.SetAttributeValue("chordRadiusRatio", _chordRadiusRatio);
			xElement.SetAttributeValue("chordScale", _chordScale);
			xElement.SetAttributeValue("defaultDiameter", _defaultDiameter);
			xElement.SetAttributeValue("density", _density);
			xElement.SetAttributeValue("dragScalar", _dragScalar);
			xElement.SetAttributeValue("hubScale", _hubScale);
			xElement.SetAttributeValue("isWaterProp", _isWaterProp);
			xElement.SetAttributeValue("maxPitch", _maxPitch);
			xElement.SetAttributeValue("pitchControlType", _pitchControlType);
			xElement.SetAttributeValue("reverseBladeDirection", _reverseBladeDirection);
			xElement.SetAttributeValue("size", _size);
			xElement.SetAttributeValue("thrustScalar", _thrustScalar);
			xElement.SetAttributeValue("bladeBlurCount", _bladeBlurCount);
			xElement.SetAttributeValue("bladeBlurSpread", _bladeBlurSpread);
			xElement.SetAttributeValue("twistAngleRoot", _twistAngleRoot);
			xElement.SetAttributeValue("pushProp", _pushProp);
			xElement.SetAttributeValue("propeller", PropellerPrefab.Id);
			xElement.SetAttributeValue("hub", HubPrefab.Id);
			if (_magicEngineId > 0)
			{
				xElement.Add(new XAttribute("magicEngineId", _magicEngineId));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_maxPitch":
			case "_twistAngleRoot":
				return Units.GetAngleString(sliderValue, 0);
			case "_size":
				return Diameter.Format(UnitType.TinyDistance);
			case "_hubScale":
			case "_chordScale":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_propeller")
			{
				return PropellerPrefab.name;
			}
			if (propertyName == "_hub")
			{
				return HubPrefab.name;
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			string name = property.Member.Name;
			if (name == "_maxPitch")
			{
				return () => _pitchControlType != PitchControl.Auto;
			}
			if (name == "_magicEngineId")
			{
				return () => !Script.IsConnectedToEngine;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "_reverseBladeDirection")
			{
				return !(bool)sourceValue;
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<PropellerAssemblyScript>();
			Script.Data = this;
			return Script;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshUI)
			{
				_refreshUI = false;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			_genericPartPropertiesScript = genericPartPropertiesScript;
			InitializeToggleButtonValues();
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_propeller")
			{
				PropellerPrefab = PropellerPrefabs.GetPropeller(_propeller);
				Script.RebuildPropellerAssembly(repositionConnectedParts: true);
				return;
			}
			if (propertyName == "_hub")
			{
				HubPrefab = PropellerPrefabs.GetHub(_hub);
				Script.RebuildPropellerAssembly(repositionConnectedParts: true);
				return;
			}
			if (propertyName == "_bladeCount")
			{
				Script.UpdateBladeCount();
				Designer.Instance.SetAircraftStructureChanged();
				return;
			}
			if (propertyName == "_maxPitch")
			{
				Script.UpdatePitchRepresentation();
				return;
			}
			if (propertyName == "_size")
			{
				Script.UpdateScale(repositionConnectedParts: true);
				Designer.Instance.SetAircraftStructureChanged();
				return;
			}
			switch (propertyName)
			{
			case "_size":
			case "_hubScale":
			case "_chordScale":
				Script.UpdateScale(repositionConnectedParts: true);
				Designer.Instance.SetAircraftStructureChanged();
				break;
			case "_pitchControlType":
				Script.SetPitchInputControllerVisibility(IsManual);
				UpdatePitchSlider();
				Script.UpdatePitchRepresentation();
				break;
			case "_reverseBladeDirection":
				Script.UpdatePropDirection();
				break;
			case "_twistAngleRoot":
			case "_pushProp":
				Script.RebuildPropellerAssembly(repositionConnectedParts: true);
				break;
			}
		}

		void ISelectPartPropertyModifier.OnPartSelectionToolClosed(string fieldName, PartData part)
		{
		}

		bool ISelectPartPropertyModifier.OnPartSelectionToolFilterPart(string fieldName, PartData part)
		{
			if (fieldName == "_magicEngineId")
			{
				return part.PartScript.GetModifierWithInterface<IMagicPowertrainSource>() != null;
			}
			return false;
		}

		public void RefreshDesignerUI()
		{
			_refreshUI = true;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_bladeCount = Mathf.Clamp(stateElement.GetIntAttribute("bladeCount", _bladeCount), 2, 16);
			_chordRadiusRatio = stateElement.GetFloatAttribute("chordRadiusRatio", _chordRadiusRatio);
			_chordScale = stateElement.GetFloatAttribute("chordScale", _chordScale);
			_defaultDiameter = stateElement.GetFloatAttribute("defaultDiameter", _defaultDiameter);
			_density = stateElement.GetFloatAttribute("density", _density);
			_dragScalar = stateElement.GetFloatAttribute("dragScalar", _dragScalar);
			_hubScale = stateElement.GetFloatAttribute("hubScale", _hubScale);
			_isWaterProp = stateElement.GetBoolAttribute("isWaterProp", _isWaterProp);
			_maxPitch = stateElement.GetFloatAttribute("maxPitch", _maxPitch);
			_pitchControlType = stateElement.GetEnumAttribute("pitchControlType", _pitchControlType);
			_reverseBladeDirection = stateElement.GetBoolAttribute("reverseBladeDirection", _reverseBladeDirection);
			_size = stateElement.GetFloatAttribute("size", _size);
			_thrustScalar = stateElement.GetFloatAttribute("thrustScalar", _thrustScalar);
			_bladeBlurCount = stateElement.GetIntAttribute("bladeBlurCount", _bladeBlurCount);
			_bladeBlurSpread = stateElement.GetFloatAttribute("bladeBlurSpread", _bladeBlurSpread);
			_twistAngleRoot = stateElement.GetFloatAttribute("twistAngleRoot", _twistAngleRoot);
			_pushProp = stateElement.GetBoolAttribute("pushProp", _pushProp);
			_magicEngineId = stateElement.GetIntAttribute("magicEngineId");
			string stringAttribute = stateElement.GetStringAttribute("propeller");
			PropellerPrefab = Game.Instance.CraftResourceData.PropellerPrefabs.GetPropeller(stringAttribute);
			_propeller = PropellerPrefab.Id;
			string stringAttribute2 = stateElement.GetStringAttribute("hub");
			HubPrefab = Game.Instance.CraftResourceData.PropellerPrefabs.GetHub(stringAttribute2);
			_hub = HubPrefab.Id;
		}

		private void InitializeToggleButtonValues()
		{
			if (_genericPartPropertiesScript != null)
			{
				ToggleButtonProperty property = _genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_propeller");
				property.ButtonAttribute.Values.Clear();
				property.ButtonAttribute.Values.AddRange(from x in PropellerPrefabs.Propellers
					orderby x.Id
					select x.Id);
				ToggleButtonProperty property2 = _genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_hub");
				property2.ButtonAttribute.Values.Clear();
				property2.ButtonAttribute.Values.AddRange(from x in PropellerPrefabs.Hubs
					orderby x.Id
					select x.Id);
			}
		}

		private void UpdatePitchSlider()
		{
		}
	}
}
