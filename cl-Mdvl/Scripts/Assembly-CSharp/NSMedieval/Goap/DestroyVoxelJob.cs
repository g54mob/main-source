using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap
{
	public struct DestroyVoxelJob : IEquatable<DestroyVoxelJob>
	{
		public BaseBuildingInstance Building;

		public MapNode NodeToRemove;

		public short Priority;

		public WorldDirection AvoidReachableDirections;

		public Vec3Int DigMarkerPosition => NodeToRemove.Position + Vec3Int.up;

		public JobType Type
		{
			get
			{
				if (Building != null)
				{
					return JobType.Construction;
				}
				return JobType.Mining;
			}
		}

		public bool HasValue
		{
			get
			{
				if (Building == null)
				{
					return NodeToRemove != null;
				}
				return true;
			}
		}

		public bool IsDone
		{
			get
			{
				if (Building != null)
				{
					return Building.HasDisposed;
				}
				if (NodeToRemove != null)
				{
					if (!NodeToRemove.IsSlopeOrStairs())
					{
						return NodeToRemove.IsVoxelAir();
					}
					return false;
				}
				return true;
			}
		}

		public DestroyVoxelJob(MapNode nodeToRemove)
		{
			NodeToRemove = nodeToRemove;
			Priority = 0;
			Building = null;
			AvoidReachableDirections = WorldDirection.None;
		}

		public DestroyVoxelJob(BaseBuildingInstance building)
		{
			Building = building;
			NodeToRemove = building.GetNode();
			Priority = 0;
			AvoidReachableDirections = WorldDirection.None;
		}

		public void RecalculatePriority()
		{
			Priority = (short)(100 * NodeToRemove.Position.y);
			if (Building != null && Building.Blueprint.PathfindingPenalty < ushort.MaxValue)
			{
				return;
			}
			foreach (MapNode neighbour in NodeToRemove.Neighbours)
			{
				if (!neighbour.IsWalkable || (neighbour.IsVoxelAir() && neighbour.Position.y != NodeToRemove.Position.y))
				{
					Priority -= 10;
				}
				if (MonoSingleton<DigMarkerResourceManager>.Instance.DigMarkerExists(neighbour.Position + Vec3Int.up))
				{
					Priority--;
				}
			}
		}

		public static void SortByPriority(List<DestroyVoxelJob> jobs)
		{
			jobs.Sort((DestroyVoxelJob job1, DestroyVoxelJob job2) => job2.Priority.CompareTo(job1.Priority));
		}

		public bool Equals(DestroyVoxelJob other)
		{
			if (object.Equals(Building, other.Building) && object.Equals(NodeToRemove, other.NodeToRemove))
			{
				return Priority == other.Priority;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is DestroyVoxelJob other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Building, NodeToRemove, Priority);
		}
	}
}
