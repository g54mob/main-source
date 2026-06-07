using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class JetEngineScript : PartModifierScript, ICraftEngine, IDesignerThrust
	{
		private class AttachPointSnapshot
		{
			public AttachPointData AttachPoint { get; set; }

			public Vector3 DeltaPosition => WorldPosition - AttachPoint.AttachPointScript.transform.position;

			public Vector3 WorldPosition { get; private set; }

			public AttachPointSnapshot(AttachPointData attachPoint)
			{
				AttachPoint = attachPoint;
				WorldPosition = attachPoint.AttachPointScript.transform.position;
			}
		}

		private AttachPointData _attachPoint;

		private IInputController _brakeInput;

		private float _brakeValue;

		private float _coreThrottle;

		private float _currentMassFlowRate;

		private EngineCommon _engineCommon;

		private float _inletEfficiency;

		private float _inverseFuelDensity;

		private IJetEngineComponents _jetComponents;

		private IExhaustSystem[] _previewExhaustSystems;

		private float _requiredAirArea;

		private float _seaLevelThrust;

		private float _thrustCurrent;

		public float BrakeValue => _brakeValue;

		public JetEngineData Data { get; set; }

		Vector3 IDesignerThrust.DesignerCenterOfThrust => _jetComponents.DesignerCenterOfThrust;

		float IDesignerThrust.DesignerThrust => Data.CalculateThrustAtSeaLevel();

		DesignerThrustTypes IDesignerThrust.DesignerThrustType => DesignerThrustTypes.ProceduralJetEngine;

		public InletAir DirectAir { get; private set; }

		public CraftEngineType EngineType => CraftEngineType.Jet;

		public IFuelSource FuelSource => _engineCommon.FuelSource;

		public bool HasShroud => GetConnectedShroud() != null;

		public float IRSignature
		{
			get
			{
				float num = Mathf.Lerp(1f, 10f, (float)Data.MathParams.Inputs.ThrottleAfterburner);
				return _seaLevelThrust * _engineCommon.EngineThrottle * num;
			}
		}

		public float MaximumMassFlowRate { get; private set; }

		public IPowertrain Powertrain => null;

		public float ThrottleResponse => _engineCommon.ThrottleResponse;

		private bool IsActivated => true;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault);
		}

		public void OnActivated()
		{
			_engineCommon.OnActivated();
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			base.OnConnectedToPart(thisAttachPoint, targetPart, targetAttachPoint, isSymmetryOperation);
			UpdateComponentsInDesigner(updateStyles: false);
		}

		public void OnModifiersCreated()
		{
		}

		public void UpdateComponentsInDesigner(bool updateStyles)
		{
			if (_previewExhaustSystems != null)
			{
				DisableExhaustPreview();
			}
			AttachPointSnapshot attachPointSnapshot = SaveAttachPointSnapshot();
			base.PartScript.EditorColliders.Clear();
			if (updateStyles)
			{
				_jetComponents.UpdateStyles();
			}
			_jetComponents.UpdateComponents();
			UpdateShroud();
			Assembly.CreateEditorCollidersForPartScript(base.PartScript);
			if (attachPointSnapshot != null)
			{
				base.PartScript.transform.position += attachPointSnapshot.DeltaPosition;
			}
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
			base.PartScript.Aircraft.OnAircraftStructureChanged -= OnCraftStructureChanged;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_attachPoint = base.PartScript.Part.GetAttachPoint(0);
			_jetComponents = Utilities.GetComponentWithInterface<IJetEngineComponents>(base.gameObject);
			_jetComponents.Initialize(this, _attachPoint.AttachPointScript);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterFixedUpdate(FlightFixedUpdateLocal, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterFixedUpdate(FlightFixedUpdateRemote, CraftUpdateFlags.FlightRemoteUnpaused);
			registrar.RegisterStart(CommonStart);
			registrar.RegisterUpdate(FlightUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void CommonStart(in CraftUpdateFrameData frame)
		{
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnCraftStructureChanged;
			if (frame.CraftLoadContext == CraftLoadContext.Flight)
			{
				_engineCommon.OnFlightStart();
				_seaLevelThrust = Data.CalculateThrustAtSeaLevel() * 0.01f;
				Data.MathParams.Inputs.Throttle = 0.0;
				Data.MathParams.Inputs.ThrottleAfterburner = 0.0;
				OnCraftStructureChanged();
				if (IsActivated)
				{
					OnActivated();
				}
			}
		}

		private void ConfigureAudio()
		{
			_engineCommon.PlayAudioWhileIdle = true;
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

		private void FlightFixedUpdateLocal(in CraftUpdateFrameData frame)
		{
			if (base.PartScript.Aircraft.AtmosphereSample.AirDensity > 0f && _inletEfficiency > 0f)
			{
				float temperature = base.PartScript.Aircraft.AtmosphereSample.Temperature;
				float num = _inletEfficiency * base.PartScript.Aircraft.AtmosphereSample.AirPressure;
				float machNumber = base.PartScript.Body.MachNumber;
				float engineThrottle = _engineCommon.EngineThrottle;
				bool useAfterburner = Data.HasAfterburner && _brakeValue == 0f;
				Data.UpdatePerformance(engineThrottle, useAfterburner, machNumber, num, temperature);
				float num2 = (Data.HasAfterburner ? Data.AfterburnerThrottleStart : 1f);
				_coreThrottle = Mathf.Clamp01(engineThrottle / num2);
				float num3 = Mathf.Pow(_coreThrottle, 2.5f);
				_thrustCurrent = Data.MathParams.Output.ThrustNetScaled * num3;
				MaximumMassFlowRate = (float)Data.MathParams.Output.FuelFlow;
				_currentMassFlowRate = MaximumMassFlowRate * num3;
				_engineCommon.FuelConsumptionRate = _currentMassFlowRate * _inverseFuelDensity;
				_engineCommon.ElectricalConsumptionRate = 0f;
				if (_brakeValue > 0f)
				{
					_thrustCurrent *= (0f - _brakeValue) * Mathf.Clamp01(machNumber * 4f) * 0.5f;
				}
			}
			else
			{
				_coreThrottle = 0f;
				_thrustCurrent = 0f;
				_currentMassFlowRate = 0f;
				_engineCommon.FuelConsumptionRate = 0f;
				_engineCommon.ElectricalConsumptionRate = 0f;
			}
			_engineCommon.FlightFixedUpdate(_thrustCurrent);
		}

		private void FlightFixedUpdateRemote(in CraftUpdateFrameData frame)
		{
			FlightFixedUpdateLocal(in frame);
		}

		private void FlightUpdate(in CraftUpdateFrameData frame)
		{
			_engineCommon.FlightUpdate();
			if (_brakeInput != null && Data.HasReverseThrust)
			{
				_brakeValue = Utilities.StepTowards(_brakeValue, Data.ThrottleResponse * 0.2f, _brakeInput.Value);
			}
			_jetComponents.AnimateComponents(_engineCommon.Active, _coreThrottle, (float)Data.MathParams.Inputs.ThrottleAfterburner);
			if (IsActivated)
			{
				_inletEfficiency = 1f;
			}
			DirectAir.Update();
		}

		private JetEngineShroudData GetConnectedShroud()
		{
			AttachPointData attachPoint = _attachPoint;
			if (attachPoint != null && attachPoint.PartConnections.Count > 0)
			{
				return _attachPoint.PartConnections[0].GetOtherPart(base.PartScript.Part).GetModifier<JetEngineShroudData>();
			}
			return null;
		}

		private void OnCraftStructureChanged()
		{
			if (base.PartScript.LoadContext == CraftLoadContext.Flight)
			{
				if (base.PartScript.ConnectedToMainCockpit)
				{
					_engineCommon.FuelSource = base.PartScript.Aircraft;
				}
				else
				{
					_engineCommon.FuelSource = EmptyFuelSource.GetOrCreate();
				}
				_engineCommon.OnCraftStructureChanged();
			}
			else if (base.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				UpdateComponentsInDesigner(updateStyles: false);
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			DirectAir = new InletAir();
			_engineCommon = new EngineCommon(this, Data.MaxGimbalAngle, Data.GimbalSpeed);
			_engineCommon.AfterburnerThrottle = () => (float)Data.MathParams.Inputs.ThrottleAfterburner;
			_engineCommon.DistortionIntensity = () => _engineCommon.EngineThrottle;
			_engineCommon.OnFlightPreStart();
			_engineCommon.ThrottleResponse = Data.ThrottleResponse;
			_requiredAirArea = Data.FanArea * 0.75f;
			ConfigureAudio();
			_inverseFuelDensity = 1.2437811f;
			_brakeInput = GetInputController("Thrust Reverse");
			return UniTask.CompletedTask;
		}

		private AttachPointSnapshot SaveAttachPointSnapshot()
		{
			if (_attachPoint.NumPartConnections > 0)
			{
				return new AttachPointSnapshot(_attachPoint);
			}
			return null;
		}

		private void UpdateShroud()
		{
			JetEngineShroudData connectedShroud = GetConnectedShroud();
			if (connectedShroud != null)
			{
				connectedShroud.Radius = Data.FanRadius;
				connectedShroud.JetEngineType = Data.JetEngineType;
				connectedShroud.Script.UpdateStyles();
			}
		}
	}
}
