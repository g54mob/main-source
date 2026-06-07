using System.Linq;
using Data.Operator;
using NaughtyAttributes;
using UnityEngine;

namespace Data.FactoryFloor.Islands
{
	[CreateAssetMenu(menuName = "Factory/EnvironmentBrushData", fileName = "EnvironmentBrushData", order = 0)]
	public class EnvironmentBrushData : ScriptableObject
	{
		[SerializeField]
		private EnvironmentColorIDs.FloorType _floorType;

		[SerializeField]
		private EnvironmentColorIDs.FloorType _surroundingFloorType;

		[SerializeField]
		private bool _paintHeight;

		[SerializeField]
		private bool _paintOutside = true;

		[SerializeField]
		private BrushTile[] _tiles;

		[field: SerializeField]
		public Color BoxColor { get; private set; }

		public Color FloorColor => EnvironmentColorIDs.GetColor(_floorType);

		public Color HeightColor => EnvironmentColorIDs.GetColor(EnvironmentColorIDs.FloorType.ElevatedGrass);

		public Color OutsideColor => EnvironmentColorIDs.GetColor(_surroundingFloorType);

		public bool PaintHeight => _paintHeight;

		public bool PaintOutside => _paintOutside;

		[field: SerializeField]
		[field: ReadOnly]
		public int ID { get; internal set; } = -1;

		public void Initialize()
		{
			BrushTile[] tiles = _tiles;
			for (int i = 0; i < tiles.Length; i++)
			{
				tiles[i].Initialize();
			}
		}

		public FactoryObjectData GetTileForGrid(int[] waterGrid, out int rotation, out int matchId)
		{
			BrushTile[] tiles = _tiles;
			foreach (BrushTile brushTile in tiles)
			{
				if (brushTile.Matches(waterGrid, out rotation))
				{
					matchId = brushTile.ID;
					return brushTile.GetEnvironmentObject();
				}
			}
			rotation = 0;
			matchId = -1;
			return null;
		}

		public bool IsTilePartOfBrush(int id)
		{
			return _tiles.Any((BrushTile x) => x.HasId(id));
		}
	}
}
