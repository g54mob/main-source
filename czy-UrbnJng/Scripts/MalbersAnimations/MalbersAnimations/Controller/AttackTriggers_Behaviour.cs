using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Attack Triggers")]
	public class AttackTriggers_Behaviour : StateMachineBehaviour
	{
		public List<AttacksBehavior> triggers = new List<AttacksBehavior>();

		private IMDamagerSet[] damagers;

		public override void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
		{
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
			foreach (AttacksBehavior trigger in triggers)
			{
				trigger.isOff = false;
				trigger.isOn = false;
			}
		}

		public override void OnStateUpdate(Animator anim, AnimatorStateInfo state, int layer)
		{
			float num = state.normalizedTime % 1f;
			foreach (AttacksBehavior trigger in triggers)
			{
				if (!trigger.isOn && num >= trigger.AttackActivation.minValue)
				{
					IMDamagerSet[] array = damagers;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].ActivateDamager(trigger.AttackTrigger, trigger.Profile);
					}
					trigger.isOn = true;
				}
				if (!trigger.isOff && num >= trigger.AttackActivation.maxValue)
				{
					if (anim.IsInTransition(layer) && anim.GetNextAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
					{
						break;
					}
					IMDamagerSet[] array = damagers;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].ActivateDamager(0, trigger.Profile);
					}
					trigger.isOff = true;
				}
			}
		}

		public override void OnStateExit(Animator anim, AnimatorStateInfo state, int layer)
		{
			if (anim.GetCurrentAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
			{
				return;
			}
			foreach (AttacksBehavior trigger in triggers)
			{
				if (!trigger.isOff)
				{
					IMDamagerSet[] array = damagers;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].ActivateDamager(0, trigger.Profile);
					}
				}
				bool isOn = (trigger.isOff = false);
				trigger.isOn = isOn;
			}
			if (damagers != null)
			{
				IMDamagerSet[] array = damagers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DamagerAnimationEnd(state.fullPathHash);
				}
			}
		}

		private void OnValidate()
		{
			foreach (AttacksBehavior trigger in triggers)
			{
				trigger.name = $"Trigger [{trigger.AttackTrigger}] Profile[{trigger.Profile}] → ({trigger.AttackActivation.minValue}) - ({trigger.AttackActivation.maxValue})";
			}
		}
	}
}
