using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[DefaultExecutionOrder(50)]
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Set Joint Connection Body", 111)]
	public class RA2SetJointConnectedBody : MonoBehaviour
	{
		[Tooltip("Reading physical dummy bones out of the ragdoll animator")]
		[HideInInspector]
		public GameObject ObjectWithRagdollAnimator;

		[Tooltip("Transform with rigidbody to assign as 'ConnectedBody' of selected joint")]
		[HideInInspector]
		public Transform ToAttach;

		[Tooltip("Joint to change its 'ConnectedBody' reference")]
		public Joint TargetJoint;

		private IRagdollAnimator2HandlerOwner handler;

		private void FixedUpdate()
		{
			if (TargetJoint == null)
			{
				base.enabled = false;
				return;
			}
			if (ObjectWithRagdollAnimator == null && ToAttach == null)
			{
				base.enabled = false;
				return;
			}
			if (ObjectWithRagdollAnimator != null)
			{
				handler = ObjectWithRagdollAnimator.GetComponent<IRagdollAnimator2HandlerOwner>();
				if (handler == null)
				{
					handler = GetComponent<IRagdollAnimator2HandlerOwner>();
					ObjectWithRagdollAnimator = base.gameObject;
				}
			}
			if (handler == null)
			{
				if (ToAttach == null)
				{
					base.enabled = false;
					return;
				}
				if (ToAttach.GetComponent<Rigidbody>() == null)
				{
					base.enabled = false;
					return;
				}
			}
			else
			{
				ToAttach = handler.GetRagdollHandler.User_GetBoneSetupBySourceAnimatorBone(ToAttach).PhysicalDummyBone;
			}
			if (ToAttach == null)
			{
				base.enabled = false;
				return;
			}
			Rigidbody rigidbody = ToAttach.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = ToAttach.GetComponentInChildren<Rigidbody>();
			}
			if (rigidbody == null)
			{
				base.enabled = false;
				return;
			}
			TargetJoint.connectedBody = rigidbody;
			base.enabled = false;
		}
	}
}
