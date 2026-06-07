using System.Collections.Generic;
using Server;

namespace Motorways.Models
{
	public class TrainLineModel : Model<EmptyModelFrame, TrainLineModel.IObserver>
	{
		public interface IObserver
		{
		}

		private readonly List<TrainModel> _trains = new List<TrainModel>();

		private readonly List<RailTileModel> _tiles = new List<RailTileModel>();

		private readonly List<RailTileModel> _trainSpawnTiles = new List<RailTileModel>();

		private bool _isLoop;

		private RailTileModel _startTile;

		private RailTileModel _endTile;

		public int TrainCount => _trains.Count;

		public bool IsLoop => _isLoop;

		public RailTileModel StartTile => _startTile;

		public RailTileModel EndTile => _endTile;

		public List<RailTileModel> TrainSpawnTiles => _trainSpawnTiles;

		public RailTileModel GetTrackAtIndex(int index)
		{
			return _tiles[index];
		}

		public void Initialize(bool isLoop)
		{
			_isLoop = isLoop;
		}

		public void AddTile(RailTileModel railTileModel, RailType type)
		{
			railTileModel.Line = this;
			_tiles.Add(railTileModel);
			RailTileConnection railConnection = railTileModel.TileModel.Tile.RailConnection;
			if (railConnection.input == TileDirection.None)
			{
				_startTile = railTileModel;
			}
			if (railConnection.output == TileDirection.None)
			{
				_endTile = railTileModel;
			}
			if (type == RailType.TrainOrigin)
			{
				_trainSpawnTiles.Add(railTileModel);
			}
		}

		public void AddTrain(TrainModel trainModel)
		{
			_trains.Add(trainModel);
		}

		public override void Reset()
		{
			base.Reset();
			_trains.Clear();
			_tiles.Clear();
			_trainSpawnTiles.Clear();
			_isLoop = false;
			_startTile = null;
			_endTile = null;
		}

		public TrainLineModel()
			: base(1)
		{
		}
	}
}
