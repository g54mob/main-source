using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Village
{
	public static class WorldObjectTemporaryDataTypeSwitcher
	{
		public static GridDataType GetWorldObjectDataType(WorldObject instance)
		{
			switch (instance.Type)
			{
			case WorldObjectType.Building:
				return GetBuildingDataType(instance as BaseBuildingInstance);
			case WorldObjectType.Cropfield:
				return GridDataType.Cropfield;
			case WorldObjectType.MapResource:
				if (!(instance is PlantMapResourceInstance))
				{
					if (!(instance is DigMarkerResourceInstance))
					{
						if (instance is FishMapResourceInstance)
						{
							return GridDataType.FishMapResource;
						}
						Log.Error("Invalid world object MapResource type found in save: " + instance, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectTemporaryDataTypeSwitcher.cs");
						return GridDataType.None;
					}
					return GridDataType.DigMarkerResourceToMine;
				}
				return GridDataType.PlantMapResource;
			case WorldObjectType.ResourcePile:
				return GridDataType.ResourcePile;
			case WorldObjectType.Slope:
				return GridDataType.Slope;
			case WorldObjectType.Stockpile:
				return GridDataType.Stockpile;
			case WorldObjectType.PathfindingPoint:
				return GridDataType.PathfindingPoint;
			default:
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectTemporaryDataTypeSwitcher.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Invalid WorldObject type ");
					messageBuilder.AppendFormatted(instance.Type);
					messageBuilder.AppendLiteral(" for ");
					messageBuilder.AppendFormatted(instance);
				}
				Log.Error(messageBuilder);
				return GridDataType.None;
			}
			}
		}

		private static GridDataType GetBuildingDataType(BaseBuildingInstance instance)
		{
			GridDataType result = GridDataType.None;
			switch (instance.ConstructionPhase)
			{
			case ConstructionPhase.Blueprint:
				result = instance.Blueprint.ConstructableBaseCategory switch
				{
					ConstructableBaseCategory.Socket => GridDataType.SocketableBlueprint, 
					ConstructableBaseCategory.Beam => GridDataType.BeamBlueprint, 
					ConstructableBaseCategory.Building => (instance.BuildingType != BuildingType.FenceGate) ? GridDataType.BuildingBlueprint : GridDataType.OthersBlueprint, 
					ConstructableBaseCategory.Furniture => instance.Blueprint.FloorDecoration ? GridDataType.RugBlueprint : GridDataType.OthersBlueprint, 
					ConstructableBaseCategory.ProductionBuilding => GridDataType.OthersBlueprint, 
					ConstructableBaseCategory.Stairs => GridDataType.OthersBlueprint, 
					ConstructableBaseCategory.Roof => GridDataType.BuildingBlueprint, 
					ConstructableBaseCategory.Trap => GridDataType.OthersBlueprint, 
					ConstructableBaseCategory.Grave => GridDataType.OthersBlueprint, 
					ConstructableBaseCategory.Decoration => (instance.Blueprint.BuildingType == BuildingType.Rug) ? GridDataType.RugBlueprint : GridDataType.OthersBlueprint, 
					_ => GridDataType.OthersBlueprint, 
				};
				break;
			case ConstructionPhase.Foundation:
				result = instance.Blueprint.ConstructableBaseCategory switch
				{
					ConstructableBaseCategory.Socket => GridDataType.SocketableUnfinished, 
					ConstructableBaseCategory.Beam => GridDataType.BeamUnfinished, 
					ConstructableBaseCategory.Building => (instance.BuildingType != BuildingType.FenceGate) ? GridDataType.BuildingUnfinished : GridDataType.OthersUnfinished, 
					ConstructableBaseCategory.Furniture => instance.Blueprint.FloorDecoration ? GridDataType.RugFoundation : GridDataType.OthersUnfinished, 
					ConstructableBaseCategory.Roof => GridDataType.BuildingUnfinished, 
					ConstructableBaseCategory.Trap => GridDataType.OthersUnfinished, 
					ConstructableBaseCategory.ProductionBuilding => GridDataType.OthersUnfinished, 
					ConstructableBaseCategory.Decoration => (instance.Blueprint.BuildingType == BuildingType.Rug) ? GridDataType.RugFoundation : GridDataType.OthersUnfinished, 
					_ => GridDataType.OthersUnfinished, 
				};
				break;
			case ConstructionPhase.Finished:
				switch (instance.Blueprint.ConstructableBaseCategory)
				{
				case ConstructableBaseCategory.Socket:
					result = GridDataType.SocketableItem;
					break;
				case ConstructableBaseCategory.Beam:
					result = GridDataType.BeamFinished;
					break;
				case ConstructableBaseCategory.Building:
					result = ((instance.BuildingType != BuildingType.FenceGate) ? GridDataType.BuildingFinished : GridDataType.FurnitureGate);
					break;
				case ConstructableBaseCategory.Furniture:
					result = (instance.Blueprint.FloorDecoration ? GridDataType.RugFinished : GridDataType.Furniture);
					break;
				case ConstructableBaseCategory.ProductionBuilding:
					result = GridDataType.ProductionBuilding;
					break;
				case ConstructableBaseCategory.Stairs:
					result = GridDataType.Stairs;
					break;
				case ConstructableBaseCategory.Roof:
					result = GridDataType.Roof;
					break;
				case ConstructableBaseCategory.Trap:
					result = GridDataType.Trap;
					break;
				case ConstructableBaseCategory.Grave:
					result = GridDataType.Grave;
					break;
				case ConstructableBaseCategory.Decoration:
					result = ((instance.Blueprint.BuildingType == BuildingType.Rug) ? GridDataType.RugFinished : GridDataType.Furniture);
					break;
				case ConstructableBaseCategory.Siege:
					result = GridDataType.Furniture;
					break;
				default:
					Debug.LogError("Invalid switch here! " + instance);
					break;
				}
				break;
			}
			return result;
		}
	}
}
