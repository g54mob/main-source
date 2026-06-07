using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	public class MWeaponBehavior : StateMachineBehaviour
	{
		public List<WeaponMessages> weaponActions = new List<WeaponMessages>();

		public bool debug;

		private IWeaponManager manager;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!animator.TryGetComponent<IWeaponManager>(out manager))
			{
				return;
			}
			foreach (WeaponMessages weaponAction in weaponActions)
			{
				weaponAction.MessageSent = false;
				if (weaponAction.time == 0f)
				{
					weaponAction.Execute(animator, manager, debug);
				}
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (manager == null)
			{
				return;
			}
			foreach (WeaponMessages weaponAction in weaponActions)
			{
				if (!weaponAction.MessageSent && weaponAction.sendInterrupted)
				{
					weaponAction.Execute(animator, manager, debug);
				}
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (manager == null)
			{
				return;
			}
			foreach (WeaponMessages weaponAction in weaponActions)
			{
				if (!weaponAction.MessageSent && stateInfo.normalizedTime >= weaponAction.time)
				{
					weaponAction.Execute(animator, manager, debug);
				}
			}
		}
	}
}
