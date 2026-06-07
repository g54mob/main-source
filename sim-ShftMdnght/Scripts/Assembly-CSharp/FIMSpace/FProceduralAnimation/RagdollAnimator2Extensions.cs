using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public static class RagdollAnimator2Extensions
	{
		private static RagdollBonesChain _copyingFrom;

		private static RagdollChainBone _copyingFromBone;

		public static RagdollBonesChain CopyingFrom => _copyingFrom;

		public static RagdollChainBone CopyingFromBone => _copyingFromBone;

		public static bool IsArm(this ERagdollChainType chain)
		{
			if (chain != ERagdollChainType.LeftArm)
			{
				return chain == ERagdollChainType.RightArm;
			}
			return true;
		}

		public static bool IsRight(this ERagdollChainType chain)
		{
			if (chain != ERagdollChainType.RightLeg)
			{
				return chain == ERagdollChainType.RightArm;
			}
			return true;
		}

		public static bool IsLeft(this ERagdollChainType chain)
		{
			if (chain != ERagdollChainType.RightLeg)
			{
				return chain == ERagdollChainType.RightArm;
			}
			return true;
		}

		public static bool IsLeg(this ERagdollChainType chain)
		{
			if (chain != ERagdollChainType.LeftLeg)
			{
				return chain == ERagdollChainType.RightLeg;
			}
			return true;
		}

		public static bool IsSameMainType(this ERagdollChainType chain, ERagdollChainType oChain)
		{
			if (chain.IsLeg() && oChain.IsLeg())
			{
				return true;
			}
			if (chain.IsArm() && oChain.IsArm())
			{
				return true;
			}
			return chain == oChain;
		}

		public static Vector3 SetAxisValue(this EJointAxis axis, Vector3 target, float value, bool inverse)
		{
			switch (axis)
			{
			case EJointAxis.X:
				target.x += (inverse ? (0f - value) : value);
				break;
			case EJointAxis.Y:
				target.y += (inverse ? (0f - value) : value);
				break;
			case EJointAxis.Z:
				target.z += (inverse ? (0f - value) : value);
				break;
			}
			return target;
		}

		public static Vector3 SetAxisValue(this EJointAxis axis, Vector3 target, float value, Vector3 customValue, bool inverse)
		{
			switch (axis)
			{
			case EJointAxis.X:
				target.x += (inverse ? (0f - value) : value);
				break;
			case EJointAxis.Y:
				target.y += (inverse ? (0f - value) : value);
				break;
			case EJointAxis.Z:
				target.z += (inverse ? (0f - value) : value);
				break;
			case EJointAxis.Custom:
				target += customValue.normalized * value;
				break;
			}
			return target;
		}

		public static Color GetIndexColor(this RagdollHandler handler, int index, float hueOffset = 0f, float alpha = 1f, float sat = 0.85f, float val = 0.85f, float stepMultiplier = 0.3f)
		{
			Color result = Color.HSVToRGB(((float)index * stepMultiplier / ((float)handler.Chains.Count - 1f) + hueOffset) % 1f, sat, val);
			result.a = alpha;
			return result;
		}

		public static void PasteMainSettingsOfOtherChain(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.Detach = copyFrom.Detach;
			}
		}

		public static void PasteColliderSettingsOfOtherChain(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom, bool allowDisplayDialog = true)
		{
			if (pasteTo == null || copyFrom == null)
			{
				return;
			}
			if (pasteTo.BoneSetups.Count != copyFrom.BoneSetups.Count)
			{
				Log("Bones count of " + pasteTo.ChainName + " is different than " + copyFrom.ChainName + " bones count!", allowDisplayDialog);
			}
			else
			{
				pasteTo.ChainScaleMultiplier = copyFrom.ChainScaleMultiplier;
				for (int i = 0; i < pasteTo.BoneSetups.Count; i++)
				{
					RagdollChainBone copyFrom2 = copyFrom.BoneSetups[i];
					pasteTo.BoneSetups[i].PasteColliderSettingsOfOtherBone(copyFrom2);
				}
			}
		}

		public static void SetCopyingSource(RagdollBonesChain copyFrom)
		{
			_copyingFrom = copyFrom;
		}

		public static void SetCopyingSource(RagdollChainBone copyFrom)
		{
			_copyingFromBone = copyFrom;
		}

		public static void PasteColliderSettingsOfOtherChainSymmetrical(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom, RagdollHandler handler, bool allowDisplayDialog = true)
		{
			if (pasteTo == null || copyFrom == null)
			{
				return;
			}
			if (pasteTo.BoneSetups.Count != copyFrom.BoneSetups.Count)
			{
				Log("Bones count of " + pasteTo.ChainName + " is different than " + copyFrom.ChainName + " bones count!", allowDisplayDialog);
				return;
			}
			pasteTo.ChainScaleMultiplier = copyFrom.ChainScaleMultiplier;
			for (int i = 0; i < pasteTo.BoneSetups.Count; i++)
			{
				RagdollChainBone copyFrom2 = copyFrom.BoneSetups[i];
				pasteTo.BoneSetups[i].PasteColliderSettingsOfOtherBoneSymmetrical(copyFrom2, handler);
			}
			if (handler.WasInitialized)
			{
				handler.User_UpdateAllBonesParametersAfterManualChanges();
			}
		}

		public static void PasteExtraSettingsOfOtherChain(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				for (int i = 0; i < pasteTo.BoneSetups.Count; i++)
				{
					RagdollChainBone copyFrom2 = copyFrom.BoneSetups[i];
					pasteTo.BoneSetups[i].PasteExtraSettingsOfOtherBone(copyFrom2);
				}
			}
		}

		public static void PastePhysicsSettingsOfOtherChain(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.MassMultiplier = copyFrom.MassMultiplier;
				pasteTo.MusclesForce = copyFrom.MusclesForce;
				pasteTo.AxisLimitRange = copyFrom.AxisLimitRange;
				pasteTo.UnlimitedRotations = copyFrom.UnlimitedRotations;
				pasteTo.ConnectedMassOverride = copyFrom.ConnectedMassOverride;
				pasteTo.ConnectedMassScale = copyFrom.ConnectedMassScale;
				pasteTo.AlternativeTensors = copyFrom.AlternativeTensors;
				pasteTo.AlternativeTensorsOnFall = copyFrom.AlternativeTensorsOnFall;
				pasteTo.HardMatchMultiply = copyFrom.HardMatchMultiply;
				for (int i = 0; i < pasteTo.BoneSetups.Count; i++)
				{
					RagdollChainBone copyFrom2 = copyFrom.BoneSetups[i];
					pasteTo.BoneSetups[i].PastePhysicsSettingsOfOtherBone(copyFrom2);
				}
			}
		}

		public static void PastePhysics_Mass_OfOtherChain(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.MassMultiplier = copyFrom.MassMultiplier;
				for (int i = 0; i < pasteTo.BoneSetups.Count && i < copyFrom.BoneSetups.Count; i++)
				{
					RagdollChainBone ragdollChainBone = copyFrom.BoneSetups[i];
					pasteTo.BoneSetups[i].MassMultiplier = ragdollChainBone.MassMultiplier;
				}
			}
		}

		public static void PastePhysicsSettingsOfOtherChainSymmetrical(this RagdollBonesChain pasteTo, RagdollBonesChain copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.MassMultiplier = copyFrom.MassMultiplier;
				pasteTo.MusclesForce = copyFrom.MusclesForce;
				pasteTo.AxisLimitRange = 0f - copyFrom.AxisLimitRange;
				pasteTo.UnlimitedRotations = copyFrom.UnlimitedRotations;
				pasteTo.HardMatchMultiply = copyFrom.HardMatchMultiply;
				for (int i = 0; i < pasteTo.BoneSetups.Count; i++)
				{
					RagdollChainBone copyFrom2 = copyFrom.BoneSetups[i];
					pasteTo.BoneSetups[i].PastePhysicsSettingsOfOtherBoneSymmetrical(copyFrom2);
				}
			}
		}

		public static void ApplyColliderSettingsToAllBonesInChain(this RagdollChainBone settingsOf, RagdollBonesChain applyToChain)
		{
			if (settingsOf == null || applyToChain == null)
			{
				return;
			}
			for (int i = 0; i < applyToChain.BoneSetups.Count; i++)
			{
				RagdollChainBone ragdollChainBone = applyToChain.BoneSetups[i];
				if (ragdollChainBone != settingsOf)
				{
					ragdollChainBone.PasteColliderSettingsOfOtherBone(settingsOf);
				}
			}
		}

		public static void PasteColliderSettingsOfOtherBone(this RagdollChainBone pasteTo, RagdollChainBone copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				if (pasteTo.Colliders.Count != copyFrom.Colliders.Count)
				{
					pasteTo.Colliders.Clear();
				}
				while (pasteTo.Colliders.Count < copyFrom.Colliders.Count)
				{
					pasteTo.AddColliderSetup();
				}
				for (int i = 0; i < copyFrom.Colliders.Count; i++)
				{
					pasteTo.Colliders[i].ColliderType = copyFrom.Colliders[i].ColliderType;
					pasteTo.Colliders[i].ColliderCenter = copyFrom.Colliders[i].ColliderCenter;
					pasteTo.Colliders[i].ColliderSizeMultiply = copyFrom.Colliders[i].ColliderSizeMultiply;
					pasteTo.Colliders[i].CapsuleDirection = copyFrom.Colliders[i].CapsuleDirection;
					pasteTo.Colliders[i].ColliderRadius = copyFrom.Colliders[i].ColliderRadius;
					pasteTo.Colliders[i].ColliderLength = copyFrom.Colliders[i].ColliderLength;
					pasteTo.Colliders[i].ColliderBoxSize = copyFrom.Colliders[i].ColliderBoxSize;
					pasteTo.Colliders[i].ColliderMesh = copyFrom.Colliders[i].ColliderMesh;
					pasteTo.Colliders[i].RotationCorrection = copyFrom.Colliders[i].RotationCorrection;
				}
			}
		}

		public static void PasteColliderSizeSettingsOfOtherBone(this RagdollChainBone pasteTo, RagdollChainBone copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				if (pasteTo.Colliders.Count != copyFrom.Colliders.Count)
				{
					pasteTo.Colliders.Clear();
				}
				while (pasteTo.Colliders.Count < copyFrom.Colliders.Count)
				{
					pasteTo.AddColliderSetup();
				}
				for (int i = 0; i < copyFrom.Colliders.Count; i++)
				{
					pasteTo.Colliders[i].ColliderSizeMultiply = copyFrom.Colliders[i].ColliderSizeMultiply;
					pasteTo.Colliders[i].CapsuleDirection = copyFrom.Colliders[i].CapsuleDirection;
					pasteTo.Colliders[i].ColliderRadius = copyFrom.Colliders[i].ColliderRadius;
					pasteTo.Colliders[i].ColliderLength = copyFrom.Colliders[i].ColliderLength;
					pasteTo.Colliders[i].ColliderBoxSize = copyFrom.Colliders[i].ColliderBoxSize;
					pasteTo.Colliders[i].ColliderMesh = copyFrom.Colliders[i].ColliderMesh;
				}
			}
		}

		public static void PasteColliderSettingsOfOtherBoneSymmetrical(this RagdollChainBone pasteTo, RagdollChainBone copyFrom, RagdollHandler handler)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.Colliders.Clear();
				while (pasteTo.Colliders.Count < copyFrom.Colliders.Count)
				{
					pasteTo.AddColliderSetup();
				}
				Transform baseTransform = handler.GetBaseTransform();
				for (int i = 0; i < copyFrom.Colliders.Count; i++)
				{
					Vector3 position = baseTransform.InverseTransformPoint(copyFrom.SourceBone.TransformPoint(copyFrom.Colliders[i].ColliderCenter));
					position.x *= -1f;
					pasteTo.Colliders[i].ColliderCenter = pasteTo.SourceBone.InverseTransformPoint(baseTransform.TransformPoint(position));
					pasteTo.Colliders[i].ColliderType = copyFrom.Colliders[i].ColliderType;
					pasteTo.Colliders[i].ColliderSizeMultiply = copyFrom.Colliders[i].ColliderSizeMultiply;
					pasteTo.Colliders[i].CapsuleDirection = copyFrom.Colliders[i].CapsuleDirection;
					pasteTo.Colliders[i].ColliderRadius = copyFrom.Colliders[i].ColliderRadius;
					pasteTo.Colliders[i].ColliderLength = copyFrom.Colliders[i].ColliderLength;
					pasteTo.Colliders[i].ColliderBoxSize = copyFrom.Colliders[i].ColliderBoxSize;
					pasteTo.Colliders[i].ColliderMesh = copyFrom.Colliders[i].ColliderMesh;
					pasteTo.Colliders[i].RotationCorrection = copyFrom.Colliders[i].RotationCorrection;
				}
			}
		}

		public static void PasteExtraSettingsOfOtherBone(this RagdollChainBone pasteTo, RagdollChainBone copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.BoneID = copyFrom.BoneID;
			}
		}

		public static void PastePhysicsSettingsOfOtherBone(this RagdollChainBone pasteTo, RagdollChainBone copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.MassMultiplier = copyFrom.MassMultiplier;
				pasteTo.ForceMultiplier = copyFrom.ForceMultiplier;
				pasteTo.MainAxis = copyFrom.MainAxis;
				pasteTo.InverseMainAxis = copyFrom.InverseMainAxis;
				pasteTo.TargetMainAxis = copyFrom.TargetMainAxis;
				pasteTo.MainAxisLowLimit = copyFrom.MainAxisLowLimit;
				pasteTo.MainAxisHighLimit = copyFrom.MainAxisHighLimit;
				pasteTo.SecondaryAxis = copyFrom.SecondaryAxis;
				pasteTo.InverseSecondaryAxis = copyFrom.InverseSecondaryAxis;
				pasteTo.TargetSecondaryAxis = copyFrom.TargetSecondaryAxis;
				pasteTo.SecondaryAxisAngleLimit = copyFrom.SecondaryAxisAngleLimit;
				pasteTo.ThirdAxisAngleLimit = copyFrom.ThirdAxisAngleLimit;
				pasteTo.OverrideMaterial = copyFrom.OverrideMaterial;
				pasteTo.UseIndividualParameters = copyFrom.UseIndividualParameters;
				pasteTo.OverrideInterpolation = copyFrom.OverrideInterpolation;
				pasteTo.OverrideDetectionMode = copyFrom.OverrideDetectionMode;
				pasteTo.OverrideDragValue = copyFrom.OverrideDragValue;
				pasteTo.OverrideAngularDrag = copyFrom.OverrideAngularDrag;
				pasteTo.OverrideSpringPower = copyFrom.OverrideSpringPower;
				pasteTo.OverrideSpringDamp = copyFrom.OverrideSpringDamp;
				pasteTo.HardMatchingMultiply = copyFrom.HardMatchingMultiply;
				pasteTo.HardMatchOverride = copyFrom.HardMatchOverride;
				pasteTo.ConnectionMassOverride = copyFrom.ConnectionMassOverride;
				pasteTo.DisableCollisionEvents = copyFrom.DisableCollisionEvents;
				pasteTo.ForceKinematicOnStanding = copyFrom.ForceKinematicOnStanding;
				pasteTo.ForceLimitsAllTheTime = copyFrom.ForceLimitsAllTheTime;
			}
		}

		public static void ApplyPhysicsSettingsToAllBonesInChain(this RagdollChainBone settingsOf, RagdollBonesChain applyToChain)
		{
			if (settingsOf == null || applyToChain == null)
			{
				return;
			}
			for (int i = 0; i < applyToChain.BoneSetups.Count; i++)
			{
				RagdollChainBone ragdollChainBone = applyToChain.BoneSetups[i];
				if (ragdollChainBone != settingsOf)
				{
					ragdollChainBone.PastePhysicsSettingsOfOtherBone(settingsOf);
				}
			}
		}

		public static void PastePhysicsSettingsOfOtherBoneSymmetrical(this RagdollChainBone pasteTo, RagdollChainBone copyFrom)
		{
			if (pasteTo != null && copyFrom != null)
			{
				pasteTo.MassMultiplier = copyFrom.MassMultiplier;
				pasteTo.ForceMultiplier = copyFrom.ForceMultiplier;
				pasteTo.MainAxis = copyFrom.MainAxis;
				pasteTo.InverseMainAxis = copyFrom.InverseMainAxis;
				pasteTo.TargetMainAxis = copyFrom.TargetMainAxis;
				pasteTo.MainAxisLowLimit = copyFrom.MainAxisLowLimit;
				pasteTo.MainAxisHighLimit = copyFrom.MainAxisHighLimit;
				pasteTo.SecondaryAxis = copyFrom.SecondaryAxis;
				pasteTo.InverseSecondaryAxis = copyFrom.InverseSecondaryAxis;
				pasteTo.TargetSecondaryAxis = copyFrom.TargetSecondaryAxis;
				pasteTo.SecondaryAxisAngleLimit = copyFrom.SecondaryAxisAngleLimit;
				pasteTo.ThirdAxisAngleLimit = copyFrom.ThirdAxisAngleLimit;
				pasteTo.MusclesBoost = copyFrom.MusclesBoost;
			}
		}

		private static void Log(string info, bool popup = true)
		{
			Debug.Log("[Ragdoll Animator 2] " + info);
		}
	}
}
