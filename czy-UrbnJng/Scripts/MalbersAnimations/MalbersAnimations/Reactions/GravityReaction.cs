using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Gravity", 0)]
	public class GravityReaction : MReaction
	{
		public enum Gravity_Reaction
		{
			Enable = 0,
			Reset = 1,
			GroundChangesGravity = 2,
			SnapAlignment = 3
		}

		public Gravity_Reaction type;

		[Hide("type", new int[] { 0, 2 })]
		public bool Value;

		protected override bool _TryReact(Component component)
		{
			MAnimal mAnimal = component as MAnimal;
			switch (type)
			{
			case Gravity_Reaction.Enable:
				mAnimal.UseGravity = Value;
				break;
			case Gravity_Reaction.Reset:
				mAnimal.Gravity_ResetDirection();
				break;
			case Gravity_Reaction.GroundChangesGravity:
				mAnimal.Gravity_DirectionFromGround(Value);
				break;
			case Gravity_Reaction.SnapAlignment:
				mAnimal.AlignToGravity();
				break;
			}
			return true;
		}
	}
}
