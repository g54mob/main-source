using System;
using System.Collections.Generic;
using Data.Operator;
using Data.Shapes;
using Newtonsoft.Json;
using SaveData.FactoryFloor;
using UnityEngine;

namespace Logic.Factory.Blueprint
{
	[Serializable]
	public class BlueprintDto
	{
		public int Index = -1;

		public Color Color;

		public string BlueprintName;

		public Vector3Int Position { get; private set; }

		public int Rotation { get; private set; }

		public List<SavedObjectDto> Elements { get; private set; } = new List<SavedObjectDto>();

		public List<ShapeDto> RelatedShapes { get; private set; } = new List<ShapeDto>();

		[JsonConstructor]
		public BlueprintDto(Vector3Int position, int rot, List<SavedObjectDto> elements, List<ShapeDto> relatedShapes)
		{
			Position = position;
			Rotation = rot;
			Elements = elements;
			RelatedShapes = relatedShapes;
		}

		public BlueprintDto(Blueprint blueprint, string bpName, Color color, int index)
		{
			BlueprintName = bpName;
			Color = color;
			Index = index;
			RelatedShapes = CollectAllShapes(blueprint);
			Position = blueprint.Position;
			Rotation = blueprint.Rotation;
			foreach (BlueprintElement element in blueprint.Elements)
			{
				Elements.Add(new SavedObjectDto(element.RelativePositions[0], element.Rotation, element.Mirrored, nonChangable: true, element.ObjectData.ID, element.SoftLinkedToRelativePositions, element.HardLinkedToRelativePositions, element.Configurations, null));
			}
		}

		private List<ShapeDto> CollectAllShapes(Blueprint blueprint)
		{
			List<ShapeDto> list = new List<ShapeDto>();
			foreach (BlueprintElement element in blueprint.Elements)
			{
				if (element.Configurations == null)
				{
					continue;
				}
				foreach (BehaviourConfigurationDto configuration in element.Configurations)
				{
					foreach (ShapeDto allRelatedShape in configuration.GetAllRelatedShapes())
					{
						list.Add(allRelatedShape);
					}
				}
			}
			return list;
		}

		public Blueprint CopyToBlueprint(FactoryObjectDatabase factoryObjectDatabase)
		{
			List<BlueprintElement> list = new List<BlueprintElement>();
			foreach (SavedObjectDto element in Elements)
			{
				FactoryObjectData objectDataWithId = factoryObjectDatabase.GetObjectDataWithId(element.FactoryObjectDataId);
				list.Add(element.ToBlueprintElement(objectDataWithId));
			}
			return new Blueprint(Position, Rotation, list);
		}
	}
}
