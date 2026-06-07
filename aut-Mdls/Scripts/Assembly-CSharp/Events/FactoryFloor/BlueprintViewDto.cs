using System.Collections.Generic;
using Data.Operator;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Events.FactoryFloor
{
	public class BlueprintViewDto
	{
		public class BlueprintViewElementDto
		{
			public int ObjectId { get; private set; }

			public Vector3 Position { get; private set; }

			public List<Vector3> AllPositions { get; private set; }

			public int Rotation { get; private set; }

			public bool Mirrored { get; private set; }

			public List<BehaviourConfigurationDto> Configurations { get; private set; } = new List<BehaviourConfigurationDto>();

			public List<BehaviourSaveStateDto> SaveStates { get; private set; } = new List<BehaviourSaveStateDto>();

			public BlueprintViewElementDto(int objectId, Vector3 position, List<Vector3> allPositions, int rotation, bool mirrored, List<BehaviourConfigurationDto> configurations, List<BehaviourSaveStateDto> saveStates)
			{
				ObjectId = objectId;
				Position = position;
				AllPositions = allPositions;
				Rotation = rotation;
				Mirrored = mirrored;
				Configurations = configurations;
				SaveStates = saveStates;
			}
		}

		public List<BlueprintViewElementDto> BlueprintViewElementDtos = new List<BlueprintViewElementDto>();

		public Dictionary<Vector3Int, BlueprintViewElementDto> BlueprintViewElementDtoPosLookup = new Dictionary<Vector3Int, BlueprintViewElementDto>();

		public Vector3 Position { get; set; }

		public int Rotation { get; private set; }

		public static BlueprintViewDto Create(Blueprint blueprint, GridLocator gridLocator, Vector3Int blueprintNewPosition)
		{
			BlueprintViewDto blueprintViewDto = new BlueprintViewDto
			{
				Position = gridLocator.GetWorldPosition(blueprint.Position),
				Rotation = blueprint.Rotation
			};
			foreach (BlueprintElement element in blueprint.Elements)
			{
				FactoryObjectData objectData = element.ObjectData;
				int rotation = element.Rotation;
				Vector3 relativePosition = gridLocator.GetRelativePosition(element.RelativePositions[0]);
				List<Vector3> list = new List<Vector3>();
				foreach (Vector3Int relativePosition2 in element.RelativePositions)
				{
					list.Add(gridLocator.GetWorldPosition(relativePosition2));
				}
				bool mirrored = element.ObjectData.CanBeMirrored && element.Mirrored;
				BlueprintViewElementDto blueprintViewElementDto = new BlueprintViewElementDto(objectData.ID, relativePosition, list, rotation, mirrored, element.Configurations, element.SaveStates);
				blueprintViewDto.BlueprintViewElementDtos.Add(blueprintViewElementDto);
				blueprintViewDto.BlueprintViewElementDtoPosLookup.Add(element.RelativePositions[0], blueprintViewElementDto);
			}
			return blueprintViewDto;
		}
	}
}
