using System.Collections.Generic;
using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_BlendOnCollisions : RagdollAnimatorFeatureBase
	{
		protected class BlendOnCollisionChain
		{
			public RagdollBonesChain OwnerChain;

			public BlendOnCollisionChain ParentOfChain;

			public List<BlendOnCollisionBone> Bones = new List<BlendOnCollisionBone>();

			public bool SkipLastBoneCollisionCheck;

			public BlendOnCollisionChain(RagdollBonesChain chain)
			{
				OwnerChain = chain;
			}

			public void Update(float delta, bool applyOnWholeChain, bool sensitive, float blendOffDelay)
			{
				BlendOnCollisionBone blendOnCollisionBone = null;
				int num = -1;
				int num2 = Bones.Count - 1;
				if (SkipLastBoneCollisionCheck)
				{
					num2 = Bones.Count - 2;
				}
				for (int num3 = num2; num3 >= 0; num3--)
				{
					if (Bones[num3].CollisionHandler.CollidesWithAnything())
					{
						blendOnCollisionBone = Bones[num3];
						num = num3;
						break;
					}
				}
				if (blendOnCollisionBone == null)
				{
					foreach (BlendOnCollisionBone bone in Bones)
					{
						bone.BlendOff(delta * 0.65f, blendOffDelay);
					}
					return;
				}
				if (applyOnWholeChain)
				{
					foreach (BlendOnCollisionBone bone2 in Bones)
					{
						bone2.BlendIn(delta);
					}
					if (sensitive && ParentOfChain != null)
					{
						for (int i = 0; i < Mathf.Min(1, ParentOfChain.Bones.Count); i++)
						{
							ParentOfChain.Bones[i].BlendIn(delta * 0.6f);
						}
					}
				}
				else if (sensitive)
				{
					if (Bones[0].CollisionHandler.CollidesWithAnything())
					{
						if (ParentOfChain != null && ParentOfChain.Bones.Count > 0)
						{
							ParentOfChain.Bones[0].BlendIn(delta * 0.75f);
						}
						return;
					}
					for (int j = num - 1; j < Bones.Count; j++)
					{
						Bones[j].BlendIn(delta);
					}
					for (int k = 0; k < num - 1; k++)
					{
						Bones[k].BlendOff(delta * 0.6f, blendOffDelay);
					}
				}
				else
				{
					for (int l = num; l < Bones.Count; l++)
					{
						Bones[l].BlendIn(delta);
					}
					for (int m = 0; m < num; m++)
					{
						Bones[m].BlendOff(delta * 0.6f, blendOffDelay);
					}
				}
			}

			public void ApplyBoneControllerBlendsToDummyBones()
			{
				foreach (BlendOnCollisionBone bone in Bones)
				{
					bone.ParentBone.BoneBlendMultiplier = bone.Blend;
				}
			}
		}

		protected class BlendOnCollisionBone
		{
			public BlendOnCollisionChain ParentChain;

			public RagdollChainBone ParentBone;

			public RA2BoneCollisionHandlerBase CollisionHandler;

			public float Blend;

			private float lastBlendIn = -100f;

			private float sd;

			public bool WasColliding(float duration = 0.4f)
			{
				return Time.fixedTime - lastBlendIn < duration;
			}

			public BlendOnCollisionBone(BlendOnCollisionChain chain, RagdollChainBone bone, RA2BoneCollisionHandlerBase handler)
			{
				ParentChain = chain;
				ParentBone = bone;
				CollisionHandler = handler;
			}

			public void BlendIn(float delta)
			{
				lastBlendIn = Time.fixedTime;
				if (Blend == 0f)
				{
					Blend = 0.125f;
				}
				Blend = Mathf.MoveTowards(Blend, 1f, delta);
			}

			public void BlendOff(float delta, float blendOffDelay)
			{
				if (!WasColliding(blendOffDelay))
				{
					Blend = Mathf.SmoothDamp(Blend, 0f, ref sd, 1f, 10000000f, delta);
					if (Blend < 0.0005f)
					{
						Blend = 0f;
					}
				}
			}
		}

		protected List<BlendOnCollisionChain> blendChains;

		protected List<RagdollBonesChain> legChains;

		protected List<BlendOnCollisionChain> legBlendChains;

		protected RagdollBonesChain coreChain;

		protected BlendOnCollisionChain coreBlendChain;

		protected FUniversalVariable blendingSpeed;

		protected FUniversalVariable applyOnWholeChains;

		protected FUniversalVariable sensitiveBlend;

		protected FUniversalVariable skipFeet;

		protected FUniversalVariable ignoreSelf;

		protected FUniversalVariable coreBlendLegs;

		protected FUniversalVariable turnOffLegs;

		public override bool OnInit()
		{
			bool flag = base.OnInit();
			if (!flag)
			{
				return false;
			}
			InitIndicators();
			blendingSpeed = base.InitializedWith.RequestVariable("Blending Speed:", 0.75f);
			applyOnWholeChains = base.InitializedWith.RequestVariable("Apply on whole chains:", true);
			sensitiveBlend = base.InitializedWith.RequestVariable("Sensitive Blend:", true);
			skipFeet = base.InitializedWith.RequestVariable("Skip Feet:", true);
			ignoreSelf = base.InitializedWith.RequestVariable("Ignore Self Collision Blend:", true);
			coreBlendLegs = base.InitializedWith.RequestVariable("Blend Legs With Core:", false);
			blendChains = new List<BlendOnCollisionChain>();
			legBlendChains = new List<BlendOnCollisionChain>();
			turnOffLegs = base.InitializedWith.RequestVariable("Turn Off Legs:", true);
			foreach (RagdollBonesChain chain2 in base.ParentRagdollHandler.Chains)
			{
				if (chain2.ChainType.IsLeg())
				{
					if (legChains == null)
					{
						legChains = new List<RagdollBonesChain>();
					}
					legChains.Add(chain2);
					if (turnOffLegs.GetBool())
					{
						continue;
					}
				}
				BlendOnCollisionChain blendOnCollisionChain = new BlendOnCollisionChain(chain2);
				if (chain2.ChainType.IsLeg() && skipFeet.GetBool())
				{
					blendOnCollisionChain.SkipLastBoneCollisionCheck = true;
				}
				foreach (RagdollChainBone boneSetup in chain2.BoneSetups)
				{
					RA2BoneCollisionHandlerBase collisionHandler = GetCollisionHandler(boneSetup);
					if (!(collisionHandler == null))
					{
						BlendOnCollisionBone item = new BlendOnCollisionBone(blendOnCollisionChain, boneSetup, collisionHandler);
						blendOnCollisionChain.Bones.Add(item);
					}
				}
				if (chain2.ChainType == ERagdollChainType.Core)
				{
					coreChain = chain2;
					coreBlendChain = blendOnCollisionChain;
				}
				else if (chain2.ChainType.IsLeg())
				{
					legBlendChains.Add(blendOnCollisionChain);
				}
				blendChains.Add(blendOnCollisionChain);
			}
			foreach (BlendOnCollisionChain blendChain in blendChains)
			{
				if (blendChain.OwnerChain.ConnectionBone == null)
				{
					continue;
				}
				RagdollBonesChain chain = base.ParentRagdollHandler.GetChain(blendChain.OwnerChain.ConnectionBone);
				if (chain == null)
				{
					continue;
				}
				foreach (BlendOnCollisionChain blendChain2 in blendChains)
				{
					if (blendChain2 != blendChain && chain == blendChain2.OwnerChain)
					{
						blendChain.ParentOfChain = blendChain2;
						break;
					}
				}
			}
			base.ParentRagdollHandler.AddToFixedUpdateLoop(UpdateBlending);
			return flag;
		}

		protected virtual void InitIndicators()
		{
			base.ParentRagdollHandler.PrepareDummyBonesCollisionIndicators(collectCollisions: true);
		}

		protected virtual RA2BoneCollisionHandlerBase GetCollisionHandler(RagdollChainBone bone)
		{
			if (bone.MainBoneCollider == null)
			{
				return null;
			}
			return bone.MainBoneCollider.GetComponent<RA2BoneCollisionHandler>();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromFixedUpdateLoop(UpdateBlending);
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.BoneBlendMultiplier = 1f;
				}
			}
		}

		public override void OnDisableRagdoll()
		{
			if (base.ParentRagdollHandler == null)
			{
				return;
			}
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (!(boneSetup.BoneProcessor.IndicatorComponent == null))
					{
						RA2BoneCollisionHandler rA2BoneCollisionHandler = boneSetup.BoneProcessor.IndicatorComponent as RA2BoneCollisionHandler;
						if (!(rA2BoneCollisionHandler == null))
						{
							rA2BoneCollisionHandler.CleanupCollisions();
						}
					}
				}
			}
		}

		private void UpdateBlending()
		{
			float num = (base.ParentRagdollHandler.UnscaledTime ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime);
			if (!base.InitializedWith.Enabled)
			{
				BlendInAll((5f + blendingSpeed.GetFloat() * 12f) * num);
				return;
			}
			float delta = (5f + blendingSpeed.GetFloat() * 12f) * num;
			if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing && base.InitializedWith.Enabled)
			{
				bool applyOnWholeChain = applyOnWholeChains.GetBool();
				bool sensitive = sensitiveBlend.GetBool();
				float blendOffDelay = 0.4f - 0.3f * blendingSpeed.GetFloat();
				foreach (BlendOnCollisionChain blendChain in blendChains)
				{
					blendChain.Update(delta, applyOnWholeChain, sensitive, blendOffDelay);
				}
				foreach (BlendOnCollisionChain blendChain2 in blendChains)
				{
					blendChain2.ApplyBoneControllerBlendsToDummyBones();
				}
				if (turnOffLegs.GetBool())
				{
					if (base.ParentRagdollHandler.LegsBlendInRequest)
					{
						foreach (RagdollBonesChain legChain in legChains)
						{
							BlendLegChain(legChain, 1f, delta, skipFeet.GetBool());
						}
						return;
					}
					{
						foreach (RagdollBonesChain legChain2 in legChains)
						{
							BlendLegChain(legChain2, 0f, delta, skipFeet: false);
						}
						return;
					}
				}
				if (coreBlendLegs.GetBool())
				{
					bool flag = false;
					for (int i = 0; i < coreBlendChain.Bones.Count; i++)
					{
						if (coreBlendChain.Bones[i].WasColliding(0.25f))
						{
							flag = true;
							break;
						}
					}
					if (!flag && !base.ParentRagdollHandler.LegsBlendInRequest)
					{
						return;
					}
					{
						foreach (BlendOnCollisionChain legBlendChain in legBlendChains)
						{
							foreach (BlendOnCollisionBone bone in legBlendChain.Bones)
							{
								bone.BlendIn(delta);
								legBlendChain.ApplyBoneControllerBlendsToDummyBones();
							}
						}
						return;
					}
				}
				if (!base.ParentRagdollHandler.LegsBlendInRequest)
				{
					return;
				}
				{
					foreach (BlendOnCollisionChain legBlendChain2 in legBlendChains)
					{
						foreach (BlendOnCollisionBone bone2 in legBlendChain2.Bones)
						{
							bone2.BlendIn(delta);
							legBlendChain2.ApplyBoneControllerBlendsToDummyBones();
						}
					}
					return;
				}
			}
			BlendInAll(delta);
		}

		public void BlendInAll(float delta)
		{
			foreach (BlendOnCollisionChain blendChain in blendChains)
			{
				foreach (BlendOnCollisionBone bone in blendChain.Bones)
				{
					bone.BlendIn(delta);
				}
				blendChain.ApplyBoneControllerBlendsToDummyBones();
			}
			if (!turnOffLegs.GetBool())
			{
				return;
			}
			foreach (RagdollBonesChain legChain in legChains)
			{
				BlendLegChain(legChain, 1f, delta, skipFeet: false);
			}
		}

		private void BlendLegChain(RagdollBonesChain chain, float target, float delta, bool skipFeet)
		{
			if (skipFeet && target > 0f && chain.BoneSetups.Count > 2)
			{
				for (int i = 0; i < chain.BoneSetups.Count - 1; i++)
				{
					RagdollChainBone ragdollChainBone = chain.BoneSetups[i];
					ragdollChainBone.BoneBlendMultiplier = Mathf.MoveTowards(ragdollChainBone.BoneBlendMultiplier, target, delta);
				}
				RagdollChainBone ragdollChainBone2 = chain.BoneSetups[chain.BoneSetups.Count - 1];
				ragdollChainBone2.BoneBlendMultiplier = Mathf.MoveTowards(ragdollChainBone2.BoneBlendMultiplier, 0f, delta);
				return;
			}
			foreach (RagdollChainBone boneSetup in chain.BoneSetups)
			{
				boneSetup.BoneBlendMultiplier = Mathf.MoveTowards(boneSetup.BoneBlendMultiplier, target, delta);
			}
		}

		public override void OnEnableRagdoll()
		{
		}
	}
}
