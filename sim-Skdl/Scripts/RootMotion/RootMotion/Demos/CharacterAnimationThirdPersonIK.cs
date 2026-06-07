using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class CharacterAnimationThirdPersonIK : CharacterAnimationThirdPerson
	{
		private FullBodyBipedIK ik;

		protected override void Start()
		{
		}

		protected override void LateUpdate()
		{
		}

		private void RotateEffector(IKEffector effector, Quaternion rotation, float mlp)
		{
		}
	}
}
