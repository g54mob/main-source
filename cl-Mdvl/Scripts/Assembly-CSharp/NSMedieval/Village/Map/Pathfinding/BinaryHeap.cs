using System;
using NSMedieval.Tools.Math;
using UnityEngine;

namespace NSMedieval.Village.Map.Pathfinding
{
	internal class BinaryHeap
	{
		public struct HeapNode
		{
			public PathSearchNode Node { get; }

			public uint F { get; set; }

			public HeapNode(PathSearchNode node, uint f)
			{
				Node = node;
				F = f;
			}
		}

		public const int NotInHeap = int.MaxValue;

		private const float GrowthFactor = 2f;

		private const int D = 4;

		private int numberOfItems;

		private HeapNode[] heap;

		public HeapNode[] List => heap;

		public BinaryHeap(int capacity)
		{
			capacity = FoxyMath.RoundUpToNextMultipleMod1(capacity, 4);
			heap = new HeapNode[capacity];
			numberOfItems = 0;
		}

		public void Clear()
		{
			for (int i = 0; i < numberOfItems; i++)
			{
				heap[i].Node.HeapIndex = int.MaxValue;
			}
			numberOfItems = 0;
		}

		public bool IsEmpty()
		{
			return numberOfItems <= 0;
		}

		public void Add(PathSearchNode node)
		{
			if (node.HeapIndex != int.MaxValue)
			{
				DecreaseKey(heap[node.HeapIndex], node.HeapIndex);
				return;
			}
			if (numberOfItems >= heap.Length)
			{
				Expand();
			}
			DecreaseKey(new HeapNode(node, node.F), numberOfItems);
			numberOfItems++;
		}

		private void DecreaseKey(HeapNode node, int index)
		{
			uint num = (node.F = node.Node.F);
			uint num2 = num;
			if (index < numberOfItems && num2 > heap[index].F)
			{
				throw new Exception("New node key greater than original key. " + node.Node.HeapIndex + " " + index);
			}
			int num3 = index;
			while (num3 != 0)
			{
				int num4 = (num3 - 1) / 4;
				if (num2 >= heap[num4].F)
				{
					break;
				}
				heap[num3] = heap[num4];
				heap[num3].Node.HeapIndex = num3;
				num3 = num4;
			}
			heap[num3] = node;
			node.Node.HeapIndex = num3;
		}

		public PathSearchNode Remove()
		{
			HeapNode heapNode = heap[0];
			heapNode.Node.HeapIndex = int.MaxValue;
			numberOfItems--;
			if (numberOfItems == 0)
			{
				return heapNode.Node;
			}
			HeapNode heapNode2 = heap[numberOfItems];
			int num = 0;
			while (true)
			{
				int num2 = num;
				uint num3 = heapNode2.F;
				int num4 = num2 * 4 + 1;
				if (num4 <= numberOfItems)
				{
					uint f = heap[num4].F;
					uint f2 = heap[num4 + 1].F;
					uint f3 = heap[num4 + 2].F;
					uint f4 = heap[num4 + 3].F;
					if (num4 < numberOfItems && f < num3)
					{
						num3 = f;
						num = num4;
					}
					if (num4 + 1 < numberOfItems && f2 < num3)
					{
						num3 = f2;
						num = num4 + 1;
					}
					if (num4 + 2 < numberOfItems && f3 < num3)
					{
						num3 = f3;
						num = num4 + 2;
					}
					if (num4 + 3 < numberOfItems && f4 < num3)
					{
						num = num4 + 3;
					}
				}
				if (num2 == num)
				{
					break;
				}
				heap[num2] = heap[num];
				heap[num2].Node.HeapIndex = num2;
			}
			heap[num] = heapNode2;
			heapNode2.Node.HeapIndex = num;
			return heapNode.Node;
		}

		public void ReBuildHeap()
		{
			for (int i = 1; i < numberOfItems; i++)
			{
				int num = i;
				HeapNode heapNode = heap[i];
				while (num != 0)
				{
					int num2 = (num - 1) / 4;
					if (heapNode.F >= heap[num2].F)
					{
						break;
					}
					heap[num] = heap[num2];
					heap[num].Node.HeapIndex = num;
					heap[num2] = heapNode;
					heapNode.Node.HeapIndex = num2;
					num = num2;
				}
			}
		}

		private void Expand()
		{
			int num = FoxyMath.RoundUpToNextMultipleMod1(Math.Max(heap.Length + 4, Math.Min(2147483645, Mathf.RoundToInt((float)heap.Length * 2f))), 4);
			if (num > 2147483646)
			{
				throw new Exception("Binary Heap Size really large ( " + int.MaxValue + " ). A heap size this large is probably the cause of pathfinding running in an infinite loop. ");
			}
			HeapNode[] array = new HeapNode[num];
			heap.CopyTo(array, 0);
			heap = array;
		}
	}
}
