using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Model.MapNew;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class GraveComponentManager : ComponentBaseManager<GraveComponent, GraveComponentInstance>
	{
		public GraveComponentManager(VillageMap map)
			: base(map)
		{
		}

		public List<WorldObject> GetGraveBuildingsPathfinding(Func<GraveComponentInstance, bool> condition = null)
		{
			List<WorldObject> list = new List<WorldObject>();
			KeyValuePair<WorldObject, GraveComponentInstance>[] array = WorldObjectComponentInstanceDictionary.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<WorldObject, GraveComponentInstance> keyValuePair = array[i];
				if (keyValuePair.Key == null || keyValuePair.Key.HasDisposed || keyValuePair.Value == null || keyValuePair.Value.HasDisposed)
				{
					continue;
				}
				if (condition != null)
				{
					if (condition(keyValuePair.Value))
					{
						list.Add(keyValuePair.Key);
					}
				}
				else
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		public bool DiggableGraveExists(Vec3Int gridPos)
		{
			if (PositionInstanceDictionary.TryGetValue(gridPos, out var value))
			{
				return value.Blueprint.Diggable;
			}
			return false;
		}

		public bool AvailableGravesExist()
		{
			return InstanceComponentDictionary.Keys.ToArray().Any((GraveComponentInstance grave) => grave.HasFreeSpace() && grave.OwnerBuilding.ConstructionPhase.Equals(ConstructionPhase.Finished));
		}

		public bool ValidGround(GraveComponentBlueprint grave, Vec3Int position, bool showMessage = false)
		{
			VoxelType voxelType = VillageManager.ActiveVillage.Map.GetNode(position)?.VoxelType;
			if (voxelType == null)
			{
				if (showMessage)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("default_error_space_not_buildable"));
				}
				return false;
			}
			foreach (string item in grave.ValidGround)
			{
				if (voxelType.GetID().Equals(item))
				{
					return true;
				}
			}
			if (showMessage)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("default_error_space_not_buildable"));
			}
			return false;
		}
	}
}
