using System;
using Data.FactoryFloor;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class OutputTunnelBehaviorSaveStateDto : BehaviourSaveStateDto
	{
		public const int CurrentVersion = 1;

		[JsonProperty("ib")]
		public InputBufferSaveData InputBufferSaveData;

		public OutputTunnelBehaviorSaveStateDto()
			: base(1)
		{
		}
	}
}
