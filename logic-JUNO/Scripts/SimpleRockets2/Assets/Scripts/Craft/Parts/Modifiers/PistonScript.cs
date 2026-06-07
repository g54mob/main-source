using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
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
	public class PistonScript : PartModifierScript<PistonData>, IAnalyzePerformance, IDesignerUpdate, IGameLoopItem, IFlightStart, IFlightUpdate, IFlightFixedUpdate
	{
		private class PistonShaft
		{
			public float Height { get; private set; }

			public Vector3 LocalRetractedPosition { get; private set; }

			public Vector3 Offset { get; private set; }

			public Transform Transform { get; private set; }

			public PistonShaft(Transform shaft, Vector3 offset, Vector3? localRetractedPosition = null)
			{
				Transform = shaft;
				Offset = offset;
				LocalRetractedPosition = localRetractedPosition ?? shaft.localPosition;
				if (shaft.TryGetComponent<MeshRenderer>(out var component))
				{
					Quaternion localRotation = shaft.localRotation;
					shaft.rotation = Quaternion.identity;
					Height = component.bounds.size.y;
					shaft.localRotation = localRotation;
				}
			}
		}

		private AudioSource _audio;

		private IFuelSource _battery;

		private IBodyJoint _bodyJoint;

		private float _breakTimer;

		private float _cycleTime;

		private Transform _expectedJointPosition;

		private bool _initializationComplete;

		private IInputController _input;

		private ConfigurableJoint _joint;

		private Rigidbody _jointRigidbody;

		private bool _moving;

		private float _partScale = 1f;

		private List<PistonShaft> _pistonExtenders = new List<PistonShaft>();

		private PistonShaft _pistonShaft;

		private float _pitch;

		private float _powerConsumption;

		private float _speed;

		private bool _updatePistonShaft;

		private float _volume;

		public bool UsesMachNumber => false;

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			if (this != null && _initializationComplete)
			{
				float currentPosition = 0f;
				if (!base.Data.Extend)
				{
					currentPosition = base.Data.Range * _partScale;
				}
				base.Data.CurrentPosition = currentPosition;
				UpdateShaftExtension();
			}
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			_powerConsumption = 0f;
			if (!_initializationComplete)
			{
				return;
			}
			_moving = false;
			if (_input == null)
			{
				return;
			}
			IFuelSource battery = _battery;
			if ((battery == null || battery.IsEmpty) && base.Data.ConsumptionMultiplier > 0f)
			{
				return;
			}
			float num = _input.Value;
			if (base.Data.Cycle)
			{
				_cycleTime += num * base.Data.Speed * frame.DeltaTime * 20f;
				num = (Mathf.Cos(MathF.PI + _cycleTime) + 1f) / 2f;
			}
			if (!base.Data.Extend)
			{
				num = 1f - num;
			}
			float num2 = num * base.Data.Range * _partScale;
			float num3 = num2 - base.Data.CurrentPosition;
			if (Mathf.Abs(num3) < 0.001f)
			{
				base.Data.CurrentPosition = num2;
			}
			else
			{
				_volume = Mathf.Clamp01(Mathf.Abs(num3) * 25f);
				_pitch = _volume * 2f;
				_moving = true;
				float num4 = num3 * frame.DeltaTime * _speed;
				base.Data.CurrentPosition = Utilities.StepTowards(base.Data.CurrentPosition, num4, num2);
				_powerConsumption = Mathf.Abs(15f * base.Data.Scale * base.Data.ConsumptionMultiplier);
				_battery.RemoveFuel(_powerConsumption * Mathf.Abs(num4));
			}
			if (base.Data.Cycle)
			{
				base.Data.CurrentPosition = num2;
			}
			if (_updatePistonShaft)
			{
				UpdateShaftExtension();
			}
			if (_joint != null && !_bodyJoint.PartConnection.IsDestroyed)
			{
				_joint.connectedBody.WakeUp();
				_jointRigidbody.WakeUp();
				float num5 = 0f;
				if (!base.Data.Extend)
				{
					num5 = 1f * base.Data.Range * _partScale;
				}
				_joint.targetPosition = new Vector3(base.Data.CurrentPosition - num5, 0f, 0f);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_audio = base.PartScript.GameObject.GetComponent<AudioSource>();
			_speed = base.Data.Speed * base.Data.Speed * base.Data.MaxSpeed;
			_input = GetInputController();
			FindAndSetupConnectionJoint();
			UpdateScale();
			base.Data.UpdateAttachPoint();
			_initializationComplete = true;
			UpdateShaftExtension();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (!_initializationComplete)
			{
				return;
			}
			if (_joint != null && !_bodyJoint.Broken)
			{
				Vector3 position = _expectedJointPosition.position;
				Vector3 vector = _joint.connectedBody.transform.TransformPoint(_joint.connectedAnchor);
				if ((position - vector).sqrMagnitude > 0.0225f)
				{
					_breakTimer += frame.DeltaTime;
				}
				else
				{
					_breakTimer = 0f;
				}
				if (_breakTimer > 0.5f && !base.Data.PreventBreaking)
				{
					BreakJoint();
				}
			}
			if (!(_audio != null))
			{
				return;
			}
			if (_moving)
			{
				if (!_audio.isPlaying)
				{
					_audio.Play();
				}
				_audio.pitch = _pitch;
				_audio.volume = _volume;
			}
			else if (_audio.isPlaying)
			{
				_audio.Stop();
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (Game.InFlightScene)
			{
				_battery = base.PartScript.BatteryFuelSource;
				if (_jointRigidbody != base.PartScript.BodyScript.RigidBody || _joint == null)
				{
					FindAndSetupConnectionJoint();
				}
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Power Consumption", () => Units.GetPowerString(_powerConsumption * 1000f)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(Mathf.Abs(15000f * base.Data.Scale * base.Data.ConsumptionMultiplier)), null, "The power consumption of the piston per meter traveled."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			base.Data.UpdateScale();
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.6f * base.Data.Scale;
			}
			_pistonShaft.Transform.parent.parent.localScale = new Vector3(base.Data.Scale, base.Data.Scale, base.Data.Scale);
			Vector3 zero = Vector3.zero;
			zero.y -= (1f - base.Data.Scale) / 4f;
			_pistonShaft.Transform.parent.parent.localPosition = zero;
			UpdateExtenderPositions();
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.ConsumptionMultiplier > 0f)
			{
				if (_battery == null)
				{
					_battery = base.PartScript.BatteryFuelSource;
				}
				result.ValidatFuel(this, _battery, 100f * _powerConsumption);
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_partScale = base.PartScript.Data.Config.PartScale.y * base.Data.Scale;
			_expectedJointPosition = Utilities.FindFirstGameObjectMyselfOrChildren("ExpectedJointPosition", base.PartScript.GameObject).transform;
			_pistonShaft = new PistonShaft(Utilities.FindFirstGameObjectMyselfOrChildren("PistonShaft-0", base.PartScript.GameObject).transform, Vector3.zero);
			int num = 1;
			Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren("PistonShaft-" + num, base.PartScript.GameObject)?.transform;
			while (transform != null)
			{
				_pistonExtenders.Add(new PistonShaft(transform, (num == 1) ? (Vector3.up * 0.04f) : Vector3.zero));
				num++;
				transform = Utilities.FindFirstGameObjectMyselfOrChildren("PistonShaft-" + num, base.PartScript.GameObject)?.transform;
			}
			if (!Game.InFlightScene)
			{
				UpdateScale();
				base.Data.UpdateAttachPoint();
				_initializationComplete = true;
				UpdateShaftExtension();
			}
		}

		private void BreakJoint()
		{
			_bodyJoint.Destroy();
		}

		private void FindAndSetupConnectionJoint()
		{
			int attachPointIndex = base.Data.AttachPointIndex;
			if (base.PartScript.Data.AttachPoints.Count <= attachPointIndex)
			{
				return;
			}
			AttachPoint attachPoint = base.PartScript.Data.AttachPoints[attachPointIndex];
			if (attachPoint.PartConnections.Count == 1)
			{
				foreach (IBodyJoint joint in base.PartScript.BodyScript.Joints)
				{
					ConfigurableJoint configurableJoint = joint.GetJointForAttachPoint(attachPoint) as ConfigurableJoint;
					if (configurableJoint != null)
					{
						Rigidbody component = configurableJoint.GetComponent<Rigidbody>();
						if (base.PartScript.BodyScript.RigidBody == component)
						{
							_bodyJoint = joint;
							_updatePistonShaft = true;
							configurableJoint.xMotion = ConfigurableJointMotion.Free;
							configurableJoint.yMotion = ConfigurableJointMotion.Free;
							configurableJoint.zMotion = ConfigurableJointMotion.Free;
							float num = 4000000f * base.Data.Scale * base.Data.Scale;
							JointDrive jointDrive = new JointDrive
							{
								maximumForce = num,
								positionSpring = num
							};
							configurableJoint.xDrive = jointDrive;
							configurableJoint.yDrive = jointDrive;
							configurableJoint.zDrive = jointDrive;
							_joint = configurableJoint;
							_jointRigidbody = component;
							break;
						}
					}
				}
				return;
			}
			if (attachPoint.PartConnections.Count == 0)
			{
				_updatePistonShaft = true;
			}
		}

		private void UpdateExtenderPositions()
		{
			if (_pistonExtenders.Count != 0)
			{
				_pistonExtenders[0].Transform.localPosition = Vector3.Max(_pistonExtenders[0].LocalRetractedPosition, _pistonShaft.Transform.localPosition - Vector3.up * _pistonShaft.Height / 2f + _pistonExtenders[0].Offset);
				for (int i = 1; i < _pistonExtenders.Count; i++)
				{
					_pistonExtenders[i].Transform.localPosition = Vector3.Max(_pistonExtenders[i].LocalRetractedPosition, _pistonExtenders[i - 1].Transform.localPosition - Vector3.up * _pistonExtenders[i - 1].Height + _pistonExtenders[i].Offset);
				}
			}
		}

		private void UpdateShaftExtension()
		{
			if (_initializationComplete)
			{
				_pistonShaft.Transform.localPosition = new Vector3(0f, base.Data.CurrentPosition / _partScale, 0f);
				UpdateExtenderPositions();
			}
		}
	}
}
