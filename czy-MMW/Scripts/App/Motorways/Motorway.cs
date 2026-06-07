using System;
using Factory;
using Factory.Pools;
using FixMath;
using UnityEngine;

namespace Motorways
{
	public class Motorway : IReleasedFromScopeHandler, IReusable
	{
		[Flags]
		public enum ChangeFlags
		{
			Number = 1,
			State = 2,
			StartTile = 4,
			EndTile = 8,
			Concrete = 0x10,
			Permanence = 0x20
		}

		public interface IObserver
		{
			void OnMotorwayChanged(Motorway motorway, ChangeFlags changes);
		}

		public const int InvalidMotorwayId = -1;

		public const int InvalidMotorwayNumber = 0;

		private ITilemap _tilemap;

		private int _id = -1;

		private int _number;

		private RoadState _state;

		private Vector2Int _startCoordinates;

		private TileDirection _startDirection;

		private Vector2Int _endCoordinates;

		private TileDirection _endDirection;

		private int _concreteCost;

		private int _concreteGivenToReplacement;

		private Fix64 _permanenceProgress = Fix64.Zero;

		[Serialize(false, null)]
		private ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		public Fix64 PermanenceProgress
		{
			get
			{
				return _permanenceProgress;
			}
			protected set
			{
				if (_permanenceProgress != value)
				{
					_permanenceProgress = value;
					if (_permanenceProgress > Fix64.One)
					{
						_permanenceProgress = Fix64.One;
					}
					NotifyMotorwayChanged(ChangeFlags.Permanence);
				}
			}
		}

		public ITilemap Tilemap => _tilemap;

		public int Id
		{
			get
			{
				return _id;
			}
			private set
			{
				_id = value;
			}
		}

		public int Number => _number;

		public RoadState State => _state;

		public Vector2Int StartCoordinates
		{
			get
			{
				return _startCoordinates;
			}
			set
			{
				if (_startCoordinates != value)
				{
					_startCoordinates = value;
					NotifyMotorwayChanged(ChangeFlags.StartTile);
				}
			}
		}

		public TileDirection StartDirection
		{
			get
			{
				return _startDirection;
			}
			set
			{
				if (_startDirection != value)
				{
					_startDirection = value;
					NotifyMotorwayChanged(ChangeFlags.StartTile);
				}
			}
		}

		public Vector2Int EndCoordinates
		{
			get
			{
				return _endCoordinates;
			}
			set
			{
				if (_endCoordinates != value)
				{
					_endCoordinates = value;
					NotifyMotorwayChanged(ChangeFlags.EndTile);
				}
			}
		}

		public TileDirection EndDirection
		{
			get
			{
				return _endDirection;
			}
			set
			{
				if (_endDirection != value)
				{
					_endDirection = value;
					NotifyMotorwayChanged(ChangeFlags.EndTile);
				}
			}
		}

		public int ConcreteCost
		{
			get
			{
				return _concreteCost;
			}
			set
			{
				if (_concreteCost != value)
				{
					_concreteCost = value;
					NotifyMotorwayChanged(ChangeFlags.Concrete);
				}
			}
		}

		public int ConcreteGivenToReplacement
		{
			get
			{
				return _concreteGivenToReplacement;
			}
			set
			{
				if (_concreteGivenToReplacement != value)
				{
					_concreteGivenToReplacement = value;
					NotifyMotorwayChanged(ChangeFlags.Concrete);
				}
			}
		}

		public bool IsPermanent => _permanenceProgress >= Fix64.One;

		public void SetPermanence(Fix64 permanence)
		{
			PermanenceProgress = permanence;
		}

		public virtual bool Initialize(ITilemap tilemap, int id, int number, RoadState roadState = RoadState.None)
		{
			if (!Diagnostics.Verify(_id == -1, "Motorway does not have an uninitialised id."))
			{
				return false;
			}
			if (!Diagnostics.Verify(number != 0, "Motorway must have valid number when initialized"))
			{
				return false;
			}
			_tilemap = tilemap;
			_id = id;
			_number = number;
			_state = roadState;
			_startCoordinates = new Vector2Int(0, 0);
			_startDirection = TileDirection.None;
			_endCoordinates = new Vector2Int(0, 0);
			_endDirection = TileDirection.None;
			_concreteCost = 0;
			_concreteGivenToReplacement = 0;
			return true;
		}

		public virtual void Reset()
		{
			_tilemap = null;
			_id = -1;
			_number = 0;
			_state = RoadState.None;
			_startCoordinates = default(Vector2Int);
			_startDirection = TileDirection.North;
			_endCoordinates = default(Vector2Int);
			_endDirection = TileDirection.North;
			_concreteCost = 0;
			_concreteGivenToReplacement = 0;
			_permanenceProgress = Fix64.Zero;
		}

		public virtual void OnReleasedFromScope(IScope scope)
		{
			_observers.UnsubscribeAll();
		}

		public bool CanSetState(RoadState newState)
		{
			switch (newState)
			{
			case RoadState.None:
				if (_state != RoadState.Mothballed && _state != RoadState.Planned)
				{
					return false;
				}
				break;
			case RoadState.Planned:
				if (_state != RoadState.None)
				{
					return false;
				}
				break;
			case RoadState.Active:
				if (_state != RoadState.Planned && _state != RoadState.Mothballed)
				{
					return false;
				}
				break;
			case RoadState.Mothballed:
				if ((_state & (RoadState.Planned | RoadState.Active)) == 0)
				{
					return false;
				}
				break;
			}
			return true;
		}

		public bool SetState(RoadState newState)
		{
			if (!CanSetState(newState))
			{
				return false;
			}
			if (_state == RoadState.Planned && newState == RoadState.Mothballed)
			{
				_state = RoadState.None;
			}
			else
			{
				if (newState == RoadState.Planned && _state == RoadState.Mothballed)
				{
					_permanenceProgress = Fix64.Zero;
				}
				_state = newState;
			}
			NotifyMotorwayChanged(ChangeFlags.State);
			return true;
		}

		public void CloneInto(Motorway cloneMotorway)
		{
			ChangeFlags changeFlags = (ChangeFlags)0;
			if (cloneMotorway._state != _state)
			{
				cloneMotorway._state = _state;
				changeFlags |= ChangeFlags.State;
			}
			if (cloneMotorway._number != _number)
			{
				cloneMotorway._number = _number;
				changeFlags |= ChangeFlags.Number;
			}
			if (cloneMotorway._startCoordinates != _startCoordinates)
			{
				cloneMotorway._startCoordinates = _startCoordinates;
				changeFlags |= ChangeFlags.StartTile;
			}
			if (cloneMotorway._startDirection != _startDirection)
			{
				cloneMotorway._startDirection = _startDirection;
				changeFlags |= ChangeFlags.StartTile;
			}
			if (cloneMotorway._endCoordinates != _endCoordinates)
			{
				cloneMotorway._endCoordinates = _endCoordinates;
				changeFlags |= ChangeFlags.EndTile;
			}
			if (cloneMotorway._endDirection != _endDirection)
			{
				cloneMotorway._endDirection = _endDirection;
				changeFlags |= ChangeFlags.EndTile;
			}
			if (cloneMotorway._concreteCost != _concreteCost)
			{
				cloneMotorway._concreteCost = _concreteCost;
				changeFlags |= ChangeFlags.Concrete;
			}
			if (cloneMotorway._concreteGivenToReplacement != _concreteGivenToReplacement)
			{
				cloneMotorway._concreteGivenToReplacement = _concreteGivenToReplacement;
				changeFlags |= ChangeFlags.Concrete;
			}
			if (cloneMotorway._permanenceProgress != _permanenceProgress)
			{
				cloneMotorway._permanenceProgress = _permanenceProgress;
				changeFlags |= ChangeFlags.Permanence;
			}
			if (changeFlags != 0)
			{
				cloneMotorway.NotifyMotorwayChanged(changeFlags);
			}
		}

		public void Clear()
		{
			_state = RoadState.None;
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		private void NotifyMotorwayChanged(ChangeFlags changes)
		{
			ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnMotorwayChanged(this, changes);
			}
		}
	}
}
