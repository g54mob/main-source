using System;
using System.Collections.Generic;

namespace Gh.Tk.Story.Structure
{
	[Serializable]
	public class ScenarioPreset
	{
		public int startingMoneyRelaxed;

		public int startingMoney;

		public int startingMoneyChallenging;

		public int minStartingMoney;

		public int maxStartingMoney;

		public List<ScenarioTrait> traits;

		public List<ScenarioChallenge> challenges;

		public IEnumerable<ScenarioTrait> GetScenarioTraits()
		{
			return null;
		}
	}
}
