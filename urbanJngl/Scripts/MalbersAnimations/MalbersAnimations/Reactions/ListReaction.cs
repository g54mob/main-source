using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("* Multiple Reactions", 0)]
	public class ListReaction : Reaction
	{
		[SerializeReference]
		[SubclassSelector]
		public List<Reaction> reactions = new List<Reaction>();

		public override Type ReactionType => typeof(Component);

		protected override bool _TryReact(Component component)
		{
			if (reactions != null)
			{
				bool flag = true;
				{
					foreach (Reaction reaction in reactions)
					{
						Component component2 = reaction.VerifyComponent(component);
						if (component2 != null)
						{
							flag = flag && reaction.TryReact(component2);
						}
					}
					return flag;
				}
			}
			return false;
		}
	}
}
