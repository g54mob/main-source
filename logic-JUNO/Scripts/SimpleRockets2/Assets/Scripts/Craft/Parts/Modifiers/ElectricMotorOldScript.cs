using System;
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
	public class ElectricMotorOldScript : PartModifierScript<ElectricMotorOldData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate, IFlightFixedUpdate
	{
		private Transform _attachPointPositions;

		private AudioSource _audio;

		private IFuelSource _battery;

		private Vector3 _bodyRelativeAngularVelocity;

		private IInputController _brakeController;

		private float _brakeInput;

		private float _brakeTorque;

		private bool _bypassBrakeController;

		private Rigidbody _connectedRigidBody;

		private ResizableWheelScript _connectedWheel;

		private float _currentRPM;

		private float _currentTorque;

		private ConfigurableJoint _joint;

		private Vector3 _jointRelativeAngularVelocity;

		private float _maxBrakeTorque;

		private float _maxMotorTorque;

		private IInputController _motorController;

		private float _motorInput;

		private float _motorTorque;

		private float _powerUsage;

		private Rigidbody _rigidBody;

		private Transform _scalar;

		private float _speed;

		private Vector3 _targetAngularVelocity = Vector3.zero;

		private Transform _visualMesh;

		public float CurrentRpm => _currentRPM;

		public float PowerUsage => _powerUsage;

		public bool UsesMachNumber => false;

		private float MaxPowerConsumption => base.Data.Torque * base.Data.PowerUsagePerTorque;

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (!(_joint != null))
			{
				return;
			}
			_bodyRelativeAngularVelocity = _connectedRigidBody.angularVelocity - _rigidBody.angularVelocity;
			_jointRelativeAngularVelocity = GetJointRelativeAngularVelocity();
			IFuelSource battery = _battery;
			if (battery == null || battery.IsEmpty)
			{
				if (_connectedWheel == null)
				{
					SetJointDrive(base.Data.StaticResistance, Vector3.zero);
				}
				_powerUsage = 0f;
				return;
			}
			if (_connectedWheel == null && (Mathf.Abs(_targetAngularVelocity.x) > Mathf.Abs(_jointRelativeAngularVelocity.x) || (Mathf.Sign(_targetAngularVelocity.x) != Mathf.Sign(_jointRelativeAngularVelocity.x) && !Mathf.Approximately(_currentTorque, 0f)) || _brakeTorque > 0f))
			{
				float num = ((Mathf.Abs(_motorTorque) > 0f) ? 0f : (base.Data.StaticResistance * Mathf.Sign(_currentTorque)));
				SetJointDrive(_currentTorque - num, _targetAngularVelocity);
				if (_rigidBody.IsSleeping())
				{
					_rigidBody.WakeUp();
				}
				if (_connectedRigidBody.IsSleeping())
				{
					_connectedRigidBody.WakeUp();
				}
			}
			else if (_connectedWheel == null)
			{
				SetJointDrive(base.Data.StaticResistance, Vector3.zero);
			}
			if (!Mathf.Approximately(_motorInput, 0f))
			{
				_powerUsage = Mathf.Abs(_motorInput) * MaxPowerConsumption;
				float num2 = 0.001f * _powerUsage * frame.DeltaTime;
				if (num2 > 0f)
				{
					_battery.RemoveFuel(num2);
				}
			}
			else
			{
				_powerUsage = 0f;
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
				_motorTorque = Mathf.Abs(_motorInput) * _maxMotorTorque;
				_brakeTorque = Mathf.Abs(_brakeInput) * _maxBrakeTorque;
				if (_motorTorque > _brakeTorque)
				{
					_currentTorque = _motorTorque - _brakeTorque;
					_targetAngularVelocity.x = _motorInput * _speed;
				}
				else
				{
					_currentTorque = _brakeTorque - _motorTorque;
					_targetAngularVelocity.x = 0f;
				}
				_currentTorque *= 0.01f;
				if (_connectedWheel == null)
				{
					_currentRPM = _jointRelativeAngularVelocity.x / (MathF.PI * 2f) * 60f;
				}
				else
				{
					_currentRPM = Mathf.Abs(_connectedWheel.CurrentRpm);
				}
				if (_audio != null && base.Data.SoundVolume > 0f)
				{
					float b = 0.0008f * _powerUsage * base.Data.SoundVolume;
					float num = Mathf.Max(_audio.volume, b);
					num -= frame.DeltaTime * 3f;
					num = Mathf.Clamp(num, 0f, 1f);
					_audio.volume = num;
					_audio.pitch = 1f + Mathf.Abs(_currentRPM) / 1000f * 0.25f;
					if (_audio.volume > 0.1f && !_audio.isPlaying)
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

		public Vector3 GetJointRelativeAngularVelocity()
		{
			Quaternion rotation = _rigidBody.rotation;
			Vector3 axis = _joint.axis;
			Vector3 normalized = Vector3.Cross(_joint.axis, _joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, axis).normalized;
			return Quaternion.Inverse(Quaternion.LookRotation(normalized, normalized2)) * (Quaternion.Inverse(rotation) * -_bodyRelativeAngularVelocity);
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
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(_powerUsage)), "Electric Motor");
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
				result.ValidatFuel(this, _battery, _powerUsage * 0.1f);
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

		private void SetJointDrive(float driveTorque, Vector3 targetAngularVelocity)
		{
			JointDrive angularXDrive = _joint.angularXDrive;
			angularXDrive.positionDamper = driveTorque;
			_joint.angularXDrive = angularXDrive;
			_joint.targetAngularVelocity = targetAngularVelocity;
		}

		private void Setup(bool inFlight)
		{
			_audio = base.transform.GetComponent<AudioSource>();
			_audio.volume = 0f;
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
						if (jointForAttachPoint != null)
						{
							_joint = jointForAttachPoint as ConfigurableJoint;
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
			_speed = MathF.PI * 2f * base.Data.Rpm / 60f;
			_maxMotorTorque = base.Data.Torque;
			_maxBrakeTorque = base.Data.BrakeTorque;
			if (_joint != null && _connectedWheel == null)
			{
				JointDrive angularXDrive = _joint.angularXDrive;
				angularXDrive.maximumForce = float.PositiveInfinity;
				angularXDrive.positionSpring = 0f;
				_joint.angularXDrive = angularXDrive;
				_joint.rotationDriveMode = RotationDriveMode.XYAndZ;
				_joint.angularXMotion = ConfigurableJointMotion.Free;
				if (_connectedRigidBody.maxAngularVelocity < _speed)
				{
					_connectedRigidBody.maxAngularVelocity = _speed;
				}
			}
		}

		private void SetupWithWheel(ResizableWheelScript resizableWheelScript)
		{
			_connectedWheel = resizableWheelScript;
			resizableWheelScript.ExternalMotorTorque = () => _motorTorque * Mathf.Sign(_motorInput);
			resizableWheelScript.AddBrakeTorque(base.Data.BrakeTorque);
		}
	}
}
