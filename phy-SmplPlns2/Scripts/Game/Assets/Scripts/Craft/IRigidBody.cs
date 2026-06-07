using UnityEngine;

namespace Assets.Scripts.Craft
{
	public interface IRigidBody
	{
		bool activeInHierarchy { get; }

		bool activeSelf { get; }

		float angularDrag { get; set; }

		Vector3 angularVelocity { get; set; }

		bool automaticCenterOfMass { get; set; }

		bool automaticInertiaTensor { get; set; }

		Vector3 centerOfMass { get; set; }

		CollisionDetectionMode collisionDetectionMode { get; set; }

		float drag { get; set; }

		Vector3 inertiaTensor { get; }

		bool IsDead { get; }

		bool isKinematic { get; set; }

		float mass { get; set; }

		float maxAngularVelocity { get; set; }

		float maxDepenetrationVelocity { get; set; }

		Rigidbody PhysxRigidBody { get; }

		Vector3 position { get; set; }

		Quaternion rotation { get; set; }

		int solverIterations { get; set; }

		RigidBodyType Type { get; }

		bool useGravity { get; set; }

		Vector3 velocity { get; set; }

		Vector3 worldCenterOfMass { get; }

		void AddForce(Vector3 force);

		void AddForceAtPosition(Vector3 force, Vector3 position);

		void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode forceMode);

		void AddRelativeTorque(float x, float y, float z);

		void AddTorque(Vector3 torque);

		Vector3 ClosestPointOnBounds(Vector3 position);

		Vector3 GetPointVelocity(Vector3 worldPoint);

		Vector3 InverseTransformVector(Vector3 vector);

		bool IsSleeping();

		void MoveRotation(Quaternion rot);

		void SetInertiaTensor(Vector3 v);

		void SetRootRigidBody(Rigidbody rigidBodyPhysx, Transform bodyTransform);

		void WakeUp();
	}
}
