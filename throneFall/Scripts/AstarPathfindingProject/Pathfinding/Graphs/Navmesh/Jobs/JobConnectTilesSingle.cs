using System.Runtime.InteropServices;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	internal struct JobConnectTilesSingle : IJob
	{
		public GCHandle tiles;

		public int tileIndex1;

		public int tileIndex2;

		public Vector2 tileWorldSize;

		public float maxTileConnectionEdgeDistance;

		public void Execute()
		{
			NavmeshTile[] array = (NavmeshTile[])tiles.Target;
			NavmeshBase.ConnectTiles(array[tileIndex1], array[tileIndex2], tileWorldSize.x, tileWorldSize.y, maxTileConnectionEdgeDistance);
		}
	}
}
