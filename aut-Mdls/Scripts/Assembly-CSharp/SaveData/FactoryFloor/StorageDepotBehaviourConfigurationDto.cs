using System;
using System.Collections.Generic;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class StorageDepotBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public const int CurrentVersion = 2;

		public override BehaviourConfigurationDto CopyOf()
		{
			return new StorageDepotBehaviourConfigurationDto();
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
