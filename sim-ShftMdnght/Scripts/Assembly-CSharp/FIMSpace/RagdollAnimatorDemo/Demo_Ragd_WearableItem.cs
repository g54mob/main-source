using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_WearableItem : FimpossibleComponent
	{
		public RagdollAnimator2 RagdollAnimator;

		[RagdollBoneSelector("RagdollAnimator")]
		public Transform TargetParent;

		[Space(5f)]
		public RA2AttachableObject AttachObject;

		public bool isHat;

		public void SwitchWearingItem()
		{
			if (RagdollAnimator.Handler.IsWearingAttachable(AttachObject))
			{
				DetachFromRagdoll();
			}
			else
			{
				WearOnRagdoll();
			}
		}

		public void WearOnRagdoll()
		{
			RagdollAnimator.Handler.WearAttachable(AttachObject, TargetParent);
			RagdollAnimator.Handler.Mecanim.CrossFadeInFixedTime(isHat ? "Wear Hat" : "Wear Sword", 0.35f);
		}

		public void DetachFromRagdoll()
		{
			RagdollAnimator.Handler.UnwearAttachable(AttachObject);
			AttachObject.transform.SetParent(null, worldPositionStays: true);
			AttachObject.transform.position += new Vector3(2f, 0f, 0f);
			RagdollAnimator.Handler.Mecanim.CrossFadeInFixedTime("Wait", 0.3f);
		}
	}
}
