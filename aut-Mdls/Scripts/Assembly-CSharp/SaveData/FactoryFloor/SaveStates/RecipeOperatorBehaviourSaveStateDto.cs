using System;
using System.Collections.Generic;
using Data.FactoryFloor.Resources;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class RecipeOperatorBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public int[] Resources;

		public Dictionary<int, List<ResourceDto>> CreatedResourcesByIndex;
	}
}
