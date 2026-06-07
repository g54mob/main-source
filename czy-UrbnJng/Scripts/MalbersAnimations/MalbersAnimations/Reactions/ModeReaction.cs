using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Mode", 0)]
	public class ModeReaction : MReaction
	{
		public enum Mode_Reaction
		{
			Activate = 0,
			ActivateForever = 1,
			Interrupt = 2,
			Stop = 3,
			SetActiveIndex = 4,
			Enable = 5,
			Disable = 6,
			CoolDown = 7,
			ResetActiveIndex = 8,
			ForceActivate = 9,
			EnableAbility = 10,
			DisableAbility = 11
		}

		public Mode_Reaction type;

		public ModeID ID;

		[Tooltip("If set to -99 it will do a random ability from the Mode")]
		[Hide("type", new int[] { 0, 1, 4, 9, 10, 11 })]
		public int Ability = -99;

		[Hide("type", new int[] { 7 })]
		public bool HasCoolDown = true;

		[Hide("type", new int[] { 7 })]
		public float coolDown;

		[Hide("type", new int[] { 0, 9 })]
		public AbilityStatus abilityStatus;

		[Hide("abilityStatus", new int[] { 2 })]
		public float AbilityTime = 3f;

		[Hide("type", new int[] { 0, 1, 9 })]
		[Tooltip("Mode Power Value for the Animator Controller")]
		public float ModePower;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			Mode mode = mAnimal.Mode_Get(ID);
			if (mode == null || ID == null)
			{
				return false;
			}
			mAnimal.Mode_SetPower(ModePower);
			switch (type)
			{
			case Mode_Reaction.Activate:
				return mAnimal.Mode_TryActivate(ID, Ability, abilityStatus, AbilityTime);
			case Mode_Reaction.ActivateForever:
				return mAnimal.Mode_TryActivate(ID, Ability, AbilityStatus.Forever);
			case Mode_Reaction.Interrupt:
				if (mAnimal.ActiveMode.ID == ID)
				{
					mAnimal.Mode_Interrupt();
					return true;
				}
				return false;
			case Mode_Reaction.SetActiveIndex:
				mode.SetAbilityIndex(Ability);
				return true;
			case Mode_Reaction.ResetActiveIndex:
				mode.ResetAbilityIndex();
				return true;
			case Mode_Reaction.Enable:
				mAnimal.Mode_Enable(ID);
				return true;
			case Mode_Reaction.Disable:
				mAnimal.Mode_Disable(ID);
				return true;
			case Mode_Reaction.CoolDown:
				mode.HasCoolDown = HasCoolDown;
				mode.CoolDown.Value = coolDown;
				return true;
			case Mode_Reaction.ForceActivate:
				mAnimal.Mode_ForceActivate(ID, Ability, abilityStatus, AbilityTime);
				return true;
			case Mode_Reaction.Stop:
				mAnimal.Mode_Stop();
				return true;
			case Mode_Reaction.EnableAbility:
				return mAnimal.Mode_Ability_Enable(ID, Ability, enable: true);
			case Mode_Reaction.DisableAbility:
				return mAnimal.Mode_Ability_Enable(ID, Ability, enable: false);
			default:
				return false;
			}
		}
	}
}
