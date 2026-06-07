using System;

namespace Motorways
{
	[Serializable]
	public class PrecalculatedTimedChallengeData
	{
		public string name;

		public ChallengeData[] challenges;

		public MapDefinition.CityNames city;

		public bool overriden;

		public bool serverOverride;
	}
}
