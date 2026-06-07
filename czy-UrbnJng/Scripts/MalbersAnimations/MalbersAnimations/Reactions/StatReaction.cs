using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Stats/Modify", 0)]
	public class StatReaction : Reaction
	{
		public List<StatModifier> modifiers = new List<StatModifier>
		{
			new StatModifier()
		};

		public override Type ReactionType => typeof(Stats);

		protected override bool _TryReact(Component reactor)
		{
			Stats stats = reactor as Stats;
			foreach (StatModifier modifier in modifiers)
			{
				modifier.ModifyStat(stats);
			}
			return true;
		}
	}
}
