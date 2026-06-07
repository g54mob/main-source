using UnityEngine;

namespace MalbersAnimations
{
	public class IsKinematicB : StateMachineBehaviour
	{
		public enum OnEnterOnExit
		{
			OnEnter = 0,
			OnExit = 1,
			OnEnterOnExit = 2,
			OnTime = 3
		}

		public OnEnterOnExit SetKinematic = OnEnterOnExit.OnEnterOnExit;

		[Tooltip("Changes the Kinematic property of the RigidBody On Enter/OnExit")]
		public bool isKinematic = true;

		[Tooltip("Time to change the the RB to kinematic or not")]
		[Range(0f, 1f)]
		public float Time = 0.5f;

		private CollisionDetectionMode current;

		private bool sent;

		private Rigidbody rb;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (rb == null)
			{
				rb = animator.GetComponent<Rigidbody>();
			}
			sent = false;
			if (SetKinematic == OnEnterOnExit.OnEnter)
			{
				Set_RB_Kinematic(isKinematic);
			}
			else if (SetKinematic == OnEnterOnExit.OnEnterOnExit)
			{
				Set_RB_Kinematic(value: true);
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!sent && SetKinematic == OnEnterOnExit.OnTime && stateInfo.normalizedTime >= Time)
			{
				Set_RB_Kinematic(isKinematic);
				sent = true;
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			switch (SetKinematic)
			{
			case OnEnterOnExit.OnExit:
				Set_RB_Kinematic(isKinematic);
				break;
			case OnEnterOnExit.OnEnterOnExit:
				Set_RB_Kinematic(value: false);
				break;
			case OnEnterOnExit.OnTime:
				if (!sent)
				{
					Set_RB_Kinematic(isKinematic);
				}
				break;
			}
		}

		private void Set_RB_Kinematic(bool value)
		{
			if (value)
			{
				current = rb.collisionDetectionMode;
				rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				rb.isKinematic = true;
			}
			else
			{
				rb.isKinematic = false;
				rb.collisionDetectionMode = current;
			}
		}
	}
}
