using UnityEngine;

public class WaitForPositionReached : CustomYieldInstruction
{
	private Transform transform;

	private float totalDistance;

	private Vector3 startingPos;

	private Vector3 target;

	private float movementSpeed;

	private float distanceMoved;

	public override bool keepWaiting
	{
		get
		{
			float num = Time.deltaTime * movementSpeed;
			distanceMoved += num;
			transform.position = Vector3.MoveTowards(transform.position, target, num);
			return distanceMoved < totalDistance;
		}
	}

	public WaitForPositionReached(Transform trans, Vector3 endPosition, float speed)
	{
		transform = trans;
		startingPos = transform.position;
		totalDistance = (endPosition - startingPos).magnitude;
		target = endPosition;
		movementSpeed = speed;
	}
}
