using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using Motorways.Models;
using UnityEngine;

namespace Motorways.Pathfinding
{
	public class ExternPathfinding
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void NativeReportError(string errorMessage);

		private readonly int _pathfinderId = NativeSetup();

		private readonly Dictionary<int, LaneModel> _edgeToLaneMap = new Dictionary<int, LaneModel>();

		private static readonly IntPtr ReportErrorMarshalled = Marshal.GetFunctionPointerForDelegate<NativeReportError>(ReportError);

		public void Clear()
		{
			_edgeToLaneMap.Clear();
			NativeClear(_pathfinderId, ReportErrorMarshalled);
		}

		public void PauseUpdate()
		{
			NativePauseUpdate(_pathfinderId, ReportErrorMarshalled);
		}

		public void ResumeUpdate()
		{
			NativeResumeUpdate(_pathfinderId, ReportErrorMarshalled);
		}

		public int AddNode(bool isEndpoint = false)
		{
			return NativeAddNode(_pathfinderId, isEndpoint, ReportErrorMarshalled);
		}

		public bool MergeNodes(int intoNodeId, int fromNodeId)
		{
			return NativeMergeNodes(_pathfinderId, intoNodeId, fromNodeId, ReportErrorMarshalled);
		}

		[MonoPInvokeCallback(typeof(NativeReportError))]
		private static void ReportError(string errorMessage)
		{
			Diagnostics.FailAssert(errorMessage);
		}

		public int AddEdge(int nodeId1, int nodeId2, int cost)
		{
			return AddEdge(null, nodeId1, nodeId2, cost);
		}

		public int AddEdge(LaneModel laneModel, int nodeId1, int nodeId2, int cost)
		{
			int num = NativeAddEdge(_pathfinderId, nodeId1, nodeId2, cost, ReportErrorMarshalled);
			if (Diagnostics.Verify(num >= 0))
			{
				_edgeToLaneMap[num] = laneModel;
			}
			return num;
		}

		public bool AddEdgesBetweenNodes(int nodeA, int nodeB, int cost)
		{
			if (AddEdge(null, nodeA, nodeB, cost) != -1)
			{
				return AddEdge(null, nodeB, nodeA, cost) != -1;
			}
			return false;
		}

		public bool RemoveEdge(int nodeId1, int nodeId2)
		{
			return NativeRemoveEdge(_pathfinderId, nodeId1, nodeId2, ReportErrorMarshalled);
		}

		public bool ChangeEdgeCost(int node1Id, int node2Id, int newCost)
		{
			return NativeChangeEdgeCost(_pathfinderId, node1Id, node2Id, newCost, ReportErrorMarshalled);
		}

		public int GetPathCost(int fromNodeId, int endpointNodeId)
		{
			int num = NativeGetPathCost(_pathfinderId, fromNodeId, endpointNodeId, ReportErrorMarshalled);
			if (num < NativeGetNoPathCostConstant())
			{
				return num;
			}
			return -1;
		}

		public int GetPathNextEdge(int fromNodeId, int endpointNodeId)
		{
			return NativeGetPathNextEdge(_pathfinderId, fromNodeId, endpointNodeId, ReportErrorMarshalled);
		}

		public int GetPathNextNode(int fromNodeId, int endpointNodeId)
		{
			return NativeGetPathNextNode(_pathfinderId, fromNodeId, endpointNodeId, ReportErrorMarshalled);
		}

		public LaneModel GetPathNextLane(int fromNodeId, int endpointNodeId)
		{
			int key = NativeGetPathNextEdge(_pathfinderId, fromNodeId, endpointNodeId, ReportErrorMarshalled);
			if (_edgeToLaneMap.TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}

		public bool GetNearestEndpoint(int fromNodeId, List<LaneModel> endpointLaneModels, out LaneModel nearestEndpoint)
		{
			int num = NativeGetNoPathCostConstant();
			nearestEndpoint = null;
			foreach (LaneModel endpointLaneModel in endpointLaneModels)
			{
				int num2 = NativeGetPathCost(_pathfinderId, fromNodeId, endpointLaneModel.PathfindingStartNodeId, ReportErrorMarshalled);
				if (num2 < num)
				{
					num = num2;
					nearestEndpoint = endpointLaneModel;
				}
			}
			return nearestEndpoint != null;
		}

		public int GetEdgeCost(int fromNodeId, int toNodeId)
		{
			return NativeGetEdgeCost(_pathfinderId, fromNodeId, toNodeId, ReportErrorMarshalled);
		}

		public int GetNeighbourCount(int fromNodeId)
		{
			return NativeGetNeighbourCount(_pathfinderId, fromNodeId, ReportErrorMarshalled);
		}

		public int GetNeighbour(int fromNodeId, int neighbourIndex)
		{
			return NativeGetNeighbour(_pathfinderId, fromNodeId, neighbourIndex, ReportErrorMarshalled);
		}

		public bool IsNodeEndpoint(int nodeId)
		{
			return NativeIsNodeEndpoint(_pathfinderId, nodeId, ReportErrorMarshalled);
		}

		public void MakeNodeEndpoint(int nodeId)
		{
			NativeMakeNodeEndpoint(_pathfinderId, nodeId, ReportErrorMarshalled);
		}

		public bool AreNodesConnected(int nodeId1, int nodeId2, bool allowMothballedLaneUsage)
		{
			return NativeAreNodesConnected(_pathfinderId, nodeId1, nodeId2, allowMothballedLaneUsage ? NativeGetNoPathCostConstant() : 100000, ReportErrorMarshalled);
		}

		public static void DebugPrintPathfindingGraphs()
		{
			Debug.LogWarning(NativeDebugPrintPathfindingGraphs(ReportErrorMarshalled));
		}

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AddNode")]
		private static extern int NativeAddNode(int pathfinderId, bool isEndpoint, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "MergeNodes")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool NativeMergeNodes(int pathfinderId, int intoNodeId, int fromNodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AddEdge")]
		private static extern int NativeAddEdge(int pathfinderId, int nodeId1, int nodeId2, int cost, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RemoveEdge")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool NativeRemoveEdge(int pathfinderId, int nodeId1, int nodeId2, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ChangeEdgeCost")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool NativeChangeEdgeCost(int pathfinderId, int node1Id, int node2Id, int newCost, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetPathCost")]
		private static extern int NativeGetPathCost(int pathfinderId, int fromNodeId, int endpointNodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetPathNextEdge")]
		private static extern int NativeGetPathNextEdge(int pathfinderId, int fromNodeId, int endpointNodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetPathNextNode")]
		private static extern int NativeGetPathNextNode(int pathfinderId, int fromNodeId, int endpointNodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetEdgeCost")]
		private static extern int NativeGetEdgeCost(int pathfinderId, int fromNodeId, int toNodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetNeighbourCount")]
		private static extern int NativeGetNeighbourCount(int pathfinderId, int fromNodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetNeighbour")]
		private static extern int NativeGetNeighbour(int pathfinderId, int fromNodeId, int neighbourIndex, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IsNodeEndpoint")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool NativeIsNodeEndpoint(int pathfinderId, int nodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "MakeNodeEndpoint")]
		private static extern void NativeMakeNodeEndpoint(int pathfinderId, int nodeId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "AreNodesConnected")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool NativeAreNodesConnected(int pathfinderId, int nodeId1, int nodeId2, int costUpperLimit, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetNoPathCostConstant")]
		private static extern int NativeGetNoPathCostConstant();

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Clear")]
		private static extern int NativeClear(int pathfinderId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "PauseUpdate")]
		private static extern int NativePauseUpdate(int pathfinderId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ResumeUpdate")]
		private static extern int NativeResumeUpdate(int pathfinderId, IntPtr reportError);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Setup")]
		private static extern int NativeSetup();

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DebugPrintPathfindingGraphs")]
		private static extern string NativeDebugPrintPathfindingGraphs(IntPtr reportError);
	}
}
