using System.Collections.Generic;
using NSEipix;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Water
{
	public class WaterfallDetection
	{
		private const float WaterfallDetectionThresholdLevel = 0.5f;

		private readonly HashSet<int> waterfallsListHashes = new HashSet<int>();

		private readonly WaterSimLogic waterSimLogic;

		public HashSet<Waterfall> AddedWaterfalls { get; } = new HashSet<Waterfall>();

		public HashSet<Waterfall> RemovedWaterfalls { get; } = new HashSet<Waterfall>();

		public List<Waterfall> WaterfallsList { get; } = new List<Waterfall>();

		public WaterfallDetection(WaterSimLogic waterSimLogic)
		{
			this.waterSimLogic = waterSimLogic;
		}

		public void TickWaterfallsForAudioSystem()
		{
			AddedWaterfalls.Clear();
			RemovedWaterfalls.Clear();
			HashSet<int> hashSet = HashSetPool<int>.Get();
			HashSet<int> hashSet2 = HashSetPool<int>.Get();
			HashSet<int> hashSet3 = HashSetPool<int>.Get();
			HashSet<int> hashSet4 = HashSetPool<int>.Get();
			HashSet<int> hashSet5 = HashSetPool<int>.Get();
			Queue<int> queue = QueuePool<int>.Get();
			int num = waterSimLogic.DataLength - 1;
			for (int num2 = num; num2 >= 0; num2--)
			{
				if (waterSimLogic.WaterDataDisplay[num2] >= 0.5f)
				{
					int x = GridDataIndexTools.GetX(num2);
					int y = GridDataIndexTools.GetY(num2);
					int z = GridDataIndexTools.GetZ(num2);
					if (WaterSimLogic.SearchEachNeighbor(x, y, z, (int nx, int ny, int nz, int index) => waterSimLogic.WaterDataDisplay[index] < 0.5f && waterSimLogic.ObstacleData[index] == 0))
					{
						hashSet.Add(num2);
					}
				}
			}
			for (int num3 = num; num3 >= 0; num3--)
			{
				if (waterSimLogic.ObstacleData[num3] != 1 && !(waterSimLogic.WaterDataDisplay[num3] < 0.5f) && hashSet.Contains(num3) && !hashSet2.Contains(num3))
				{
					SearchWaterfallForAudio(num3, queue, hashSet2, hashSet4, searchXorZAxis: true);
					SearchWaterfallForAudio(num3, queue, hashSet2, hashSet5, searchXorZAxis: false);
					if (hashSet4.Count != 0 || hashSet5.Count != 0)
					{
						HashSet<int> hashSet6 = ((hashSet4.Count > hashSet5.Count) ? hashSet4 : hashSet5);
						int item = Waterfall.CalculateHash(hashSet6);
						hashSet3.Add(item);
						hashSet2.UnionWith(hashSet6);
						if (!waterfallsListHashes.Contains(item))
						{
							Waterfall item2 = new Waterfall(hashSet6);
							WaterfallsList.Add(item2);
							waterfallsListHashes.Add(item);
							AddedWaterfalls.Add(item2);
						}
					}
				}
			}
			foreach (Waterfall item3 in WaterfallsList.IterateInReverseDynamic())
			{
				if (!hashSet3.Contains(item3.NodesHash))
				{
					WaterfallsList.Remove(item3);
					waterfallsListHashes.Remove(item3.NodesHash);
					RemovedWaterfalls.Add(item3);
				}
			}
			HashSetPool<int>.Return(hashSet);
			HashSetPool<int>.Return(hashSet2);
			HashSetPool<int>.Return(hashSet4);
			HashSetPool<int>.Return(hashSet5);
			HashSetPool<int>.Return(hashSet3);
			QueuePool<int>.Return(queue);
		}

		public void DrawGizmos()
		{
		}

		private void SearchWaterfallForAudio(int startIndex, Queue<int> queue, HashSet<int> processed, HashSet<int> lastArea, bool searchXorZAxis)
		{
			lastArea.Clear();
			lastArea.Add(startIndex);
			queue.Clear();
			queue.Enqueue(startIndex);
			while (queue.Count > 0)
			{
				int index = queue.Dequeue();
				int x = GridDataIndexTools.GetX(index);
				int y = GridDataIndexTools.GetY(index);
				int z = GridDataIndexTools.GetZ(index);
				if (searchXorZAxis)
				{
					CheckExpandTo(x + 1, y, z);
					CheckExpandTo(x - 1, y, z);
				}
				else
				{
					CheckExpandTo(x, y, z + 1);
					CheckExpandTo(x, y, z - 1);
				}
				CheckExpandTo(x, y - 1, z);
				CheckExpandTo(x, y + 1, z);
				CheckExpandTo(x + 1, y, z - 1);
				CheckExpandTo(x - 1, y, z + 1);
				CheckExpandTo(x + 1, y, z + 1);
				CheckExpandTo(x - 1, y, z - 1);
			}
			void CheckExpandTo(int nx, int ny, int nz)
			{
				if (GridDataIndexTools.InRange(nx, ny, nz))
				{
					int num = GridDataIndexTools.FastTo1DIndexNoCheck(nx, ny, nz);
					if (waterSimLogic.ObstacleData[num] != 1 && !(waterSimLogic.WaterDataDisplay[num] <= 0.5f) && WaterSimLogic.SearchEachNeighbor(nx, ny, nz, (int num3, int num4, int num5, int num2) => waterSimLogic.WaterDataDisplay[num2] <= 0.5f && waterSimLogic.ObstacleData[num2] != 1) && !processed.Contains(num) && !lastArea.Contains(num))
					{
						queue.Enqueue(num);
						lastArea.Add(num);
					}
				}
			}
		}
	}
}
