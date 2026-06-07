using System;
using Data.FactoryFloor.Resources;
using SaveData.FactoryFloor.SaveStates;

namespace Data.FactoryFloor
{
	[Serializable]
	public class InputBufferSaveData : BehaviourSaveStateDto
	{
		public ResourceDto[] InputBufferResources;

		public InputBufferSaveData(ResourceDto[] resourceDtos)
		{
			InputBufferResources = resourceDtos;
		}
	}
}
