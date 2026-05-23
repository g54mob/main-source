using Pathfinding.RVO;
using UnityEngine;

public class RotateForwardToRVOVelocityRVO : MonoBehaviour
{
	public Transform transformToRotate;

	public RVOController target;

	public AutoAttack attack;

	public float regularSmoothTime = 0.1f;

	public float attackSmoothTime = 0.05f;

	public bool ignoreAttack;

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
		if ((bool)(Object)(object)target && target.velocity.sqrMagnitude > minSqVelocity && !attackOverride)
		{
			desiredForward = target.velocity;
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
		if (!ignoreAttack)
		{
			desiredForward = attack.LastTargetPosition - transformToRotate.position;
			desiredForward.y = 0f;
			desiredForward.Normalize();
			attackOverride = true;
		}
	}
}
