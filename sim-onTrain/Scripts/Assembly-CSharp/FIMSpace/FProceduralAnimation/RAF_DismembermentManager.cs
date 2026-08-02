using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_DismembermentManager : RagdollAnimatorFeatureBase
	{
		private List<RagdollChainBone> update_dismemberedAnimated = new List<RagdollChainBone>();

		private List<RagdollChainBone> update_dismemberedSync = new List<RagdollChainBone>();

		private List<Action<RagdollChainBone>> OnBoneDismemberActions = new List<Action<RagdollChainBone>>();

		public override bool OnInit()
		{
			base.ParentRagdollHandler.AddToPostLateUpdateLoop(LateUpdate);
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromPostLateUpdateLoop(LateUpdate);
		}

		public void LateUpdate()
		{
			float totalBlend = base.ParentRagdollHandler.GetTotalBlend();
			if (update_dismemberedSync.Count > 0)
			{
				if (totalBlend >= 1f)
				{
					for (int i = 0; i < update_dismemberedSync.Count; i++)
					{
						RagdollChainBone ragdollChainBone = update_dismemberedSync[i];
						ragdollChainBone.SourceBone.SetPositionAndRotation(ragdollChainBone.PhysicalDummyBone.position, ragdollChainBone.PhysicalDummyBone.rotation);
					}
				}
				else
				{
					for (int j = 0; j < update_dismemberedSync.Count; j++)
					{
						RagdollChainBone ragdollChainBone2 = update_dismemberedSync[j];
						ragdollChainBone2.SourceBone.SetPositionAndRotation(Vector3.Lerp(ragdollChainBone2.SourceBone.position, ragdollChainBone2.PhysicalDummyBone.position, totalBlend), Quaternion.Slerp(ragdollChainBone2.SourceBone.rotation, ragdollChainBone2.PhysicalDummyBone.rotation, totalBlend));
					}
				}
			}
			if (update_dismemberedAnimated.Count > 0 && !base.ParentRagdollHandler.ApplyPositions)
			{
				for (int k = 0; k < update_dismemberedAnimated.Count; k++)
				{
					RagdollChainBone ragdollChainBone3 = update_dismemberedAnimated[k];
					ragdollChainBone3.BoneProcessor.ApplyPhysicalPositionToTheBone(ragdollChainBone3.ParentChain.GetBlend(totalBlend));
				}
			}
		}

		private void SortBySourceBoneDepth(List<RagdollChainBone> bones)
		{
			bones.Sort((RagdollChainBone x, RagdollChainBone y) => x.SourceBoneDepth.CompareTo(y.SourceBoneDepth));
		}

		private void AddBoneToDismemberedAnimatedUpdate(RagdollChainBone bone)
		{
			if (!update_dismemberedAnimated.Contains(bone))
			{
				update_dismemberedAnimated.Add(bone);
				SortBySourceBoneDepth(update_dismemberedAnimated);
			}
		}

		private void RemoveBoneFromDismemberedAnimatedUpdate(RagdollChainBone bone)
		{
			if (update_dismemberedAnimated.Contains(bone))
			{
				update_dismemberedAnimated.Remove(bone);
			}
		}

		private void AddBoneToDismemberedSyncUpdate(RagdollChainBone bone)
		{
			if (!update_dismemberedSync.Contains(bone))
			{
				update_dismemberedSync.Add(bone);
				SortBySourceBoneDepth(update_dismemberedSync);
			}
		}

		private void RemoveBoneFromDismemberedSyncUpdate(RagdollChainBone bone)
		{
			if (update_dismemberedSync.Contains(bone))
			{
				update_dismemberedSync.Remove(bone);
			}
		}

		public void AddToOnDismemberBoneActions(Action<RagdollChainBone> action)
		{
			if (!OnBoneDismemberActions.Contains(action))
			{
				OnBoneDismemberActions.Add(action);
			}
		}

		public void RemoveFromOnDismemberBoneActions(Action<RagdollChainBone> action)
		{
			if (OnBoneDismemberActions.Contains(action))
			{
				OnBoneDismemberActions.Remove(action);
			}
		}

		private void OnDismemberBone(RagdollChainBone bone)
		{
			foreach (Action<RagdollChainBone> onBoneDismemberAction in OnBoneDismemberActions)
			{
				onBoneDismemberAction(bone);
			}
		}

		public void DismemberBone(RagdollChainBone bone, EDismemberType type)
		{
			if (!base.ParentRagdollHandler.WasInitialized)
			{
				return;
			}
			ApplyBoneSwitchesOnDismember(bone);
			switch (type)
			{
			case EDismemberType.AnimatedDismembered:
				foreach (RagdollChainBone item in bone.ParentChain.CollectAllConnectedBones(bone))
				{
					ApplyBoneSwitchesOnDismember(item);
					ApplyFallDismemberParameters(item);
					item.ParentDismembered = true;
					AddBoneToDismemberedAnimatedUpdate(item);
				}
				bone.SetJointFreeMotion();
				break;
			case EDismemberType.Disconnect:
			{
				List<RagdollChainBone> list = bone.ParentChain.CollectAllConnectedBones(bone);
				foreach (RagdollChainBone.InBetweenBone item2 in bone.ParentChain.CollectAllFillBones(list))
				{
					if (bone.ParentChain.ParentHandler.skeletonFillExtraBonesList != null)
					{
						bone.ParentChain.ParentHandler.skeletonFillExtraBonesList.Remove(item2);
					}
					if (bone.ParentChain.ParentHandler.skeletonFillExtraBones != null)
					{
						bone.ParentChain.ParentHandler.skeletonFillExtraBones.Remove(item2.SourceBone);
					}
				}
				foreach (RagdollChainBone item3 in list)
				{
					ApplyBoneSwitchesOnDismember(item3);
					item3.ParentDismembered = true;
					item3.ParentChain.RemoveRuntimeBoneProcessing(item3);
					item3.ParentChain.ParentHandler.RemoveBoneFromRuntimeCalculations(item3);
					item3.SwitchOffJointAnimationMatching();
					AddBoneToDismemberedSyncUpdate(item3);
				}
				bone.SetJointFreeMotion();
				break;
			}
			case EDismemberType.CustomHandling:
				bone.ParentChain.RemoveBoneAndItsChildren(bone);
				break;
			}
			if (!bone.ParentChain.Detach)
			{
				bone.GameRigidbody.transform.SetParent(bone.ParentChain.ParentHandler.Dummy_Container, worldPositionStays: true);
			}
			bone.WasDismembered = true;
			OnDismemberBone(bone);
		}

		private void ApplyBoneSwitchesOnDismember(RagdollChainBone cbone)
		{
			cbone.BypassKinematicControl = true;
			cbone.ForceKinematicOnStanding = false;
			cbone.GameRigidbody.isKinematic = false;
		}

		private void ApplyFallDismemberParameters(RagdollChainBone bone)
		{
			if (!bone.WasDismembered)
			{
				bone.HardMatchingMultiply = 0f;
				bone.RefreshJoint(bone.ParentChain, fallMode: true, onSource: false, playmodeRefresh: true, base.ParentRagdollHandler.InstantConnectedMassChange);
				bone.RefreshCollider(bone.ParentChain, fallMode: true, onSource: false);
				bone.Joint_SetAngularMotionLock(ConfigurableJointMotion.Limited);
			}
		}

		public void RestoreDismemberedBones()
		{
			RagdollChainBone getAnchorBoneController = base.ParentRagdollHandler.GetAnchorBoneController;
			bool isKinematic = getAnchorBoneController.GameRigidbody.isKinematic;
			getAnchorBoneController.GameRigidbody.isKinematic = true;
			getAnchorBoneController.PhysicalDummyBone.position = getAnchorBoneController.BoneProcessor.AnimatorPosition;
			getAnchorBoneController.PhysicalDummyBone.rotation = getAnchorBoneController.BoneProcessor.AnimatorRotation;
			getAnchorBoneController.GameRigidbody.isKinematic = isKinematic;
			for (int i = 0; i < update_dismemberedSync.Count; i++)
			{
				RagdollChainBone bone = update_dismemberedSync[i];
				RestoreDismemberedBonePart1_List(bone);
			}
			for (int j = 0; j < update_dismemberedSync.Count; j++)
			{
				RagdollChainBone bone2 = update_dismemberedSync[j];
				RestoreDismemberedBonePart2_Calculations(bone2);
			}
			for (int k = 0; k < update_dismemberedAnimated.Count; k++)
			{
				RagdollChainBone bone3 = update_dismemberedAnimated[k];
				RestoreDismemberedBone_DismemberAnimatedMode(bone3);
			}
			RestoreDismemberedBonesPart3_RefreshAllBonesSettings();
			update_dismemberedSync.Clear();
			update_dismemberedAnimated.Clear();
		}

		public void RestoreDismemberedBone_DismemberAnimatedMode(RagdollChainBone bone)
		{
			if (!bone.ParentChain.BoneSetups.Contains(bone))
			{
				bone.ParentChain.BoneSetups.Add(bone);
			}
			bone.WasDismembered = false;
			bone.ParentDismembered = false;
			ProceedRestoreBoneJoint(bone);
		}

		public void RestoreDismemberedBonePart1_List(RagdollChainBone bone)
		{
			if (!bone.ParentChain.BoneSetups.Contains(bone))
			{
				bone.ParentChain.BoneSetups.Add(bone);
				bone.ParentChain.RuntimeBoneProcessors.Add(bone.BoneProcessor);
			}
			bone.WasDismembered = false;
			bone.ParentDismembered = false;
		}

		public void RestoreDismemberedBonePart2_Calculations(RagdollChainBone bone)
		{
			base.ParentRagdollHandler.RestoreBoneToRuntimeCalculations(bone);
			ProceedRestoreBoneJoint(bone);
		}

		public void RestoreDismemberedBonesPart3_RefreshAllBonesSettings()
		{
			base.ParentRagdollHandler.User_UpdateJointsPlayParameters(reset: false);
			base.ParentRagdollHandler.User_UpdateAllBonesParametersAfterManualChanges();
		}

		private void ProceedRestoreBoneJoint(RagdollChainBone bone)
		{
			bone.GameRigidbody.isKinematic = true;
			bone.PhysicalDummyBone.transform.position = bone.BoneProcessor.AnimatorPosition;
			bone.PhysicalDummyBone.transform.rotation = bone.BoneProcessor.AnimatorRotation;
			bone.PhysicalDummyBone.position = bone.BoneProcessor.AnimatorPosition;
			bone.PhysicalDummyBone.rotation = bone.BoneProcessor.AnimatorRotation;
			bone.GameRigidbody.isKinematic = false;
			bone.HardMatchingMultiply = 1f;
			bone.RefreshJoint(bone.ParentChain, bone.ParentChain.ParentHandler.IsFallingOrSleep, onSource: false, playmodeRefresh: true, base.ParentRagdollHandler.InstantConnectedMassChange);
			bone.RefreshJointLimitSwitch(bone.ParentChain);
		}
	}
}
