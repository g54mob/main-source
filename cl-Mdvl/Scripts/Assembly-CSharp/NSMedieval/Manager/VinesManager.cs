using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Terrain;
using NSMedieval.Views.Resources;
using NSMedieval.Village.Map;

namespace NSMedieval.Manager
{
	public class VinesManager
	{
		private VillageMap map;

		private Dictionary<Vec3Int, VineView> positionView = new Dictionary<Vec3Int, VineView>();

		public VinesManager(VillageMap map)
		{
			this.map = map;
			MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnBuildingDestroyed;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnSingleGroundDestroyed;
			MonoSingleton<GroundController>.Instance.VoxelAddedEvent += OnVoxelAdded;
		}

		public void Dispose()
		{
			map = null;
			positionView.Clear();
			positionView = null;
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnBuildingDestroyed;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnSingleGroundDestroyed;
				MonoSingleton<GroundController>.Instance.VoxelAddedEvent -= OnVoxelAdded;
			}
		}

		public void Cache(Vec3Int position, VineView vineView)
		{
			if (!positionView.TryAdd(position, vineView))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\VinesManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Position ");
					messageBuilder.AppendFormatted(position);
					messageBuilder.AppendLiteral(" is already cached in VinesManager!");
				}
				Log.Warning(messageBuilder);
			}
		}

		public void RemoveFromCache(Vec3Int position)
		{
			if (!positionView.Remove(position))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\VinesManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Position ");
					messageBuilder.AppendFormatted(position);
					messageBuilder.AppendLiteral(" is not found in VinesManager cache!");
				}
				Log.Warning(messageBuilder);
			}
		}

		private void OnBuildingDestroyed(BaseBuildingInstance building)
		{
			CheckForBuildingRefresh(building);
		}

		private void OnConstructionCompleted(BaseBuildingInstance building)
		{
			CheckForBuildingRefresh(building);
		}

		private void CheckForBuildingRefresh(BaseBuildingInstance building)
		{
			if (building.BuildingType == BuildingType.Wall)
			{
				RefreshNeighbours(building.GridDataPosition);
				RefreshNeighbours(building.GridDataPosition + Vec3Int.up);
			}
		}

		private void OnVoxelAdded(BaseBuildingInstance building)
		{
			RefreshNeighbours(building.GridDataPosition);
			RefreshNeighbours(building.GridDataPosition + Vec3Int.up);
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			foreach (Vec3Int position in positions)
			{
				Vec3Int a = position;
				RefreshNeighbours(a);
				RefreshNeighbours(a + Vec3Int.up);
			}
		}

		private void OnSingleGroundDestroyed(Vec3Int gridPos)
		{
			RefreshNeighbours(gridPos);
			RefreshNeighbours(gridPos + Vec3Int.up);
		}

		private void RefreshNeighbours(Vec3Int gridPos)
		{
			foreach (Vec3Int item in gridPos.ForEachSuroundingPosXZ())
			{
				if (positionView.TryGetValue(item, out var value))
				{
					value.RefreshVines();
				}
			}
		}
	}
}
