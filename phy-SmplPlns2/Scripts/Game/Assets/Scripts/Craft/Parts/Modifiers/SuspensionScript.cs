using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class SuspensionScript : PartModifierScript, IVariableOutput
	{
		private BodyJoint _bodyJoint;

		private Transform _bottomPoint;

		private float _breakTimer;

		private ConfigurableJoint _joint;

		private Transform _shaft;

		private Transform _spring;

		private Transform _topShaftMeshOrigin;

		public SuspensionData Suspension { get; set; }

		[VariableOutput("Extension")]
		private float CurrOffset { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault);
		}

		public void Initialize(SuspensionData suspension)
		{
			Suspension = suspension;
		}

		public void UpdateOutputs()
		{
			if (_joint != null && _joint.connectedBody != null)
			{
				Vector3 position = _joint.connectedBody.transform.TransformPoint(_joint.connectedAnchor);
				CurrOffset = _bottomPoint.InverseTransformPoint(position).y;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
		}

		private void ConfigureJoint()
		{
			JointDrive xDrive = default(JointDrive);
			xDrive.positionSpring = 500f * Suspension.Spring;
			xDrive.positionDamper = 35f * Suspension.Damper;
			xDrive.maximumForce = xDrive.positionSpring * 2f;
			_joint.xDrive = xDrive;
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_shaft = Utilities.FindFirstGameObjectMyselfOrChildren("TopShaft", base.PartScript.gameObject).transform;
			_spring = Utilities.FindFirstGameObjectMyselfOrChildren("Spring", base.PartScript.gameObject).transform;
			_topShaftMeshOrigin = Utilities.FindFirstGameObjectMyselfOrChildren("TopShaftMeshOrigin", base.PartScript.gameObject).transform;
			_bottomPoint = Utilities.FindFirstGameObjectMyselfOrChildren("BottomPoint", base.PartScript.gameObject).transform;
			if (base.PartScript.PhysicsEnabled)
			{
				int attachPointIndex = Suspension.AttachPointIndex;
				if (base.PartScript.Part.AttachPoints.Count > attachPointIndex)
				{
					AttachPointData attachPointData = base.PartScript.Part.AttachPoints[attachPointIndex];
					if (attachPointData.PartConnections.Count == 1)
					{
						foreach (BodyJoint joint in base.PartScript.Body.Joints)
						{
							ConfigurableJoint jointForAttachPoint = joint.GetJointForAttachPoint(attachPointData);
							if (jointForAttachPoint != null)
							{
								Rigidbody component = jointForAttachPoint.GetComponent<Rigidbody>();
								if (base.PartScript.Body.RigidBody.PhysxRigidBody == component)
								{
									component.maxDepenetrationVelocity = 1f;
									_bodyJoint = joint;
									_joint = jointForAttachPoint;
									ConfigureJoint();
									break;
								}
							}
						}
					}
				}
				if (_joint == null)
				{
					Debug.Log("Can't find joint");
				}
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			float num = 0.5f;
			if (_joint != null && !_bodyJoint.Broken && base.PartScript.Part.PartCollisionResponse != PartCollisionResponseType.None)
			{
				Vector3 position = _joint.connectedBody.transform.TransformPoint(_joint.connectedAnchor);
				Vector3 vector = _bottomPoint.InverseTransformPoint(position);
				if (vector.y > 0.8f)
				{
					_breakTimer += frame.DeltaTime;
				}
				else
				{
					_breakTimer = 0f;
				}
				if (_breakTimer > 0.5f)
				{
					_bodyJoint.Break(playSound: true);
				}
				num = vector.y;
			}
			float value = num - 0.5f;
			value = Mathf.Clamp(value, -0.4f, 2f);
			_shaft.localPosition = new Vector3(0f, value, 0f);
			float value2 = num / 0.5f;
			value2 = Mathf.Clamp(value2, 0.1f, 2f);
			_spring.transform.localScale = new Vector3(1f, value2, 1f);
			if (value > 0f)
			{
				_topShaftMeshOrigin.localScale = new Vector3(1f, 1.5f, 1f);
			}
			else
			{
				_topShaftMeshOrigin.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}
}
