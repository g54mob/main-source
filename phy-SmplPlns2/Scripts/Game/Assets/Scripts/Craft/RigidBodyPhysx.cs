using System;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class RigidBodyPhysx : IRigidBody
	{
		private Rigidbody _rigidbody;

		public bool activeInHierarchy => _rigidbody.gameObject.activeInHierarchy;

		public bool activeSelf => _rigidbody.gameObject.activeSelf;

		public float angularDrag
		{
			get
			{
				return _rigidbody.angularDamping;
			}
			set
			{
				_rigidbody.angularDamping = value;
			}
		}

		public Vector3 angularVelocity
		{
			get
			{
				return _rigidbody.angularVelocity;
			}
			set
			{
				_rigidbody.angularVelocity = value;
			}
		}

		public bool automaticCenterOfMass
		{
			get
			{
				return _rigidbody.automaticCenterOfMass;
			}
			set
			{
				_rigidbody.automaticCenterOfMass = value;
			}
		}

		public bool automaticInertiaTensor
		{
			get
			{
				return _rigidbody.automaticInertiaTensor;
			}
			set
			{
				_rigidbody.automaticInertiaTensor = value;
			}
		}

		public Vector3 centerOfMass
		{
			get
			{
				return _rigidbody.centerOfMass;
			}
			set
			{
				_rigidbody.centerOfMass = value;
			}
		}

		public CollisionDetectionMode collisionDetectionMode
		{
			get
			{
				return _rigidbody.collisionDetectionMode;
			}
			set
			{
				_rigidbody.collisionDetectionMode = value;
			}
		}

		public float drag
		{
			get
			{
				return _rigidbody.linearDamping;
			}
			set
			{
				_rigidbody.linearDamping = value;
			}
		}

		public Vector3 inertiaTensor => _rigidbody.inertiaTensor;

		public bool IsDead => _rigidbody == null;

		public bool isKinematic
		{
			get
			{
				return _rigidbody.isKinematic;
			}
			set
			{
				_rigidbody.isKinematic = value;
			}
		}

		public float mass
		{
			get
			{
				return _rigidbody.mass;
			}
			set
			{
				_rigidbody.mass = value;
			}
		}

		public float maxAngularVelocity
		{
			get
			{
				return _rigidbody.maxAngularVelocity;
			}
			set
			{
				_rigidbody.maxAngularVelocity = value;
			}
		}

		public float maxDepenetrationVelocity
		{
			get
			{
				return _rigidbody.maxDepenetrationVelocity;
			}
			set
			{
				_rigidbody.maxDepenetrationVelocity = value;
			}
		}

		public Rigidbody PhysxRigidBody => _rigidbody;

		public Vector3 position
		{
			get
			{
				return _rigidbody.position;
			}
			set
			{
				_rigidbody.position = value;
			}
		}

		public Quaternion rotation
		{
			get
			{
				return _rigidbody.rotation;
			}
			set
			{
				_rigidbody.rotation = value;
			}
		}

		public int solverIterations
		{
			get
			{
				return _rigidbody.solverIterations;
			}
			set
			{
				_rigidbody.solverIterations = value;
			}
		}

		public RigidBodyType Type => RigidBodyType.Local;

		public bool useGravity
		{
			get
			{
				return _rigidbody.useGravity;
			}
			set
			{
				_rigidbody.useGravity = value;
			}
		}

		public Vector3 velocity
		{
			get
			{
				return _rigidbody.linearVelocity;
			}
			set
			{
				_rigidbody.linearVelocity = value;
			}
		}

		public Vector3 worldCenterOfMass => _rigidbody.worldCenterOfMass;

		public RigidBodyPhysx(Rigidbody rigidbody)
		{
			_rigidbody = rigidbody;
		}

		public void AddForce(Vector3 force)
		{
			_rigidbody.AddForce(force);
		}

		public void AddForceAtPosition(Vector3 force, Vector3 position)
		{
			_rigidbody.AddForceAtPosition(force, position);
		}

		public void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode forceMode)
		{
			_rigidbody.AddForceAtPosition(force, position, forceMode);
		}

		public void AddRelativeTorque(float x, float y, float z)
		{
			_rigidbody.AddRelativeTorque(x, y, z);
		}

		public void AddTorque(Vector3 torque)
		{
			_rigidbody.AddTorque(torque);
		}

		public Vector3 ClosestPointOnBounds(Vector3 position)
		{
			return _rigidbody.ClosestPointOnBounds(position);
		}

		public Vector3 GetPointVelocity(Vector3 worldPoint)
		{
			return _rigidbody.GetPointVelocity(worldPoint);
		}

		public Vector3 InverseTransformVector(Vector3 vector)
		{
			return _rigidbody.transform.InverseTransformVector(vector);
		}

		public bool IsSleeping()
		{
			return _rigidbody.IsSleeping();
		}

		public void MoveRotation(Quaternion rot)
		{
			_rigidbody.MoveRotation(rot);
		}

		public void SetInertiaTensor(Vector3 v)
		{
			_rigidbody.SetInertiaTensor(v);
		}

		public void SetRootRigidBody(Rigidbody rigidBodyPhysx, Transform bodyTransform)
		{
			throw new NotSupportedException("This method is not supported on local rigid bodies.");
		}

		public void WakeUp()
		{
			_rigidbody.WakeUp();
		}
	}
}
