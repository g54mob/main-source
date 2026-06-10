using System;
using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap
{
	public struct CreateVoxelJob : IEquatable<CreateVoxelJob>
	{
		public BaseBuildingInstance Building;

		public bool IsWallish;

		public short Priority;

		public bool IsBuildingWalkable;

		public WorldDirection AvoidReachableDirections;

		public bool HasValue => Building != null;

		public bool CanBeConstructed
		{
			get
			{
				if (Building != null)
				{
					return Building.ConstructionPhase == ConstructionPhase.Foundation;
				}
				return false;
			}
		}

		public CreateVoxelJob(BaseBuildingInstance building)
		{
			Building = building;
			IsWallish = (building.Blueprint.BuildingType & (BuildingType.AnyDoor | BuildingType.Default | BuildingType.Wall | BuildingType.Window)) != 0;
			if ((building.BuildingType & BuildingType.Stairs) != 0)
			{
				IsBuildingWalkable = false;
			}
			else
			{
				IsBuildingWalkable = building.Blueprint.PathfindingPenalty < ushort.MaxValue;
			}
			Priority = 0;
			AvoidReachableDirections = WorldDirection.None;
		}

		public void RecalculatePriority()
		{
			MapNode node = Building.GetNode();
			Priority = (short)(-10 * node.Position.y);
			if (!IsWallish && IsBuildingWalkable)
			{
				Priority -= 9;
				return;
			}
			foreach (MapNode neighbour in node.Neighbours)
			{
				if (!neighbour.IsWalkable || (neighbour.IsVoxelAir() && neighbour.Position.y != node.Position.y))
				{
					Priority++;
				}
			}
		}

		public static void SortByPriority(List<CreateVoxelJob> jobs)
		{
			jobs.Sort((CreateVoxelJob job1, CreateVoxelJob job2) => job2.Priority.CompareTo(job1.Priority));
		}

		public bool Equals(CreateVoxelJob other)
		{
			if (object.Equals(Building, other.Building) && IsWallish == other.IsWallish)
			{
				return Priority == other.Priority;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is CreateVoxelJob other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Building, IsWallish, Priority);
		}
	}
}
