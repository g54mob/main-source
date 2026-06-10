using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Village.Map.Pathfinding
{
	public static class PathSearchNodePool
	{
		private static readonly Queue<PathSearchNode> SearchNodeAllocBlock = new Queue<PathSearchNode>();

		private static readonly Queue<PathSearchNode> OutOfPool = new Queue<PathSearchNode>();

		private static int totalAllocated;

		private const int SearchAllocBlock = 15000;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			OutOfPool.Clear();
			SearchNodeAllocBlock.Clear();
			totalAllocated = 0;
		}

		public static PathSearchNode Get()
		{
			lock (SearchNodeAllocBlock)
			{
				if (SearchNodeAllocBlock.Count == 0)
				{
					for (int i = 0; i < 15000; i++)
					{
						SearchNodeAllocBlock.Enqueue(new PathSearchNode(null, null));
					}
					totalAllocated += 15000;
				}
				PathSearchNode pathSearchNode = SearchNodeAllocBlock.Dequeue();
				OutOfPool.Enqueue(pathSearchNode);
				return pathSearchNode;
			}
		}

		public static void ReturnAllNodesToPool()
		{
			lock (SearchNodeAllocBlock)
			{
				foreach (PathSearchNode item in OutOfPool)
				{
					item.Parent = null;
					item.Node = null;
					item.HeapIndex = int.MaxValue;
					SearchNodeAllocBlock.Enqueue(item);
				}
				OutOfPool.Clear();
			}
		}
	}
}
