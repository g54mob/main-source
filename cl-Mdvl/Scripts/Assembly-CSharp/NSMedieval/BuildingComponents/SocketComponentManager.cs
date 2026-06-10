using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class SocketComponentManager
	{
		private Dictionary<Vec3Int, SocketComponentInstance> positionInstance = new Dictionary<Vec3Int, SocketComponentInstance>();

		private Dictionary<SocketComponentInstance, SocketComponent> instanceComponent = new Dictionary<SocketComponentInstance, SocketComponent>();

		private Dictionary<WorldObject, SocketComponentInstance> worldObjectComponent = new Dictionary<WorldObject, SocketComponentInstance>();

		private VillageMap map;

		public SocketComponentManager(VillageMap map)
		{
			this.map = map;
		}

		public void Dispose()
		{
			positionInstance.Clear();
			positionInstance = null;
			instanceComponent.Clear();
			instanceComponent = null;
			worldObjectComponent.Clear();
			worldObjectComponent = null;
		}

		public SocketComponentInstance GetSocketComponentInstance(Vec3Int gridPos)
		{
			positionInstance.TryGetValue(gridPos, out var value);
			return value;
		}

		public SocketComponentInstance GetSocketComponentInstance(WorldObject worldObject)
		{
			if (worldObject == null)
			{
				return null;
			}
			worldObjectComponent.TryGetValue(worldObject, out var value);
			return value;
		}

		public void AddToCache(SocketComponent component, SocketComponentInstance componentInstance)
		{
			if (positionInstance.ContainsKey(componentInstance.GridDataPosition))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(104, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SocketComponent at position ");
					messageBuilder.AppendFormatted(componentInstance.GridDataPosition);
					messageBuilder.AppendLiteral(" has already been added to SocketComponentManager! This should never happen.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				positionInstance.Add(componentInstance.GridDataPosition, componentInstance);
				instanceComponent.Add(componentInstance, component);
				worldObjectComponent.Add(componentInstance.OwnerBuilding, componentInstance);
				VillageManager.ActiveVillage.WorldObjectStorage.ComponentInstances.Add(componentInstance);
			}
		}

		public void RemoveFromCache(SocketComponentInstance componentInstance)
		{
			if (componentInstance != null)
			{
				positionInstance.Remove(componentInstance.GridDataPosition);
				instanceComponent.Remove(componentInstance);
				worldObjectComponent.Remove(componentInstance.OwnerBuilding);
				VillageManager.ActiveVillage.WorldObjectStorage.ComponentInstances.Remove(componentInstance);
			}
		}
	}
}
