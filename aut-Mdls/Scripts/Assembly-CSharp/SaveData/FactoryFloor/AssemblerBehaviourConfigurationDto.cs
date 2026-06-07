using System;
using System.Collections.Generic;
using System.Linq;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class AssemblerBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public const int CurrentVersion = 1;

		public ShapeDto CombinedShapeDto;

		public List<ConfigAssemblerShapeDto> ConfigShapes;

		public bool IsConfigured;

		public AssemblerBehaviourConfigurationDto()
			: base(1)
		{
			CombinedShapeDto = null;
			ConfigShapes = null;
			IsConfigured = false;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new AssemblerBehaviourConfigurationDto
			{
				CombinedShapeDto = CombinedShapeDto,
				ConfigShapes = ConfigShapes?.ToList(),
				IsConfigured = IsConfigured
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			if (!IsConfigured)
			{
				return new List<ShapeDto>();
			}
			List<ShapeDto> list = new List<ShapeDto> { CombinedShapeDto };
			foreach (ConfigAssemblerShapeDto configShape in ConfigShapes)
			{
				if (configShape != null)
				{
					list.Add(configShape.ShapeDto);
				}
			}
			return list;
		}
	}
}
