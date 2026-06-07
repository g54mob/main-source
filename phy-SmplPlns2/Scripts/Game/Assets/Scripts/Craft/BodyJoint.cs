using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyJoint
	{
		private class JointInfo
		{
			public AttachPointData AttachPoint { get; set; }

			public ConfigurableJoint Joint { get; set; }
		}

		private List<JointInfo> _joints = new List<JointInfo>();

		public BodyScript BodyA { get; set; }

		public BodyScript BodyB { get; set; }

		public bool BodyIslandBoundary { get; set; }

		public bool Broken { get; set; }

		public Rigidbody IntermediaryRigidbody { get; set; }

		public PartConnection PartConnection { get; set; }

		public bool PreventInertiaTensorDiffusion { get; set; }

		public BodyJoint(PartConnection partConnection, BodyScript bodyA, BodyScript bodyB)
		{
			PartConnection = partConnection;
			BodyA = bodyA;
			BodyB = bodyB;
		}

		public void Break(bool playSound)
		{
			if (!Broken)
			{
				if (playSound)
				{
					AudioManager.PlaySound(AudioStore.PartBreakOffAlternate, _joints[0].Joint.transform.position);
				}
				DestroyPhysicsJoints();
				BodyA.Joints.Remove(this);
				BodyB.Joints.Remove(this);
				PartConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
			}
		}

		public void DestroyPhysicsJoints(bool destroyImmediately = false)
		{
			Broken = true;
			for (int i = 0; i < _joints.Count; i++)
			{
				_joints[i].Joint.connectedBody = null;
				if (destroyImmediately)
				{
					Object.DestroyImmediate(_joints[i].Joint);
				}
				else
				{
					Object.Destroy(_joints[i].Joint);
				}
			}
			_joints.Clear();
			if (IntermediaryRigidbody != null)
			{
				if (destroyImmediately)
				{
					Object.DestroyImmediate(IntermediaryRigidbody.gameObject);
				}
				else
				{
					Object.Destroy(IntermediaryRigidbody.gameObject);
				}
				IntermediaryRigidbody = null;
			}
		}

		public ConfigurableJoint GetJointForAttachPoint(AttachPointData attachPoint)
		{
			for (int i = 0; i < _joints.Count; i++)
			{
				if (_joints[i].AttachPoint == attachPoint)
				{
					return _joints[i].Joint;
				}
			}
			return null;
		}

		public bool HasJoint(Joint joint)
		{
			for (int i = 0; i < _joints.Count; i++)
			{
				if (_joints[i].Joint == joint)
				{
					return true;
				}
			}
			return false;
		}

		public BodyScript OtherBody(BodyScript body)
		{
			if (body == BodyA)
			{
				return BodyB;
			}
			return BodyA;
		}

		public void SetJoint(ConfigurableJoint joint, AttachPointData attachPoint)
		{
			_joints.Add(new JointInfo
			{
				Joint = joint,
				AttachPoint = attachPoint
			});
		}
	}
}
