using System;
using Restory.Data.RandomBallsPoolSystems;

namespace Restory.Data.Devices
{
	[Serializable]
	public class WeightedLocalizationKey : WeightedBallSourceObject<string>
	{
		public WeightedLocalizationKey(string localizationKey, int weight)
			: base(localizationKey, weight)
		{
		}
	}
}
