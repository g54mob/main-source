using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	public class TrainNetworkDefinition
	{
		private readonly List<TrainLineDefinition> _trainLines = new List<TrainLineDefinition>();

		public IReadOnlyList<TrainLineDefinition> TrainLines => _trainLines;

		public TrainLineDefinition CreateTrainLine()
		{
			TrainLineDefinition trainLineDefinition = new TrainLineDefinition();
			_trainLines.Add(trainLineDefinition);
			return trainLineDefinition;
		}

		public static TrainNetworkDefinition CreateFromRailTileCoordinates(Dictionary<Vector2Int, RailType> railTileCoordinates)
		{
			TrainNetworkDefinition trainNetworkDefinition = new TrainNetworkDefinition();
			Dictionary<Vector2Int, bool> dictionary = new Dictionary<Vector2Int, bool>();
			foreach (Vector2Int key3 in railTileCoordinates.Keys)
			{
				dictionary.Add(key3, value: false);
			}
			Stack<Vector2Int> stack = new Stack<Vector2Int>();
			while (true)
			{
				Vector2Int? vector2Int = FindNextTileToStartSearchFrom(railTileCoordinates, dictionary);
				if (!vector2Int.HasValue)
				{
					break;
				}
				stack.Push(vector2Int.Value);
				TrainLineDefinition trainLineDefinition = trainNetworkDefinition.CreateTrainLine();
				while (stack.Count > 0)
				{
					Vector2Int vector2Int2 = stack.Pop();
					if (dictionary[vector2Int2])
					{
						continue;
					}
					dictionary[vector2Int2] = true;
					trainLineDefinition.AddTrack(new Vector2Int(vector2Int2.x, vector2Int2.y), railTileCoordinates[vector2Int2]);
					int num = 0;
					int num2 = 0;
					TileDirection[] nonDiagonalDirections = TileUtilities.NonDiagonalDirections;
					for (int i = 0; i < nonDiagonalDirections.Length; i++)
					{
						Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(nonDiagonalDirections[i]);
						Vector2Int vector2Int3 = new Vector2Int(vector2Int2.x + adjacencyOffsetForDirection.x, vector2Int2.y + adjacencyOffsetForDirection.y);
						if (railTileCoordinates.ContainsKey(vector2Int3))
						{
							num2++;
							if (dictionary[vector2Int3])
							{
								num++;
							}
							else
							{
								stack.Push(vector2Int3);
							}
						}
					}
					nonDiagonalDirections = TileUtilities.DiagonalDirections;
					foreach (TileDirection direction in nonDiagonalDirections)
					{
						Vector2Int adjacencyOffsetForDirection2 = TileUtilities.GetAdjacencyOffsetForDirection(direction);
						Vector2Int vector2Int4 = new Vector2Int(vector2Int2.x + adjacencyOffsetForDirection2.x, vector2Int2.y + adjacencyOffsetForDirection2.y);
						if (!railTileCoordinates.ContainsKey(vector2Int4))
						{
							continue;
						}
						TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(direction, -1);
						TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(direction, 1);
						Vector2Int adjacencyOffsetForDirection3 = TileUtilities.GetAdjacencyOffsetForDirection(rotatedDirection);
						Vector2Int adjacencyOffsetForDirection4 = TileUtilities.GetAdjacencyOffsetForDirection(rotatedDirection2);
						Vector2Int key = vector2Int2 + adjacencyOffsetForDirection3;
						Vector2Int key2 = vector2Int2 + adjacencyOffsetForDirection4;
						bool num3 = railTileCoordinates.ContainsKey(key);
						bool flag = railTileCoordinates.ContainsKey(key2);
						if (!num3 && !flag)
						{
							num2++;
							if (dictionary[vector2Int4])
							{
								num++;
							}
							else
							{
								stack.Push(vector2Int4);
							}
						}
					}
					trainLineDefinition.isLoop = num == 2;
					trainLineDefinition.isValid = num2 <= 2;
				}
			}
			return trainNetworkDefinition;
		}

		private static Vector2Int? FindNextTileToStartSearchFrom(Dictionary<Vector2Int, RailType> tilemap, Dictionary<Vector2Int, bool> visitedTiles)
		{
			foreach (KeyValuePair<Vector2Int, bool> visitedTile in visitedTiles)
			{
				if (visitedTile.Value)
				{
					continue;
				}
				Vector2Int key = visitedTile.Key;
				int num = 0;
				TileDirection[] nonDiagonalDirections = TileUtilities.NonDiagonalDirections;
				for (int i = 0; i < nonDiagonalDirections.Length; i++)
				{
					Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(nonDiagonalDirections[i]);
					Vector2Int key2 = new Vector2Int(key.x + adjacencyOffsetForDirection.x, key.y + adjacencyOffsetForDirection.y);
					if (tilemap.ContainsKey(key2))
					{
						num++;
					}
					if (num >= 2)
					{
						break;
					}
				}
				if (num > 1)
				{
					continue;
				}
				nonDiagonalDirections = TileUtilities.DiagonalDirections;
				foreach (TileDirection direction in nonDiagonalDirections)
				{
					Vector2Int adjacencyOffsetForDirection2 = TileUtilities.GetAdjacencyOffsetForDirection(direction);
					Vector2Int key3 = new Vector2Int(key.x + adjacencyOffsetForDirection2.x, key.y + adjacencyOffsetForDirection2.y);
					if (tilemap.ContainsKey(key3))
					{
						TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(direction, -1);
						TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(direction, 1);
						Vector2Int adjacencyOffsetForDirection3 = TileUtilities.GetAdjacencyOffsetForDirection(rotatedDirection);
						Vector2Int adjacencyOffsetForDirection4 = TileUtilities.GetAdjacencyOffsetForDirection(rotatedDirection2);
						Vector2Int key4 = new Vector2Int(key.x + adjacencyOffsetForDirection3.x, key.y + adjacencyOffsetForDirection3.y);
						Vector2Int key5 = new Vector2Int(key.x + adjacencyOffsetForDirection4.x, key.y + adjacencyOffsetForDirection4.y);
						bool num2 = tilemap.ContainsKey(key4);
						bool flag = tilemap.ContainsKey(key5);
						if (!num2 && !flag)
						{
							num++;
						}
					}
				}
				if (num <= 1)
				{
					return visitedTile.Key;
				}
			}
			foreach (KeyValuePair<Vector2Int, bool> visitedTile2 in visitedTiles)
			{
				if (!visitedTile2.Value)
				{
					return visitedTile2.Key;
				}
			}
			return null;
		}
	}
}
