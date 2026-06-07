using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;
using ModApi.Design;
using ModApi.Flight;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class JetEngineScript : PartModifierScript<JetEngineData>, IReactionEngine, IAnalyzePerformance, IDesignerStart, IGameLoopItem, IFlightStart, IFlightUpdate, IFlightFixedUpdate, IDesignerLateUpdate
	{
		private class AttachPointSnapshot
		{
			public AttachPoint AttachPoint { get; set; }

			public Vector3 DeltaPosition => WorldPosition - AttachPoint.AttachPointScript.transform.position;

			public Vector3 WorldPosition { get; private set; }

			public AttachPointSnapshot(AttachPoint attachPoint)
			{
				AttachPoint = attachPoint;
				WorldPosition = attachPoint.AttachPointScript.transform.position;
			}
		}

		private const float MaxMachNumber = 1.5f;

		private float _afterburnerThrottle;

		private AttachPoint _attachPointTop;

		private IInputController _brakeInput;

		private float _brakeValue;

		private float _currentIsp;

		private float _currentMassFlowRate;

		private EngineCommon _engineCommon;

		private FuselageScript _fuselage;

		private float _inletEfficiency;

		private float _inverseFuelDensity;

		private JetEngineComponentsScript _jetComponents;

		private JetEngineMath.Params _mathParams = new JetEngineMath.Params();

		private IExhaustSystem[] _previewExhaustSystems;

		private float _requiredAirArea;

		private float _thrustCore;

		private float _thrustCurrent;

		private float _thrustFan;

		private float _thrustMax;

		float IReactionEngine.CurrentMassFlowRate => _currentMassFlowRate;

		float IReactionEngine.CurrentThrust => _thrustCurrent;

		public InletAir DirectAir { get; private set; }

		public IFuelSource FuelSource => _engineCommon.FuelSource;

		IFuelSource IReactionEngine.FuelSource => _engineCommon.FuelSource;

		bool IReactionEngine.IsActive => _engineCommon.Active;

		public float MaximumMassFlowRate { get; private set; }

		float IReactionEngine.MaximumThrust => _thrustMax;

		PartData IReactionEngine.Part => base.PartScript.Data;

		public bool PreviewExhaust { get; set; }

		float IReactionEngine.RemainingFuel => (float)(FuelSource.TotalFuel * (double)FuelSource.FuelType.Density);

		public bool SupportsWarpBurn => false;

		public float ThrottleResponse => _engineCommon.ThrottleResponse;

		public bool UsesMachNumber => true;

		public void CalculateDesignerPerformance()
		{
			IPerformanceAnalysis performanceAnalysis = Game.Instance.Designer.PerformanceAnalysis;
			AtmosphereSample atmosphereSample = performanceAnalysis.AtmosphereSample;
			float num = Mathf.Clamp(performanceAnalysis.MachNumber, 0f, 1.5f);
			UpdatePerformance(1f, num, atmosphereSample.AirPressure, atmosphereSample.Temperature);
		}

		void IDesignerLateUpdate.DesignerLateUpdate(in DesignerFrameData frame)
		{
			if (PreviewExhaust && base.Data.HasAfterburner)
			{
				if (_previewExhaustSystems == null)
				{
					_previewExhaustSystems = GetComponentsInChildren<IExhaustSystem>(includeInactive: true);
				}
				base.gameObject.GetComponentInChildren<VariableNozzleAnimationScript>()?.SetExpansion(1f, animate: false);
				IExhaustSystem[] previewExhaustSystems = _previewExhaustSystems;
				foreach (IExhaustSystem obj in previewExhaustSystems)
				{
					obj.SetActive(active: true);
					obj.UpdateExhaust(1f);
				}
			}
			else if (_previewExhaustSystems != null)
			{
				DisableExhaustPreview();
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			Game.Instance.Designer.PerformanceAnalysis.EnvironmentChanged += OnPerformanceAnalysisEnvironmentChanged;
			CalculateDesignerPerformance();
			_brakeInput = GetInputController("Thrust Reverse");
			VisibilityBrake(base.Data.HasReverseThrust);
		}

		public override void FlightEnd()
		{
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (base.PartScript.CraftScript.AtmosphereSample.AirDensity > 0f && _inletEfficiency > 0f)
			{
				float temperature = base.PartScript.CraftScript.AtmosphereSample.Temperature;
				float num = _inletEfficiency * base.PartScript.CraftScript.AtmosphereSample.AirPressure;
				float num2 = Mathf.Clamp(base.PartScript.BodyScript.MachNumber, 0f, 1.5f);
				UpdatePerformance(_engineCommon.EngineThrottle, num2, num, temperature);
				_engineCommon.FuelConsumptionRate = _currentMassFlowRate * _inverseFuelDensity;
				_engineCommon.ElectricalConsumptionRate = 0f;
				if (_brakeValue > 0f)
				{
					_thrustCurrent *= (0f - _brakeValue) * Mathf.Clamp01(num2 * 4f) * 0.5f;
				}
			}
			else
			{
				_afterburnerThrottle = 0f;
				_thrustCurrent = 0f;
				_thrustMax = 0f;
				_thrustCore = 0f;
				_thrustFan = 0f;
				_currentIsp = 0f;
				_currentMassFlowRate = 0f;
				_engineCommon.FuelConsumptionRate = 0f;
				_engineCommon.ElectricalConsumptionRate = 0f;
			}
			_engineCommon.FlightFixedUpdate(_thrustCurrent, 0f);
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			DirectAir = new InletAir();
			_engineCommon.OnFlightStart();
			_engineCommon.ThrottleResponse = base.Data.ThrottleResponse;
			_requiredAirArea = base.Data.FanArea * 0.75f;
			ConfigureAudio();
			_inverseFuelDensity = 1f / FuelSource.FuelType.Density;
			_mathParams.Inputs.BypassRatio = base.Data.BypassRatio;
			_mathParams.Inputs.CoreInletArea = (double)(base.Data.CoreRadius * base.Data.CoreRadius) * Math.PI;
			_mathParams.Inputs.CompressorPressureRatio = base.Data.CompressionRatio;
			_brakeInput = GetInputController("Thrust Reverse");
			if (base.PartScript.Data.Activated)
			{
				OnActivated();
			}
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_engineCommon.FlightUpdate();
			if (frame.IsWarping && base.PartScript.Data.Activated)
			{
				_engineCommon.EngineThrottle = 0f;
				_engineCommon.ElectricalConsumptionRate = 0f;
				_engineCommon.FuelConsumptionRate = 0f;
				_afterburnerThrottle = 0f;
			}
			if (_brakeInput != null && base.Data.HasReverseThrust)
			{
				_brakeValue = Utilities.StepTowards(_brakeValue, base.Data.ThrottleResponse * 0.2f, _brakeInput.Value);
			}
			if (_brakeValue > 0f)
			{
				float targetVolume = _brakeValue * _engineCommon.EngineThrottle;
				_jetComponents.AfterburnerAudio.UpdateLoopAudio(targetVolume, 1.5f);
			}
			else if (base.Data.HasAfterburner)
			{
				float targetVolume2 = 0f;
				if (_afterburnerThrottle > 0f)
				{
					targetVolume2 = Mathf.Lerp(0.5f, 1f, _afterburnerThrottle);
				}
				_jetComponents.AfterburnerAudio.UpdateLoopAudio(targetVolume2);
			}
			_jetComponents.AnimateComponents(_engineCommon.Active, _engineCommon.EngineThrottle);
			if (base.PartScript.Data.Activated)
			{
				float num = _requiredAirArea - DirectAir.AvailableAir;
				if (num > 0f)
				{
					base.PartScript.CraftScript.InletAir.UseAir(num);
					float num2 = Mathf.Clamp01(DirectAir.AvailableAir / _requiredAirArea);
					_inletEfficiency = num2 * 1f + (1f - num2) * base.PartScript.CraftScript.InletAir.AirEfficiency;
				}
				else
				{
					_inletEfficiency = 1f;
				}
			}
			DirectAir.Update();
		}

		public override void OnActivated()
		{
			_engineCommon.OnActivated();
			if (base.Data.HasAfterburner)
			{
				_jetComponents.AfterburnerAudio.Initialize();
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			if (base.PartScript.CommandPod != null)
			{
				_engineCommon.FuelSource = base.PartScript.CommandPod.JetFuelSource;
			}
			else
			{
				_engineCommon.FuelSource = EmptyFuelSource.GetOrCreate(FuelType.Jet);
			}
			if (Game.InFlightScene)
			{
				_engineCommon.OnCraftStructureChanged(craftScript);
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			GroupModel groupModel = new GroupModel("Performance");
			model.AddGroup(groupModel);
			GenerateInspectorModel(groupModel, flightScene: true);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			GenerateInspectorModel(groupModel, flightScene: false);
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			_engineCommon = new EngineCommon(this, 0f, 0f);
			_engineCommon.ExhaustThrottleOverride = () => _afterburnerThrottle;
			_engineCommon.DistortionIntensity = () => _engineCommon.EngineThrottle;
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			base.OnSymmetry(mode, originalPart, created);
			_jetComponents.UpdateComponents();
		}

		public void UpdateComponentsInDesigner(bool updateStyles)
		{
			if (_previewExhaustSystems != null)
			{
				DisableExhaustPreview();
			}
			AttachPointSnapshot attachPointSnapshot = SaveAttachPointSnapshot();
			_jetComponents.UpdateComponents();
			if (updateStyles)
			{
				_jetComponents.UpdateStyles();
			}
			if (attachPointSnapshot != null)
			{
				base.PartScript.Transform.position += attachPointSnapshot.DeltaPosition;
			}
			Symmetry.SynchronizePartModifiers(base.PartScript);
			Symmetry.UpdatePartPositions(new List<IPartScript> { base.PartScript });
		}

		public override void ValidatePart(ValidationResult result)
		{
			_engineCommon.ValidatePart(result);
		}

		public void VisibilityBrake(bool visible)
		{
			if (_brakeInput != null && _brakeInput.Visible != visible)
			{
				_brakeInput.Visible = visible;
			}
		}

		protected virtual void OnDestroy()
		{
			if (Game.InDesignerScene)
			{
				Game.Instance.Designer.PerformanceAnalysis.EnvironmentChanged -= OnPerformanceAnalysisEnvironmentChanged;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_attachPointTop = base.PartScript.Data.GetAttachPoint("AttachPointTopLoad");
			_fuselage = base.PartScript.GetModifier<FuselageScript>();
			_fuselage.UpdateAttachPointRotatePosition = false;
			_jetComponents = GetComponent<JetEngineComponentsScript>();
			_jetComponents.Initialize(this, _fuselage);
			base.Data.CalculateMassAndPrice();
		}

		private static string GetStationString(double pressure, double temperature)
		{
			return $"{pressure / 1000.0:n0}kPa {temperature:n0}K";
		}

		private JetEngineMath.Params CalculateDesignerPerformance(double airPressure, double airTemperature, double machNumber)
		{
			JetEngineMath.Params obj = new JetEngineMath.Params
			{
				Inputs = 
				{
					AmbientTemperature = airTemperature,
					AmbientPressure = airPressure,
					BypassRatio = base.Data.BypassRatio,
					CompressorPressureRatio = base.Data.CompressionRatio,
					CoreInletArea = (double)(base.Data.CoreRadius * base.Data.CoreRadius) * Math.PI,
					MachNumber = machNumber,
					Throttle = 1.0,
					ThrottleAfterburner = (base.Data.HasAfterburner ? 1f : 0f)
				}
			};
			JetEngineMath.ProcessParams(obj);
			return obj;
		}

		private void ConfigureAudio()
		{
			float t = 0.5f * (base.Data.CoreRadius - 0.25f);
			float basePitch = Mathf.Lerp(2f, 0.5f, t);
			float baseVolume = Mathf.Lerp(0.5f, 1f, t);
			float distanceScale = Mathf.Lerp(0.25f, 1f, t);
			_engineCommon.Audio.Configure(basePitch, baseVolume, distanceScale);
			_engineCommon.Audio.LerpRate = 1f;
			_engineCommon.PlayAudioWhileIdle = true;
			_jetComponents.AfterburnerAudio.Configure(basePitch, baseVolume, distanceScale);
		}

		private void DisableExhaustPreview()
		{
			base.gameObject.GetComponentInChildren<VariableNozzleAnimationScript>()?.SetExpansion(0f, animate: false);
			IExhaustSystem[] previewExhaustSystems = _previewExhaustSystems;
			for (int i = 0; i < previewExhaustSystems.Length; i++)
			{
				previewExhaustSystems[i].SetActive(active: false);
			}
			_previewExhaustSystems = null;
		}

		private void GenerateInspectorModel(GroupModel model, bool flightScene)
		{
			_ = _mathParams.Output;
			model.Add(new TextModel("Thrust", () => Units.GetForceString(_thrustCurrent)));
			model.Add(new TextModel("Core Thrust", () => Units.GetForceString(_thrustCore)));
			model.Add(new TextModel("Fan Thrust", () => Units.GetForceString(_thrustFan)));
			model.Add(new TextModel("Isp", () => Units.GetIspString(_currentIsp)));
			model.Add(new TextModel("Fuel Usage", () => Units.GetMassFlowRateString(_currentMassFlowRate)));
			if (flightScene)
			{
				model.Add(new TextModel("Inlet Efficiency", () => GetInletEfficiency()));
				model.Add(new TextModel("Afterburner", () => Units.GetPercentageString(_afterburnerThrottle)));
			}
		}

		private string GetInletEfficiency()
		{
			if (base.PartScript.Data.Activated)
			{
				return Units.GetPercentageString(_inletEfficiency);
			}
			return "N/A";
		}

		private void OnPerformanceAnalysisEnvironmentChanged(object sender, EventArgs e)
		{
			CalculateDesignerPerformance();
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			_engineCommon.OnTimeMultiplierModeChanged(e);
		}

		private AttachPointSnapshot SaveAttachPointSnapshot()
		{
			if (_attachPointTop.NumPartConnections > 0)
			{
				AttachPoint attachPointRotate = _fuselage.AttachPointRotate;
				if (attachPointRotate != null && attachPointRotate.NumPartConnections == 0)
				{
					return new AttachPointSnapshot(_attachPointTop);
				}
			}
			if (_attachPointTop.NumPartConnections == 0)
			{
				AttachPoint attachPointRotate2 = _fuselage.AttachPointRotate;
				if (attachPointRotate2 != null && attachPointRotate2.NumPartConnections > 0)
				{
					return new AttachPointSnapshot(_fuselage.AttachPointRotate);
				}
			}
			return null;
		}

		private void UpdatePerformance(float throttle, double machNumber, double ambientPressure, double ambientTemperature)
		{
			JetEngineMath.Inputs inputs = _mathParams.Inputs;
			inputs.AfterburnerTemp = ((base.Data.OverrideAfterBurnerTemp < 0f) ? 2000f : base.Data.OverrideAfterBurnerTemp);
			inputs.BurnerTemp = ((base.Data.OverrideBurnerTemp < 0f) ? 1388f : base.Data.OverrideBurnerTemp);
			inputs.FanPressureRatio = ((base.Data.OverrideFanPressureRatio < 0f) ? 1.5 : ((double)base.Data.OverrideFanPressureRatio));
			inputs.BypassRatio = base.Data.BypassRatio;
			inputs.CoreInletArea = (double)(base.Data.CoreRadius * base.Data.CoreRadius) * Math.PI;
			inputs.CompressorPressureRatio = base.Data.CompressionRatio;
			inputs.AmbientTemperature = ambientTemperature;
			inputs.AmbientPressure = ambientPressure;
			inputs.Throttle = 1.0;
			inputs.MachNumber = machNumber;
			if (base.Data.HasAfterburner)
			{
				if (_brakeValue > 0f)
				{
					_afterburnerThrottle = 0f;
				}
				else
				{
					float afterburnerThrottleStart = base.Data.AfterburnerThrottleStart;
					_afterburnerThrottle = Mathf.Clamp01((throttle - afterburnerThrottleStart) / (1f - afterburnerThrottleStart));
				}
				inputs.ThrottleAfterburner = _afterburnerThrottle;
			}
			else
			{
				inputs.ThrottleAfterburner = 0.0;
			}
			JetEngineMath.ProcessParams(_mathParams);
			_thrustMax = _mathParams.Output.ThrustNetScaled;
			_thrustCurrent = _thrustMax * throttle;
			_thrustCore = (float)_mathParams.Output.ThrustCore * 0.01f * throttle;
			_thrustFan = (float)_mathParams.Output.ThrustFan * 0.01f * throttle;
			MaximumMassFlowRate = (float)_mathParams.Output.FuelFlow;
			_currentMassFlowRate = MaximumMassFlowRate * throttle;
			_currentIsp = MathUtils.CalculateIsp(_thrustCurrent * 100f, _currentMassFlowRate);
		}
	}
}
