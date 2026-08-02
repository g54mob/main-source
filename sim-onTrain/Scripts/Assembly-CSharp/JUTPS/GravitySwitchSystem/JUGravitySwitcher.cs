using JUTPSActions;
using UnityEngine;

namespace JUTPS.GravitySwitchSystem
{
	[AddComponentMenu("JU TPS/Third Person System/Gravity Switcher/JU Gravity Switcher")]
	public class JUGravitySwitcher : JUTPSAction
	{
		public bool EnabledGroundPlacement = true;

		public float Speed = 6f;

		public float ToGroundForce = 30f;

		public bool DisableGravityOnDirectionChange = true;

		protected virtual void DoGroundPlacement()
		{
			if (EnabledGroundPlacement)
			{
				TPSCharacter.UpDirection = Vector3.Lerp(TPSCharacter.UpDirection, (TPSCharacter.GroundNormal == Vector3.zero) ? Vector3.up : TPSCharacter.GroundNormal, Speed * Time.deltaTime);
				if (TPSCharacter.IsGrounded && !TPSCharacter.IsJumping && TPSCharacter.IsMoving)
				{
					rb.velocity += ((TPSCharacter.GroundNormal == Vector3.zero) ? (-Vector3.up) : (-TPSCharacter.GroundNormal * ToGroundForce * Time.deltaTime));
				}
			}
			else if (!TPSCharacter.IsGrounded)
			{
				TPSCharacter.UpDirection = Vector3.Lerp(TPSCharacter.UpDirection, Vector3.up, Speed * Time.deltaTime);
			}
			if (DisableGravityOnDirectionChange)
			{
				rb.useGravity = Vector3.Dot(TPSCharacter.UpDirection, Vector3.up) > 0.8f;
			}
		}

		private void Update()
		{
			DoGroundPlacement();
		}
	}
}
