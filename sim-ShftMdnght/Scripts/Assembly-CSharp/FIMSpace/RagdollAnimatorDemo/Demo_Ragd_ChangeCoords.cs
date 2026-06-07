using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[DefaultExecutionOrder(-100)]
	public class Demo_Ragd_ChangeCoords : FimpossibleComponent
	{
		[DefaultExecutionOrder(100)]
		private class LateFixedUpdate : MonoBehaviour
		{
			public Demo_Ragd_ChangeCoords parent;

			private void FixedUpdate()
			{
				parent.CallLateFixedUpdate();
			}
		}

		public Transform ToMove;

		public Transform ToFollow;

		public Vector3 LocalPosition = Vector3.zero;

		public Vector3 LocalRotation = Vector3.zero;

		private Vector3 toFollowPos;

		private void Reset()
		{
			ToMove = base.transform;
		}

		private void Start()
		{
			base.gameObject.AddComponent<LateFixedUpdate>().parent = this;
			if ((bool)ToFollow)
			{
				toFollowPos = ToFollow.position;
			}
		}

		private void CallLateFixedUpdate()
		{
			toFollowPos = ToFollow.position;
		}

		private void LateUpdate()
		{
			ToMove.transform.position = toFollowPos + ToFollow.TransformVector(LocalPosition);
			ToMove.transform.rotation = ToFollow.rotation * Quaternion.Euler(LocalRotation);
		}
	}
}
