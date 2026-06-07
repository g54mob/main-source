using System.Collections.Generic;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class SuspensionScript : PartModifierScript<SuspensionData>, IDesignerStart, IGameLoopItem, IFlightStart, IFlightUpdate
	{
		private Transform _attachPointPositions;

		private Transform _scalar;

		private Dictionary<AttachPoint, Vector3> _attachPointsOriginalLocalPositions = new Dictionary<AttachPoint, Vector3>();

		private IBodyJoint _bodyJoint;

		private Transform _bottomPoint;

		private float _breakTimer;

		private ConfigurableJoint _joint;

		private Transform _shaft;

		private Transform _spring;

		private Transform _topShaftMeshOrigin;

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			UpdateScale();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			UpdateScale();
			_shaft = Utilities.FindFirstGameObjectMyselfOrChildren("TopShaft", base.PartScript.GameObject).transform;
			_spring = Utilities.FindFirstGameObjectMyselfOrChildren("Spring", base.PartScript.GameObject).transform;
			_topShaftMeshOrigin = Utilities.FindFirstGameObjectMyselfOrChildren("TopShaftMeshOrigin", base.PartScript.GameObject).transform;
			_bottomPoint = Utilities.FindFirstGameObjectMyselfOrChildren("BottomPoint", base.PartScript.GameObject).transform;
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
							Rigidbody component = jointForAttachPoint.GetComponent<Rigidbody>();
							if (base.PartScript.BodyScript.RigidBody == component)
							{
								component.maxDepenetrationVelocity = 1f;
								_bodyJoint = joint;
								_joint = jointForAttachPoint as ConfigurableJoint;
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

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			float num = 0.5f;
			if (_joint != null && !_bodyJoint.Broken)
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
				if (_breakTimer > 0.5f && !base.Data.PreventBreaking)
				{
					_bodyJoint.Destroy();
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
				_topShaftMeshOrigin.localScale = Vector3.one;
			}
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
			_scalar.localScale = base.Data.Size;
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointPosition in _attachPointPositions)
			{
				foreach (AttachPoint attachPoint in base.Data.Part.AttachPoints)
				{
					if (!(attachPoint.Name == attachPointPosition.name))
					{
						continue;
					}
					attachPoint.Scale = 0.6f * base.Data.Size.x;
					Vector3 position = attachPoint.Position;
					attachPoint.Position = attachPointPosition.localPosition * base.Data.Scale + _scalar.localPosition * (1f - base.Data.Scale);
					if (!(attachPoint.AttachPointScript != null))
					{
						break;
					}
					if (repositionAttachedParts)
					{
						Vector3 position2 = attachPoint.Position;
						Vector3 delta = attachPoint.AttachPointScript.transform.parent.TransformVector(position2 - position);
						foreach (PartConnection partConnection in attachPoint.PartConnections)
						{
							DesignerUtilities.RepositionParts(base.Data.Part, partConnection, delta, movedParts);
						}
					}
					attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
					break;
				}
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("Suspension", base.PartScript.GameObject).transform;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPositions", _scalar.gameObject);
			if (gameObject != null)
			{
				_attachPointPositions = gameObject.transform;
			}
			UpdateScale();
			if (!Game.InDesignerScene)
			{
				return;
			}
			foreach (AttachPoint attachPoint in base.Data.Part.AttachPoints)
			{
				_attachPointsOriginalLocalPositions[attachPoint] = attachPoint.Position;
			}
		}

		private void BreakJoint()
		{
			_bodyJoint.Destroy();
		}

		private void ConfigureJoint()
		{
			JointDrive xDrive = default(JointDrive);
			xDrive.positionSpring = 1000f * base.Data.Spring;
			xDrive.positionDamper = 70f * base.Data.Damper;
			xDrive.maximumForce = xDrive.positionSpring * 2f;
			_joint.xDrive = xDrive;
			_joint.xMotion = ConfigurableJointMotion.Free;
			_joint.targetPosition = new Vector3(0.5f, 0f, 0f) * base.Data.Part.Config.PartScale.y * base.Data.Scale;
			_joint.anchor = _bodyJoint.Body.Transform.InverseTransformPoint(_bottomPoint.position);
		}
	}
}
