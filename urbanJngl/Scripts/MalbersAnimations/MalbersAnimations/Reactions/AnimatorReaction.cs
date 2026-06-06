using System;
using System.Collections.Generic;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Unity/Animator SetParameter", 0)]
	public class AnimatorReaction : Reaction
	{
		public List<MAnimatorParameter> parameters = new List<MAnimatorParameter>();

		public override Type ReactionType => typeof(Animator);

		public void Set(Animator anim)
		{
			foreach (MAnimatorParameter parameter in parameters)
			{
				parameter.Set(anim);
			}
		}

		protected override bool _TryReact(Component component)
		{
			Set(component as Animator);
			return true;
		}
	}
}
