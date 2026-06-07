using Factory;
using FixMath;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class TrainCrossingModel : Model<EmptyModelFrame, TrainCrossingModel.IObserver>
	{
		public interface IObserver
		{
			void OnSignalChanged(TrainSignalState trainSignalState);
		}

		[Dependency]
		private SimulationConstantsData _constants;

		private Tile? _tile;

		private RoadChunkModel _roadChunkModel;

		private TrainSignalState _signalState = TrainSignalState.Open;

		private bool _signalOpenRequested;

		private Fix64 _signalOpenRequestTime;

		public Tile? Tile => _tile;

		public RoadChunkModel RoadChunkModel => _roadChunkModel;

		public Vector2Int CrossingDirection { get; private set; }

		public TrainSignalState SignalState
		{
			get
			{
				return _signalState;
			}
			private set
			{
				if (value != _signalState)
				{
					_signalState = value;
					ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.OnSignalChanged(value);
					}
				}
			}
		}

		public void Initialize(Tile tile, RoadChunkModel roadChunkModel, Vector2Int trainCrossingDirection)
		{
			_tile = tile;
			_roadChunkModel = roadChunkModel;
			CrossingDirection = trainCrossingDirection;
			_signalState = TrainSignalState.Open;
		}

		public override void Reset()
		{
			base.Reset();
			CrossingDirection = Vector2Int.zero;
			_signalState = TrainSignalState.Open;
			_tile = null;
			_signalOpenRequested = false;
			_signalOpenRequestTime = default(Fix64);
			_roadChunkModel = null;
		}

		public void RequestSignalStateChange(TrainSignalState targetSignalState)
		{
			if (targetSignalState != _signalState && !_signalOpenRequested)
			{
				if (targetSignalState == TrainSignalState.Closed)
				{
					SignalState = TrainSignalState.Closed;
					return;
				}
				_signalOpenRequested = true;
				_signalOpenRequestTime = base.Clock.Time;
			}
		}

		public bool HasPendingSignalOpenRequestTimeElapsed()
		{
			if (!_signalOpenRequested)
			{
				return false;
			}
			return base.Clock.Time > _signalOpenRequestTime + _constants.crossingWaitTime;
		}

		public void CommitPendingSignalOpenRequest()
		{
			if (!_signalOpenRequested)
			{
				Diagnostics.FailAssert("No signal state change request pending!");
				return;
			}
			_signalOpenRequested = false;
			SignalState = TrainSignalState.Open;
		}

		public TrainCrossingModel()
			: base(1)
		{
		}
	}
}
