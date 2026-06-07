using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Flight.Simulation;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	[Serializable]
	[PartModifierDesignerHeader("Jet Engine")]
	public class JetEngineData : PartModifierData
	{
		public const float MinBypassRatio = 0f;

		public const float MinCompressionRatio = 1f;

		[DesignerPropertyColor(Label = "Afterburner Base Color", Order = 145, AllowTransparency = true, Tooltip = "The color of the base of the afterburner, for fun.")]
		private Color _afterburnerBaseColor = new Color32(117, 176, byte.MaxValue, byte.MaxValue);

		[DesignerPropertySlider(0f, 0.95f, 20, Label = "Afterburner Throttle", Order = 141, Tooltip = "This is the throttle at which the afterburner will kick in.")]
		private float _afterburnerThrottleStart = 0.8f;

		[DesignerPropertyColor(Label = "Afterburner Tip Color", Order = 146, AllowTransparency = true, Tooltip = "The color of the tip of the afterburner, also for fun.")]
		private Color _afterburnerTipColor = new Color32(byte.MaxValue, 128, 0, 127);

		[DesignerPropertyLabel(Label = "Afterburner Unsupported", Type = DesignerPropertyLabelAttribute.LabelType.LabelOnly, Order = 141, Tooltip = "The selected nozzle does not support afterburner.")]
		private string _afterburnerUnsupported = "Afterburner is not supported for this jet engine";

		private float _baseSize = 1f;

		[DesignerPropertySlider(1000f, 2500f, 151, Label = "Burner Temperature", Order = 23, Tooltip = "Sets the maximum temperature of the combustion chamber. Higher temperatures generate significantly more thrust, but will burn through fuel much faster and increase mass for the extra nickel plating.")]
		private float _burnerTemp = 1500f;

		private float[] _burnerTempRange = new float[2] { 1000f, 2500f };

		private float[] _bypassRange = new float[2] { 0f, 10f };

		[DesignerPropertySlider(0f, 7f, 141, Label = "Bypass Ratio", Order = 20, Header = "Engine Specs", Tooltip = "The amount of air that bypasses the core. This can greatly increase fuel efficiency. All the cool engineers are doing it these days.")]
		private float _bypassRatio = 0.5f;

		private float[] _compressionRange = new float[2] { 5f, 20f };

		[DesignerPropertySlider(1f, 30f, 59, Label = "Compression Ratio", Order = 22, Tooltip = "Increasing compression can increase fuel efficiency (and thrust up to a point), but also increases the length and weight of the core.")]
		private float _compressionRatio = 7f;

		private float _coreVisualScale = 1f;

		[DesignerPropertyLabel(Label = "Fuel Usage", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 51, Tooltip = "The amount of fuel used by this engine at full throttle.")]
		private string _designerFuelUsage = "TODO";

		[DesignerPropertyLabel(Label = "Thrust", Type = DesignerPropertyLabelAttribute.LabelType.LabelAndValue, Order = 50, Header = "Performance", Tooltip = "The estimated static thrust of this engine at sea level. If an afterburner is present, then both dry and wet thrust are displayed.")]
		private string _designerThrust = "TODO";

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Fan Style", Order = 10)]
		private string _fanStyleID;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Gimbal Speed", Order = 131, Tooltip = "The rate at which the nozzle gimbals")]
		private float _gimbalSpeed;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Afterburner", Order = 140, Header = "Afterburner", Tooltip = "It greatly increases the power of the engine but it decreases efficiency.")]
		private bool _hasAfterburner;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Reverse Thrust", Order = 30, Tooltip = "Allows the engine to push air forward to slow down the craft.")]
		private bool _hasReverseThrust = true;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Inlet Cone Style", Order = 11)]
		private string _inletConeStyleID;

		private float _mass;

		[DesignerPropertySlider(0f, 1f, 101, Label = "Max Gimbal Angle", Order = 130, Tooltip = "The maximum range the nozzle can gimbal.")]
		private float _maxGimbalAnglePercentage;

		[DesignerPropertySlider(0.75f, 1.5f, 76, Label = "Nozzle Length", Order = 121, Tooltip = "Changes the length of the nozzle. Does not affect performance.")]
		private float _nozzleLength = 1f;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Nozzle Style", Order = 120, Header = "Nozzle")]
		private string _nozzleStyleID;

		private bool _refreshUI;

		[DesignerPropertySlider(0.5f, 1.5f, 101, Label = "Diameter", Order = 1, Tooltip = "Changes the overall size of the engine.")]
		private float _size = 1f;

		private float[] _sizeRange = new float[2] { 0.5f, 1.5f };

		private float _turbinePressureRatio = 1f;

		public Color32 AfterburnerBaseColor => _afterburnerBaseColor;

		public float AfterburnerThrottleStart => _afterburnerThrottleStart;

		public Color32 AfterburnerTipColor => _afterburnerTipColor;

		public override bool AllowDisableSymmetry => false;

		public float BypassRatio
		{
			get
			{
				return _bypassRatio;
			}
			set
			{
				_bypassRatio = value;
			}
		}

		public float CompressionRatio
		{
			get
			{
				return _compressionRatio;
			}
			set
			{
				_compressionRatio = value;
			}
		}

		public float CompressorLength => _compressionRatio * 0.1f + 0.1f;

		public float CoreRadius => Mathf.Sqrt(FanRadius * FanRadius / (BypassRatio + 1f));

		public float CoreVisualRadius => CoreRadius * _coreVisualScale;

		public float FanArea => MathF.PI * FanRadius * FanRadius;

		public JetEnginePrefabs.FanPrefab FanPrefab { get; private set; }

		public float FanPressureRatio { get; private set; } = 1.5f;

		public float FanRadius => Scale * 0.5f;

		public float GimbalSpeed => _gimbalSpeed;

		public bool HasAfterburner
		{
			get
			{
				return _hasAfterburner;
			}
			set
			{
				_hasAfterburner = value;
			}
		}

		public bool HasReverseThrust
		{
			get
			{
				return _hasReverseThrust;
			}
			set
			{
				_hasReverseThrust = value;
			}
		}

		public JetEnginePrefabs.InletConePrefab InletConePrefab { get; private set; }

		public JetEngineType JetEngineType { get; private set; }

		public override float Mass => _mass;

		public JetEngineMath.Params MathParams { get; private set; } = new JetEngineMath.Params();

		public float MaxGimbalAngle => _maxGimbalAnglePercentage * NozzlePrefab.gimbalAngle;

		public float NozzleLength => _nozzleLength;

		public JetEnginePrefabs.NozzlePrefab NozzlePrefab { get; private set; }

		public float Scale => _size * _baseSize;

		public JetEngineScript Script { get; private set; }

		public float ThrottleResponse => 0.05f / Mathf.Sqrt(CoreRadius);

		public float TurbinePressureRatio => _turbinePressureRatio;

		private JetEnginePrefabs Prefabs => Game.Instance.CraftResourceData.JetEnginePrefabs;

		public JetEngineData(XElement element)
			: base(element)
		{
			JetEngineType = element.GetEnumAttribute("jetEngineType", JetEngineType.Legacy);
			_baseSize = element.GetFloatAttribute("baseSize", 1f);
			element.GetFloatArrayAttribute("burnerTempRange", _burnerTempRange, 0f);
			element.GetFloatArrayAttribute("bypassRange", _bypassRange, 0f);
			element.GetFloatArrayAttribute("compressionRange", _compressionRange, 0f);
			element.GetFloatArrayAttribute("sizeRange", _sizeRange, 0f);
			_coreVisualScale = element.GetFloatAttribute("coreVisualScale", _coreVisualScale);
			FanPressureRatio = element.GetFloatAttribute("fanPressureRatio", FanPressureRatio);
		}

		public float CalculateThrustAtSeaLevel()
		{
			return (float)CalculatePerformanceAtSeaLevel().ThrustNet;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("burnerTemp", _burnerTemp), new XAttribute("afterburnerThrottleStart", _afterburnerThrottleStart), new XAttribute("afterburnerBaseColor", ColorUtility.ToHtmlStringRGBA(_afterburnerBaseColor)), new XAttribute("afterburnerTipColor", ColorUtility.ToHtmlStringRGBA(_afterburnerTipColor)), new XAttribute("bypassRatio", _bypassRatio), new XAttribute("compressionRatio", _compressionRatio), new XAttribute("afterburner", _hasAfterburner), new XAttribute("reverseThrust", _hasReverseThrust), new XAttribute("size", _size), new XAttribute("turbinePressureRatio", _turbinePressureRatio), new XAttribute("maxGimbalAngle", _maxGimbalAnglePercentage), new XAttribute("gimbalSpeed", _gimbalSpeed), new XAttribute("fanStyle", FanPrefab.Id), new XAttribute("inletConeStyle", InletConePrefab.Id), new XAttribute("nozzleStyle", NozzlePrefab.Id), new XAttribute("mass", _mass), new XAttribute("nozzleLength", _nozzleLength));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_gimbalSpeed":
			case "_afterburnerThrottleStart":
				return Utilities.FormatPercentage(sliderValue);
			case "_size":
				return (FanRadius * 2f).Format(UnitType.ShortDistance, solo: false, longName: false, "n2");
			case "_maxGimbalAnglePercentage":
				return string.Format("{0:n1}{1}", MaxGimbalAngle, "°");
			case "_compressionRatio":
				return $"{sliderValue:n1}x";
			case "_bypassRatio":
				return $"{sliderValue:n2}";
			case "_burnerTemp":
				return $"{sliderValue:n0}°K";
			case "_nozzleLength":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			return propertyName switch
			{
				"_fanStyleID" => FanPrefab.name, 
				"_inletConeStyleID" => InletConePrefab.name, 
				"_nozzleStyleID" => NozzlePrefab.name, 
				_ => base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value), 
			};
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_gimbalSpeed":
			case "_maxGimbalAnglePercentage":
				return () => NozzlePrefab.gimbalAngle > 0f;
			case "_afterburnerThrottleStart":
			case "_afterburnerBaseColor":
			case "_afterburnerTipColor":
				return () => _hasAfterburner;
			case "_afterburnerUnsupported":
				return () => !NozzlePrefab.supportsAfterburner;
			case "_hasAfterburner":
				return () => NozzlePrefab.supportsAfterburner;
			case "_hasReverseThrust":
				return () => JetEngineType == JetEngineType.Civilian || JetEngineType == JetEngineType.Legacy;
			case "_nozzleLength":
				return () => NozzlePrefab.supportsNozzleLength;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<JetEngineScript>();
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
			if (!UnityEngine.Input.GetKeyDown(KeyCode.Alpha0))
			{
				return;
			}
			List<JetEngineData> list = base.Part.PartScript.Aircraft.Aircraft.Assembly.Parts.Select((PartData x) => x.GetModifier<JetEngineData>()).ToList();
			AtmosphereSample atmosphereSample = Atmosphere.SampleAltitude(0f);
			float num = 0f;
			if (false)
			{
				Debug.Log("Using Cruise Altitude");
				num = 0.8f;
				atmosphereSample.AirPressure = 23842f;
				atmosphereSample.Temperature = 218.8f;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (JetEngineData item in list)
			{
				if (item != null)
				{
					item.UpdatePerformance(1f, useAfterburner: false, num, atmosphereSample.AirPressure, atmosphereSample.Temperature);
					float num2 = (float)item.MathParams.Output.ThrustNet / 1000f;
					double num3 = ((num2 > 0f) ? (item.MathParams.Output.FuelFlow / (double)num2 * 3600.0) : 0.0);
					double num4 = 0.0;
					double num5 = 0.0;
					if (item.NozzlePrefab.supportsAfterburner)
					{
						item.UpdatePerformance(1f, useAfterburner: true, num, atmosphereSample.AirPressure, atmosphereSample.Temperature);
						num4 = (float)item.MathParams.Output.ThrustNet / 1000f;
						num5 = ((num4 > 0.0) ? (item.MathParams.Output.FuelFlow / num4 * 3600.0) : 0.0);
					}
					item.CalculateMass((float)item.MathParams.Output.ThrustNet);
					item.Part.RecalculateLoadedMass(recalculateModifierMass: true);
					stringBuilder.AppendLine($"{item.Part.Name}: Diameter: {item.FanRadius:n2}m, FPR: {item.MathParams.Inputs.FanPressureRatio:n2}, CPR: {item.MathParams.Inputs.CompressorPressureRatio:n2}, bypass: {item.BypassRatio:n2}, Turbine Temp: {item._burnerTemp:n2}K, Mass: {item.Part.LoadedMass / 0.01f}kg, Dry Thrust: {num2:n1}kN, Dry TSFC: {num3:n1}, Wet Thrust: {num4:n1}kN, Wet Thrust TSFC: {num5:n1}, MassFlowCore: {item.MathParams.Output.MassFlowCore:n2}kg/s, MassFlowFan: {item.MathParams.Output.MassFlowFan:n2}kg/s, FuelFlow: {item.MathParams.Output.FuelFlow:n2}kg, Spoolup Time: {((item.ThrottleResponse > 0f) ? (1f / item.ThrottleResponse) : 0f):n2}/s");
				}
			}
			Debug.Log(stringBuilder);
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			UpdateDesignerPerformance();
			ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_burnerTemp");
			ISliderProperty property2 = genericPartPropertiesScript.GetProperty<ISliderProperty>("_bypassRatio");
			ISliderProperty property3 = genericPartPropertiesScript.GetProperty<ISliderProperty>("_compressionRatio");
			ISliderProperty property4 = genericPartPropertiesScript.GetProperty<ISliderProperty>("_size");
			property.SliderAttribute.MinValue = _burnerTempRange[0];
			property.SliderAttribute.MaxValue = _burnerTempRange[1];
			property2.SliderAttribute.MinValue = _bypassRange[0];
			property2.SliderAttribute.MaxValue = _bypassRange[1];
			property3.SliderAttribute.MinValue = _compressionRange[0];
			property3.SliderAttribute.MaxValue = _compressionRange[1];
			property4.SliderAttribute.MinValue = _sizeRange[0];
			property4.SliderAttribute.MaxValue = _sizeRange[1];
			property.SliderAttribute.NumberOfSteps = (int)((property.SliderAttribute.MaxValue - property.SliderAttribute.MinValue) / 10f) + 1;
			property2.SliderAttribute.NumberOfSteps = (int)((property2.SliderAttribute.MaxValue - property2.SliderAttribute.MinValue) / 0.01f) + 1;
			property3.SliderAttribute.NumberOfSteps = (int)((property3.SliderAttribute.MaxValue - property3.SliderAttribute.MinValue) / 0.1f) + 2;
			property4.SliderAttribute.NumberOfSteps = (int)((property4.SliderAttribute.MaxValue - property4.SliderAttribute.MinValue) / 0.01f) + 1;
			JetEnginePrefabs.JetEnginePrefab[] inletCones = Prefabs.InletCones;
			ConfigureToggleButton(genericPartPropertiesScript, "_inletConeStyleID", inletCones);
			inletCones = Prefabs.Nozzles;
			ConfigureToggleButton(genericPartPropertiesScript, "_nozzleStyleID", inletCones);
			inletCones = Prefabs.Fans;
			ConfigureToggleButton(genericPartPropertiesScript, "_fanStyleID", inletCones);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			switch (propertyName)
			{
			case "_fanStyleID":
				FanPrefab = Prefabs.GetFan(_fanStyleID, JetEngineType);
				break;
			case "_inletConeStyleID":
				InletConePrefab = Prefabs.GetInletCone(_inletConeStyleID, JetEngineType);
				break;
			case "_nozzleStyleID":
				NozzlePrefab = Prefabs.GetNozzle(_nozzleStyleID, JetEngineType);
				break;
			}
			UpdateComponents(updateStyles: true);
			UpdateDesignerPerformance();
			Designer.Instance.SetAircraftStructureChanged();
			_refreshUI = true;
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			Script.OnModifiersCreated();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_burnerTemp = stateElement.GetFloatAttribute("burnerTemp", _burnerTemp);
			_afterburnerThrottleStart = stateElement.GetFloatAttribute("afterburnerThrottleStart", _afterburnerThrottleStart);
			_afterburnerBaseColor = stateElement.GetHtmlColorAttribute("afterburnerBaseColor", _afterburnerBaseColor);
			_afterburnerTipColor = stateElement.GetHtmlColorAttribute("afterburnerTipColor", _afterburnerTipColor);
			_bypassRatio = stateElement.GetFloatAttribute("bypassRatio", _bypassRatio);
			_compressionRatio = stateElement.GetFloatAttribute("compressionRatio", _compressionRatio);
			_hasAfterburner = stateElement.GetBoolAttribute("afterburner", _hasAfterburner);
			_hasReverseThrust = stateElement.GetBoolAttribute("reverseThrust", _hasReverseThrust);
			_size = stateElement.GetFloatAttribute("size", _size);
			_turbinePressureRatio = stateElement.GetFloatAttribute("turbinePressureRatio", _turbinePressureRatio);
			_gimbalSpeed = stateElement.GetFloatAttribute("gimbalSpeed", _gimbalSpeed);
			_maxGimbalAnglePercentage = stateElement.GetFloatAttribute("maxGimbalAngle", _maxGimbalAnglePercentage);
			_mass = stateElement.GetFloatAttribute("mass");
			string stringAttribute = stateElement.GetStringAttribute("fanStyle");
			FanPrefab = Prefabs.GetFan(stringAttribute, JetEngineType);
			_fanStyleID = FanPrefab.Id;
			string stringAttribute2 = stateElement.GetStringAttribute("inletConeStyle");
			InletConePrefab = Prefabs.GetInletCone(stringAttribute2, JetEngineType);
			_inletConeStyleID = InletConePrefab.Id;
			string stringAttribute3 = stateElement.GetStringAttribute("nozzleStyle");
			NozzlePrefab = Prefabs.GetNozzle(stringAttribute3, JetEngineType);
			_nozzleStyleID = NozzlePrefab.Id;
			_nozzleLength = stateElement.GetFloatAttribute("nozzleLength", _nozzleLength);
			if (_mass == 0f)
			{
				JetEngineMath.Outputs outputs = CalculatePerformanceAtSeaLevel();
				CalculateMass((float)outputs.ThrustNet);
			}
		}

		public void UpdatePerformance(float throttle, bool useAfterburner, double machNumber, double ambientPressure, double ambientTemperature)
		{
			JetEngineMath.Inputs inputs = MathParams.Inputs;
			inputs.AfterburnerTemp = Mathf.Max(2200f, _burnerTemp + 200f);
			inputs.BurnerTemp = _burnerTemp;
			inputs.FanPressureRatio = FanPressureRatio;
			inputs.TurbinePressureRatio = TurbinePressureRatio;
			inputs.BypassRatio = BypassRatio;
			float num = 0.09f * Mathf.Min(_size, 1f);
			float num2 = Mathf.Max(0.05f, FanRadius - num);
			float num3 = Mathf.Sqrt(num2 * num2 / (BypassRatio + 1f));
			inputs.CoreInletArea = (double)(num3 * num3) * Math.PI;
			inputs.CompressorPressureRatio = CompressionRatio;
			inputs.AmbientTemperature = ambientTemperature;
			inputs.AmbientPressure = ambientPressure;
			inputs.Throttle = 1.0;
			inputs.MachNumber = machNumber;
			if (useAfterburner)
			{
				float afterburnerThrottleStart = AfterburnerThrottleStart;
				inputs.ThrottleAfterburner = Mathf.Clamp01((throttle - afterburnerThrottleStart) / (1f - afterburnerThrottleStart));
			}
			else
			{
				inputs.ThrottleAfterburner = 0.0;
			}
			JetEngineMath.ProcessParams(MathParams);
		}

		private void CalculateMass(float thrust)
		{
			float coreRadius = CoreRadius;
			float num = MathF.PI * coreRadius * coreRadius;
			float num2 = 1f + Mathf.Max(0f, (_burnerTemp - 1388f) / 2500f);
			float num3 = Mathf.Sqrt(Mathf.Max(0f, BypassRatio - 1f));
			float num4 = 145f * (1f + num3 * 1.4f);
			float num5 = 360f * (1f + num3 * 0.5f) * num2;
			float num6 = 0f;
			float num7 = FanArea * 0.5f;
			num6 += num7 * num4;
			float num8 = num * (3.276f + CompressorLength);
			num6 += num8 * num5;
			if (HasAfterburner)
			{
				float num9 = num * 2.364f;
				num6 += num9 * 150f;
			}
			float num10 = num * 2.155f;
			num6 += num10 * 250f;
			_mass = num6 * 0.01f;
		}

		private JetEngineMath.Outputs CalculatePerformanceAtSeaLevel(bool afterburner = true)
		{
			AtmosphereSample atmosphereSample = Atmosphere.SampleAltitude(0f);
			UpdatePerformance(1f, HasAfterburner && afterburner, 0.0, atmosphereSample.AirPressure, atmosphereSample.Temperature);
			return MathParams.Output;
		}

		private void ConfigureToggleButton(IGenericPartProperties genericPartPropertiesScript, string propertyName, JetEnginePrefabs.JetEnginePrefab[] prefabs)
		{
			ToggleButtonProperty property = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>(propertyName);
			property.ButtonAttribute.Values.Clear();
			property.ButtonAttribute.Values.AddRange(from x in prefabs
				where x.supportedJetEngineTypes.HasFlag(JetEngineType)
				orderby x.Id
				select x.Id);
		}

		private void UpdateComponents(bool updateStyles = false)
		{
			Script.UpdateComponentsInDesigner(updateStyles);
		}

		private void UpdateDesignerPerformance()
		{
			CalculatePerformanceAtSeaLevel(afterburner: false);
			float num = (float)MathParams.Output.ThrustNet;
			float num2 = (float)MathParams.Output.FuelFlow;
			JetEngineMath.Outputs outputs = CalculatePerformanceAtSeaLevel();
			CalculateMass((float)outputs.ThrustNet);
			base.Part.RecalculateLoadedMass(recalculateModifierMass: true);
			if (HasAfterburner)
			{
				_designerThrust = Units.GetForceString(num) + " | " + Units.GetForceString((float)outputs.ThrustNet);
				_designerFuelUsage = Units.GetMassFlowRateString(num2) + " | " + Units.GetMassFlowRateString((float)outputs.FuelFlow);
			}
			else
			{
				_designerThrust = Units.GetForceString((float)outputs.ThrustNet);
				_designerFuelUsage = Units.GetMassFlowRateString((float)outputs.FuelFlow);
			}
		}
	}
}
