using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_3HitsFall : MonoBehaviour, IRagdollAnimator2Receiver
	{
		public LayerMask DetectHitsOn = 0;

		public Color FullHP = Color.green;

		public Color HP2 = Color.green;

		public Color HP1 = Color.green;

		public Color HP0 = Color.red;

		public SkinnedMeshRenderer Skin;

		public float FallImpactPower = 1f;

		public float FallImpactDuration = 0.1f;

		public float DamageAtVelocity = 4f;

		internal float lastImpulse;

		private int HP = 3;

		private float hitTime;

		private void Start()
		{
			SetColor(FullHP);
		}

		public void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision)
		{
			if (Time.fixedTime - hitTime < 0.25f || !RagdollHandlerUtilities.LayerMaskContains(DetectHitsOn, mainCollision.collider.gameObject.layer) || (lastImpulse = mainCollision.impulse.magnitude) < DamageAtVelocity)
			{
				return;
			}
			hitTime = Time.fixedTime;
			HP--;
			if (HP >= 0)
			{
				if (HP == 2)
				{
					SetColor(HP2);
				}
				else if (HP == 1)
				{
					SetColor(HP1);
				}
				else if (HP == 0)
				{
					SetColor(HP0);
				}
			}
			if (HP == 0)
			{
				RagdollHandler parentHandler = hitted.ParentHandler;
				parentHandler.User_SwitchFallState(RagdollHandler.EAnimatingMode.Falling);
				Vector3 normalized = mainCollision.relativeVelocity.normalized;
				parentHandler.User_AddAllBonesImpact(normalized * FallImpactPower, FallImpactDuration, ForceMode.Acceleration);
				parentHandler.User_AddRigidbodyImpact(hitted.DummyBoneRigidbody, normalized * FallImpactPower, FallImpactDuration, ForceMode.VelocityChange);
			}
		}

		public void ResetHP()
		{
			HP = 3;
			SetColor(FullHP);
		}

		private void SetColor(Color c)
		{
			Material[] materials = Skin.materials;
			materials[0].color = c;
			materials[1].color = c * 0.55f;
			Skin.materials = materials;
		}
	}
}
