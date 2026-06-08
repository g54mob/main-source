using System.Collections.Generic;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.Coordinates;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	public class SluiceSynchronizer
	{
		private static readonly Vector3Int[] Neighbors = new Vector3Int[2]
		{
			new Vector3Int(-1, 0, 0),
			new Vector3Int(1, 0, 0)
		};

		private readonly IBlockService _blockService;

		private readonly Queue<SluiceState> _neighborsQueue = new Queue<SluiceState>();

		private readonly HashSet<SluiceState> _visitedNeighbors = new HashSet<SluiceState>();

		public SluiceSynchronizer(IBlockService blockService)
		{
			_blockService = blockService;
		}

		public void SynchronizeNeighbors(SluiceState startingSluice)
		{
			EnqueueSluice(startingSluice);
			while (!_neighborsQueue.IsEmpty())
			{
				SluiceState sluiceState = _neighborsQueue.Dequeue();
				BlockObject component = sluiceState.GetComponent<BlockObject>();
				Vector3Int[] neighbors = Neighbors;
				foreach (Vector3Int coordinates in neighbors)
				{
					SynchronizeNeighbor(sluiceState, component.TransformCoordinates(coordinates), component.Orientation);
				}
			}
			_visitedNeighbors.Clear();
		}

		public void SynchronizeWithNeighbors(SluiceState sluice)
		{
			BlockObject component = sluice.GetComponent<BlockObject>();
			Vector3Int[] neighbors = Neighbors;
			foreach (Vector3Int coordinates in neighbors)
			{
				Vector3Int coordinates2 = component.TransformCoordinates(coordinates);
				SluiceState sluice2 = GetSluice(coordinates2, component.Orientation);
				if (sluice2 != null)
				{
					SynchronizeNeighbors(sluice2);
					break;
				}
			}
		}

		private void SynchronizeNeighbor(SluiceState currentState, Vector3Int neighborCoords, Orientation orientation)
		{
			SluiceState sluice = GetSluice(neighborCoords, orientation);
			if ((bool)sluice && !_visitedNeighbors.Contains(sluice))
			{
				Sluice component = sluice.GetComponent<Sluice>();
				sluice.SetState(currentState, component.MinHeight - component.MaxHeight);
				EnqueueSluice(sluice);
			}
		}

		private void EnqueueSluice(SluiceState sluice)
		{
			_neighborsQueue.Enqueue(sluice);
			_visitedNeighbors.Add(sluice);
		}

		private SluiceState GetSluice(Vector3Int coordinates, Orientation orientation)
		{
			SluiceState bottomObjectComponentAt = _blockService.GetBottomObjectComponentAt<SluiceState>(coordinates);
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
