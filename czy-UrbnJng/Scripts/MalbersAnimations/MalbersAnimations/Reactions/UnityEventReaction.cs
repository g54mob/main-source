using System;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("[Event]", 0)]
	public class UnityEventReaction : Reaction
	{
		public ComponentEvent Invoke = new ComponentEvent();

		public override Type ReactionType => typeof(Component);

		protected override bool _TryReact(Component component)
		{
			Invoke.Invoke(component);
			return true;
		}
	}
}
