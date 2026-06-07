using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Flight;
using Jundroo.Common.Animation;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Utils;
using NWH.Common.Utility;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[PartModifierDesignerHeader("Engine")]
	public class JEngineData : PartModifierData, IModifierWithOutputs
	{
		private const float GlobalBaseSize = 0.62f;

		private const float NewtonMeterToFootPound = 0.73756f;

		private float _basePower;

		private float _baseRpm;

		private float _baseSize;

		[DesignerPropertySlider(1f, 6f, 6, Label = "Cylinders", Order = 3)]
		private int _cylinderRows = 3;

		[DesignerPropertyLabel(Label = "Horse Power", Header = "Engine Performance", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 100, Tooltip = "The horse power of the engine.")]
		private string _designerHorsePowerDisplay;

		[DesignerPropertyLabel(Label = "Max RPM", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 105, Tooltip = "The maximum RPM of the engine.")]
		private string _designerMaxRpmDisplay;

		[DesignerPropertyLabel(Label = "Peak Torque", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 110, Tooltip = "The peak torque of the engine.")]
		private string _designerTorqueDisplay;

		[DesignerPropertySlider(0f, 1f, 0, Label = "Cylinders", Order = 2)]
		private int _engineConfiguration;

		[DesignerPropertySlider(-1f, 1f, 41, Label = "Engine Tuning", Order = 10)]
		private float _engineTuning;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Forced Induction", Order = 31)]
		private float _forcedInduction = 1f;

		private float _mass;

		private float _massToPowerRatio;

		private string _powerCurve = "0";

		private bool _refreshUI;

		private float _rpmScalingExponent;

		private bool _showCylindersPerRow;

		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Size", Order = 1)]
		private float _size = 1f;

		private float _soundPitchLimit;

		private float _soundPitchOffset;

		private float _soundPitchRange;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Supercharger", Order = 30)]
		private bool _supercharger;

		private float _superchargerMultiplier;

		public int EngineConfiguration => _engineConfiguration;

		public float ForcedInductionMultiplier
		{
			get
			{
				if (!HasSupercharger)
				{
					return 1f;
				}
				return Mathf.Lerp(1f, _superchargerMultiplier, _forcedInduction);
			}
		}

		public bool HasSupercharger
		{
			get
			{
				if (_supercharger)
				{
					return _superchargerMultiplier > 1f;
				}
				return false;
			}
		}

		public float IdleRpm => MaxRpm * 0.15f;

		public float MaxRpm { get; private set; }

		public Type ModifierScriptType => typeof(JEngineScript);

		public int NumCylinderRows => _cylinderRows;

		public int NumCylinders => NumCylinderRows * Script.EnginePrefab.NumCylinders;

		public float Power { get; private set; }

		public float SoundPitchLimit => _soundPitchLimit;

		public float SoundPitchOffset => _soundPitchOffset;

		public float SoundPitchRange => _soundPitchRange;

		public EngineSoundType SoundType { get; private set; }

		public AnimationCurve PowerCurve
		{
			get
			{
				if (_powerCurve == "0" || string.IsNullOrEmpty(_powerCurve))
				{
					return null;
				}
				AnimationCurve animationCurve = new AnimationCurve();
				UserCurve.AddKeyframes(animationCurve, _powerCurve);
				if (animationCurve.length <= 0)
				{
					return null;
				}
				return animationCurve;
			}
			set
			{
				_powerCurve = ((value == null) ? "0" : UserCurve.GetKeyframesAsString(value, UserCurve.CurveStyle.Custom));
			}
		}

		public float RedlineRpmPercent { get; private set; }

		public JEngineScript Script { get; private set; }

		public float Size => _baseSize * _size;

		public float SizePercentage
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public float StartupDuration { get; }

		public float ThrottleResponse { get; set; } = 5f;

		public JEngineData(XElement partType)
			: base(partType)
		{
			_baseRpm = partType.GetFloatAttribute("baseRpm");
			_basePower = partType.GetFloatAttribute("basePower");
			_massToPowerRatio = partType.GetFloatAttribute("massToPower", 0.5f);
			_baseSize = partType.GetFloatAttribute("baseSize", 1f) * 0.62f;
			RedlineRpmPercent = partType.GetFloatAttribute("redLine", 1f);
			_superchargerMultiplier = partType.GetFloatAttribute("superchargerMultiplier");
			ThrottleResponse = partType.GetFloatAttribute("throttleResponse", ThrottleResponse);
			_rpmScalingExponent = partType.GetFloatAttribute("rpmScalingExponent", 1f);
			StartupDuration = partType.GetFloatAttribute("startupDuration", 0.25f);
			SoundType = partType.GetEnumAttribute("soundType", EngineSoundType.None);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("engineConfiguration", _engineConfiguration);
			xElement.SetAttributeValue("cylinderRows", _cylinderRows);
			xElement.SetAttributeValue("engineTuning", _engineTuning);
			xElement.SetAttributeValue("size", _size);
			xElement.SetAttributeValue("mass", _mass);
			xElement.SetAttributeValue("horsePower", Power);
			xElement.SetAttributeValue("rpm", MaxRpm);
			xElement.SetAttributeValue("supercharger", _supercharger);
			xElement.SetAttributeValue("forcedInduction", _forcedInduction);
			xElement.SetAttributeValue("powerCurve", _powerCurve);
			xElement.SetAttributeValue("soundPitchLimit", _soundPitchLimit);
			xElement.SetAttributeValue("soundPitchOffset", _soundPitchOffset);
			xElement.SetAttributeValue("soundPitchRange", _soundPitchRange);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_cylinderRows":
				if (!_showCylindersPerRow)
				{
					return $"{NumCylinders}";
				}
				return $"{_cylinderRows}";
			case "_engineConfiguration":
				return $"{Script.EnginePrefab.NumCylinders}";
			case "_engineTuning":
			{
				string text = ((_engineTuning < 0f) ? "Favor Torque" : "Favor RPM");
				if (_engineTuning == 0f)
				{
					text = "Balanced";
				}
				return Utilities.FormatPercentage(Mathf.Abs(_engineTuning)) + " " + text;
			}
			case "_size":
			case "_forcedInduction":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_engineConfiguration")
			{
				return () => _showCylindersPerRow;
			}
			if (property.Member.Name == "_supercharger")
			{
				return () => _superchargerMultiplier > 1f;
			}
			if (property.Member.Name == "_forcedInduction")
			{
				return () => _supercharger;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<JEngineScript>();
			Script.Initialize(this);
			if (_mass == 0f || Power == 0f || MaxRpm == 0f)
			{
				UpdateEnginePerformance();
				if (Script.LoadContext == CraftLoadContext.Flight && !aircraftScript.RemoteAircraft)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage("This craft may not work correctly. Please reload it in the designer and re-save it.");
				}
			}
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
			UpdateEnginePerformanceDisplay();
			_showCylindersPerRow = Script.EnginePrefabs.Length > 1;
			if (_showCylindersPerRow)
			{
				ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_engineConfiguration");
				property.SliderAttribute.MinValue = 0f;
				property.SliderAttribute.MaxValue = Script.EnginePrefabs.Length - 1;
				property.Value = _engineConfiguration;
			}
			ISliderProperty property2 = genericPartPropertiesScript.GetProperty<ISliderProperty>("_cylinderRows");
			string text = (_showCylindersPerRow ? "Rows" : "Cylinders");
			property2.Slider.LabelText = text;
			property2.SliderAttribute.Label = text;
			property2.SliderAttribute.MinValue = Script.EnginePrefab.MinRows;
			property2.SliderAttribute.MaxValue = Script.EnginePrefab.MaxRows;
			property2.Value = _cylinderRows;
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			EngineComponent engine = Script.GetComponent<VehicleController>().powertrain.engine;
			AnimationCurve powerCurve = PowerCurve;
			if (powerCurve == null)
			{
				powerCurve = engine.powerCurve;
			}
			if (!(property.Member.Name == "_powerCurve"))
			{
				return;
			}
			Game.Instance.UserInterface.CreateCurveEditor(powerCurve, delegate(AnimationCurve x)
			{
				PowerCurve = x;
				JEngineData mirroredModifier = SymmetryUtility.GetMirroredModifier(this);
				if (mirroredModifier != null)
				{
					mirroredModifier.PowerCurve = x;
				}
				Designer.Instance.SetAircraftStructureChanged();
				UpdateEnginePerformance();
				UpdateEnginePerformanceDisplay();
				_refreshUI = true;
			}).EditorScript.SetupSecondaryCurve(delegate(AnimationCurve pc)
			{
				AnimationCurve animationCurve = new AnimationCurve();
				_ = string.Empty;
				float num = 0f;
				for (float num2 = 0f; num2 <= 1f; num2 += 0.01f)
				{
					float num3 = num2 * engine.revLimiterRPM;
					if (num3 < engine.idleRPM)
					{
						animationCurve.AddKey(num2, 0f);
					}
					else
					{
						float num4 = pc.Evaluate(num2) * engine.maxPower;
						float num5 = UnitConverter.RPMToAngularVelocity(num3);
						float num6 = ((num5 > 0f) ? (num4 * 1000f / num5) : 0f);
						num6 *= ForcedInductionMultiplier;
						if (num6 > num)
						{
							num = num6;
						}
						animationCurve.AddKey(num2, num6 * 0.73756f);
					}
				}
				animationCurve.SetTangents(AnimationCurveTangentMode.Linear);
				return animationCurve;
			});
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			switch (propertyName)
			{
			case "_size":
			case "_cylinderRows":
			case "_engineConfiguration":
			case "_engineTuning":
			case "_forcedInduction":
			case "_supercharger":
			{
				bool buildMeshes = propertyName != "_size";
				Script.UpdateEngineMeshes(buildMeshes, updateAttachedParts: true);
				Designer.Instance.SetAircraftStructureChanged();
				break;
			}
			}
			UpdateEnginePerformance();
			UpdateEnginePerformanceDisplay();
			_refreshUI = true;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_engineConfiguration = stateElement.GetIntAttribute("engineConfiguration", _engineConfiguration);
			_cylinderRows = stateElement.GetIntAttribute("cylinderRows", _cylinderRows);
			_engineTuning = stateElement.GetFloatAttribute("engineTuning", _engineTuning);
			_size = stateElement.GetFloatAttribute("size", _size);
			_supercharger = stateElement.GetBoolAttribute("supercharger", _supercharger);
			_forcedInduction = stateElement.GetFloatAttribute("forcedInduction", _forcedInduction);
			_powerCurve = stateElement.GetStringAttribute("powerCurve", _powerCurve);
			_soundPitchLimit = stateElement.GetFloatAttribute("soundPitchLimit", -1f);
			_soundPitchOffset = stateElement.GetFloatAttribute("soundPitchOffset", -1f);
			_soundPitchRange = stateElement.GetFloatAttribute("soundPitchRange", -1f);
			_mass = stateElement.GetFloatAttribute("mass");
			Power = stateElement.GetFloatAttribute("horsePower");
			MaxRpm = stateElement.GetFloatAttribute("rpm");
		}

		protected override float CalculateMass()
		{
			return _mass;
		}

		private void UpdateEnginePerformance()
		{
			float num = Size / 0.62f;
			float num2 = num * num;
			float num3 = NumCylinders;
			float num4 = _basePower * num3 * num2;
			float num5 = num4 * 5252f / _baseRpm;
			float t = (_engineTuning + 1f) / 2f;
			float num6 = Mathf.Lerp(0.75f, 1.25f, t);
			float num7 = Mathf.Pow(num, _rpmScalingExponent);
			if (num7 < 0.01f)
			{
				num7 = 0.01f;
			}
			MaxRpm = _baseRpm * (1f / num7) * num6;
			float num8 = Mathf.Lerp(1.1f, 0.9f, t);
			float num9 = num5 * num8;
			Power = num9 * MaxRpm / 5252f;
			float num10 = 1f;
			if (HasSupercharger && _supercharger)
			{
				num10 = Mathf.Lerp(1f, 1.2f, ForcedInductionMultiplier - 1f);
			}
			_mass = num4 * _massToPowerRatio * num10 * 0.01f;
			if (_mass < 0.001f)
			{
				_mass = 0.001f;
			}
		}

		private void UpdateEnginePerformanceDisplay()
		{
			_designerHorsePowerDisplay = $"{Power * ForcedInductionMultiplier:n0} hp";
			_designerMaxRpmDisplay = $"{MaxRpm:n0} RPM";
			Script.CalculateDesignerPeakTorque(out var peakTorque, out var _);
			_designerTorqueDisplay = $"{peakTorque * 0.73756f:n0} ft-lb";
			base.Part.RecalculateLoadedMass(recalculateModifierMass: true);
		}
	}
}
