using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors
{
	public struct OnlineLevelUpData
	{
		public List<WeaponType> ChosenLevelUpWeapons { get; set; }

		public List<ItemType> ChosenLevelUpItems { get; set; }

		public List<CharacterController> ChosenAmuletTargets { get; set; }

		public List<WeightedLimitBreak> ChosenLimitBreaks { get; set; }

		public bool ShouldSwapToLevelUpUi { get; set; }

		public CharacterController TargetCharacter { get; set; }

		public bool AdjustXpFactors { get; set; }
	}
}
