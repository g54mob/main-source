using System;
using XNode;

namespace Gh.Tk.Story.GameModifiers
{
	[NodeWidth(350)]
	public class AdjustTraitRarityGameModifierNode : GameModifierNode
	{
		public TraitRarityConfig[] config;

		public static bool TryGetTraitRarityOverride(Type traitType, string race, out int chance)
		{
			chance = default(int);
			return false;
		}
	}
}
