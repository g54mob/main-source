using System;

namespace Timberborn.Navigation
{
	internal readonly struct NavMeshChange
	{
		private readonly NavMeshChangeType _changeType;

		private readonly int _startNodeId;

		private readonly int _endNodeId;

		private readonly int _groupId;

		private readonly float _cost;

		public NavMeshChange(NavMeshChangeType changeType, int startNodeId, int endNodeId, int groupId, float cost)
		{
			_changeType = changeType;
			_startNodeId = startNodeId;
			_endNodeId = endNodeId;
			_groupId = groupId;
			_cost = cost;
		}

		public void Apply(TerrainNavMeshSource terrainNavMeshSource, NavMeshUpdate.Builder navMeshUpdateBuilder)
		{
			switch (_changeType)
			{
			case NavMeshChangeType.AddEdge:
				terrainNavMeshSource.AddEdge(_startNodeId, _endNodeId, _groupId, _cost);
				break;
			case NavMeshChangeType.RemoveEdge:
				terrainNavMeshSource.RemoveEdge(_startNodeId, _endNodeId, _groupId, _cost);
				break;
			case NavMeshChangeType.BlockEdge:
				terrainNavMeshSource.BlockEdge(_startNodeId, _endNodeId, _groupId);
				break;
			case NavMeshChangeType.UnblockEdge:
				terrainNavMeshSource.UnblockEdge(_startNodeId, _endNodeId, _groupId);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case NavMeshChangeType.None:
				break;
			}
			if (_changeType != NavMeshChangeType.None)
			{
				navMeshUpdateBuilder.AddTerrainNode(_startNodeId);
				navMeshUpdateBuilder.AddTerrainNode(_endNodeId);
			}
		}

		public void Apply(RoadNavMeshSource roadNavMeshSource, NavMeshUpdate.Builder navMeshUpdateBuilder)
		{
			switch (_changeType)
			{
			case NavMeshChangeType.AddEdge:
				roadNavMeshSource.AddEdge(_startNodeId, _endNodeId, _groupId, _cost);
				break;
			case NavMeshChangeType.RemoveEdge:
				roadNavMeshSource.RemoveEdge(_startNodeId, _endNodeId, _groupId, _cost);
				break;
			case NavMeshChangeType.BlockEdge:
				roadNavMeshSource.BlockEdge(_startNodeId, _endNodeId, _groupId);
				break;
			case NavMeshChangeType.UnblockEdge:
				roadNavMeshSource.UnblockEdge(_startNodeId, _endNodeId, _groupId);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case NavMeshChangeType.None:
				break;
			}
			if (_changeType != NavMeshChangeType.None)
			{
				navMeshUpdateBuilder.AddRoadNode(_startNodeId);
				navMeshUpdateBuilder.AddRoadNode(_endNodeId);
			}
		}
	}
}
