using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("", 0)]
	public class RagdollAnimator2BoneIndicator : MonoBehaviour
	{
		public RagdollHandler ParentHandler { get; private set; }

		public RagdollHandler ParentRagdollProcessor => ParentHandler;

		public RagdollAnimator2 ParentRagdollAnimator => ParentHandler.Caller as RagdollAnimator2;

		public RagdollBoneProcessor RagdollBoneProcessor { get; private set; }

		public Rigidbody DummyBoneRigidbody => RagdollBoneProcessor.rigidbody;

		public Transform PhysicalBone => RagdollBoneProcessor.BoneSetup.PhysicalDummyBone;

		public Transform SourceBone => RagdollBoneProcessor.BoneSetup.SourceBone;

		public RagdollChainBone BoneSettings { get; private set; }

		public RA2AttachableObject AttachableObject { get; private set; }

		public ERagdollBoneID BodyBoneID { get; private set; } = ERagdollBoneID.Unknown;

		public RagdollBonesChain ParentChain { get; private set; }

		public ERagdollChainType ChainType => ParentChain.ChainType;

		public bool IsAnimatorBone { get; private set; }

		public bool IsAnimatorBoneReference { get; private set; }

		internal void MarkAsAnimatorBone()
		{
			IsAnimatorBoneReference = true;
		}

		public virtual RagdollAnimator2BoneIndicator Initialize(RagdollHandler handler, RagdollBoneProcessor boneProcessor, RagdollBonesChain parentChain, bool isAnimatorBone = false, RA2AttachableObject attachable = null)
		{
			ParentHandler = handler;
			BodyBoneID = ERagdollBoneID.Unknown;
			RagdollBoneProcessor = boneProcessor;
			if (boneProcessor != null)
			{
				BoneSettings = boneProcessor.BoneSetup;
			}
			IsAnimatorBone = isAnimatorBone;
			AttachableObject = attachable;
			ParentChain = parentChain;
			if (boneProcessor != null)
			{
				BodyBoneID = boneProcessor.BoneSetup.BoneID;
				boneProcessor.IndicatorComponent = this;
			}
			return this;
		}
	}
}
