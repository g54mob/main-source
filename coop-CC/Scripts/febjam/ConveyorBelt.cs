using Aggro.Core;
using UnityEngine;

public class ConveyorBelt : EntityBehaviourBase
{
	public enum ConveyorBeltMovement
	{
		Forwards = 0,
		Rotational = 1
	}

	public ConveyorBeltMovement movement;

	public float forwardsSpeed = 2f;

	public float rotationClockwiseSpeedDegrees = 45f;

	public bool drawGizmos;

	public bool disableInBreakRoom;

	protected override void OnUpdateSimulation()
	{
		if (!disableInBreakRoom || GameUtil.GetCurrentRoomType() != RoomType.BreakRoom)
		{
			Rigidbody rigidbody = base.entity.GetObject<Rigidbody>();
			Transform transform = base.entity.GetObject<Transform>();
			switch (movement)
			{
			case ConveyorBeltMovement.Forwards:
			{
				Vector3 forward = transform.forward;
				float num = forwardsSpeed * (1f / 60f);
				Vector3 position = rigidbody.position;
				position -= forward * num;
				rigidbody.position = position;
				rigidbody.MovePosition(position + forward * num);
				break;
			}
			case ConveyorBeltMovement.Rotational:
			{
				Quaternion rotation = rigidbody.rotation;
				Quaternion quaternion = Quaternion.AngleAxis(rotationClockwiseSpeedDegrees * (1f / 60f), transform.up);
				rotation *= Quaternion.Inverse(quaternion);
				rigidbody.rotation = rotation;
				rigidbody.MoveRotation(rotation * quaternion);
				break;
			}
			default:
				throw new InvalidEnumException();
			}
		}
	}

	public void OnDrawGizmos()
	{
		if (drawGizmos)
		{
			Vector3 vector = base.transform.position + Vector3.up * 0.5f;
			Vector3 vector2 = Vector3.Normalize(base.transform.forward * forwardsSpeed);
			if (movement == ConveyorBeltMovement.Rotational)
			{
				vector2 = Vector3.Normalize((base.transform.forward + base.transform.right) * rotationClockwiseSpeedDegrees);
			}
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(vector, vector + vector2);
		}
	}
}
