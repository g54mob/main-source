using System;
using System.Diagnostics;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Fire;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.State.Timers;
using NSMedieval.Tools;
using NSMedieval.Types;
using Unity.Collections;

namespace NSMedieval.Village.Map
{
	public class AirFloodfillManager : IDisposable
	{
		private static NativeArray<byte> tempData;

		private static NativeArray<int> floodfillNodeIds;

		private VillageMap map;

		private int dataLength;

		private readonly object lockObject = new object();

		private readonly Stopwatch airFloodfillStopwatch;

		private BaseTimer scheduleTimer;

		private ThreadingJobSystem.ThreadedTaskData floodfillThreadTask;

		private bool threadStarted;

		public static void InitStaticArrays()
		{
			tempData = ArrayStorage.GetNativeArray<byte>("AirFloodfillManager.tempData", GridDataIndexTools.MaxDataLength);
			floodfillNodeIds = ArrayStorage.GetNativeArray<int>("AirFloodfillManager.floodfillNodeIds", GridDataIndexTools.MaxDataLength);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(tempData, dataLength);
			ArrayStorage.ClearNativeArray(floodfillNodeIds, dataLength);
		}

		public AirFloodfillManager(VillageMap map)
		{
			this.map = map;
			Vec3Int size = map.Size;
			dataLength = size.x * size.y * size.z;
			InitStaticArrays();
			ClearStaticArrays();
			airFloodfillStopwatch = new Stopwatch();
			scheduleTimer = new UnscaledTimer(0.05f, restartOnEnd: false);
			scheduleTimer.AddCallback(StartFlow);
			scheduleTimer.Pause();
		}

		public void ScheduleFloodfill()
		{
			if (scheduleTimer != null)
			{
				scheduleTimer.RestartTimer();
				if (scheduleTimer.Paused)
				{
					scheduleTimer.Resume();
				}
			}
		}

		public void Dispose()
		{
			scheduleTimer?.Dispose();
			scheduleTimer = null;
			map = null;
			airFloodfillStopwatch.Stop();
			floodfillThreadTask = null;
		}

		private void StartFlow()
		{
			if (!threadStarted)
			{
				threadStarted = true;
				floodfillThreadTask = MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(delegate
				{
					FlowThread();
					return true;
				}, FlowFinishedMainThread);
			}
		}

		private void FlowFinishedMainThread(bool result)
		{
			threadStarted = false;
		}

		private void FlowThread()
		{
			lock (lockObject)
			{
				TemperatureManager temperatureManager = map.TemperatureManager;
				airFloodfillStopwatch.Restart();
				MapNode[] gridSpaceData = map.GridSpaceData;
				int num = gridSpaceData.Length;
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					MapNode mapNode = gridSpaceData[i];
					byte b = (tempData[i] = (byte)((mapNode.VoxelType != null) ? 4u : 0u));
					if (b == 4)
					{
						tempData[i] |= 1;
					}
					else
					{
						if (mapNode.Coverage != CoverageType.Outside)
						{
							continue;
						}
						tempData[i] |= 1;
						if ((mapNode.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.Wall)) == 0)
						{
							tempData[i] |= 2;
							if (mapNode.IsWalkable)
							{
								floodfillNodeIds[num2] = i;
								num2++;
							}
						}
					}
				}
				Heightmap instance = MonoSingleton<Heightmap>.Instance;
				for (int j = 0; j < num2; j++)
				{
					int num3 = floodfillNodeIds[j];
					MapNode mapNode2 = gridSpaceData[num3];
					Vec3Int[] neighbors3DNonDiagonal = MapNodeUtils.Neighbors3DNonDiagonal;
					for (int k = 0; k < neighbors3DNonDiagonal.Length; k++)
					{
						Vec3Int b3 = neighbors3DNonDiagonal[k];
						MapNode node = map.GetNode(mapNode2.Position + b3);
						if (node == null)
						{
							continue;
						}
						int index = node.Index;
						if ((tempData[index] & 5) == 0)
						{
							if ((node.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.Wall)) != MapNodeTags.None && (node.Tag & MapNodeTags.OpenWindow) == 0)
							{
								tempData[index] = 1;
							}
							else if ((b3.y <= 0 || ((node.Tag & MapNodeTags.Floor) == 0 && (node.DataType & GridDataType.Roof) == 0)) && (b3.y >= 0 || ((mapNode2.Tag & MapNodeTags.Floor) == 0 && (mapNode2.DataType & GridDataType.Roof) == 0)) && node.Position.y <= instance.HeightmapMaxNeighbors[node.Position.x, node.Position.z])
							{
								tempData[index] |= 3;
								floodfillNodeIds[num2] = index;
								num2++;
							}
						}
					}
				}
				for (int l = 0; l < num; l++)
				{
					temperatureManager.SetOutsideAir(l, (tempData[l] & 2) != 0 && (tempData[l] & 4) == 0);
				}
				airFloodfillStopwatch.Stop();
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Temperature\\AirFloodfillManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Air flow done in: ");
					messageBuilder.AppendFormatted(airFloodfillStopwatch.Elapsed.TotalMilliseconds);
					messageBuilder.AppendLiteral(" ms");
				}
				Log.Info(messageBuilder);
			}
		}
	}
}
