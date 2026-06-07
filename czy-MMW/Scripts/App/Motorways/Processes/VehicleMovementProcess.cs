using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using Unity.Profiling;

namespace Motorways.Processes
{
	public class VehicleMovementProcess : IProcess, IReusable
	{
		[Serialize(false, null)]
		private readonly List<VehicleModel> _vehiclesMovingLanes = new List<VehicleModel>();

		[Serialize(false, null)]
		private readonly List<VehicleModel> _vehiclesInBrokenPushingCycles = new List<VehicleModel>();

		[Serialize(false, null)]
		private readonly List<VehicleModel> _stuckVehicles = new List<VehicleModel>();

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("VehicleMovementProcess");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private Pathfinder _pathfinder;

		public static readonly Fix64 DefaultDesiredSpeed = Fix64.FromRaw(12884901888L);

		public static readonly Fix64 DesiredTimeGap = Fix64.FromRaw(4294967296L);

		public static readonly Fix64 MinimumGap = Fix64.FromRaw(429496729L);

		public static readonly Fix64 VehicleLength = Fix64.FromRaw(2791728742L);

		public static readonly Fix64 MaximumDeceleration = Fix64.FromRaw(6442450944L);

		private static readonly Fix64 CoolnessFactor = Fix64.FromRaw(858993459L);

		private static readonly Fix64 AccelerationExponent = Fix64.FromRaw(17179869184L);

		private static readonly Fix64 OneEMinus3 = Fix64.FromRaw(429496L);

		private static readonly Fix64 OneEMinus5 = Fix64.FromRaw(4294L);

		private static readonly Fix64 MinimumSpeedWithClearance = (Fix64)1E-08;

		private static readonly Fix64 ClearanceForMinimumSpeed = MinimumGap + VehicleLength * Fix64Consts.Two;

		private static readonly Fix64 MinimumDistanceToNonBlockingIntersection = VehicleLength * Fix64Consts.Two;

		private static readonly Fix64 IntersectionStoppingOffset = VehicleLength - MinimumGap * Fix64Consts.OneHalf;

		private static readonly Fix64 TargetStoppingOffset = VehicleLength + MinimumGap;

		private static readonly ProfilerMarker Profiler_Step = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step");

		private static readonly ProfilerMarker Profiler_StepCalculateSpeed = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.CalculateSpeed");

		private static readonly ProfilerMarker Profiler_StepCalculateSpeedCurrentLane = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.CalculateSpeed.CurrentLane");

		private static readonly ProfilerMarker Profiler_StepCalculateSpeedNextLane = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.CalculateSpeed.NextLane");

		private static readonly ProfilerMarker Profiler_StepCalculateSpeedCheckHotswapBlocking = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.CalculateSpeed.CheckHotswapBlocking");

		private static readonly ProfilerMarker Profiler_StepCalculateSpeedMaxAcceleration = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.CalculateSpeed.MaxAcceleration");

		private static readonly ProfilerMarker Profiler_StepCalculateSpeedUpdateDistance = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.CalculateSpeed.UpdateDistance");

		private static readonly ProfilerMarker Profiler_StepMoveLane = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.Step.MoveLane");

		private static readonly ProfilerMarker Profiler_CalculateAcceleration = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.CalculateAcceleration");

		private static readonly ProfilerMarker Profiler_MoveToNewLane = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.MoveToNewLane");

		private static readonly ProfilerMarker Profiler_ClearPushingCycles = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.ClearPushingCycles");

		private static readonly ProfilerMarker Profiler_CheckCycles = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.CheckCycles");

		private static readonly ProfilerMarker Profiler_BreakCycle = new ProfilerMarker(ProfilerUtility.CategoryProcess, "VehicleMovementProcess.BreakCycle");

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 deltaTime)
		{
			bool flag = _constants.useAverageLaneSpeedRatherThanMin;
			Fix64 fix = DefaultDesiredSpeed * _constants.speedMultiplier;
			IntersectionDecisionDatabaseModel intersectionDecisionDatabaseModel = null;
			if (FeatureToggle.IsFeatureEnabled(Feature.RecordIntersectionDecisions))
			{
				intersectionDecisionDatabaseModel = simulation.GetModel<IntersectionDecisionDatabaseModel>();
			}
			ModelListEnumerator<VehicleModel> enumerator = simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				VehicleModel current = enumerator.Current;
				LaneModel lane = current.CurrentFrame.lane;
				RoadChunkModel roadChunk = lane.roadChunk;
				LaneModel laneModel = null;
				RoadChunkModel roadChunkModel = null;
				Fix64 fix2 = Fix64.MaxValue;
				VehicleModel.ObstacleType obstacleType = VehicleModel.ObstacleType.None;
				Fix64 fix3 = Fix64.MaxValue;
				Fix64 fix4 = Fix64.Zero;
				Fix64 fix5 = Fix64.Zero;
				Fix64 leadingAcceleration = Fix64.Zero;
				VehicleModel next = null;
				Fix64 distance = Fix64.MaxValue;
				LaneModel laneModel2 = null;
				Fix64 distanceToBlockingLane = Fix64.MaxValue;
				bool flag2 = false;
				VehicleModel blockingVehicle = null;
				RoadChunkModel roadChunkModel2 = null;
				Fix64 currentGap = Fix64.MaxValue;
				RoadChunkModel roadChunkModel3 = null;
				Fix64 currentGap2 = Fix64.MaxValue;
				bool flag3 = false;
				if (!_constants.useAverageLaneSpeedRatherThanMinOnMotorways)
				{
					flag = !current.CurrentFrame.lane.connection.IsMotorway;
				}
				if (!roadChunk.CanTraversingVehicleContinue(current))
				{
					laneModel2 = lane;
					distanceToBlockingLane = Fix64.Zero;
					obstacleType = VehicleModel.ObstacleType.BlockingIntersection;
				}
				else if (lane.TryGetNextVehicleAfter(current, out next, out distance) && next != null)
				{
					obstacleType = VehicleModel.ObstacleType.LeadingVehicle;
					fix3 = distance;
					fix5 = next.CurrentFrame.speed;
					leadingAcceleration = next.CurrentFrame.acceleration;
					blockingVehicle = next;
				}
				Fix64 fix6 = lane.SpeedLimit;
				Fix64 fix7 = fix6;
				int count = current.path.Count;
				if (count == 0)
				{
					Fix64 fix8 = current.targetDistanceAlongLastLane - current.CurrentFrame.distanceAlongLane;
					if (current.behaviorState == VehicleModel.BehaviorState.RealigningDriveway || obstacleType == VehicleModel.ObstacleType.None || fix3 > fix8)
					{
						obstacleType = VehicleModel.ObstacleType.Target;
						fix3 = Fix64.Abs(fix8);
						fix4 = TargetStoppingOffset;
						fix5 = Fix64.Zero;
						leadingAcceleration = Fix64.Zero;
					}
				}
				else
				{
					Fix64 fix9 = lane.Length - current.CurrentFrame.distanceAlongLane;
					Fix64 fix10 = Fix64.Min(_constants.LookaheadDistance, fix9);
					fix7 *= fix10;
					laneModel = current.path[0];
					roadChunkModel = laneModel.roadChunk;
					fix2 = fix9;
					IntersectionEntryDecision intersectionEntryDecision = null;
					if (intersectionDecisionDatabaseModel != null && (roadChunkModel.lanes.Count > 2 || roadChunkModel.IsTrainCrossing))
					{
						intersectionEntryDecision = _scope.Get<IntersectionEntryDecision>();
					}
					if (!roadChunkModel.CanInboundVehicleEnter(current, out var blockingVehicle2, intersectionEntryDecision))
					{
						flag3 = true;
						if (obstacleType == VehicleModel.ObstacleType.None)
						{
							laneModel2 = laneModel;
							distanceToBlockingLane = fix9;
							obstacleType = VehicleModel.ObstacleType.BlockingIntersection;
							fix3 = fix9;
							if (!roadChunkModel.isTileCorner)
							{
								fix4 += IntersectionStoppingOffset;
							}
							blockingVehicle = blockingVehicle2;
							_stuckVehicles.Add(current);
						}
					}
					if (intersectionEntryDecision != null)
					{
						intersectionDecisionDatabaseModel.AddDecision(intersectionEntryDecision);
					}
					bool flag4 = false;
					int num = 0;
					LaneModel laneModel3 = laneModel;
					while (laneModel3 != null && fix9 < _constants.LookaheadDistance)
					{
						fix6 = Fix64.Min(laneModel3.SpeedLimit, fix6);
						Fix64 fix11 = Fix64.Min(laneModel3.Length, _constants.LookaheadDistance - fix10);
						fix7 += laneModel3.SpeedLimit * fix11;
						fix10 += fix11;
						if (num < 2)
						{
							flag4 |= laneModel3.IsAboutToHotswap;
						}
						if (obstacleType == VehicleModel.ObstacleType.None)
						{
							RoadChunkModel roadChunk2 = laneModel3.roadChunk;
							if (num > 0 && !roadChunk2.CanInboundVehicleEnter(current, out var _))
							{
								laneModel2 = laneModel3;
								distanceToBlockingLane = fix9;
								obstacleType = VehicleModel.ObstacleType.BlockingIntersection;
								fix3 = fix9;
								if (roadChunk2.IsTrainCrossing)
								{
									fix4 -= _constants.crossingStopDistance * VehicleLength;
									if (roadChunk2.isTileCorner)
									{
										fix4 -= IntersectionStoppingOffset;
									}
								}
								else if (!roadChunk2.isTileCorner)
								{
									fix4 += IntersectionStoppingOffset;
								}
							}
							else
							{
								next = laneModel3.GetLastVehicle();
								if (next != null)
								{
									distance = fix9 + next.CurrentFrame.distanceAlongLane;
									obstacleType = VehicleModel.ObstacleType.LeadingVehicle;
									fix3 = distance;
									fix5 = next.CurrentFrame.speed;
									leadingAcceleration = next.CurrentFrame.acceleration;
									blockingVehicle = next;
								}
								if (num == count - 1)
								{
									Fix64 fix12 = fix9 + current.targetDistanceAlongLastLane;
									if (obstacleType == VehicleModel.ObstacleType.None || fix3 > fix12)
									{
										fix3 = fix12;
										fix4 = TargetStoppingOffset;
										obstacleType = VehicleModel.ObstacleType.Target;
									}
								}
								if (obstacleType == VehicleModel.ObstacleType.None && roadChunkModel2 == null && fix9 > MinimumDistanceToNonBlockingIntersection && !roadChunk2.IsControlled && roadChunk2.GetNumberOfRoadsInIntersectionForSlowingVehicles() >= _constants.NumberOfRoadsAtIntersectionToSlowDownFor)
								{
									roadChunkModel2 = roadChunk2;
									currentGap = fix9;
									if (!roadChunk2.isTileCorner)
									{
										currentGap += IntersectionStoppingOffset;
									}
								}
								if (obstacleType == VehicleModel.ObstacleType.None && roadChunkModel3 == null && roadChunk2.IsTrainCrossing && fix9 > VehicleLength * _constants.crossingSlowDistance)
								{
									roadChunkModel3 = roadChunk2;
									currentGap2 = fix9;
								}
							}
						}
						fix9 += laneModel3.Length;
						num++;
						laneModel3 = ((num < count) ? current.path[num] : null);
					}
					if (count > 2)
					{
						while (!flag4 && num < 2)
						{
							flag4 |= current.path[num].IsAboutToHotswap;
							num++;
						}
						if (!flag4 && current.path[2].IsAboutToHotswap)
						{
							RoadTileConnection connection = lane.connection;
							flag2 = connection.input.type != RoadType.Carpark && connection.output.type != RoadType.Carpark && connection.output.type != RoadType.ParkingSpace;
							flag3 = flag3 || flag2;
						}
					}
					if (flag)
					{
						fix7 /= fix10;
					}
				}
				Fix64 fix13 = (flag ? fix7 : fix6) * fix;
				Fix64 maximumAcceleration;
				if (roadChunk.IsRoundabout || (roadChunkModel != null && roadChunkModel.IsRoundabout))
				{
					maximumAcceleration = _constants.roundaboutAcceleration;
				}
				else if (roadChunk.IsTrainCrossing || (roadChunkModel != null && roadChunkModel.IsTrainCrossing))
				{
					maximumAcceleration = _constants.maxAccelerationOnCrossings;
				}
				else
				{
					RoadChunkModel roadChunk3 = current.house.DrivewayLane.roadChunk;
					bool num2 = (roadChunk == roadChunk3 || roadChunkModel == roadChunk3) | (roadChunk.IsControlled || (roadChunkModel?.IsControlled ?? false));
					RoadTileConnection connection2 = lane.connection;
					maximumAcceleration = ((num2 | (connection2.input.type == RoadType.Motorway && connection2.output.type == RoadType.Motorway && current.CurrentFrame.lane.Length - current.CurrentFrame.distanceAlongLane < VehicleLength)) ? _constants.controlledIntersectionAcceleration : _constants.maxAcceleration);
				}
				if (current.vehiclePushingInto != null)
				{
					if (obstacleType == VehicleModel.ObstacleType.LeadingVehicle && next == current.vehiclePushingInto)
					{
						if (fix5 > _constants.minSpeedBeforePushingCycle)
						{
							_vehiclesInBrokenPushingCycles.Add(current);
						}
						fix5 = Fix64.Max(fix5, _constants.minSpeedBeforePushingCycle);
						fix4 = Fix64.Max(VehicleLength + MinimumGap * Fix64Consts.Two - fix3, Fix64.Zero);
					}
					else
					{
						_vehiclesInBrokenPushingCycles.Add(current);
					}
				}
				Fix64 fix14 = CalculateAcceleration(fix3 + fix4, current.CurrentFrame.speed, fix5, leadingAcceleration, fix13, maximumAcceleration, _constants.accelerationExponent, _constants.maxDeceleration, _constants.decelerationExponent);
				if (obstacleType == VehicleModel.ObstacleType.BlockingIntersection && laneModel2.roadChunk.IsControlled && fix3 < VehicleLength * Fix64Consts.Two)
				{
					fix14 *= Fix64Consts.Two;
				}
				if (flag2)
				{
					Fix64 second = CalculateAcceleration(fix2 + (roadChunkModel.isTileCorner ? Fix64.Zero : IntersectionStoppingOffset), current.CurrentFrame.speed, Fix64.Zero, Fix64.Zero, fix13, maximumAcceleration, _constants.accelerationExponent, _constants.maxDeceleration, _constants.decelerationExponent);
					fix14 = Fix64.Min(fix14, second);
					if (obstacleType != VehicleModel.ObstacleType.BlockingIntersection || laneModel2 != lane)
					{
						obstacleType = VehicleModel.ObstacleType.HotswappingLane;
						distanceToBlockingLane = fix2;
						laneModel2 = laneModel;
					}
				}
				else if (roadChunkModel2 != null)
				{
					Fix64 fix15 = _constants.targetSpeedTowardsIntersections * fix13;
					Fix64 second2 = CalculateAcceleration(currentGap, current.CurrentFrame.speed, fix15, Fix64.Zero, fix15, maximumAcceleration, _constants.accelerationExponent, _constants.maxDeceleration, _constants.decelerationExponentTowardsIntersections);
					fix14 = Fix64.Min(fix14, second2);
				}
				else if (roadChunkModel3 != null)
				{
					Fix64 fix16 = _constants.targetSpeedTowardsCrossings * fix13;
					Fix64 second3 = CalculateAcceleration(currentGap2, current.CurrentFrame.speed, fix16, Fix64.Zero, fix16, maximumAcceleration, _constants.accelerationExponent, _constants.maxDeceleration, _constants.decelerationExponentTowardsCrossings);
					fix14 = Fix64.Min(fix14, second3);
				}
				VehicleModel.Frame nextFrame = current.NextFrame;
				nextFrame.nearestObstacle = obstacleType;
				nextFrame.leadingVehicle = next;
				nextFrame.distanceToLeadingVehicle = distance;
				nextFrame.blockingLane = laneModel2;
				nextFrame.distanceToBlockingLane = distanceToBlockingLane;
				nextFrame.acceleration = fix14;
				Fix64 second4 = ((fix3 > ClearanceForMinimumSpeed) ? MinimumSpeedWithClearance : Fix64.Zero);
				nextFrame.speed = Fix64.Max(current.CurrentFrame.speed + current.NextFrame.acceleration * deltaTime, second4);
				current.blockingVehicle = blockingVehicle;
				if (obstacleType == VehicleModel.ObstacleType.LeadingVehicle && nextFrame.speed < _constants.minSpeedBeforePushingCycle && distance < MinimumGap)
				{
					_stuckVehicles.Add(current);
				}
				bool flag5 = false;
				Fix64 fix17 = (current.CurrentFrame.speed + current.NextFrame.speed) * Fix64Consts.OneHalf * deltaTime;
				if (current.behaviorState == VehicleModel.BehaviorState.RealigningDriveway && current.targetDistanceAlongLastLane < current.CurrentFrame.distanceAlongLane)
				{
					flag5 = true;
					fix17 = -fix17;
				}
				current.NextFrame.distanceAlongLane = current.CurrentFrame.distanceAlongLane + fix17;
				current.NextFrame.lane = lane;
				if (current.NextFrame.distanceAlongLane > lane.Length)
				{
					if (flag3)
					{
						current.NextFrame.distanceAlongLane = lane.Length;
					}
					else
					{
						_vehiclesMovingLanes.Add(current);
					}
				}
				else if ((count == 0 && !flag5 && current.NextFrame.distanceAlongLane > current.targetDistanceAlongLastLane) || (flag5 && current.NextFrame.distanceAlongLane < current.targetDistanceAlongLastLane))
				{
					current.NextFrame.distanceAlongLane = current.targetDistanceAlongLastLane;
					current.NextFrame.speed = Fix64.Zero;
				}
				current.NotifyBehaviorChange();
				flag = _constants.useAverageLaneSpeedRatherThanMin;
			}
			foreach (VehicleModel vehiclesMovingLane in _vehiclesMovingLanes)
			{
				vehiclesMovingLane.NextFrame.distanceAlongLane -= vehiclesMovingLane.CurrentFrame.lane.Length;
				if (vehiclesMovingLane.path.Count > 0)
				{
					MoveVehicleToNewLane(vehiclesMovingLane, vehiclesMovingLane.path[0]);
				}
				else
				{
					vehiclesMovingLane.NextFrame.distanceAlongLane = vehiclesMovingLane.CurrentFrame.lane.Length;
				}
				if (vehiclesMovingLane.path.Count == 0)
				{
					bool flag6 = vehiclesMovingLane.behaviorState == VehicleModel.BehaviorState.RealigningDriveway && vehiclesMovingLane.targetDistanceAlongLastLane < vehiclesMovingLane.CurrentFrame.distanceAlongLane;
					if ((!flag6 && vehiclesMovingLane.NextFrame.distanceAlongLane > vehiclesMovingLane.targetDistanceAlongLastLane) || (flag6 && vehiclesMovingLane.NextFrame.distanceAlongLane < vehiclesMovingLane.targetDistanceAlongLastLane))
					{
						vehiclesMovingLane.NextFrame.distanceAlongLane = vehiclesMovingLane.targetDistanceAlongLastLane;
						vehiclesMovingLane.NextFrame.speed = Fix64.Zero;
					}
				}
			}
			if (_vehiclesInBrokenPushingCycles.Count > 0)
			{
				foreach (VehicleModel vehiclesInBrokenPushingCycle in _vehiclesInBrokenPushingCycles)
				{
					if (vehiclesInBrokenPushingCycle.vehiclePushingInto != null)
					{
						VehicleModel vehicleModel = vehiclesInBrokenPushingCycle;
						do
						{
							VehicleModel vehiclePushingInto = vehicleModel.vehiclePushingInto;
							vehicleModel.vehiclePushingInto = null;
							vehicleModel = vehiclePushingInto;
						}
						while (vehicleModel != vehiclesInBrokenPushingCycle && vehicleModel != null);
					}
				}
			}
			if (_stuckVehicles.Count > 0)
			{
				int frameCount = simulation.Scope.Get<Clock>().FrameCount;
				List<VehicleModel> list = new List<VehicleModel>();
				foreach (VehicleModel stuckVehicle in _stuckVehicles)
				{
					VehicleModel nextVehicleInBlockingChain;
					for (nextVehicleInBlockingChain = stuckVehicle; nextVehicleInBlockingChain != null; nextVehicleInBlockingChain = nextVehicleInBlockingChain.blockingVehicle)
					{
						if (nextVehicleInBlockingChain.frameBlockingChainLastChecked == frameCount)
						{
							if (list.Contains(nextVehicleInBlockingChain))
							{
								int num3 = list.FindIndex((VehicleModel vehicle) => vehicle == nextVehicleInBlockingChain);
								if (num3 > 0)
								{
									list.RemoveRange(0, num3);
								}
								BreakCycle(list);
							}
							break;
						}
						list.Add(nextVehicleInBlockingChain);
						nextVehicleInBlockingChain.frameBlockingChainLastChecked = frameCount;
					}
					list.Clear();
				}
			}
			_vehiclesMovingLanes.Clear();
			_vehiclesInBrokenPushingCycles.Clear();
			_stuckVehicles.Clear();
		}

		private void MoveVehicleToNewLane(VehicleModel vehicle, LaneModel newLane)
		{
			vehicle.isShovingIntoNextIntersection = false;
			if (vehicle.path.Count > 0)
			{
				vehicle.path[0].roadChunk.RemoveInboundVehicle(vehicle, vehicle.path[0]);
				vehicle.path.RemoveAt(0);
				vehicle.pathLength -= newLane.Length;
			}
			LaneModel lane = vehicle.CurrentFrame.lane;
			if (lane != null)
			{
				if (!Diagnostics.Verify(lane != newLane, "Cannot move vehicle to the lane it is already on."))
				{
					return;
				}
				lane.RemoveVehicle(vehicle);
			}
			vehicle.NextFrame.lane = newLane;
			VehicleModel.Frame currentFrame = vehicle.CurrentFrame;
			if (currentFrame.lane == null)
			{
				currentFrame.lane = newLane;
			}
			if (vehicle.path.Count > 3)
			{
				LaneModel pathNextLane = _pathfinder.GetPathNextLane(vehicle.path[1].PathfindingEndNodeId, vehicle.path[vehicle.path.Count - 1].PathfindingStartNodeId);
				if (pathNextLane != null && pathNextLane != vehicle.path[2])
				{
					vehicle.RequestPathfind(VehicleModel.PathfindUrgency.AsSoonAsPossible);
					vehicle.RequestReturnPathfind(VehicleModel.PathfindUrgency.AsSoonAsPossible);
				}
			}
			switch (vehicle.behaviorState)
			{
			case VehicleModel.BehaviorState.WaitingForDestination:
			case VehicleModel.BehaviorState.RealigningDriveway:
				Diagnostics.FailAssert("Vehicle shouldn't be moving lanes in state {0}.", vehicle.behaviorState);
				break;
			case VehicleModel.BehaviorState.DrivingToDestination:
				if (vehicle.path.Count < 2)
				{
					vehicle.behaviorState = VehicleModel.BehaviorState.ParkingAtDestination;
					vehicle.destination.Carpark.vehiclesEntering.Add(vehicle);
				}
				break;
			case VehicleModel.BehaviorState.DrivingHome:
				if ((vehicle.path.Count == 0 && newLane == vehicle.house.DrivewayLane) || (vehicle.path.Count == 1 && vehicle.path[0] == vehicle.house.DrivewayLane))
				{
					Fix64 targetDistanceAlongLastLane = (vehicle.house.HasWaitingVehicle ? vehicle.house.GetLaneDistanceAtBackOfDriveway(vehicle.house.DrivewayLane) : vehicle.house.GetLaneDistanceAtFrontOfDriveway(vehicle.house.DrivewayLane));
					vehicle.targetDistanceAlongLastLane = targetDistanceAlongLastLane;
				}
				if (newLane.roadChunk == vehicle.house.DrivewayLane.roadChunk && vehicle.path.Count == 0)
				{
					if (newLane == vehicle.house.DrivewayLane)
					{
						vehicle.behaviorState = VehicleModel.BehaviorState.WaitingForDestination;
						vehicle.house.waitingVehicles.Add(vehicle);
					}
					else
					{
						vehicle.targetDistanceAlongLastLane = vehicle.house.GetLaneDistanceAtCenterOfDriveway(newLane);
						vehicle.behaviorState = VehicleModel.BehaviorState.RealigningDriveway;
						vehicle.house.realigningVehicles.Add(vehicle);
					}
					vehicle.destination = null;
					vehicle.OnArrivedAtHouse();
				}
				break;
			default:
				Diagnostics.FailAssert("Vehicle in unknown state {0}.", vehicle.behaviorState);
				break;
			case VehicleModel.BehaviorState.ParkingAtDestination:
			case VehicleModel.BehaviorState.ParkedAtDestination:
				break;
			}
			newLane.AddVehicle(vehicle);
			vehicle.OnMovedToNewLane(newLane, lane);
		}

		private void BreakCycle(List<VehicleModel> cycle)
		{
			bool flag = false;
			bool flag2 = true;
			foreach (VehicleModel item in cycle)
			{
				VehicleModel.ObstacleType nearestObstacle = item.NextFrame.nearestObstacle;
				flag = flag || nearestObstacle == VehicleModel.ObstacleType.BlockingIntersection;
				flag2 = flag2 && nearestObstacle == VehicleModel.ObstacleType.LeadingVehicle;
			}
			if (flag)
			{
				foreach (VehicleModel item2 in cycle)
				{
					if (item2.NextFrame.nearestObstacle == VehicleModel.ObstacleType.BlockingIntersection)
					{
						item2.isShovingIntoNextIntersection = true;
					}
				}
				return;
			}
			if (flag2)
			{
				foreach (VehicleModel item3 in cycle)
				{
					item3.vehiclePushingInto = item3.NextFrame.leadingVehicle;
				}
				return;
			}
			Log.Warn("Unable to shove or push vehicle cycle!\n{0}", string.Join("\n", cycle.Select((VehicleModel vehicle) => $"[Vehicle Id={vehicle.id}, Obstacle={vehicle.NextFrame.nearestObstacle}]")));
		}

		public static Fix64 CalculateAcceleration(Fix64 currentGap, Fix64 currentSpeed, Fix64 leadingSpeed, Fix64 leadingAcceleration, Fix64 desiredSpeed, Fix64 maximumAcceleration, Fix64 accelerationExponent, Fix64 maximumDeceleration, Fix64 decelerationExponent)
		{
			return Fix64.FromRaw(NativeCalculateAcceleration(currentGap.RawValue, currentSpeed.RawValue, leadingSpeed.RawValue, leadingAcceleration.RawValue, desiredSpeed.RawValue, maximumAcceleration.RawValue, accelerationExponent.RawValue, maximumDeceleration.RawValue, decelerationExponent.RawValue));
		}

		public static Fix64 ReferenceCalculateAcceleration(Fix64 currentGap, Fix64 currentSpeed, Fix64 leadingSpeed, Fix64 leadingAcceleration, Fix64 desiredSpeed, Fix64 maximumAcceleration, Fix64 accelerationExponent, Fix64 maximumDeceleration, Fix64 decelerationExponent)
		{
			Fix64 fix = Fix64.Max(currentGap - VehicleLength, MinimumGap);
			Fix64 fix2 = currentSpeed - leadingSpeed;
			Fix64 fix3 = ((currentSpeed <= desiredSpeed) ? (maximumAcceleration * (Fix64.One - Fix64.Pow(currentSpeed / desiredSpeed, accelerationExponent))) : (-maximumDeceleration * (Fix64.One - Fix64.Pow(desiredSpeed / currentSpeed, maximumAcceleration * decelerationExponent / maximumDeceleration))));
			Fix64 fix4 = (MinimumGap + Fix64.Max(Fix64.Zero, currentSpeed * DesiredTimeGap + Fix64Consts.OneHalf * currentSpeed * fix2 / Fix64.Sqrt(maximumAcceleration * maximumDeceleration))) / fix;
			Fix64 fix5 = maximumAcceleration * (Fix64.One - fix4 * fix4);
			Fix64 fix6 = ((!(currentSpeed <= desiredSpeed)) ? ((fix4 >= Fix64.One) ? (fix3 + fix5) : fix3) : ((fix4 >= Fix64.One) ? fix5 : (fix3 * (Fix64.One - Fix64.Pow(fix4, Fix64Consts.Two * maximumAcceleration / Fix64.Max(fix3, OneEMinus3))))));
			Fix64 fix7 = ((currentSpeed - leadingSpeed >= Fix64.Zero) ? Fix64.One : Fix64.Zero);
			Fix64 fix8 = Fix64Consts.Two * fix * leadingAcceleration;
			if (fix8 == Fix64.Zero)
			{
				fix8 = OneEMinus5;
			}
			Fix64 first = ((leadingSpeed * fix2 < -fix8) ? (currentSpeed * currentSpeed * leadingAcceleration / (leadingSpeed * leadingSpeed - fix8)) : (leadingAcceleration - fix2 * fix2 * fix7 / (Fix64Consts.Two * fix)));
			first = Fix64.Min(first, maximumAcceleration);
			Fix64 second = ((fix6 >= first) ? fix6 : ((Fix64.One - CoolnessFactor) * fix6 + CoolnessFactor * (first + maximumDeceleration * Fix64.Tanh((fix6 - first) / maximumDeceleration))));
			if (!(desiredSpeed < OneEMinus5))
			{
				return Fix64.Max(-maximumDeceleration, second);
			}
			return Fix64.Zero;
		}

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CalculateAcceleration")]
		private static extern long NativeCalculateAcceleration(long currentGap, long currentSpeed, long leadingSpeed, long leadingAcceleration, long desiredSpeed, long maximumAcceleration, long accelerationExponent, long maximumDeceleration, long decelerationExponent);
	}
}
