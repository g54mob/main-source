using FIMSpace.FProceduralAnimation;
using UnityEngine;
using UnityEngine.UI;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_HeroFallDamage : MonoBehaviour, IRagdollAnimator2Receiver
	{
		public FBasic_RigidbodyMover Mover;

		public RagdollAnimator2 Ragdoll;

		[Tooltip("Falling Y Velocity to trigger fall ragdoll on")]
		public float RagdollOnFallVelocityAbove = 10f;

		public float AdditionalImpactOnFall = 0.1f;

		[Space(5f)]
		public GameObject TextPrefab;

		public Transform Canvas;

		public AudioSource HitAudio;

		[Space(5f)]
		public bool OnlyCoreCollisions = true;

		public float HitThreshold = 5f;

		public float MaxHitDamageAt = 10f;

		public float MaxSingleHitDamage = 30f;

		private Vector3 previousFrameVelocity = Vector3.zero;

		private Vector3 lastVelocity = Vector3.zero;

		private bool wasGrounded = true;

		protected RAF_BlendOnCollisions blendOnCollisions;

		private float lastHitAt = -100f;

		private float audioCulldown = -1f;

		private float lastFallY = 1000000f;

		protected virtual void Start()
		{
			blendOnCollisions = Ragdoll.Handler.GetExtraFeature<RAF_BlendOnCollisions>();
		}

		protected virtual void FixedUpdate()
		{
			previousFrameVelocity = lastVelocity;
			lastVelocity = Mover.Rigb.velocity;
			if (wasGrounded != Mover.isGrounded)
			{
				if (Ragdoll.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
				{
					lastFallY = 1000000f;
					float y = previousFrameVelocity.y;
					if (y <= 0f - RagdollOnFallVelocityAbove)
					{
						SpawnDamage(GetDamage((0f - y) * 4f));
						OnHit(20f);
						Ragdoll.User_SwitchFallState();
						if (AdditionalImpactOnFall > 0f)
						{
							Ragdoll.User_AddAllBonesImpact(previousFrameVelocity * AdditionalImpactOnFall);
						}
					}
				}
				if ((bool)blendOnCollisions)
				{
					blendOnCollisions.Helper.Enabled = Mover.isGrounded;
				}
			}
			wasGrounded = Mover.isGrounded;
		}

		public void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision)
		{
			if (hitted.ParentHandler.AnimatingMode != RagdollHandler.EAnimatingMode.Falling || Time.fixedTime - lastHitAt < 0.25f)
			{
				return;
			}
			float y = Ragdoll.User_GetPosition_BottomCenter().y;
			if (y - lastFallY > -3.5f)
			{
				return;
			}
			float num = mainCollision.impulse.magnitude;
			if (OnlyCoreCollisions)
			{
				if (hitted.ParentChain.ChainType != ERagdollChainType.Core)
				{
					return;
				}
			}
			else
			{
				if (hitted.ParentChain.ChainType.IsLeg())
				{
					num *= 0.8f;
				}
				if (hitted.ParentChain.ChainType.IsArm())
				{
					num *= 0.6f;
				}
			}
			if (num > HitThreshold)
			{
				lastFallY = y;
				OnHit(mainCollision.relativeVelocity.magnitude);
				SpawnDamage(GetDamage(num));
			}
		}

		protected virtual float GetDamage(float velocity)
		{
			return Mathf.Lerp(MaxSingleHitDamage * 0.2f, MaxSingleHitDamage, Mathf.InverseLerp(HitThreshold, MaxHitDamageAt, velocity));
		}

		private void OnHit(float velocity)
		{
			if (!(Time.unscaledTime - audioCulldown < 0.1f) && !(velocity < 2f))
			{
				audioCulldown = Time.unscaledTime;
				if ((bool)HitAudio)
				{
					HitAudio.PlayOneShot(HitAudio.clip, 0.3f + Mathf.InverseLerp(2f, 10f, velocity) * 0.7f);
				}
			}
		}

		private void SpawnDamage(float dmg)
		{
			lastHitAt = Time.fixedTime;
			GameObject obj = Object.Instantiate(TextPrefab);
			Text component = obj.GetComponent<Text>();
			component.text = Mathf.Round(0f - dmg).ToString();
			obj.transform.SetParent(Canvas);
			component.rectTransform.anchoredPosition = new Vector2(Mathf.Sin(Time.time * 7f) * 120f, 0f);
			component.rectTransform.localScale = Vector3.one;
		}
	}
}
