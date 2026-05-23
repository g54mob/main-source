using System;
using System.Collections.Generic;
using Data.Shapes;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class CutterBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public Vector3Int Rotation { get; private set; }

		public List<int> Cuts { get; private set; }

		public int CutInterval { get; private set; }

		public ShapeDto ConfigShape { get; private set; }

		public bool IsConfigured { get; private set; }

		public CutterBehaviourConfigurationDto(List<int> cuts, int cutInterval, Vector3Int rotation, ShapeDto configShape, bool isConfigured)
		{
			Cuts = cuts;
			CutInterval = cutInterval;
			Rotation = rotation;
			ConfigShape = configShape;
			IsConfigured = isConfigured;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new CutterBehaviourConfigurationDto(Cuts, CutInterval, Rotation, ConfigShape, IsConfigured);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			if (ConfigShape == null)
			{
				return new List<ShapeDto>();
			}
			return new List<ShapeDto> { ConfigShape };
		}
	}
}
