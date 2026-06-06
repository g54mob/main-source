using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Attack Trigger")]
	public class AttackTriggerBehaviour : StateMachineBehaviour
	{
		[Tooltip("0: Disable All Attack Triggers\n-1: Enable All Attack Triggers\nx: Enable the Attack Trigger by its index")]
		public int AttackTrigger = 1;

		[Tooltip("Profile to activate on the Damager")]
		[Min(0f)]
		public int Profile;

		[Tooltip("Range on the Animation that the Attack Trigger will be Active")]
		[MinMaxRange(0f, 1f)]
		public RangedFloat AttackActivation = new RangedFloat(0.3f, 0.6f);

		private bool isOn;

		private bool isOff;

		private IMDamagerSet[] damagers;

		public override void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
		{
			isOn = (isOff = false);
			if (damagers == null)
			{
				damagers = anim.GetComponents<IMDamagerSet>();
			}
			if (damagers != null)
			{
				IMDamagerSet[] array = damagers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DamagerAnimationStart(stateInfo.fullPathHash);
				}
			}
		}

		public override void OnStateUpdate(Animator anim, AnimatorStateInfo state, int layer)
		{
			float num = state.normalizedTime % 1f;
			if (!isOn && num >= AttackActivation.minValue)
			{
				IMDamagerSet[] array = damagers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ActivateDamager(AttackTrigger, Profile);
				}
				isOn = true;
			}
			if (!isOff && num >= AttackActivation.maxValue && (!anim.IsInTransition(layer) || anim.GetNextAnimatorStateInfo(layer).fullPathHash != state.fullPathHash))
			{
				IMDamagerSet[] array = damagers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ActivateDamager(0, Profile);
				}
				isOff = true;
			}
		}

		public override void OnStateExit(Animator anim, AnimatorStateInfo state, int layer)
		{
			if (anim.GetCurrentAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
			{
				return;
			}
			if (!isOff)
			{
				IMDamagerSet[] array = damagers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ActivateDamager(0, Profile);
				}
			}
			isOn = (isOff = false);
			if (damagers != null)
			{
				IMDamagerSet[] array = damagers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DamagerAnimationEnd(state.fullPathHash);
				}
			}
		}
	}
}
