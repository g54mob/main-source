using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Gauge")]
	public class GaugeData : PartModifierData
	{
		public enum GaugeFaceTypes
		{
			AirSpeed200Indicator = 0,
			AirSpeed400Indicator = 1,
			AirSpeed600Indicator = 2,
			AltimeterIndicator = 3,
			AttitudeIndicator = 4,
			FuelIndicator = 5,
			HeadingIndicator = 6,
			ThrottleIndicator = 7,
			TrimIndicator = 8,
			TurnCoordinatorIndicator = 9,
			VerticalSpeedIndicator = 10,
			VTOLIndicator = 11,
			RotorRPM = 12,
			Basic1 = 13
		}

		[Serializable]
		public enum GaugeRotationType
		{
			Indicator = 0,
			Face = 10
		}

		public enum IndicatorType
		{
			Indicator1 = 0,
			Indicator2 = 1,
			Indicator3 = 2,
			Indicator4 = 3,
			Indicator5 = 4,
			Indicator6 = 5,
			Indicator7 = 6,
			None = 7
		}

		private enum AltitudeUnit
		{
			Feet = 0,
			Meters = 10,
			None = 20
		}

		private enum GaugeTrimType
		{
			Trim1 = 0,
			Trim2 = 1
		}

		private enum GaugeTypePreset
		{
			Custom = 0,
			Heading = 10,
			Fuel = 20,
			Throttle = 30,
			Speed200 = 40,
			Speed400 = 50,
			Speed600 = 60,
			Altitude = 70,
			Trim = 80,
			TurnCoordinator = 90,
			VerticalSpeed = 100,
			RotorRPM = 110,
			VTOL = 120,
			BankAngle = 130
		}

		private enum SpeedUnit
		{
			Knots = 0,
			MetersPerSecond = 10,
			MilesPerHour = 20,
			KilometersPerHour = 30,
			None = 40
		}

		public class GaugeIndicatorData
		{
			[DesignerPropertyToggleButton(new string[] { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6", "Option 7", "None" }, Label = "Indicator Needle", Order = 10)]
			private IndicatorType _indicatorType;

			[DesignerPropertyToggleButton(new string[] { "Trim", "VTOL", "Throttle", "Brake", "Roll", "Pitch", "Yaw", "Heading", "Disabled" }, Label = "Input", AllowFunkyInput = true, Order = 25)]
			private string _input = "Throttle";

			[DesignerPropertyToggleButton(new string[] { "False", "True" }, Label = "Invert", Order = 26)]
			private bool _invert;

			[DesignerPropertySlider(0f, 360f, 37, Label = "Input Multiplier", Order = 30)]
			private float _multiplier = 360f;

			[DesignerPropertySlider(-180f, 180f, 73, Label = "Indicator Zero", Order = 20)]
			private float _zero;

			public string Input => _input;

			public bool Invert
			{
				get
				{
					return _invert;
				}
				set
				{
					_invert = value;
				}
			}

			public float Multiplier
			{
				get
				{
					if (Mathf.Approximately(_multiplier, 0f))
					{
						return 1f;
					}
					return _multiplier;
				}
			}

			public IndicatorType NeedleType => _indicatorType;

			public float Zero => _zero;

			public GaugeIndicatorData(string input, float multiplier, IndicatorType indicator, float zero, bool invert)
			{
				_input = input;
				_multiplier = multiplier;
				_indicatorType = indicator;
				_zero = zero;
				_invert = invert;
			}
		}

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Feet", "Meters" }, Label = "Unit", Order = 3, SilenceEnumCountMismatch = true)]
		private AltitudeUnit _altitudeUnit = AltitudeUnit.None;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Label = "Face Emission Day", Order = 35)]
		private float _faceEmissionDay = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Label = "Face Emission Night", Order = 36)]
		private float _faceEmissionNight = 1f;

		[DesignerPropertyToggleButton(new string[] { "Trim", "VTOL", "Throttle", "Brake", "Roll", "Pitch", "Yaw", "Heading", "Disabled" }, Label = "Face Input", AllowFunkyInput = true, Order = 25)]
		private string _faceInput = "Disabled";

		[DesignerPropertyToggleButton(new string[] { "False", "True" }, Label = "Invert", Order = 26)]
		private bool _faceInvert;

		[SerializeField]
		[DesignerPropertySlider(0f, 360f, 37, Label = "Face Input Multiplier", Order = 30)]
		private float _faceMultiplier = 360f;

		[SerializeField]
		[DesignerPropertySlider(-180f, 180f, 73, Label = "Face Zero", Order = 21)]
		private float _faceZero;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[]
		{
			"AS-200", "AS-400", "AS-600", "Altimeter", "Attitude", "Fuel", "Heading", "Throttle", "Trim", "TC",
			"Vertical-S", "VTOL", "RPM", "Generic"
		}, Label = "Gauge Face", Order = 5)]
		private GaugeFaceTypes _gaugeFaceTexture;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[]
		{
			"Custom", "Compass", "Fuel", "Throttle", "Speed 200", "Speed 400", "Speed 600", "Altitude", "Trim", "TC",
			"Vert. Speed", "Rotor RPM", "VTOL", "Bank Angle"
		}, Label = "Preset", Order = 2)]
		private GaugeTypePreset _gaugeType;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { }, Label = "Hide Base", Order = 45)]
		private bool _hideBase;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { }, Label = "Hide Face", Order = 50)]
		private bool _hideFace;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { }, Label = "Hide Trim", Order = 65)]
		private bool _hideTrim;

		[DesignerPropertyClass(Label = "Indicator", Order = 10)]
		private GaugeIndicatorData[] _indicators = new GaugeIndicatorData[1]
		{
			new GaugeIndicatorData("Heading", 360f, IndicatorType.Indicator1, 0f, invert: false)
		};

		private bool _queuedUiRefresh;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Indicator", "Face" }, Label = "Rotation", Order = 13)]
		private GaugeRotationType _rotationType;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Scale", Order = 15)]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Knots", "m/s", "MPH", "KPH" }, Label = "Unit", Order = 3, SilenceEnumCountMismatch = true)]
		private SpeedUnit _speedUnit = SpeedUnit.None;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "Trim 1", "Trim 2" }, Label = "Trim", Order = 11)]
		private GaugeTrimType _trimType;

		public float FaceEmissionDay => _faceEmissionDay;

		public float FaceEmissionNight => _faceEmissionNight;

		public string FaceInput => _faceInput;

		public bool FaceInvert => _faceInvert;

		public float FaceMultiplier
		{
			get
			{
				if (Mathf.Approximately(_faceMultiplier, 0f))
				{
					return 1f;
				}
				return _faceMultiplier;
			}
		}

		public GaugeFaceTypes FaceType => _gaugeFaceTexture;

		public float FaceZero => _faceZero;

		public bool HideBase => _hideBase;

		public bool HideFace => _hideFace;

		public bool HideTrim => _hideTrim;

		public GaugeIndicatorData[] Indicators => _indicators;

		public GaugeRotationType RotationType => _rotationType;

		public float Scale => _scale;

		public GaugeScript Script { get; private set; }

		public GaugeData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("type", _gaugeType.ToString()), new XAttribute("face", _gaugeFaceTexture.ToString()), new XAttribute("trimType", _trimType.ToString()), new XAttribute("scale", _scale.ToString()), new XAttribute("rotationType", _rotationType.ToString()), new XAttribute("faceInput", _faceInput), new XAttribute("invert", _faceInvert), new XAttribute("faceZero", _faceZero.ToString()), new XAttribute("faceMultiplier", _faceMultiplier.ToString()), new XAttribute("faceEmissionDay", _faceEmissionDay.ToString()), new XAttribute("faceEmissionNight", _faceEmissionNight.ToString()), new XAttribute("hideBase", _hideBase.ToString()), new XAttribute("hideFace", _hideFace.ToString()), new XAttribute("hideTrim", _hideTrim.ToString()));
			if (_speedUnit != SpeedUnit.None)
			{
				xElement.Add(new XAttribute("speedUnit", _speedUnit.ToString()));
			}
			if (_altitudeUnit != AltitudeUnit.None)
			{
				xElement.Add(new XAttribute("altitudeUnit", _altitudeUnit.ToString()));
			}
			for (int i = 0; i < Indicators.Length; i++)
			{
				GaugeIndicatorData gaugeIndicatorData = Indicators[i];
				xElement.Add(new XElement("Indicator", new XAttribute("input", gaugeIndicatorData.Input), new XAttribute("invert", gaugeIndicatorData.Invert), new XAttribute("indicator", gaugeIndicatorData.NeedleType), new XAttribute("multiplier", gaugeIndicatorData.Multiplier), new XAttribute("zero", gaugeIndicatorData.Zero)));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_scale":
			case "_faceEmissionDay":
			case "_faceEmissionNight":
				return Utilities.FormatPercentage(sliderValue);
			case "_faceMultiplier":
			case "_multiplier":
				if (!Mathf.Approximately(sliderValue, 0f) && !Mathf.Approximately(sliderValue, 1f))
				{
					return sliderValue.ToString();
				}
				return "None";
			case "_faceZero":
			case "_zero":
				return sliderValue.ToString("0");
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_speedUnit":
				return () => _gaugeType == GaugeTypePreset.Speed200 || _gaugeType == GaugeTypePreset.Speed400 || _gaugeType == GaugeTypePreset.Speed600;
			case "_altitudeUnit":
				return () => _gaugeType == GaugeTypePreset.Altitude;
			case "_faceInput":
			case "_faceInvert":
			case "_faceMultiplier":
				return () => _rotationType == GaugeRotationType.Face;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<GaugeScript>();
			Script.Initialize(this);
			UpdateGaugeTexture(_gaugeFaceTexture);
			UpdateTrim(_trimType);
			UpdateIndicators();
			UpdateScale(_scale);
			UpdateZero();
			UpdateHiddenMeshes(_hideBase, _hideFace, _hideTrim);
			return Script;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_queuedUiRefresh)
			{
				genericPartProperties.RefreshUI();
				_queuedUiRefresh = false;
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_gaugeType":
			case "_speedUnit":
			case "_altitudeUnit":
				if (_gaugeType == GaugeTypePreset.Speed200 || _gaugeType == GaugeTypePreset.Speed400 || _gaugeType == GaugeTypePreset.Speed600)
				{
					if (_speedUnit == SpeedUnit.None)
					{
						_speedUnit = SpeedUnit.Knots;
					}
				}
				else if (_gaugeType == GaugeTypePreset.Altitude && _altitudeUnit == AltitudeUnit.None)
				{
					_altitudeUnit = AltitudeUnit.Feet;
				}
				ApplyPreset(_gaugeType);
				break;
			}
			if (propertyName == "_gaugeFaceTexture")
			{
				UpdateGaugeTexture(_gaugeFaceTexture);
				EnsureTypeCustom();
			}
			if (propertyName == "_faceZero" || propertyName == "_zero")
			{
				UpdateZero();
				EnsureTypeCustom();
			}
			if (propertyName == "_indicatorType")
			{
				UpdateIndicators();
				EnsureTypeCustom();
			}
			if (propertyName == "_trimType")
			{
				UpdateTrim(_trimType);
				EnsureTypeCustom();
			}
			if (propertyName == "_scale")
			{
				UpdateScale(_scale);
			}
			switch (propertyName)
			{
			case "_hideBase":
			case "_hideFace":
			case "_hideTrim":
				UpdateHiddenMeshes(_hideBase, _hideFace, _hideTrim);
				break;
			}
			if (propertyName == "_faceEmissionDay" || propertyName == "_faceEmissionNight")
			{
				UpdateEmission(_faceEmissionDay, _faceEmissionNight);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			XElement xElement = stateElement.Parent.Element("InputController.State");
			if (stateElement.Element("Indicator") == null && xElement != null)
			{
				Debug.Log($"Detected old gauge on part-{base.Part.Id}, upgrading.");
				bool flag = stateElement.Attribute("rotationType")?.Value == "Face";
				XElement xElement2 = new XElement("Indicator");
				xElement2.Add(new XAttribute("input", flag ? "Disabled" : xElement.Attribute("input").Value));
				xElement2.Add(new XAttribute("invert", flag ? "false" : xElement.Attribute("invert").Value));
				xElement2.Add(new XAttribute("indicator", stateElement.Attribute("indicator").Value));
				xElement2.Add(new XAttribute("multiplier", flag ? "0" : stateElement.Attribute("multiplier").Value));
				xElement2.Add(new XAttribute("zero", stateElement.Attribute("indicatorZero").Value));
				stateElement.Add(xElement2);
				if (flag)
				{
					stateElement.Add(new XAttribute("faceInput", xElement.Attribute("input").Value));
					stateElement.Add(new XAttribute("faceMultiplier", stateElement.Attribute("multiplier").Value));
					stateElement.Add(new XAttribute("invert", xElement.Attribute("invert").Value));
				}
			}
			_gaugeType = stateElement.GetEnumAttribute("type", GaugeTypePreset.Custom);
			string value = ((string)stateElement.Attribute("face")) ?? string.Empty;
			_gaugeFaceTexture = (Enum.TryParse<GaugeFaceTypes>(value, out var result) ? result : GaugeFaceTypes.AirSpeed200Indicator);
			_trimType = stateElement.GetEnumAttribute("trimType", GaugeTrimType.Trim1);
			_scale = stateElement.GetFloatAttribute("scale", 1f);
			_rotationType = stateElement.GetEnumAttribute("rotationType", GaugeRotationType.Indicator);
			_faceInput = stateElement.GetStringAttribute("faceInput", "Disabled");
			_faceInvert = stateElement.GetBoolAttribute("invert");
			_faceZero = stateElement.GetFloatAttribute("faceZero");
			_faceMultiplier = stateElement.GetFloatAttribute("faceMultiplier", 360f);
			float floatAttribute = stateElement.GetFloatAttribute("faceEmission", 1f);
			_faceEmissionDay = stateElement.GetFloatAttribute("faceEmissionDay", floatAttribute);
			_faceEmissionNight = stateElement.GetFloatAttribute("faceEmissionNight", floatAttribute);
			_hideBase = stateElement.GetBoolAttribute("hideBase");
			_hideFace = stateElement.GetBoolAttribute("hideFace");
			_hideTrim = stateElement.GetBoolAttribute("hideTrim");
			_speedUnit = stateElement.GetEnumAttribute("speedUnit", SpeedUnit.None);
			_altitudeUnit = stateElement.GetEnumAttribute("altitudeUnit", AltitudeUnit.None);
			List<GaugeIndicatorData> list = new List<GaugeIndicatorData>(1);
			foreach (XElement item in stateElement.Elements("Indicator"))
			{
				GaugeIndicatorData gaugeIndicatorData = ParseIndicator(item);
				if (gaugeIndicatorData != null)
				{
					list.Add(gaugeIndicatorData);
				}
			}
			if (list.Count != 0)
			{
				_indicators = list.ToArray();
			}
			static GaugeIndicatorData ParseIndicator(XElement el)
			{
				string stringAttribute = el.GetStringAttribute("input", "Throttle");
				bool boolAttribute = el.GetBoolAttribute("invert");
				float floatAttribute2 = el.GetFloatAttribute("multiplier", 360f);
				IndicatorType enumAttribute = el.GetEnumAttribute("indicator", IndicatorType.Indicator1);
				float floatAttribute3 = el.GetFloatAttribute("zero");
				return new GaugeIndicatorData(stringAttribute, floatAttribute2, enumAttribute, floatAttribute3, boolAttribute);
			}
		}

		private void ApplyPreset(GaugeTypePreset preset)
		{
			_queuedUiRefresh = true;
			switch (preset)
			{
			case GaugeTypePreset.Heading:
				_gaugeFaceTexture = GaugeFaceTypes.HeadingIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("Disabled", 0f, IndicatorType.Indicator6, 0f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Face;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Heading";
				_faceInvert = true;
				break;
			case GaugeTypePreset.Fuel:
				_gaugeFaceTexture = GaugeFaceTypes.FuelIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("Fuel", 290f, IndicatorType.Indicator1, -145f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.Throttle:
				_gaugeFaceTexture = GaugeFaceTypes.ThrottleIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("Throttle", 180f, IndicatorType.Indicator1, -90f, invert: false)
				};
				_trimType = GaugeTrimType.Trim2;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.Speed200:
				_gaugeFaceTexture = GaugeFaceTypes.AirSpeed200Indicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData(GetSpeedPresetInput(200, _speedUnit), 0f, IndicatorType.Indicator1, 20f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.Speed400:
				_gaugeFaceTexture = GaugeFaceTypes.AirSpeed400Indicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData(GetSpeedPresetInput(400, _speedUnit), 0f, IndicatorType.Indicator1, 20f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.Speed600:
				_gaugeFaceTexture = GaugeFaceTypes.AirSpeed600Indicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData(GetSpeedPresetInput(600, _speedUnit), 0f, IndicatorType.Indicator1, 20f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.Altitude:
			{
				_gaugeFaceTexture = GaugeFaceTypes.AltimeterIndicator;
				string text = string.Empty;
				if (_altitudeUnit == AltitudeUnit.Feet)
				{
					text = " * " + 3.28084f.ToString("0.00000");
				}
				_indicators = new GaugeIndicatorData[3]
				{
					new GaugeIndicatorData("Altitude * 0.001" + text, 360f, IndicatorType.Indicator2, 0f, invert: false),
					new GaugeIndicatorData("Altitude * 0.0001" + text, 360f, IndicatorType.Indicator3, 0f, invert: false),
					new GaugeIndicatorData("Altitude * 0.00001" + text, 360f, IndicatorType.Indicator7, 0f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			}
			case GaugeTypePreset.Trim:
				_gaugeFaceTexture = GaugeFaceTypes.TrimIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("Trim", 90f, IndicatorType.Indicator3, 0f, invert: true)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.TurnCoordinator:
				_gaugeFaceTexture = GaugeFaceTypes.TurnCoordinatorIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("AngleOfSlip * clamp01(IAS-5)", 0f, IndicatorType.Indicator2, 0f, invert: true)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.VerticalSpeed:
				_gaugeFaceTexture = GaugeFaceTypes.VerticalSpeedIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("rate(Altitude) * 0.05", 180f, IndicatorType.Indicator2, -90f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.VTOL:
				_gaugeFaceTexture = GaugeFaceTypes.VTOLIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("VTOL", 90f, IndicatorType.Indicator2, -90f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.RotorRPM:
				_gaugeFaceTexture = GaugeFaceTypes.RotorRPM;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("RotorRPM/600", 220f, IndicatorType.Indicator2, -110f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Indicator;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "Disabled";
				_faceInvert = false;
				break;
			case GaugeTypePreset.BankAngle:
				_gaugeFaceTexture = GaugeFaceTypes.AttitudeIndicator;
				_indicators = new GaugeIndicatorData[1]
				{
					new GaugeIndicatorData("Disabled", 0f, IndicatorType.None, 0f, invert: false)
				};
				_trimType = GaugeTrimType.Trim1;
				_rotationType = GaugeRotationType.Face;
				_faceZero = 0f;
				_faceMultiplier = 0f;
				_faceInput = "RollAngle";
				_faceInvert = false;
				break;
			default:
				_queuedUiRefresh = false;
				break;
			}
			if (_queuedUiRefresh)
			{
				UpdateGaugeTexture(_gaugeFaceTexture);
				UpdateTrim(_trimType);
				UpdateIndicators();
				UpdateZero();
			}
		}

		private void EnsureTypeCustom()
		{
			if (_gaugeType != GaugeTypePreset.Custom)
			{
				_gaugeType = GaugeTypePreset.Custom;
				_queuedUiRefresh = true;
			}
		}

		private string GetSpeedPresetInput(int speed, SpeedUnit unit)
		{
			double num = 360.0 / (double)speed;
			switch (_speedUnit)
			{
			case SpeedUnit.Knots:
				num *= 1.943844;
				break;
			case SpeedUnit.MilesPerHour:
				num *= 2.236936;
				break;
			case SpeedUnit.KilometersPerHour:
				num *= 3.6;
				break;
			}
			return $"max(20, IAS * {num}) - 20";
		}

		private void UpdateEmission(float emissionDay, float emissionNight)
		{
			Script.SetFaceEmission(emissionDay, emissionNight);
		}

		private void UpdateGaugeTexture(GaugeFaceTypes face)
		{
			Texture2D gaugeFaceTexture = Resources.Load<Texture2D>("Craft/Parts/Textures/Gauges/" + face);
			Script.OnGaugeFaceChanged(gaugeFaceTexture);
		}

		private void UpdateHiddenMeshes(bool hideBase, bool hideFace, bool hideTrim)
		{
			Script.OnHiddenMeshChanged(hideBase, hideFace, hideTrim);
		}

		private void UpdateIndicators()
		{
			Script.OnIndicatorChanged();
		}

		private void UpdateScale(float scale)
		{
			Script.OnScaleChanged(scale);
		}

		private void UpdateTrim(GaugeTrimType trimType)
		{
			Script.OnTrimChanged(trimType.ToString());
		}

		private void UpdateZero()
		{
			Script.OnZeroChanged();
		}
	}
}
