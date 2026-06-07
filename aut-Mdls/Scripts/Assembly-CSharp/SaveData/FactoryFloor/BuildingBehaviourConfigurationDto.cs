using System;
using System.Collections.Generic;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class BuildingBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public override BehaviourConfigurationDto CopyOf()
		{
			return new BuildingBehaviourConfigurationDto();
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
