using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class LadderComponentManager : ComponentBaseManager<LadderComponent, LadderComponentInstance>
	{
		public LadderComponentManager(VillageMap map)
			: base(map)
		{
			Map.BuildingsManagerMain.BuildingDestroyedEvent += OnBuildingDestroyed;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnBuildingConstructed;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyed;
		}

		public override void Dispose()
		{
			Map.BuildingsManagerMain.BuildingDestroyedEvent -= OnBuildingDestroyed;
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnBuildingConstructed;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyed;
			}
			base.Dispose();
		}

		private void OnBuildingConstructed(BaseBuildingInstance baseBuildingInstance)
		{
			if (baseBuildingInstance.BuildingType == BuildingType.Floor)
			{
				RefreshLadderVisuals(baseBuildingInstance.GridDataPosition);
			}
		}

		private void OnBuildingDestroyed(BaseBuildingInstance baseBuildingInstance)
		{
			RefreshLadderVisuals(baseBuildingInstance.GridDataPosition);
		}

		private void OnGroundDestroyed(Vec3Int gridPos)
		{
			RefreshLadderVisuals(gridPos);
		}

		public void StairsConstructed(StairsComponentInstance stairsComponentInstance)
		{
			if (stairsComponentInstance != null && !stairsComponentInstance.HasDisposed)
			{
				Vec3Int frontPosition = stairsComponentInstance.FrontPosition;
				Vec3Int pos = new Vec3Int(frontPosition.x, frontPosition.y + 1, frontPosition.z);
				GetComponentInstance(pos)?.ShowFloor(showFloor: true);
			}
		}

		public void RefreshLadderVisuals(Vec3Int gridDataPosition)
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			pooledList.Add(gridDataPosition + Vec3Int.forward);
			pooledList.Add(gridDataPosition + Vec3Int.right);
			pooledList.Add(gridDataPosition + Vec3Int.back);
			pooledList.Add(gridDataPosition + Vec3Int.left);
			pooledList.Add(gridDataPosition);
			int count = pooledList.Count;
			for (int num = pooledList.Count - 1; num >= 0; num--)
			{
				bool isEnabled;
				if (num >= pooledList.Count)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(77, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("i >= allNeighbours.Count for ladder at ");
						messageBuilder.AppendFormatted(gridDataPosition);
						messageBuilder.AppendLiteral(" (count = ");
						messageBuilder.AppendFormatted(pooledList.Count);
						messageBuilder.AppendLiteral(", startCount = ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral("), iter start");
					}
					Log.Error(messageBuilder);
				}
				if (pooledList.Count != count)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(86, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("allNeighbours.Count != startCount for ladder at ");
						messageBuilder.AppendFormatted(gridDataPosition);
						messageBuilder.AppendLiteral(" (count = ");
						messageBuilder.AppendFormatted(pooledList.Count);
						messageBuilder.AppendLiteral(", startCount = ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral("), iter start");
					}
					Log.Error(messageBuilder);
				}
				RefreshLaddersVisuals(GetComponentInstance(pooledList[num]));
				if (pooledList.Count != count)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(89, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("allNeighbours.Count != startCount for ladder at ");
						messageBuilder.AppendFormatted(gridDataPosition);
						messageBuilder.AppendLiteral(" (count = ");
						messageBuilder.AppendFormatted(pooledList.Count);
						messageBuilder.AppendLiteral(", startCount = ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral("), after 1. call");
					}
					Log.Error(messageBuilder);
				}
				RefreshLaddersVisuals(GetComponentInstance(pooledList[num] + Vec3Int.down));
				if (pooledList.Count != count)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(89, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("allNeighbours.Count != startCount for ladder at ");
						messageBuilder.AppendFormatted(gridDataPosition);
						messageBuilder.AppendLiteral(" (count = ");
						messageBuilder.AppendFormatted(pooledList.Count);
						messageBuilder.AppendLiteral(", startCount = ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral("), after 2. call");
					}
					Log.Error(messageBuilder);
				}
				RefreshLaddersVisuals(GetComponentInstance(pooledList[num] + Vec3Int.up));
				if (pooledList.Count != count)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(89, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("allNeighbours.Count != startCount for ladder at ");
						messageBuilder.AppendFormatted(gridDataPosition);
						messageBuilder.AppendLiteral(" (count = ");
						messageBuilder.AppendFormatted(pooledList.Count);
						messageBuilder.AppendLiteral(", startCount = ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral("), after 3. call");
					}
					Log.Error(messageBuilder);
				}
			}
		}

		private void RefreshLaddersVisuals(LadderComponentInstance ladder)
		{
			if (ladder == null || ladder.HasDisposed || ladder.OwnerBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				return;
			}
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			int num = (int)Mathf.Repeat(ladder.Angle, 360f);
			Vec3Int a = ladder.Front;
			Vec3Int a2 = ladder.Back;
			Vec3Int a3 = ladder.GridDataPosition;
			switch (num)
			{
			case 0:
				pooledList.Add(a3 + Vec3Int.right);
				pooledList.Add(a3 + Vec3Int.back);
				pooledList.Add(a3 + Vec3Int.left);
				break;
			case 90:
				pooledList.Add(a3 + Vec3Int.forward);
				pooledList.Add(a3 + Vec3Int.back);
				pooledList.Add(a3 + Vec3Int.left);
				break;
			case 180:
				pooledList.Add(a3 + Vec3Int.forward);
				pooledList.Add(a3 + Vec3Int.right);
				pooledList.Add(a3 + Vec3Int.left);
				break;
			case 270:
				pooledList.Add(a3 + Vec3Int.forward);
				pooledList.Add(a3 + Vec3Int.right);
				pooledList.Add(a3 + Vec3Int.back);
				break;
			default:
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponentManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Weird angle for stairs ");
					messageBuilder.AppendFormatted(num);
				}
				Log.Warning(messageBuilder);
				break;
			}
			}
			bool showTop = false;
			foreach (Vec3Int item in pooledList)
			{
				Vec3Int a4 = item;
				if (Map.BuildingsManagerMain.GetByTypeAndPosition(BuildingType.Floor, a4 + Vec3Int.up, (BaseBuildingInstance x) => x.ConstructionPhase == ConstructionPhase.Finished) != null)
				{
					showTop = true;
					break;
				}
			}
			ladder.ShowTop(showTop);
			using PooledList<Vec3Int> pooledList2 = ListPool<Vec3Int>.GetJanitor();
			pooledList2.Add(a3 + Vec3Int.forward);
			pooledList2.Add(a3 + Vec3Int.right);
			pooledList2.Add(a3 + Vec3Int.back);
			pooledList2.Add(a3 + Vec3Int.left);
			bool showFloor = false;
			if (GetComponentInstance(ladder.GridDataPosition + Vec3Int.down) == null)
			{
				foreach (Vec3Int item2 in pooledList2)
				{
					if (Map.BuildingsManagerMain.GetByTypeAndPosition(BuildingType.Floor, item2, (BaseBuildingInstance x) => x.ConstructionPhase == ConstructionPhase.Finished) != null)
					{
						showFloor = true;
						break;
					}
				}
			}
			StairsComponentInstance[] array = Map.StairsComponentManager.InstanceComponent.Keys.ToArray();
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				Vec3Int frontPosition = array[num2].FrontPosition;
				if (new Vec3Int(frontPosition.x, frontPosition.y + 1, frontPosition.z) == a3)
				{
					showFloor = true;
					break;
				}
			}
			ladder.ShowFloor(showFloor);
			Vec3Int pos = a + Vec3Int.up;
			LadderComponentInstance componentInstance = GetComponentInstance(pos);
			if (componentInstance != null && !componentInstance.HasDisposed)
			{
				ladder.ShowFloor(showFloor: true);
			}
			Vec3Int pos2 = a2 + Vec3Int.down;
			LadderComponentInstance componentInstance2 = GetComponentInstance(pos2);
			if (componentInstance2 != null && !componentInstance2.HasDisposed)
			{
				ladder.ShowFloor(showFloor: true);
			}
			MapNode node = ladder.GetNode();
			if (node.DataType.HasFlag(GridDataType.DigMarkerResource) || node.DataType.HasFlag(GridDataType.DigMarkerResourceToMine))
			{
				ladder.ShowFloor(showFloor: false);
			}
			BaseBuildingInstance wallTypeBuildingWithVerticalStability = Map.BuildingsManagerMain.GetWallTypeBuildingWithVerticalStability(a);
			bool flag = MonoSingleton<GroundManager>.Instance.GroundExists(a);
			Vec3Int vec3Int = a3 + Vec3Int.down;
			BaseBuildingInstance wallTypeBuildingWithVerticalStability2 = Map.BuildingsManagerMain.GetWallTypeBuildingWithVerticalStability(vec3Int);
			bool flag2 = (wallTypeBuildingWithVerticalStability2 != null && wallTypeBuildingWithVerticalStability2.ConstructionPhase == ConstructionPhase.Finished) || MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int);
			ladder.ShowSupport(wallTypeBuildingWithVerticalStability == null && !flag && flag2);
			CheckLadderTop(ladder);
		}

		private void CheckLadderTop(LadderComponentInstance sourceLadder)
		{
			Queue<LadderComponentInstance> nodesInProgress = QueuePool<LadderComponentInstance>.Get();
			Queue<LadderComponentInstance> visitedNodes = QueuePool<LadderComponentInstance>.Get();
			visitedNodes.Enqueue(sourceLadder);
			VisitNodeNeighbours(sourceLadder);
			if (nodesInProgress.Count > 0)
			{
				sourceLadder.ShowTop(showTop: true);
			}
			while (nodesInProgress.Count > 0)
			{
				LadderComponentInstance ladderComponentInstance = nodesInProgress.Dequeue();
				if (!ladderComponentInstance.HasDisposed)
				{
					VisitNodeNeighbours(ladderComponentInstance);
					ladderComponentInstance.ShowTop(showTop: true);
				}
			}
			while (visitedNodes.Count > 0)
			{
				LadderComponentInstance ladderComponentInstance2 = visitedNodes.Dequeue();
				LadderComponentInstance componentInstance = GetComponentInstance(ladderComponentInstance2.GridDataPosition + Vec3Int.up);
				if (componentInstance != null && !componentInstance.HasDisposed && Math.Abs(ladderComponentInstance2.Angle) - Math.Abs(componentInstance.Angle) != 0f)
				{
					sourceLadder.ShowTop(showTop: true);
					CheckLadderTop(componentInstance);
				}
			}
			QueuePool<LadderComponentInstance>.Return(nodesInProgress);
			QueuePool<LadderComponentInstance>.Return(visitedNodes);
			void VisitNodeNeighbours(LadderComponentInstance source)
			{
				Vec3Int a = source.GridDataPosition;
				using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
				pooledList.Add(a + Vec3Int.forward);
				pooledList.Add(a + Vec3Int.right);
				pooledList.Add(a + Vec3Int.back);
				pooledList.Add(a + Vec3Int.left);
				foreach (Vec3Int item in pooledList)
				{
					LadderComponentInstance componentInstance2 = GetComponentInstance(item);
					if (componentInstance2 != null && !componentInstance2.HasDisposed && !visitedNodes.Contains(componentInstance2))
					{
						visitedNodes.Enqueue(componentInstance2);
						nodesInProgress.Enqueue(componentInstance2);
					}
				}
			}
		}
	}
}
