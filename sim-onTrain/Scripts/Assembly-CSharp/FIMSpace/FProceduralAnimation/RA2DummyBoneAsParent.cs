using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[DefaultExecutionOrder(50)]
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Ragdoll Bone as Parent", 111)]
	public class RA2DummyBoneAsParent : MonoBehaviour
	{
		[Tooltip("Reading physical dummy bones out of the ragdoll animator")]
		public GameObject ObjectWithRagdollAnimator;

		[Space(5f)]
		[Tooltip("Transform with rigidbody to assign as 'ConnectedBody' of selected joint")]
		[HideInInspector]
		public Transform TargetParent;

		[HideInInspector]
		public Vector3 LocalPosition = Vector3.zero;

		[HideInInspector]
		public Vector3 LocalRotation = Vector3.zero;

		private IRagdollAnimator2HandlerOwner handler;

		private void FixedUpdate()
		{
			if (ObjectWithRagdollAnimator == null && TargetParent == null)
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
				if (TargetParent == null)
				{
					base.enabled = false;
					return;
				}
				if (TargetParent.GetComponent<Rigidbody>() == null)
				{
					base.enabled = false;
					return;
				}
			}
			else
			{
				TargetParent = handler.GetRagdollHandler.User_GetBoneSetupBySourceAnimatorBone(TargetParent).PhysicalDummyBone;
			}
			if (TargetParent == null)
			{
				base.enabled = false;
				return;
			}
			Rigidbody rigidbody = TargetParent.GetComponent<Rigidbody>();
			if (rigidbody == null)
			{
				rigidbody = TargetParent.GetComponentInChildren<Rigidbody>();
			}
			if (rigidbody == null)
			{
				base.enabled = false;
				return;
			}
			base.transform.SetParent(rigidbody.transform, worldPositionStays: true);
			base.transform.localPosition = LocalPosition;
			base.transform.localRotation = Quaternion.Euler(LocalRotation);
			base.enabled = false;
		}
	}
}
