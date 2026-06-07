using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.Operator;
using Logic.Factory.Blueprint;
using Newtonsoft.Json;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class SavedObjectDto
	{
		[JsonProperty("x")]
		public int PositionX;

		[JsonProperty("y")]
		public int PositionY;

		[JsonProperty("z")]
		public int PositionZ;

		[JsonProperty("r")]
		public int Rotation;

		[JsonProperty("m")]
		public int MirroredInt;

		[JsonProperty("c")]
		public int NonChangableInt;

		[JsonProperty("s")]
		public List<Vector3Int> SoftLinkedPositions;

		[JsonProperty("h")]
		public List<Vector3Int> HardLinkedPositions;

		[JsonProperty("i")]
		public int FactoryObjectDataId;

		[JsonProperty("bc")]
		public List<BehaviourConfigurationDto> BehaviourConfigurationDtos;

		[JsonProperty("bs")]
		public List<BehaviourSaveStateDto> BehaviourSaveStateDtos;

		[JsonProperty("e")]
		public bool ApartOfMap;

		public SavedObjectDto()
		{
		}

		public SavedObjectDto(Vector3Int position, int rotation, bool mirrored, bool nonChangable, int id, List<Vector3Int> softLinkedPositions, List<Vector3Int> hardLinkedPositions, List<BehaviourConfigurationDto> behaviourConfigurationDto, List<BehaviourSaveStateDto> behaviourSaveStateDto, bool isApartOfMap = false)
		{
			PositionX = position.x;
			PositionY = position.y;
			PositionZ = position.z;
			Rotation = rotation;
			MirroredInt = (mirrored ? 1 : 0);
			NonChangableInt = (nonChangable ? 1 : 0);
			FactoryObjectDataId = id;
			SoftLinkedPositions = (softLinkedPositions.IsNullOrEmpty() ? null : softLinkedPositions);
			HardLinkedPositions = (hardLinkedPositions.IsNullOrEmpty() ? null : hardLinkedPositions);
			BehaviourConfigurationDtos = (behaviourConfigurationDto.IsNullOrEmpty() ? null : behaviourConfigurationDto);
			BehaviourSaveStateDtos = (behaviourSaveStateDto.IsNullOrEmpty() ? null : behaviourSaveStateDto);
			ApartOfMap = isApartOfMap;
		}

		public FactoryObject ToFactoryObject(FactoryLayer layer, FactoryObjectData objectData, int id)
		{
			return new FactoryObject(CalculateRelativePositions(objectData), objectData, id, Rotation, MirroredInt == 1, NonChangableInt == 1, layer, BehaviourConfigurationDtos?.ToArray(), BehaviourSaveStateDtos?.ToArray(), ApartOfMap);
		}

		public BlueprintElement ToBlueprintElement(FactoryObjectData objectData)
		{
			return new BlueprintElement(CalculateRelativePositions(objectData), objectData, Rotation, MirroredInt == 1, IsSoftLinked(), IsHardLinked(), SoftLinkedPositions, HardLinkedPositions, BehaviourConfigurationDtos.IsNullOrEmpty() ? new List<BehaviourConfigurationDto>() : BehaviourConfigurationDtos);
		}

		private List<Vector3Int> CalculateRelativePositions(FactoryObjectData objectData)
		{
			BlueprintElement blueprintElement = new BlueprintElement(new List<Vector3Int>(objectData.RelativePositions), objectData, 0, mirrored: false);
			Blueprint blueprint = new Blueprint(Vector3Int.zero, 0, new List<BlueprintElement> { blueprintElement });
			if (Rotation != 0)
			{
				blueprint.Rotate(Rotation);
			}
			if (MirroredInt == 1)
			{
				blueprint.Mirror();
			}
			return FactoryObject.GetOccupiedPositions(GetPosition(), blueprintElement.RelativePositions);
		}

		public Vector3Int GetPosition()
		{
			return new Vector3Int(PositionX, PositionY, PositionZ);
		}

		public bool IsSoftLinked()
		{
			return !SoftLinkedPositions.IsNullOrEmpty();
		}

		public bool IsHardLinked()
		{
			return !HardLinkedPositions.IsNullOrEmpty();
		}
	}
}
