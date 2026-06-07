using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_FallSwitchOnKey : MonoBehaviour
	{
		public RagdollAnimator2 TargetRagdoll;

		public KeyCode key = KeyCode.Q;

		public KeyCode resetKey = KeyCode.R;

		private Vector3 initPos;

		private Quaternion initRot;

		private void Start()
		{
			initPos = base.transform.position;
			initRot = base.transform.rotation;
		}

		private void Update()
		{
			if (Input.GetKeyDown(key))
			{
				TargetRagdoll.User_SwitchFallState(!TargetRagdoll.Handler.IsInStandingMode);
			}
			if (Input.GetKeyDown(resetKey))
			{
				TargetRagdoll.User_SwitchFallState(standing: true);
				TargetRagdoll.User_Teleport(initPos, initRot);
			}
		}
	}
}
