using System;
using Data.FactoryFloor.Resources;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class SkylineInBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public ResourceDto[] Resources;
	}
}
