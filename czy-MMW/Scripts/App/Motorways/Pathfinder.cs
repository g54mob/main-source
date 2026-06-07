using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Models;
using Motorways.Pathfinding;

namespace Motorways
{
	public class Pathfinder : ICreatedInScopeHandler, IReleasedFromScopeHandler
	{
		public enum MothballedLaneUse
		{
			Discouraged = 0,
			LastResort = 1,
			Never = 2
		}

		public const int NormalLaneCostMultiplier = 10;

		public const int MothballLaneCost = 100000;

		public const int NoPathCost = -1;

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Pathfinder");

		public static readonly Fix64 CarparkPenalty = (Fix64)5L;

		public static readonly Fix64 UTurnPenalty = (Fix64)500L;

		public static readonly Fix64 MothballedDiscouragedLanePenalty = (Fix64)1.25;

		public static readonly Fix64 MothballedLastResortLanePenalty = (Fix64)500L;

		public static readonly Fix64 VehicleSpeedCostMultiplier = (Fix64)2L;

		private ExternPathfinding _externPathfinding;

		public bool IsActive { get; private set; }

		public void OnCreatedInScope(IScope scope)
		{
			_externPathfinding = new ExternPathfinding();
			IsActive = true;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			Clear();
		}

		public void Clear()
		{
			if (IsActive)
			{
				_externPathfinding.Clear();
			}
			IsActive = false;
		}

		public void PauseUpdate()
		{
			_externPathfinding.PauseUpdate();
		}

		public void ResumeUpdate()
		{
			_externPathfinding.ResumeUpdate();
		}

		public List<LaneModel> CreatePath(LaneModel startLane, List<LaneModel> possibleEndLanes, bool allowMothballedLaneUse)
		{
			if (possibleEndLanes.Contains(startLane))
			{
				return new List<LaneModel>();
			}
			if (_externPathfinding.GetNearestEndpoint(startLane.PathfindingEndNodeId, possibleEndLanes, out var nearestEndpoint))
			{
				return CreatePath(startLane, nearestEndpoint, allowMothballedLaneUse);
			}
			return null;
		}

		public List<LaneModel> CreatePath(LaneModel startLane, LaneModel endLane, bool allowMothballedLaneUse)
		{
			if (!Diagnostics.Verify(startLane != null, "Cannot find path from a null lane."))
			{
				return null;
			}
			if (endLane == startLane)
			{
				Log.Info("Pathfinding from {0} to {1} which is the same lane!", startLane, endLane);
				return new List<LaneModel>();
			}
			if (startLane.EndPosition == endLane.StartPosition)
			{
				Log.Info("Pathfinding from {0} to {1} which are connected, so we just return the endLane as the entire path", startLane, endLane);
				return new List<LaneModel> { endLane };
			}
			if (!Diagnostics.Verify(_externPathfinding.IsNodeEndpoint(endLane.PathfindingStartNodeId), "Pathfinder can only find paths to endpoint nodes"))
			{
				return null;
			}
			LaneModel laneModel = startLane;
			if (!allowMothballedLaneUse)
			{
				int pathCost = _externPathfinding.GetPathCost(laneModel.PathfindingEndNodeId, endLane.PathfindingStartNodeId);
				if (pathCost >= 100000)
				{
					Log.Info("Returning null path from {0} to {1} as known path costs {2} so must contain mothballed road, which isn't allowed!", laneModel, endLane, pathCost);
					return null;
				}
			}
			List<LaneModel> list = new List<LaneModel>();
			while (laneModel.PathfindingEndNodeId != endLane.PathfindingStartNodeId)
			{
				laneModel = _externPathfinding.GetPathNextLane(laneModel.PathfindingEndNodeId, endLane.PathfindingStartNodeId);
				if (laneModel == null || !Diagnostics.Verify(!list.Contains(laneModel), "Path from {0} to {1} already contains lane {2} from {3} to {4}. There must be a loop!", laneModel.PathfindingEndNodeId, endLane.PathfindingStartNodeId, laneModel._id, laneModel.PathfindingStartNodeId, laneModel.PathfindingEndNodeId))
				{
					break;
				}
				list.Add(laneModel);
			}
			if (laneModel != null)
			{
				if (!Diagnostics.Verify(laneModel.PathfindingEndNodeId == endLane.PathfindingStartNodeId, "currentLane ({0}) was not null but it doesn't end at the endpoint lane. How is that possible?", laneModel))
				{
					return null;
				}
				list.Add(endLane);
				return list;
			}
			return null;
		}

		public int AddNode(bool isEndpoint)
		{
			return _externPathfinding.AddNode(isEndpoint);
		}

		public void AddEdge(LaneModel laneModel, int fromNodeId, int toNodeId, int cost)
		{
			_externPathfinding.AddEdge(laneModel, fromNodeId, toNodeId, cost);
		}

		public void RemoveEdge(int fromNodeId, int toNodeId)
		{
			_externPathfinding.RemoveEdge(fromNodeId, toNodeId);
		}

		public void ChangeEdgeCost(int fromNode, int toNode, int newCost)
		{
			_externPathfinding.ChangeEdgeCost(fromNode, toNode, newCost);
		}

		public bool MergeNodes(int intoNodeId, int fromNodeId)
		{
			return _externPathfinding.MergeNodes(intoNodeId, fromNodeId);
		}

		public void MakeEndpoint(int nodeId)
		{
			_externPathfinding.MakeNodeEndpoint(nodeId);
		}

		public LaneModel GetPathNextLane(int fromNodeId, int toNodeId)
		{
			return _externPathfinding.GetPathNextLane(fromNodeId, toNodeId);
		}

		public int GetMinPathCost(LaneModel fromLane, List<LaneModel> toLanes, bool allowMothballedLaneUse)
		{
			int num = (allowMothballedLaneUse ? int.MaxValue : 100000);
			int num2 = num;
			foreach (LaneModel toLane in toLanes)
			{
				int pathCost = _externPathfinding.GetPathCost(fromLane.PathfindingEndNodeId, toLane.PathfindingStartNodeId);
				if (pathCost >= 0 && pathCost < num2)
				{
					num2 = pathCost;
				}
			}
			if (num2 < num)
			{
				return num2;
			}
			return -1;
		}

		public bool AreLanesConnected(LaneModel fromLane, IEnumerable<LaneModel> possibleToLanes, bool allowMothballedLaneUsage)
		{
			foreach (LaneModel possibleToLane in possibleToLanes)
			{
				if (AreLanesConnected(fromLane, possibleToLane, allowMothballedLaneUsage))
				{
					return true;
				}
			}
			return false;
		}

		public bool AreLanesConnected(LaneModel fromLane, LaneModel toLane, bool allowMothballedLaneUsage)
		{
			if (fromLane.PathfindingEndNodeId == -1 || toLane.PathfindingStartNodeId == -1)
			{
				Log.Warn("Returning false from AreLanesConnected({0}, {1}) as the {2} lane doesn't have an end node ID", fromLane, toLane, (fromLane.PathfindingEndNodeId == -1) ? "from" : "to");
				return false;
			}
			return _externPathfinding.AreNodesConnected(fromLane.PathfindingEndNodeId, toLane.PathfindingStartNodeId, allowMothballedLaneUsage);
		}
	}
}
