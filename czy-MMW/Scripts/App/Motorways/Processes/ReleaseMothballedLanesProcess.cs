using System.Collections.Generic;
using System.Linq;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using Unity.Profiling;
using UnityEngine;

namespace Motorways.Processes
{
	public class ReleaseMothballedLanesProcess : IProcess, IReusable
	{
		private class MothballedConnection
		{
			private readonly TileModel _tileModel;

			private readonly TileDirection _direction;

			private readonly TileDirection _roundaboutInputDirection;

			private readonly MotorwayModel _motorway;

			private MotorwayModel _replacementPendingMotorway;

			private List<LaneModel> AllLanes
			{
				get
				{
					List<LaneModel> list = new List<LaneModel>();
					list.AddRange(GetTileModel(0).roadChunk.GetLanesConnectedToDirection(RoadState.Mothballed, GetDirection(0)));
					list.AddRange(GetTileModel(1).roadChunk.GetLanesConnectedToDirection(RoadState.Mothballed, GetDirection(1)));
					TileCornerModel tileCornerModel = GetTileCornerModel();
					if (tileCornerModel != null)
					{
						TileDirectionBitfield directions = new TileDirectionBitfield
						{
							[GetDirection(0)] = true,
							[GetDirection(1)] = true
						};
						list.AddRange(tileCornerModel.roadChunk.GetLanesConnectedToDirections(RoadState.Mothballed, directions));
					}
					if (_motorway != null)
					{
						list.AddRange(_motorway.roadChunk.lanes);
					}
					return list;
				}
			}

			public bool CanBeReplacedByRoundabout => AllLanes.All((LaneModel laneModel) => laneModel.CanHotswap);

			public TileModel GetTileModel(int index)
			{
				if (_motorway == null)
				{
					if (index != 0)
					{
						return _tileModel.GetAdjacentTileModelInDirection(_direction);
					}
					return _tileModel;
				}
				if (index != 0)
				{
					return _motorway.EndTile;
				}
				return _motorway.StartTile;
			}

			public TileDirection GetDirection(int index)
			{
				if (_motorway == null)
				{
					if (index != 0)
					{
						return TileUtilities.GetOppositeDirection(_direction);
					}
					return _direction;
				}
				if (index != 0)
				{
					return _motorway.EndDirection;
				}
				return _motorway.StartDirection;
			}

			public TileCornerModel GetTileCornerModel()
			{
				if (_motorway == null && TileUtilities.IsDirectionDiagonal(_direction))
				{
					return _tileModel.GetAdjacentTileCornerModelInDirection(_direction);
				}
				return null;
			}

			public void Release()
			{
				Log.Info("Releasing connection {0}.", this);
				HashSet<VehicleModel> hashSet = new HashSet<VehicleModel>();
				HashSet<VehicleModel> hashSet2 = new HashSet<VehicleModel>();
				foreach (LaneModel allLane in AllLanes)
				{
					foreach (RoadChunkModel.InboundVehicle inboundVehicle in allLane.roadChunk.inboundVehicles)
					{
						if (inboundVehicle.chosenLane == allLane)
						{
							hashSet.Add(inboundVehicle.vehicle);
						}
					}
					foreach (RoadChunkModel.InboundVehicle returningInboundVehicle in allLane.roadChunk.returningInboundVehicles)
					{
						if (returningInboundVehicle.chosenLane == allLane)
						{
							hashSet2.Add(returningInboundVehicle.vehicle);
						}
					}
					Log.Info("Removing lane {0}.", allLane);
					allLane.roadChunk.RemoveLane(allLane);
				}
				if (hashSet.Count > 0 || hashSet2.Count > 0)
				{
					Log.Info("Going to clear and request repaths of {0} incoming and {1} outgoing vehicles", hashSet.Count, hashSet2.Count);
				}
				foreach (VehicleModel item in hashSet)
				{
					if (Diagnostics.Verify(item != null, "Why does a lane on {0} have a null inbound vehicle?", this))
					{
						item.ClearNonCommittedLanes();
						item.RequestPathfind(VehicleModel.PathfindUrgency.AsSoonAsPossible);
					}
				}
				foreach (VehicleModel item2 in hashSet2)
				{
					if (Diagnostics.Verify(item2 != null, "Why does a lane on {0} have a null inbound vehicle?", this))
					{
						item2.ClearReturnPath();
						item2.RequestReturnPathfind(VehicleModel.PathfindUrgency.AsSoonAsPossible);
					}
				}
				if (_motorway == null)
				{
					if (_roundaboutInputDirection != TileDirection.None)
					{
						GetTileModel(0).Tile.SetRoundaboutState(_roundaboutInputDirection, _direction, RoadState.None);
						return;
					}
					GetTileModel(0).Tile.SetNodeState(new RoadTileNode(GetDirection(0)), RoadState.None);
					GetTileModel(1).Tile.SetNodeState(new RoadTileNode(GetDirection(1)), RoadState.None);
					return;
				}
				if (_replacementPendingMotorway != null)
				{
					_replacementPendingMotorway.isHighBuildPriority = true;
					List<VehicleModel> list = new List<VehicleModel>();
					foreach (RoadChunkModel.InboundVehicle inboundVehicle2 in _motorway.roadChunk.inboundVehicles)
					{
						list.Add(inboundVehicle2.vehicle);
					}
					foreach (VehicleModel item3 in list)
					{
						Log.Info("Clearing paths for vehicle {0}.", item3.id);
						item3.ClearNonCommittedLanes();
						item3.RequestPathfind(VehicleModel.PathfindUrgency.AsSoonAsPossible);
					}
					list.Clear();
					foreach (RoadChunkModel.InboundVehicle returningInboundVehicle2 in _motorway.roadChunk.returningInboundVehicles)
					{
						list.Add(returningInboundVehicle2.vehicle);
					}
					foreach (VehicleModel item4 in list)
					{
						Log.Info("Clearing return paths for vehicle {0}.", item4.id);
						item4.ClearReturnPath();
						item4.RequestReturnPathfind(VehicleModel.PathfindUrgency.AsSoonAsPossible);
					}
				}
				_motorway.SetMotorwayAndNodeState(RoadState.None);
			}

			private bool IsReleasingOfConcreteHandledByRoundabout(ISimulation simulation)
			{
				ModelListEnumerator<RoundaboutModel> enumerator = simulation.GetModels<RoundaboutModel>().GetEnumerator();
				while (enumerator.MoveNext())
				{
					foreach (AdjacentTileConnection replacedConnection in enumerator.Current.ReplacedConnections)
					{
						if ((GetTileModel(0).Tile.Coordinates == replacedConnection.OriginCoordinates && GetTileModel(1).Tile.Coordinates == replacedConnection.DestinationCoordinates) | (GetTileModel(1).Tile.Coordinates == replacedConnection.OriginCoordinates && GetTileModel(0).Tile.Coordinates == replacedConnection.DestinationCoordinates))
						{
							return true;
						}
					}
				}
				return false;
			}

			public int ReleaseUpgrades(GameBehaviourModel behaviour, UpgradeDatabase upgradeDatabase, ISimulation simulation)
			{
				int num = 0;
				if (_motorway == null)
				{
					if (_roundaboutInputDirection == TileDirection.None)
					{
						if (IsReleasingOfConcreteHandledByRoundabout(simulation))
						{
							return 0;
						}
						Tile tile = GetTileModel(0).Tile;
						Tile tile2 = GetTileModel(1).Tile;
						RoadState num2 = tile.StateOfRoadInDirection(_direction);
						RoadState roadState = tile2.StateOfRoadInDirection(TileUtilities.GetOppositeDirection(_direction));
						if (num2 == RoadState.None && roadState == RoadState.None)
						{
							num = behaviour.GetConcreteCostForConnection(tile, tile2);
						}
					}
					else if (Roundabout.DoesConnectionOwnRoundabout(new RoadTileConnection(new RoadTileNode(_roundaboutInputDirection, RoadType.Roundabout), new RoadTileNode(_direction, RoadType.Roundabout))))
					{
						upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Roundabout);
					}
				}
				if (num > 0)
				{
					upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Concrete, num);
				}
				return num;
			}

			private bool CanMotorwayRelease(ISimulation simulation)
			{
				bool flag = false;
				foreach (LaneModel allLane in AllLanes)
				{
					if (allLane.HasTraversingOrCommittedVehicles)
					{
						return false;
					}
					flag |= allLane.roadChunk.DoesLaneHaveAnyInboundVehicles(allLane);
				}
				if (!flag)
				{
					Log.Info("Permitting motorway {0} to release because it has no traversing, committed, or inbound vehicles.", _motorway.Id);
					return true;
				}
				ModelListEnumerator<MotorwayModel> enumerator2 = simulation.GetModels<MotorwayModel>().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					MotorwayModel current2 = enumerator2.Current;
					if (current2.State != RoadState.Planned)
					{
						continue;
					}
					bool flag2 = current2.StartCoordinates == _motorway.StartCoordinates || current2.StartCoordinates == _motorway.EndCoordinates;
					bool flag3 = current2.EndCoordinates == _motorway.StartCoordinates || current2.EndCoordinates == _motorway.EndCoordinates;
					if (!flag2 && !flag3)
					{
						continue;
					}
					if (flag2 && flag3)
					{
						_replacementPendingMotorway = current2;
						break;
					}
					int motorwayInDirection = current2.StartTile.Tile.GetMotorwayInDirection(current2.StartDirection, RoadState.Mothballed);
					int motorwayInDirection2 = current2.EndTile.Tile.GetMotorwayInDirection(current2.EndDirection, RoadState.Mothballed);
					bool num = motorwayInDirection == -1 || motorwayInDirection == _motorway.Id;
					bool flag4 = motorwayInDirection2 == -1 || motorwayInDirection2 == _motorway.Id;
					if (!num || !flag4)
					{
						continue;
					}
					TileModel tileModel;
					TileModel tileModel2;
					if (flag2)
					{
						tileModel = current2.EndTile;
						tileModel2 = ((current2.StartCoordinates == _motorway.StartCoordinates) ? _motorway.EndTile : _motorway.StartTile);
					}
					else
					{
						tileModel = current2.StartTile;
						tileModel2 = ((current2.EndCoordinates == _motorway.StartCoordinates) ? _motorway.EndTile : _motorway.StartTile);
					}
					LaneModel laneModel = null;
					foreach (LaneModel lane in tileModel2.roadChunk.lanes)
					{
						if (lane.state == RoadState.Active)
						{
							laneModel = lane;
							break;
						}
					}
					LaneModel laneModel2 = null;
					foreach (LaneModel lane2 in tileModel.roadChunk.lanes)
					{
						if (lane2.state == RoadState.Active)
						{
							laneModel2 = lane2;
							break;
						}
					}
					if (laneModel != null && laneModel2 != null && simulation.Scope.Get<Pathfinder>().AreLanesConnected(laneModel, laneModel2, allowMothballedLaneUsage: false))
					{
						_replacementPendingMotorway = current2;
						break;
					}
				}
				if (_replacementPendingMotorway != null)
				{
					Log.Info("Permitting motorway {0} to release because it has no traversing or committed vehicles, and all inbound vehicles can use the pending motorway {1}.", _motorway.Id, _replacementPendingMotorway.Id);
					return true;
				}
				return false;
			}

			public bool CanRelease(ISimulation simulation, HashSet<Tile> hotSwappableRoundaboutCentres = null)
			{
				if (_motorway != null)
				{
					return CanMotorwayRelease(simulation);
				}
				bool flag = false;
				foreach (LaneModel allLane in AllLanes)
				{
					if (!allLane.CanRelease)
					{
						if (!allLane.CanHotswap)
						{
							return false;
						}
						flag = true;
					}
				}
				if (flag)
				{
					Tile tile = GetTileModel(0).Tile;
					Tile tile2 = GetTileModel(1).Tile;
					bool flag2 = Roundabout.IsTileCenterOfRoundabout(tile, RoadState.Planned) || Roundabout.IsTileCenterOfRoundabout(tile2, RoadState.Planned);
					bool num = flag2 || tile.HasRoundabout(RoadState.Planned) || tile2.HasRoundabout(RoadState.Planned);
					bool flag3 = TileUtilities.IsDirectionDiagonal(_direction) && flag2;
					if (!num)
					{
						return false;
					}
					if (((!tile.HasRoundabout(RoadState.Planned) && !Roundabout.IsTileCenterOfRoundabout(tile, RoadState.Planned)) || (!tile2.HasRoundabout(RoadState.Planned) && !Roundabout.IsTileCenterOfRoundabout(tile2, RoadState.Planned))) && !flag3)
					{
						return false;
					}
					TileModel tileModel = (tile.HasRoundabout(RoadState.Planned) ? GetTileModel(0) : (tile2.HasRoundabout(RoadState.Planned) ? GetTileModel(1) : (Roundabout.IsTileCenterOfRoundabout(tile) ? GetTileModel(0).GetAdjacentTileModelInDirection(TileDirection.North) : GetTileModel(1).GetAdjacentTileModelInDirection(TileDirection.North))));
					if (tileModel == null)
					{
						return false;
					}
					Tile centerTile = Roundabout.GetCenterTile(tileModel.Tile, RoadState.Planned);
					if (!Diagnostics.Verify(hotSwappableRoundaboutCentres != null, "hotSwappableRoundaboutCentres is null in CanRelease when it's needed") || !hotSwappableRoundaboutCentres.Contains(centerTile))
					{
						return false;
					}
				}
				return true;
			}

			public MothballedConnection(TileModel tileModel, TileDirection direction)
			{
				_tileModel = tileModel;
				_direction = direction;
				_roundaboutInputDirection = TileDirection.None;
				_motorway = null;
			}

			public MothballedConnection(TileModel tileModel, RoadTileConnection roundaboutConnection)
			{
				_tileModel = tileModel;
				_direction = roundaboutConnection.output.direction;
				_roundaboutInputDirection = roundaboutConnection.input.direction;
				_motorway = null;
			}

			public MothballedConnection(MotorwayModel motorwayModel)
			{
				_tileModel = null;
				_direction = TileDirection.None;
				_roundaboutInputDirection = TileDirection.None;
				_motorway = motorwayModel;
			}

			public override bool Equals(object obj)
			{
				if (obj is MothballedConnection other)
				{
					return Equals(other);
				}
				return false;
			}

			public bool Equals(MothballedConnection other)
			{
				if (_motorway != other._motorway)
				{
					return false;
				}
				if (_motorway == null)
				{
					return (_tileModel == other.GetTileModel(0) && _direction == other.GetDirection(0)) | (_tileModel == other.GetTileModel(1) && _direction == other.GetDirection(1));
				}
				return true;
			}

			public override int GetHashCode()
			{
				if (_motorway == null)
				{
					return _tileModel.Coordinates.GetHashCode() ^ _tileModel.GetAdjacentTileModelInDirection(_direction).Coordinates.GetHashCode();
				}
				return _motorway.GetHashCode();
			}

			public override string ToString()
			{
				if (_motorway == null)
				{
					if (_roundaboutInputDirection != TileDirection.None)
					{
						return $"[MothballedConnection Tile={_tileModel.Coordinates}, RoundaboutConnection={_roundaboutInputDirection} -> {_direction}]";
					}
					return $"[MothballedConnection Tile={_tileModel.Coordinates}, Direction={_direction}]";
				}
				return $"[MothballedConnection Motorway={_motorway}]";
			}
		}

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ReleaseMothballedLanesProcess");

		[Serialize(false, null)]
		private readonly HashSet<MothballedConnection> _mothballedConnections = new HashSet<MothballedConnection>();

		[Serialize(false, null)]
		private readonly HashSet<MothballedConnection> _connectionsToRelease = new HashSet<MothballedConnection>();

		[Serialize(false, null)]
		private readonly List<LaneModel> _temporaryLanesToRelease = new List<LaneModel>();

		[Dependency]
		private IScope _scope;

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabase;

		[Dependency]
		private RoadTileAtlas _roadTileAtlas;

		[Dependency]
		private City _city;

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private GameBehaviourModel _behaviour;

		private static readonly ProfilerMarker Profiler_Step = new ProfilerMarker(ProfilerCategory.Scripts, "ReleaseMothballedLanesProcess.Step()");

		private static readonly ProfilerMarker Profiler_CollateMothballedConnections = new ProfilerMarker(ProfilerCategory.Scripts, "ReleaseMothballedLanesProcess.CollateMothballedConnections()");

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			_connectionsToRelease.Clear();
			ModelListEnumerator<PassageModel> enumerator = simulation.GetModels<PassageModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				PassageModel current = enumerator.Current;
				if (current.State != RoadState.Mothballed)
				{
					continue;
				}
				Passage passage = current.Passage;
				IList<Vector2Int> crossingCoordinates = passage.CrossingCoordinates;
				MothballedConnection mothballedConnection = new MothballedConnection(_tilemap.GetTileModel(passage.StartCoordinates), TileUtilities.GetDirectionBetweenAdjacentCoordinates(passage.StartCoordinates, crossingCoordinates[0]));
				MothballedConnection mothballedConnection2 = null;
				if (passage.IsComplete)
				{
					mothballedConnection2 = new MothballedConnection(_tilemap.GetTileModel(passage.EndCoordinates), TileUtilities.GetDirectionBetweenAdjacentCoordinates(passage.EndCoordinates, crossingCoordinates[crossingCoordinates.Count - 1]));
				}
				if (mothballedConnection.CanRelease(simulation) && (mothballedConnection2 == null || mothballedConnection2.CanRelease(simulation)))
				{
					_connectionsToRelease.Add(mothballedConnection);
					for (int i = 1; i < crossingCoordinates.Count; i++)
					{
						TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(crossingCoordinates[i], crossingCoordinates[i - 1]);
						TileModel tileModel = _tilemap.GetTileModel(crossingCoordinates[i]);
						_connectionsToRelease.Add(new MothballedConnection(tileModel, directionBetweenAdjacentCoordinates));
					}
					if (mothballedConnection2 != null)
					{
						_connectionsToRelease.Add(mothballedConnection2);
					}
					_upgradeDatabase.ReleaseMothballedUpgrade(passage.UpgradeType);
					simulation.RemoveModel(current);
				}
			}
			CollateMothballedConnections(simulation);
			HashSet<Tile> hashSet = new HashSet<Tile>();
			ModelListEnumerator<RoundaboutModel> enumerator2 = simulation.GetModels<RoundaboutModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				RoundaboutModel current2 = enumerator2.Current;
				if (current2.State == RoadState.Planned)
				{
					TileModel tileModel2 = _tilemap.GetTileModel(current2.OriginCoordinates);
					if (CanPlannedRoundaboutHotswap(tileModel2, _mothballedConnections))
					{
						hashSet.Add(tileModel2.Tile);
					}
				}
			}
			foreach (MothballedConnection mothballedConnection5 in _mothballedConnections)
			{
				if (mothballedConnection5.CanRelease(simulation, hashSet))
				{
					_connectionsToRelease.Add(mothballedConnection5);
				}
			}
			_mothballedConnections.Clear();
			enumerator2 = simulation.GetModels<RoundaboutModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				RoundaboutModel current4 = enumerator2.Current;
				if (current4.State != RoadState.Mothballed)
				{
					continue;
				}
				TileModel centerTileModel = current4.CenterTileModel;
				bool flag = false;
				TileDirection[] diagonalDirections = TileUtilities.DiagonalDirections;
				foreach (TileDirection tileDirection in diagonalDirections)
				{
					TileModel adjacentTileModelInDirection = centerTileModel.GetAdjacentTileModelInDirection(tileDirection);
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(tileDirection);
					if (adjacentTileModelInDirection != null && adjacentTileModelInDirection.Tile.HasTwoLaneRoadInDirection(oppositeDirection, RoadState.Mothballed) && adjacentTileModelInDirection.roadChunk.GetLanesConnectedToDirection(RoadState.Mothballed, oppositeDirection).Exists((LaneModel lane) => !lane.CanHotswap))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					SetRoundaboutWantsHotswap(centerTileModel, doesWantHotswap: false, null, out var _);
					continue;
				}
				List<MothballedConnection> list = new List<MothballedConnection>();
				foreach (Tile item2 in Roundabout.GetTilesInRoundabout(current4.CenterTileModel.Tile, RoadState.Mothballed))
				{
					TileModel tileModel3 = _tilemap.GetTileModel(item2.Coordinates);
					if (Diagnostics.Verify(tileModel3 != null, "There is no corresponding tile model at {0}. This roundabout will not release nicely.", item2.Coordinates) && Diagnostics.Verify(item2.GetRoundaboutConnection(RoadState.Mothballed).output.direction != TileDirection.None, "The tile at {0} does not have the expected mothballed roundabout connection.", item2.Coordinates))
					{
						MothballedConnection mothballedConnection3 = new MothballedConnection(tileModel3, item2.GetRoundaboutConnection(RoadState.Mothballed));
						if (!mothballedConnection3.CanRelease(simulation, hashSet))
						{
							list.Clear();
							break;
						}
						list.Add(mothballedConnection3);
					}
				}
				centerTileModel = current4.CenterTileModel;
				Tile tile = centerTileModel.Tile;
				if (list.Count == 0)
				{
					bool flag2 = true;
					TileModel tileModel4 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.East));
					TileModel tileModel5 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.NorthWest));
					TileModel tileModel6 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.North));
					TileModel tileModel7 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.NorthEast));
					TileModel tileModel8 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.West));
					TileModel tileModel9 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.SouthWest));
					TileModel tileModel10 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.South));
					TileModel tileModel11 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, TileDirection.SouthEast));
					TileModel[] array = new TileModel[8] { tileModel4, tileModel7, tileModel6, tileModel5, tileModel8, tileModel9, tileModel10, tileModel11 };
					TileDirection[] array2 = new TileDirection[8]
					{
						TileDirection.East,
						TileDirection.NorthEast,
						TileDirection.North,
						TileDirection.NorthWest,
						TileDirection.West,
						TileDirection.SouthWest,
						TileDirection.South,
						TileDirection.SouthEast
					};
					TileDirection[] array3 = new TileDirection[8]
					{
						TileDirection.North,
						TileDirection.West,
						TileDirection.West,
						TileDirection.South,
						TileDirection.South,
						TileDirection.East,
						TileDirection.East,
						TileDirection.North
					};
					TileDirection[] array4 = new TileDirection[8]
					{
						TileDirection.South,
						TileDirection.East,
						TileDirection.East,
						TileDirection.North,
						TileDirection.North,
						TileDirection.West,
						TileDirection.West,
						TileDirection.South
					};
					TileDirection[] array5 = new TileDirection[8]
					{
						TileDirection.NorthWest,
						TileDirection.None,
						TileDirection.SouthWest,
						TileDirection.None,
						TileDirection.SouthEast,
						TileDirection.None,
						TileDirection.NorthEast,
						TileDirection.None
					};
					TileDirection[] array6 = new TileDirection[8]
					{
						TileDirection.SouthWest,
						TileDirection.None,
						TileDirection.NorthWest,
						TileDirection.None,
						TileDirection.NorthEast,
						TileDirection.None,
						TileDirection.SouthEast,
						TileDirection.None
					};
					TileDirection[] directionToCentre = new TileDirection[8]
					{
						TileDirection.West,
						TileDirection.SouthWest,
						TileDirection.South,
						TileDirection.SouthEast,
						TileDirection.East,
						TileDirection.NorthEast,
						TileDirection.North,
						TileDirection.NorthWest
					};
					int tileIndex;
					int j;
					for (tileIndex = 0; tileIndex < array.Length - 1; tileIndex = j)
					{
						TileModel obj = array[tileIndex];
						if (obj != null && obj.roadChunk.lanes.Exists((LaneModel lane) => (((lane.connection.input.type == RoadType.Roundabout) ^ (lane.connection.output.type == RoadType.Roundabout)) || (tileIndex % 2 == 1 && (lane.connection.input.direction == directionToCentre[tileIndex] || lane.connection.output.direction == directionToCentre[tileIndex]))) && !lane.CanRelease))
						{
							int otherTileIndex;
							for (otherTileIndex = tileIndex + 1; otherTileIndex < array.Length; otherTileIndex = j)
							{
								TileModel obj2 = array[otherTileIndex];
								if (obj2 != null && obj2.roadChunk.lanes.Exists((LaneModel lane) => (((lane.connection.input.type == RoadType.Roundabout) ^ (lane.connection.output.type == RoadType.Roundabout)) || (otherTileIndex % 2 == 1 && (lane.connection.input.direction == directionToCentre[otherTileIndex] || lane.connection.output.direction == directionToCentre[otherTileIndex]))) && !lane.CanRelease))
								{
									bool flag3 = false;
									int num = otherTileIndex - tileIndex;
									int num2 = ((tileIndex > 0) ? (tileIndex - 1) : (array.Length - 1));
									int num3 = (tileIndex + 1) % array.Length;
									TileDirection tileDirection2 = ((num == 1) ? array3[tileIndex] : ((num == array.Length - 1) ? array4[tileIndex] : ((num == 2) ? array5[tileIndex] : ((num != array.Length - 2) ? TileDirection.None : array6[tileIndex]))));
									if (tileDirection2 != TileDirection.None && array[tileIndex].Tile.HasTwoLaneRoadInDirection(tileDirection2, RoadState.ActiveOrPending))
									{
										flag3 = true;
									}
									else if (num == 2 && array[num3] != null && array[tileIndex].Tile.HasTwoLaneRoadInDirection(array3[tileIndex], RoadState.ActiveOrPending) && array[num3].Tile.HasTwoLaneRoadInDirection(array3[num3], RoadState.ActiveOrPending))
									{
										flag3 = true;
									}
									else if (num == array.Length - 2 && array[num2] != null && array[tileIndex].Tile.HasTwoLaneRoadInDirection(array4[tileIndex], RoadState.ActiveOrPending) && array[num2].Tile.HasTwoLaneRoadInDirection(array4[num2], RoadState.ActiveOrPending))
									{
										flag3 = true;
									}
									else if (centerTileModel.Tile.HasTwoLaneRoadInDirection(array2[otherTileIndex], RoadState.ActiveOrPending) && centerTileModel.Tile.HasTwoLaneRoadInDirection(array2[tileIndex], RoadState.ActiveOrPending))
									{
										flag3 = true;
									}
									if (!flag3)
									{
										flag2 = false;
									}
								}
								j = otherTileIndex + 1;
							}
						}
						j = tileIndex + 1;
					}
					bool doesWantHotswap = flag2;
					SetRoundaboutWantsHotswap(centerTileModel, doesWantHotswap, list, out var canHotswapNow2);
					foreach (LaneModel item3 in centerTileModel.roadChunk.lanes.Where((LaneModel lane) => lane.connection.input.type == RoadType.Roundabout || lane.connection.output.type == RoadType.Roundabout))
					{
						item3.IsAboutToHotswap = flag2;
						canHotswapNow2 &= item3.CanHotswap;
					}
					diagonalDirections = TileUtilities.DiagonalDirections;
					foreach (TileDirection direction in diagonalDirections)
					{
						TileModel tileModel12 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, direction));
						if (tileModel12 == null)
						{
							continue;
						}
						foreach (LaneModel lane in tileModel12.roadChunk.lanes)
						{
							if ((lane.connection.input.type == RoadType.Roundabout && lane.connection.input.direction == TileUtilities.GetOppositeDirection(direction)) || (lane.connection.output.type == RoadType.Roundabout && lane.connection.output.direction == TileUtilities.GetOppositeDirection(direction)))
							{
								lane.IsAboutToHotswap = flag2;
								canHotswapNow2 &= lane.CanHotswap;
							}
						}
					}
					if (!canHotswapNow2)
					{
						list.Clear();
					}
				}
				Vector2Int centerCoordinates = current4.CenterCoordinates;
				diagonalDirections = TileUtilities.DiagonalDirections;
				foreach (TileDirection direction2 in diagonalDirections)
				{
					TileModel tileModel13 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(centerCoordinates, direction2));
					TileDirection oppositeDirection2 = TileUtilities.GetOppositeDirection(direction2);
					if (tileModel13 != null && tileModel13.Tile.HasTwoLaneRoadInDirection(oppositeDirection2, RoadState.Mothballed) && !tileModel13.Tile.IsNodePermanent(oppositeDirection2))
					{
						MothballedConnection mothballedConnection4 = new MothballedConnection(tileModel13, oppositeDirection2);
						if (mothballedConnection4.CanRelease(simulation, hashSet))
						{
							_connectionsToRelease.Add(mothballedConnection4);
						}
					}
				}
				if (list.Count <= 0)
				{
					continue;
				}
				Log.Info("Releasing roundabout at {0}.", centerCoordinates);
				foreach (MothballedConnection item4 in list)
				{
					_connectionsToRelease.Add(item4);
				}
			}
			if (_connectionsToRelease.Any())
			{
				HashSet<TileModel> hashSet2 = new HashSet<TileModel>();
				int num4 = 0;
				foreach (MothballedConnection item5 in _connectionsToRelease)
				{
					item5.Release();
					int num5 = item5.ReleaseUpgrades(_behaviour, _upgradeDatabase, simulation);
					num4 += num5;
					hashSet2.Add(item5.GetTileModel(0));
					hashSet2.Add(item5.GetTileModel(1));
				}
				if (num4 > 0 && _city.Rules.RecordsGameStatistics())
				{
					_player.AchievementStatistics.LogDeletedUpgrade(UpgradeType.Concrete, num4, _scope.Get<IAchievementHandler>());
				}
				foreach (TileModel item6 in hashSet2)
				{
					if (item6.Tile.HasTrafficLight && !TileEditor.TileSupportsTrafficLight(item6.Tile))
					{
						item6.Tile.HasTrafficLight = false;
						_upgradeDatabase.MothballUpgrade(UpgradeType.TrafficLight);
						_upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.TrafficLight);
					}
					TileDirectionBitfield twoLaneRoads = item6.Tile.GetTwoLaneRoads(RoadState.Live);
					TileDirectionBitfield twoLaneRoads2 = item6.Tile.GetTwoLaneRoads(RoadState.Mothballed);
					if (twoLaneRoads2.Count == 1 && twoLaneRoads.Equals(twoLaneRoads2))
					{
						TileDirection tileDirection3 = twoLaneRoads2[0];
						RoadTileConnection connection = new RoadTileConnection(new RoadTileNode(tileDirection3), new RoadTileNode(tileDirection3));
						if (item6.roadChunk.HasLaneForConnection(connection))
						{
							Log.Info("Not adding a u-turn lane on tile {0} in direction {1} because one already exists.", item6.Coordinates, tileDirection3);
							continue;
						}
						RoadTileSignature roadTileSignature = _scope.Get<RoadTileSignature>();
						roadTileSignature.AddConnection(connection);
						RoadTileDefinition definitionForSignature = _roadTileAtlas.GetDefinitionForSignature(roadTileSignature);
						_scope.Release(roadTileSignature);
						bool isEndpointLane = item6.Tile.ContentType == TileContentType.House;
						item6.AddLane(connection, definitionForSignature, RoadState.Mothballed, isEndpointLane);
					}
				}
				_connectionsToRelease.Clear();
				simulation.GetModel<CityModel>().OnLanesReleased();
			}
			if (_tilemap.TemporaryLanes.Count <= 0)
			{
				return;
			}
			foreach (LaneModel temporaryLane in _tilemap.TemporaryLanes)
			{
				if (temporaryLane.CanRelease)
				{
					_temporaryLanesToRelease.Add(temporaryLane);
				}
			}
			if (_temporaryLanesToRelease.Count <= 0)
			{
				return;
			}
			foreach (LaneModel item7 in _temporaryLanesToRelease)
			{
				item7.roadChunk.RemoveLane(item7);
			}
			_temporaryLanesToRelease.Clear();
			void SetRoundaboutWantsHotswap(TileModel roundaboutCentre, bool flag4, List<MothballedConnection> roundaboutConnectionsToRelease, out bool reference)
			{
				reference = flag4;
				foreach (Tile item8 in Roundabout.GetTilesInRoundabout(roundaboutCentre.Tile, RoadState.Mothballed))
				{
					TileModel tileModel14 = _tilemap.GetTileModel(item8.Coordinates);
					foreach (LaneModel item9 in tileModel14.roadChunk.lanes.Where((LaneModel lane) => lane.connection.input.type == RoadType.Roundabout || lane.connection.output.type == RoadType.Roundabout))
					{
						item9.IsAboutToHotswap = flag4;
						reference &= item9.CanHotswap;
						if (item9.connection.IsRoundabout)
						{
							foreach (LaneModel inboundLane in item9.InboundLanes)
							{
								inboundLane.IsAboutToHotswap = flag4;
								reference &= inboundLane.CanHotswap;
							}
							foreach (LaneModel outboundLane in item9.OutboundLanes)
							{
								outboundLane.IsAboutToHotswap = flag4;
								reference &= outboundLane.CanHotswap;
							}
						}
					}
					if (reference && Diagnostics.Verify(roundaboutConnectionsToRelease != null))
					{
						MothballedConnection item = new MothballedConnection(tileModel14, item8.GetRoundaboutConnection(RoadState.Mothballed));
						roundaboutConnectionsToRelease.Add(item);
					}
				}
			}
		}

		private bool CanPlannedRoundaboutHotswap(TileModel plannedRoundaboutCenter, HashSet<MothballedConnection> allMothballedConnections)
		{
			bool isAboutToHotswap = true;
			bool result = true;
			HashSet<LaneModel> hashSet = new HashSet<LaneModel>();
			foreach (Tile item in Roundabout.GetTilesInRoundabout(plannedRoundaboutCenter.Tile, RoadState.Planned))
			{
				if (!item.IsPlannedRoundaboutBlocked)
				{
					continue;
				}
				RoadTileConnection roundaboutConnection = item.GetRoundaboutConnection(RoadState.Planned);
				foreach (LaneModel lane in _tilemap.GetTileModel(item.Coordinates).roadChunk.lanes)
				{
					if (lane.connection.input.type == RoadType.Roundabout || lane.connection.output.type == RoadType.Roundabout)
					{
						isAboutToHotswap = false;
						result = false;
						break;
					}
					TileDirectionBitfield invalidExitsForConnection = Roundabout.GetInvalidExitsForConnection(roundaboutConnection.input.direction, roundaboutConnection.output.direction);
					if (invalidExitsForConnection[lane.connection.input.direction])
					{
						hashSet.Add(lane);
						foreach (LaneModel inboundLane in lane.InboundLanes)
						{
							hashSet.Add(inboundLane);
						}
						if (!lane.CanHotswap)
						{
							result = false;
						}
					}
					if (!invalidExitsForConnection[lane.connection.output.direction])
					{
						continue;
					}
					hashSet.Add(lane);
					foreach (LaneModel outboundLane in lane.OutboundLanes)
					{
						hashSet.Add(outboundLane);
					}
					if (!lane.CanHotswap)
					{
						result = false;
					}
				}
			}
			Tile centerTile = Roundabout.GetCenterTile(plannedRoundaboutCenter.Tile, RoadState.Planned);
			TileModel centreTileModel = _tilemap.GetTileModel(centerTile.Coordinates);
			foreach (LaneModel lane2 in centreTileModel.roadChunk.lanes)
			{
				if (!Diagnostics.Verify(lane2.state == RoadState.Mothballed, "Found non-mothballed lane {0} for tile {1} which is supposed to be the centre tile of a planned roundabout!", lane2, centerTile))
				{
					continue;
				}
				hashSet.Add(lane2);
				if (lane2.connection.input.type == RoadType.Roundabout || lane2.connection.output.type == RoadType.Roundabout)
				{
					result = false;
					isAboutToHotswap = false;
					continue;
				}
				if (!lane2.CanHotswap)
				{
					result = false;
				}
				if (lane2.connection.IsRoundabout)
				{
					result = false;
				}
				if (TileUtilities.IsDirectionDiagonal(lane2.connection.output.direction))
				{
					foreach (LaneModel outboundLane2 in lane2.OutboundLanes)
					{
						hashSet.Add(outboundLane2);
						if (!outboundLane2.CanHotswap)
						{
							result = false;
						}
					}
				}
				if (!TileUtilities.IsDirectionDiagonal(lane2.connection.input.direction))
				{
					continue;
				}
				foreach (LaneModel inboundLane2 in lane2.InboundLanes)
				{
					hashSet.Add(inboundLane2);
					if (!inboundLane2.CanHotswap)
					{
						result = false;
					}
				}
			}
			if (allMothballedConnections != null)
			{
				foreach (MothballedConnection item2 in allMothballedConnections.Where((MothballedConnection connection) => connection.GetTileModel(0) == centreTileModel || connection.GetTileModel(1) == centreTileModel))
				{
					if (!item2.CanBeReplacedByRoundabout)
					{
						result = false;
					}
					if (TileUtilities.IsDirectionDiagonal(item2.GetDirection(0)) && ((item2.GetTileModel(0) == centreTileModel) ? item2.GetTileModel(1) : item2.GetTileModel(0)).roadChunk.lanes.Exists((LaneModel lane) => !lane.connection.IsUTurn && lane.state == RoadState.Mothballed))
					{
						isAboutToHotswap = false;
						result = false;
					}
				}
			}
			foreach (LaneModel item3 in hashSet)
			{
				item3.IsAboutToHotswap = isAboutToHotswap;
			}
			return result;
		}

		private void CollateMothballedConnections(ISimulation simulation)
		{
			_mothballedConnections.Clear();
			foreach (AdjacentTileConnection mothballedTileConnection in _tilemap.MothballedTileConnections)
			{
				_mothballedConnections.Add(new MothballedConnection(_tilemap.GetTileModel(mothballedTileConnection.OriginCoordinates), mothballedTileConnection.OriginDirection));
			}
			ModelListEnumerator<RoundaboutModel> enumerator2 = simulation.GetModels<RoundaboutModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				RoundaboutModel current2 = enumerator2.Current;
				TileDirectionBitfield.Enumerator enumerator3 = current2.CenterTileModel.Tile.GetTwoLaneRoads(RoadState.Mothballed).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					TileDirection current3 = enumerator3.Current;
					if (current2.CenterTileModel.GetAdjacentTileModelInDirection(current3).Tile.GetTwoLaneRoadStateInDirection(TileUtilities.GetOppositeDirection(current3)) != RoadState.Mothballed)
					{
						_mothballedConnections.Add(new MothballedConnection(current2.CenterTileModel, current3));
					}
				}
			}
			ModelListEnumerator<MotorwayModel> enumerator4 = simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator4.MoveNext())
			{
				MotorwayModel current4 = enumerator4.Current;
				if (current4.State == RoadState.Mothballed)
				{
					_mothballedConnections.Add(new MothballedConnection(current4));
				}
			}
		}

		public void Reset()
		{
			_mothballedConnections.Clear();
			_connectionsToRelease.Clear();
			_temporaryLanesToRelease.Clear();
		}
	}
}
