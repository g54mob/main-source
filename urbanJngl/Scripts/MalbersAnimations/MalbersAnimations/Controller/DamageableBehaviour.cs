using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class DamageableBehaviour : StateMachineBehaviour
	{
		private IMDamage damageable;

		public List<DamageableProfile> DamageProfile;

		public override void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (damageable == null)
			{
				damageable = anim.GetComponent<IMDamage>();
			}
			foreach (DamageableProfile item in DamageProfile)
			{
				item.isOff = false;
				item.isOn = false;
				if (item.ProfileActivation.minValue == 0f)
				{
					damageable.Profile_Set(item.Profile);
					item.isOn = true;
				}
			}
		}

		public override void OnStateUpdate(Animator anim, AnimatorStateInfo state, int layer)
		{
			float num = state.normalizedTime % 1f;
			foreach (DamageableProfile item in DamageProfile)
			{
				if (!item.isOn && num >= item.ProfileActivation.minValue)
				{
					damageable.Profile_Set(item.Profile);
					item.isOn = true;
				}
				else if (!item.isOff && num >= item.ProfileActivation.maxValue)
				{
					if (anim.IsInTransition(layer) && anim.GetNextAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
					{
						break;
					}
					item.isOff = true;
					damageable.Profile_Restore();
				}
			}
		}

		public override void OnStateExit(Animator anim, AnimatorStateInfo state, int layer)
		{
			if (anim.GetCurrentAnimatorStateInfo(layer).fullPathHash == state.fullPathHash)
			{
				return;
			}
			foreach (DamageableProfile item in DamageProfile)
			{
				if (!item.isOff)
				{
					damageable.Profile_Restore();
				}
				bool isOn = (item.isOff = false);
				item.isOn = isOn;
			}
		}

		private void OnValidate()
		{
			foreach (DamageableProfile item in DamageProfile)
			{
				item.display = $"Profile [{item.Profile.Value}] → ({item.ProfileActivation.minValue}) - ({item.ProfileActivation.maxValue})";
			}
		}

		private void Reset()
		{
			DamageProfile = new List<DamageableProfile>
			{
				new DamageableProfile
				{
					Profile = new StringReference("Default"),
					ProfileActivation = new RangedFloat(0.3f, 0.6f)
				}
			};
			OnValidate();
		}
	}
}
