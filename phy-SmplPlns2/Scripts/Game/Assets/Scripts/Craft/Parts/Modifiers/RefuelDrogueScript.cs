using System;
using Assets.Scripts.Flight;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class RefuelDrogueScript : PartModifierScript
	{
		public const float MaxAttractDistance = 7f;

		private Func<bool> _activator;

		private ConfigurableJoint _assistJoint;

		private Rigidbody _fixedRefRb;

		private int _frameCount;

		private int _lastFueledFrame = -1;

		private JointDrive _positionDrive;

		private ConfigurableJoint _stabilisationJoint;

		public float AssistStrength { get; set; } = 1f;

		public RefuelDrogueData Modifier { get; set; }

		private Rigidbody FixedRefRigidbody
		{
			get
			{
				if (_fixedRefRb == null)
				{
					_fixedRefRb = new GameObject("FixedRefRb").AddComponent<Rigidbody>();
					_fixedRefRb.constraints = RigidbodyConstraints.FreezeAll;
					_fixedRefRb.transform.parent = base.transform;
					_fixedRefRb.transform.localPosition = Vector3.zero;
					_fixedRefRb.transform.localRotation = Quaternion.identity;
				}
				return _fixedRefRb;
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		protected virtual void OnTriggerStay(Collider other)
		{
			int frameCount = Time.frameCount;
			if (_lastFueledFrame == frameCount)
			{
				return;
			}
			BodyScript bodyScript = other.attachedRigidbody?.GetComponent<BodyScript>();
			if (bodyScript != null)
			{
				_lastFueledFrame = frameCount;
				if (_activator())
				{
					AircraftScript aircraft = base.PartScript.Aircraft;
					AircraftScript aircraft2 = bodyScript.Aircraft;
					float fuel = aircraft.Fuel;
					float num = aircraft2.FuelCapacity - aircraft2.Fuel;
					float num2 = Time.deltaTime * Modifier.TransferRate;
					float amount = Mathf.Min(fuel, num, num2);
					aircraft.UseFuel(amount);
					aircraft2.GiveFuel(amount);
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void CreateAssistJoint()
		{
			Rigidbody physxRigidBody = base.PartScript.Body.RigidBody.PhysxRigidBody;
			_positionDrive = new JointDrive
			{
				positionSpring = 30f * AssistStrength,
				positionDamper = 15f * AssistStrength,
				maximumForce = float.MaxValue
			};
			ConfigurableJoint configurableJoint = physxRigidBody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.enableCollision = true;
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.axis = Vector3.zero;
			configurableJoint.secondaryAxis = Vector3.zero;
			configurableJoint.connectedAnchor = Vector3.zero;
			_assistJoint = configurableJoint;
		}

		private void CreateStablisationJoint()
		{
			ConfigurableJoint configurableJoint = base.PartScript.Body.RigidBody.PhysxRigidBody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.connectedBody = FixedRefRigidbody;
			configurableJoint.axis = default(Vector3);
			configurableJoint.secondaryAxis = default(Vector3);
			configurableJoint.rotationDriveMode = RotationDriveMode.Slerp;
			configurableJoint.configuredInWorldSpace = false;
			configurableJoint.swapBodies = true;
			_stabilisationJoint = configurableJoint;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_frameCount < 5)
			{
				_frameCount++;
			}
			else if (_stabilisationJoint == null)
			{
				CreateStablisationJoint();
			}
			else if (_frameCount < 10)
			{
				_frameCount++;
			}
			if (_activator())
			{
				Vector3 position = base.transform.position;
				float drag = 0.5f;
				for (int i = 0; i < 6; i++)
				{
					base.PartScript.Body.DragPhysics.AddFrameDrag((PartDrag.DragDirection)i, drag, position);
				}
			}
			UpdateJoints();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (loadContext != CraftLoadContext.Flight)
			{
				base.enabled = false;
				return UniTask.CompletedTask;
			}
			if (string.IsNullOrWhiteSpace(Modifier.ActivationString) || Modifier.ActivationString == "None")
			{
				_activator = () => true;
			}
			else
			{
				_activator = base.Controls.GetActivatorGetter(Modifier.ActivationString, base.PartScript);
			}
			return UniTask.CompletedTask;
		}

		private void UpdateJoints()
		{
			Rigidbody physxRigidBody = base.PartScript.Body.RigidBody.PhysxRigidBody;
			if (_frameCount >= 10)
			{
				Vector3 toDirection = physxRigidBody.linearVelocity - base.PartScript.Aircraft.WindVelocity;
				_fixedRefRb.rotation = Quaternion.FromToRotation(Vector3.down, toDirection);
				_stabilisationJoint.targetRotation = Quaternion.identity;
				_stabilisationJoint.slerpDrive = new JointDrive
				{
					positionSpring = Mathf.Clamp(toDirection.sqrMagnitude * 0.5f - 50f, 0f, 50f),
					positionDamper = 1f,
					maximumForce = float.MaxValue
				};
			}
			if (AssistStrength > 0f)
			{
				float num = float.PositiveInfinity;
				Vector3 position = base.transform.position;
				RefuelProbeScript refuelProbeScript = null;
				AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
				if (aircraftScript != null)
				{
					foreach (RefuelProbeScript refuelProbe in aircraftScript.RefuelProbes)
					{
						float sqrMagnitude = (refuelProbe.ProbePos - position).sqrMagnitude;
						if ((refuelProbeScript == null || sqrMagnitude < num) && sqrMagnitude < 49f)
						{
							refuelProbeScript = refuelProbe;
							num = sqrMagnitude;
						}
					}
				}
				if (refuelProbeScript != null)
				{
					if (_assistJoint == null)
					{
						CreateAssistJoint();
					}
					Rigidbody physxRigidBody2 = refuelProbeScript.PartScript.Body.RigidBody.PhysxRigidBody;
					if (_assistJoint.connectedBody != physxRigidBody2)
					{
						_assistJoint.connectedBody = physxRigidBody2;
						_assistJoint.anchor = physxRigidBody.centerOfMass + physxRigidBody.transform.InverseTransformVector(base.transform.up * 0.1f);
						_assistJoint.connectedAnchor = physxRigidBody2.transform.InverseTransformPoint(refuelProbeScript.transform.position);
						_assistJoint.targetPosition = default(Vector3);
						_assistJoint.xDrive = _positionDrive;
						_assistJoint.yDrive = default(JointDrive);
						_assistJoint.zDrive = _positionDrive;
					}
					return;
				}
			}
			if (_assistJoint != null && _assistJoint.connectedBody != null)
			{
				_assistJoint.connectedBody = null;
				_assistJoint.xDrive = default(JointDrive);
				_assistJoint.yDrive = default(JointDrive);
				_assistJoint.zDrive = default(JointDrive);
			}
		}
	}
}
