using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.CraftResourceData;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	[PartModifierDesignerHeader("Wheel")]
	public class JWheelData : PartModifierData, IModifierWithOutputs, ISelectPartPropertyModifier
	{
		private const float DefaultSize = 1.25f;

		private const float DefaultWidth = 1f;

		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Brake Torque", Order = 35)]
		private float _brakeTorque = 1f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Duals", Order = 6, Tooltip = "I think I'm seeing double.")]
		private bool _duals;

		[DesignerPropertySlider(0f, 10f, 101, Label = "Friction Circle Power", Order = 101)]
		private float _frictionCirclePower = 3f;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Friction Circle Strength", Order = 100, Header = "Experimental", HeaderCollapsed = true)]
		private float _frictionCircleStrength;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Friction Force Point", Order = 105)]
		private float _frictionForcePoint;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Friction Preset", Order = 52, Tooltip = "Selects the tire friction model for paved surfaces. 'Arcade' provides stable, forgiving grip, while 'Racing' offers more realistic handling. Note: This setting does not affect off-road handling.")]
		private string _frictionPreset = "Racing";

		private IGenericPartProperties _genericPartPropertiesScript;

		[DesignerPropertyPartId(Label = "Magic Engine", Order = 23, MustBeConnected = true, StartMessage = "Select an an engine, transmission, or gearbox to power this wheel.", NoOptionsMessage = "No engines are available for this wheel.", Tooltip = "Beams torque wirelessly from an engine/transmission/gearbox directly to this part. Ideal for when you need power but don't have the patience to connect drive shafts. Note: if a powertrain is physically connected to this part then it will not use magical torque beams.")]
		private int _magicEngineId;

		private bool _refreshUI;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Reverse Direction", Order = 25, Tooltip = "Reverse the direction the wheel should spin when powered.")]
		private bool _reversedDirection;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Rim Style", Order = 5)]
		private string _rim;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Rim Offset", Order = 5)]
		private float _rimOffset = 0.5f;

		[DesignerPropertySlider(0.5f, 5f, 91, Label = "Tire Diameter", Order = 0)]
		private float _size = 1.25f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Tire Style", Order = 3, Tooltip = "Racing has the best traction on roads, Offroad has the best traction off the roads, and Street is somewhere in between.")]
		private TireCategory _tireStyle;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Tread", Order = 4, Tooltip = "Purely cosmetic. It doesn't affect traction but it does affect how you feel about your tires.")]
		private string _tireTread;

		[DesignerPropertySlider(0.5f, 1.25f, 16, Label = "Forward Traction", Order = 50, Header = "Traction")]
		private float _tractionForward = 1f;

		[DesignerPropertySlider(0.5f, 1.25f, 16, Label = "Sideways Traction", Order = 51)]
		private float _tractionSideways = 1f;

		[DesignerPropertySlider(0f, 45f, 10, Label = "Turning Angle", Order = 20, Header = "Control")]
		private float _turningAngle;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Turning Angle Dampening", Order = 21, Tooltip = "Reduces the turning angle as speed increases.")]
		private float _turningAngleDampening;

		[DesignerPropertySlider(0.5f, 1.5f, 21, Label = "Width", Order = 1)]
		private float _width = 1f;

		public float BrakeTorque => _brakeTorque;

		public bool Duals => _duals;

		public float FrictionCirclePower => _frictionCirclePower;

		public float FrictionCircleStrength => _frictionCircleStrength;

		public float FrictionForcePoint => _frictionForcePoint;

		public WheelPrefabs.FrictionPreset FrictionPreset { get; private set; }

		public bool HideRims { get; private set; }

		public int MagicEngineId => _magicEngineId;

		public override float Mass => base.Mass;

		public Type ModifierScriptType => typeof(JWheelScript);

		public Vector4? Pacejka { get; private set; }

		public float Radius => _size * 0.25f;

		public bool ReversedDirection
		{
			get
			{
				return _reversedDirection;
			}
			set
			{
				_reversedDirection = value;
			}
		}

		public float RimOffset => _rimOffset;

		public WheelPrefabs.RimPrefab RimPrefab { get; private set; }

		public JWheelScript Script { get; private set; }

		public float SingleWidth => _width * _size * 0.2f;

		public WheelPrefabs.TirePrefab TirePrefab { get; private set; }

		public float TotalWidth => SingleWidth * (Duals ? 2f : 1f);

		public float TractionForward => _tractionForward;

		public float TractionSideways => _tractionSideways;

		public float TurningAngle
		{
			get
			{
				if (!_duals)
				{
					return _turningAngle;
				}
				return 0f;
			}
		}

		public float TurningAngleDampening => _turningAngleDampening;

		public float TurningRate { get; private set; }

		public float WidthPercentage => _width;

		private WheelPrefabs WheelPrefabs => Game.Instance.CraftResourceData.WheelPrefabs;

		public JWheelData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("turningAngle", _turningAngle));
			xElement.Add(new XAttribute("turningAngleDampening", _turningAngleDampening));
			xElement.Add(new XAttribute("reversed", _reversedDirection));
			xElement.Add(new XAttribute("size", _size));
			xElement.Add(new XAttribute("width", _width));
			xElement.Add(new XAttribute("duals", _duals));
			xElement.Add(new XAttribute("tire", TirePrefab.Id));
			xElement.Add(new XAttribute("rim", RimPrefab.Id));
			xElement.Add(new XAttribute("rimOffset", _rimOffset));
			xElement.Add(new XAttribute("turningRate", TurningRate));
			xElement.Add(new XAttribute("frictionCircleStrength", _frictionCircleStrength));
			xElement.Add(new XAttribute("frictionCirclePower", _frictionCirclePower));
			if (HideRims)
			{
				xElement.Add(new XAttribute("hideRims", HideRims));
			}
			xElement.Add(new XAttribute("brake", _brakeTorque));
			xElement.Add(new XAttribute("frictionPreset", FrictionPreset.id));
			xElement.Add(new XAttribute("tractionForward", _tractionForward));
			xElement.Add(new XAttribute("tractionSideways", _tractionSideways));
			xElement.Add(new XAttribute("forcePoint", _frictionForcePoint));
			if (Pacejka.HasValue)
			{
				xElement.Add(new XAttribute("pacejka", Pacejka.Value.ToXAttributeValue()));
			}
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
			case "_turningAngleDampening":
			case "_brakeTorque":
			case "_tractionForward":
			case "_tractionSideways":
			case "_frictionCircleStrength":
			case "_frictionForcePoint":
			case "_rimOffset":
				return Utilities.FormatPercentage(sliderValue);
			case "_width":
				return Utilities.FormatPercentage(sliderValue) + " (" + SingleWidth.Format(UnitType.TinyDistance, solo: false, longName: false, "#,###.0") + ")";
			case "_size":
				return Utilities.FormatPercentage(sliderValue) + " (" + (Radius * 2f).Format(UnitType.TinyDistance, solo: false, longName: false, "#,###.0") + ")";
			case "_turningAngle":
			{
				int num = (int)sliderValue;
				if (num == 0)
				{
					return "None";
				}
				return num + "°";
			}
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			return propertyName switch
			{
				"_rim" => RimPrefab.name, 
				"_tireTread" => TirePrefab.name, 
				"_tireStyle" => TirePrefab.category.ToString(), 
				"_frictionPreset" => FrictionPreset.name, 
				_ => base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value), 
			};
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_magicEngineId":
				return () => !Script.IsConnectedToEngine;
			case "_turningAngle":
			case "_turningAngleDampening":
				return () => !_duals;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "_reversedDirection")
			{
				return !(bool)sourceValue;
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<JWheelScript>();
			Script.Wheel = this;
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertiesClosed()
		{
			base.OnGenericDesignerPropertiesClosed();
			Script.EnableDesignerAnimation(enable: false);
		}

		public override void OnGenericDesignerPropertiesPartDeselected()
		{
			base.OnGenericDesignerPropertiesPartDeselected();
			Script.EnableDesignerAnimation(enable: false);
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
			Script.EnableDesignerAnimation(enable: true);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			switch (propertyName)
			{
			case "_turningAngle":
				Script.DesignerUpdateTurningAngle();
				break;
			case "_size":
			case "_width":
			case "_rim":
			case "_rimOffset":
			case "_reversedDirection":
			case "_tireStyle":
			case "_tireTread":
			case "_duals":
				switch (propertyName)
				{
				case "_rim":
					RimPrefab = WheelPrefabs.GetRim(_rim);
					break;
				case "_tireStyle":
					TirePrefab = WheelPrefabs.Tires.Where((WheelPrefabs.TirePrefab x) => x.category == _tireStyle).First();
					_tireTread = TirePrefab.Id;
					InitializeToggleButtonValues();
					_genericPartPropertiesScript?.RefreshUI();
					break;
				case "_tireTread":
					TirePrefab = WheelPrefabs.GetTire(_tireTread);
					break;
				}
				Script.RebuildWheel(async: false).Forget();
				switch (propertyName)
				{
				case "_size":
				case "_width":
				case "_duals":
					Designer.Instance.SetAircraftStructureChanged();
					break;
				}
				break;
			case "_frictionPreset":
				FrictionPreset = WheelPrefabs.GetFrictionPreset(_frictionPreset);
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
			_turningAngle = stateElement.GetFloatAttribute("turningAngle");
			_turningAngleDampening = stateElement.GetFloatAttribute("turningAngleDampening");
			_magicEngineId = stateElement.GetIntAttribute("magicEngineId");
			_reversedDirection = stateElement.GetBoolAttribute("reversed", _reversedDirection);
			_size = stateElement.GetFloatAttribute("size", 1.25f);
			_width = stateElement.GetFloatAttribute("width", 1f);
			_duals = stateElement.GetBoolAttribute("duals", _duals);
			_rimOffset = stateElement.GetFloatAttribute("rimOffset", _rimOffset);
			TurningRate = stateElement.GetFloatAttribute("turningRate", 150f);
			_frictionCircleStrength = Mathf.Clamp01(stateElement.GetFloatAttribute("frictionCircleStrength", _frictionCircleStrength));
			_frictionCirclePower = Mathf.Max(stateElement.GetFloatAttribute("frictionCirclePower", _frictionCirclePower), 1f);
			HideRims = stateElement.GetBoolAttribute("hideRims");
			string stringAttribute = stateElement.GetStringAttribute("tire");
			TirePrefab = Game.Instance.CraftResourceData.WheelPrefabs.GetTire(stringAttribute);
			_tireTread = TirePrefab.Id;
			_tireStyle = TirePrefab.category;
			string stringAttribute2 = stateElement.GetStringAttribute("rim");
			RimPrefab = Game.Instance.CraftResourceData.WheelPrefabs.GetRim(stringAttribute2);
			_rim = RimPrefab.Id;
			_tractionForward = stateElement.GetFloatAttribute("tractionForward", 1f);
			_tractionSideways = stateElement.GetFloatAttribute("tractionSideways", 1f);
			_frictionForcePoint = stateElement.GetFloatAttribute("forcePoint");
			string stringAttribute3 = stateElement.GetStringAttribute("frictionPreset", _frictionPreset);
			FrictionPreset = Game.Instance.CraftResourceData.WheelPrefabs.GetFrictionPreset(stringAttribute3);
			_brakeTorque = stateElement.GetFloatAttribute("brake", _brakeTorque);
			Pacejka = stateElement.GetVector4AttributeOrNull("pacejka");
			if (_tractionForward < 0f)
			{
				_tractionForward = 0f;
			}
			if (_tractionSideways < 0f)
			{
				_tractionSideways = 0f;
			}
			if (_turningAngle < 0f)
			{
				_turningAngle = 0f;
			}
			if (_size < 0.1f)
			{
				_size = 0.1f;
			}
			if (_width < 0.1f)
			{
				_width = 0.1f;
			}
		}

		protected override float CalculateMass()
		{
			return CalculateMass(Radius, SingleWidth, Duals);
		}

		private static float CalculateMass(float radius, float width, bool duals)
		{
			float num = MathF.PI * radius * radius * width;
			float num2 = radius * 0.5f;
			float num3 = MathF.PI * num2 * num2 * width;
			float num4 = num - num3;
			float num5 = 0.015f + num4 * 2f + num3 * 4.5f;
			if (num5 < 0.015f)
			{
				num5 = 0.015f;
			}
			return num5 * (duals ? 2f : 1f);
		}

		private void InitializeToggleButtonValues()
		{
			if (_genericPartPropertiesScript != null)
			{
				ToggleButtonProperty property = _genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_rim");
				property.ButtonAttribute.Values.Clear();
				property.ButtonAttribute.Values.AddRange(from x in WheelPrefabs.Rims
					orderby x.Id
					select x.Id);
				ToggleButtonProperty property2 = _genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_tireTread");
				property2.ButtonAttribute.Values.Clear();
				property2.ButtonAttribute.Values.AddRange(from x in WheelPrefabs.Tires
					where x.category == _tireStyle
					orderby x.Id
					select x.Id);
				ToggleButtonProperty property3 = _genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_frictionPreset");
				property3.ButtonAttribute.Values.Clear();
				property3.ButtonAttribute.Values.AddRange(from x in WheelPrefabs.FrictionPresets
					orderby x.id
					select x.id);
			}
		}
	}
}
