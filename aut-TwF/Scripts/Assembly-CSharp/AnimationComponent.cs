using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
	[SerializeField]
	private bool checkIsMoving = true;

	[SerializeField]
	private bool updateMovementDirection;

	protected Animator animator;

	protected MovementComponent movementComp;

	protected virtual void Awake()
	{
		animator = GetComponent<Animator>();
		movementComp = GetComponent<MovementComponent>();
	}

	protected virtual void Update()
	{
		if (checkIsMoving)
		{
			CheckIsMoving();
		}
		if (updateMovementDirection)
		{
			UpdateMovementDirection();
		}
	}

	protected virtual void CheckIsMoving()
	{
		if ((bool)movementComp)
		{
			animator?.SetBool("IsMoving", movementComp.IsMoving());
		}
	}

	private void UpdateMovementDirection()
	{
		Vector3 vector = Vector3.zero;
		if ((bool)movementComp)
		{
			vector = base.transform.InverseTransformDirection(movementComp.GetVelocity().normalized).normalized;
		}
		animator?.SetFloat("Forward", vector.z);
		animator?.SetFloat("Right", vector.x);
	}
}
