using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Tools;
using NSMedieval.Village.Map;
using Unity.Collections;

namespace Fire
{
	public class FirePresenceGrid
	{
		public const int GridCellSize = 2;

		public const int GridCellHeight = 2;

		private readonly Dictionary<int, int> firePresence;

		private readonly Vec3Int presenceGridSize;

		public FirePresenceGrid(Vec3Int mapSize)
		{
			presenceGridSize = new Vec3Int(mapSize.x / 2, mapSize.y / 2, mapSize.z / 2);
			firePresence = new Dictionary<int, int>();
			MonoSingleton<FireController>.Instance.FireAddedEvent += OnFireAdded;
			MonoSingleton<FireController>.Instance.FireRemovedEvent += OnFireRemoved;
		}

		public int GetFirePresence(MapNode node)
		{
			int key = CalculateNodeKey(node.Position);
			return firePresence.GetValueOrDefault(key, 0);
		}

		public int GetFirePresence(in Vec3Int nodePosition)
		{
			int key = CalculateNodeKey(in nodePosition);
			return firePresence.GetValueOrDefault(key, 0);
		}

		public bool HasFirePresence(MapNode node)
		{
			return GetFirePresence(node) > 0;
		}

		public bool HasFirePresence(in Vec3Int nodePos)
		{
			return GetFirePresence(in nodePos) > 0;
		}

		public void Dispose()
		{
			if (MonoSingleton<FireController>.IsInstantiated())
			{
				MonoSingleton<FireController>.Instance.FireAddedEvent -= OnFireAdded;
				MonoSingleton<FireController>.Instance.FireRemovedEvent -= OnFireRemoved;
			}
		}

		private void OnFireAdded(NativeParallelHashSet<int> nodeIndices)
		{
			foreach (int item in nodeIndices)
			{
				int key = CalculateNodeKey(GridDataIndexTools.FastTo3DIndex(item));
				firePresence.TryAdd(key, 0);
				firePresence[key]++;
			}
		}

		private void OnFireRemoved(NativeParallelHashSet<int> nodeIndices)
		{
			foreach (int item in nodeIndices)
			{
				int key = CalculateNodeKey(GridDataIndexTools.FastTo3DIndex(item));
				if (firePresence.ContainsKey(key))
				{
					firePresence[key]--;
					if (firePresence[key] == 0)
					{
						firePresence.Remove(key);
					}
				}
			}
		}

		private int CalculateNodeKey(in Vec3Int nodePosition)
		{
			int num = nodePosition.x / 2;
			int num2 = nodePosition.y / 2;
			int num3 = nodePosition.z / 2;
			return num + num2 * presenceGridSize.x + num3 * presenceGridSize.x * presenceGridSize.y;
		}
	}
}
