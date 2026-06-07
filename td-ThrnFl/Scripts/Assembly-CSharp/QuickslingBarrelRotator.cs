using UnityEngine;

public class QuickslingBarrelRotator : MonoBehaviour
{
	public Transform transformToRotate;

	public AutoAttack attack;

	public float attackSmoothTime = 0.05f;

	private Vector3 desiredForward;

	private Vector3 angularVelocityRef;

	private float minSqVelocity = 1.5f;

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
		if (Vector3.Angle(transformToRotate.forward, desiredForward) > 3f)
		{
			transformToRotate.forward = Vector3.SmoothDamp(transformToRotate.forward, desiredForward, ref angularVelocityRef, attackSmoothTime);
		}
	}

	private void OnAttack()
	{
		desiredForward = attack.LastTargetPosition - transformToRotate.position;
		desiredForward.y = 0f;
		desiredForward.Normalize();
	}
}
