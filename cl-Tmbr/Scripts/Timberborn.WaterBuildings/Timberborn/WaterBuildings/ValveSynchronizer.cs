using System.Collections.Generic;
using Timberborn.Automation;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.Coordinates;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	internal class ValveSynchronizer
	{
		private static readonly Vector3Int[] Neighbors = new Vector3Int[2]
		{
			new Vector3Int(-1, 0, 0),
			new Vector3Int(1, 0, 0)
		};

		private readonly IBlockService _blockService;

		private readonly Queue<Valve> _neighborsQueue = new Queue<Valve>();

		private readonly HashSet<Valve> _visitedNeighbors = new HashSet<Valve>();

		public ValveSynchronizer(IBlockService blockService)
		{
			_blockService = blockService;
		}

		public void SynchronizeAllNeighbors(Valve valve)
		{
			SynchronizeNeighbors(valve, unfinishedOnly: false);
		}

		public void SynchronizeWithAllNeighbors(Valve valve)
		{
			if (valve.IsSynchronized)
			{
				SynchronizeWithNeighbors(valve, unfinishedOnly: false);
			}
		}

		public void SynchronizeWithUnfinishedNeighbors(Valve valve)
		{
			if (valve.IsSynchronized)
			{
				SynchronizeWithNeighbors(valve, unfinishedOnly: true);
			}
		}

		private void SynchronizeNeighbors(Valve startingValve, bool unfinishedOnly)
		{
			if (!startingValve.IsSynchronized)
			{
				return;
			}
			EnqueueValve(startingValve);
			while (!_neighborsQueue.IsEmpty())
			{
				Valve valve = _neighborsQueue.Dequeue();
				BlockObject component = valve.GetComponent<BlockObject>();
				Vector3Int[] neighbors = Neighbors;
				foreach (Vector3Int coordinates in neighbors)
				{
					SynchronizeNeighbor(valve, component.TransformCoordinates(coordinates), component.Orientation, unfinishedOnly);
				}
			}
			_visitedNeighbors.Clear();
		}

		private void SynchronizeWithNeighbors(Valve valve, bool unfinishedOnly)
		{
			BlockObject component = valve.GetComponent<BlockObject>();
			Vector3Int[] neighbors = Neighbors;
			foreach (Vector3Int coordinates in neighbors)
			{
				Vector3Int coordinates2 = component.TransformCoordinates(coordinates);
				Valve valve2 = GetValve(coordinates2, component.Orientation);
				if (valve2 != null)
				{
					SynchronizeNeighbors(valve2, unfinishedOnly);
					break;
				}
			}
		}

		private void SynchronizeNeighbor(Valve sourceValve, Vector3Int neighborCoords, Orientation orientation, bool unfinishedOnly)
		{
			Valve valve = GetValve(neighborCoords, orientation);
			if ((bool)valve && !_visitedNeighbors.Contains(valve))
			{
				BlockObject component = valve.GetComponent<BlockObject>();
				if (!unfinishedOnly || !component.IsFinished)
				{
					valve.SetOutflowLimit(sourceValve.OutflowLimit);
					valve.SetOutflowLimitEnabled(sourceValve.OutflowLimitEnabled);
					valve.SetAutomationOutflowLimit(sourceValve.AutomationOutflowLimit);
					valve.SetAutomationOutflowLimitEnabled(sourceValve.AutomationOutflowLimitEnabled);
					valve.SetReactionSpeed(sourceValve.ReactionSpeed);
					Automatable component2 = sourceValve.GetComponent<Automatable>();
					valve.GetComponent<Automatable>().SetInput(component2.Input);
					EnqueueValve(valve);
				}
			}
		}

		private void EnqueueValve(Valve valve)
		{
			_neighborsQueue.Enqueue(valve);
			_visitedNeighbors.Add(valve);
		}

		private Valve GetValve(Vector3Int coordinates, Orientation orientation)
		{
			Valve bottomObjectComponentAt = _blockService.GetBottomObjectComponentAt<Valve>(coordinates);
			if ((bool)bottomObjectComponentAt && bottomObjectComponentAt.IsSynchronized)
			{
				BlockObject component = bottomObjectComponentAt.GetComponent<BlockObject>();
				if (component.Orientation == orientation && component.Coordinates == coordinates)
				{
					return bottomObjectComponentAt;
				}
			}
			return null;
		}
	}
}
