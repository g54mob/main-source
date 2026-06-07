using System;

namespace Brewery.Bar
{
	[Serializable]
	public class FullTagBreakdownEntry
	{
		public string tagName;

		public float factionMultiplier;

		public string catalystName;

		public float catalystSkillBonus;

		public float finalMultiplier;
	}
}
