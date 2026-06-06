using System;
using Pathfinding.Jobs;
using Pathfinding.Sync;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobBuildNodes
	{
		public class BuildNodeTilesOutput : IProgress, IDisposable
		{
			public TileBuilder.TileBuilderOutput progressSource;

			public NavmeshTile[] tiles;

			public float Progress => 0f;

			public void Dispose()
			{
			}
		}

		private uint graphIndex;

		public uint initialPenalty;

		public bool recalculateNormals;

		public float maxTileConnectionEdgeDistance;

		private Matrix4x4 graphToWorldSpace;

		private TileLayout tileLayout;

		internal JobBuildNodes(RecastGraph graph, TileLayout tileLayout)
		{
			graphIndex = 0u;
			initialPenalty = 0u;
			recalculateNormals = false;
			maxTileConnectionEdgeDistance = 0f;
			graphToWorldSpace = default(Matrix4x4);
			this.tileLayout = default(TileLayout);
		}

		public Promise<BuildNodeTilesOutput> Schedule(DisposeArena arena, Promise<TileBuilder.TileBuilderOutput> preCutDependency, Promise<TileCutter.TileCutterOutput> postCutDependency)
		{
			return default(Promise<BuildNodeTilesOutput>);
		}
	}
}
