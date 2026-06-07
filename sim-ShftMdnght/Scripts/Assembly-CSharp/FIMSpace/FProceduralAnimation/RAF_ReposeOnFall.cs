using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_ReposeOnFall : RagdollAnimatorFeatureUpdate
	{
		public enum EBaseTransformRepose
		{
			AnchorToFootPosition = 0,
			AnchorBoneBottom = 1,
			BonesBoundsBottomCenter = 2,
			SkeletonCenter = 3
		}

		private FUniversalVariable reposeVar;

		private FUniversalVariable rotationVar;

		private float reposeStartAt = -100f;

		public override bool UseLateUpdate => true;

		public static Vector3 GetReposePosition(IRagdollAnimator2HandlerOwner iHandler, EBaseTransformRepose reposeMode)
		{
			return reposeMode switch
			{
				EBaseTransformRepose.AnchorToFootPosition => iHandler.GetRagdollHandler.User_GetPosition_HipsToFoot(), 
				EBaseTransformRepose.AnchorBoneBottom => iHandler.GetRagdollHandler.User_GetPosition_AnchorBottom(), 
				EBaseTransformRepose.BonesBoundsBottomCenter => iHandler.GetRagdollHandler.User_GetPosition_BottomCenter(), 
				_ => iHandler.GetRagdollHandler.User_GetPosition_Center(), 
			};
		}

		public override bool OnInit()
		{
			reposeVar = base.InitializedWith.RequestVariable("Mode", 1);
			rotationVar = base.InitializedWith.RequestVariable("Apply Rotation:", false);
			return base.OnInit();
		}

		public override void LateUpdate()
		{
			if (!base.InitializedWith.Enabled)
			{
				return;
			}
			if (base.ParentRagdollHandler.IsFallingOrSleep)
			{
				if (reposeStartAt < 0f)
				{
					reposeStartAt = Time.time;
				}
				else if (!(Time.time - reposeStartAt < 0.1f))
				{
					EBaseTransformRepose reposeMode = (EBaseTransformRepose)reposeVar.GetInt();
					base.ParentRagdollHandler.BaseTransform.position = GetReposePosition(base.ParentRagdollHandler, reposeMode);
					if (rotationVar.GetBool())
					{
						base.ParentRagdollHandler.BaseTransform.rotation = base.ParentRagdollHandler.User_GetMappedRotationHipsToLegsMiddle(Vector3.up);
					}
				}
			}
			else
			{
				reposeStartAt = -100f;
			}
		}
	}
}
