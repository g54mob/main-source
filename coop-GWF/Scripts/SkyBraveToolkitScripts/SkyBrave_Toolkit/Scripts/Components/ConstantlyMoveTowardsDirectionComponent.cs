using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class ConstantlyMoveTowardsDirectionComponent : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		public float moveSpeed;

		[SerializeField]
		private bool canMove = true;

		[SerializeField]
		private bool ignoreMoveDirectionAndUseTransformForward;

		[SerializeField]
		private Vector3 moveDirection = Vector3.forward;

		private void Start()
		{
			if (ignoreMoveDirectionAndUseTransformForward)
			{
				moveDirection = base.transform.forward;
			}
		}

		public void Update()
		{
			if (canMove)
			{
				MoveTowardsDirection();
			}
		}

		public void MoveTowardsDirection()
		{
			canMove = true;
			base.transform.position += moveSpeed * Time.deltaTime * moveDirection.normalized;
			DebugVisualizer();
		}

		public void StopMovement()
		{
			canMove = false;
		}

		private void DebugVisualizer()
		{
			Debug.DrawRay(base.transform.position, moveDirection * moveSpeed, Color.blue);
		}
	}
}
