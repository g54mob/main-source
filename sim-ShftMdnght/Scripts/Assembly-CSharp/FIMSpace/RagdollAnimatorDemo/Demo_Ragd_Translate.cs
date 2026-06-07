using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_Translate : FimpossibleComponent
	{
		public Rigidbody ToMove;

		public Vector3 LocalVelocity = Vector3.forward;

		private void Update()
		{
			if (ToMove == null)
			{
				base.transform.Translate(LocalVelocity * Time.deltaTime, Space.Self);
			}
		}

		private void FixedUpdate()
		{
			if ((bool)ToMove)
			{
				ToMove.velocity = base.transform.TransformVector(LocalVelocity);
			}
		}
	}
}
