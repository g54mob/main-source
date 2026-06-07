using Pathfinding.Jobs;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct CompactVoxelField : IArenaDisposable
	{
		public const int UnwalkableArea = 0;

		public const uint NotConnected = 63u;

		public readonly int voxelWalkableHeight;

		public readonly int width;

		public readonly int depth;

		public NativeList<CompactVoxelSpan> spans;

		public NativeList<CompactVoxelCell> cells;

		public NativeList<int> areaTypes;

		public const int MaxLayers = 65535;

		public CompactVoxelField(int width, int depth, int voxelWalkableHeight, Allocator allocator)
		{
			spans = new NativeList<CompactVoxelSpan>(0, allocator);
			cells = new NativeList<CompactVoxelCell>(0, allocator);
			areaTypes = new NativeList<int>(0, allocator);
			this.width = width;
			this.depth = depth;
			this.voxelWalkableHeight = voxelWalkableHeight;
		}

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
			arena.Add(spans);
			arena.Add(cells);
			arena.Add(areaTypes);
		}

		public int GetNeighbourIndex(int index, int direction)
		{
			return index + VoxelUtilityBurst.DX[direction] + VoxelUtilityBurst.DZ[direction] * width;
		}

		public void BuildFromLinkedField(LinkedVoxelField field)
		{
			int num = 0;
			int num2 = field.width;
			int num3 = field.depth;
			int num4 = num2 * num3;
			int spanCount = field.GetSpanCount();
			spans.Resize(spanCount, NativeArrayOptions.UninitializedMemory);
			areaTypes.Resize(spanCount, NativeArrayOptions.UninitializedMemory);
			cells.Resize(num4, NativeArrayOptions.UninitializedMemory);
			NativeList<LinkedVoxelSpan> linkedSpans = field.linkedSpans;
			for (int i = 0; i < num4; i += num2)
			{
				for (int j = 0; j < num2; j++)
				{
					int num5 = j + i;
					if (linkedSpans[num5].bottom == uint.MaxValue)
					{
						cells[j + i] = new CompactVoxelCell(0, 0);
						continue;
					}
					int i2 = num;
					int num6 = 0;
					while (num5 != -1)
					{
						if (linkedSpans[num5].area != 0)
						{
							int top = (int)linkedSpans[num5].top;
							int next = linkedSpans[num5].next;
							int num7 = (int)((next != -1) ? linkedSpans[next].bottom : 65536);
							spans[num] = new CompactVoxelSpan((ushort)math.min(top, 65535), (uint)math.min(num7 - top, 65535));
							areaTypes[num] = linkedSpans[num5].area;
							num++;
							num6++;
						}
						num5 = linkedSpans[num5].next;
					}
					cells[j + i] = new CompactVoxelCell(i2, num6);
				}
			}
		}
	}
}
