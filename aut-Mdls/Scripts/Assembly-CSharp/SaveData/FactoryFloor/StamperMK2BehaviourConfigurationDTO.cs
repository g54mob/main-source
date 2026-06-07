using System.Collections.Generic;
using Data.Shapes;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	public class StamperMK2BehaviourConfigurationDTO : BehaviourConfigurationDto
	{
		public ShapeDto StampedShapeDTO;

		public ShapeDto ExcessShapeDTO;

		public ShapeDto SelectedShapeADTO;

		public ShapeDto SelectedShapeBDTO;

		public ShapeDto ConfigShapeDTO;

		public Vector3Int Rotation;

		public override BehaviourConfigurationDto CopyOf()
		{
			return new StamperMK2BehaviourConfigurationDTO
			{
				StampedShapeDTO = StampedShapeDTO,
				Rotation = Rotation,
				ExcessShapeDTO = ExcessShapeDTO,
				SelectedShapeADTO = SelectedShapeADTO,
				SelectedShapeBDTO = SelectedShapeBDTO,
				ConfigShapeDTO = ConfigShapeDTO
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			List<ShapeDto> list = new List<ShapeDto>();
			if (ExcessShapeDTO != null)
			{
				list.Add(ExcessShapeDTO);
			}
			if (StampedShapeDTO != null)
			{
				list.Add(StampedShapeDTO);
			}
			if (SelectedShapeADTO != null)
			{
				list.Add(SelectedShapeADTO);
			}
			if (SelectedShapeBDTO != null)
			{
				list.Add(SelectedShapeBDTO);
			}
			if (ConfigShapeDTO != null)
			{
				list.Add(ConfigShapeDTO);
			}
			return list;
		}
	}
}
