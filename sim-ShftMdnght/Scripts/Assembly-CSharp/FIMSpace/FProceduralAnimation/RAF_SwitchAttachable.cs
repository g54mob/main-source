using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_SwitchAttachable : RagdollAnimatorFeatureBase
	{
		private FUniversalVariable attachableV;

		private FUniversalVariable parentV;

		private RA2AttachableObject attached;

		public override bool OnInit()
		{
			if (!base.OnInit())
			{
				return false;
			}
			attachableV = base.InitializedWith.RequestVariable("Attachable", null);
			parentV = base.InitializedWith.RequestVariable("Target Parent", null);
			RefreshAttachableState(logIfNullParent: false);
			return true;
		}

		public void RefreshAttachableState(bool logIfNullParent = true)
		{
			if (attachableV.GetUnityObject() == attached)
			{
				return;
			}
			if (parentV.GetUnityObject() as Transform == null)
			{
				if (logIfNullParent)
				{
					Debug.Log("[Ragdoll Animator 2] Trying to attach object into null reference bone! :" + (base.ParentRagdollHandler.Caller ? base.ParentRagdollHandler.Caller.name : "") + ":");
				}
				return;
			}
			RA2AttachableObject rA2AttachableObject = attachableV.GetUnityObject() as RA2AttachableObject;
			if (rA2AttachableObject == null)
			{
				base.ParentRagdollHandler.UnwearAttachable(attached);
				attached = null;
			}
			else
			{
				base.ParentRagdollHandler.UnwearAttachable(attached);
				base.ParentRagdollHandler.WearAttachable(rA2AttachableObject, parentV.GetUnityObject() as Transform);
				attached = rA2AttachableObject;
			}
		}
	}
}
