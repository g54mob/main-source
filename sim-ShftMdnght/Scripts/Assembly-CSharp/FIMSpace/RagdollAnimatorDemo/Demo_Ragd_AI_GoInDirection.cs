using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_AI_GoInDirection : FimpossibleComponent
	{
		public FBasic_RigidbodyMover Mover;

		public Animator Mecanim;

		public Vector3 worldDirection = Vector3.right;

		private void Update()
		{
			if (!Mecanim.GetBool("Action"))
			{
				Mover.MoveTowards(base.transform.position + worldDirection);
			}
		}
	}
}
