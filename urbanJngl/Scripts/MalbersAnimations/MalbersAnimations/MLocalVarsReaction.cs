using System;
using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddTypeMenu("Malbers/Variables/Local Variable", 0)]
	public class MLocalVarsReaction : Reaction
	{
		[Header("Variable Name")]
		public LocalVar var;

		public override Type ReactionType => typeof(MLocalVars);

		protected override bool _TryReact(Component reactor)
		{
			MLocalVars mLocalVars = reactor as MLocalVars;
			if (mLocalVars.HasVar(var))
			{
				mLocalVars.SetVar(var);
				return true;
			}
			return false;
		}
	}
}
