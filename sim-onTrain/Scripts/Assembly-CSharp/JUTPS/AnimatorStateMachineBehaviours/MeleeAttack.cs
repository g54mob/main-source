using JUTPS.CharacterBrain;
using UnityEngine;

namespace JUTPS.AnimatorStateMachineBehaviours
{
	public class MeleeAttack : StateMachineBehaviour
	{
		[Range(0f, 1f)]
		public float StartUsing = 0.15f;

		[Range(0f, 1f)]
		public float StopUsing = 0.8f;

		public bool RightHand = true;

		public bool LeftHand;

		public bool RightFoot;

		public bool LeftFoot;

		private JUCharacterBrain Controller;

		[HideInInspector]
		public bool IsPunching;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			IsPunching = false;
			if (Controller == null)
			{
				Controller = animator.gameObject.GetComponent<JUCharacterBrain>();
			}
			if (Controller == null)
			{
				Debug.LogError("could not find a JU Controller");
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stateInfo.normalizedTime > StartUsing && stateInfo.normalizedTime < StopUsing && !IsPunching)
			{
				if (Controller.RightHandDamager != null && RightHand)
				{
					Controller.RightHandDamager.gameObject.SetActive(value: true);
				}
				if (Controller.LeftHandDamager != null && LeftHand)
				{
					Controller.LeftHandDamager.gameObject.SetActive(value: true);
				}
				if (Controller.LeftFootDamager != null && LeftFoot)
				{
					Controller.LeftFootDamager.gameObject.SetActive(value: true);
				}
				if (Controller.RightFootDamager != null && RightFoot)
				{
					Controller.RightFootDamager.gameObject.SetActive(value: true);
				}
				Controller.IsPunching = true;
				IsPunching = true;
			}
			if (stateInfo.normalizedTime > StopUsing && IsPunching)
			{
				if (Controller.RightHandDamager != null && RightHand)
				{
					Controller.RightHandDamager.gameObject.SetActive(value: false);
				}
				if (Controller.LeftHandDamager != null && LeftHand)
				{
					Controller.LeftHandDamager.gameObject.SetActive(value: false);
				}
				if (Controller.LeftFootDamager != null && LeftFoot)
				{
					Controller.LeftFootDamager.gameObject.SetActive(value: false);
				}
				if (Controller.RightFootDamager != null && RightFoot)
				{
					Controller.RightFootDamager.gameObject.SetActive(value: false);
				}
				IsPunching = false;
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			IsPunching = false;
			if (Controller.RightHandDamager != null && RightHand)
			{
				Controller.RightHandDamager.gameObject.SetActive(value: false);
			}
			if (Controller.LeftHandDamager != null && LeftHand)
			{
				Controller.LeftHandDamager.gameObject.SetActive(value: false);
			}
			if (Controller.LeftFootDamager != null && LeftFoot)
			{
				Controller.LeftFootDamager.gameObject.SetActive(value: false);
			}
			if (Controller.RightFootDamager != null && RightFoot)
			{
				Controller.RightFootDamager.gameObject.SetActive(value: false);
			}
			Controller.IsPunching = false;
		}
	}
}
