using System;
using Data.FactoryFloor.PlacementValidators;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class StorageDepotSaveStateDto : BehaviourSaveStateDto, ICanOnlyBeMovedOnOwnIslandSaveState
	{
		[JsonProperty("id")]
		public int StoredResourceID;

		[JsonProperty("r")]
		public bool HasResource;

		[JsonProperty("c")]
		public Color Color;

		[JsonProperty("h")]
		public string Hash;

		[JsonProperty("a")]
		public ulong StoredAmount;

		[JsonProperty("island")]
		public int IslandID;

		int ICanOnlyBeMovedOnOwnIslandSaveState.GetIslandId()
		{
			return IslandID;
		}
	}
}
