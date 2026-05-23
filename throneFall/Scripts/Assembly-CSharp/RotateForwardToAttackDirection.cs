using UnityEngine;

public class RotateForwardToAttackDirection : MonoBehaviour
{
	public Transform transformToRotate;

	public AutoAttack attack;

	public float attackSmoothTime = 0.05f;

	public float regularSmoothTime = 0.25f;

	private Vector3 desiredForward;

	private Vector3 angularVelocityRef;

	private float minSqVelocity = 1.5f;

	private bool attackOverride;

	private Vector3 originalForward;

	private void Start()
	{
		originalForward = transformToRotate.forward;
		attack.onAttackTriggered.AddListener(OnAttack);
		desiredForward = originalForward;
	}

	private void Update()
	{
		if (Vector3.Angle(transformToRotate.forward, desiredForward) > 3f)
		{
			if (attackOverride)
			{
				transformToRotate.forward = Vector3.SmoothDamp(transformToRotate.forward, desiredForward, ref angularVelocityRef, attackSmoothTime);
			}
			else
			{
				transformToRotate.forward = Vector3.SmoothDamp(transformToRotate.forward, originalForward, ref angularVelocityRef, regularSmoothTime);
			}
		}
		else
		{
			attackOverride = false;
			desiredForward = originalForward;
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
