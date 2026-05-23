using UnityEngine;

public class RotateForwardToRVOVelocity : MonoBehaviour
{
	public Transform transformToRotate;

	public PathfindMovement target;

	public AutoAttack attack;

	public float regularSmoothTime = 0.1f;

	public float attackSmoothTime = 0.05f;

	private Vector3 desiredForward;

	private Vector3 angularVelocityRef;

	private float minSqVelocity = 1.5f;

	private bool attackOverride;

	private void Start()
	{
		if ((bool)attack)
		{
			attack.onAttackTriggered.AddListener(OnAttack);
		}
		desiredForward = transformToRotate.forward;
	}

	private void Update()
	{
		if ((bool)target && target.RVO.velocity.sqrMagnitude > minSqVelocity && !attackOverride)
		{
			desiredForward = target.RVO.velocity;
			desiredForward.y = 0f;
			desiredForward.Normalize();
		}
		if (Vector3.Angle(transformToRotate.forward, desiredForward) > 3f)
		{
			if (attackOverride)
			{
				transformToRotate.forward = Vector3.SmoothDamp(transformToRotate.forward, desiredForward, ref angularVelocityRef, attackSmoothTime);
			}
			else
			{
				transformToRotate.forward = Vector3.SmoothDamp(transformToRotate.forward, desiredForward, ref angularVelocityRef, regularSmoothTime);
			}
		}
		else
		{
			attackOverride = false;
		}
	}

	private void OnAttack()
	{
		desiredForward = attack.LastTargetPosition - transformToRotate.position;
		desiredForward.y = 0f;
		desiredForward.Normalize();
		attackOverride = true;
	}
}
