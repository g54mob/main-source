using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.SyncData;
using Jundroo.Common.Utils;
using NWH.Common.Utility;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JEngineScript : PowertrainModifierScript, IMagicPowertrainSource, IPowertrain, IRpmSource, ICraftEngine, IVariableOutput
	{
		[Serializable]
		public class EnginePrefabConfiguration
		{
			[field: SerializeField]
			public int MaxRows { get; private set; }

			[field: SerializeField]
			public int MinRows { get; private set; } = 1;

			[field: SerializeField]
			public int NumCylinders { get; private set; }

			[field: SerializeField]
			public GameObject Prefab { get; private set; }
		}

		private const float HorsepowerToKilowatt = 0.7457f;

		private InputControllerScript _controller;

		private int? _currentEngineConfiguration;

		[SerializeField]
		private EngineColliderScript _engineCollider;

		private List<IPowertrainNode> _magicSinks;

		private MeshSandwichEngineScript _meshSandwich;

		private float _previousSize;

		[SerializeField]
		private Transform _scaleRoot;

		private float _throttleResponse;

		private UpdateAttachPointsScript _updateAttachPoints;

		private JVehicleController _vehicleController;

		public JEngineData Data { get; private set; }

		public float EngineIdleRpm => Data.IdleRpm;

		public float EngineInertia => 0.05f + Mathf.Pow(Data.SizePercentage, 3f) * 0.35f * (1f + 0.2f * Mathf.Log(Data.NumCylinderRows));

		public float EngineMaxRpm => Data.MaxRpm;

		public float EnginePeakTorque { get; private set; }

		public EnginePrefabConfiguration EnginePrefab => EnginePrefabs[Data.EngineConfiguration];

		[field: SerializeField]
		public EnginePrefabConfiguration[] EnginePrefabs { get; private set; }

		public float EngineRedlineRpm { get; private set; }

		[VariableOutput("RPM")]
		public float EngineRpm => (Powertrain?.engine?.OutputRPM).GetValueOrDefault();

		public float EngineThrottle { get; private set; }

		public float EngineThrottleMax { get; private set; }

		public CraftEngineType EngineType => CraftEngineType.InternalCombustion;

		public float InputThrottle { get; private set; }

		public float IRSignature => EngineThrottle * Data.Power * 0.1f;

		public override bool IsEngine => true;

		[VariableOutput("OutputTorque")]
		public float OutputTorque => (Powertrain?.engine?.outputTorque).GetValueOrDefault();

		public NWH.VehiclePhysics2.Powertrain.Powertrain Powertrain => _vehicleController.powertrain;

		IPowertrain ICraftEngine.Powertrain => this;

		public JTransmissionScript PrimaryTransmission { get; set; }

		float IRpmSource.ReportedRpm => EngineRpm;

		int IRpmSource.ReportedRpmPriority => 0;

		PartScript IRpmSource.ReportingPartScript => base.PartScript;

		public void CalculateDesignerPeakTorque(out float peakTorque, out float peakTorqueRpm)
		{
			EngineComponent engine = GetComponent<VehicleController>().powertrain.engine;
			ConfigureEngine(engine);
			engine.GetPeakTorque(out peakTorque, out peakTorqueRpm);
		}

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			if (inputConnection != null)
			{
				throw new NotSupportedException("InitializePowerTrain: sourcePartConnection should always be null for an engine");
			}
			PowertrainNode powertrainNode = new PowertrainNode(this, null);
			PowertrainNode outputNode = PowertrainBuilder.CreateOutputNode(powertrainNode, base.PartScript, _magicSinks);
			powertrainNode.InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
			{
				PowertrainComponent output = outputNode?.InitializePowertrain?.Invoke(powertrain, powertrain.Powertrain.engine);
				powertrain.Powertrain.engine.Output = output;
				if (powertrain.Powertrain.engine.Output != null)
				{
					_vehicleController.enabled = true;
				}
				else if (!base.PartScript.Aircraft.RemoteAircraft)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage($"Engine #{base.PartScript.Part.Id} was not connected to anything so it has been disabled.");
				}
				return powertrain.Powertrain.engine;
			};
			return powertrainNode;
		}

		public void Initialize(JEngineData data)
		{
			Data = data;
			_previousSize = Data.Size;
			_updateAttachPoints = GetComponent<UpdateAttachPointsScript>();
			CreateEngineMeshes();
			UpdateEngineMeshes(buildMeshes: true, updateAttachedParts: false);
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			base.InitializePartSyncData(syncData);
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => EngineRpm,
				ValueRead = delegate(float x)
				{
					if (_vehicleController?.powertrain?.engine != null)
					{
						_vehicleController.powertrain.engine.outputAngularVelocity = UnitConverter.RPMToAngularVelocity(x);
					}
				},
				DeltaScale = 0.01f
			});
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => _vehicleController.powertrain.engine.Load,
				ValueRead = delegate(float x)
				{
					if (_vehicleController?.powertrain?.engine != null)
					{
						_vehicleController.powertrain.engine.Load = x;
					}
				},
				DeltaScale = 10f
			});
		}

		public void RegisterSink(IPowertrainNode node)
		{
			if (_magicSinks == null)
			{
				_magicSinks = new List<IPowertrainNode>();
			}
			_magicSinks.Add(node);
		}

		public void UpdateEngineMeshes(bool buildMeshes, bool updateAttachedParts)
		{
			if (_currentEngineConfiguration != Data.EngineConfiguration)
			{
				buildMeshes = true;
				CreateEngineMeshes();
			}
			_scaleRoot.localScale = Vector3.one * Data.Size;
			if (buildMeshes)
			{
				_meshSandwich.NumFillMeshes = Data.NumCylinderRows;
				_meshSandwich.SuperchargerEnabled = Data.HasSupercharger;
				_meshSandwich.BuildMeshes();
				_engineCollider.UpdateCollider(_meshSandwich);
			}
			if (base.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.Part.CenterOfMass = _meshSandwich.CenterOfMass * Data.Size;
				UpdateAttachPoints(updateAttachedParts);
			}
		}

		void IVariableOutput.UpdateOutputs()
		{
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		protected IEnumerator Start()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_throttleResponse = Data.ThrottleResponse / Mathf.Clamp(Data.SizePercentage, 0.25f, 4f);
				_vehicleController = GetComponent<JVehicleController>();
				_vehicleController.vehicleRigidbody = base.PartScript.Body.RigidBody.PhysxRigidBody;
				_controller = base.PartScript.GetModifier<InputControllerScript>();
				EngineThrottleMax = _controller.InputController.MaxValue;
				EngineRedlineRpm = EngineMaxRpm * Data.RedlineRpmPercent;
				ConfigureEngine(_vehicleController.powertrain.engine);
				_vehicleController.RemoteCraft = base.PartScript.Aircraft.RemoteAircraft;
				_vehicleController.powertrain.vehicleController = _vehicleController;
				yield return new WaitForEndOfFrame();
				CreatePowertrainNode(null).InitializePowertrain?.Invoke(this, null);
				base.PartScript.Aircraft.Powertrain.RegisterPowertrain(this);
				_vehicleController.onEnable.AddListener(AddFilter);
			}
		}

		private void AddFilter()
		{
			_vehicleController.onEnable.RemoveListener(AddFilter);
			AudioClip audioClip = null;
			float num = 0f;
			float num2 = 0f;
			if (Data.SoundType == EngineSoundType.CarFlat && Data.NumCylinders == 4)
			{
				audioClip = AudioStore.Boxer;
				num = 0.55f;
				num2 = 0.15f;
			}
			else if (Data.SoundType.HasFlag(EngineSoundType.Car))
			{
				switch (Data.NumCylinderRows)
				{
				case 1:
				case 2:
				case 3:
					audioClip = AudioStore.Cyl6;
					num = 0.4f;
					num2 = 0.15f;
					break;
				case 4:
					audioClip = AudioStore.Cyl8;
					num = 0.45f;
					num2 = 0.1f;
					break;
				case 5:
					audioClip = AudioStore.Cyl10;
					num = 0.5f;
					num2 = 0.25f;
					break;
				default:
					audioClip = AudioStore.Cyl12;
					num = 0.3f;
					num2 = 0.05f;
					break;
				}
			}
			num2 = ((Data.SoundPitchOffset >= 0f) ? Data.SoundPitchOffset : num2);
			num = ((Data.SoundPitchRange >= 0f) ? Data.SoundPitchRange : num);
			if (num > 0f)
			{
				_vehicleController.soundManager.engineRunningComponent.pitchOffset = num2;
				_vehicleController.soundManager.engineRunningComponent.pitchRange = num;
			}
			if (Data.SoundPitchLimit > 0f)
			{
				_vehicleController.soundManager.engineRunningComponent.pitchCeiling = Data.SoundPitchLimit;
			}
			Transform transform = base.transform.Find("EngineAudioSources");
			transform.gameObject.AddComponent<LPFbyDistance>().Filter = transform.gameObject.AddComponent<AudioLowPassFilter>();
			AudioSource[] components = transform.GetComponents<AudioSource>();
			foreach (AudioSource audioSource in components)
			{
				audioSource.maxDistance = 50f + 0.8f * EnginePeakTorque;
				audioSource.rolloffMode = AudioRolloffMode.Custom;
				Keyframe keyframe = new Keyframe(0f, 1f, -1f, -1f);
				keyframe.weightedMode = WeightedMode.None;
				Keyframe keyframe2 = keyframe;
				keyframe = new Keyframe(1f, 0f, 0f, 0f);
				keyframe.weightedMode = WeightedMode.None;
				Keyframe keyframe3 = keyframe;
				audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, new AnimationCurve(keyframe2, keyframe3));
				if (audioSource.GetComponentIndex() == 2 && audioClip != null)
				{
					audioSource.clip = audioClip;
				}
			}
		}

		private void ConfigureEngine(EngineComponent engine)
		{
			engine.maxPower = Data.Power * 0.7457f;
			engine.revLimiterRPM = Data.MaxRpm;
			engine.startDuration = 0.25f;
			engine.idleRPM = Data.IdleRpm;
			engine.stallRPM = Data.IdleRpm * 0.4f;
			engine.ignition = false;
			engine.inertia = EngineInertia;
			engine.startDuration = Data.StartupDuration;
			if (Data.HasSupercharger)
			{
				engine.forcedInduction.useForcedInduction = true;
				engine.forcedInduction.forcedInductionType = EngineComponent.ForcedInduction.ForcedInductionType.Supercharger;
				engine.forcedInduction.powerGainMultiplier = Data.ForcedInductionMultiplier;
			}
			else
			{
				engine.forcedInduction.useForcedInduction = false;
				engine.forcedInduction.powerGainMultiplier = 1f;
			}
			AnimationCurve powerCurve = Data.PowerCurve;
			if (powerCurve != null)
			{
				engine.powerCurve = powerCurve;
			}
			engine.GetPeakTorque(out var peakTorque, out var _);
			EnginePeakTorque = peakTorque;
		}

		private bool ConsumeFuel(CraftUpdateFrameData frame)
		{
			if (frame.Craft.Fuel > 0f)
			{
				if (Powertrain.engine.IsRunning)
				{
					float a = Mathf.Abs(Powertrain.engine.generatedPower) / 0.35f / 10f;
					float b = 1f * Data.SizePercentage;
					float amount = Mathf.Max(a, b) / 3600f * frame.DeltaTime;
					frame.Craft.UseFuel(amount);
				}
				return true;
			}
			if (Powertrain.engine.IsRunning)
			{
				Powertrain.engine.StopEngine();
			}
			return false;
		}

		private void CreateEngineMeshes()
		{
			_currentEngineConfiguration = Data.EngineConfiguration;
			if (_meshSandwich != null)
			{
				_meshSandwich.Destroy();
				_meshSandwich = null;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(EnginePrefabs[Data.EngineConfiguration].Prefab);
			gameObject.transform.SetParent(_scaleRoot);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			_meshSandwich = gameObject.GetComponent<MeshSandwichEngineScript>();
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (base.PartModifier.UsedInPropMode)
			{
				return;
			}
			InputThrottle = _controller.Value;
			if (!_controller.Active)
			{
				EngineThrottle = 0f;
				if (_vehicleController.powertrain.engine.ignition)
				{
					_vehicleController.powertrain.engine.ignition = false;
				}
			}
			else if (ConsumeFuel(frame) && base.PartScript.EstimateOfUnderwaterPercent < 0.8f)
			{
				float num = InputThrottle;
				if (PrimaryTransmission != null)
				{
					if (PrimaryTransmission.ShiftGuardBrake > 0f)
					{
						num = 0f;
					}
					else if (num < 0f)
					{
						num = ((!(PrimaryTransmission.Gear < 0f)) ? 0f : Mathf.Abs(num));
					}
				}
				EngineThrottle = Mathf.Min(Utilities.StepTowards(EngineThrottle, Time.fixedDeltaTime * _throttleResponse, num), EngineThrottleMax);
			}
			else
			{
				EngineThrottle = 0f;
			}
			_vehicleController.input.Throttle = EngineThrottle;
			_vehicleController.input.states.throttleRaw = EngineThrottle;
			_vehicleController.input.states.inputSwappedThrottle = EngineThrottle;
			_vehicleController.input.states.inputSwappedThrottleRaw = EngineThrottle;
		}

		private void UpdateAttachPoints(bool updateAttachedParts)
		{
			_updateAttachPoints.UpdateAttachPoints(base.PartScript, updateAttachedParts);
			if (updateAttachedParts)
			{
				float size = Data.Size;
				float num = 1f;
				if (_previousSize > 0.001f)
				{
					num = size / _previousSize;
				}
				if (Mathf.Abs(num - 1f) > 0.0001f)
				{
					(base.PartScript.Part.AttachPoints[0].PartConnections.FirstOrDefault()?.GetOtherPart(base.PartScript.Part))?.PartScript.GetModifierWithInterface<IEngineScaleResponder>()?.OnEngineScaleChanged(num);
				}
				_previousSize = size;
			}
		}
	}
}
