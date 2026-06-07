using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Utils;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JTransmissionScript : PowertrainModifierScript, IVariableOutput, IMagicPowertrainSource, IEngineScaleResponder
	{
		private ClutchComponent _clutch;

		[SerializeField]
		private BoxCollider _collider;

		private Vector3 _colliderSize;

		private float _lastShiftInputValue;

		private bool _lastShiftWasUp;

		private List<IPowertrainNode> _magicSinks;

		[SerializeField]
		private MeshSandwichScript _meshSandwich;

		private IPowertrain _powertrain;

		private bool _readyToShift;

		[SerializeField]
		private Transform _scaleRoot;

		private IInputController _shiftInput;

		private TransmissionComponent _transmission;

		private UpdateAttachPointsScript _updateAttachPoints;

		public string CurrentGearName => _transmission?.GearName ?? string.Empty;

		public JTransmissionData Data { get; private set; }

		[VariableOutput("Gear")]
		public float Gear => _transmission?.Gear ?? 0;

		[VariableOutput("GearRatio")]
		public float GearRatio => _transmission?.currentGearRatio ?? 0f;

		[VariableOutput("InputTorque")]
		public float InputTorque => _transmission?.inputTorque ?? 0f;

		[VariableOutput("OutputTorque")]
		public float OutputTorque => _transmission?.outputTorque ?? 0f;

		public float ShiftGuardBrake { get; private set; }

		public void CreateMeshes()
		{
			UpdateMeshes(buildMeshes: true);
		}

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			if (inputConnection == null)
			{
				throw new ArgumentNullException("inputConnection");
			}
			AttachPointData item = base.PartScript.Part.AttachPoints[1];
			if (inputConnection.PartConnection.AttachPointsA.Contains(item) || inputConnection.PartConnection.AttachPointsB.Contains(item))
			{
				Debug.LogWarning("Attempting to use output attach point as input attach point");
				return null;
			}
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			List<float> gearRatios = Data.GenerateGearRatios();
			PowertrainNode powertrainNode = new PowertrainNode(this, inputConnection);
			PowertrainNode outputNode = PowertrainBuilder.CreateOutputNode(powertrainNode, base.PartScript, _magicSinks, 1, "PowertrainOutput", Data.FinalGearRatio * gearRatios.Max());
			powertrainNode.InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
			{
				float engineMaxRpm = powertrain.EngineMaxRpm;
				float engineIdleRpm = powertrain.EngineIdleRpm;
				ClutchComponent clutchComponent = new ClutchComponent
				{
					name = $"Clutch-{base.PartScript.Part.Id}",
					inertia = powertrain.EngineInertia * 0.15f,
					controlType = ClutchComponent.ClutchControlType.Automatic,
					throttleEngagementOffsetRPM = engineMaxRpm * 0.15f,
					engagementRPM = engineIdleRpm * 1.2f,
					engagementRange = engineIdleRpm * 0.4f,
					engagementCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f),
					slipTorque = powertrain.EnginePeakTorque * 10f,
					creepTorque = 0f,
					creepSpeedLimit = 1f
				};
				TransmissionComponent transmissionComponent = new TransmissionComponent
				{
					name = $"Transmission-{base.PartScript.Part.Id}",
					inertia = powertrain.EngineInertia * 0.1f,
					transmissionType = GetTransmissionType(),
					isSequential = true,
					allowUpshiftGearSkipping = false,
					shiftDuration = Data.ShiftDuration,
					postShiftBan = Data.PostShiftBan,
					clutchInputShiftThreshold = 1f,
					automaticTransmissionDNRShiftType = TransmissionComponent.AutomaticTransmissionDNRShiftType.Auto,
					dnrSpeedThreshold = 0.4f,
					UpshiftRPM = engineMaxRpm * Data.ShiftUpRpmPercent,
					DownshiftRPM = engineMaxRpm * Data.ShiftDownRpmPercent,
					variableShiftPoint = (Data.VariableShift > 0f),
					variableShiftIntensity = Data.VariableShift,
					inclineEffectCoeff = 0f
				};
				transmissionComponent.finalGearRatio = Data.FinalGearRatio;
				transmissionComponent.gears = gearRatios;
				clutchComponent.Output = transmissionComponent;
				clutchComponent.transmission = transmissionComponent;
				transmissionComponent.vehicleController = powertrain.Powertrain.vehicleController;
				clutchComponent.vehicleController = powertrain.Powertrain.vehicleController;
				powertrain.Powertrain.clutch = clutchComponent;
				powertrain.Powertrain.transmission = transmissionComponent;
				if (powertrain.PrimaryTransmission == null)
				{
					powertrain.PrimaryTransmission = this;
				}
				_powertrain = powertrain;
				_clutch = clutchComponent;
				_transmission = transmissionComponent;
				if (outputNode != null)
				{
					transmissionComponent.Output = outputNode.InitializePowertrain?.Invoke(powertrain, transmissionComponent);
				}
				return clutchComponent;
			};
			return powertrainNode;
		}

		public void Initialize(JTransmissionData data)
		{
			Data = data;
			_updateAttachPoints = GetComponent<UpdateAttachPointsScript>();
			_colliderSize = _collider.size;
			CreateMeshes();
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			base.OnConnectedToPart(thisAttachPoint, targetPart, targetAttachPoint, isSymmetryOperation);
			PartData partData = base.PartScript.Part.AttachPoints[0].PartConnections.FirstOrDefault()?.GetOtherPart(base.PartScript.Part);
			if (partData != null && partData.TryGetModifier<JEngineData>(out var result))
			{
				Data.SizePercentage = result.SizePercentage;
				UpdateMeshes(buildMeshes: false);
			}
		}

		public void OnEngineScaleChanged(float scaleRatio)
		{
			AttachPointScript attachPointScript = base.PartScript.AttachPointScripts[1];
			Vector3 position = attachPointScript.transform.position;
			Data.SizePercentage *= scaleRatio;
			UpdateMeshes(buildMeshes: false);
			PartConnection partConnection = attachPointScript.AttachPoint.PartConnections.FirstOrDefault();
			if (partConnection != null && !partConnection.GetOtherPart(base.PartScript.Part).TryGetModifier<JDriveShaftData>(out var _))
			{
				SymmetryUtility.MoveConnectedParts(base.PartScript.Part, attachPointScript.AttachPoint, null, position, null, ignoreSymmetricParts: true);
			}
		}

		public void RegisterSink(IPowertrainNode node)
		{
			if (_magicSinks == null)
			{
				_magicSinks = new List<IPowertrainNode>();
			}
			_magicSinks.Add(node);
		}

		public void UpdateMeshes(bool buildMeshes)
		{
			_scaleRoot.localScale = Vector3.one * Data.Size;
			if (buildMeshes)
			{
				_meshSandwich.NumFillMeshes = Mathf.Max(Data.NumGears - 2, 0);
				_meshSandwich.BuildMeshes();
			}
			_collider.size = new Vector3(_colliderSize.x * Data.Size, _colliderSize.y * Data.Size, _colliderSize.z * _meshSandwich.Length * Data.Size);
			_collider.center = new Vector3(0f, 0f, (0f - _collider.size.z) / 2f);
			if (base.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.Part.CenterOfMass = new Vector3(0f, 0.25f, _meshSandwich.Length / 2f) * Data.Size;
				_updateAttachPoints.UpdateAttachPoints(base.PartScript, updateAttachedParts: false);
			}
		}

		void IVariableOutput.UpdateOutputs()
		{
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnFlightStartLocal, CraftUpdateFlags.FlightLocal);
			registrar.RegisterUpdate(OnFlightUpdateLocalUnpaused, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private TransmissionComponent.TransmissionShiftType GetTransmissionType()
		{
			return Data.TransmissionType switch
			{
				JTransmissionData.JTransmissionType.Automatic => TransmissionComponent.TransmissionShiftType.Automatic, 
				JTransmissionData.JTransmissionType.Manual => TransmissionComponent.TransmissionShiftType.Manual, 
				_ => throw new NotImplementedException($"Unsupported transmission type: {Data.TransmissionType}"), 
			};
		}

		private void OnFlightStartLocal(in CraftUpdateFrameData frame)
		{
			_shiftInput = GetInputController("shift");
		}

		private void OnFlightUpdateLocalUnpaused(in CraftUpdateFrameData frame)
		{
			ShiftGuardBrake = 0f;
			if (_powertrain == null)
			{
				return;
			}
			if (_transmission.transmissionType == TransmissionComponent.TransmissionShiftType.Automatic)
			{
				if (_powertrain.InputThrottle < 0f && _transmission.Gear >= 0)
				{
					float surfaceSpeed = _powertrain.Powertrain.vehicleController.SurfaceSpeed;
					ShiftWithBrakeGuard(-1, surfaceSpeed, Mathf.Abs(_powertrain.InputThrottle));
				}
				else if (_powertrain.InputThrottle > 0f && _transmission.Gear <= 0)
				{
					float surfaceSpeed2 = _powertrain.Powertrain.vehicleController.SurfaceSpeed;
					ShiftWithBrakeGuard(1, surfaceSpeed2, _powertrain.InputThrottle);
				}
			}
			else if (_transmission.transmissionType == TransmissionComponent.TransmissionShiftType.Manual)
			{
				UpdateShiftInput();
			}
		}

		private void ShiftWithBrakeGuard(int gear, float craftSpeed, float shiftGuardBrakeInput)
		{
			if (Data.ShiftGuardSpeedThreshold == 0f || craftSpeed < Data.ShiftGuardSpeedThreshold)
			{
				_transmission.ShiftInto(gear, instant: true);
			}
			else
			{
				ShiftGuardBrake = shiftGuardBrakeInput;
			}
		}

		private void UpdateShiftInput()
		{
			float value = _shiftInput.Value;
			_clutch.clutchInput = 1f - Mathf.Clamp01(Mathf.Abs(value));
			float num = value - _lastShiftInputValue;
			bool flag = value > 0.1f && _lastShiftInputValue <= 0.1f;
			bool flag2 = value < -0.1f && _lastShiftInputValue >= -0.1f;
			if (!_readyToShift)
			{
				if (_lastShiftWasUp && num < 0f)
				{
					_readyToShift = true;
				}
				else if (!_lastShiftWasUp && num > 0f)
				{
					_readyToShift = true;
				}
			}
			else if (flag)
			{
				_readyToShift = false;
				_lastShiftWasUp = true;
				_transmission.ShiftInto(_transmission.Gear + 1, instant: true);
			}
			else if (flag2)
			{
				_readyToShift = false;
				_lastShiftWasUp = false;
				_transmission.ShiftInto(_transmission.Gear - 1, instant: true);
			}
			ShiftGuardBrake = Mathf.Clamp01(0f - _powertrain.InputThrottle);
			_lastShiftInputValue = value;
		}
	}
}
