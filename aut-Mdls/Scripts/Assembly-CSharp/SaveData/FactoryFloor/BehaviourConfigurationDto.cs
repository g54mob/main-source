using System;
using System.Collections.Generic;
using Data.SaveData;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public abstract class BehaviourConfigurationDto : AbstractSaveData
	{
		public abstract BehaviourConfigurationDto CopyOf();

		public abstract List<ShapeDto> GetAllRelatedShapes();

		protected BehaviourConfigurationDto()
			: base(0)
		{
		}

		protected BehaviourConfigurationDto(int currentVersion)
			: base(currentVersion)
		{
		}
	}
}
