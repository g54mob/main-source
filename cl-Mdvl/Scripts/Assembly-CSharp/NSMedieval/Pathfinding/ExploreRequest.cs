using System;
using NSMedieval.Goap;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Pathfinding
{
	public struct ExploreRequest
	{
		public IPathfindingAgent Agent { get; set; }

		public GridDataType GridData { get; set; }

		public Func<WorldObject, bool> Condition { get; set; }

		public bool DoQuickSearch { get; set; }

		public Vec3Int StartPosOverride { get; set; }

		public Func<WorldObject, Vec3Int, P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult> OnFound { get; set; }

		public ExploreRequest(IPathfindingAgent agent, GridDataType gridData, bool doQuickSearch, Func<WorldObject, bool> condition, Func<WorldObject, Vec3Int, P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult> onFound)
		{
			Agent = agent;
			GridData = gridData;
			Condition = condition;
			OnFound = onFound;
			DoQuickSearch = doQuickSearch;
			StartPosOverride = Vec3Int.zero;
		}

		public ExploreRequest(IPathfindingAgent agent, Vec3Int startPosOverride, GridDataType gridData, bool doQuickSearch, Func<WorldObject, bool> condition, Func<WorldObject, Vec3Int, P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult> onFound)
		{
			Agent = agent;
			GridData = gridData;
			Condition = condition;
			OnFound = onFound;
			DoQuickSearch = doQuickSearch;
			StartPosOverride = startPosOverride;
		}
	}
}
