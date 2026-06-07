using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class BoatMovementProcess : IProcess, IReusable
	{
		[Dependency]
		private TilemapModel _tilemapModel;

		[Dependency]
		private SimulationConstantsData _constants;

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<BoatModel> enumerator = simulation.GetModels<BoatModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				BoatModel current = enumerator.Current;
				Fix64 speed = current.CurrentFrame.speed;
				Fix64 stoppingDistance = current.StoppingDistance;
				Fix64 distanceToTarget = current.DistanceToTarget;
				Fix64 boatCenterToBowDistance = _constants.boatCenterToBowDistance;
				BoatPathTileModel boatPathTileModel = null;
				Fix64 fix = Fix64.Zero;
				CarparkModel targetTerminal = null;
				Fix64 fix2 = ((current.state == BoatModel.BehaviorState.Sailing) ? Fix64.Max(_constants.boatStoppingDistanceFromBuffer, stoppingDistance * Fix64Consts.Two) : Fix64.Zero);
				Fix64 fix3 = fix2;
				Fix64 zero = Fix64.Zero;
				BoatPathTileModel boatPathTileModel2 = current.CurrentFrame.tile;
				Fix64 fix4 = current.CurrentFrame.DistanceAlongPathSegment;
				BoatModel.BoatDirection boatDirection = current.CurrentFrame.direction;
				while (boatPathTileModel2 != null && zero < fix3)
				{
					BoatPathTileModel nextBoatPathModelInDirection = boatPathTileModel2.GetNextBoatPathModelInDirection(boatDirection);
					if (boatPathTileModel == null && zero < fix2)
					{
						if (boatPathTileModel2.carpark != null)
						{
							(BoatPathTileModel destination, Fix64 distanceAlongDestination) tuple = boatPathTileModel2.Traverse(boatPathTileModel2.Length / Fix64Consts.Two, boatCenterToBowDistance);
							BoatPathTileModel item = tuple.destination;
							Fix64 item2 = tuple.distanceAlongDestination;
							Fix64 fix5 = current.CurrentFrame.tile.DistanceTo(current.CurrentFrame.DistanceAlongPathSegment, item, fix, current.CurrentFrame.direction);
							if (fix5 != BoatPathTileModel.InvalidDistance && fix5 > stoppingDistance)
							{
								bool flag = true;
								if (item.BoatPath.IsLoop)
								{
									Fix64 fix6 = current.CurrentFrame.tile.DistanceTo(current.CurrentFrame.DistanceAlongPathSegment, item, fix, current.CurrentFrame.direction);
									flag = fix6 == BoatPathTileModel.InvalidDistance || fix5 < fix6;
								}
								if (flag)
								{
									targetTerminal = boatPathTileModel2.carpark;
									boatPathTileModel = item;
									fix = item2;
								}
							}
						}
						if (boatPathTileModel == null && nextBoatPathModelInDirection == null)
						{
							(boatPathTileModel, fix) = boatPathTileModel2.Traverse(boatPathTileModel2.Length - _constants.boatStoppingDistanceFromBuffer, boatCenterToBowDistance);
						}
					}
					zero += boatPathTileModel2.Length - fix4;
					fix4 = Fix64.Zero;
					boatPathTileModel2 = nextBoatPathModelInDirection;
				}
				switch (current.state)
				{
				case BoatModel.BehaviorState.Sailing:
					if (boatPathTileModel != null)
					{
						current.state = BoatModel.BehaviorState.ApproachingTerminal;
						current.targetBoatPath = boatPathTileModel;
						current.SetTargetTerminal(targetTerminal);
						current.stoppingDistanceAlongTargetPathSegment = fix;
					}
					break;
				case BoatModel.BehaviorState.ApproachingTerminal:
					if (distanceToTarget <= stoppingDistance)
					{
						current.state = BoatModel.BehaviorState.Stopping;
					}
					break;
				case BoatModel.BehaviorState.Stopped:
					current.DelayBeforeStarting -= timestep;
					if (current.DelayBeforeStarting <= Fix64.Zero)
					{
						if (current.GetTargetTerminal() != null)
						{
							current.SetTargetTerminal(null);
							current.state = BoatModel.BehaviorState.Undocking;
						}
						else
						{
							current.state = BoatModel.BehaviorState.Sailing;
						}
						current.DelayBeforeStarting = Fix64.Zero;
					}
					break;
				}
				Fix64 min = Fix64.Zero;
				Fix64 fix7;
				switch (current.state)
				{
				case BoatModel.BehaviorState.Sailing:
				case BoatModel.BehaviorState.ApproachingTerminal:
					fix7 = _constants.boatAcceleration;
					break;
				case BoatModel.BehaviorState.Undocking:
					fix7 = _constants.boatUndockingAcceleration;
					break;
				case BoatModel.BehaviorState.Stopping:
					fix7 = ((distanceToTarget >= Fix64.Zero) ? (-(speed * speed) / (Fix64Consts.Two * distanceToTarget)) : (-_constants.boatDeceleration));
					min = _constants.boatMinimumSpeedDuringDeceleration;
					break;
				default:
					fix7 = Fix64.Zero;
					break;
				}
				Fix64 value = current.CurrentFrame.speed + fix7 * timestep;
				value = Fix64.Clamp(value, min, _constants.boatSpeed);
				Fix64 fix8 = value * timestep;
				bool flag2 = false;
				switch (current.state)
				{
				case BoatModel.BehaviorState.Undocking:
					if (!Diagnostics.Verify(_constants.boatUndockingSpeedThreshold < _constants.boatSpeed, "undocking speed threshold must be less than boat speed!"))
					{
						_constants.boatUndockingSpeedThreshold = _constants.boatSpeed;
					}
					if (value >= _constants.boatUndockingSpeedThreshold)
					{
						current.state = BoatModel.BehaviorState.Sailing;
					}
					break;
				case BoatModel.BehaviorState.Stopping:
					if (fix8 >= distanceToTarget || value <= Fix64.Zero)
					{
						value = Fix64.Zero;
						fix8 = current.CurrentFrame.tile.Length - current.CurrentFrame.DistanceAlongPathSegment;
						current.state = BoatModel.BehaviorState.Stopped;
						if (current.GetTargetTerminal() != null)
						{
							current.DelayBeforeStarting = _constants.boatTerminalWaitTime;
							current.HasPendingDemand = true;
							flag2 = true;
						}
						else
						{
							current.DelayBeforeStarting = _constants.boatTerminalWaitTime;
							flag2 = true;
						}
						current.stoppingDistanceAlongTargetPathSegment = Fix64.Zero;
						current.distanceTraveledSinceLastTarget = Fix64.Zero;
					}
					break;
				case BoatModel.BehaviorState.Stopped:
					value = Fix64.Zero;
					break;
				}
				BoatPathTileModel boatPathTileModel3 = current.CurrentFrame.tile;
				Fix64 distanceAlongPathSegment = current.CurrentFrame.DistanceAlongPathSegment;
				distanceAlongPathSegment += fix8;
				if (distanceAlongPathSegment > boatPathTileModel3.Length)
				{
					distanceAlongPathSegment -= boatPathTileModel3.Length;
					boatPathTileModel3 = boatPathTileModel3.GetNextBoatPathModelInDirection(current.CurrentFrame.direction);
				}
				if (flag2)
				{
					boatDirection = ((boatDirection == BoatModel.BoatDirection.Forwards) ? BoatModel.BoatDirection.Backwards : BoatModel.BoatDirection.Forwards);
				}
				current.distanceTraveledSinceLastTarget += fix8;
				current.NextFrame.speed = value;
				current.NextFrame.tile = boatPathTileModel3;
				current.NextFrame.direction = boatDirection;
				current.NextFrame.DistanceAlongPathSegment = distanceAlongPathSegment;
			}
		}

		public void Reset()
		{
		}
	}
}
