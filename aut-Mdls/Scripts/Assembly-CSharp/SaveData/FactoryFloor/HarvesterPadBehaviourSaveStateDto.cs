using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SaveData.FactoryFloor.SaveStates;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine.Serialization;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class HarvesterPadBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		[JsonProperty("ri")]
		[FormerlySerializedAs("ResourceID")]
		public int ResourceID;

		[JsonProperty("rc")]
		[FormerlySerializedAs("ResourceCount")]
		public int ResourceCount;

		[JsonProperty("ds")]
		public Dictionary<int, List<HarvesterPadDroneSaveStateDto>> DroneSaveStates;

		public HarvesterPadBehaviourSaveStateDto()
		{
		}

		public HarvesterPadBehaviourSaveStateDto(int resourceID, int resourceCount, Dictionary<int, List<HarvesterPadDroneSaveStateDto>> droneSaveStates)
		{
			ResourceID = resourceID;
			ResourceCount = resourceCount;
			DroneSaveStates = droneSaveStates;
		}
	}
}
