using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public class BodySyncData
	{
		private BodyScript _body;

		private Vector3? _lastRelativePosition;

		private Quaternion? _lastRelativeRotation;

		public Vector3 AngularVelocity { get; set; }

		public float Delta { get; private set; }

		public short Id => (short)_body.Id;

		public BodyScript ParentBody { get; set; }

		public float PhysicsTimeOfLastSend { get; private set; }

		public Vector3 Position { get; private set; }

		public Quaternion Rotation { get; private set; }

		public Vector3? TargetPosition { get; set; }

		public Quaternion? TargetRotation { get; set; }

		public Vector3 Velocity { get; set; }

		public BodySyncData(BodyScript body)
		{
			_body = body;
		}

		public void OnSent(float physicsTime)
		{
			PhysicsTimeOfLastSend = physicsTime;
			_lastRelativeRotation = Rotation;
			_lastRelativePosition = Position;
		}

		public void Update(float physicsTime)
		{
			if (ParentBody != null)
			{
				Rotation = Quaternion.Inverse(ParentBody.transform.rotation) * _body.transform.rotation;
				Position = ParentBody.transform.InverseTransformPoint(_body.transform.position) * ParentBody.transform.lossyScale.x;
			}
			else
			{
				Position = _body.transform.position;
				Rotation = _body.transform.rotation;
				Delta = physicsTime - PhysicsTimeOfLastSend;
			}
			AngularVelocity = _body.RigidBody.angularVelocity;
			Velocity = _body.RigidBody.velocity;
			if (!_lastRelativeRotation.HasValue)
			{
				OnSent(0f);
				Delta = 0f;
			}
			else
			{
				Delta = CalculateDelta(physicsTime);
			}
		}

		private float CalculateDelta(float currentPhysicsTime)
		{
			float num = currentPhysicsTime - PhysicsTimeOfLastSend + 1f;
			return ((Position - _lastRelativePosition.Value).magnitude * num * 20f + Quaternion.Angle(Rotation, _lastRelativeRotation.Value) * num * 1f) * num;
		}
	}
}
