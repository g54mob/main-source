using System.Collections.Generic;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class TileData : IPersistable
	{
		public enum Direction
		{
			Left = 0,
			Right = 1,
			Down = 2,
			Up = 3
		}

		private int _indexCache;

		[JsonIgnore]
		private string _up;

		[JsonIgnore]
		private string _down;

		[JsonIgnore]
		private string _left;

		[JsonIgnore]
		private string _right;

		private List<string> _neighbours;

		private Dictionary<string, Dictionary<string, sbyte>> _activeAtmosphereEffects;

		internal Dictionary<string, sbyte> _levelEquilibriumModifiers;

		[JsonIgnore]
		private FrameCachedValue<float> _temperature;

		[JsonIgnore]
		private FrameCachedValue<float> _decor;

		[JsonIgnore]
		private FrameCachedValue<float> _brightness;

		[JsonIgnore]
		private FrameCachedValue<float> _filth;

		[JsonIgnore]
		private FrameCachedValue<float> _noise;

		[JsonIgnore]
		private bool _isUpTileSet;

		[JsonIgnore]
		private TileData _upTile;

		[JsonIgnore]
		private bool _isDownTileSet;

		[JsonIgnore]
		private TileData _downTile;

		[JsonIgnore]
		private bool _isLeftTileSet;

		[JsonIgnore]
		private TileData _leftTile;

		[JsonIgnore]
		private bool _isRightTileSet;

		[JsonIgnore]
		private TileData _rightTile;

		[JsonIgnore]
		public GameObject Visual { get; set; }

		[JsonIgnore]
		public GameObject LevelEditorVisual { get; set; }

		public int X { get; set; }

		public int Y { get; set; }

		public int Z { get; set; }

		[JsonIgnore]
		public Vector3Int GridPosition => default(Vector3Int);

		[JsonIgnore]
		public Vector3 WorldPosition => default(Vector3);

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsInside { get; set; }

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string Up
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string Down
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string Left
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string Right
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public List<string> Neighbours => null;

		[JsonIgnore]
		public int WallCount { get; private set; }

		public int RoomId { get; set; }

		public string Zone { get; set; }

		[JsonIgnore]
		public float Temperature => 0f;

		[JsonIgnore]
		public float Decor => 0f;

		[JsonIgnore]
		public float Brightness => 0f;

		[JsonIgnore]
		public float Filth => 0f;

		[JsonIgnore]
		public float Noise => 0f;

		[JsonIgnore]
		public TileData UpTile => null;

		[JsonIgnore]
		public TileData DownTile => null;

		[JsonIgnore]
		public TileData LeftTile => null;

		[JsonIgnore]
		public TileData RightTile => null;

		protected TileData()
		{
		}

		public TileData(int x, int y, int z)
		{
		}

		public int GetIndexInFlatTileArray()
		{
			return 0;
		}

		public void SetIndexCache(int index)
		{
		}

		public bool IsInsideAnUnlockedRoom()
		{
			return false;
		}

		private void InvalidateWallCountAndNeighbours()
		{
		}

		private void InvalidateNeighbourInfos()
		{
		}

		public Room GetRoom()
		{
			return null;
		}

		public float GetEffectValue(string effectName)
		{
			return 0f;
		}

		public void SetEquilibrium(string effect, sbyte value)
		{
		}

		public void SetAtmosphereEffect(GameObjectX source, string effect, sbyte value)
		{
		}

		public void SetAtmosphereEffect(string sourceId, string effect, sbyte value)
		{
		}

		public void RemoveAtmosphereEffect(GameObjectX source, string effect)
		{
		}

		public void RemoveAtmosphereEffect(string sourceId, string effect)
		{
		}

		public void TransferEffectsToOtherTile(GameObjectX source, TileData newTile, Dictionary<string, sbyte> target = null)
		{
		}

		public void ClearAtmosphereEffect(GameObjectX source)
		{
		}

		public void ClearAtmosphereEffect(string sourceId)
		{
		}

		private void UpdateAtmosphereOutputs()
		{
		}

		public Bounds GetTileBounds()
		{
			return default(Bounds);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static Direction GetOppositeDirection(Direction direction)
		{
			return default(Direction);
		}

		public void Set(Direction direction, string value)
		{
		}

		public bool IsInsideLockedRoom()
		{
			return false;
		}
	}
}
