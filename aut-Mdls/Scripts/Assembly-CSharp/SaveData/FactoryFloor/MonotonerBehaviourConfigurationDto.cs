using System;
using System.Collections.Generic;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class MonotonerBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public bool IsPaintingBlack { get; private set; }

		public MonotonerBehaviourConfigurationDto(bool isPaintingBlack)
		{
			IsPaintingBlack = isPaintingBlack;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new MonotonerBehaviourConfigurationDto(IsPaintingBlack);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
