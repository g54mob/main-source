using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Stats/Enable-Disable", 0)]
	public class StatEnableReaction : Reaction
	{
		public IDEnable<StatID>[] stats;

		public override Type ReactionType => typeof(Stats);

		protected override bool _TryReact(Component component)
		{
			Stats stats = component as Stats;
			IDEnable<StatID>[] array = this.stats;
			foreach (IDEnable<StatID> iDEnable in array)
			{
				stats.Stat_Get(iDEnable.ID)?.SetActive(iDEnable.enable);
			}
			return true;
		}
	}
}
