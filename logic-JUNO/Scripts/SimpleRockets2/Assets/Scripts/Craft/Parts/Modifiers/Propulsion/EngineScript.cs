using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
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
	public class EngineScript : PartModifierScript<EngineData>, IReactionEngine, IAnalyzePerformance, IDesignerStart, IGameLoopItem, IFlightStart, IFlightUpdate, IFlightFixedUpdate, IDesignerUpdate
	{
		private EngineActuatorScript[] _actuators;

		private EngineCommon _engineCommon;

		private FuelTankScript _fuelTank;

		private bool _inFlightScene;

		private float _maxNozzleThrust;

		private ParticleSystem[] _particleSystems;

		private IExhaustSystem[] _previewExhaustSystems;

		private IInputController _throttleInput;

		public float CurrentEfficiency { get; private set; }

		public float CurrentMassFlowRate => MaximumMassFlowRate * _engineCommon.EngineThrottle;

		public float CurrentThrust
		{
			get
			{
				if (!Game.InDesignerScene)
				{
					return _engineCommon.CurrentThrust;
				}
				return base.Data.Thrust;
			}
		}

		public Vector3 Down => -base.transform.up;

		public IFuelSource FuelSource => _engineCommon.FuelSource;

		IFuelSource IReactionEngine.FuelSource => _engineCommon.FuelSource;

		bool IReactionEngine.IsActive
		{
			get
			{
				if (_throttleInput.Active)
				{
					return _engineCommon.Active;
				}
				return false;
			}
		}

		public float MaximumMassFlowRate => base.Data.FuelConsumption * FuelSource.FuelType.Density;

		float IReactionEngine.MaximumThrust => base.Data.Thrust;

		PartData IReactionEngine.Part => base.PartScript.Data;

		public bool PreviewExhaust { get; set; }

		float IReactionEngine.RemainingFuel => (float)(FuelSource.TotalFuel * (double)FuelSource.FuelType.Density);

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

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			UpdateScale();
		}

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			if (PreviewExhaust)
			{
				if (_previewExhaustSystems == null)
				{
					_previewExhaustSystems = GetComponentsInChildren<IExhaustSystem>(includeInactive: true);
				}
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
			float engineThrottle = _engineCommon.EngineThrottle;
			float num = engineThrottle * CurrentEfficiency;
			float nozzleThrust = _maxNozzleThrust * num;
			float maxTorque = base.Data.MaxTorque * num;
			_engineCommon.FuelConsumptionRate = engineThrottle * base.Data.FuelConsumption;
			_engineCommon.ElectricalConsumptionRate = engineThrottle * base.Data.ElectricalConsumption;
			_engineCommon.FlightFixedUpdate(nozzleThrust, maxTorque);
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_engineCommon.OnFlightStart();
			if (base.PartScript.Data.Activated)
			{
				OnActivated();
			}
			_particleSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: true) ?? null;
			UpdateScale();
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_engineCommon.FlightUpdate();
			CurrentEfficiency = GetEfficiencyAtCurrentAtmosphericDensity(base.PartScript.CraftScript.AtmosphereSample.AirDensity);
			ProcessWarpMode(in frame);
			EngineActuatorScript[] actuators = _actuators;
			for (int i = 0; i < actuators.Length; i++)
			{
				actuators[i].UpdateRotations();
			}
		}

		public float GetEfficiencyAtCurrentAtmosphericDensity(float currentDensity)
		{
			return Mathf.Lerp(base.Data.VacuumEfficiency, base.Data.SeaLevelEfficiency, currentDensity / 1.2f);
		}

		public override void OnActivated()
		{
			_engineCommon.OnActivated();
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			FuelTankData modifier = e.TargetPart.GetModifier<FuelTankData>();
			if (modifier != null && modifier.AutoFuelType)
			{
				EngineUtilities.UpdateAutoFuelTypeFuelTanks(modifier, base.Data.FuelType);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			foreach (FuelTankScript modifier in base.PartScript.GetModifiers<FuelTankScript>())
			{
				if (modifier.FuelType == base.Data.FuelType)
				{
					FuelTank = modifier;
					break;
				}
			}
			if (FuelTank == null)
			{
				FuelTank = EngineUtilities.GetFuelTank(base.PartScript, 0, base.Data.FuelType)?.Script;
			}
			RefreshFuelSource();
			if (Game.InFlightScene)
			{
				_engineCommon.OnCraftStructureChanged(craftScript);
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			model.Add(new TextModel("Efficiency", () => Units.GetPercentageString(CurrentEfficiency)));
			model.Add(new TextModel("Power Usage", () => Units.GetPowerString(_engineCommon.ElectricalConsumptionRate * 1000f)));
			model.Add(new TextModel("Thrust", () => Units.GetForceString(CurrentThrust)));
			model.Add(new TextModel("Fuel Usage", () => Units.GetMassFlowRateString(CurrentMassFlowRate)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Thrust", () => Units.GetForceString(base.Data.Thrust * GetEfficiencyAtCurrentAtmosphericDensity((Game.Instance.Designer?.PerformanceAnalysis?.AtmosphereSample.AirDensity).GetValueOrDefault())), null, "The amount of thrust produced by the engine at full throttle"));
			groupModel.Add(new TextModel("Isp", () => Units.GetIspString(MathUtils.CalculateIsp(base.Data.Thrust * GetEfficiencyAtCurrentAtmosphericDensity((Game.Instance.Designer?.PerformanceAnalysis?.AtmosphereSample.AirDensity).GetValueOrDefault()) * 100f, base.Data.FuelConsumption)), null, "The specific impulse of the engine at the current altitude. Isp measures how fuel efficient an engine is. Higher is better."));
			groupModel.Add(new TextModel("Fuel Consumption", () => Units.GetMassFlowRateString(base.Data.FuelConsumption), null, "The amount of liters of fuel burnt per second at full throttle."));
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(base.Data.ElectricalConsumption * 1000f), null, "The power consumption of the engine."));
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			_engineCommon = new EngineCommon(this, base.Data.GimbalRange * base.Data.MaxGimbalAngle, 2.5f);
			_engineCommon.RequiresElectricity = base.Data.ElectricalConsumption > 0f;
			_maxNozzleThrust = base.Data.Thrust;
			float num = 0f;
			EngineNozzleScript[] nozzles = _engineCommon.Nozzles;
			foreach (EngineNozzleScript engineNozzleScript in nozzles)
			{
				num += engineNozzleScript.ThrustScale;
			}
			if (num > 0f)
			{
				_maxNozzleThrust = base.Data.Thrust / num;
			}
			if (Game.InFlightScene)
			{
				_throttleInput = GetInputController((CraftControls x) => x.Throttle);
			}
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			FuelTank = null;
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale();
		}

		public void UpdateAutoFuelTypeFuelTanks()
		{
			EngineUtilities.UpdateAutoFuelTypeFuelTanks(FuelTank?.Data, base.Data.FuelType);
		}

		public void UpdateScale()
		{
			if (!(base.Data.Part.PartType.Id == "IonEngine1"))
			{
				return;
			}
			Transform transform = base.transform.Find("Scalar");
			if (!(transform != null))
			{
				return;
			}
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * base.Data.Scale;
			}
			transform.localScale = Vector3.one * base.Data.Scale;
			if (_particleSystems != null)
			{
				ParticleSystem[] particleSystems = _particleSystems;
				foreach (ParticleSystem particleSystem in particleSystems)
				{
					ParticleSystem.MainModule main = particleSystem.main;
					main.startSpeed = 2.5f * base.Data.Scale;
					main.startSize = base.Data.Scale;
					main.startColor = ((particleSystem.gameObject.name == "Inner Flame") ? base.Data.ExhaustColorInner : base.Data.ExhaustColorOutter);
				}
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			_engineCommon.ValidatePart(result);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_inFlightScene = Game.InFlightScene;
			_actuators = GetComponentsInChildren<EngineActuatorScript>();
			UpdateScale();
			_particleSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: true) ?? null;
		}

		private void OnCraftFuelSourceChanged(object sender, EventArgs e)
		{
			RefreshFuelSource();
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			_engineCommon.OnTimeMultiplierModeChanged(e);
		}

		private void ProcessWarpMode(in FlightFrameData frame)
		{
			if (!frame.IsWarping || !base.PartScript.Data.Activated)
			{
				return;
			}
			if (base.Data.SupportsWarpBurn && base.PartScript.CommandPod != null && !base.PartScript.Disconnected)
			{
				_engineCommon.UpdateInputs(immediateThrottle: true);
				float engineThrottle = _engineCommon.EngineThrottle;
				if (engineThrottle > 0f)
				{
					float num = engineThrottle * CurrentEfficiency;
					float nozzleThrust = _maxNozzleThrust * num;
					_engineCommon.FuelConsumptionRate = engineThrottle * base.Data.FuelConsumption;
					_engineCommon.ElectricalConsumptionRate = engineThrottle * base.Data.ElectricalConsumption;
					_engineCommon.WarpBurn(nozzleThrust, (float)frame.DeltaTimeWorld, base.PartScript.CraftScript.CraftNode as CraftNode);
				}
			}
			else
			{
				_engineCommon.EngineThrottle = 0f;
				_engineCommon.ElectricalConsumptionRate = 0f;
				_engineCommon.FuelConsumptionRate = 0f;
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
	}
}
