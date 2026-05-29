using Pathfinding.Jobs;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct LinkedVoxelField : IArenaDisposable
	{
		public const uint MaxHeight = 65536u;

		public const int MaxHeightInt = 65536;

		public const uint InvalidSpanValue = uint.MaxValue;

		public const float AvgSpanLayerCountEstimate = 8f;

		public int width;

		public int depth;

		public int height;

		public bool flatten;

		public NativeList<LinkedVoxelSpan> linkedSpans;

		private NativeList<int> removedStack;

		private NativeList<CellMinMax> linkedCellMinMax;

		public LinkedVoxelField(int width, int depth, int height)
		{
			this.width = width;
			this.depth = depth;
			this.height = height;
			flatten = true;
			linkedSpans = new NativeList<LinkedVoxelSpan>(0, Allocator.Persistent);
			removedStack = new NativeList<int>(128, Allocator.Persistent);
			linkedCellMinMax = new NativeList<CellMinMax>(0, Allocator.Persistent);
		}

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
			arena.Add(linkedSpans);
			arena.Add(removedStack);
			arena.Add(linkedCellMinMax);
		}

		public void ResetLinkedVoxelSpans()
		{
			int num = width * depth;
			LinkedVoxelSpan value = new LinkedVoxelSpan(uint.MaxValue, uint.MaxValue, -1, -1);
			linkedSpans.ResizeUninitialized(num);
			linkedCellMinMax.Resize(num, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < num; i++)
			{
				linkedSpans[i] = value;
				linkedCellMinMax[i] = new CellMinMax
				{
					objectID = -1,
					min = 0,
					max = 0
				};
			}
			removedStack.Clear();
		}

		private void PushToSpanRemovedStack(int index)
		{
			removedStack.Add(in index);
		}

		public int GetSpanCount()
		{
			int num = 0;
			int num2 = width * depth;
			for (int i = 0; i < num2; i++)
			{
				int num3 = i;
				while (num3 != -1 && linkedSpans[num3].bottom != uint.MaxValue)
				{
					num += ((linkedSpans[num3].area != 0) ? 1 : 0);
					num3 = linkedSpans[num3].next;
				}
			}
			return num;
		}

		public void ResolveSolid(int index, int objectID, int voxelWalkableClimb)
		{
			CellMinMax cellMinMax = linkedCellMinMax[index];
			if (cellMinMax.objectID == objectID && cellMinMax.min < cellMinMax.max - 1)
			{
				AddLinkedSpan(index, cellMinMax.min, cellMinMax.max - 1, 0, voxelWalkableClimb, objectID);
			}
		}

		public void SetWalkableBackground()
		{
			int num = width * depth;
			for (int i = 0; i < num; i++)
			{
				linkedSpans[i] = new LinkedVoxelSpan(0u, 1u, 1);
			}
		}

		public void AddFlattenedSpan(int index, int area)
		{
			if (linkedSpans[index].bottom == uint.MaxValue)
			{
				linkedSpans[index] = new LinkedVoxelSpan(0u, 1u, area);
			}
			else
			{
				linkedSpans[index] = new LinkedVoxelSpan(0u, 1u, (linkedSpans[index].area != 0 && area != 0) ? math.max(linkedSpans[index].area, area) : 0);
			}
		}

		public void AddLinkedSpan(int index, int bottom, int top, int area, int voxelWalkableClimb, int objectID)
		{
			CellMinMax value = linkedCellMinMax[index];
			if (value.objectID != objectID)
			{
				linkedCellMinMax[index] = new CellMinMax
				{
					objectID = objectID,
					min = bottom,
					max = top
				};
			}
			else
			{
				value.min = math.min(value.min, bottom);
				value.max = math.max(value.max, top);
				linkedCellMinMax[index] = value;
			}
			top = math.min(top, height);
			bottom = math.max(bottom, 0);
			if (bottom >= top)
			{
				return;
			}
			uint num = (uint)top;
			uint num2 = (uint)bottom;
			if (linkedSpans[index].bottom == uint.MaxValue)
			{
				linkedSpans[index] = new LinkedVoxelSpan(num2, num, area);
				return;
			}
			int num3 = -1;
			int index2 = index;
			while (index != -1)
			{
				LinkedVoxelSpan linkedVoxelSpan = linkedSpans[index];
				if (linkedVoxelSpan.bottom > num)
				{
					break;
				}
				if (linkedVoxelSpan.top < num2)
				{
					num3 = index;
					index = linkedVoxelSpan.next;
					continue;
				}
				if (math.abs((int)(num - linkedVoxelSpan.top)) < voxelWalkableClimb && (area == 0 || linkedVoxelSpan.area == 0))
				{
					area = math.max(area, linkedVoxelSpan.area);
				}
				else if (num < linkedVoxelSpan.top)
				{
					area = linkedVoxelSpan.area;
				}
				num2 = math.min(linkedVoxelSpan.bottom, num2);
				num = math.max(linkedVoxelSpan.top, num);
				int next = linkedVoxelSpan.next;
				if (num3 != -1)
				{
					LinkedVoxelSpan value2 = linkedSpans[num3];
					value2.next = next;
					linkedSpans[num3] = value2;
					PushToSpanRemovedStack(index);
					index = next;
					continue;
				}
				if (next != -1)
				{
					linkedSpans[index2] = linkedSpans[next];
					PushToSpanRemovedStack(next);
					continue;
				}
				linkedSpans[index2] = new LinkedVoxelSpan(num2, num, area);
				return;
			}
			int num4;
			if (removedStack.Length > 0)
			{
				num4 = removedStack[removedStack.Length - 1];
				removedStack.RemoveAtSwapBack(removedStack.Length - 1);
			}
			else
			{
				num4 = linkedSpans.Length;
				linkedSpans.Resize(linkedSpans.Length + 1, NativeArrayOptions.UninitializedMemory);
			}
			if (num3 != -1)
			{
				linkedSpans[num4] = new LinkedVoxelSpan(num2, num, area, linkedSpans[num3].next);
				LinkedVoxelSpan value3 = linkedSpans[num3];
				value3.next = num4;
				linkedSpans[num3] = value3;
			}
			else
			{
				linkedSpans[num4] = linkedSpans[index2];
				linkedSpans[index2] = new LinkedVoxelSpan(num2, num, area, num4);
			}
		}
	}
}
