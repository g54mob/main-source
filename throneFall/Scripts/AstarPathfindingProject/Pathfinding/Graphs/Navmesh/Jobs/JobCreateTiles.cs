using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobCreateTiles : IJob
	{
		[ReadOnly]
		public NativeArray<TileMesh.TileMeshUnsafe> tileMeshes;

		public GCHandle tiles;

		public uint graphIndex;

		public Int2 graphTileCount;

		public IntRect tileRect;

		public uint initialPenalty;

		public bool recalculateNormals;

		public Vector2 tileWorldSize;

		public Matrix4x4 graphToWorldSpace;

		public void Execute()
		{
			NavmeshTile[] array = (NavmeshTile[])tiles.Target;
			int width = tileRect.Width;
			int height = tileRect.Height;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int num = i * width + j;
					int tileIndex = (i + tileRect.ymin) * graphTileCount.x + (j + tileRect.xmin);
					TileMesh.TileMeshUnsafe tileMeshUnsafe = tileMeshes[num];
					UnsafeSpan<Int3> unsafeSpan = tileMeshUnsafe.verticesInTileSpace.AsUnsafeSpan<Int3>().Clone(Allocator.Persistent);
					UnsafeSpan<Int3> verts = unsafeSpan.Clone(Allocator.Persistent);
					Int3 @int = (Int3)new Vector3(tileWorldSize.x * (float)(j + tileRect.xmin), 0f, tileWorldSize.y * (float)(i + tileRect.ymin));
					for (int k = 0; k < unsafeSpan.Length; k++)
					{
						Int3 int2 = unsafeSpan[k] + @int;
						unsafeSpan[k] = int2;
						verts[k] = (Int3)graphToWorldSpace.MultiplyPoint3x4((Vector3)int2);
					}
					UnsafeSpan<int> unsafeSpan2 = tileMeshUnsafe.triangles.AsUnsafeSpan<int>().Clone(Allocator.Persistent);
					NavmeshTile navmeshTile = new NavmeshTile
					{
						x = j + tileRect.xmin,
						z = i + tileRect.ymin,
						w = 1,
						d = 1,
						tris = unsafeSpan2,
						vertsInGraphSpace = unsafeSpan,
						verts = verts,
						bbTree = new BBTree(unsafeSpan2, unsafeSpan),
						nodes = new TriangleMeshNode[unsafeSpan2.Length / 3],
						graph = null
					};
					NavmeshBase.CreateNodes(navmeshTile, navmeshTile.tris, tileIndex, graphIndex, tileMeshUnsafe.tags.AsUnsafeSpan<uint>(), initializeNodes: false, null, initialPenalty, tryPreserveExistingTagsAndPenalties: false);
					array[num] = navmeshTile;
				}
			}
		}
	}
}
