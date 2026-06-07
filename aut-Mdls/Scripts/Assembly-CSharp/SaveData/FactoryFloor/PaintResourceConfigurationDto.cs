using System.Collections.Generic;
using Data.Shapes;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	public class PaintResourceConfigurationDto : BehaviourConfigurationDto
	{
		public Color Color;

		public PaintResourceConfigurationDto(Color color)
		{
			Color = color;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new PaintResourceConfigurationDto(Color);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
