using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[PartModifierDesignerHeader("Transmission")]
	public class JTransmissionData : PartModifierData, IModifierWithOutputs
	{
		public enum JGearProfileType
		{
			Street = 0,
			Racing = 1,
			Offroad = 2,
			Custom = 3
		}

		public enum JTransmissionType
		{
			Automatic = 0,
			Manual = 1
		}

		private class GearProfile
		{
			public float FirstGearRatio { get; set; }

			public float LastGearRatio { get; set; }

			public float SpacingBias { get; set; }
		}

		private const float BaseSize = 0.62f;

		private const float DefaultShiftGuardSpeedThreshold = 5f;

		private static readonly Dictionary<JGearProfileType, GearProfile> _gearProfiles = new Dictionary<JGearProfileType, GearProfile>
		{
			{
				JGearProfileType.Racing,
				new GearProfile
				{
					FirstGearRatio = 3f,
					LastGearRatio = 0.65f,
					SpacingBias = 0.5f
				}
			},
			{
				JGearProfileType.Street,
				new GearProfile
				{
					FirstGearRatio = 4f,
					LastGearRatio = 0.85f,
					SpacingBias = 0.75f
				}
			},
			{
				JGearProfileType.Offroad,
				new GearProfile
				{
					FirstGearRatio = 5f,
					LastGearRatio = 1f,
					SpacingBias = 1f
				}
			},
			{
				JGearProfileType.Custom,
				new GearProfile
				{
					FirstGearRatio = 4f,
					LastGearRatio = 0.85f,
					SpacingBias = 0.75f
				}
			}
		};

		[DesignerPropertySlider(1f, 10f, 101, Label = "Final Gear Ratio", Order = 40, Tooltip = "Multiplier for all gears. Higher values = More Acceleration. Lower values = Higher Top Speed.")]
		private float _finalGearRatio = 3.5f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Gear Profile", Order = 30, Header = "Gears")]
		private JGearProfileType _gearProfile;

		[DesignerPropertyCustomWidget(WidgetTemplate = "property-gear-ratios", Order = 41)]
		private List<float> _gearRatios;

		[DesignerPropertySlider(1f, 10f, 10, Label = "Number of Gears", Order = 35)]
		private int _numGears = 5;

		private bool _refreshUI;

		[DesignerPropertySpinner(0f, 50f, 0.1f, AllowManualEntry = true, Label = "Gear Ratio: R", Order = 50, Tooltip = "Gets the gear ratio for reverse")]
		private float _reverseGearRatio = 3f;

		[DesignerPropertySlider(0.25f, 0.85f, 61, Label = "Shift Down RPM", Order = 13)]
		private float _shiftDownRpmPercent = 0.4f;

		[DesignerPropertySlider(0.5f, 0.98f, 49, Label = "Shift Up RPM", Order = 12)]
		private float _shiftUpRpmPercent = 0.8f;

		private float _size = 1f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Shifting", Order = 10)]
		private JTransmissionType _transmissionType;

		public float FinalGearRatio => _finalGearRatio;

		public JGearProfileType GearProfileType => _gearProfile;

		public Type ModifierScriptType => typeof(JTransmissionScript);

		public int NumGears => _numGears;

		public float PostShiftBan { get; private set; } = 0.5f;

		public JTransmissionScript Script { get; private set; }

		public float ShiftDownRpmPercent => _shiftDownRpmPercent;

		public float ShiftDuration { get; private set; }

		public float ShiftGuardSpeedThreshold { get; private set; } = 5f;

		public float ShiftUpRpmPercent => _shiftUpRpmPercent;

		public float Size => 0.62f * _size;

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

		public JTransmissionType TransmissionType => _transmissionType;

		public float VariableShift { get; private set; }

		public JTransmissionData(XElement partType)
			: base(partType)
		{
		}

		public List<float> GenerateGearRatios()
		{
			if (NumGears < 1)
			{
				Debug.LogError("Number of forward gears must be at least 1.");
				return new List<float> { -3f, 0f, 3f };
			}
			GearProfile gearProfile = _gearProfiles[GearProfileType];
			List<float> list = new List<float>
			{
				0f - _reverseGearRatio,
				0f
			};
			if (GearProfileType == JGearProfileType.Custom && _gearRatios.Count >= 1)
			{
				for (int i = 0; i < NumGears && i < _gearRatios.Count; i++)
				{
					list.Add(_gearRatios[i]);
				}
			}
			else
			{
				float a = Mathf.Log(gearProfile.FirstGearRatio);
				float b = Mathf.Log(gearProfile.LastGearRatio);
				for (int j = 0; j < NumGears; j++)
				{
					float t = Mathf.Pow((NumGears == 1) ? 0f : ((float)j / (float)(NumGears - 1)), gearProfile.SpacingBias);
					float item = Mathf.Exp(Mathf.Lerp(a, b, t));
					list.Add(item);
				}
			}
			return list;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("size", _size);
			xElement.SetAttributeValue("gearProfile", _gearProfile);
			xElement.SetAttributeValue("finalGearRatio", _finalGearRatio);
			xElement.SetAttributeValue("reverseGearRatio", _reverseGearRatio);
			xElement.SetAttributeValue("numGears", _numGears);
			xElement.SetAttributeValue("shiftDownRpm", _shiftDownRpmPercent);
			xElement.SetAttributeValue("shiftUpRpm", _shiftUpRpmPercent);
			xElement.SetAttributeValue("transmissionType", _transmissionType);
			xElement.SetAttributeValue("shiftDuration", ShiftDuration);
			xElement.SetAttributeValue("postShiftBan", PostShiftBan);
			xElement.SetAttributeValue("variableShift", VariableShift);
			if (ShiftGuardSpeedThreshold != 5f)
			{
				xElement.SetAttributeValue("shiftGuardSpeedThreshold", ShiftGuardSpeedThreshold);
			}
			List<float> gearRatios = _gearRatios;
			if (gearRatios != null && gearRatios.Count > 0)
			{
				xElement.SetAttributeValue("customGearRatios", string.Join(",", _gearRatios));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_size":
			case "_shiftUpRpmPercent":
			case "_shiftDownRpmPercent":
				return Utilities.FormatPercentage(sliderValue);
			case "_finalGearRatio":
				return $"{_finalGearRatio:n1}";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_shiftUpRpmPercent":
			case "_shiftDownRpmPercent":
				return () => _transmissionType == JTransmissionType.Automatic;
			case "_gearRatios":
				return () => _gearProfile == JGearProfileType.Custom;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<JTransmissionScript>();
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshUI)
			{
				_refreshUI = false;
				genericPartProperties.RefreshUI();
				RefreshGearRatios(genericPartProperties);
			}
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			_refreshUI = true;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			switch (propertyName)
			{
			case "_size":
			case "_numGears":
			{
				bool buildMeshes = propertyName != "_size";
				Script.UpdateMeshes(buildMeshes);
				Designer.Instance.SetAircraftStructureChanged();
				break;
			}
			case "_shiftUpRpmPercent":
				_shiftDownRpmPercent = Mathf.Min(_shiftUpRpmPercent - 0.05f, _shiftDownRpmPercent);
				_refreshUI = true;
				break;
			case "_shiftDownRpmPercent":
				_shiftUpRpmPercent = Mathf.Max(_shiftUpRpmPercent, _shiftDownRpmPercent + 0.05f);
				_refreshUI = true;
				break;
			}
			if (propertyName == "_numGears" || propertyName == "_gearProfile")
			{
				_refreshUI = true;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = stateElement.GetFloatAttribute("size", _size);
			_gearProfile = stateElement.GetEnumAttribute("gearProfile", _gearProfile);
			_numGears = stateElement.GetIntAttribute("numGears", _numGears);
			_shiftDownRpmPercent = stateElement.GetFloatAttribute("shiftDownRpm", _shiftDownRpmPercent);
			_shiftUpRpmPercent = stateElement.GetFloatAttribute("shiftUpRpm", _shiftUpRpmPercent);
			_transmissionType = stateElement.GetEnumAttribute("transmissionType", _transmissionType);
			ShiftDuration = stateElement.GetFloatAttribute("shiftDuration", ShiftDuration);
			PostShiftBan = stateElement.GetFloatAttribute("postShiftBan", PostShiftBan);
			VariableShift = stateElement.GetFloatAttribute("variableShift", VariableShift);
			ShiftGuardSpeedThreshold = stateElement.GetFloatAttribute("shiftGuardSpeedThreshold", ShiftGuardSpeedThreshold);
			float floatAttribute = stateElement.GetFloatAttribute("gearTuning");
			float defaultValue = Mathf.Lerp(7f, 3f, Mathf.Clamp01((floatAttribute + 1f) / 2f));
			_finalGearRatio = stateElement.GetFloatAttribute("finalGearRatio", defaultValue);
			_reverseGearRatio = stateElement.GetFloatAttribute("reverseGearRatio", 3f);
			_gearRatios = stateElement.GetFloatListAttribute("customGearRatios");
		}

		protected override float CalculateMass()
		{
			float num = 6f * Mathf.Pow(_numGears, 0.8f);
			return (25f + num) * Mathf.Pow(_size, 2.4f) * 0.01f;
		}

		private void RefreshGearRatios(IGenericPartProperties partProperties)
		{
			if (_gearProfile == JGearProfileType.Custom)
			{
				GearRatiosWidget component = partProperties.GetProperty<CustomWidgetProperty>("_gearRatios").Widget.GetComponent<GearRatiosWidget>();
				if (_gearRatios == null || _gearRatios.Count == 0)
				{
					_gearRatios = new List<float> { 4f, 3f, 2f, 1.5f, 1.25f, 1f, 0.9f, 0.75f };
				}
				int num = Mathf.Min(10, _numGears);
				while (_gearRatios.Count < num)
				{
					_gearRatios.Add(0f);
				}
				component.SetRatios(_gearRatios, _numGears);
			}
		}
	}
}
