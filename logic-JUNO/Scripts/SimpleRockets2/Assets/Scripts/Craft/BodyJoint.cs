using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyJoint : IBodyJoint
	{
		private List<BodyPhysicsJoint> _joints = new List<BodyPhysicsJoint>();

		public IBodyScript Body { get; private set; }

		public bool Broken { get; set; }

		public IBodyScript ConnectedBody { get; private set; }

		public Rigidbody IntermediaryRigidbody { get; set; }

		public IReadOnlyList<BodyPhysicsJoint> Joints => _joints;

		public PartConnection PartConnection { get; private set; }

		public BodyJoint(PartConnection partConnection, IBodyScript body, IBodyScript connectedBody)
		{
			PartConnection = partConnection;
			PartConnection.Destroyed += OnPartConnectionDestroyed;
			Body = body;
			ConnectedBody = connectedBody;
		}

		public void Destroy()
		{
			Destroy(true);
		}

		public void Destroy(bool destroyPartConnection = true)
		{
			if (!Broken)
			{
				PartConnection.Destroyed -= OnPartConnectionDestroyed;
				DestroyPhysicsJoints();
				Body.Joints.Remove(this);
				ConnectedBody.Joints.Remove(this);
				if (destroyPartConnection)
				{
					PartConnection.DestroyConnection();
					Body.CraftScript.SetStructureChanged();
				}
			}
		}

		public void FlightEnd()
		{
			PartConnection.Destroyed -= OnPartConnectionDestroyed;
		}

		public Joint GetJointForAttachPoint(AttachPoint attachPoint)
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

		public IBodyScript OtherBody(IBodyScript body)
		{
			if (body == Body)
			{
				return ConnectedBody;
			}
			return Body;
		}

		public void SetJoint(Joint joint, AttachPoint attachPoint)
		{
			_joints.Add(new BodyPhysicsJoint(joint, attachPoint));
		}

		private void DestroyPhysicsJoints()
		{
			Broken = true;
			for (int i = 0; i < _joints.Count; i++)
			{
				if (_joints[i].Joint != null)
				{
					_joints[i].Joint.connectedBody = null;
					Object.Destroy(_joints[i].Joint);
				}
			}
			_joints.Clear();
			if (IntermediaryRigidbody != null)
			{
				Object.Destroy(IntermediaryRigidbody.gameObject);
				IntermediaryRigidbody = null;
			}
		}

		private void OnPartConnectionDestroyed(PartConnection partConnection)
		{
			Destroy(destroyPartConnection: false);
		}
	}
}
