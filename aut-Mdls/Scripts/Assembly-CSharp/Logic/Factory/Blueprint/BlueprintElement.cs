using System.Collections.Generic;
using Data.Operator;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Logic.Factory.Blueprint
{
	public class BlueprintElement
	{
		public List<BehaviourConfigurationDto> Configurations = new List<BehaviourConfigurationDto>();

		public List<BehaviourSaveStateDto> SaveStates = new List<BehaviourSaveStateDto>();

		public List<Vector3Int> RelativePositions { get; private set; } = new List<Vector3Int>();

		public FactoryObjectData ObjectData { get; private set; }

		internal int Rotation { get; set; }

		internal bool Mirrored { get; set; }

		public int CreatedId { get; private set; } = -1;

		public bool IsSoftLinked { get; private set; }

		public bool IsHardLinked { get; private set; }

		public List<Vector3Int> SoftLinkedToRelativePositions { get; set; } = new List<Vector3Int>();

		public List<Vector3Int> HardLinkedToRelativePositions { get; set; } = new List<Vector3Int>();

		public BlueprintElement(List<Vector3Int> relativePositions, FactoryObjectData objectData, int rotation, bool mirrored, int createdId = -1)
		{
			RelativePositions = relativePositions;
			ObjectData = objectData;
			Rotation = rotation;
			Mirrored = mirrored;
			CreatedId = createdId;
		}

		public BlueprintElement(List<Vector3Int> relativePositions, FactoryObjectData objectData, int rotation, bool mirrored, bool isSoftLinked, bool isHardLinked, List<Vector3Int> softLinkedToRelativePositions, List<Vector3Int> hardLinkedToRelativePositions, List<BehaviourConfigurationDto> behaviourConfigurationDtos = null, int createdId = -1)
		{
			RelativePositions = relativePositions;
			ObjectData = objectData;
			Rotation = rotation;
			Mirrored = mirrored;
			CreatedId = createdId;
			IsSoftLinked = isSoftLinked;
			IsHardLinked = isHardLinked;
			SoftLinkedToRelativePositions = softLinkedToRelativePositions;
			HardLinkedToRelativePositions = hardLinkedToRelativePositions;
			Configurations = behaviourConfigurationDtos;
		}

		public BlueprintElement(List<Vector3Int> relativePositions, FactoryObjectData objectData, int rotation, bool mirrored, bool isSoftLinked, bool isHardLinked, List<Vector3Int> softLinkedToRelativePositions, List<Vector3Int> hardLinkedToRelativePositions, List<BehaviourConfigurationDto> behaviourConfigurationDtos, List<BehaviourSaveStateDto> behaviourSaveStateDtos, int createdId = -1)
		{
			RelativePositions = relativePositions;
			ObjectData = objectData;
			Rotation = rotation;
			Mirrored = mirrored;
			CreatedId = createdId;
			IsSoftLinked = isSoftLinked;
			IsHardLinked = isHardLinked;
			SoftLinkedToRelativePositions = softLinkedToRelativePositions;
			HardLinkedToRelativePositions = hardLinkedToRelativePositions;
			Configurations = behaviourConfigurationDtos;
			SaveStates = behaviourSaveStateDtos;
		}
	}
}
