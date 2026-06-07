using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Data.Shapes;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class BuildingCranesBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		[Serializable]
		public struct CraneData
		{
			public Vector3Int RelativeCraneEntrancePos;

			public Vector3Int RelativeCranePos;
		}

		public List<CraneData> CraneDatas { get; private set; }

		public BuildingCranesBehaviourConfigurationDto(List<BuildingCranesBehaviour.Crane> cranes, FactoryObject buildingFactoryObject)
		{
			CraneDatas = new List<CraneData>();
			foreach (BuildingCranesBehaviour.Crane crane in cranes)
			{
				CraneDatas.Add(new CraneData
				{
					RelativeCraneEntrancePos = buildingFactoryObject.WorldPosToDataPos(crane.Position),
					RelativeCranePos = buildingFactoryObject.WorldPosToDataPos(crane.PickupPosition)
				});
			}
		}

		[JsonConstructor]
		public BuildingCranesBehaviourConfigurationDto(List<CraneData> craneDatas)
		{
			CraneDatas = craneDatas;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new BuildingCranesBehaviourConfigurationDto(CraneDatas);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
