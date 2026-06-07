using System.Collections.Generic;
using Server;

namespace Motorways.Models
{
	public class BoatPathModel : Model<EmptyModelFrame, BoatPathModel.IObserver>
	{
		public interface IObserver
		{
		}

		private readonly List<BoatModel> _boats = new List<BoatModel>();

		private readonly List<BoatPathTileModel> _tiles = new List<BoatPathTileModel>();

		private readonly List<BoatPathTileModel> _boatSpawnTiles = new List<BoatPathTileModel>();

		private bool _isLoop;

		private BoatPathTileModel _startTile;

		private BoatPathTileModel _endTile;

		public int BoatCount => _boats.Count;

		public bool IsLoop => _isLoop;

		public BoatPathTileModel StartTile => _startTile;

		public BoatPathTileModel EndTile => _endTile;

		public List<BoatPathTileModel> BoatSpawnTiles => _boatSpawnTiles;

		public BoatPathTileModel GetTrackAtIndex(int index)
		{
			return _tiles[index];
		}

		public void Initialize(bool isLoop)
		{
			_isLoop = isLoop;
		}

		public void AddTile(BoatPathTileModel boatPathTileModel, BoatPathType boatPathType)
		{
			boatPathTileModel.BoatPath = this;
			_tiles.Add(boatPathTileModel);
			BoatPathTileConnection boatPathConnection = boatPathTileModel.TileModel.Tile.BoatPathConnection;
			if (boatPathConnection.input == TileDirection.None)
			{
				_startTile = boatPathTileModel;
			}
			if (boatPathConnection.output == TileDirection.None)
			{
				_endTile = boatPathTileModel;
			}
			if (boatPathType == BoatPathType.BoatOrigin)
			{
				_boatSpawnTiles.Add(boatPathTileModel);
			}
		}

		public void AddBoat(BoatModel boatModel)
		{
			_boats.Add(boatModel);
		}

		public override void Reset()
		{
			base.Reset();
			_boats.Clear();
			_tiles.Clear();
			_boatSpawnTiles.Clear();
			_isLoop = false;
			_startTile = null;
			_endTile = null;
		}

		public BoatPathModel()
			: base(1)
		{
		}
	}
}
