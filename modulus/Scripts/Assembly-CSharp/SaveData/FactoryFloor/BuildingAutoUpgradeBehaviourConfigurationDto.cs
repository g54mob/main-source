using System;
using System.Collections.Generic;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class BuildingAutoUpgradeBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public bool AutoUpgrade;

		public BuildingAutoUpgradeBehaviourConfigurationDto(bool autoUpgrade)
		{
			AutoUpgrade = autoUpgrade;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new BuildingAutoUpgradeBehaviourConfigurationDto(AutoUpgrade);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
