using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobConnectTiles : IJob
	{
		public GCHandle tiles;

		public int coordinateSum;

		public int direction;

		public int zOffset;

		public int zStride;

		private Vector2 tileWorldSize;

		private IntRect tileRect;

		public float maxTileConnectionEdgeDistance;

		private static readonly ProfilerMarker ConnectTilesMarker = new ProfilerMarker("ConnectTiles");

		public static JobHandle ScheduleBatch(GCHandle tilesHandle, JobHandle dependency, IntRect tileRect, Vector2 tileWorldSize, float maxTileConnectionEdgeDistance)
		{
			int num = Mathf.Max(1, JobsUtility.JobWorkerCount);
			NativeArray<JobHandle> jobs = new NativeArray<JobHandle>(num, Allocator.Temp);
			for (int i = 0; i <= 1; i++)
			{
				for (int j = 0; j <= 1; j++)
				{
					for (int k = 0; k < num; k++)
					{
						jobs[k] = new JobConnectTiles
						{
							tiles = tilesHandle,
							tileRect = tileRect,
							tileWorldSize = tileWorldSize,
							coordinateSum = i,
							direction = j,
							maxTileConnectionEdgeDistance = maxTileConnectionEdgeDistance,
							zOffset = k,
							zStride = num
						}.Schedule(dependency);
					}
					dependency = JobHandle.CombineDependencies(jobs);
				}
			}
			return dependency;
		}

		public static JobHandle ScheduleRecalculateBorders(GCHandle tilesHandle, JobHandle dependency, IntRect tileRect, IntRect innerRect, Vector2 tileWorldSize, float maxTileConnectionEdgeDistance)
		{
			int width = innerRect.Width;
			int height = innerRect.Height;
			NativeArray<JobHandle> jobs = new NativeArray<JobHandle>(2 * width + 2 * math.max(0, height - 2), Allocator.Temp);
			int num = 0;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (j != 0 && i != 0 && j != width - 1 && i != height - 1)
					{
						continue;
					}
					int num2 = innerRect.xmin + j;
					int num3 = innerRect.ymin + i;
					JobHandle jobHandle = dependency;
					for (int k = 0; k < 4; k++)
					{
						int num4 = num2 + k switch
						{
							1 => -1, 
							0 => 1, 
							_ => 0, 
						};
						int num5 = num3 + k switch
						{
							3 => -1, 
							2 => 1, 
							_ => 0, 
						};
						if (!innerRect.Contains(num4, num5) && tileRect.Contains(num4, num5))
						{
							jobHandle = new JobConnectTilesSingle
							{
								tiles = tilesHandle,
								tileIndex1 = num2 + num3 * tileRect.Width,
								tileIndex2 = num4 + num5 * tileRect.Width,
								tileWorldSize = tileWorldSize,
								maxTileConnectionEdgeDistance = maxTileConnectionEdgeDistance
							}.Schedule(jobHandle);
						}
					}
					jobs[num++] = jobHandle;
				}
			}
			return JobHandle.CombineDependencies(jobs);
		}

		public void Execute()
		{
			NavmeshTile[] array = (NavmeshTile[])tiles.Target;
			int height = tileRect.Height;
			int width = tileRect.Width;
			for (int i = zOffset; i < height; i += zStride)
			{
				for (int j = 0; j < width; j++)
				{
					if ((j + i) % 2 != coordinateSum)
					{
						continue;
					}
					int num = j + i * width;
					int num2;
					if (direction == 0 && j < width - 1)
					{
						num2 = j + 1 + i * width;
					}
					else
					{
						if (direction != 1 || i >= height - 1)
						{
							continue;
						}
						num2 = j + (i + 1) * width;
					}
					NavmeshBase.ConnectTiles(array[num], array[num2], tileWorldSize.x, tileWorldSize.y, maxTileConnectionEdgeDistance);
				}
			}
		}
	}
}
