using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ElectricMotorScript : PartModifierScript<ElectricMotorData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate, IFlightFixedUpdate
	{
		private Transform _attachPointPositions;

		private AudioSource _audio;

		private IFuelSource _battery;

		private IInputController _brakeController;

		private float _brakeInput;

		private float _brakeTorque;

		private bool _bypassBrakeController;

		private Rigidbody _connectedRigidBody;

		private ResizableWheelScript _connectedWheel;

		private float _currentRPM;

		private float _currentTorque;

		private HingeJoint _joint;

		private float _maxConnectedBodyRpm;

		private IInputController _motorController;

		private float _motorInput;

		private float _motorTorque;

		private float _motorTorqueAbs;

		private float _powerConsumption;

		private Rigidbody _rigidBody;

		private float _rpmOverride = 1f;

		private float _rpmReductionScalar = 1f;

		private Transform _scalar;

		private float _targetRpm;

		private Transform _visualMesh;

		public float AppliedMotorTorque { get; private set; }

		public float CurrentRpm
		{
			get
			{
				return _currentRPM;
			}
			private set
			{
				_currentRPM = value / RpmReductionScalar;
			}
		}

		public float RpmReductionScalar
		{
			get
			{
				return _rpmReductionScalar;
			}
			set
			{
				SetRpmReduction(_rpmReductionScalar, value);
			}
		}

		public float PowerConsumption => _powerConsumption;

		public float Torque => _currentTorque;

		public bool UsesMachNumber => false;

		private float MaxPowerConsumption => base.Data.Torque * base.Data.PowerUsagePerTorque;

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (!(_joint != null))
			{
				return;
			}
			if (_connectedWheel == null)
			{
				Vector3 angularVelocityWorld = _connectedRigidBody.angularVelocity - _rigidBody.angularVelocity;
				CurrentRpm = 0f - Utilities.PhysicsUtils.GetRpmAroundAxis(_joint.axis, _joint.transform, angularVelocityWorld);
			}
			else
			{
				CurrentRpm = Mathf.Abs(_connectedWheel.CurrentRpm);
			}
			IFuelSource battery = _battery;
			if (battery == null || battery.IsEmpty)
			{
				if (_connectedWheel == null)
				{
					SetJointDrive(base.Data.StaticResistance, 0f, isStaticResistance: true);
				}
				_powerConsumption = 0f;
				return;
			}
			if (_connectedWheel == null)
			{
				if (_currentTorque > 0f)
				{
					SetJointDrive(_currentTorque, _targetRpm, isStaticResistance: false);
				}
				else
				{
					SetJointDrive(base.Data.StaticResistance, 0f, isStaticResistance: true);
				}
				if (_rigidBody.IsSleeping())
				{
					_rigidBody.WakeUp();
				}
				if (_connectedRigidBody.IsSleeping())
				{
					_connectedRigidBody.WakeUp();
				}
			}
			if (!Mathf.Approximately(_motorInput, 0f))
			{
				_powerConsumption = Mathf.Abs(_motorInput) * MaxPowerConsumption;
				if (_powerConsumption > 0f)
				{
					_battery.RemoveFuel(0.001f * _powerConsumption * frame.DeltaTime);
				}
			}
			else
			{
				_powerConsumption = 0f;
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_motorController = GetInputController("Motor");
			_brakeController = GetInputController((CraftControls x) => x.Brake);
			if (_brakeController is SimpleInputController)
			{
				_bypassBrakeController = false;
			}
			SetupJoint();
			UpdateScale();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (_joint != null)
			{
				_motorInput = Mathf.Clamp(_motorController.Value, -1f, 1f);
				_brakeInput = ((!_bypassBrakeController) ? Mathf.Clamp01(_brakeController.Value) : ((base.PartScript.CommandPod == null) ? 0f : base.PartScript.CommandPod.Controls.Brake));
				_motorTorque = base.Data.Torque * _motorInput;
				_motorTorqueAbs = Mathf.Abs(_motorTorque);
				_brakeTorque = Mathf.Abs(_brakeInput) * base.Data.BrakeTorque;
				if (_motorTorqueAbs > _brakeTorque)
				{
					_currentTorque = _motorTorqueAbs - _brakeTorque;
					_targetRpm = (base.Data.ThrottleGovernorEnabled ? (_motorInput * base.Data.Rpm * _rpmOverride) : (Mathf.Sign(_motorInput) * _maxConnectedBodyRpm));
				}
				else
				{
					_currentTorque = _brakeTorque - _motorTorqueAbs;
					_targetRpm = 0f;
				}
				_currentTorque *= 0.01f;
				if (_audio != null && base.Data.SoundVolume > 0f)
				{
					float b = 1E-05f * _powerConsumption * base.Data.SoundVolume;
					float num = Mathf.Max(_audio.volume, b);
					num -= frame.DeltaTime * 3f;
					num = Mathf.Clamp(num, 0f, 1f);
					_audio.volume = num;
					_audio.pitch = 1f + 250f * Mathf.Abs(_currentRPM);
					if (_audio.volume > 0.01f && !_audio.isPlaying)
					{
						_audio.Play();
					}
				}
			}
			else if (_audio != null && _audio.isPlaying)
			{
				_audio.Stop();
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			CheckJoint();
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Current RPM", () => _currentRPM.ToString("n1")), "Electric Motor");
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(_powerConsumption)), "Electric Motor");
			model.Add(new ToggleModel("RPM Governor", () => base.Data.ThrottleGovernorEnabled, delegate(bool x)
			{
				base.Data.ThrottleGovernorEnabled = x;
			}), "Electric Motor");
			model.Add(new SliderModel("RPM Clamp", () => _rpmOverride, delegate(float x)
			{
				_rpmOverride = Mathf.Clamp(x, 0f, 1f);
			}), "Electric Motor").ValueFormatter = (float x) => (x * base.Data.Rpm).ToString("n1");
			if (Application.isEditor)
			{
				model.Add(new TextModel("Target RPM", () => _targetRpm.ToString("n1")), "Electric Motor");
			}
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(MaxPowerConsumption), null, "The power consumption of the motor."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale(repositionAttachedParts: true);
		}

		public void UpdateScale(bool repositionAttachedParts = false)
		{
			if (!(_scalar != null) || !(_attachPointPositions != null))
			{
				return;
			}
			_scalar.localScale = 2.25f * base.Data.Scale * Vector3.one;
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointTransform in _attachPointPositions)
			{
				AttachPoint attachPoint = base.Data.Part.AttachPoints.Where((AttachPoint x) => x.Name == attachPointTransform.name).FirstOrDefault();
				if (attachPoint == null)
				{
					continue;
				}
				attachPoint.Scale = 1f * base.Data.Scale;
				Vector3 position = attachPointTransform.position;
				attachPoint.Position = base.transform.InverseTransformPoint(position);
				if (!(attachPoint.AttachPointScript != null))
				{
					continue;
				}
				if (repositionAttachedParts)
				{
					Vector3 delta = position - attachPoint.AttachPointScript.transform.position;
					foreach (PartConnection partConnection in attachPoint.PartConnections)
					{
						DesignerUtilities.RepositionParts(base.Data.Part, partConnection, delta, movedParts);
					}
				}
				attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.PowerUsagePerTorque > 0f)
			{
				result.ValidatFuel(this, _battery, _powerConsumption * 0.1f);
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("Mesh", base.gameObject).transform;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPositions", _scalar.gameObject);
			if (gameObject != null)
			{
				_attachPointPositions = gameObject.transform;
			}
			UpdateScale();
			Setup(Game.InFlightScene);
		}

		private void CheckJoint()
		{
			if (base.PartScript.BodyScript != null && (_rigidBody != base.PartScript.BodyScript.RigidBody || _joint == null || _joint.connectedBody != _connectedRigidBody))
			{
				SetupJoint();
			}
		}

		private void SetJointDrive(float driveTorque, float targetRpm, bool isStaticResistance)
		{
			JointMotor motor = _joint.motor;
			float num = (motor.force = driveTorque * RpmReductionScalar);
			motor.targetVelocity = targetRpm * 6f * RpmReductionScalar;
			_joint.motor = motor;
			float num3 = driveTorque - num;
			_rigidBody.AddRelativeTorque(Mathf.Sign(targetRpm) * num3 * _joint.axis);
			AppliedMotorTorque = (isStaticResistance ? 0f : driveTorque);
		}

		private void SetRpmReduction(float currentVal, float newVal)
		{
			if (currentVal != newVal)
			{
				_rpmReductionScalar = newVal;
				if (_connectedRigidBody != null && _joint != null)
				{
					float num = newVal / currentVal;
					Vector3 direction = Vector3.Scale(_joint.transform.InverseTransformDirection(_connectedRigidBody.angularVelocity), Utilities.Abs(_joint.axis) * num);
					Vector3 angularVelocity = _joint.transform.TransformDirection(direction);
					_connectedRigidBody.angularVelocity = angularVelocity;
				}
			}
		}

		private void Setup(bool inFlight)
		{
			if (inFlight)
			{
				_audio = base.transform.GetComponent<AudioSource>();
				_audio.volume = 0f;
				_audio.time = Random.Range(0f, _audio.clip.length);
			}
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("MotorShaft", base.gameObject);
			if (gameObject != null)
			{
				_visualMesh = gameObject.transform;
			}
		}

		private void SetupJoint()
		{
			int attachPointIndex = base.Data.AttachPointIndex;
			if (base.PartScript.Data.AttachPoints.Count > attachPointIndex)
			{
				AttachPoint attachPoint = base.PartScript.Data.AttachPoints[attachPointIndex];
				if (attachPoint.PartConnections.Count == 1)
				{
					foreach (IBodyJoint joint in base.PartScript.BodyScript.Joints)
					{
						Joint jointForAttachPoint = joint.GetJointForAttachPoint(attachPoint);
						if (!(jointForAttachPoint != null))
						{
							continue;
						}
						_joint = jointForAttachPoint as HingeJoint;
						if (_joint != null)
						{
							_rigidBody = _joint.GetComponent<Rigidbody>();
							_connectedRigidBody = _joint.connectedBody;
							ResizableWheelScript resizableWheelScript = joint.PartConnection.GetOtherPart(base.Data.Part).GetModifier<ResizableWheelData>()?.Script;
							if (resizableWheelScript != null)
							{
								SetupWithWheel(resizableWheelScript);
							}
						}
					}
					if (_joint == null)
					{
						Debug.LogError("Could not find joint for the rotator", this);
					}
				}
			}
			_maxConnectedBodyRpm = base.Data.Rpm * _rpmOverride;
			RpmReductionScalar = 1f;
		}

		private void SetupWithWheel(ResizableWheelScript resizableWheelScript)
		{
			_connectedWheel = resizableWheelScript;
			resizableWheelScript.ExternalMotorTorque = () => _motorTorqueAbs * Mathf.Sign(_motorInput);
			resizableWheelScript.AddBrakeTorque(base.Data.BrakeTorque);
		}
	}
}
