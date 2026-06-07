using System;
using System.Collections.Generic;
using PajamaLlama.Enums;
using UnityEngine;

namespace PajamaLlama.Flotsam.Landmarks.Generator
{
	[CreateAssetMenu(fileName = "LandmarkRoadTileset", menuName = "Flotsam/Landmarks/Assets/Road Tileset")]
	public class LandmarkRoadTileset : LandmarkTilesetBase
	{
		[Serializable]
		public struct JunctionRotation
		{
			[EnumFlag(1)]
			public CardinalDirectionFlags DirectionFlags;

			public float Rotation;
		}

		public int RoadWidth = 4;

		[SerializeField]
		private LandmarkTilesetPrefab[] _roadPrefabs;

		[Header("Corners")]
		[SerializeField]
		private LandmarkTilesetPrefab _cornerPrefabs;

		[SerializeField]
		private JunctionRotation[] _cornerRotations;

		[Header("T-Junctions")]
		[SerializeField]
		private LandmarkTilesetPrefab _tJunctionPrefabs;

		[SerializeField]
		private JunctionRotation[] _tJunictioRotations;

		[Header("Cross-Junctions")]
		[SerializeField]
		private LandmarkTilesetPrefab _crossJunctionPrefabs;

		public override LandmarkCellType Type => LandmarkCellType.Road;

		public void ComputeRoadCellOrientation(LandmarkGrid landmarkGrid, IEnumerable<LandmarkCell> roadCells)
		{
			foreach (LandmarkCell roadCell in roadCells)
			{
				if (roadCell.RoadOrientation != HorizontalVerticalFlags.None)
				{
					continue;
				}
				int num = ReturnRoadSize(roadCell, 1);
				int num2 = ReturnRoadSize(roadCell, 3);
				if (num < RoadWidth || num2 < RoadWidth)
				{
					continue;
				}
				HorizontalVerticalFlags horizontalVerticalFlags;
				if (num == RoadWidth)
				{
					horizontalVerticalFlags = ((num2 != num) ? HorizontalVerticalFlags.Vertical : ((UnityEngine.Random.Range(0, 2) == 0) ? HorizontalVerticalFlags.Horizontal : HorizontalVerticalFlags.Vertical));
				}
				else
				{
					if (num2 != RoadWidth)
					{
						continue;
					}
					horizontalVerticalFlags = HorizontalVerticalFlags.Horizontal;
				}
				int num3;
				int num4;
				LandmarkCell landmarkCell;
				if (horizontalVerticalFlags == HorizontalVerticalFlags.Horizontal)
				{
					num3 = 3;
					num4 = 1;
					landmarkCell = landmarkGrid.ReturnCell(roadCell.RowPos, roadCell.ColumnPos - ReturnRoadSize(roadCell, 0, countQueryCell: false));
				}
				else
				{
					num3 = 1;
					num4 = 3;
					landmarkCell = landmarkGrid.ReturnCell(roadCell.RowPos - ReturnRoadSize(roadCell, 2, countQueryCell: false), roadCell.ColumnPos);
				}
				int num5 = 0;
				while (landmarkCell != null && landmarkCell.IsRoad && num5 < RoadWidth)
				{
					landmarkCell.AddRoadOrientation(horizontalVerticalFlags);
					LandmarkCell landmarkCell2 = landmarkCell.Neighbors[num4];
					while (landmarkCell2 != null && landmarkCell2.IsRoad)
					{
						landmarkCell2.AddRoadOrientation(horizontalVerticalFlags);
						landmarkCell2 = landmarkCell2.Neighbors[num4];
					}
					landmarkCell = landmarkCell.Neighbors[num3];
					num5++;
				}
			}
		}

		private int ReturnRoadSize(LandmarkCell cell, int direction, bool countQueryCell = true)
		{
			if (!cell.IsRoad)
			{
				return 0;
			}
			int num = (countQueryCell ? 1 : 0);
			LandmarkCell neighbor;
			while (cell.TryReturnNeighbor(out neighbor, direction) && neighbor.IsRoad)
			{
				num++;
				cell = neighbor;
			}
			return num;
		}

		public override bool TryReturnPrefab(LandmarkCell cell, out LandmarkTilesetPrefab prefab, out Quaternion rotation)
		{
			prefab = default(LandmarkTilesetPrefab);
			rotation = Quaternion.identity;
			if (cell.CellType != Type)
			{
				return false;
			}
			switch (cell.RoadOrientation)
			{
			case HorizontalVerticalFlags.Horizontal:
			{
				int length = ReturnRoadSegmentLength(cell, 1, cell.RoadOrientation);
				rotation = Quaternion.Euler(0f, 90f, 0f);
				return ReturnRoadPrefab(length, out prefab);
			}
			case HorizontalVerticalFlags.Vertical:
			{
				int length = ReturnRoadSegmentLength(cell, 3, cell.RoadOrientation);
				return ReturnRoadPrefab(length, out prefab);
			}
			case HorizontalVerticalFlags.Horizontal | HorizontalVerticalFlags.Vertical:
			{
				CardinalDirectionFlags directions;
				switch (ReturnJunctionCount(cell, out directions))
				{
				case 2:
					rotation = ReturnJunctionRotation(_cornerRotations, directions);
					prefab = _cornerPrefabs;
					return true;
				case 3:
					rotation = ReturnJunctionRotation(_tJunictioRotations, directions);
					prefab = _tJunctionPrefabs;
					return true;
				case 4:
					rotation = Quaternion.identity;
					prefab = _crossJunctionPrefabs;
					return true;
				}
				break;
			}
			}
			return false;
		}

		private int ReturnRoadSegmentLength(LandmarkCell cell, int neighborIndex, HorizontalVerticalFlags orientation)
		{
			int num = 1;
			LandmarkCell neighbor;
			while (cell.TryReturnNeighbor(out neighbor, neighborIndex) && neighbor.RoadOrientation == orientation)
			{
				num++;
				cell = neighbor;
			}
			return num;
		}

		private bool ReturnRoadPrefab(int length, out LandmarkTilesetPrefab prefab)
		{
			prefab = default(LandmarkTilesetPrefab);
			using (ListPool<LandmarkTilesetPrefab>.List list = ListPool<LandmarkTilesetPrefab>.Get())
			{
				LandmarkTilesetPrefab[] roadPrefabs = _roadPrefabs;
				for (int i = 0; i < roadPrefabs.Length; i++)
				{
					LandmarkTilesetPrefab item = roadPrefabs[i];
					if (item.Length <= length)
					{
						list.Add(item);
					}
				}
				if (list.Count == 0)
				{
					return false;
				}
				prefab = list[UnityEngine.Random.Range(0, list.Count)];
			}
			return true;
		}

		private int ReturnJunctionCount(LandmarkCell cell, out CardinalDirectionFlags directions)
		{
			int num = 0;
			directions = CardinalDirectionFlags.None;
			if (ReturnNeighborOrientationAtDistance(cell, 2, 1) == HorizontalVerticalFlags.Vertical)
			{
				num++;
				directions |= CardinalDirectionFlags.North;
			}
			if (ReturnNeighborOrientationAtDistance(cell, 1, RoadWidth) == HorizontalVerticalFlags.Horizontal)
			{
				num++;
				directions |= CardinalDirectionFlags.East;
			}
			if (ReturnNeighborOrientationAtDistance(cell, 3, RoadWidth) == HorizontalVerticalFlags.Vertical)
			{
				num++;
				directions |= CardinalDirectionFlags.South;
			}
			if (ReturnNeighborOrientationAtDistance(cell, 0, 1) == HorizontalVerticalFlags.Horizontal)
			{
				num++;
				directions |= CardinalDirectionFlags.West;
			}
			return num;
		}

		private Quaternion ReturnJunctionRotation(JunctionRotation[] rotations, CardinalDirectionFlags directionFlags)
		{
			for (int i = 0; i < rotations.Length; i++)
			{
				JunctionRotation junctionRotation = rotations[i];
				if (junctionRotation.DirectionFlags == directionFlags)
				{
					return Quaternion.Euler(0f, junctionRotation.Rotation, 0f);
				}
			}
			Debug.LogWarningFormat("No rotation found for directions '{0}'!", directionFlags);
			return Quaternion.identity;
		}

		private HorizontalVerticalFlags ReturnNeighborOrientationAtDistance(LandmarkCell cell, int neighborIndex, int distance)
		{
			LandmarkCell neighbor = null;
			int num = 0;
			while (num < distance && cell.TryReturnNeighbor(out neighbor, neighborIndex))
			{
				if (neighbor.CellType == LandmarkCellType.Road)
				{
					num++;
					cell = neighbor;
					continue;
				}
				return HorizontalVerticalFlags.None;
			}
			if (num < distance)
			{
				return HorizontalVerticalFlags.None;
			}
			return neighbor.RoadOrientation;
		}
	}
}
