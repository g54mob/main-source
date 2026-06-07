using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class ConveyorBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public const int CurrentVersion = 1;

		[JsonProperty("i")]
		public int ResourceDataID;

		[JsonProperty("h")]
		public string Hash;

		[JsonProperty("c")]
		public Color Color;

		public ConveyorBehaviourSaveStateDto()
			: base(1)
		{
		}
	}
}
