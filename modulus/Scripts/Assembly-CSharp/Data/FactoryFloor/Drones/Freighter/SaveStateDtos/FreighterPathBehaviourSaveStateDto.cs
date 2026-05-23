using System;
using System.Collections.Generic;
using Data.SaveData;

namespace Data.FactoryFloor.Drones.Freighter.SaveStateDtos
{
	[Serializable]
	public class FreighterPathBehaviourSaveStateDto : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int CurrentStopIndex;

		public int NextStopIndex;

		public List<FreighterStopConfigurationSaveStateDto> FreighterStopConfigurations;

		public FreighterPathBehaviourSaveStateDto()
			: base(0)
		{
		}
	}
}
