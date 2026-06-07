using UnityEngine;

namespace MalbersAnimations
{
	public class RigidConstraintsB : StateMachineBehaviour
	{
		public bool PosX;

		public bool PosY;

		public bool PosZ;

		public bool RotX = true;

		public bool RotY = true;

		public bool RotZ = true;

		public bool OnEnter = true;

		public bool OnExit;

		protected int Amount;

		private Rigidbody rb;

		private bool ExitTime;

		public float OnEnterDrag;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Amount = 0;
			rb = animator.GetComponent<Rigidbody>();
			if (PosX)
			{
				Amount += 2;
			}
			if (PosY)
			{
				Amount += 4;
			}
			if (PosZ)
			{
				Amount += 8;
			}
			if (RotX)
			{
				Amount += 16;
			}
			if (RotY)
			{
				Amount += 32;
			}
			if (RotZ)
			{
				Amount += 64;
			}
			if (OnEnter && (bool)rb)
			{
				rb.constraints = (RigidbodyConstraints)Amount;
			}
			ExitTime = false;
			rb.drag = OnEnterDrag;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!ExitTime && OnExit && stateInfo.normalizedTime > 1f)
			{
				rb.constraints = (RigidbodyConstraints)Amount;
				ExitTime = true;
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (OnExit)
			{
				rb.constraints = (RigidbodyConstraints)Amount;
			}
		}
	}
}
