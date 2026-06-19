using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WorldEnvironment.Islands
{
	public class IslandWorldGrid : IIslandWorldGrid
	{
		public readonly int GridX;

		public readonly int GridY;

		private WorldGridParams _gridParams;

		private int[,] _islandGrid;

		public int[,] IslandGrid => _islandGrid;

		public WorldGridParams GridParams => _gridParams;

		public IslandWorldGrid(int gridX, int gridY, WorldGridParams gridParams)
		{
			GridX = gridX;
			GridY = gridY;
			_gridParams = gridParams;
			_islandGrid = new int[gridParams.GridSize, gridParams.GridSize];
		}

		public void GenerateIslandGrid(int worldSeed)
		{
			System.Random random = new System.Random(worldSeed + GridX * 73856093 + GridY * 19349663);
			for (int i = 0; i < _gridParams.GridSize; i++)
			{
				for (int j = 0; j < _gridParams.GridSize; j++)
				{
					float canLocateAnyType = (float)random.Next(0, 101) / 100f;
					List<IslandSpawnParams> source = _gridParams.IslandSpawnParams.Where((IslandSpawnParams islandSpawnParams2) => islandSpawnParams2.SpawnChance >= canLocateAnyType).ToList();
					if (source.Any())
					{
						float islandValue = (float)random.Next(0, 101) / 100f;
						List<IslandSpawnParams> source2 = source.Where((IslandSpawnParams islandSpawnParams2) => islandSpawnParams2.SpawnChance >= islandValue).ToList();
						if (source2.Any())
						{
							IslandSpawnParams islandSpawnParams = source2.OrderBy((IslandSpawnParams islandSpawnParams2) => Mathf.Abs(islandSpawnParams2.SpawnChance - islandValue)).First();
							_islandGrid[i, j] = (int)islandSpawnParams.Type;
						}
					}
					else
					{
						_islandGrid[i, j] = 0;
					}
					bool flag = GridX == 0 && GridY == 0;
					if (i == 2 && j == 2 && flag)
					{
						MarkMainIsland(i, j);
					}
				}
			}
		}

		public Vector3 GetCellWorldPos(int x, int y, Vector3 centerIslandWorldPos)
		{
			int gridSize = _gridParams.GridSize;
			int chunkSize = _gridParams.ChunkSize;
			Vector3 zero = Vector3.zero;
			zero.x = centerIslandWorldPos.x + (float)(-(2 - x) * chunkSize) + (float)(chunkSize * gridSize * GridX);
			zero.z = centerIslandWorldPos.z + (float)(-(2 - y) * chunkSize) + (float)(chunkSize * gridSize * GridY);
			return zero;
		}

		private void MarkMainIsland(int x, int y)
		{
			_islandGrid[x, y] = 1;
		}
	}
}
