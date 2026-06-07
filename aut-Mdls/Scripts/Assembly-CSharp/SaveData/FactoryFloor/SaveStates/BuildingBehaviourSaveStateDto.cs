using System;
using System.Collections.Generic;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class BuildingBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public int Stage;

		public bool IsUpgrading;

		public bool IsActive;

		public List<int> ShapeRequirements = new List<int>();
	}
}
