using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.Serialization
{
	public class MigrationManager : MonoSingleton<MigrationManager>
	{
		public struct SocketMigrationHelper
		{
			public Vec3Int AttachedToPosition;

			public ObjectSide ObjectSide;

			public SocketMigrationHelper(Vec3Int pos, ObjectSide side)
			{
				AttachedToPosition = pos;
				ObjectSide = side;
			}
		}

		private List<BaseBuildingInstance> buildings = new List<BaseBuildingInstance>();

		private List<BaseComponentInstance> components = new List<BaseComponentInstance>();

		private Dictionary<Vec3Int, SocketComponentInstance> socketComponents = new Dictionary<Vec3Int, SocketComponentInstance>();

		private Dictionary<BaseBuildingInstance, SocketMigrationHelper> sockets = new Dictionary<BaseBuildingInstance, SocketMigrationHelper>();

		private List<BaseBuildingInstance> beamsToSetup = new List<BaseBuildingInstance>();

		private Dictionary<Vec3Int, BaseBuildingInstance> buildingsByPosition = new Dictionary<Vec3Int, BaseBuildingInstance>();

		public List<BaseBuildingInstance> BeamsToSetup => beamsToSetup;

		public List<BaseBuildingInstance> GetBuildings()
		{
			return buildings;
		}

		public List<BaseComponentInstance> GetComponents()
		{
			return components;
		}

		public Dictionary<Vec3Int, SocketComponentInstance> GetSocketComponents()
		{
			return socketComponents;
		}

		public Dictionary<BaseBuildingInstance, SocketMigrationHelper> GetSockets()
		{
			return sockets;
		}

		public void ClearBuildingData()
		{
			buildings.Clear();
			components.Clear();
			sockets.Clear();
			socketComponents.Clear();
			buildingsByPosition.Clear();
		}

		public void MigrateBuilding(FVDeserializer deserializer, IFVSerializable oldObject)
		{
			if (deserializer.ReadString("blueprintId") == null)
			{
				Debug.LogError("Blueprint ID is missing! Skipping object " + oldObject.GetType().Name + ".");
				return;
			}
			BaseBuildingInstance baseBuildingInstance = new BaseBuildingInstance(deserializer);
			if (buildingsByPosition.TryGetValue(baseBuildingInstance.GridDataPosition, out var value) && baseBuildingInstance.BuildingType == value.BuildingType && baseBuildingInstance.BlueprintId.Equals(value.BlueprintId))
			{
				deserializer.AddMigratedObject(oldObject, value);
				Debug.LogError($"Migration skipping building {baseBuildingInstance.BlueprintId} {baseBuildingInstance.UniqueId}. Duplicate of {value.BlueprintId} {value.UniqueId} detected");
				return;
			}
			buildings.Add(baseBuildingInstance);
			buildingsByPosition.TryAdd(baseBuildingInstance.GridDataPosition, baseBuildingInstance);
			baseBuildingInstance.SetMaxHealth();
			deserializer.AddTempData("uniqueId", baseBuildingInstance.UniqueId);
			if (baseBuildingInstance.Blueprint.BuildingType == BuildingType.Wall || baseBuildingInstance.Blueprint.BuildingType == BuildingType.Voxel)
			{
				SocketComponentInstance socketComponentInstance = new SocketComponentInstance(deserializer);
				components.Add(socketComponentInstance);
				socketComponents.Add(baseBuildingInstance.GridDataPosition.ToVec3IntWorld(), socketComponentInstance);
				deserializer.ClearTempData();
				deserializer.AddMigratedObject(oldObject, baseBuildingInstance);
				return;
			}
			if (baseBuildingInstance.Blueprint.PlacementType == PlacementType.WallSocket)
			{
				if (baseBuildingInstance.Blueprint.BuildingType == BuildingType.Beam)
				{
					beamsToSetup.Add(baseBuildingInstance);
				}
				else
				{
					Vec3Int lhs = deserializer.ReadVec3Int("attachedToPosition", Vec3Int.zero);
					ObjectSide side = deserializer.ReadEnum("socket", (ObjectSide)0);
					if (lhs != Vec3Int.zero)
					{
						sockets.Add(baseBuildingInstance, new SocketMigrationHelper(lhs, side));
					}
				}
			}
			if (!string.IsNullOrEmpty(baseBuildingInstance.Blueprint.FuelConsumerComponentID))
			{
				FuelConsumerComponentInstance item = new FuelConsumerComponentInstance(Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(baseBuildingInstance.Blueprint.FuelConsumerComponentID), baseBuildingInstance.UniqueId);
				components.Add(item);
			}
			TryAddComponent(baseBuildingInstance.Blueprint.BeamComponentID, deserializer, (FVDeserializer d) => new BeamComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.BedComponentID, deserializer, (FVDeserializer d) => new BedComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.CaravanPostComponentID, deserializer, (FVDeserializer d) => new CaravanPostComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.ChairComponentID, deserializer, (FVDeserializer d) => new ChairComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.DecorationComponentID, deserializer, (FVDeserializer d) => new DecorationComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.DoorComponentID, deserializer, (FVDeserializer d) => new DoorComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.EntertainmentComponentID, deserializer, (FVDeserializer d) => new EntertainmentComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.GraveComponentID, deserializer, (FVDeserializer d) => new GraveComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.LadderComponentID, deserializer, (FVDeserializer d) => new LadderComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.MapTableComponentID, deserializer, (FVDeserializer d) => new MapTableComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.PenMarkerComponentID, deserializer, (FVDeserializer d) => new PenMarkerComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.ProductionComponentID, deserializer, (FVDeserializer d) => new ProductionComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.RoofComponentID, deserializer, (FVDeserializer d) => new RoofComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.RugComponentID, deserializer, (FVDeserializer d) => new RugComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.ShelfComponentID, deserializer, (FVDeserializer d) => new ShelfComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.ShrineComponentID, deserializer, (FVDeserializer d) => new ShrineComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.SignComponentID, deserializer, (FVDeserializer d) => new SignComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.StairComponentID, deserializer, (FVDeserializer d) => new StairsComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.TableComponentID, deserializer, (FVDeserializer d) => new TableComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.TradingPostComponentID, deserializer, (FVDeserializer d) => new TradingPostComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.TrapComponentID, deserializer, (FVDeserializer d) => new TrapComponentInstance(deserializer));
			TryAddComponent(baseBuildingInstance.Blueprint.WindowComponentID, deserializer, (FVDeserializer d) => new WindowComponentInstance(deserializer));
			deserializer.ClearTempData();
			deserializer.AddMigratedObject(oldObject, baseBuildingInstance);
		}

		private void TryAddComponent<T>(string componentID, FVDeserializer deserializer, Func<FVDeserializer, T> constructor) where T : class
		{
			if (!string.IsNullOrEmpty(componentID))
			{
				deserializer.ReplaceOrAddTempData("componentBlueprintID", componentID);
				T val = constructor(deserializer);
				components.Add(val as BaseComponentInstance);
			}
		}

		private void TryAddComponent<T>(FVDeserializer deserializer, Func<FVDeserializer, T> constructor) where T : class
		{
			T val = constructor(deserializer);
			components.Add(val as BaseComponentInstance);
		}
	}
}
