using System;
using System.Collections.Generic;
using Data.Shapes;

namespace SaveData.FactoryFloor.Configurations
{
	[Serializable]
	public class PointerBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public int Color { get; private set; }

		public PointerBehaviourConfigurationDto(int color)
		{
			Color = color;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new PointerBehaviourConfigurationDto(Color);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
