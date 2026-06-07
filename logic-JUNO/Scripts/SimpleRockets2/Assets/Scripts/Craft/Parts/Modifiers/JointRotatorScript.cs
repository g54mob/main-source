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
	public class JointRotatorScript : PartModifierScript<JointRotatorData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate, IFlightFixedUpdate, IDesignerStart
	{
		private Transform _attachPointPositions;

		private AudioSource _audio;

		private GameObject _axel;

		private IFuelSource _battery;

		private Rigidbody _connectedRigidBody;

		private IInputController _controller;

		private bool _floppyJoint;

		private bool _freeSpin;

		private ConfigurableJoint _joint;

		private float _powerConsumption;

		private Rigidbody _rigidBody;

		private Transform _scalar;

		private float _speed;

		private float _targetAngle;

		private Transform _visualMesh;

		public bool UsesMachNumber => false;

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			_controller = GetInputController();
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			_powerConsumption = 0f;
			if (!(_joint != null))
			{
				return;
			}
			IFuelSource battery = _battery;
			if (((battery == null || battery.IsEmpty) && base.Data.ConsumptionMultiplier != 0f) || _freeSpin || _floppyJoint)
			{
				return;
			}
			float num = _targetAngle - base.Data.Angle;
			if (num != 0f)
			{
				float num2 = num / Mathf.Abs(num) * _speed * frame.DeltaTime;
				if (Mathf.Abs(num2) > Mathf.Abs(num))
				{
					num2 = num;
				}
				base.Data.Angle += num2;
				_powerConsumption = 15f * base.Data.Scale * base.Data.ConsumptionMultiplier;
				_battery.RemoveFuel(_powerConsumption * frame.DeltaTime);
			}
			_joint.targetRotation = Quaternion.Euler(0f - base.Data.Angle, 0f, 0f);
			if (_rigidBody.IsSleeping())
			{
				_rigidBody.WakeUp();
			}
			if (_connectedRigidBody.IsSleeping())
			{
				_connectedRigidBody.WakeUp();
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_controller = GetInputController();
			_targetAngle = (_controller?.Value ?? 0f) * base.Data.Range;
			SetupJoint();
			UpdateScale();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (_joint != null)
			{
				_targetAngle = _controller.Value * base.Data.Range;
				if (_audio != null && base.Data.SoundVolume > 0f)
				{
					float value = Mathf.Abs(_targetAngle - base.Data.Angle);
					value = Mathf.Clamp(value, 0f, 0.5f) * base.Data.SoundVolume;
					float num = Mathf.Max(_audio.volume, value);
					num -= frame.DeltaTime * 3f;
					num = Mathf.Clamp(num, 0f, 1f);
					_audio.volume = num;
					if (_audio.volume > 0.01f && !_audio.isPlaying)
					{
						_audio.Play();
					}
				}
				if (_visualMesh != null && !_floppyJoint)
				{
					_visualMesh.localRotation = Quaternion.Euler(0f, 0f - base.Data.Angle, 0f);
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
			CheckJoint();
			_battery = base.PartScript.BatteryFuelSource;
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
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(_powerConsumption * 1000f)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(15000f * base.Data.Scale * base.Data.ConsumptionMultiplier), null, "The power consumption of the servo."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			SetBaseMeshesActiveByMode(base.Data.MeshBaseMode);
			UpdateScale(repositionAttachedParts: true);
		}

		public void SetBaseMeshesActiveByMode(JointRotatorData.BaseMode baseMode)
		{
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("RotatorBaseExtension", base.gameObject);
			GameObject gameObject2 = Utilities.FindFirstGameObjectMyselfOrChildren("RotatorBase", base.gameObject);
			switch (baseMode)
			{
			case JointRotatorData.BaseMode.Extended:
				gameObject2?.SetActive(value: true);
				gameObject?.SetActive(value: true);
				break;
			case JointRotatorData.BaseMode.Normal:
				gameObject2?.SetActive(value: true);
				gameObject.SetActive(value: false);
				break;
			case JointRotatorData.BaseMode.None:
				gameObject2?.SetActive(value: false);
				gameObject.SetActive(value: false);
				break;
			default:
				Debug.LogError("Unsupported JointRotatorData.BaseMode \"" + baseMode.ToString() + "\"");
				break;
			}
		}

		public void UpdateScale(bool repositionAttachedParts = false)
		{
			if (!(_scalar != null) || !(_attachPointPositions != null))
			{
				return;
			}
			_scalar.localScale = Vector3.one * base.Data.Scale;
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointTransform in _attachPointPositions)
			{
				AttachPoint attachPoint = base.Data.Part.AttachPoints.Where((AttachPoint x) => x.Name == attachPointTransform.name).FirstOrDefault();
				if (attachPoint == null)
				{
					continue;
				}
				attachPoint.Scale = 0.6f * base.Data.Scale;
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
			if (base.Data.ConsumptionMultiplier > 0f)
			{
				result.ValidatFuel(this, _battery, 100f * _powerConsumption);
			}
		}

		public void VisibilityAngle(bool visible)
		{
			if (_controller != null && _controller.Visible != visible)
			{
				_controller.Visible = visible;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("Mesh", base.gameObject).transform;
			_axel = Utilities.FindFirstGameObjectMyselfOrChildren("Axel", base.gameObject);
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

		private void Setup(bool inFlight)
		{
			if (inFlight)
			{
				_audio = base.transform.GetComponent<AudioSource>();
				_audio.volume = 0f;
				_audio.time = Random.Range(0f, _audio.clip.length);
			}
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Hinge", base.gameObject);
			if (gameObject != null)
			{
				_visualMesh = gameObject.transform;
			}
			SetBaseMeshesActiveByMode(base.Data.MeshBaseMode);
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
							JointDrive angularXDrive = _joint.angularXDrive;
							angularXDrive.positionSpring = 400000f * base.Data.Scale * base.Data.Scale;
							_joint.angularXDrive = angularXDrive;
							_rigidBody = _joint.GetComponent<Rigidbody>();
							_connectedRigidBody = _joint.connectedBody;
						}
					}
					if (_joint == null)
					{
						Debug.LogError("Could not find joint for the rotator", this);
					}
				}
			}
			_speed = base.Data.Speed * base.Data.Speed * base.Data.MaxSpeed;
			if (_joint != null)
			{
				JointDrive angularXDrive2 = _joint.angularXDrive;
				angularXDrive2.positionDamper *= base.Data.DamperMultiplier;
				_joint.angularXDrive = angularXDrive2;
				if (base.Data.Range < 0.0001f && base.Data.AllowFreeSpin)
				{
					_freeSpin = true;
					angularXDrive2.positionDamper = 0f;
					angularXDrive2.positionSpring = 0f;
					_joint.angularXDrive = angularXDrive2;
				}
				else if (base.Data.Speed < 0.0001f)
				{
					_floppyJoint = true;
					angularXDrive2.positionDamper = 0f;
					angularXDrive2.positionSpring = 0f;
					_joint.angularXDrive = angularXDrive2;
					_joint.angularXMotion = ConfigurableJointMotion.Limited;
					SoftJointLimit lowAngularXLimit = _joint.lowAngularXLimit;
					lowAngularXLimit.limit = 0f - base.Data.Range;
					_joint.lowAngularXLimit = lowAngularXLimit;
					lowAngularXLimit.limit = base.Data.Range;
					_joint.highAngularXLimit = lowAngularXLimit;
				}
				if (_floppyJoint && _visualMesh != null && _joint != null)
				{
					_visualMesh.parent = _joint.connectedBody.transform;
				}
			}
		}
	}
}
