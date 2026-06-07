using System;
using System.Collections.Generic;
using Data.FactoryFloor.Drones.Freighter.SaveStateDtos;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class FreightersSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int MaxFreighterAmount;

		public List<FreighterObjectSaveStateDto> FreighterObjectsSaveData = new List<FreighterObjectSaveStateDto>();

		public FreightersSaveData(int maxFreighterAmount, List<FreighterObjectSaveStateDto> freighterObjectsSaveData)
			: base(0)
		{
			MaxFreighterAmount = maxFreighterAmount;
			FreighterObjectsSaveData = freighterObjectsSaveData;
		}
	}
}
