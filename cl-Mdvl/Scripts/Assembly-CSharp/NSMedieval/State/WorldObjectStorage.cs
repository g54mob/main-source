using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Extensions;
using NSMedieval.Serialization;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("WorldObjectStorage", "")]
	public class WorldObjectStorage : ISerializationCallbackReceiver, IFVSerializable
	{
		[SerializeField]
		private ConcurrentHashSet<WorldObject> worldObjects = new ConcurrentHashSet<WorldObject>();

		[SerializeField]
		private ConcurrentHashSet<BaseComponentInstance> componentInstances = new ConcurrentHashSet<BaseComponentInstance>();

		[NonSerialized]
		private Dictionary<int, WorldObject> worldObjectsByUniqueId = new Dictionary<int, WorldObject>();

		[NonSerialized]
		private Dictionary<int, BaseComponentInstance> baseComponentsByUniqueId = new Dictionary<int, BaseComponentInstance>();

		public ConcurrentHashSet<WorldObject> WorldObjects => worldObjects;

		public ConcurrentHashSet<BaseComponentInstance> ComponentInstances => componentInstances;

		public Dictionary<int, BaseComponentInstance> BaseComponentsByUniqueId => baseComponentsByUniqueId;

		public WorldObject GetWorldObjectByUniqueId(int id)
		{
			if (worldObjectsByUniqueId.ContainsKey(id))
			{
				return worldObjectsByUniqueId[id];
			}
			return null;
		}

		public BaseComponentInstance GetBaseComponentInstanceByUniqueId(int id)
		{
			if (baseComponentsByUniqueId == null)
			{
				baseComponentsByUniqueId = new Dictionary<int, BaseComponentInstance>();
			}
			if (baseComponentsByUniqueId.TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		public WorldObjectStorage()
		{
		}

		public void SynchronizeWorldData()
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (WorldObject worldObject in WorldObjects)
			{
				if (worldObject != null)
				{
					map.AddToTheWorld(worldObject, isSilent: true);
				}
			}
		}

		public void OnBeforeSerialize()
		{
			if (VillageManager.ActiveVillage?.Map?.NodesHolder?.GridData == null)
			{
				Log.Warning("WorldObjectStorage data not found!", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(9, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(VillageManager.ActiveVillage);
					messageBuilder.AppendLiteral(" | ");
					messageBuilder.AppendFormatted(VillageManager.ActiveVillage?.Map);
					messageBuilder.AppendLiteral(" | ");
					messageBuilder.AppendFormatted(VillageManager.ActiveVillage?.Map?.NodesHolder);
					messageBuilder.AppendLiteral(" | ");
					messageBuilder.AppendFormatted(VillageManager.ActiveVillage?.Map?.NodesHolder?.GridData);
				}
				Log.Warning(messageBuilder);
			}
		}

		public void OnAfterDeserialize()
		{
			Dictionary<string, int> removedCounts = new Dictionary<string, int>();
			WorldObjects.RemoveWhere(delegate(WorldObject item)
			{
				if (!item.BlueprintExists)
				{
					string name = item.GetType().Name;
					removedCounts.TryAdd(name, 0);
					removedCounts[name]++;
					return true;
				}
				return false;
			});
			bool isEnabled;
			if (removedCounts.Count > 0)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(94, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ignored invalid WorldObjects during loading because they didn't have an existing blueprintId: ");
					messageBuilder.AppendFormatted(removedCounts.ToPrettyString());
				}
				Log.Error(messageBuilder);
			}
			int num = WorldObjects.RemoveWhere((WorldObject item) => item.HasDisposed);
			if (num > 0)
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Removed  ");
					messageBuilder2.AppendFormatted(num);
					messageBuilder2.AppendLiteral(" WorldObjects during loading because HasDisposed was true.");
				}
				Log.Warning(messageBuilder2);
			}
			MigrateBuildings();
			SyncWorldObjects();
			SyncBuildingComponents();
			removedCounts.Clear();
			foreach (WorldObject worldObject in WorldObjects)
			{
				if (!(worldObject is BaseBuildingInstance baseBuildingInstance) || worldObject.GetUniqueId() == 0 || string.IsNullOrEmpty(baseBuildingInstance.Blueprint.ProductionComponentID) || !(GetBaseComponentInstanceByUniqueId(baseBuildingInstance.UniqueId) is ProductionComponentInstance { HasProductionSystemInstance: not false } productionComponentInstance))
				{
					continue;
				}
				foreach (ProductionInstance item in productionComponentInstance.ProductionSystemInstance.Productions.IterateInReverseDynamic())
				{
					if (!(item.Blueprint != null))
					{
						productionComponentInstance.ProductionSystemInstance.Productions.Remove(item);
						removedCounts.TryAdd(item.BlueprintId, 1);
						removedCounts[item.BlueprintId]++;
					}
				}
			}
			if (removedCounts.Count > 0)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(102, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ignored invalid production instances during loading because they didn't have an existing blueprintId: ");
					messageBuilder.AppendFormatted(removedCounts.ToPrettyString());
				}
				Log.Error(messageBuilder);
			}
		}

		private void SyncWorldObjects()
		{
			if (worldObjectsByUniqueId == null)
			{
				worldObjectsByUniqueId = new Dictionary<int, WorldObject>();
			}
			worldObjectsByUniqueId.Clear();
			foreach (WorldObject worldObject in WorldObjects)
			{
				if (worldObject.GetUniqueId() != 0 && !worldObjectsByUniqueId.ContainsKey(worldObject.UniqueId))
				{
					worldObjectsByUniqueId.Add(worldObject.UniqueId, worldObject);
				}
			}
		}

		private void SyncBuildingComponents()
		{
			if (baseComponentsByUniqueId == null)
			{
				baseComponentsByUniqueId = new Dictionary<int, BaseComponentInstance>();
			}
			baseComponentsByUniqueId.Clear();
			foreach (BaseComponentInstance componentInstance in componentInstances)
			{
				if (!baseComponentsByUniqueId.TryAdd(componentInstance.UniqueID, componentInstance))
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Cannot add component to dictionary with unique ID: ");
						messageBuilder.AppendFormatted(componentInstance.UniqueID);
					}
					Log.Warning(messageBuilder);
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.ChangeWriter("WorldObjects.bin");
			serializer.Write("componentInstances", componentInstances);
			serializer.Write("worldObjects", worldObjects);
			serializer.PopBackWriter();
		}

		public WorldObjectStorage(FVDeserializer deserializer)
		{
			deserializer.ChangeReader("WorldObjects.bin");
			componentInstances = deserializer.ReadObjectConcurrentHashSet("componentInstances", componentInstances);
			worldObjects = deserializer.ReadObjectConcurrentHashSet<WorldObject>("worldObjects");
			deserializer.PopBackReader();
			OnAfterDeserialize();
		}

		private void MigrateBuildings()
		{
			List<BaseBuildingInstance> buildings = MonoSingleton<MigrationManager>.Instance.GetBuildings();
			if (buildings == null || buildings.Count == 0)
			{
				return;
			}
			List<BaseComponentInstance> components = MonoSingleton<MigrationManager>.Instance.GetComponents();
			Dictionary<Vec3Int, SocketComponentInstance> socketComponents = MonoSingleton<MigrationManager>.Instance.GetSocketComponents();
			Dictionary<BaseBuildingInstance, MigrationManager.SocketMigrationHelper> sockets = MonoSingleton<MigrationManager>.Instance.GetSockets();
			foreach (BaseBuildingInstance item in buildings)
			{
				WorldObjects.Add(item);
				if (sockets.ContainsKey(item))
				{
					Vec3Int attachedToPosition = sockets[item].AttachedToPosition;
					if (socketComponents.ContainsKey(attachedToPosition))
					{
						socketComponents[attachedToPosition].AttachToSocketMigration(item, sockets[item].ObjectSide);
					}
				}
			}
			foreach (BaseComponentInstance item2 in components)
			{
				componentInstances.Add(item2);
			}
			WorldObjects.RemoveWhere((WorldObject item) => item == null);
			WorldObjects.RemoveWhere((WorldObject item) => item is IFVMigrated);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(70, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObjectStorage.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Building Migration Success! Migrated ");
				messageBuilder.AppendFormatted(buildings.Count);
				messageBuilder.AppendLiteral(" buildings and added ");
				messageBuilder.AppendFormatted(components.Count);
				messageBuilder.AppendLiteral(" components.");
			}
			Log.Info(messageBuilder);
			MonoSingleton<MigrationManager>.Instance.ClearBuildingData();
		}
	}
}
