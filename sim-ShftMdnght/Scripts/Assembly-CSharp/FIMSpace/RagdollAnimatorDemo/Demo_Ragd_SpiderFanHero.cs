using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_SpiderFanHero : FimpossibleComponent
	{
		public FBasic_RigidbodyMover Mover;

		public Animator Mecanim;

		private Vector3 startPos;

		private Quaternion startRot;

		private void Start()
		{
			startPos = base.transform.position;
			startRot = base.transform.rotation;
		}

		private void Update()
		{
			if (!Mecanim.GetBool("Action"))
			{
				float num = Distance2D(base.transform.position, startPos);
				if (num < 0.3f && num > 0.01f)
				{
					Mover.SetTargetRotation(startRot * Vector3.forward);
				}
				else if (num > 0.3f)
				{
					Mover.MoveTowards(startPos);
				}
			}
		}

		private float Distance2D(Vector3 a, Vector3 b)
		{
			return Vector2.Distance(new Vector2(a.x, a.z), new Vector2(b.x, b.z));
		}
	}
}
