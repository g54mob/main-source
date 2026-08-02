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
			SkeletonCenter = 3,
			FeetMiddle = 4
		}

		public enum EOrientationMode
		{
			HipsToFeetMiddle = 0,
			HeadToHips = 1,
			HipsToHead = 2,
			MappedHips = 3
		}

		private FUniversalVariable reposeVar;

		private FUniversalVariable rotationVar;

		private FUniversalVariable orientationVar;

		private float reposeStartAt = -100f;

		private bool wasFixed;

		public override bool UseFixedUpdate => true;

		public override bool UseLateUpdate => true;

		public static Vector3 GetReposePosition(IRagdollAnimator2HandlerOwner iHandler, EBaseTransformRepose reposeMode)
		{
			return reposeMode switch
			{
				EBaseTransformRepose.AnchorToFootPosition => iHandler.GetRagdollHandler.User_GetPosition_HipsToFoot(), 
				EBaseTransformRepose.AnchorBoneBottom => iHandler.GetRagdollHandler.User_GetPosition_AnchorBottom(), 
				EBaseTransformRepose.BonesBoundsBottomCenter => iHandler.GetRagdollHandler.User_GetPosition_BottomCenter(), 
				EBaseTransformRepose.SkeletonCenter => iHandler.GetRagdollHandler.User_GetPosition_Center(), 
				_ => iHandler.GetRagdollHandler.User_GetPosition_FeetMiddle(), 
			};
		}

		public override bool OnInit()
		{
			reposeVar = base.InitializedWith.RequestVariable("Mode", 1);
			rotationVar = base.InitializedWith.RequestVariable("Apply Rotation:", false);
			orientationVar = base.InitializedWith.RequestVariable("Orientation Mode", 0);
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
				else
				{
					if (Time.time - reposeStartAt < 0.1f || !wasFixed)
					{
						return;
					}
					EBaseTransformRepose reposeMode = (EBaseTransformRepose)reposeVar.GetInt();
					base.ParentRagdollHandler.BaseTransform.position = GetReposePosition(base.ParentRagdollHandler, reposeMode);
					if (rotationVar.GetBool())
					{
						EOrientationMode eOrientationMode = (EOrientationMode)orientationVar.GetInt();
						Quaternion rotation = base.ParentRagdollHandler.BaseTransform.rotation;
						switch (eOrientationMode)
						{
						case EOrientationMode.HipsToFeetMiddle:
							rotation = base.ParentRagdollHandler.User_GetMappedRotationHipsToLegsMiddle(Vector3.up);
							break;
						case EOrientationMode.HipsToHead:
							rotation = base.ParentRagdollHandler.User_GetMappedRotationHipsToHead(Vector3.up);
							break;
						case EOrientationMode.HeadToHips:
							rotation = base.ParentRagdollHandler.User_GetMappedRotationHeadToHips(Vector3.up);
							break;
						case EOrientationMode.MappedHips:
							rotation = base.ParentRagdollHandler.User_GetRotation_Mapped(Vector3.up);
							break;
						}
						base.ParentRagdollHandler.BaseTransform.rotation = rotation;
					}
				}
			}
			else
			{
				wasFixed = false;
				reposeStartAt = -100f;
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (base.ParentRagdollHandler.IsFallingOrSleep && !(reposeStartAt <= 0f))
			{
				wasFixed = true;
			}
		}
	}
}
