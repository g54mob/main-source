using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/State", 0)]
	public class StateReaction : MReaction
	{
		public enum State_Reaction
		{
			Activate = 0,
			AllowExit = 1,
			ForceActivate = 2,
			Enable = 3,
			Disable = 4,
			SetExitStatus = 5,
			AllowExitToState = 6,
			Replace = 7
		}

		public State_Reaction type;

		[Tooltip("State you want to activate or Exit")]
		[Hide("type", true, new int[] { 7 })]
		public StateID ID;

		[Hide("type", new int[] { 0, 2 })]
		[Tooltip("This will change the value of the Enter Status parameter on the Animator. Useful to use different animations when Activating a State")]
		public int EnterStatus;

		[Tooltip("This will change the value of the Exit Status parameter on the Animator. Useful to use different animations when Exiting a State")]
		[Hide("type", new int[] { 5, 1, 6 })]
		public int ExitStatus;

		[Hide("type", new int[] { 7 })]
		public State replace;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			switch (type)
			{
			case State_Reaction.Activate:
			{
				State state = mAnimal.State_Get(ID);
				if ((bool)state && state.CanBeActivated)
				{
					state.Activate();
					return true;
				}
				return false;
			}
			case State_Reaction.AllowExit:
				if (ID == null || mAnimal.ActiveStateID == ID)
				{
					return mAnimal.ActiveState.AllowExit();
				}
				return false;
			case State_Reaction.ForceActivate:
				mAnimal.State_Force(ID);
				return true;
			case State_Reaction.Enable:
				mAnimal.State_Enable(ID);
				return true;
			case State_Reaction.Disable:
				mAnimal.State_Disable(ID);
				return true;
			case State_Reaction.SetExitStatus:
				mAnimal.State_SetEnterStatus(ExitStatus);
				return true;
			case State_Reaction.AllowExitToState:
				mAnimal.ActiveState.AllowExit(ID.ID, ExitStatus);
				return true;
			case State_Reaction.Replace:
				mAnimal.State_Replace(replace);
				return true;
			default:
				return false;
			}
		}
	}
}
