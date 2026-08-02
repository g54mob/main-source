using JUTPS.JUInputSystem;
using JUTPSActions;
using UnityEngine;

namespace JUTPS.ActionScripts
{
	[AddComponentMenu("JU TPS/Third Person System/Additionals/Sidescroller Locomotion")]
	public class SidescrollerLocomotion : JUTPSAction
	{
		public bool BlockHorizontalLocomotion = true;

		public bool UseVerticalInputToCrouch = true;

		public bool BlockZPosition = true;

		private float startZPosition;

		private void Start()
		{
		}

		private void Update()
		{
			if (BlockHorizontalLocomotion)
			{
				TPSCharacter.BlockVerticalInput = true;
			}
			if (BlockZPosition)
			{
				Vector3 velocity = rb.velocity;
				velocity.z = 0f;
				rb.velocity = velocity;
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, startZPosition);
			}
			if (UseVerticalInputToCrouch)
			{
				if (JUInput.GetAxis(JUInput.Axis.MoveVertical) < -0.2f && !TPSCharacter.IsCrouched)
				{
					TPSCharacter.IsCrouched = true;
				}
				if (JUInput.GetAxis(JUInput.Axis.MoveVertical) > 0.2f && TPSCharacter.IsCrouched)
				{
					TPSCharacter.IsCrouched = false;
				}
			}
		}
	}
}
