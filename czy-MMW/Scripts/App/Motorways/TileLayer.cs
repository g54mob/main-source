using System;
using System.Collections.Generic;
using System.Linq;
using Motorways.EdgeLoopOperator;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;

namespace Motorways
{
	public class TileLayer
	{
		private class BorderSegment : IEquatable<BorderSegment>
		{
			public readonly Vector3Int landTilePosition;

			public readonly Vector3Int borderNormal;

			public BorderSegment(Vector3Int landTilePosition, Vector3Int borderNormal)
			{
				this.landTilePosition = landTilePosition;
				this.borderNormal = borderNormal;
			}

			public bool Equals(BorderSegment other)
			{
				if (other == null)
				{
					return false;
				}
				if (this == other)
				{
					return true;
				}
				if (landTilePosition.Equals(other.landTilePosition))
				{
					return borderNormal.Equals(other.borderNormal);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (landTilePosition.GetHashCode() * 397) ^ borderNormal.GetHashCode();
			}
		}

		private class TileChunk : HashSet<Vector3Int>
		{
			public readonly HashSet<BorderSegment> allBorderSegments = new HashSet<BorderSegment>();
		}

		private static readonly Vector3Int[] Directions = new Vector3Int[4]
		{
			Vector3Int.up,
			Vector3Int.right,
			Vector3Int.down,
			Vector3Int.left
		};

		private static readonly Vector3Int[] DirectionsDiagonal = new Vector3Int[8]
		{
			Vector3Int.up,
			Vector3Int.right,
			Vector3Int.down,
			Vector3Int.left,
			new Vector3Int(1, 1, 0),
			new Vector3Int(1, -1, 0),
			new Vector3Int(-1, -1, 0),
			new Vector3Int(-1, 1, 0)
		};

		private readonly List<TileChunk> _tileChunks = new List<TileChunk>();

		private int _subdivisions;

		public static TileLayer FromTilemap(Tilemap tilemap, MapVisualGroupType tileGroupType, int trimEdge, int subdivisions)
		{
			TileLayer tileLayer = new TileLayer();
			tileLayer._subdivisions = subdivisions;
			SubdividableTilemap subdividableTilemap = new SubdividableTilemap(tilemap, subdivisions);
			HashSet<Vector3Int> hashSet = new HashSet<Vector3Int>();
			foreach (Vector3Int item in subdividableTilemap.AllPositionsWithin)
			{
				if (!IsSolid(subdividableTilemap, item, tileGroupType, trimEdge) || hashSet.Contains(item))
				{
					continue;
				}
				Queue<Vector3Int> queue = new Queue<Vector3Int>();
				queue.Enqueue(item);
				hashSet.Add(item);
				TileChunk tileChunk = new TileChunk();
				tileLayer._tileChunks.Add(tileChunk);
				while (queue.Any())
				{
					Vector3Int vector3Int = queue.Dequeue();
					tileChunk.Add(vector3Int);
					for (int i = 0; i < DirectionsDiagonal.Length; i++)
					{
						Vector3Int vector3Int2 = DirectionsDiagonal[i];
						Vector3Int vector3Int3 = vector3Int + vector3Int2;
						if (!IsSolid(subdividableTilemap, vector3Int3, tileGroupType, trimEdge))
						{
							if (i < 4)
							{
								tileChunk.allBorderSegments.Add(new BorderSegment(vector3Int, vector3Int2));
							}
						}
						else if (!hashSet.Contains(vector3Int3))
						{
							queue.Enqueue(vector3Int3);
							hashSet.Add(vector3Int3);
						}
					}
				}
			}
			return tileLayer;
		}

		private static bool IsSolid(SubdividableTilemap tilemap, Vector3Int position, MapVisualGroupType groupType, int trimEdge)
		{
			bool invert;
			switch (groupType)
			{
			case MapVisualGroupType.Land:
				invert = true;
				break;
			case MapVisualGroupType.Mountains:
				invert = false;
				break;
			default:
				Diagnostics.FailAssert($"Unsupported tile layer type: {groupType}");
				return false;
			}
			if (trimEdge == 0)
			{
				return CheckTilePosition(tilemap, position, invert);
			}
			Queue<(Vector3Int, int)> queue = new Queue<(Vector3Int, int)>();
			HashSet<Vector3Int> hashSet = new HashSet<Vector3Int>();
			queue.Enqueue((position, 0));
			hashSet.Add(position);
			while (queue.Count > 0)
			{
				var (vector3Int, num) = queue.Dequeue();
				if (!CheckTilePosition(tilemap, vector3Int, invert))
				{
					return false;
				}
				if (num >= trimEdge)
				{
					continue;
				}
				Vector3Int[] directionsDiagonal = DirectionsDiagonal;
				foreach (Vector3Int vector3Int2 in directionsDiagonal)
				{
					Vector3Int vector3Int3 = vector3Int + vector3Int2;
					if (!hashSet.Contains(vector3Int3))
					{
						queue.Enqueue((vector3Int3, num + 1));
						hashSet.Add(vector3Int3);
					}
				}
			}
			return true;
		}

		private static bool CheckTilePosition(SubdividableTilemap tilemap, Vector3Int position, bool invert)
		{
			if (invert)
			{
				if (tilemap.Contains(position))
				{
					return !tilemap.HasTile(position);
				}
				return false;
			}
			if (tilemap.Contains(position))
			{
				return tilemap.HasTile(position);
			}
			return false;
		}

		public List<EdgeLoop> BuildEdgeLoops(MapVisualGroupType visualGroupType, MapMeshLayer meshLayer)
		{
			List<EdgeLoop> list = new List<EdgeLoop>();
			foreach (TileChunk tileChunk in _tileChunks)
			{
				while (tileChunk.allBorderSegments.Any())
				{
					EdgeLoop edgeLoop = new EdgeLoop(visualGroupType, meshLayer);
					list.Add(edgeLoop);
					BorderSegment borderSegment = tileChunk.allBorderSegments.Last();
					Vector3Int vector3Int = borderSegment.landTilePosition;
					Vector3Int vector3Int2 = borderSegment.borderNormal;
					Vector3Int vector3Int3 = vector3Int2.RotateCW2D();
					Vector3Int vector3Int4 = vector3Int;
					Vector3Int vector3Int5 = vector3Int2;
					do
					{
						Vector3 vector = vector3Int + (Vector3)(vector3Int2 + vector3Int3) / 2f;
						tileChunk.allBorderSegments.Remove(new BorderSegment(vector3Int, vector3Int2));
						Vector3Int vector3Int6 = vector3Int + vector3Int2 + vector3Int3;
						Vector3Int vector3Int7 = vector3Int + vector3Int3;
						TopologyType topologyType;
						if (tileChunk.Contains(vector3Int6))
						{
							topologyType = TopologyType.Concave;
							vector3Int = vector3Int6;
							vector3Int3 = vector3Int3.RotateCCW2D();
							vector3Int2 = vector3Int2.RotateCCW2D();
						}
						else if (tileChunk.Contains(vector3Int7))
						{
							topologyType = TopologyType.Flat;
							vector3Int = vector3Int7;
						}
						else
						{
							topologyType = TopologyType.Convex;
							vector3Int3 = vector3Int3.RotateCW2D();
							vector3Int2 = vector3Int2.RotateCW2D();
						}
						if (_subdivisions == 2)
						{
							vector += new Vector3(-0.5f, -0.5f, 0f);
						}
						edgeLoop.AddPoint(vector / _subdivisions, topologyType);
					}
					while (vector3Int4 != vector3Int || vector3Int5 != vector3Int2);
				}
			}
			return list;
		}
	}
}
