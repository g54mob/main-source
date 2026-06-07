using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[DefaultExecutionOrder(-2)]
	public class Demo_Ragd_Follow : FimpossibleComponent
	{
		public Transform ToFollow;

		public bool InitPositionIsRelative;

		private Vector3 localPos = Vector3.zero;

		private void Start()
		{
			if ((bool)ToFollow && InitPositionIsRelative)
			{
				localPos = ToFollow.InverseTransformPoint(base.transform.position);
			}
		}

		private void LateUpdate()
		{
			if (!(ToFollow == null))
			{
				base.transform.position = ToFollow.TransformPoint(localPos);
			}
		}
	}
}
