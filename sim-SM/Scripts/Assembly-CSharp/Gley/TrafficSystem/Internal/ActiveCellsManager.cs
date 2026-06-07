using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class ActiveCellsManager
	{
		private readonly GridDataHandler _gridDataHandler;

		private List<Vector2Int> _activeCells;

		private List<Vector2Int> _currentCells;

		internal ActiveCellsManager(NativeArray<float3> activeCameraPositions, GridDataHandler gridDataHandler, int level)
		{
		}

		internal void UpdateGrid(int level, NativeArray<float3> activeCameraPositions)
		{
		}

		private void UpdateActiveCells(NativeArray<float3> activeCameraPositions, int level)
		{
		}
	}
}
