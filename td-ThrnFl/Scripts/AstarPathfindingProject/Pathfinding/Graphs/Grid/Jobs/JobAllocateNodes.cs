using System;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Grid.Jobs
{
	public struct JobAllocateNodes : IJob
	{
		public AstarPath active;

		[ReadOnly]
		public NativeArray<float4> nodeNormals;

		public IntBounds dataBounds;

		public int3 nodeArrayBounds;

		public GridNodeBase[] nodes;

		public Func<GridNodeBase> newGridNodeDelegate;

		public void Execute()
		{
			int3 size = dataBounds.size;
			UnsafeSpan<float4> unsafeSpan = nodeNormals.AsUnsafeReadOnlySpan();
			for (int i = 1; i < size.y; i++)
			{
				for (int j = 0; j < size.z; j++)
				{
					int num = ((i + dataBounds.min.y) * nodeArrayBounds.z + (j + dataBounds.min.z)) * nodeArrayBounds.x + dataBounds.min.x;
					for (int k = 0; k < size.x; k++)
					{
						int num2 = num + k;
						bool flag = math.any(unsafeSpan[num2]);
						GridNodeBase gridNodeBase = nodes[num2];
						bool flag2 = gridNodeBase != null;
						if (flag != flag2)
						{
							if (flag)
							{
								gridNodeBase = (nodes[num2] = newGridNodeDelegate());
								active.InitializeNode(gridNodeBase);
								continue;
							}
							gridNodeBase.ClearCustomConnections(alsoReverse: true);
							gridNodeBase.ResetConnectionsInternal();
							gridNodeBase.Destroy();
							nodes[num2] = null;
						}
					}
				}
			}
		}
	}
}
