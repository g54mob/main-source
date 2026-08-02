using JUTPS.FX;
using JUTPSActions;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.ActionScripts
{
	[AddComponentMenu("JU TPS/Third Person System/Actions/Fall Damage")]
	public class FallDamage : JUTPSAction
	{
		[Header("Fall Damage")]
		[Range(0f, 10f)]
		public float Damage = 10f;

		public float HeightToGetDamage = 4f;

		[Header("Landing Roll")]
		public bool RollWhenLand;

		public float HeightToMakeCharacterRoll = 2f;

		public bool CameraShake = true;

		[Range(0f, 5f)]
		public float CameraShakeIntensity = 3f;

		[Header("Events")]
		public UnityEvent OnLanding;

		public UnityEvent OnFalling;

		private float FallDamageIntensity;

		private void Update()
		{
			if (!TPSCharacter.IsGrounded && !TPSCharacter.CanJump)
			{
				Falling();
				float y = base.transform.InverseTransformDirection(rb.velocity).y;
				if (y > 0f)
				{
					FallDamageIntensity = 0f;
				}
				else
				{
					FallDamageIntensity = (0f - y) / 5f;
				}
				anim.SetFloat(TPSCharacter.AnimatorParameters.LandingIntensity, FallDamageIntensity);
			}
			else if (FallDamageIntensity > 0f)
			{
				if (Shaker.GetCurrentCameraInstance() != null)
				{
					Shaker.GetCurrentCameraInstance().Shake(FallDamageIntensity + 3f, 0.2f, 30f, 3f, 6f, CameraShakeIntensity * FallDamageIntensity / 30f);
				}
				if (FallDamageIntensity > HeightToMakeCharacterRoll && RollWhenLand)
				{
					TPSCharacter._Roll();
				}
				if (FallDamageIntensity > HeightToGetDamage)
				{
					TPSCharacter.TakeDamage(FallDamageIntensity * Damage);
				}
				FallDamageIntensity = 0f;
				Landed();
			}
			if (TPSCharacter.IsDriving || TPSCharacter.IsRagdolled)
			{
				FallDamageIntensity = 0f;
			}
		}

		protected virtual void Landed()
		{
			OnLanding.Invoke();
		}

		protected virtual void Falling()
		{
			OnFalling.Invoke();
		}
	}
}
