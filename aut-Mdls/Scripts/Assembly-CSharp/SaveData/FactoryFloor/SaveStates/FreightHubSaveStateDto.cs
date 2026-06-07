using System;
using Data.FactoryFloor.PlacementValidators;
using Data.FactoryFloor.Resources;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class FreightHubSaveStateDto : BehaviourSaveStateDto, ICanOnlyBeMovedOnOwnIslandSaveState
	{
		[JsonProperty("ir")]
		public ResourceDto[] InResources;

		[JsonProperty("ia")]
		public int[] InResourceAmounts;

		[JsonProperty("or")]
		public ResourceDto[] OutResources;

		[JsonProperty("oa")]
		public int[] OutResourceAmounts;

		[JsonProperty("i")]
		public int IslandId;

		[JsonProperty("n")]
		public string CustomName;

		int ICanOnlyBeMovedOnOwnIslandSaveState.GetIslandId()
		{
			return IslandId;
		}
	}
}
