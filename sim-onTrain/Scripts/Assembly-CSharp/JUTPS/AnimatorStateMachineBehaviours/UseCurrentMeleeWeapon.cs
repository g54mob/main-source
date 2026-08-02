using JUTPS.CharacterBrain;
using UnityEngine;

namespace JUTPS.AnimatorStateMachineBehaviours
{
	public class UseCurrentMeleeWeapon : StateMachineBehaviour
	{
		[Range(0f, 1f)]
		public float StartUsing = 0.15f;

		[Range(0f, 1f)]
		public float StopUsing = 0.8f;

		private JUCharacterBrain Controller;

		[HideInInspector]
		public bool UsingMeleeWeapon;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			UsingMeleeWeapon = false;
			if (Controller == null)
			{
				Controller = animator.gameObject.GetComponent<JUCharacterBrain>();
			}
			if (Controller == null)
			{
				Debug.LogError("the use of the melee weapon was not possible, could not find a JU Controller");
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Controller.MeleeWeaponInUseRightHand == null && Controller.MeleeWeaponInUseLeftHand == null)
			{
				return;
			}
			Controller.ResetDefaultLayersWeight(0f, Controller.FiringMode);
			Controller.LeftHandWeightIK = 0f;
			Controller.RightHandWeightIK = 0f;
			if (stateInfo.normalizedTime > StartUsing && stateInfo.normalizedTime < StopUsing && !UsingMeleeWeapon)
			{
				if ((bool)Controller.MeleeWeaponInUseRightHand)
				{
					Controller.MeleeWeaponInUseRightHand.UseItem();
				}
				if ((bool)Controller.MeleeWeaponInUseLeftHand)
				{
					Controller.MeleeWeaponInUseLeftHand.UseItem();
				}
				UsingMeleeWeapon = true;
			}
			if (stateInfo.normalizedTime > StopUsing && UsingMeleeWeapon)
			{
				if ((bool)Controller.MeleeWeaponInUseRightHand)
				{
					Controller.MeleeWeaponInUseRightHand.StopUseItem();
				}
				if ((bool)Controller.MeleeWeaponInUseLeftHand)
				{
					Controller.MeleeWeaponInUseLeftHand.StopUseItem();
				}
				UsingMeleeWeapon = false;
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if ((bool)Controller.MeleeWeaponInUseRightHand)
			{
				Controller.MeleeWeaponInUseRightHand.StopUseItem();
			}
			if ((bool)Controller.MeleeWeaponInUseLeftHand)
			{
				Controller.MeleeWeaponInUseLeftHand.StopUseItem();
			}
		}
	}
}
