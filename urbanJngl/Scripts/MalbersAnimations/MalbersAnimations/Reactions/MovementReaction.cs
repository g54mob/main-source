using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Movement", 0)]
	public class MovementReaction : MReaction
	{
		public enum Move_Reaction
		{
			UseCameraInput = 0,
			Sleep = 1,
			LockInput = 2,
			LockMovement = 3,
			AlwaysForward = 4,
			UseCameraUp = 5,
			LockForward = 6,
			LockHorizontal = 7,
			LockUpDown = 8
		}

		public Move_Reaction type = Move_Reaction.Sleep;

		public bool Value;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			switch (type)
			{
			case Move_Reaction.UseCameraInput:
				mAnimal.UseCameraInput = Value;
				break;
			case Move_Reaction.Sleep:
				mAnimal.Sleep = Value;
				break;
			case Move_Reaction.LockInput:
				mAnimal.LockInput = Value;
				break;
			case Move_Reaction.LockMovement:
				mAnimal.LockMovement = Value;
				break;
			case Move_Reaction.AlwaysForward:
				mAnimal.AlwaysForward = Value;
				break;
			case Move_Reaction.UseCameraUp:
				mAnimal.UseCameraUp = Value;
				break;
			case Move_Reaction.LockForward:
				mAnimal.LockForwardMovement = Value;
				break;
			case Move_Reaction.LockHorizontal:
				mAnimal.LockHorizontalMovement = Value;
				break;
			case Move_Reaction.LockUpDown:
				mAnimal.LockUpDownMovement = Value;
				break;
			}
			return true;
		}
	}
}
