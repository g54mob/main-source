using Factory;
using Factory.Pools;
using FixMath;
using JetBrains.Annotations;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class TrainMovementProcess : IProcess, IReusable
	{
		[Dependency]
		private TilemapModel _tilemapModel;

		[Dependency]
		private SimulationConstantsData _constants;

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<TrainModel> enumerator = simulation.GetModels<TrainModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TrainModel current = enumerator.Current;
				Fix64 speed = current.CurrentFrame.speed;
				Fix64 stoppingDistance = current.StoppingDistance;
				Fix64 distanceToTarget = current.DistanceToTarget;
				Fix64 fix = _constants.trainCenterToWheelDistance;
				Fix64 fix2 = _constants.trainCenterToWheelDistance * (Fix64)5L + _constants.trainCarriageSeparationDistance * (Fix64)2L;
				RailDirection railDirection = current.CurrentFrame.direction;
				if (railDirection == RailDirection.Backwards)
				{
					Fix64 fix3 = fix2;
					Fix64 fix4 = fix;
					fix = fix3;
					fix2 = fix4;
				}
				RailTileModel railTileModel = null;
				Fix64 fix5 = Fix64.Zero;
				CarparkModel targetStation = null;
				Fix64 fix6 = _constants.trainCrossingSignalDistance + fix;
				Fix64 fix7 = ((current.state == TrainModel.BehaviorState.Driving) ? (Fix64.Max(_constants.trainStoppingDistanceFromBuffer, stoppingDistance * Fix64Consts.Two) + fix) : Fix64.Zero);
				Fix64 fix8 = Fix64.Max(fix6, fix7);
				Fix64 zero = Fix64.Zero;
				RailTileModel railTileModel2 = current.CurrentFrame.tile;
				Fix64 fix9 = current.CurrentFrame.distanceAlongTrack;
				RailTileModel railTileModel3 = null;
				RailTileModel railTileModel4 = null;
				while (railTileModel2 != null && zero < fix8)
				{
					if (zero < fix6)
					{
						railTileModel3 = railTileModel2;
					}
					RailTileModel nextRailModelInDirection = railTileModel2.GetNextRailModelInDirection(railDirection);
					if (railTileModel == null && zero < fix7)
					{
						if (railTileModel2.carpark != null && (nextRailModelInDirection == null || railTileModel2.carpark != nextRailModelInDirection.carpark) && current.distanceTraveledSinceLastStation > TilemapModel.TileWidth)
						{
							(RailTileModel destination, Fix64 distanceAlongDestination, Fix64 totalDistanceTraversed) tuple = railTileModel2.Traverse(railTileModel2.Length / Fix64Consts.Two, fix, TileUtilities.GetOppositeDirection(railDirection));
							RailTileModel item = tuple.destination;
							Fix64 item2 = tuple.distanceAlongDestination;
							Fix64 fix10 = current.CurrentFrame.tile.DistanceTo(current.CurrentFrame.distanceAlongTrack, item, fix5, railDirection);
							if (fix10 != RailTileModel.InvalidDistance && fix10 > stoppingDistance)
							{
								bool flag = true;
								if (item.Line.IsLoop)
								{
									Fix64 fix11 = current.CurrentFrame.tile.DistanceTo(current.CurrentFrame.distanceAlongTrack, item, fix5, TileUtilities.GetOppositeDirection(railDirection));
									flag = fix11 == RailTileModel.InvalidDistance || fix10 < fix11;
								}
								if (flag)
								{
									targetStation = railTileModel2.carpark;
									railTileModel = item;
									fix5 = item2;
								}
							}
						}
						if (railTileModel == null && nextRailModelInDirection == null)
						{
							(railTileModel, fix5, _) = railTileModel2.Traverse((railDirection == RailDirection.Forwards) ? (railTileModel2.Length - _constants.trainStoppingDistanceFromBuffer) : _constants.trainStoppingDistanceFromBuffer, fix, TileUtilities.GetOppositeDirection(railDirection));
						}
					}
					if (railDirection == RailDirection.Forwards)
					{
						zero += railTileModel2.Length - fix9;
						fix9 = Fix64.Zero;
					}
					else
					{
						zero += fix9;
						fix9 = nextRailModelInDirection?.Length ?? Fix64.Zero;
					}
					railTileModel2 = nextRailModelInDirection;
				}
				railTileModel4 = current.CurrentFrame.tile.Traverse(current.CurrentFrame.distanceAlongTrack, fix2, TileUtilities.GetOppositeDirection(railDirection)).destination;
				if (railDirection == RailDirection.Backwards)
				{
					RailTileModel railTileModel5 = railTileModel3;
					RailTileModel railTileModel6 = railTileModel4;
					railTileModel4 = railTileModel5;
					railTileModel3 = railTileModel6;
				}
				ConfigureSignals(railTileModel4, railTileModel3);
				switch (current.state)
				{
				case TrainModel.BehaviorState.Driving:
					if (railTileModel != null)
					{
						current.state = TrainModel.BehaviorState.ApproachingDestination;
						current.targetTrack = railTileModel;
						current.targetStation = targetStation;
						current.stoppingDistanceAlongTargetTrack = fix5;
					}
					break;
				case TrainModel.BehaviorState.ApproachingDestination:
					if (distanceToTarget <= stoppingDistance)
					{
						current.state = TrainModel.BehaviorState.Stopping;
					}
					break;
				case TrainModel.BehaviorState.Stopped:
					current.DelayBeforeStarting -= timestep;
					if (current.DelayBeforeStarting <= Fix64.Zero)
					{
						current.targetStation = null;
						current.state = TrainModel.BehaviorState.Driving;
						current.DelayBeforeStarting = Fix64.Zero;
					}
					break;
				}
				Fix64 min = Fix64.Zero;
				Fix64 fix12;
				switch (current.state)
				{
				case TrainModel.BehaviorState.Driving:
				case TrainModel.BehaviorState.ApproachingDestination:
					fix12 = _constants.trainAcceleration;
					break;
				case TrainModel.BehaviorState.Stopping:
					fix12 = ((distanceToTarget >= Fix64.Zero) ? (-(speed * speed) / (Fix64Consts.Two * distanceToTarget)) : (-_constants.trainDeceleration));
					min = _constants.trainMinimumSpeedDuringDeceleration;
					break;
				default:
					fix12 = Fix64.Zero;
					break;
				}
				Fix64 value = current.CurrentFrame.speed + fix12 * timestep;
				value = Fix64.Clamp(value, min, _constants.trainSpeed);
				Fix64 fix13 = value * timestep;
				bool flag2 = false;
				switch (current.state)
				{
				case TrainModel.BehaviorState.Stopping:
					if (!(fix13 >= distanceToTarget) && !(value <= Fix64.Zero))
					{
						break;
					}
					value = Fix64.Zero;
					fix13 = Fix64.Max(distanceToTarget, Fix64.Zero);
					current.state = TrainModel.BehaviorState.Stopped;
					if (current.targetStation != null)
					{
						current.distanceTraveledSinceLastStation = Fix64.Zero;
						current.DelayBeforeStarting = _constants.trainStationWaitTime;
						current.HasPendingDemand = true;
						Fix64 fix14 = fix + (fix + fix2);
						if (current.targetTrack.Traverse(current.stoppingDistanceAlongTargetTrack, fix14, railDirection).totalDistanceTraversed < fix14)
						{
							flag2 = true;
						}
					}
					else
					{
						current.DelayBeforeStarting = _constants.trainStationWaitTime;
						flag2 = true;
					}
					current.targetTrack = null;
					current.stoppingDistanceAlongTargetTrack = Fix64.Zero;
					break;
				case TrainModel.BehaviorState.Stopped:
					value = Fix64.Zero;
					break;
				}
				RailTileModel railTileModel7 = current.CurrentFrame.tile;
				Fix64 fix15 = current.CurrentFrame.distanceAlongTrack;
				if (railDirection == RailDirection.Forwards)
				{
					fix15 += fix13;
					if (fix15 > railTileModel7.Length)
					{
						fix15 -= railTileModel7.Length;
						railTileModel7 = railTileModel7.NextRailModel;
					}
				}
				else
				{
					fix15 -= fix13;
					if (fix15 < Fix64.Zero)
					{
						railTileModel7 = railTileModel7.PreviousRailModel;
						fix15 = railTileModel7.Length + fix15;
					}
				}
				if (flag2)
				{
					railDirection = ((railDirection == RailDirection.Forwards) ? RailDirection.Backwards : RailDirection.Forwards);
				}
				current.distanceTraveledSinceLastStation += fix13;
				current.NextFrame.direction = railDirection;
				current.NextFrame.speed = value;
				current.NextFrame.tile = railTileModel7;
				current.NextFrame.distanceAlongTrack = fix15;
			}
		}

		public void Reset()
		{
		}

		private void ConfigureSignals([NotNull] RailTileModel blockedSectionStart, [NotNull] RailTileModel blockedSectionEnd)
		{
			if (blockedSectionStart.Line.IsLoop)
			{
				TrainSignalState targetSignalState = TrainSignalState.Closed;
				RailTileModel railTileModel = blockedSectionStart;
				do
				{
					RailTileModel nextRailModel = railTileModel.NextRailModel;
					foreach (RoadChunkModel item in railTileModel.GetRoadChunksInDirection(RailDirection.Forwards))
					{
						if (item.TrainCrossingModel != null)
						{
							item.TrainCrossingModel.RequestSignalStateChange(targetSignalState);
						}
					}
					if (nextRailModel == blockedSectionEnd)
					{
						targetSignalState = TrainSignalState.Open;
					}
					railTileModel = nextRailModel;
				}
				while (railTileModel != blockedSectionStart && railTileModel != null);
				return;
			}
			RailTileModel railTileModel2 = blockedSectionStart.Line.StartTile;
			TrainSignalState trainSignalState = TrainSignalState.Open;
			while (railTileModel2 != null)
			{
				RailTileModel nextRailModel2 = railTileModel2.NextRailModel;
				if (trainSignalState == TrainSignalState.Open && railTileModel2 == blockedSectionStart)
				{
					trainSignalState = TrainSignalState.Closed;
				}
				railTileModel2.SignalState = trainSignalState;
				foreach (RoadChunkModel item2 in railTileModel2.GetRoadChunksInDirection(RailDirection.Forwards))
				{
					if (item2.TrainCrossingModel != null)
					{
						item2.TrainCrossingModel.RequestSignalStateChange(trainSignalState);
					}
				}
				if (trainSignalState == TrainSignalState.Closed && railTileModel2 == blockedSectionEnd)
				{
					trainSignalState = TrainSignalState.Open;
				}
				railTileModel2 = nextRailModel2;
			}
		}
	}
}
