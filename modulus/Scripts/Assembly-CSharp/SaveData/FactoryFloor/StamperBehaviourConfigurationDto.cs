using System.Collections.Generic;
using Data.Shapes;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	public class StamperBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public Vector2Int StampStart;

		public Vector2Int StampEnd;

		public Vector3Int Rotation;

		public ShapeDto Shape;

		public override BehaviourConfigurationDto CopyOf()
		{
			return new StamperBehaviourConfigurationDto
			{
				StampStart = StampStart,
				StampEnd = StampEnd,
				Rotation = Rotation,
				Shape = Shape
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto> { Shape };
		}
	}
}
