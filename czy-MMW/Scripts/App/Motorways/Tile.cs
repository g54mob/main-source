using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways
{
	[Serializable(1)]
	public class Tile : IReusable
	{
		public enum MotorwayInclusion
		{
			Ignore = 0,
			Include = 1
		}

		public struct PassageInfo
		{
			private Tile _tile;

			public Passage passage;

			public bool IsStart => _tile.Coordinates == passage.StartCoordinates;

			public bool IsEnd => _tile.Coordinates == passage.EndCoordinates;

			public PassageInfo(Tile tile, Passage passage)
			{
				_tile = tile;
				this.passage = passage;
			}
		}

		public enum TileChangePermissions
		{
			Full = 0,
			RespectPermanence = 1
		}

		public interface IObserver
		{
			void OnTileChanged(Tile changedTile);
		}

		public static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Tile");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private GameBehaviourModel _behaviour;

		[Dependency]
		protected City _city;

		[Dependency]
		protected TilemapModel _tilemap;

		private bool _hasTrafficLight;

		private Fix64 _trafficLightPermanenceProgress = Fix64.Zero;

		private RailTileConnection _railConnection = RailTileConnection.InvalidConnection;

		private BoatPathTileConnection _boatPathConnection = BoatPathTileConnection.InvalidConnection;

		private bool _isCenterOfRoundabout;

		private Fix64 _roundaboutPermanenceProgress = Fix64.Zero;

		private readonly RoadState[] _twoLaneRoadState = new RoadState[8];

		private int _unbuiltMotorwayId = -1;

		private int _unbuiltMotorwayNumber;

		private TileDirection _plannedRoundaboutInput = TileDirection.None;

		private TileDirection _plannedRoundaboutOutput = TileDirection.None;

		private TileDirection _activeRoundaboutInput = TileDirection.None;

		private TileDirection _activeRoundaboutOutput = TileDirection.None;

		private TileDirection _mothballedRoundaboutInput = TileDirection.None;

		private TileDirection _mothballedRoundaboutOutput = TileDirection.None;

		private readonly int[] _plannedMotorways = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };

		private readonly int[] _activeMotorways = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };

		private readonly int[] _mothballedMotorways = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };

		private TileDirectionBitfield _isDirectionImmutable = TileDirectionBitfield.None;

		private readonly Fix64[] _nodePermanenceProgress = new Fix64[8];

		[Serialize(false, null)]
		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		[Serialize(true, null)]
		public ITilemap Tilemap { get; private set; }

		[Serialize(true, null)]
		public Vector2Int Coordinates { get; private set; }

		[Serialize(true, null)]
		public TileContentType ContentType { get; private set; }

		[Serialize(true, null)]
		public IModel ContentModel { get; private set; }

		public Fix64 TrafficLightPermanenceProgress => _trafficLightPermanenceProgress;

		public bool HasTrafficLight
		{
			get
			{
				return _hasTrafficLight;
			}
			set
			{
				if (_hasTrafficLight != value)
				{
					_hasTrafficLight = value;
					NotifyTileChanged();
				}
			}
		}

		public bool IsTrafficLightPermanent => _trafficLightPermanenceProgress >= Fix64.One;

		public bool HasRailConnection => _railConnection != RailTileConnection.InvalidConnection;

		public RailTileConnection RailConnection => _railConnection;

		public bool HasBoatPathConnection => _boatPathConnection != BoatPathTileConnection.InvalidConnection;

		public BoatPathTileConnection BoatPathConnection => _boatPathConnection;

		public bool IsCenterOfRoundabout
		{
			get
			{
				return _isCenterOfRoundabout;
			}
			set
			{
				if (_isCenterOfRoundabout != value)
				{
					_isCenterOfRoundabout = value;
					NotifyTileChanged();
				}
			}
		}

		public Fix64 RoundaboutPermanenceProgress => _roundaboutPermanenceProgress;

		public bool IsRoundaboutPermanent => _roundaboutPermanenceProgress >= Fix64.One;

		public int UnbuiltMotorwayId
		{
			get
			{
				return _unbuiltMotorwayId;
			}
			set
			{
				if (_unbuiltMotorwayId != value)
				{
					_unbuiltMotorwayId = value;
					NotifyTileChanged();
				}
			}
		}

		public int UnbuiltMotorwayNumber
		{
			get
			{
				return _unbuiltMotorwayNumber;
			}
			set
			{
				if (_unbuiltMotorwayNumber != value)
				{
					_unbuiltMotorwayNumber = value;
					NotifyTileChanged();
				}
			}
		}

		public TileDirection DrivewayDirection
		{
			get
			{
				if (!Diagnostics.Verify(ContentType == TileContentType.House || ContentType == TileContentType.Carpark, "It's a bit sketch requesting a driveway direction from something that's not a house."))
				{
					return TileDirection.None;
				}
				for (int i = 0; i < _twoLaneRoadState.Length; i++)
				{
					if ((_twoLaneRoadState[i] & RoadState.ActiveOrPending) != RoadState.None)
					{
						return (TileDirection)i;
					}
				}
				return TileDirection.None;
			}
		}

		public bool IsDrivewayOnly
		{
			get
			{
				if (GetTwoLaneRoadCount() != 1 || ContentType == TileContentType.Tree)
				{
					return false;
				}
				TileDirection connectedTileDirection = TileDirection.None;
				Tile adjacentConnectedTile = GetAdjacentConnectedTile(out connectedTileDirection, RoadState.ActiveOrPending, GetTwoLaneRoads(RoadState.Active, MotorwayInclusion.Include));
				if (adjacentConnectedTile.ContentType == TileContentType.None)
				{
					return false;
				}
				return TileUtilities.GetOppositeDirection(connectedTileDirection) == adjacentConnectedTile.DrivewayDirection;
			}
		}

		public bool IsDriveway
		{
			get
			{
				if (ContentType == TileContentType.Tree)
				{
					return false;
				}
				TileDirection connectedTileDirection = TileDirection.None;
				Tile adjacentConnectedTile = GetAdjacentConnectedTile(out connectedTileDirection, RoadState.ActiveOrPending, GetTwoLaneRoads(RoadState.Active, MotorwayInclusion.Include));
				if (adjacentConnectedTile.ContentType == TileContentType.None)
				{
					return false;
				}
				return TileUtilities.GetOppositeDirection(connectedTileDirection) == adjacentConnectedTile.DrivewayDirection;
			}
		}

		public bool IsPlannedRoundaboutBlocked
		{
			get
			{
				if (_mothballedRoundaboutInput != TileDirection.None)
				{
					return true;
				}
				if (_plannedRoundaboutInput == TileDirection.None || _plannedRoundaboutOutput == TileDirection.None)
				{
					if (Roundabout.IsTileCenterOfRoundabout(this, RoadState.Planned))
					{
						TileDirection[] nonDiagonalDirections = TileUtilities.NonDiagonalDirections;
						foreach (TileDirection direction in nonDiagonalDirections)
						{
							if (GetTwoLaneRoadStateInDirection(direction) != RoadState.None)
							{
								return true;
							}
						}
					}
					return false;
				}
				TileDirectionBitfield invalidExitsForConnection = Roundabout.GetInvalidExitsForConnection(_plannedRoundaboutInput, _plannedRoundaboutOutput);
				TileDirectionBitfield twoLaneRoads = GetTwoLaneRoads(RoadState.Mothballed, MotorwayInclusion.Include);
				return (invalidExitsForConnection.Bits & twoLaneRoads.Bits) != 0;
			}
		}

		public void SetRailConnection(RailTileConnection connection)
		{
			if (!(_railConnection == connection))
			{
				_railConnection = connection;
				NotifyTileChanged();
			}
		}

		public void SetBoatPathConnection(BoatPathTileConnection connection)
		{
			if (!(_boatPathConnection == connection))
			{
				_boatPathConnection = connection;
				NotifyTileChanged();
			}
		}

		public void Initialize(ITilemap tilemap, Vector2Int coordinates, TileContentType contentType)
		{
			Tilemap = tilemap;
			Coordinates = coordinates;
			ContentType = contentType;
		}

		public bool CloneInto(Tile cloneTile)
		{
			bool flag = false;
			flag |= cloneTile.ContentType != ContentType;
			cloneTile.ContentType = ContentType;
			flag |= cloneTile.HasTrafficLight != HasTrafficLight;
			cloneTile.HasTrafficLight = HasTrafficLight;
			flag |= cloneTile.IsCenterOfRoundabout != IsCenterOfRoundabout;
			cloneTile.IsCenterOfRoundabout = IsCenterOfRoundabout;
			flag |= cloneTile.UnbuiltMotorwayId != UnbuiltMotorwayId;
			cloneTile.UnbuiltMotorwayId = UnbuiltMotorwayId;
			flag |= cloneTile.UnbuiltMotorwayNumber != UnbuiltMotorwayNumber;
			cloneTile.UnbuiltMotorwayNumber = UnbuiltMotorwayNumber;
			flag |= cloneTile._trafficLightPermanenceProgress != _trafficLightPermanenceProgress;
			cloneTile._trafficLightPermanenceProgress = _trafficLightPermanenceProgress;
			flag |= cloneTile._roundaboutPermanenceProgress != _roundaboutPermanenceProgress;
			cloneTile._roundaboutPermanenceProgress = _roundaboutPermanenceProgress;
			flag |= cloneTile._plannedRoundaboutInput != _plannedRoundaboutInput || cloneTile._plannedRoundaboutOutput != _plannedRoundaboutOutput || cloneTile._activeRoundaboutInput != _activeRoundaboutInput || cloneTile._activeRoundaboutOutput != _activeRoundaboutOutput || cloneTile._mothballedRoundaboutInput != _mothballedRoundaboutInput || cloneTile._mothballedRoundaboutOutput != _mothballedRoundaboutOutput;
			cloneTile._plannedRoundaboutInput = _plannedRoundaboutInput;
			cloneTile._plannedRoundaboutOutput = _plannedRoundaboutOutput;
			cloneTile._activeRoundaboutInput = _activeRoundaboutInput;
			cloneTile._activeRoundaboutOutput = _activeRoundaboutOutput;
			cloneTile._mothballedRoundaboutInput = _mothballedRoundaboutInput;
			cloneTile._mothballedRoundaboutOutput = _mothballedRoundaboutOutput;
			flag |= !cloneTile._isDirectionImmutable.Equals(_isDirectionImmutable);
			cloneTile._isDirectionImmutable = _isDirectionImmutable;
			for (int i = 0; i < 8; i++)
			{
				flag |= _twoLaneRoadState[i] != cloneTile._twoLaneRoadState[i] || _plannedMotorways[i] != cloneTile._plannedMotorways[i] || _nodePermanenceProgress[i] != cloneTile._nodePermanenceProgress[i] || _activeMotorways[i] != cloneTile._activeMotorways[i] || _mothballedMotorways[i] != cloneTile._mothballedMotorways[i];
				cloneTile._twoLaneRoadState[i] = _twoLaneRoadState[i];
				cloneTile._plannedMotorways[i] = _plannedMotorways[i];
				cloneTile._nodePermanenceProgress[i] = _nodePermanenceProgress[i];
				cloneTile._activeMotorways[i] = _activeMotorways[i];
				cloneTile._mothballedMotorways[i] = _mothballedMotorways[i];
			}
			flag |= cloneTile._railConnection != _railConnection;
			cloneTile._railConnection = _railConnection;
			if (flag)
			{
				cloneTile.NotifyTileChanged();
			}
			return flag;
		}

		public TileDirectionBitfield GetTwoLaneRoads(RoadState states = RoadState.Active, MotorwayInclusion motorwayInclusion = MotorwayInclusion.Ignore)
		{
			TileDirectionBitfield result = default(TileDirectionBitfield);
			for (int i = 0; i < _twoLaneRoadState.Length; i++)
			{
				TileDirection direction = (TileDirection)i;
				result[direction] = (_twoLaneRoadState[i] & states) != 0;
				if (motorwayInclusion == MotorwayInclusion.Include)
				{
					result[direction] |= HasMotorwayInDirection(direction, states);
				}
			}
			return result;
		}

		public RoadState StateOfRoadInDirection(TileDirection direction)
		{
			return _twoLaneRoadState[(int)direction];
		}

		public RoadState GetTwoLaneRoadStateInDirection(TileDirection direction)
		{
			return _twoLaneRoadState[(int)direction];
		}

		public bool HasTwoLaneRoadInDirection(TileDirection direction, RoadState states = RoadState.Active)
		{
			if (direction == TileDirection.None)
			{
				return false;
			}
			return (_twoLaneRoadState[(int)direction] & states) != 0;
		}

		public int GetTwoLaneRoadCount(RoadState states = RoadState.Active, MotorwayInclusion motorwayInclusion = MotorwayInclusion.Ignore)
		{
			int num = 0;
			for (int i = 0; i < _twoLaneRoadState.Length; i++)
			{
				bool flag = (_twoLaneRoadState[i] & states) != 0;
				if (motorwayInclusion == MotorwayInclusion.Include)
				{
					flag |= HasMotorwayInDirection((TileDirection)i, states);
				}
				num += (flag ? 1 : 0);
			}
			return num;
		}

		public RoadTileSignature CreateSignature(RoadState states)
		{
			RoadTileSignature roadTileSignature = _scope.Get<RoadTileSignature>();
			TileDirection roundaboutInput = TileDirection.None;
			TileDirection roundaboutOutput = TileDirection.None;
			bool flag = false;
			if (HasRoundabout(states))
			{
				RoadTileConnection roundaboutConnection = GetRoundaboutConnection(states);
				roadTileSignature.AddConnection(roundaboutConnection);
				if ((states & RoadState.Mothballed) != RoadState.None)
				{
					roundaboutInput = roundaboutConnection.input.direction;
					roundaboutOutput = roundaboutConnection.output.direction;
					flag = true;
				}
			}
			RoadType type = RoadType.TwoLane;
			if (ContentType == TileContentType.House)
			{
				states &= ~RoadState.Mothballed;
				type = RoadType.Driveway;
			}
			TileDirectionBitfield.Enumerator enumerator = GetTwoLaneRoads(states).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				RoadTileNode roadTileNode = new RoadTileNode(current, type);
				if (!flag || Roundabout.CanConnectionAddExitNode(roundaboutInput, roundaboutOutput, roadTileNode))
				{
					roadTileSignature.AddNode(roadTileNode);
				}
			}
			enumerator = GetMotorwayRamps(states).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current2 = enumerator.Current;
				int num = -1;
				if ((states & RoadState.Active) != RoadState.None && HasMotorwayInDirection(current2, RoadState.Active))
				{
					num = _activeMotorways[(int)current2];
				}
				if (num == -1 && (states & RoadState.Planned) != RoadState.None && HasMotorwayInDirection(current2, RoadState.Planned))
				{
					num = _plannedMotorways[(int)current2];
				}
				if (num == -1 && (states & RoadState.Mothballed) != RoadState.None && HasMotorwayInDirection(current2, RoadState.Mothballed))
				{
					num = _mothballedMotorways[(int)current2];
				}
				RoadTileNode roadTileNode2 = new RoadTileNode(current2, RoadType.Motorway, num);
				if (!flag || Roundabout.CanConnectionAddExitNode(roundaboutInput, roundaboutOutput, roadTileNode2))
				{
					roadTileSignature.AddNode(roadTileNode2);
				}
			}
			return roadTileSignature;
		}

		public bool CanSetNodeState(RoadTileNode node, RoadState newState, TileChangePermissions changePermissions = TileChangePermissions.Full)
		{
			if (node.type == RoadType.TwoLane || node.type == RoadType.Driveway)
			{
				if (HasMotorwayInDirection(node.direction, RoadState.Live | RoadState.Planned))
				{
					return false;
				}
				int direction = (int)node.direction;
				RoadState roadState = _twoLaneRoadState[direction];
				if ((newState & RoadState.VisiblyActive) != RoadState.None && HasRoundabout(RoadState.Planned | RoadState.Active) && !Roundabout.CanConnectionAddExitNode(GetRoundaboutConnection(RoadState.Planned | RoadState.Active), node))
				{
					return false;
				}
				switch (newState)
				{
				case RoadState.None:
					return roadState == RoadState.Mothballed;
				case RoadState.Planned:
					if (node.type == RoadType.Driveway)
					{
						return false;
					}
					if (HasPermissionToChangeNodeState(node.direction, changePermissions))
					{
						return (roadState & (RoadState.Live | RoadState.Pending)) == 0;
					}
					return false;
				case RoadState.Pending:
					if (HasPermissionToChangeNodeState(node.direction, changePermissions))
					{
						return (roadState & RoadState.ActiveOrPending) == 0;
					}
					return false;
				case RoadState.Active:
					if (roadState != RoadState.Pending)
					{
						return false;
					}
					if (HasRoundabout(RoadState.Mothballed))
					{
						return Roundabout.CanConnectionAddExitNode(GetRoundaboutConnection(RoadState.Mothballed), node);
					}
					return true;
				case RoadState.Mothballed:
					if (!HasPermissionToChangeNodeState(node.direction, changePermissions))
					{
						return false;
					}
					if ((roadState & RoadState.ActiveOrPending) != RoadState.None)
					{
						return true;
					}
					if (roadState == RoadState.None)
					{
						if (TileUtilities.IsDirectionDiagonal(node.direction))
						{
							return IsCenterOfRoundabout;
						}
						return false;
					}
					return false;
				}
			}
			else if (node.type == RoadType.Motorway)
			{
				int direction2 = (int)node.direction;
				switch (newState)
				{
				case RoadState.None:
					if (_plannedMotorways[direction2] != node.motorwayId)
					{
						return _mothballedMotorways[direction2] == node.motorwayId;
					}
					return true;
				case RoadState.Mothballed:
					if (_plannedMotorways[direction2] != node.motorwayId)
					{
						return _activeMotorways[direction2] == node.motorwayId;
					}
					return true;
				case RoadState.Planned:
					if (!HasPermissionToChangeNodeState(node.direction, changePermissions))
					{
						return false;
					}
					if (Roundabout.IsTileCenterOfRoundabout(this, RoadState.VisiblyActive | RoadState.Mothballed))
					{
						return false;
					}
					if (_activeMotorways[direction2] == -1 && _plannedMotorways[direction2] == node.motorwayId)
					{
						return true;
					}
					if (_plannedMotorways[direction2] != -1 || _activeMotorways[direction2] != -1)
					{
						return false;
					}
					if (GetTwoLaneRoadStateInDirection(node.direction) != RoadState.None)
					{
						return false;
					}
					return true;
				case RoadState.Active:
					if (HasPermissionToChangeNodeState(node.direction, changePermissions))
					{
						if (_plannedMotorways[direction2] != node.motorwayId || _mothballedMotorways[direction2] != -1)
						{
							if (_plannedMotorways[direction2] == -1)
							{
								return _mothballedMotorways[direction2] == node.motorwayId;
							}
							return false;
						}
						return true;
					}
					return false;
				default:
					return false;
				}
			}
			Diagnostics.FailAssert("CanSetNodeState is unable to handle nodes of type {0}.", node.type);
			return false;
		}

		public bool SetNodeState(RoadTileNode node, RoadState newState, TileChangePermissions permissions = TileChangePermissions.Full)
		{
			if (!CanSetNodeState(node, newState, permissions))
			{
				return false;
			}
			if (node.type == RoadType.TwoLane)
			{
				int direction = (int)node.direction;
				RoadState roadState = _twoLaneRoadState[direction];
				if (newState != roadState)
				{
					if (newState == RoadState.Mothballed && roadState == RoadState.Pending)
					{
						newState = RoadState.None;
					}
					_twoLaneRoadState[direction] = newState;
					if (newState == RoadState.Pending && roadState != RoadState.Mothballed)
					{
						_nodePermanenceProgress[direction] = Fix64.Zero;
					}
					NotifyTileChanged();
					return true;
				}
			}
			if (node.type == RoadType.Driveway)
			{
				int direction2 = (int)node.direction;
				RoadState roadState2 = _twoLaneRoadState[direction2];
				if (newState != roadState2)
				{
					if ((newState & RoadState.ActiveOrPending) != RoadState.None)
					{
						TileDirection drivewayDirection = DrivewayDirection;
						if (drivewayDirection != TileDirection.None)
						{
							int num = (int)drivewayDirection;
							if (_twoLaneRoadState[num] == RoadState.Pending)
							{
								_twoLaneRoadState[num] = RoadState.None;
							}
							else
							{
								_twoLaneRoadState[num] = RoadState.Mothballed;
							}
						}
					}
					else if (newState == RoadState.Mothballed && roadState2 == RoadState.Pending)
					{
						newState = RoadState.None;
					}
					_twoLaneRoadState[direction2] = newState;
					NotifyTileChanged();
					return true;
				}
			}
			if (node.type == RoadType.Motorway)
			{
				int direction3 = (int)node.direction;
				switch (newState)
				{
				case RoadState.None:
					if (_plannedMotorways[direction3] == node.motorwayId)
					{
						_plannedMotorways[direction3] = -1;
					}
					if (_mothballedMotorways[direction3] == node.motorwayId)
					{
						_mothballedMotorways[direction3] = -1;
					}
					break;
				case RoadState.Mothballed:
					if (_activeMotorways[direction3] == node.motorwayId)
					{
						_activeMotorways[direction3] = -1;
						_mothballedMotorways[direction3] = node.motorwayId;
					}
					if (_plannedMotorways[direction3] == node.motorwayId)
					{
						_plannedMotorways[direction3] = -1;
					}
					break;
				case RoadState.Planned:
					_plannedMotorways[direction3] = node.motorwayId;
					break;
				case RoadState.Active:
					if (_plannedMotorways[direction3] == node.motorwayId)
					{
						_plannedMotorways[direction3] = -1;
					}
					else
					{
						_mothballedMotorways[direction3] = -1;
					}
					_activeMotorways[direction3] = node.motorwayId;
					break;
				default:
					return false;
				}
				NotifyTileChanged();
				return true;
			}
			return false;
		}

		public bool HasMotorwayInDirection(TileDirection direction, RoadState roadStates)
		{
			if ((roadStates & RoadState.Mothballed) != RoadState.None && _mothballedMotorways[(int)direction] > -1)
			{
				return true;
			}
			if ((roadStates & RoadState.Planned) != RoadState.None && _plannedMotorways[(int)direction] > -1)
			{
				return true;
			}
			if ((roadStates & RoadState.Active) != RoadState.None && _activeMotorways[(int)direction] > -1)
			{
				return true;
			}
			return false;
		}

		public int GetMotorwayInDirection(TileDirection direction, RoadState roadStates)
		{
			if ((roadStates & RoadState.Active) != RoadState.None && _activeMotorways[(int)direction] != -1)
			{
				return _activeMotorways[(int)direction];
			}
			if ((roadStates & RoadState.Planned) != RoadState.None && _plannedMotorways[(int)direction] != -1)
			{
				return _plannedMotorways[(int)direction];
			}
			if ((roadStates & RoadState.Mothballed) != RoadState.None && _mothballedMotorways[(int)direction] != -1)
			{
				return _mothballedMotorways[(int)direction];
			}
			return -1;
		}

		public TileDirection GetMotorwayRampDirection(int motorwayId)
		{
			for (int i = 0; i < 8; i++)
			{
				if (_plannedMotorways[i] == motorwayId || _activeMotorways[i] == motorwayId || _mothballedMotorways[i] == motorwayId)
				{
					return (TileDirection)i;
				}
			}
			return TileDirection.None;
		}

		public TileDirectionBitfield GetMotorwayRamps(RoadState states)
		{
			TileDirectionBitfield result = default(TileDirectionBitfield);
			for (int i = 0; i < 8; i++)
			{
				result[(TileDirection)i] = HasMotorwayInDirection((TileDirection)i, states);
			}
			return result;
		}

		public bool HasRoundabout(RoadState states)
		{
			if ((states & RoadState.Active) == RoadState.Active && _activeRoundaboutInput != TileDirection.None)
			{
				return true;
			}
			if ((states & RoadState.Planned) == RoadState.Planned && _plannedRoundaboutInput != TileDirection.None)
			{
				return true;
			}
			if ((states & RoadState.Mothballed) == RoadState.Mothballed && _mothballedRoundaboutInput != TileDirection.None)
			{
				return true;
			}
			return false;
		}

		public RoadTileConnection GetRoundaboutConnection(RoadState states)
		{
			TileDirection tileDirection = TileDirection.None;
			TileDirection direction = TileDirection.None;
			if ((states & RoadState.Active) == RoadState.Active && _activeRoundaboutInput != TileDirection.None)
			{
				tileDirection = _activeRoundaboutInput;
				direction = _activeRoundaboutOutput;
			}
			if ((states & RoadState.Planned) == RoadState.Planned && _plannedRoundaboutInput != TileDirection.None)
			{
				tileDirection = _plannedRoundaboutInput;
				direction = _plannedRoundaboutOutput;
			}
			if ((states & RoadState.Mothballed) == RoadState.Mothballed && _mothballedRoundaboutInput != TileDirection.None)
			{
				tileDirection = _mothballedRoundaboutInput;
				direction = _mothballedRoundaboutOutput;
			}
			if (tileDirection != TileDirection.None)
			{
				return new RoadTileConnection(new RoadTileNode(tileDirection, RoadType.Roundabout), new RoadTileNode(direction, RoadType.Roundabout));
			}
			return RoadTileConnection.InvalidConnection;
		}

		public RoadState GetRoundaboutState(RoadTileConnection roundaboutConnection)
		{
			TileDirection direction = roundaboutConnection.input.direction;
			TileDirection direction2 = roundaboutConnection.output.direction;
			if (_activeRoundaboutInput == direction && _activeRoundaboutOutput == direction2)
			{
				return RoadState.Active;
			}
			if (_plannedRoundaboutInput == direction && _plannedRoundaboutOutput == direction2)
			{
				return RoadState.Planned;
			}
			if (_mothballedRoundaboutInput == direction && _mothballedRoundaboutOutput == direction2)
			{
				return RoadState.Mothballed;
			}
			return RoadState.None;
		}

		public bool IsNodeBlocked(RoadTileNode node)
		{
			if (_mothballedRoundaboutInput == TileDirection.None)
			{
				return false;
			}
			return !Roundabout.CanConnectionAddExitNode(GetRoundaboutConnection(RoadState.Mothballed), node);
		}

		public bool CanSetRoundaboutState(RoadTileConnection roundaboutConnection, RoadState roundaboutState)
		{
			return CanSetRoundaboutState(roundaboutConnection.input.direction, roundaboutConnection.output.direction, roundaboutState);
		}

		public bool CanSetRoundaboutState(TileDirection roundaboutInput, TileDirection roundaboutOutput, RoadState roundaboutState)
		{
			for (int i = 0; i < 8; i++)
			{
				if (HasMotorwayInDirection((TileDirection)i, RoadState.Live | RoadState.Planned))
				{
					return false;
				}
			}
			switch (roundaboutState)
			{
			case RoadState.None:
				if (_mothballedRoundaboutInput != roundaboutInput || _mothballedRoundaboutOutput != roundaboutOutput)
				{
					if (_plannedRoundaboutInput == roundaboutInput)
					{
						return _plannedRoundaboutOutput == roundaboutOutput;
					}
					return false;
				}
				return true;
			case RoadState.Mothballed:
				if (_activeRoundaboutInput != roundaboutInput || _activeRoundaboutOutput != roundaboutOutput)
				{
					if (_plannedRoundaboutInput == roundaboutInput)
					{
						return _plannedRoundaboutOutput == roundaboutOutput;
					}
					return false;
				}
				return true;
			case RoadState.Planned:
				return !HasRoundabout(RoadState.Planned | RoadState.Active);
			case RoadState.Active:
				if (_mothballedRoundaboutInput == roundaboutInput && _mothballedRoundaboutOutput == roundaboutOutput)
				{
					return true;
				}
				if (_plannedRoundaboutInput == roundaboutInput && _plannedRoundaboutOutput == roundaboutOutput)
				{
					return !IsPlannedRoundaboutBlocked;
				}
				return false;
			default:
				Diagnostics.FailAssert("Cannot set roundabout state to {0}.", roundaboutState);
				return false;
			}
		}

		public bool SetRoundaboutState(RoadTileConnection roundaboutConnection, RoadState roundaboutState)
		{
			return SetRoundaboutState(roundaboutConnection.input.direction, roundaboutConnection.output.direction, roundaboutState);
		}

		public bool SetRoundaboutState(TileDirection roundaboutInput, TileDirection roundaboutOutput, RoadState roundaboutState)
		{
			if (!CanSetRoundaboutState(roundaboutInput, roundaboutOutput, roundaboutState))
			{
				return false;
			}
			Log.Info("Setting roundabout state of tile {0} for input {1} output {2} to {3}", this, roundaboutInput, roundaboutOutput, roundaboutState);
			switch (roundaboutState)
			{
			case RoadState.None:
				if (_mothballedRoundaboutInput == roundaboutInput && _mothballedRoundaboutOutput == roundaboutOutput)
				{
					_mothballedRoundaboutInput = TileDirection.None;
					_mothballedRoundaboutOutput = TileDirection.None;
				}
				if (_plannedRoundaboutInput == roundaboutInput && _plannedRoundaboutOutput == roundaboutOutput)
				{
					_plannedRoundaboutInput = TileDirection.None;
					_plannedRoundaboutOutput = TileDirection.None;
				}
				break;
			case RoadState.Mothballed:
				if (_activeRoundaboutInput == roundaboutInput && _activeRoundaboutOutput == roundaboutOutput)
				{
					_activeRoundaboutInput = TileDirection.None;
					_activeRoundaboutOutput = TileDirection.None;
					_mothballedRoundaboutInput = roundaboutInput;
					_mothballedRoundaboutOutput = roundaboutOutput;
				}
				if (_plannedRoundaboutInput == roundaboutInput && _plannedRoundaboutOutput == roundaboutOutput)
				{
					_plannedRoundaboutInput = TileDirection.None;
					_plannedRoundaboutOutput = TileDirection.None;
				}
				break;
			case RoadState.Planned:
			{
				_plannedRoundaboutInput = roundaboutInput;
				_plannedRoundaboutOutput = roundaboutOutput;
				if (_mothballedRoundaboutInput == roundaboutInput && _mothballedRoundaboutOutput == roundaboutOutput)
				{
					_mothballedRoundaboutInput = TileDirection.None;
					_mothballedRoundaboutOutput = TileDirection.None;
				}
				TileDirectionBitfield.Enumerator enumerator = Roundabout.GetInvalidExitsForConnection(roundaboutInput, roundaboutOutput).GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current2 = enumerator.Current;
					if ((_twoLaneRoadState[(int)current2] & RoadState.ActiveOrPending) != RoadState.None)
					{
						SetNodeState(new RoadTileNode(current2), RoadState.Mothballed);
					}
				}
				break;
			}
			case RoadState.Active:
			{
				_plannedRoundaboutInput = TileDirection.None;
				_plannedRoundaboutOutput = TileDirection.None;
				_activeRoundaboutInput = roundaboutInput;
				_activeRoundaboutOutput = roundaboutOutput;
				if (_mothballedRoundaboutInput != roundaboutInput || _mothballedRoundaboutOutput != roundaboutOutput)
				{
					break;
				}
				_mothballedRoundaboutInput = TileDirection.None;
				_mothballedRoundaboutOutput = TileDirection.None;
				TileDirectionBitfield.Enumerator enumerator = Roundabout.GetInvalidExitsForConnection(roundaboutInput, roundaboutOutput).GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					if (_twoLaneRoadState[(int)current] == RoadState.Pending)
					{
						SetNodeState(new RoadTileNode(current), RoadState.Mothballed);
					}
				}
				break;
			}
			default:
				return false;
			}
			NotifyTileChanged();
			return true;
		}

		public void SetNodeImmutability(TileDirection direction, bool isImmutable)
		{
			if (_isDirectionImmutable[direction] != isImmutable)
			{
				_isDirectionImmutable[direction] = isImmutable;
				NotifyTileChanged();
			}
		}

		public bool IsNodePermanent(TileDirection direction)
		{
			if (!(_nodePermanenceProgress[(int)direction] >= Fix64.One))
			{
				return _isDirectionImmutable[direction];
			}
			return true;
		}

		public TileDirectionBitfield GetPermanentDirections()
		{
			TileDirectionBitfield none = TileDirectionBitfield.None;
			TileDirection[] directions = TileUtilities.Directions;
			foreach (TileDirection tileDirection in directions)
			{
				none[tileDirection] = _nodePermanenceProgress[(int)tileDirection] >= Fix64.One;
			}
			return none;
		}

		public Fix64 GetNodePermanenceProgress(TileDirection direction)
		{
			if (!IsNodePermanent(direction))
			{
				return _nodePermanenceProgress[(int)direction];
			}
			return Fix64.One;
		}

		public bool AnyRoadHasPermanenceBelowValue(Fix64 permanenceToTest, RoadState roadState)
		{
			TileDirectionBitfield.Enumerator enumerator = GetTwoLaneRoads(roadState).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (_nodePermanenceProgress[(int)current] < permanenceToTest && !IsConnectedViaDrivewayInDirection(current))
				{
					return true;
				}
			}
			return false;
		}

		private bool HasPermissionToChangeNodeState(TileDirection direction, TileChangePermissions changePermissions = TileChangePermissions.Full)
		{
			if (!_isDirectionImmutable[direction])
			{
				if (changePermissions != TileChangePermissions.Full)
				{
					return _nodePermanenceProgress[(int)direction] < Fix64.One;
				}
				return true;
			}
			return false;
		}

		public void SetNodePermanence(TileDirection direction, bool isPermanent)
		{
			SetNodePermanence(direction, isPermanent ? Fix64.One : Fix64.Zero);
		}

		public void SetNodePermanence(TileDirection direction, Fix64 permanence)
		{
			_nodePermanenceProgress[(int)direction] = permanence;
			NotifyTileChanged();
		}

		public void IncrementNodePermanenceProgress(Fix64 permanenceProgress, TileDirectionBitfield directions, RoadState state = RoadState.Active)
		{
			bool flag = false;
			TileDirectionBitfield tileDirectionBitfield = new TileDirectionBitfield(directions.Bits & GetTwoLaneRoads(state, MotorwayInclusion.Include).Bits);
			TileDirectionBitfield.Enumerator enumerator = tileDirectionBitfield.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				_nodePermanenceProgress[(int)current] += permanenceProgress;
				if (_nodePermanenceProgress[(int)current] >= Fix64.One)
				{
					_nodePermanenceProgress[(int)current] = Fix64.One;
				}
				flag = true;
			}
			if (HasTrafficLight && !IsTrafficLightPermanent)
			{
				_trafficLightPermanenceProgress += permanenceProgress;
				if (_trafficLightPermanenceProgress > Fix64.One)
				{
					_trafficLightPermanenceProgress = Fix64.One;
				}
				flag = true;
			}
			if (IsCenterOfRoundabout && !IsRoundaboutPermanent)
			{
				Vector2Int vector2Int = new Vector2Int(-1, 0);
				RoadTileConnection connectionForCoordinatesOffset = Roundabout.GetConnectionForCoordinatesOffset(vector2Int);
				Tile tile = Tilemap.GetTile(Coordinates + vector2Int);
				if (tile != null && tile.GetRoundaboutState(connectionForCoordinatesOffset) == RoadState.Active)
				{
					_roundaboutPermanenceProgress += permanenceProgress;
					if (_roundaboutPermanenceProgress > Fix64.One)
					{
						_roundaboutPermanenceProgress = Fix64.One;
					}
					flag = true;
				}
			}
			if (flag)
			{
				NotifyTileChanged();
			}
		}

		public void ResetRoundaboutPermanence()
		{
			if (_roundaboutPermanenceProgress > Fix64.Zero)
			{
				_roundaboutPermanenceProgress = Fix64.Zero;
				NotifyTileChanged();
			}
		}

		public bool CanSetContentType(TileContentType type)
		{
			if (type == TileContentType.None)
			{
				return true;
			}
			if (ContentType == TileContentType.None)
			{
				return IsEmpty();
			}
			if ((type == TileContentType.Destination || type == TileContentType.Carpark || type == TileContentType.House || type == TileContentType.BoatTerminal) && ContentType == TileContentType.Tree)
			{
				return _city.Rules.ShouldBuildingsBulldozeTrees;
			}
			return false;
		}

		public void SetContentType(TileContentType type, IModel contentModel)
		{
			if (ContentType == TileContentType.Tree && (type == TileContentType.Destination || type == TileContentType.Carpark || type == TileContentType.House || type == TileContentType.BoatTerminal))
			{
				TreeModel treeModel = ContentModel as TreeModel;
				if (Diagnostics.Verify(treeModel != null, "ContentType at {0} is Tree, but no TreeModel found!"))
				{
					Diagnostics.Verify(_city.Rules.ShouldBuildingsBulldozeTrees, "Bulldozing tree at {0}, but game rules says we shouldn't be", Coordinates);
					treeModel.Bulldoze();
				}
			}
			ContentType = type;
			ContentModel = contentModel;
			NotifyTileChanged();
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		private void NotifyTileChanged()
		{
			ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnTileChanged(this);
			}
		}

		public void Clear()
		{
			ContentType = TileContentType.None;
			ContentModel = null;
			_hasTrafficLight = false;
			_trafficLightPermanenceProgress = Fix64.Zero;
			_roundaboutPermanenceProgress = Fix64.Zero;
			_isCenterOfRoundabout = false;
			for (int i = 0; i < 8; i++)
			{
				_twoLaneRoadState[i] = RoadState.None;
				_plannedMotorways[i] = -1;
				_activeMotorways[i] = -1;
				_mothballedMotorways[i] = -1;
				_nodePermanenceProgress[i] = Fix64.Zero;
			}
			_isDirectionImmutable = TileDirectionBitfield.None;
			_plannedRoundaboutInput = TileDirection.None;
			_plannedRoundaboutOutput = TileDirection.None;
			_activeRoundaboutInput = TileDirection.None;
			_activeRoundaboutOutput = TileDirection.None;
			_mothballedRoundaboutInput = TileDirection.None;
			_mothballedRoundaboutOutput = TileDirection.None;
			UnbuiltMotorwayId = -1;
			UnbuiltMotorwayNumber = 0;
			_railConnection = RailTileConnection.InvalidConnection;
			NotifyTileChanged();
		}

		public bool CanDrawRoadsOn()
		{
			return _behaviour.CanDrawRoadOn(ContentType);
		}

		public bool IsEmpty()
		{
			for (int i = 0; i < 8; i++)
			{
				if (_twoLaneRoadState[i] != RoadState.None)
				{
					return false;
				}
				if (_plannedMotorways[i] != -1 || _activeMotorways[i] != -1 || _mothballedMotorways[i] != -1)
				{
					return false;
				}
			}
			if (Roundabout.IsTileCenterOfRoundabout(this))
			{
				return false;
			}
			if (UnbuiltMotorwayId != -1)
			{
				return false;
			}
			if (_plannedRoundaboutInput != TileDirection.None || _activeRoundaboutInput != TileDirection.None || _mothballedRoundaboutInput != TileDirection.None)
			{
				return false;
			}
			return true;
		}

		public bool IsConnectedViaDrivewayInDirection(TileDirection direction)
		{
			Tile tile = Tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(Coordinates, direction));
			if (tile != null && (tile.ContentType == TileContentType.House || tile.ContentType == TileContentType.Carpark))
			{
				return true;
			}
			return false;
		}

		public Tile GetAdjacentConnectedTile(out TileDirection connectedTileDirection, RoadState traversableConnectionStates, TileDirectionBitfield traversableDirections)
		{
			connectedTileDirection = TileDirection.None;
			TileDirectionBitfield.Enumerator enumerator = GetTwoLaneRoads(traversableConnectionStates).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (traversableDirections[current])
				{
					connectedTileDirection = current;
					return Tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(Coordinates, current));
				}
			}
			return null;
		}

		public override string ToString()
		{
			string text = $"[Tile Coordinates={Coordinates}";
			if (ContentType != TileContentType.None)
			{
				text += $", ContentType={ContentType}, ContentModel={ContentModel}";
			}
			string text2 = "";
			string text3 = "";
			string text4 = "";
			for (int i = 0; i < 8; i++)
			{
				if (_plannedMotorways[i] != -1)
				{
					text3 += $"{(TileDirection)i} {_plannedMotorways[i]}, ";
				}
				if (_activeMotorways[i] != -1)
				{
					text2 += $"{(TileDirection)i} {_activeMotorways[i]}, ";
				}
				if (_mothballedMotorways[i] != -1)
				{
					text4 += $"{(TileDirection)i} {_mothballedMotorways[i]}, ";
				}
			}
			if (text3.Length > 0)
			{
				text = text + ", PlannedMotorways=[" + text3.Substring(0, text3.Length - 2) + "]";
			}
			if (text2.Length > 0)
			{
				text = text + ", ActiveMotorways=[" + text2.Substring(0, text2.Length - 2) + "]";
			}
			if (text4.Length > 0)
			{
				text = text + ", MothballedMotorways=[" + text4.Substring(0, text4.Length - 2) + "]";
			}
			return text + "]";
		}

		public void Reset()
		{
			Tilemap = null;
			Coordinates = default(Vector2Int);
			ContentType = TileContentType.None;
			ContentModel = null;
			_hasTrafficLight = false;
			_trafficLightPermanenceProgress = Fix64.Zero;
			_roundaboutPermanenceProgress = Fix64.Zero;
			_isCenterOfRoundabout = false;
			_unbuiltMotorwayId = -1;
			_unbuiltMotorwayNumber = 0;
			for (int i = 0; i < 8; i++)
			{
				_twoLaneRoadState[i] = RoadState.None;
				_plannedMotorways[i] = -1;
				_activeMotorways[i] = -1;
				_mothballedMotorways[i] = -1;
			}
			_isDirectionImmutable = TileDirectionBitfield.None;
			_activeRoundaboutInput = TileDirection.None;
			_activeRoundaboutOutput = TileDirection.None;
			_mothballedRoundaboutInput = TileDirection.None;
			_mothballedRoundaboutOutput = TileDirection.None;
			_plannedRoundaboutInput = TileDirection.None;
			_plannedRoundaboutOutput = TileDirection.None;
			_railConnection = RailTileConnection.InvalidConnection;
			_boatPathConnection = BoatPathTileConnection.InvalidConnection;
			_observers.UnsubscribeAll();
		}
	}
}
