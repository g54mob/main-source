using System;
using System.Collections.Generic;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Design;
using ModApi.Flight;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class RocketEngineScript : PartModifierScript<RocketEngineData>, IReactionEngine, IAnalyzePerformance, IDesignerStart, IGameLoopItem, IFlightStart, IFlightUpdate, IFlightFixedUpdate, IDesignerUpdate, IFlightPostStart
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

		private AttachPoint _attachPointTop;

		private float _currentIsp;

		private float _currentMassFlowRate;

		private float _electricalConsumption;

		private EngineCommon _engineCommon;

		private RocketEngineComponentsScript _engineComponents;

		private FlightSceneUiController _flightSceneUiController;

		private float _fuelLitersPerKilogram;

		private FuelTankScript _fuelTank;

		private bool _hasBeenActivated;

		private bool _inFlightScene;

		private float _maxThrottle = 1f;

		private RocketEngineMath.Params _params = new RocketEngineMath.Params();

		private IExhaustSystem[] _previewExhaustSystems;

		private IInputController _throttleInput;

		private float _thrustCurrent;

		private float _thrustMax;

		float IReactionEngine.CurrentMassFlowRate => _currentMassFlowRate;

		float IReactionEngine.CurrentThrust => _thrustCurrent;

		public IFuelSource FuelSource => _engineCommon.FuelSource;

		IFuelSource IReactionEngine.FuelSource => _engineCommon.FuelSource;

		bool IReactionEngine.IsActive => _engineCommon.Active;

		public float MaximumMassFlowRate { get; private set; }

		float IReactionEngine.MaximumThrust => _thrustMax;

		PartData IReactionEngine.Part => base.PartScript.Data;

		public bool PreviewExhaust { get; set; }

		float IReactionEngine.RemainingFuel => (float)(FuelSource.TotalFuel * (double)FuelSource.FuelType.Density);

		public RocketEngineMath.StaticPerformance StaticPerformance => _params.Static;

		public bool SupportsWarpBurn => base.Data.SupportsWarpBurn;

		public float ThrottleResponse => _engineCommon.ThrottleResponse;

		public bool UsesMachNumber => false;

		private FuelTankScript FuelTank
		{
			get
			{
				return _fuelTank;
			}
			set
			{
				if (_fuelTank != value)
				{
					if (_inFlightScene && _fuelTank != null)
					{
						_fuelTank.CraftFuelSourceChanged -= OnCraftFuelSourceChanged;
					}
					_fuelTank = value;
					if (_inFlightScene && _fuelTank != null)
					{
						_fuelTank.CraftFuelSourceChanged += OnCraftFuelSourceChanged;
					}
				}
			}
		}

		private double PerformanceAnalysisAirPressure => (Game.Instance.Designer?.PerformanceAnalysis?.AtmosphereSample.AirPressure).GetValueOrDefault();

		public void CalculateDesignerPerformance()
		{
			InitializeRocketParameters();
			CalculateRocketPerformance(PerformanceAnalysisAirPressure, 1f);
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			Game.Instance.Designer.PerformanceAnalysis.EnvironmentChanged += OnPerformanceAnalysisEnvironmentChanged;
			InitializeExhaust();
			_throttleInput = GetInputController("Throttle");
			VisibilityThrottle(base.Data.EngineType.FuelGrains.Count == 0);
		}

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			if (PreviewExhaust)
			{
				if (_previewExhaustSystems == null)
				{
					_previewExhaustSystems = GetComponentsInChildren<IExhaustSystem>(includeInactive: true);
				}
				UpdateExhaustExpansionRatio(Game.Instance.Designer.PerformanceAnalysis.AtmosphereSample.AirPressure, Time.deltaTime);
				IExhaustSystem[] previewExhaustSystems = _previewExhaustSystems;
				foreach (IExhaustSystem obj in previewExhaustSystems)
				{
					obj.SetActive(active: true);
					obj.UpdateExhaust(1f);
				}
			}
			else if (_previewExhaustSystems != null)
			{
				IExhaustSystem[] previewExhaustSystems = _previewExhaustSystems;
				for (int i = 0; i < previewExhaustSystems.Length; i++)
				{
					previewExhaustSystems[i].SetActive(active: false);
				}
				_previewExhaustSystems = null;
			}
		}

		public override void FlightEnd()
		{
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			float num = AdjustedThrottle();
			if (!base.Data.Ignited && num > 0f && base.Data.IgnitionsMax > 0)
			{
				if (base.Data.IgnitionsMax > base.Data.IgnitionsUsed)
				{
					base.Data.IgnitionsUsed++;
					base.Data.Ignited = true;
				}
				else
				{
					base.PartScript.Data.Activated = false;
					base.PartScript.Data.Config.SupportsActivation = false;
					_flightSceneUiController.RegeneratePartInspectorPanel(base.PartScript, createIfClosed: false);
					LoopingAudioScript audio = _engineCommon.Audio;
					audio.PlayStopSound(audio.LoopVolume, audio.BasePitch);
					num = 0f;
				}
			}
			float airPressure = base.PartScript.CraftScript.AtmosphereSample.AirPressure;
			CalculateRocketPerformance(airPressure, num);
			base.PartScript.TakeDamage((Mathf.Clamp01(num - 1f) * 10f + 0f) * frame.DeltaTime, PartDamageType.Heat);
			_engineCommon.FuelConsumptionRate = _currentMassFlowRate * _fuelLitersPerKilogram;
			_engineCommon.ElectricalConsumptionRate = _electricalConsumption;
			_engineCommon.FlightFixedUpdate(_thrustCurrent, 0f);
			if (_thrustCurrent == 0f)
			{
				base.Data.Ignited = false;
			}
		}

		void IFlightPostStart.FlightPostStart(in FlightFrameData frame)
		{
			if (base.Data.Ignited)
			{
				_engineCommon.UpdateInputs(immediateThrottle: true);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			InitializeExhaust();
			_engineCommon.OnFlightStart();
			_engineCommon.ThrottleResponse = ((base.Data.ThrottleResponse > 0f) ? base.Data.ThrottleResponse : base.Data.EngineType.ThrottleResponse);
			_engineCommon.MinThrottle = ((base.Data.MinThrottleOverride < 0f) ? base.Data.EngineType.MinThrottle : base.Data.MinThrottleOverride);
			_engineCommon.SupportsDeactivation = base.Data.EngineType.SupportsDeactivation;
			_fuelLitersPerKilogram = 1f / FuelSource.FuelType.Density;
			ConfigureAudio();
			if (base.PartScript.Data.Activated)
			{
				OnActivated();
			}
			_engineComponents.FlightStart();
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
			_flightSceneUiController = (Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript).UiController;
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			float num = Mathf.Min(1f, AdjustedThrottle());
			float num2 = 0f;
			if (base.PartScript.Data.Activated)
			{
				if (frame.IsWarping && !base.Data.SupportsWarpBurn)
				{
					_engineCommon.EngineThrottle = 0f;
					_engineCommon.ElectricalConsumptionRate = 0f;
					_engineCommon.FuelConsumptionRate = 0f;
				}
				else if (_engineComponents.ExhaustSystem != null)
				{
					if (frame.IsWarping)
					{
						ProcessWarpMode(in frame);
					}
					UpdateExhaustExpansionRatio(base.PartScript.CraftScript.AtmosphereSample.AirPressure, frame.DeltaTime);
					if (base.PartScript.WaterPhysics.UnderWaterAmount > 0f)
					{
						_engineComponents.SmokeTrail.SpeedOverride = 0.1f * base.Data.SmokeSpeed;
						_engineComponents.SmokeTrail.Color = Color.white;
						num2 = 1f;
					}
					else if (base.Data.HasSmoke)
					{
						_engineComponents.SmokeTrail.SpeedOverride = base.Data.SmokeSpeed;
						_engineComponents.SmokeTrail.Color = base.Data.SmokeColor;
						num2 = Mathf.Clamp01(1f - 3f * _engineComponents.ExhaustSystem.ExpansionRatio / _engineComponents.ExhaustSystem.MaxExpansionRatio);
					}
				}
				_engineComponents.UpdateActuators();
			}
			if ((base.PartScript.Data.Activated && num > 0f) || _hasBeenActivated)
			{
				_hasBeenActivated = true;
				_engineComponents.UpdateSmokePosition();
				_engineCommon.FlightUpdate(num2 * num * num, num, Mathf.Max(1f, 0.5f * _engineComponents.ExhaustSystem.ExpansionRatio));
			}
		}

		public void InitializeExhaust()
		{
			ExhaustSystemScript exhaustSystem = _engineComponents.ExhaustSystem;
			float num = (float)_params.Static.MassFlow;
			float num2 = (float)_params.Dynamic.ExitMachNumber;
			float num3 = 1f;
			if (base.Data.AltitudeCompensation > 0f)
			{
				num2 = 6f;
			}
			else
			{
				float nozzleExitRadius = base.Data.NozzleExitRadius;
				if (nozzleExitRadius > 0f)
				{
					num3 = Mathf.Min(base.Data.NozzleThroatRadius / nozzleExitRadius, 1f);
				}
			}
			float num4 = Mathf.Clamp(100f * num3, 4f, 100f);
			exhaustSystem.MaxExpansionRatio = ((base.Data.ExhaustExpansionRange.y > 0f && base.Data.ExhaustExpansionRange.y < num4) ? base.Data.ExhaustExpansionRange.y : num4);
			Color exhaustColor = base.Data.ExhaustColor;
			exhaustSystem.Alpha = exhaustColor.a * Mathf.Clamp01(0.05f + num * 0.1f / base.Data.NozzleExitRadius);
			exhaustColor.a = 1f;
			exhaustSystem.Color = exhaustColor;
			exhaustSystem.ColorExpanded = base.Data.ExhaustColorExpanded;
			exhaustSystem.ColorTip = base.Data.ExhaustColorTip;
			exhaustSystem.ColorShock = base.Data.ExhaustColorShock;
			exhaustSystem.ColorFlame = base.Data.ExhaustColorFlame;
			exhaustSystem.ColorSoot = base.Data.ExhaustColorSoot;
			float num5 = Mathf.Lerp(2f, 7.5f, num * 0.0004f);
			exhaustSystem.ExhaustLength = exhaustSystem.NozzleRadius * (1f + num2 * 1.1f) * (1f + num5 * 1.1f) * base.Data.ExhaustScale;
			exhaustSystem.ExhaustBendLength = Mathf.Sqrt(base.Data.Scale) * (-0.04f + 0.07f * base.Data.ExtensionSize / base.Data.Scale);
			exhaustSystem.ExhaustBend = base.Data.NozzleType.ExhaustBend;
			exhaustSystem.ExhaustOffset = base.Data.ExhaustOffset;
			exhaustSystem.ShockIntensity = ((base.Data.ExhaustShockIntensity < 0f) ? base.Data.FuelType.ShockIntensity : base.Data.ExhaustShockIntensity);
			exhaustSystem.GlobalIntensity = ((base.Data.ExhaustGlobalIntensity < 0f) ? base.Data.FuelType.GlobalIntensity : base.Data.ExhaustGlobalIntensity);
			exhaustSystem.ShockDirection = base.Data.NozzleType.ShockDirection + base.Data.ExhaustShockDirectionOffset;
			exhaustSystem.RimShade = ((base.Data.ExhaustRimShade < 0f) ? base.Data.FuelType.RimShade : base.Data.ExhaustRimShade);
			exhaustSystem.SootLength = base.Data.ExhaustSootLength;
			exhaustSystem.SootIntensity = base.Data.ExhaustSootIntensity;
			exhaustSystem.TextureIntensity = base.Data.ExhaustTextureStrength;
			exhaustSystem.NozzleShine = base.Data.NozzleDiscStrength;
			exhaustSystem.SetUp();
			if (_engineComponents.SmokeTrail != null)
			{
				_engineComponents.SmokeTrail.Color = base.Data.SmokeColor;
				_engineComponents.SmokeTrail.SpeedOverride = base.Data.SmokeSpeed;
			}
		}

		public override void OnActivated()
		{
			if (!_engineCommon.SupportsDeactivation && base.Data.Part.Config.SupportsActivation)
			{
				base.Data.Part.Config.SupportsActivation = false;
				_flightSceneUiController.RegeneratePartInspectorPanel(base.PartScript, createIfClosed: false);
			}
			if (_engineCommon.HasFuel)
			{
				_engineCommon.OnActivated();
			}
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			FuelTankData fuelTank = EngineUtilities.GetFuelTank(base.PartScript, 0, base.Data.FuelType);
			if (fuelTank != null && fuelTank.AutoFuelType)
			{
				EngineUtilities.UpdateAutoFuelTypeFuelTanks(fuelTank, base.Data.FuelType);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			FuelTank = EngineUtilities.GetFuelTank(base.PartScript, 0, base.Data.FuelType)?.Script;
			RefreshFuelSource();
			if (Game.InFlightScene)
			{
				_engineCommon.OnCraftStructureChanged(craftScript);
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			GroupModel groupModel = new GroupModel("Performance");
			model.AddGroup(groupModel);
			CreateInspectorModel(groupModel, () => AdjustedThrottle(), flight: true);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			CreateInspectorModel(groupModel, () => 1f, flight: false);
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			_engineCommon = new EngineCommon(this, base.Data.GimbalRange * base.Data.EngineType.GimbalRange, base.Data.EngineType.GimbalSpeed);
			OnTypeChange();
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			FuelTank = null;
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			base.OnSymmetry(mode, originalPart, created);
			base.Data.OnSymmetry(originalPart);
			UpdateComponentsInDesigner(updateFuel: false, updateSymmetricParts: false);
		}

		public void OnTypeChange()
		{
			_engineCommon.RequiresElectricity = ((base.Data.WattsPerFuelFlowOverride == -1f) ? base.Data.EngineType.WattsPerMassFlow : base.Data.WattsPerFuelFlowOverride) > 0f;
			_engineCommon.ThrottleResponse = ((base.Data.ThrottleResponse > 0f) ? base.Data.ThrottleResponse : base.Data.EngineType.ThrottleResponse);
		}

		public void UpdateAutoFuelTypeFuelTanks()
		{
			EngineUtilities.UpdateAutoFuelTypeFuelTanks(FuelTank?.Data, base.Data.FuelType);
		}

		public void UpdateComponentsInDesigner(bool updateFuel, bool updateSymmetricParts)
		{
			base.Data.UpdateEngineType(updateFuel);
			OnTypeChange();
			CalculateDesignerPerformance();
			CalculateMassAndPrice();
			AttachPointSnapshot attachPointSnapshot = (updateSymmetricParts ? SaveAttachPointSnapshot() : null);
			_engineComponents.UpdateComponents();
			UpdateAttachPointRadius();
			if (updateSymmetricParts)
			{
				if (attachPointSnapshot != null)
				{
					base.PartScript.Transform.position += attachPointSnapshot.DeltaPosition;
				}
				Symmetry.SynchronizePartModifiers(base.PartScript);
				Symmetry.UpdatePartPositions(new List<IPartScript> { base.PartScript });
				Symmetry.ExecuteOnSymmetricPartModifiers(base.Data, includeSourceModifier: false, delegate(RocketEngineData x)
				{
					x.Script.InitializeExhaust();
				});
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.MassFlowRateOverride != 0f)
			{
				_engineCommon.ValidatePart(result);
			}
		}

		public void VisibilityThrottle(bool visible)
		{
			if (_throttleInput != null && _throttleInput.Visible != visible)
			{
				_throttleInput.Visible = visible;
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
			_attachPointTop = base.PartScript.Data.GetAttachPoint("AttachPointTop");
			UpdateAttachPointRadius();
			_engineComponents = GetComponent<RocketEngineComponentsScript>();
			_engineComponents.Initialize(this);
			_inFlightScene = Game.InFlightScene;
			CalculateDesignerPerformance();
			CalculateMassAndPrice();
		}

		private float AdjustedThrottle()
		{
			if (!(_engineCommon.EngineThrottle <= 0f))
			{
				if (base.Data.ThrustCurve == null)
				{
					return Mathf.Max(_engineCommon.MinThrottle, _engineCommon.EngineThrottle * _maxThrottle);
				}
				return base.Data.ThrustCurve.GetValueAtTime(1f - _engineCommon.FuelSource.GetRemainingPercentage());
			}
			return 0f;
		}

		private void CalculateMassAndPrice()
		{
			base.Data.CalculateMassAndPrice((float)_params.Static.NormalizedMassFlow, (float)_params.Dynamic.ThrustCore);
		}

		private void CalculateRocketPerformance(double airPressure, float throttle)
		{
			RocketEngineMath.CalculateDynamicPerformance(_params, airPressure);
			MaximumMassFlowRate = ((base.Data.MassFlowRateOverride < 0f) ? ((float)_params.Static.MassFlow) : base.Data.MassFlowRateOverride);
			_currentMassFlowRate = MaximumMassFlowRate * throttle;
			_thrustMax = base.Data.ThrustOverride * _params.Dynamic.ThrustNetScaled;
			_thrustCurrent = _thrustMax * throttle;
			_electricalConsumption = 1E-06f * ((base.Data.WattsPerFuelFlowOverride == -1f) ? base.Data.EngineType.WattsPerMassFlow : base.Data.WattsPerFuelFlowOverride) * Mathf.Max(0f, base.Data.ChamberPressure - 0.2f) * _currentMassFlowRate / base.Data.FuelType.Density;
			_currentIsp = MathUtils.CalculateIsp(_thrustCurrent * 100f, _currentMassFlowRate);
		}

		private void ConfigureAudio()
		{
			bool flag = ((base.Data.EngineSound == "None") ? base.Data.EngineType.AudioId : base.Data.EngineSound) == "Solid";
			float t = Mathf.Clamp01(base.Data.Size * (flag ? 2f : 1.5f) - 0.25f);
			float basePitch = Mathf.SmoothStep(2f, 0.75f, t);
			float baseVolume = Mathf.SmoothStep(0.5f, 5f, t);
			float distanceScale = Mathf.Lerp(1f, 5f, t);
			_engineCommon.Audio.Configure(basePitch, baseVolume, distanceScale);
			_engineCommon.Audio.LerpRate = 1f;
			_engineCommon.PlayAudioWhileIdle = false;
		}

		private void CreateInspectorModel(GroupModel model, Func<float> throttle, bool flight)
		{
			model.Add(new TextModel("Thrust", () => Units.GetForceString(_thrustCurrent), null, "The thrust of the engine at the current altitude."));
			model.Add(new TextModel("Isp", () => Units.GetIspString(_currentIsp), null, "The specific impulse of the engine at the current altitude. Isp measures how fuel efficient an engine is. Higher is better."));
			model.Add(new TextModel("Mass Flow", () => Units.GetMassFlowRateString(_currentMassFlowRate), null, "The amount of fuel burned per second."));
			model.Add(new TextModel("Exhaust Velocity", () => Units.GetVelocityString((float)_params.Dynamic.ExhaustVelocity * throttle()), null, "The velocity of the exhaust gas as it exits the nozzle."));
			model.Add(new TextModel("Nozzle Area Ratio", () => Units.GetRatioString(base.Data.NozzleAreaExit, base.Data.NozzleAreaThroat), null, "The ratio of the nozzle's exit area to the nozzle's throat area."));
			model.Add(new TextModel("Exit Pressure", () => Units.GetPressureString((float)_params.Dynamic.ExitPressure * throttle()), null, "The pressure of the engine's exhaust gas.")).ElementName = "Performance.Engine.ExitPressure";
			model.Add(new TextModel("Air Pressure", () => Units.GetPressureString((float)_params.Dynamic.AirPressure), null, "The atmospheric pressure at the current altitude."));
			model.Add(new TextModel("Power Usage", () => Units.GetPowerString(_electricalConsumption * 1000f), null, "The amount of electricity the engine is using."));
			model.Add(new TextModel("Spool Time", () => (base.Data.ThrustCurve == null) ? Units.GetRelativeTimeString(1f / ThrottleResponse, 2) : (base.Data.FuelGrain.Name + " Grain"), null, "The time it would take for the engine to go from 0% to 100% throttle."));
			if (flight)
			{
				model.Add(new TextModel("Ignitions", () => (base.Data.IgnitionsMax != 0) ? $"{base.Data.IgnitionsUsed}/{base.Data.IgnitionsMax}" : "Unlimited", null, "The amount of ignitions available."));
				model.Add(new TextModel("Engine Throttle", () => Units.GetPercentageString(throttle()), null, "The engine's current throttle. Some engines respond more slowly to changes in throttle."));
				if ((double)_engineCommon.MinThrottle != 1.0)
				{
					model.Add(new SliderModel("Max Throttle", () => _maxThrottle, delegate(float x)
					{
						_maxThrottle = Mathf.Clamp(x, Mathf.Max(_engineCommon.MinThrottle, 0.5f), 1.2f);
					}, Mathf.Max(_engineCommon.MinThrottle, 0.5f), 1.2f));
				}
			}
			else
			{
				model.Add(new TextModel("Max Ignitions", () => (base.Data.IgnitionsMax != 0) ? base.Data.IgnitionsMax.ToString() : "Unlimited", null, "The amount of times the engine can be ignited."));
			}
		}

		private void InitializeRocketParameters()
		{
			RocketEngineMath.Inputs inputs = _params.Inputs;
			inputs.ChamberPressure = base.Data.ChamberPressure;
			inputs.FuelMolecularWeight = base.Data.FuelType.MolecularWeight;
			inputs.FuelSpecificHeatRatio = base.Data.FuelType.Gamma;
			inputs.ChamberTemperature = base.Data.FuelType.CombustionTemperature;
			inputs.Efficiency = base.Data.EngineType.Efficiency * base.Data.NozzleType.Efficiency;
			inputs.ThroatArea = base.Data.NozzleAreaThroat;
			if (base.Data.AltitudeCompensation > 0f)
			{
				inputs.AltitudeCompensation = base.Data.AltitudeCompensation;
				inputs.ExitArea = 0f;
			}
			else
			{
				inputs.AltitudeCompensation = 0f;
				inputs.ExitArea = base.Data.NozzleAreaExit;
			}
			RocketEngineMath.CalculateStaticPerformance(_params);
		}

		private void OnCraftFuelSourceChanged(object sender, EventArgs e)
		{
			RefreshFuelSource();
		}

		private void OnPerformanceAnalysisEnvironmentChanged(object sender, EventArgs e)
		{
			CalculateDesignerPerformance();
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			_engineCommon.OnTimeMultiplierModeChanged(e);
		}

		private void ProcessWarpMode(in FlightFrameData frame)
		{
			_engineCommon.UpdateInputs(immediateThrottle: true);
			if (_engineCommon.EngineThrottle > 0f)
			{
				CalculateRocketPerformance(0.0, AdjustedThrottle());
				_engineCommon.WarpBurn(_thrustCurrent, (float)frame.DeltaTimeWorld, base.PartScript.CraftScript.CraftNode as CraftNode);
			}
		}

		private void RefreshFuelSource()
		{
			if (base.Data.FuelType == FuelTank?.CraftFuelSource?.FuelType)
			{
				_engineCommon.FuelSource = FuelTank?.CraftFuelSource;
			}
			else
			{
				_engineCommon.FuelSource = EmptyFuelSource.GetOrCreate(base.Data.FuelType);
			}
		}

		private AttachPointSnapshot SaveAttachPointSnapshot()
		{
			if (_attachPointTop?.AttachPointScript != null)
			{
				return new AttachPointSnapshot(_attachPointTop);
			}
			return null;
		}

		private void UpdateAttachPointRadius()
		{
			if (Game.InDesignerScene)
			{
				_attachPointTop.Radius = Mathf.Max(base.Data.TopRadius, base.Data.NozzleExitRadius);
			}
		}

		private void UpdateExhaustExpansionRatio(float pressure, float deltaTime)
		{
			float num = (float)_params.Dynamic.ExitPressure;
			float num2 = pressure;
			if (num2 < 15f)
			{
				num2 = 15f;
			}
			float num3 = Mathf.Sqrt(num / num2) * (1f - 0.85f * base.Data.AltitudeCompensation);
			num3 = ((base.Data.ExhaustExpansionRange.x > num3) ? base.Data.ExhaustExpansionRange.x : num3);
			num3 = ((base.Data.ExhaustExpansionRange.y > 0f && base.Data.ExhaustExpansionRange.y < num3) ? base.Data.ExhaustExpansionRange.y : num3);
			float num4 = Mathf.Clamp01(base.Data.NozzleType.OverexpansionDamageThreshold - num3) * base.Data.OverexpansionDamage * _engineCommon.EngineThrottle * deltaTime;
			if (num4 > 0f)
			{
				base.PartScript.TakeDamage(num4, PartDamageType.Overexpansion);
			}
			_engineComponents.ExhaustSystem.ExpansionRatio = num3;
		}
	}
}
