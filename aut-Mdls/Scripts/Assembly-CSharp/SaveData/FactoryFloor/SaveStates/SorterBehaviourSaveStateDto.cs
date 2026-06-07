using System;
using Data.FactoryFloor;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class SorterBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public InputBufferSaveData InputBufferSaveData;
	}
}
