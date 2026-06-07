using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Damage/Play Combo", 0)]
	public class ComboReaction : Reaction
	{
		[Tooltip("Branch to Play on the Combo")]
		public int Branch;

		public override Type ReactionType => typeof(ComboManager);

		protected override bool _TryReact(Component component)
		{
			(component as ComboManager).Play();
			return true;
		}
	}
}
