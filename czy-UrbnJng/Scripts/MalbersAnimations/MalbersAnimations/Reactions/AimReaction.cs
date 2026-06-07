using System;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Tools/Aim", 0)]
	public class AimReaction : Reaction
	{
		[Tooltip("Set a new Target to the Aim Component. If left empty, it will clear the target")]
		public GameObjectReference NewTarget = new GameObjectReference();

		public override Type ReactionType => typeof(Aim);

		protected override bool _TryReact(Component reactor)
		{
			if (reactor is Aim aim)
			{
				if ((bool)NewTarget.Value)
				{
					aim.SetTarget(NewTarget.Value);
				}
				else
				{
					aim.ClearTarget();
				}
			}
			return true;
		}
	}
}
