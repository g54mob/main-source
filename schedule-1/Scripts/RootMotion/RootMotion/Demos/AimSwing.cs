using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class AimSwing : MonoBehaviour
	{
		public AimIK ik;

		[Tooltip("The direction in which the weapon is aimed in animation (in character space). Tweak this value to adjust the aiming.")]
		public Vector3 animatedAimDirection;

		private void LateUpdate()
		{
		}
	}
}
