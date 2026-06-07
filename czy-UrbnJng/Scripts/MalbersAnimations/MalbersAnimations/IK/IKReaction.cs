using System;
using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[AddTypeMenu("Malbers/IK", 0)]
	public class IKReaction : Reaction
	{
		public enum IKReactionType
		{
			Activate = 0,
			Deactivate = 1,
			SetTargets = 2,
			ClearTargets = 3
		}

		public string IKSet = "IKSetName";

		public IKReactionType action;

		public Transform[] targets;

		public override Type ReactionType => typeof(IIKSource);

		protected override bool _TryReact(Component reactor)
		{
			IIKSource iIKSource = reactor as IIKSource;
			switch (action)
			{
			case IKReactionType.Activate:
				iIKSource.Set_Enable(IKSet);
				break;
			case IKReactionType.Deactivate:
				iIKSource.Set_Disable(IKSet);
				break;
			case IKReactionType.SetTargets:
				iIKSource.Target_Set(IKSet, targets);
				break;
			case IKReactionType.ClearTargets:
				iIKSource.Target_Clear(IKSet);
				break;
			}
			return true;
		}
	}
}
