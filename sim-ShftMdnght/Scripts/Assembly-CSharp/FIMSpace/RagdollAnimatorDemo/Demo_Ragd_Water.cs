using System.Collections.Generic;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_Water : FimpossibleComponent
	{
		private List<RagdollAnimator2> WaterModeRagdolls = new List<RagdollAnimator2>();

		public Collider WaterCollider;

		public GameObject WaterParticle;

		public GameObject WaterParticleLight;

		[Space(6f)]
		public float StopPushOn = 0.05f;

		public float StrongerPushBelow = 1.5f;

		public float AveragePushPower = 1f;

		public float DeepPushMultiplier = 5f;

		private void OnTriggerEnter(Collider other)
		{
			RagdollAnimator2BoneIndicator component = other.gameObject.GetComponent<RagdollAnimator2BoneIndicator>();
			if (!(component == null) && component.BoneSettings != null && component.BoneSettings.IsAnchor && !WaterModeRagdolls.Contains(component.ParentRagdollAnimator))
			{
				WaterModeRagdolls.Add(component.ParentRagdollAnimator);
				component.ParentRagdollAnimator.User_SwitchAllBonesUseGravity(useGravity: false);
				component.ParentRagdollAnimator.User_SwitchAllBonesMaxVelocity(5f);
				component.ParentRagdollAnimator.User_ChangeAllRigidbodiesDrag(1f);
				component.ParentRagdollAnimator.User_ChangeAllRigidbodiesAngularDrag(1f);
				float magnitude = component.DummyBoneRigidbody.velocity.magnitude;
				if (magnitude > 4f)
				{
					SpawnSplashParticle(WaterParticle, component.DummyBoneRigidbody.position);
				}
				else if (magnitude > 2f)
				{
					SpawnSplashParticle(WaterParticleLight, component.DummyBoneRigidbody.position);
				}
			}
		}

		private void SpawnSplashParticle(GameObject particle, Vector3 wPos)
		{
			Ray ray = new Ray(wPos + Vector3.up * 1000f, Vector3.down);
			float y = WaterCollider.bounds.max.y;
			if (WaterCollider.Raycast(ray, out var hitInfo, 10000f))
			{
				y = hitInfo.point.y;
			}
			wPos.y = y;
			Object.Instantiate(particle, wPos, Quaternion.Euler(-90f, 0f, 0f));
		}

		private void OnTriggerExit(Collider other)
		{
			RagdollAnimator2BoneIndicator component = other.gameObject.GetComponent<RagdollAnimator2BoneIndicator>();
			if (!(component == null) && component.BoneSettings != null && component.BoneSettings.IsAnchor && WaterModeRagdolls.Contains(component.ParentRagdollAnimator))
			{
				WaterModeRagdolls.Remove(component.ParentRagdollAnimator);
				component.ParentRagdollAnimator.User_SwitchAllBonesUseGravity();
				component.ParentRagdollAnimator.User_SwitchAllBonesMaxVelocity(10000f);
				component.ParentRagdollAnimator.User_ChangeAllRigidbodiesDrag(component.ParentRagdollAnimator.Handler.RigidbodyDragValue);
				component.ParentRagdollAnimator.User_ChangeAllRigidbodiesAngularDrag(component.ParentRagdollAnimator.Handler.RigidbodyAngularDragValue);
			}
		}

		private void FixedUpdate()
		{
			for (int i = 0; i < WaterModeRagdolls.Count; i++)
			{
				RagdollAnimator2 ragdollAnimator = WaterModeRagdolls[i];
				RagdollChainBone getAnchorBoneController = ragdollAnimator.Handler.GetAnchorBoneController;
				Ray ray = new Ray(getAnchorBoneController.PhysicalDummyBone.position + Vector3.up * 1000f, Vector3.down);
				float num = 0.5f;
				float y = WaterCollider.bounds.max.y;
				if (WaterCollider.Raycast(ray, out var hitInfo, 10000f))
				{
					y = hitInfo.point.y;
					float num2 = Mathf.Abs(hitInfo.point.y - getAnchorBoneController.PhysicalDummyBone.position.y);
					num = ((!(num2 < StrongerPushBelow)) ? Mathf.InverseLerp(0f, StrongerPushBelow, num2) : 1f);
				}
				y -= StopPushOn;
				foreach (RagdollBonesChain chain in ragdollAnimator.Handler.Chains)
				{
					for (int j = 0; j < chain.BoneSetups.Count; j++)
					{
						if (!(chain.BoneSetups[j].MainBoneCollider.bounds.center.y > y))
						{
							chain.BoneSetups[j].GameRigidbody.AddForce(Vector3.up * (1f + num * DeepPushMultiplier) * AveragePushPower, ForceMode.Acceleration);
						}
					}
				}
			}
		}
	}
}
