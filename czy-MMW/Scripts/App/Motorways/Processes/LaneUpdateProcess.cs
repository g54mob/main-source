using System.Collections.Generic;
using System.Linq;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Processes
{
	public class LaneUpdateProcess : IProcess, IReusable
	{
		[Serialize(false, null)]
		private readonly List<LaneModel> _lanesChanged = new List<LaneModel>();

		[Serialize(false, null)]
		private readonly List<TileCornerModel> _tileCornersToUpdate = new List<TileCornerModel>();

		[Serialize(false, null)]
		private readonly List<MotorwayModel> _motorwaysToUpdate = new List<MotorwayModel>();

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LaneUpdateProcess");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private RoadTileAtlas _atlas;

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private Pathfinder _pathfinder;

		private CityModel _city;

		public void Step(ISimulation simulation, Fix64 deltaTime)
		{
			_tilemap.ActivateUnblockedPendingLanes();
			_city = simulation.GetModel<CityModel>();
			bool flag = false;
			foreach (TileModel changedTile in _tilemap.ChangedTiles)
			{
				Tile tile = changedTile.Tile;
				if (tile.ContentType == TileContentType.Carpark)
				{
					continue;
				}
				RoadTileSignature roadTileSignature = tile.CreateSignature(RoadState.Active);
				RoadTileSignature roadTileSignature2 = tile.CreateSignature(RoadState.Live);
				List<RoadTileConnection> list = new List<RoadTileConnection>(roadTileSignature.Connections);
				List<RoadTileConnection> list2 = new List<RoadTileConnection>(roadTileSignature2.Connections);
				foreach (LaneModel lane in changedTile.roadChunk.lanes)
				{
					bool flag2 = list.Contains(lane.connection);
					bool flag3 = lane.state == RoadState.Active;
					if (flag2 && !flag3)
					{
						lane.state = RoadState.Active;
						_lanesChanged.Add(lane);
						TryAddUpdatedTileCorner(changedTile, lane);
					}
					else if (!flag2 && flag3)
					{
						lane.state = RoadState.Mothballed;
						_lanesChanged.Add(lane);
						TryAddUpdatedTileCorner(changedTile, lane);
					}
					if (!flag2 && tile.ContentType != TileContentType.House && !roadTileSignature2.HasConnection(lane.connection))
					{
						if (lane.connection.IsUTurn && !lane.isTemporary)
						{
							_tilemap.TemporaryLanes.Add(lane);
							lane.isTemporary = true;
						}
					}
					else if (lane.isTemporary)
					{
						_tilemap.TemporaryLanes.Remove(lane);
						lane.isTemporary = false;
					}
					if (flag2)
					{
						list.Remove(lane.connection);
					}
					list2.Remove(lane.connection);
				}
				if (list2.Count > 0)
				{
					RoadTileDefinition definitionForSignature = _atlas.GetDefinitionForSignature(roadTileSignature2);
					if (Diagnostics.Verify(definitionForSignature != null, "Tile at {0} has invalid live signature {1}.", tile.Coordinates, roadTileSignature2))
					{
						foreach (RoadTileConnection item in list2)
						{
							RoadState initialState = RoadState.Mothballed;
							if (list.Contains(item))
							{
								initialState = RoadState.Active;
								list.Remove(item);
							}
							bool flag4 = tile.ContentType == TileContentType.House;
							LaneModel laneModel = changedTile.AddLane(item, definitionForSignature, initialState, flag4);
							_lanesChanged.Add(laneModel);
							flag = true;
							TileCornerModel tileCornerModel = TryAddUpdatedTileCorner(changedTile, laneModel);
							ModelList<TrainCrossingModel> models = simulation.GetModels<TrainCrossingModel>();
							bool flag5 = false;
							ModelListEnumerator<TrainCrossingModel> enumerator4 = models.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								if (enumerator4.Current.RoadChunkModel == changedTile.roadChunk)
								{
									flag5 = true;
									break;
								}
							}
							if (flag5)
							{
								continue;
							}
							if (tileCornerModel != null && !tileCornerModel.roadChunk.IsRoundabout && _city.Mode != GameMode.Background && !flag4)
							{
								List<TileModel> list3 = _tilemap.ChangedTiles.ToList();
								int num = -1;
								for (int i = 0; i < list3.Count; i++)
								{
									if (list3[i] == changedTile)
									{
										num = i;
									}
								}
								if (num == -1)
								{
									continue;
								}
								if (list3.Count >= 2)
								{
									int num2 = num + 1;
									if (num2 >= list3.Count)
									{
										num2 = num - 1;
									}
									List<Vector2Int> thePerpendicularDiagonalPositions = TileUtilities.GetThePerpendicularDiagonalPositions(list3[num].Coordinates, list3[num2].Coordinates);
									if (thePerpendicularDiagonalPositions == null)
									{
										continue;
									}
									int num3 = 0;
									foreach (Vector2Int item2 in thePerpendicularDiagonalPositions)
									{
										TileModel tileModel = _tilemap.GetTileModel(item2);
										if (tileModel != null && tileModel.Tile.HasRailConnection)
										{
											num3++;
										}
									}
									if (num3 != 0 && num3 == thePerpendicularDiagonalPositions.Count && tileCornerModel.roadChunk.TrainCrossingModel == null && changedTile.roadChunk != tileCornerModel.roadChunk)
									{
										Vector2Int vector2Int = list3[num2].Coordinates - list3[num].Coordinates;
										TileDirection closestDirection = TileUtilities.GetClosestDirection(-vector2Int);
										CornerAdjacencyReference cornerDefinition = new CornerAdjacencyReference(list3[num2].Coordinates, closestDirection);
										if (_tilemap.GetTileCornerModel(cornerDefinition)?.roadChunk?.TrainCrossingModel != null)
										{
											break;
										}
										tileCornerModel.roadChunk.TrainCrossingModel = simulation.Scope.Get<TrainCrossingModel>();
										tileCornerModel.roadChunk.TrainCrossingModel.Initialize(tile, tileCornerModel.roadChunk, vector2Int);
										simulation.AddModel(tileCornerModel.roadChunk.TrainCrossingModel);
									}
								}
							}
							TryAddUpdatedMotorway(laneModel);
						}
					}
				}
				if (tile.ContentType == TileContentType.Tree && (tile.GetTwoLaneRoads(RoadState.Active, Tile.MotorwayInclusion.Include).Count > 0 || tile.HasRoundabout(RoadState.Active)))
				{
					TreeModel treeModel = tile.ContentModel as TreeModel;
					if (Diagnostics.Verify(treeModel != null, "Tile {0} says it is a tree, but has a content of {1} instead.", tile, tile.ContentModel))
					{
						treeModel.Bulldoze();
					}
				}
				if (tile.ContentType != TileContentType.Carpark && tile.ContentType != TileContentType.Destination && changedTile.roadChunk.TrainCrossingModel == null && changedTile.RailTileModel != null && changedTile.roadChunk.lanes.Count > 0)
				{
					changedTile.roadChunk.TrainCrossingModel = simulation.Scope.Get<TrainCrossingModel>();
					changedTile.roadChunk.TrainCrossingModel.Initialize(tile, changedTile.roadChunk, Vector2Int.zero);
					simulation.AddModel(changedTile.roadChunk.TrainCrossingModel);
				}
				if (list.Count > 0)
				{
					RoadTileDefinition definitionForSignature2 = _atlas.GetDefinitionForSignature(roadTileSignature);
					if (Diagnostics.Verify(definitionForSignature2 != null, "Tile at {0} has invalid active signature {1}.", tile.Coordinates, roadTileSignature))
					{
						foreach (RoadTileConnection item3 in list)
						{
							bool isEndpointLane = tile.ContentType == TileContentType.House;
							LaneModel laneModel2 = changedTile.AddLane(item3, definitionForSignature2, RoadState.Active, isEndpointLane);
							_lanesChanged.Add(laneModel2);
							flag = true;
							TryAddUpdatedTileCorner(changedTile, laneModel2);
							TryAddUpdatedMotorway(laneModel2);
						}
					}
				}
				_scope.Release(roadTileSignature);
				_scope.Release(roadTileSignature2);
			}
			_tilemap.ClearChangedTiles();
			if (_tileCornersToUpdate.Count > 0)
			{
				foreach (TileCornerModel item4 in _tileCornersToUpdate)
				{
					RoadTileSignature roadTileSignature3 = item4.CreateTileSignature();
					List<RoadTileConnection> list4 = new List<RoadTileConnection>(roadTileSignature3.Connections);
					foreach (LaneModel lane2 in item4.roadChunk.lanes)
					{
						bool flag6 = list4.Contains(lane2.connection);
						bool flag7 = lane2.state == RoadState.Active;
						if (flag6)
						{
							list4.Remove(lane2.connection);
							if (!flag7)
							{
								lane2.state = RoadState.Active;
							}
						}
						else if (!flag6 && flag7)
						{
							lane2.state = RoadState.Mothballed;
							_lanesChanged.Add(lane2);
						}
					}
					if (list4.Count > 0)
					{
						RoadTileDefinition cornerDefinitionForSignature = _atlas.GetCornerDefinitionForSignature(roadTileSignature3);
						foreach (RoadTileConnection item5 in list4)
						{
							item4.AddLane(item5, cornerDefinitionForSignature, RoadState.Active);
						}
					}
					_scope.Release(roadTileSignature3);
				}
				_tileCornersToUpdate.Clear();
			}
			if (_motorwaysToUpdate.Count > 0)
			{
				foreach (MotorwayModel item6 in _motorwaysToUpdate)
				{
					TileModel tileModel2 = _tilemap.GetTileModel(item6.StartCoordinates);
					TileModel tileModel3 = _tilemap.GetTileModel(item6.EndCoordinates);
					if (item6.startToEndLane == null)
					{
						List<LaneModel> lanesExitingInDirection = tileModel2.roadChunk.GetLanesExitingInDirection(item6.StartDirection);
						List<LaneModel> lanesEnteringFromDirection = tileModel3.roadChunk.GetLanesEnteringFromDirection(item6.EndDirection);
						if (Diagnostics.Verify(lanesExitingInDirection.Count > 0 && lanesEnteringFromDirection.Count > 0, "Motorway has no connecting lanes!"))
						{
							RoadTileConnection connection = new RoadTileConnection(new RoadTileNode(TileUtilities.GetOppositeDirection(item6.StartDirection), RoadType.Motorway, item6.Id), new RoadTileNode(TileUtilities.GetOppositeDirection(item6.EndDirection), RoadType.Motorway, item6.Id));
							List<Vector2Fixed> path = new List<Vector2Fixed>
							{
								lanesExitingInDirection[0].EndPosition,
								lanesEnteringFromDirection[0].StartPosition
							};
							item6.startToEndLane = item6.roadChunk.AddBespokeLane(connection, path, RoadState.Active);
						}
						List<LaneModel> lanesExitingInDirection2 = tileModel3.roadChunk.GetLanesExitingInDirection(item6.EndDirection);
						List<LaneModel> lanesEnteringFromDirection2 = tileModel2.roadChunk.GetLanesEnteringFromDirection(item6.StartDirection);
						if (Diagnostics.Verify(lanesExitingInDirection2.Count > 0 && lanesEnteringFromDirection2.Count > 0, "Motorway has no connecting lanes!"))
						{
							RoadTileConnection connection2 = new RoadTileConnection(new RoadTileNode(TileUtilities.GetOppositeDirection(item6.EndDirection), RoadType.Motorway, item6.Id), new RoadTileNode(TileUtilities.GetOppositeDirection(item6.StartDirection), RoadType.Motorway, item6.Id));
							List<Vector2Fixed> path2 = new List<Vector2Fixed>
							{
								lanesExitingInDirection2[0].EndPosition,
								lanesEnteringFromDirection2[0].StartPosition
							};
							item6.endToStartLane = item6.roadChunk.AddBespokeLane(connection2, path2, RoadState.Active);
						}
					}
					tileModel2.roadChunk.ConnectInboundLane(item6.endToStartLane);
					tileModel2.roadChunk.ConnectOutboundLane(item6.startToEndLane);
					tileModel3.roadChunk.ConnectInboundLane(item6.startToEndLane);
					tileModel3.roadChunk.ConnectOutboundLane(item6.endToStartLane);
				}
				_motorwaysToUpdate.Clear();
			}
			if (flag)
			{
				_city.OnLanesAdded();
			}
			if (_lanesChanged.Count <= 0)
			{
				return;
			}
			ModelListEnumerator<VehicleModel> enumerator8 = simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator8.MoveNext())
			{
				VehicleModel current10 = enumerator8.Current;
				if (!current10.IsWaitingAtHouse && !current10.IsRealigningOnDriveway && _pathfinder.AreLanesConnected(current10.LastCommittedLane, _lanesChanged, allowMothballedLaneUsage: true))
				{
					current10.RequestPathfind();
					current10.RequestReturnPathfind();
				}
			}
			_lanesChanged.Clear();
		}

		private TileCornerModel TryAddUpdatedTileCorner(TileModel tileModel, LaneModel lane)
		{
			if (tileModel != null && lane != null)
			{
				if (TileUtilities.IsDirectionDiagonal(lane.connection.input.direction))
				{
					TileCornerModel orCreateTileCornerModel = _tilemap.GetOrCreateTileCornerModel(new CornerAdjacencyReference(tileModel.Coordinates, lane.connection.input.direction));
					if (!_tileCornersToUpdate.Contains(orCreateTileCornerModel))
					{
						_tileCornersToUpdate.Add(orCreateTileCornerModel);
						return orCreateTileCornerModel;
					}
				}
				if (TileUtilities.IsDirectionDiagonal(lane.connection.output.direction))
				{
					TileCornerModel orCreateTileCornerModel2 = _tilemap.GetOrCreateTileCornerModel(new CornerAdjacencyReference(tileModel.Coordinates, lane.connection.output.direction));
					if (!_tileCornersToUpdate.Contains(orCreateTileCornerModel2))
					{
						_tileCornersToUpdate.Add(orCreateTileCornerModel2);
						return orCreateTileCornerModel2;
					}
				}
			}
			return null;
		}

		private void TryAddUpdatedMotorway(LaneModel lane)
		{
			if (lane.connection.input.type == RoadType.Motorway)
			{
				MotorwayModel motorwayModel = _tilemap.GetMotorwayModel(lane.connection.input.motorwayId);
				if (motorwayModel != null && !_motorwaysToUpdate.Contains(motorwayModel))
				{
					_motorwaysToUpdate.Add(motorwayModel);
				}
			}
			if (lane.connection.output.type == RoadType.Motorway)
			{
				MotorwayModel motorwayModel2 = _tilemap.GetMotorwayModel(lane.connection.output.motorwayId);
				if (motorwayModel2 != null && !_motorwaysToUpdate.Contains(motorwayModel2))
				{
					_motorwaysToUpdate.Add(motorwayModel2);
				}
			}
		}

		public void Reset()
		{
			_lanesChanged.Clear();
			_tileCornersToUpdate.Clear();
			_motorwaysToUpdate.Clear();
		}
	}
}
