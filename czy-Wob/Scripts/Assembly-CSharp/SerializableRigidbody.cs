using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class SerializableRigidbody
{
	public SerializableVector3 position;

	public SerializableQuaternion rotation;

	public SerializableVector3 velocity;

	public SerializableVector3 angularVelocity;

	public SerializableRigidbody()
	{
	}

	public SerializableRigidbody(Rigidbody rb)
	{
		Save(rb);
	}

	public void Save(Rigidbody rb)
	{
		position = new SerializableVector3(rb.position);
		rotation = new SerializableQuaternion(rb.rotation);
		velocity = new SerializableVector3(rb.velocity);
		angularVelocity = new SerializableVector3(rb.angularVelocity);
	}

	public void Load(Rigidbody rb)
	{
		bool isKinematic = rb.isKinematic;
		CollisionDetectionMode collisionDetectionMode = rb.collisionDetectionMode;
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		rb.isKinematic = true;
		rb.MovePosition(position.Load());
		rb.MoveRotation(rotation.Load());
		if (!isKinematic)
		{
			ObjectRegistration.GetRegistrationScript().StartCoroutine(KinematicUpdate(rb, collisionDetectionMode));
			return;
		}
		rb.velocity = velocity.Load();
		rb.angularVelocity = angularVelocity.Load();
	}

	public SerializableRigidbody GetCopy()
	{
		return new SerializableRigidbody
		{
			position = position.GetCopy(),
			rotation = rotation.GetCopy(),
			velocity = velocity.GetCopy(),
			angularVelocity = angularVelocity.GetCopy()
		};
	}

	private IEnumerator KinematicUpdate(Rigidbody rb, CollisionDetectionMode collisionMode)
	{
		yield return new WaitForEndOfFrame();
		if (!(rb == null))
		{
			rb.isKinematic = false;
			rb.collisionDetectionMode = collisionMode;
			rb.velocity = velocity.Load();
			rb.angularVelocity = angularVelocity.Load();
		}
	}
}
