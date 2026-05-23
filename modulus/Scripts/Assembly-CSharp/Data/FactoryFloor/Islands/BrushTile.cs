using System;
using System.Collections.Generic;
using Data.Operator;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Islands
{
	[Serializable]
	public class BrushTile
	{
		public enum Rotation
		{
			Fixed = 0,
			Rotate360 = 1
		}

		public enum TileType
		{
			Fixed = 0,
			Random = 1
		}

		[SerializeField]
		private FactoryObjectData _tile;

		[SerializeField]
		private Rotation _rotation = Rotation.Rotate360;

		[SerializeField]
		private TileType _tileType;

		[SerializeField]
		private TileChance[] _tileArray;

		[SerializeField]
		private int[] _neighbours = new int[9];

		private Dictionary<int, int[]> _options = new Dictionary<int, int[]>();

		private RandomNumberGenerator<FactoryObjectData> _randomNumberGenerator;

		[field: SerializeField]
		[field: ReadOnly]
		public int ID { get; internal set; } = -1;

		public void Initialize()
		{
			_options.Clear();
			_options.Add(0, _neighbours);
			if (_rotation == Rotation.Rotate360)
			{
				for (int i = 90; i < 360; i += 90)
				{
					_options.Add(i, GridUtils.Rotate3x3IntGrid(_neighbours, i));
				}
			}
			if (_tileType == TileType.Random)
			{
				_randomNumberGenerator = new RandomNumberGenerator<FactoryObjectData>();
				TileChance[] tileArray = _tileArray;
				foreach (TileChance tileChance in tileArray)
				{
					_randomNumberGenerator.Add(tileChance.Chance, tileChance.Tile);
				}
			}
		}

		public bool Matches(int[] neighbours, out int rotation)
		{
			rotation = 0;
			foreach (KeyValuePair<int, int[]> option in _options)
			{
				if (GridsAreEqual(option.Value, neighbours))
				{
					rotation = option.Key;
					return true;
				}
			}
			return false;
		}

		private static bool GridsAreEqual(int[] grid1, int[] grid2)
		{
			for (int i = 0; i < grid1.Length; i++)
			{
				if (grid1[i] != 0 && grid1[i] != grid2[i])
				{
					return false;
				}
			}
			return true;
		}

		public FactoryObjectData GetEnvironmentObject()
		{
			if (_tileType == TileType.Random)
			{
				return _randomNumberGenerator.NextItem();
			}
			return _tile;
		}

		public bool HasId(int id)
		{
			return _tile.ID == id;
		}
	}
}
