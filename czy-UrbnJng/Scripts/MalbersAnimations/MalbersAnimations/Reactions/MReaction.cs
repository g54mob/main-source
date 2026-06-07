using System;
using MalbersAnimations.Controller;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	public abstract class MReaction : Reaction
	{
		public override Type ReactionType => typeof(MAnimal);
	}
}
