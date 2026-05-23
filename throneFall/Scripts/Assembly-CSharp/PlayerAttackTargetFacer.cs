using UnityEngine;

public class PlayerAttackTargetFacer : MonoBehaviour
{
	public Transform targetTransform;

	public ManualAttack attack;

	public float maxRotationDelta = 360f;

	public float lookBackTime = 0.4f;

	private Vector3 desiredForwardVector;

	private Quaternion desiredRotation = Quaternion.identity;

	private float lookClock;

	private bool shouldReset;

	public void AssignAttack(ManualAttack _attack)
	{
		attack = _attack;
		attack.onAttack.AddListener(UpdateTarget);
		if (attack.cooldownTime <= lookBackTime)
		{
			lookBackTime = attack.cooldownTime + 0.05f;
		}
	}

	private void UpdateTarget()
	{
		if (!(attack.LastTargetPos == Vector3.zero))
		{
			desiredForwardVector = attack.LastTargetPos - targetTransform.position;
			desiredForwardVector.y = 0f;
			desiredForwardVector.Normalize();
			desiredRotation = Quaternion.LookRotation(desiredForwardVector, Vector3.up);
			lookClock = lookBackTime;
		}
	}

	private void Update()
	{
		if (lookClock >= 0f)
		{
			lookClock -= Time.deltaTime;
			if (!targetTransform.rotation.Equals(desiredRotation))
			{
				targetTransform.rotation = Quaternion.RotateTowards(targetTransform.rotation, desiredRotation, maxRotationDelta * Time.deltaTime);
			}
			if (lookClock <= 0f)
			{
				shouldReset = true;
			}
		}
		else if (shouldReset)
		{
			targetTransform.rotation = Quaternion.RotateTowards(targetTransform.rotation, targetTransform.parent.rotation, maxRotationDelta * Time.deltaTime);
			if (targetTransform.rotation.Equals(targetTransform.parent.rotation))
			{
				shouldReset = false;
			}
		}
	}
}
