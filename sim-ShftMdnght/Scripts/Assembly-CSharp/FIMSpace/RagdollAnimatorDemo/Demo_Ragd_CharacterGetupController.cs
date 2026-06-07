using System.Collections;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_CharacterGetupController : MonoBehaviour, IRagdollAnimator2Receiver
	{
		public RagdollAnimator2 RagdollAnim;

		public Animator Mecanim;

		public MonoBehaviour MoverToDisable;

		public Rigidbody CharacterRigidbody;

		public Transform debug;

		[Space(5f)]
		public float ApplyImpactPower = 4f;

		public LayerMask GroundLayer = 1;

		public int HitsToKnockout = 3;

		private int hitsOccured;

		private float hitCulldown;

		public void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision)
		{
			if (Mecanim.GetBool("Ragdolled") || Time.time - hitCulldown < 0.1f || RagdollAnim.Handler.IsFallingOrSleep || hitted.LatestEnterCollision.rigidbody == null)
			{
				return;
			}
			float num = 7f;
			if (!(hitted.LatestEnterCollision.relativeVelocity.magnitude < num))
			{
				hitsOccured++;
				hitCulldown = Time.time;
				if (hitsOccured >= HitsToKnockout)
				{
					Vector3 relativeVelocity = hitted.LatestEnterCollision.relativeVelocity;
					KnockoutImpact(hitted, relativeVelocity);
				}
			}
		}

		private void KnockoutImpact(RA2BoneCollisionHandler hittedBone, Vector3 relativeVelocity)
		{
		}

		private void FixedUpdate()
		{
		}

		private void GetUp(bool fromBack)
		{
		}

		private IEnumerator IERestoreControll()
		{
			float elapsed = 0f;
			while (elapsed < 1.35f)
			{
				yield return null;
				elapsed += Time.deltaTime;
				if (Mecanim.GetBool("Ragdolled"))
				{
					yield break;
				}
			}
			MoverToDisable.enabled = true;
		}
	}
}
