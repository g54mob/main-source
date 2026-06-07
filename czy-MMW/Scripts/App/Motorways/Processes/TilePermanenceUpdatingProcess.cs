using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Processes
{
	public class TilePermanenceUpdatingProcess : IProcess, IReusable
	{
		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private City _city;

		[Dependency]
		private TilemapModel _tilemap;

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			if (!_city.Rules.RoadsBecomePermanentOverTime || timestep <= Fix64.Zero)
			{
				return;
			}
			Fix64 permanenceProgress = timestep / _constants.DurationTillRoadPermanence;
			ModelListEnumerator<TileModel> enumerator = simulation.GetModels<TileModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileModel current = enumerator.Current;
				TileDirectionBitfield directionsToIncrement = GetDirectionsToIncrement(current, simulation);
				if (directionsToIncrement.Count > 0 || current.Tile.HasTrafficLight || current.Tile.IsCenterOfRoundabout)
				{
					current.Tile.IncrementNodePermanenceProgress(permanenceProgress, directionsToIncrement);
				}
			}
			ModelListEnumerator<MotorwayModel> enumerator2 = simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				enumerator2.Current.IncrementPermanence(permanenceProgress);
			}
		}

		private TileDirectionBitfield GetDirectionsToIncrement(TileModel tileModel, ISimulation simulation)
		{
			if (tileModel.Tile.ContentType == TileContentType.House || tileModel.Tile.ContentType == TileContentType.Carpark)
			{
				return TileDirectionBitfield.None;
			}
			if (_city.Definition.TileIsOverWater(tileModel.Coordinates) || _city.Definition.TileIsUnderAMountain(tileModel.Coordinates))
			{
				if (IsCoordinatePartOfIncompletePassage(tileModel.Coordinates, simulation))
				{
					return TileDirectionBitfield.None;
				}
				return tileModel.Tile.GetTwoLaneRoads();
			}
			TileDirectionBitfield none = TileDirectionBitfield.None;
			TileDirectionBitfield.Enumerator enumerator = tileModel.Tile.GetTwoLaneRoads().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (!tileModel.Tile.IsNodePermanent(current) && !tileModel.Tile.IsConnectedViaDrivewayInDirection(current))
				{
					Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(tileModel.Coordinates, current);
					if ((!_city.Definition.TileIsOverWater(adjacentCoordinates) && !_city.Definition.TileIsUnderAMountain(adjacentCoordinates)) || _tilemap.GetTile(adjacentCoordinates) == null || !IsCoordinatePartOfIncompletePassage(adjacentCoordinates, simulation))
					{
						none[current] = true;
					}
				}
			}
			enumerator = tileModel.Tile.GetMotorwayRamps(RoadState.Active).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current2 = enumerator.Current;
				if (!tileModel.Tile.IsNodePermanent(current2))
				{
					none[current2] = true;
				}
			}
			return none;
		}

		private static bool IsCoordinatePartOfIncompletePassage(Vector2Int coordinates, ISimulation simulation)
		{
			ModelListEnumerator<PassageModel> enumerator = simulation.GetModels<PassageModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				PassageModel current = enumerator.Current;
				if (current.Passage.CrossingCoordinates.Contains(coordinates) && !current.Passage.IsComplete)
				{
					return true;
				}
			}
			return false;
		}
	}
}
