using System.Collections.Generic;
using Factory;
using FixMath;
using Server;
using Unity.Profiling;
using UnityEngine;

namespace Motorways.Models
{
	[Serializable(1)]
	public class LaneModel : Model<EmptyModelFrame, LaneModel.IObserver>, ICreatedInScopeHandler, IDeserializedHandler
	{
		public interface IObserver
		{
			void OnLaneModelReleased(LaneModel laneModel);
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LaneModel");

		[Serialize(false, null)]
		public int _id = -1;

		private static int NextId = 1;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private GameBehaviourModel _behaviour;

		private bool _isEndpointLane;

		private bool _isCarparkLane;

		[Dependency]
		private Pathfinder _pathfinder;

		[Serialize(false, null)]
		private Fix64 _length = -Fix64Consts.One;

		[Serialize(false, null)]
		private Fix64 _speedLimitScale = Fix64Consts.One;

		[Serialize(false, null)]
		private Fix64 _speedLimit = -Fix64Consts.One;

		public bool hasBeenUsed;

		[Serialize(false, null)]
		private List<Vector2Fixed> _lanePoints;

		private List<Vector2Fixed> _bespokeLanePoints;

		[Serialize(false, null)]
		private readonly List<LineSegment> _lineSegments = new List<LineSegment>();

		private int _tileDefinitionIndex = -1;

		private Vector2Fixed _worldOffset;

		public RoadTileConnection connection;

		private RoadState _state;

		public bool isTemporary;

		private List<LaneModel> _outboundLanes = new List<LaneModel>();

		[Serialize(false, null)]
		private List<LaneModel> _inboundLanes = new List<LaneModel>();

		public RoadChunkModel roadChunk;

		private List<VehicleModel> _vehicles = new List<VehicleModel>();

		private static readonly ProfilerMarker Profiler_FirstVehicleAheadOf = new ProfilerMarker(ProfilerUtility.CategoryModel, "LaneModel.FirstVehicleAheadOf");

		[field: Serialize(false, null)]
		public int PathfindingStartNodeId { get; private set; } = -1;

		[field: Serialize(false, null)]
		public int PathfindingEndNodeId { get; private set; } = -1;

		public Vector2Fixed StartPosition => lanePoints[0];

		public Vector2Fixed EndPosition => lanePoints[lanePoints.Count - 1];

		public Fix64 Length
		{
			get
			{
				if (_length < Fix64.Zero)
				{
					_length = Fix64.Zero;
					for (int i = 0; i < lanePoints.Count - 1; i++)
					{
						Vector2Fixed a = lanePoints[i];
						Vector2Fixed b = lanePoints[i + 1];
						Fix64 fix = Vector2Fixed.Distance(a, b);
						_length += fix;
					}
				}
				return _length;
			}
		}

		public int PathfindingCost
		{
			get
			{
				Fix64 fix = SpeedLimit;
				if (connection.IsRoundabout)
				{
					fix = fix / _constants.roundaboutSpeedMultiplier * _constants.defaultLaneSpeed;
				}
				Fix64 fix2 = Length / fix;
				if (_isCarparkLane)
				{
					fix2 *= Fix64Consts.Two;
				}
				if (_state != RoadState.Mothballed)
				{
					return Mathf.Max(1, (int)(10f * (float)fix2));
				}
				return 100000;
			}
		}

		public Fix64 SpeedLimit
		{
			get
			{
				if (_speedLimit > Fix64.Zero)
				{
					return _speedLimit;
				}
				_speedLimit = _behaviour.GetLaneSpeed(this) * _speedLimitScale;
				return _speedLimit;
			}
		}

		public List<Vector2Fixed> lanePoints => _lanePoints;

		public RoadState state
		{
			get
			{
				return _state;
			}
			set
			{
				if (value == _state)
				{
					return;
				}
				_state = value;
				switch (value)
				{
				case RoadState.Mothballed:
					if (PathfindingStartNodeId != -1 && PathfindingEndNodeId != -1)
					{
						UpdateLaneCost(100000);
					}
					break;
				case RoadState.Active:
					if (PathfindingStartNodeId != -1 && PathfindingEndNodeId != -1)
					{
						UpdateLaneCost(PathfindingCost);
					}
					break;
				}
			}
		}

		public List<LaneModel> OutboundLanes => _outboundLanes;

		public List<LaneModel> InboundLanes => _inboundLanes;

		public List<VehicleModel> Vehicles => _vehicles;

		public bool HasTraversingOrCommittedVehicles
		{
			get
			{
				if (Vehicles.Count > 0)
				{
					return true;
				}
				return roadChunk.DoesLaneHaveAnyCommittedVehicles(this);
			}
		}

		public bool HasInboundVehicles => roadChunk.DoesLaneHaveAnyInboundVehicles(this);

		public bool CanRelease
		{
			get
			{
				if (Vehicles.Count == 0)
				{
					return !roadChunk.DoesLaneHaveAnyInboundVehicles(this);
				}
				return false;
			}
		}

		public bool CanHotswap
		{
			get
			{
				if (Vehicles.Count == 0)
				{
					return !roadChunk.DoesLaneHaveAnyCommittedVehicles(this);
				}
				return false;
			}
		}

		public bool IsAboutToHotswap { get; set; }

		public void SetSpeedLimitScale(Fix64 newSpeedScale)
		{
			if (_speedLimitScale != newSpeedScale)
			{
				_speedLimitScale = newSpeedScale;
				RecalculateSpeedLimit();
			}
		}

		public void RecalculateSpeedLimit()
		{
			_speedLimit = -Fix64Consts.One;
		}

		public List<LineSegment> GetLineSegments()
		{
			if (_lineSegments.Count == 0)
			{
				BuildLineSegments();
			}
			return _lineSegments;
		}

		public void RemoveVehicle(VehicleModel vehicle)
		{
			Vehicles.Remove(vehicle);
		}

		public void AddVehicle(VehicleModel vehicle)
		{
			if (!Diagnostics.Verify(vehicle.NextFrame.lane == this || vehicle.CurrentFrame.lane == this, "The vehicle doesn't think it is entering this lane!"))
			{
				return;
			}
			for (int i = 0; i < Vehicles.Count; i++)
			{
				if (vehicle.CurrentFrame.distanceAlongLane > Vehicles[i].CurrentFrame.distanceAlongLane)
				{
					Vehicles.Insert(i, vehicle);
					return;
				}
			}
			Vehicles.Add(vehicle);
		}

		public VehicleModel GetLastVehicle(bool ignoreWaiting = true)
		{
			VehicleModel vehicleModel = null;
			foreach (VehicleModel vehicle in Vehicles)
			{
				if ((!ignoreWaiting || !vehicle.IsWaitingAtHouse) && (vehicleModel == null || vehicle.CurrentFrame.distanceAlongLane < vehicleModel.CurrentFrame.distanceAlongLane))
				{
					vehicleModel = vehicle;
				}
			}
			return vehicleModel;
		}

		public VehicleModel FirstVehicleFromHouse(HouseModel house)
		{
			VehicleModel vehicleModel = null;
			foreach (VehicleModel vehicle in Vehicles)
			{
				if (vehicle.house == house && (vehicleModel == null || vehicleModel.CurrentFrame.distanceAlongLane < vehicle.CurrentFrame.distanceAlongLane))
				{
					vehicleModel = vehicle;
				}
			}
			return vehicleModel;
		}

		public bool TryGetNextVehicleAfter(VehicleModel current, out VehicleModel next, out Fix64 distance)
		{
			if (connection.input.type == RoadType.Driveway)
			{
				next = null;
				distance = Fix64Consts.Zero;
				return true;
			}
			Fix64 distanceAlongLane = current.CurrentFrame.distanceAlongLane;
			bool condition = false;
			distance = Length;
			VehicleModel vehicleModel = null;
			foreach (VehicleModel vehicle in Vehicles)
			{
				if (vehicle == current)
				{
					condition = true;
					continue;
				}
				Fix64 fix = vehicle.CurrentFrame.distanceAlongLane - distanceAlongLane;
				if (fix > Fix64.Zero && fix < distance)
				{
					distance = fix;
					vehicleModel = vehicle;
				}
			}
			if (!Diagnostics.Verify(condition, "Can't check who is ahead of {0}, because it's not in {1}.", current, this))
			{
				next = null;
				distance = Fix64Consts.Zero;
				return false;
			}
			next = vehicleModel;
			if (next == null)
			{
				distance = Fix64.MaxValue;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.CheckForVehicleCollisionsWhenMerging))
			{
				Fix64 fix2 = Length - distanceAlongLane;
				foreach (LaneModel lane in roadChunk.lanes)
				{
					if (lane == this || lane.connection.output.direction != connection.output.direction)
					{
						continue;
					}
					foreach (VehicleModel vehicle2 in lane._vehicles)
					{
						Fix64 fix3 = lane.Length - vehicle2.CurrentFrame.distanceAlongLane;
						if (fix3 < fix2)
						{
							Fix64 fix4 = fix2 - fix3;
							if (fix4 < distance || next == null)
							{
								distance = fix4;
								next = vehicle2;
							}
						}
					}
				}
			}
			return true;
		}

		public Vector2Fixed PositionAtDistance(Fix64 distance, bool projectIfOver = false)
		{
			if (distance < Fix64.Zero)
			{
				if (projectIfOver)
				{
					return StartPosition + (StartPosition - lanePoints[1]).normalized * Fix64.Abs(distance);
				}
				return StartPosition;
			}
			Fix64 fix = distance;
			for (int i = 0; i < lanePoints.Count - 1; i++)
			{
				Vector2Fixed vector2Fixed = lanePoints[i];
				Vector2Fixed vector2Fixed2 = lanePoints[i + 1];
				Fix64 fix2 = Vector2Fixed.Distance(vector2Fixed, vector2Fixed2);
				if (fix2 > fix)
				{
					return vector2Fixed + (vector2Fixed2 - vector2Fixed).normalized * fix;
				}
				fix -= fix2;
			}
			if (projectIfOver)
			{
				return EndPosition + (EndPosition - lanePoints[lanePoints.Count - 2]).normalized * fix;
			}
			return EndPosition;
		}

		public void Initialize(RoadChunkModel owningChunk, RoadTileDefinition owningTileDefinition, RoadTileConnection connectionToReflect, Vector2Fixed worldOffset, bool isEndpointLane)
		{
			roadChunk = owningChunk;
			connection = connectionToReflect;
			RoadTilePath path = owningTileDefinition.GetPath(connection);
			_lanePoints = path.GetLogicalPoints(worldOffset);
			_length = path.Length;
			_tileDefinitionIndex = owningTileDefinition.index;
			_worldOffset = worldOffset;
			_isEndpointLane = isEndpointLane;
			_lineSegments.Clear();
		}

		public void Initialize(RoadChunkModel owningChunk, RoadTileConnection connectionToReflect, List<Vector2Fixed> bespokePath, bool isEndpointLane, bool isCarparkLane)
		{
			roadChunk = owningChunk;
			connection = connectionToReflect;
			_bespokeLanePoints = bespokePath;
			_lanePoints = _bespokeLanePoints;
			_isEndpointLane = isEndpointLane;
			_isCarparkLane = isCarparkLane;
			_lineSegments.Clear();
		}

		public void AddInboundLane(LaneModel inboundLane)
		{
			if (!_inboundLanes.Contains(inboundLane))
			{
				_inboundLanes.Add(inboundLane);
			}
		}

		public void AddOutboundLane(LaneModel outboundLane)
		{
			if (!_outboundLanes.Contains(outboundLane))
			{
				RecalculateSpeedLimit();
				_outboundLanes.Add(outboundLane);
				SetupPathfindingNodesForOutboundLane(outboundLane);
				_pathfinder.AddEdge(this, PathfindingStartNodeId, PathfindingEndNodeId, PathfindingCost);
			}
		}

		public bool RemoveInboundLane(LaneModel lane)
		{
			return _inboundLanes.Remove(lane);
		}

		public bool RemoveOutboundLane(LaneModel lane)
		{
			RecalculateSpeedLimit();
			return _outboundLanes.Remove(lane);
		}

		public void RemoveInboundAndOutboundLanes()
		{
			foreach (LaneModel inboundLane in _inboundLanes)
			{
				Diagnostics.Verify(inboundLane.RemoveOutboundLane(this), "Removing non-reciprocal inbound lane {0} from {1}.", inboundLane, this);
			}
			_inboundLanes.Clear();
			foreach (LaneModel outboundLane in _outboundLanes)
			{
				Diagnostics.Verify(outboundLane.RemoveInboundLane(this), "Remove non-reciprocal outbound lane {0} from {1}.", outboundLane, this);
			}
			_outboundLanes.Clear();
			RemovePathfinderEdge();
		}

		public override string ToString()
		{
			if (_lanePoints == null)
			{
				return $"[LaneModel Id={_id}, Connection={connection}, State={state}, Start Node={PathfindingStartNodeId}, End Node={PathfindingEndNodeId}]";
			}
			return $"[LaneModel Id={_id}, Connection={connection}, State={state}, Start=({(float)StartPosition.x:0.##}, {(float)StartPosition.y:0.##}), End=({(float)EndPosition.x:0.##}, {(float)EndPosition.y:0.##}), Start Node={PathfindingStartNodeId}, End Node={PathfindingEndNodeId}]";
		}

		public override void Reset()
		{
			base.Reset();
			state = RoadState.None;
			isTemporary = false;
			connection = default(RoadTileConnection);
			_worldOffset = default(Vector2Fixed);
			_speedLimit = -Fix64.One;
			_speedLimitScale = -Fix64.One;
			_id = -1;
			_tileDefinitionIndex = -1;
			_length = -Fix64Consts.One;
			_lanePoints = null;
			_bespokeLanePoints = null;
			RemovePathfinderEdge();
			_isEndpointLane = false;
			_isCarparkLane = false;
			_inboundLanes.Clear();
			_outboundLanes.Clear();
			roadChunk = null;
			_vehicles.Clear();
			_lineSegments.Clear();
			IsAboutToHotswap = false;
			hasBeenUsed = false;
		}

		public void OnCreatedInScope(IScope scope)
		{
			_id = NextId;
			NextId++;
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			RemovePathfinderEdge();
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnLaneModelReleased(this);
			}
			base.OnReleasedFromScope(scope);
		}

		private void RemovePathfinderEdge()
		{
			if (PathfindingStartNodeId != -1 && PathfindingEndNodeId != -1 && _pathfinder.IsActive)
			{
				_pathfinder.RemoveEdge(PathfindingStartNodeId, PathfindingEndNodeId);
			}
			PathfindingStartNodeId = -1;
			PathfindingEndNodeId = -1;
		}

		public void UpdateLaneCost(int newCost)
		{
			_pathfinder.ChangeEdgeCost(PathfindingStartNodeId, PathfindingEndNodeId, newCost);
		}

		public void OnDeserialized(IScope context)
		{
			if (_tileDefinitionIndex >= 0)
			{
				if (_bespokeLanePoints != null && _bespokeLanePoints.Count == 0)
				{
					_bespokeLanePoints = null;
				}
				RoadTileDefinition definitionForIndex = context.Get<RoadTileAtlas>().GetDefinitionForIndex(_tileDefinitionIndex);
				if (Diagnostics.Verify(definitionForIndex != null, "Could not find tile definition for deserialised LaneModel."))
				{
					RoadTilePath path = definitionForIndex.GetPath(connection);
					if (Diagnostics.Verify(path != null, "Could not find path for connection {0} in tile definition {1}.", connection, definitionForIndex))
					{
						_lanePoints = path.GetLogicalPoints(_worldOffset);
						_length = path.Length;
					}
				}
			}
			else
			{
				_lanePoints = _bespokeLanePoints;
			}
			_lineSegments.Clear();
			foreach (LaneModel outboundLane in _outboundLanes)
			{
				outboundLane._inboundLanes.Add(this);
				SetupPathfindingNodesForOutboundLane(outboundLane);
			}
			if (Diagnostics.Verify(PathfindingStartNodeId != -1 && PathfindingEndNodeId != -1, "Nodes not set up! There should always be at least one outbound lane, as it would otherwise be a dead end with no u-turn. Since there are no nodes, we're not creating an edge!"))
			{
				_pathfinder.AddEdge(this, PathfindingStartNodeId, PathfindingEndNodeId, PathfindingCost);
			}
			int num = 0;
			while (num < Vehicles.Count)
			{
				VehicleModel vehicleModel = Vehicles[num];
				if (!Diagnostics.Verify(vehicleModel.CurrentFrame.lane == this, "Vehicle is on lane {0}, but lane {1} wants it. The vehicle will be removed, but other things may break.", vehicleModel.CurrentFrame.lane, this))
				{
					Vehicles.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}

		private void SetupPathfindingNodesForOutboundLane(LaneModel outboundLane)
		{
			if (PathfindingStartNodeId == -1)
			{
				PathfindingStartNodeId = _pathfinder.AddNode(_isEndpointLane);
			}
			if (PathfindingEndNodeId == -1)
			{
				if (outboundLane.PathfindingStartNodeId == -1)
				{
					outboundLane.PathfindingStartNodeId = _pathfinder.AddNode(outboundLane._isEndpointLane);
				}
				PathfindingEndNodeId = outboundLane.PathfindingStartNodeId;
			}
			else if (outboundLane.PathfindingStartNodeId == -1)
			{
				outboundLane.PathfindingStartNodeId = PathfindingEndNodeId;
			}
			else if (PathfindingEndNodeId != outboundLane.PathfindingStartNodeId)
			{
				Diagnostics.Verify(_pathfinder.MergeNodes(PathfindingEndNodeId, outboundLane.PathfindingStartNodeId));
				outboundLane.PathfindingStartNodeId = PathfindingEndNodeId;
			}
		}

		private void BuildLineSegments()
		{
			_lineSegments.Clear();
			for (int i = 0; i < _lanePoints.Count - 1; i++)
			{
				_lineSegments.Add(new LineSegment((Vector2)_lanePoints[i], (Vector2)_lanePoints[i + 1]));
			}
		}

		public LaneModel()
			: base(1)
		{
		}
	}
}
