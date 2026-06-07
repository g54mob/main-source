using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using JetBrains.Annotations;
using Motorways.Processes;
using Server;
using Unity.Profiling;

namespace Motorways.Models
{
	public class RoadChunkModel : Model<EmptyModelFrame, IEmptyModelObserver>, IDeserializedHandler
	{
		[Serializable(1)]
		public class InboundVehicle : IReusable
		{
			public VehicleModel vehicle;

			public LaneModel chosenLane;

			public Fix64 timestamp;

			public Fix64 committedTimestamp = -Fix64.One;

			public bool IsShoving
			{
				get
				{
					if (vehicle.isShovingIntoNextIntersection && vehicle.path.Count > 0)
					{
						return vehicle.path[0] == chosenLane;
					}
					return false;
				}
			}

			public void Reset()
			{
				vehicle = null;
				chosenLane = null;
				timestamp = Fix64.Zero;
				committedTimestamp = -Fix64.One;
			}
		}

		private class InboundVehicleDistanceComparer : IComparer<InboundVehicle>
		{
			public static LaneModel roundaboutLane;

			public int Compare(InboundVehicle x, InboundVehicle y)
			{
				if (x.IsShoving ^ y.IsShoving)
				{
					if (!x.IsShoving)
					{
						return 1;
					}
					return -1;
				}
				if (roundaboutLane != null)
				{
					bool flag = IsVehicleOnRoundabout(x.vehicle, roundaboutLane);
					if (flag != IsVehicleOnRoundabout(y.vehicle, roundaboutLane))
					{
						if (!flag)
						{
							return 1;
						}
						return -1;
					}
				}
				Fix64 fix = x.vehicle.DistanceToLane(x.chosenLane);
				Fix64 other = y.vehicle.DistanceToLane(y.chosenLane);
				int num = fix.CompareTo(other);
				if (num == 0)
				{
					return x.timestamp.CompareTo(y.timestamp);
				}
				return num;
			}

			private bool IsVehicleOnRoundabout(VehicleModel vehicle, LaneModel roundaboutLane)
			{
				LaneModel lane = vehicle.CurrentFrame.lane;
				LaneModel laneModel = roundaboutLane;
				do
				{
					if (lane == roundaboutLane || lane.OutboundLanes.Contains(roundaboutLane))
					{
						return true;
					}
					bool flag = false;
					foreach (LaneModel outboundLane in roundaboutLane.OutboundLanes)
					{
						if (outboundLane.connection.IsRoundabout)
						{
							roundaboutLane = outboundLane;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return false;
					}
				}
				while (roundaboutLane != laneModel);
				return false;
			}
		}

		public readonly List<LaneModel> lanes = new List<LaneModel>();

		private Fix64 _laneSpeedLimitScale = Fix64Consts.One;

		private static readonly Fix64 CarStoppedSpeedThreshold;

		private static readonly InboundVehicleDistanceComparer inboundVehicleDistanceComparer;

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private SimulationConstantsData _constants;

		public bool isTileCorner;

		private TrafficLightModel _trafficLightModel;

		public readonly List<InboundVehicle> inboundVehicles = new List<InboundVehicle>();

		public readonly List<InboundVehicle> returningInboundVehicles = new List<InboundVehicle>();

		[Serialize(false, null)]
		public readonly List<VehicleModel> traversingVehicles = new List<VehicleModel>();

		private static readonly Diagnostics.Log.Channel Log;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private ClockModel _clock;

		private TileDirectionBitfield _outboundDirections;

		private static readonly ProfilerMarker Profiler_GetNumberOfRoadsInIntersectionForSlowingVehicles;

		private static readonly ProfilerMarker Profiler_SortInboundVehicles;

		private static readonly ProfilerMarker Profiler_SortInboundVehiclesSorting;

		private static readonly ProfilerMarker Profiler_CanInboundVehicleEnter;

		private static readonly ProfilerMarker Profiler_InboundVehicleCollidesWithTraversingVehicle;

		private static readonly ProfilerMarker Profiler_VehicleHasSpace;

		[Serialize(true, null)]
		public TrainCrossingModel TrainCrossingModel { get; set; }

		public TrafficLightModel TrafficLight
		{
			get
			{
				return _trafficLightModel;
			}
			set
			{
				_trafficLightModel = value;
				foreach (LaneModel lane in lanes)
				{
					foreach (LaneModel inboundLane in lane.InboundLanes)
					{
						inboundLane.RecalculateSpeedLimit();
					}
				}
			}
		}

		public bool IsControlled
		{
			get
			{
				if (_trafficLightModel != null)
				{
					return true;
				}
				if (TrainCrossingModel != null)
				{
					return false;
				}
				return IsRoundabout;
			}
		}

		public bool IsRoundabout
		{
			get
			{
				foreach (LaneModel lane in lanes)
				{
					if (lane.connection.IsRoundabout)
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsTrainCrossing => TrainCrossingModel != null;

		static RoadChunkModel()
		{
			CarStoppedSpeedThreshold = (Fix64)0.001f;
			inboundVehicleDistanceComparer = new InboundVehicleDistanceComparer();
			Log = Diagnostics.Log.OpenChannel("RoadChunkModel");
			Profiler_GetNumberOfRoadsInIntersectionForSlowingVehicles = new ProfilerMarker(ProfilerUtility.CategoryModel, "RoadChunkModel.GetNumberOfRoadsInIntersectionForSlowingVehicles");
			Profiler_SortInboundVehicles = new ProfilerMarker(ProfilerUtility.CategoryModel, "RoadChunkModel.SortInboundVehicles");
			Profiler_SortInboundVehiclesSorting = new ProfilerMarker(ProfilerUtility.CategoryModel, "RoadChunkModel.SortInboundVehicles.Sorting");
			Profiler_CanInboundVehicleEnter = new ProfilerMarker(ProfilerUtility.CategoryModel, "RoadChunkModel.CanInboundVehicleEnter");
			Profiler_InboundVehicleCollidesWithTraversingVehicle = new ProfilerMarker(ProfilerUtility.CategoryModel, "RoadChunkModel.InboundVehicleCollidesWithTraversingVehicle");
			Profiler_VehicleHasSpace = new ProfilerMarker(ProfilerUtility.CategoryModel, "RoadChunkModel.VehicleHasSpace");
			Log.IsMuted = true;
		}

		public override void Reset()
		{
			base.Reset();
			lanes.Clear();
			TrafficLight = null;
			_laneSpeedLimitScale = Fix64Consts.One;
			isTileCorner = false;
			traversingVehicles.Clear();
			_outboundDirections = default(TileDirectionBitfield);
			TrainCrossingModel = null;
		}

		public bool AddInboundVehicle(VehicleModel vehicle, LaneModel chosenLane, int offset, bool returningInboundVehicle = false)
		{
			if (!Diagnostics.Verify(lanes.Contains(chosenLane), "Can't add a vehicle inbound to a lane arbitrated by a different road chunk."))
			{
				return false;
			}
			InboundVehicle inboundVehicle = _scope.Get<InboundVehicle>();
			inboundVehicle.vehicle = vehicle;
			inboundVehicle.chosenLane = chosenLane;
			inboundVehicle.timestamp = _clock.Time + (Fix64)offset;
			if (!returningInboundVehicle)
			{
				inboundVehicles.Add(inboundVehicle);
			}
			else
			{
				returningInboundVehicles.Add(inboundVehicle);
			}
			chosenLane.hasBeenUsed = true;
			return true;
		}

		public bool RemoveInboundVehicle(VehicleModel vehicle, LaneModel lane, bool returningVehicle = false)
		{
			List<InboundVehicle> list = (returningVehicle ? returningInboundVehicles : inboundVehicles);
			for (int i = 0; i < list.Count; i++)
			{
				InboundVehicle inboundVehicle = list[i];
				if (inboundVehicle.vehicle == vehicle && inboundVehicle.chosenLane == lane)
				{
					_scope.Release(inboundVehicle);
					list.RemoveAt(i);
					return true;
				}
			}
			Diagnostics.FailAssert("Failed to find inbound vehicle {0} for lane {1}!", vehicle, lane);
			return false;
		}

		public void SortInboundVehicles()
		{
			traversingVehicles.Clear();
			if (inboundVehicles.Count == 0 || (lanes.Count <= 2 && TrainCrossingModel == null))
			{
				return;
			}
			foreach (LaneModel lane in lanes)
			{
				foreach (VehicleModel vehicle in lane.Vehicles)
				{
					traversingVehicles.Add(vehicle);
				}
			}
			int num = -1;
			int count = inboundVehicles.Count;
			for (int i = 0; i < count; i++)
			{
				InboundVehicle inboundVehicle = inboundVehicles[i];
				bool num2 = inboundVehicle.vehicle.IsCommittedToLane(inboundVehicle.chosenLane);
				if (num2 && inboundVehicle.committedTimestamp < Fix64.Zero)
				{
					inboundVehicle.committedTimestamp = _clock.Time;
				}
				int num3;
				if (!num2 || IsDirectionBlockedByTrafficLight(inboundVehicle.chosenLane.connection.input.direction, inboundVehicle.chosenLane.connection.output.direction) || WouldInboundVehicleCollideWithTraversingVehicle(inboundVehicle, out var _))
				{
					num3 = (inboundVehicle.IsShoving ? 1 : 0);
					if (num3 == 0 && num < 0)
					{
						num = i;
					}
				}
				else
				{
					num3 = 1;
				}
				if (num3 != 0 && num >= 0)
				{
					InboundVehicle value = inboundVehicles[num];
					inboundVehicles[num] = inboundVehicles[i];
					inboundVehicles[i] = value;
					num++;
				}
			}
			LaneModel roundaboutLane = null;
			foreach (LaneModel lane2 in lanes)
			{
				if (lane2.connection.IsRoundabout)
				{
					roundaboutLane = lane2;
					break;
				}
			}
			InboundVehicleDistanceComparer.roundaboutLane = roundaboutLane;
			if (num > 1)
			{
				inboundVehicles.Sort(0, num, inboundVehicleDistanceComparer);
			}
			else if (num < 0)
			{
				inboundVehicles.Sort(inboundVehicleDistanceComparer);
			}
		}

		public bool CanInboundVehicleEnter([NotNull] VehicleModel vehicle, out VehicleModel blockingVehicle, [CanBeNull] IntersectionEntryDecision decision = null)
		{
			blockingVehicle = null;
			InboundVehicle inboundVehicle = InboundVehicleForVehicle(vehicle);
			if (!Diagnostics.Verify(inboundVehicle != null, "Can't find InboundVehicle for {0}.", vehicle))
			{
				return false;
			}
			decision?.Initialize(inboundVehicle);
			LaneModel chosenLane = inboundVehicle.chosenLane;
			if (!Diagnostics.Verify(chosenLane != null, "InboundVehicle for {0} does not have an assigned lane.", vehicle))
			{
				decision?.SetVerdict(IntersectionEntryVerdict.NoReservedLane);
				return false;
			}
			if (TrainCrossingModel != null)
			{
				TrainCrossingModel trainCrossingModel = vehicle.CurrentFrame.lane.roadChunk.TrainCrossingModel;
				if (trainCrossingModel == null || trainCrossingModel.SignalState != TrainSignalState.Closed)
				{
					if (TrainCrossingModel.SignalState == TrainSignalState.Closed)
					{
						Fix64 zero = Fix64.Zero;
						zero += vehicle.CurrentFrame.lane.Length - vehicle.CurrentFrame.distanceAlongLane;
						foreach (LaneModel item in vehicle.path)
						{
							if (item.roadChunk == this)
							{
								break;
							}
							zero += item.Length;
						}
						if (!isTileCorner || zero > VehicleMovementProcess.VehicleLength)
						{
							decision?.SetVerdict(IntersectionEntryVerdict.BlockedByUnsafeCrossing);
							return false;
						}
						Log.Info("Not stopping vehicle {0} at train crossing on chunk ? because distance to the crossing chunk is only {1} - less than vehicle length: {2}", vehicle.id, zero, VehicleMovementProcess.VehicleLength);
					}
					else if (vehicle.CurrentFrame.lane.state != RoadState.Mothballed)
					{
						foreach (LaneModel item2 in vehicle.path)
						{
							foreach (VehicleModel traversingVehicle in item2.roadChunk.traversingVehicles)
							{
								if (!traversingVehicle.CurrentFrame.lane.connection.IntersectsOtherConnection(item2.connection) || traversingVehicle.blockingVehicle == null)
								{
									continue;
								}
								Fix64 zero2 = Fix64.Zero;
								if (traversingVehicle.CurrentFrame.lane == traversingVehicle.blockingVehicle.CurrentFrame.lane)
								{
									zero2 += traversingVehicle.blockingVehicle.CurrentFrame.distanceAlongLane - traversingVehicle.CurrentFrame.distanceAlongLane;
								}
								else
								{
									zero2 += traversingVehicle.CurrentFrame.lane.Length - traversingVehicle.CurrentFrame.distanceAlongLane;
									foreach (LaneModel item3 in traversingVehicle.path)
									{
										if (item3 == traversingVehicle.blockingVehicle.CurrentFrame.lane)
										{
											zero2 += traversingVehicle.blockingVehicle.CurrentFrame.distanceAlongLane;
											break;
										}
										zero2 += item3.Length;
									}
								}
								if (zero2 < (Fix64)3L * VehicleMovementProcess.VehicleLength || traversingVehicle.CurrentFrame.speed < CarStoppedSpeedThreshold)
								{
									Log.Info("Vehicle {0} blocked from entering train crossing because vehicle {1} is currently on or just after the crossing and is blocked by vehicle {2} which is only {3} in front of it", vehicle.id, traversingVehicle.id, traversingVehicle.blockingVehicle.id, zero2);
									decision?.SetVerdict(IntersectionEntryVerdict.BlockedByCongestedCrossing);
									return false;
								}
							}
							if (item2.roadChunk.TrainCrossingModel == null)
							{
								break;
							}
						}
					}
				}
			}
			if (lanes.Count <= 2)
			{
				decision?.SetVerdict(IntersectionEntryVerdict.NoIntersectingLanes);
				return true;
			}
			if (IsDirectionBlockedByTrafficLight(chosenLane.connection.input.direction, chosenLane.connection.output.direction))
			{
				decision?.SetVerdict(IntersectionEntryVerdict.BlockedByTrafficLight);
				return false;
			}
			if (vehicle.isShovingIntoNextIntersection && vehicle.path.Count > 0 && vehicle.path[0] == chosenLane)
			{
				decision?.SetVerdict(IntersectionEntryVerdict.Shoved);
				return true;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.MaximumWaitTimeAtIntersections) && _clock.Time - inboundVehicle.committedTimestamp > _constants.MaximumTimeToWaitAtIntersection)
			{
				decision?.SetVerdict(IntersectionEntryVerdict.ExceededMaximumWaitTime);
				return true;
			}
			if (WouldInboundVehicleCollideWithTraversingVehicle(inboundVehicle, out blockingVehicle, decision))
			{
				decision?.SetVerdict(IntersectionEntryVerdict.BlockedByTraversingVehicle);
				return false;
			}
			foreach (InboundVehicle inboundVehicle2 in inboundVehicles)
			{
				if (inboundVehicle2.vehicle == vehicle)
				{
					decision?.SetVerdict(IntersectionEntryVerdict.NoBlockingVehicles);
					return true;
				}
				bool flag = inboundVehicle2.vehicle.CurrentFrame.nearestObstacle == VehicleModel.ObstacleType.HotswappingLane || inboundVehicle2.vehicle.CurrentFrame.speed < CarStoppedSpeedThreshold;
				if (inboundVehicle.chosenLane.connection.IntersectsOtherConnection(inboundVehicle2.chosenLane.connection, leftSideTraffic: false, smallIntersection: true, flag))
				{
					blockingVehicle = inboundVehicle2.vehicle;
					decision?.SetInboundVehicleInfluence(inboundVehicle2, IntersectionEntryVehicleInfluence.ReservedIntersectingLane);
					decision?.SetVerdict(IntersectionEntryVerdict.BlockedByInboundVehicle);
					return false;
				}
				if (decision != null)
				{
					IntersectionEntryVehicleInfluence influence = IntersectionEntryVehicleInfluence.ReservedNonIntersectingLane;
					if (flag && inboundVehicle.chosenLane.connection.IntersectsOtherConnection(inboundVehicle2.chosenLane.connection, leftSideTraffic: false, smallIntersection: true))
					{
						influence = ((inboundVehicle2.vehicle.CurrentFrame.nearestObstacle == VehicleModel.ObstacleType.HotswappingLane) ? IntersectionEntryVehicleInfluence.BlockedByHotswap : IntersectionEntryVehicleInfluence.Stopped);
					}
					decision.SetInboundVehicleInfluence(inboundVehicle2, influence);
				}
			}
			return inboundVehicles[0].vehicle == vehicle;
		}

		public bool WouldInboundVehicleCollideWithTraversingVehicle(InboundVehicle inboundVehicle, out VehicleModel collidingVehicle, IntersectionEntryDecision decision = null)
		{
			bool flag = _constants.greenLightsIgnoreCollisions && IsDirectionGreenFromTrafficLight(inboundVehicle.chosenLane.connection.input.direction);
			bool flag2 = false;
			bool flag3 = false;
			foreach (VehicleModel traversingVehicle in traversingVehicles)
			{
				if (traversingVehicle.id == inboundVehicle.vehicle.id)
				{
					decision?.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.Self);
					continue;
				}
				if (traversingVehicle.path == null || traversingVehicle.path.Count == 0)
				{
					decision?.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.Parked);
					continue;
				}
				if (_constants.TreatStraightRoundaboutEntrancesAsNotRoundabouts && HasVehicleNotYetEnteredRoundabout(traversingVehicle) && inboundVehicle.chosenLane != traversingVehicle.CurrentFrame.lane)
				{
					decision?.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.SeparateRoundaboutEntrance);
					continue;
				}
				if (SharesExitToIntersection(traversingVehicle.CurrentFrame.lane, inboundVehicle.chosenLane))
				{
					if (!flag2)
					{
						flag3 = DoesVehicleHaveSpace(inboundVehicle.vehicle);
						flag2 = true;
					}
					if (!flag3)
					{
						collidingVehicle = traversingVehicle;
						decision?.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.SameExitNoSpace);
						return true;
					}
				}
				else if (traversingVehicle.CurrentFrame.distanceAlongLane > traversingVehicle.CurrentFrame.lane.Length - VehicleMovementProcess.VehicleLength)
				{
					decision?.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.AlmostThroughLane);
					continue;
				}
				if (!flag && traversingVehicle.CurrentFrame.lane != inboundVehicle.chosenLane && traversingVehicle.CurrentFrame.lane.connection.IntersectsOtherConnection(inboundVehicle.chosenLane.connection, leftSideTraffic: false, smallIntersection: true))
				{
					collidingVehicle = traversingVehicle;
					decision?.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.OnIntersectingLane);
					return true;
				}
				if (decision != null)
				{
					if (flag && traversingVehicle.CurrentFrame.lane != inboundVehicle.chosenLane && traversingVehicle.CurrentFrame.lane.connection.IntersectsOtherConnection(inboundVehicle.chosenLane.connection, leftSideTraffic: false, smallIntersection: true))
					{
						decision.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.OnIgnoredIntersectingLane);
					}
					else
					{
						decision.SetTraversingVehicleInfluence(traversingVehicle, IntersectionEntryVehicleInfluence.None);
					}
				}
			}
			collidingVehicle = null;
			return false;
		}

		public bool CanTraversingVehicleContinue(VehicleModel vehicle)
		{
			if (!_constants.TreatStraightRoundaboutEntrancesAsNotRoundabouts)
			{
				return true;
			}
			if (!IsRoundabout)
			{
				return true;
			}
			if (inboundVehicles.Count == 0)
			{
				return true;
			}
			if (Diagnostics.Verify(lanes.Contains(vehicle.CurrentFrame.lane), "This vehicle isn't actually in this road chunk!") && HasVehicleNotYetEnteredRoundabout(vehicle) && inboundVehicles[0].chosenLane.connection.IsRoundabout && inboundVehicles[0].chosenLane.InboundLanes.Contains(inboundVehicles[0].vehicle.CurrentFrame.lane))
			{
				return false;
			}
			return true;
		}

		private bool HasVehicleNotYetEnteredRoundabout(VehicleModel vehicle)
		{
			if (IsRoundabout && !TileUtilities.IsDirectionDiagonal(vehicle.CurrentFrame.lane.connection.input.direction) && vehicle.CurrentFrame.lane.connection.input.type != RoadType.Roundabout && vehicle.CurrentFrame.lane.connection.output.type == RoadType.Roundabout)
			{
				return vehicle.CurrentFrame.distanceAlongLane < vehicle.CurrentFrame.lane.Length * _constants.PercentageOfStraightLanesIntoRoundaboutsToCountOutside;
			}
			return false;
		}

		private bool DoesVehicleHaveSpace(VehicleModel inputVehicle)
		{
			VehicleModel vehicleModel = inputVehicle;
			Fix64 zero = Fix64.Zero;
			for (int i = 0; i < 5; i++)
			{
				if (vehicleModel == null)
				{
					break;
				}
				VehicleModel.Frame currentFrame = vehicleModel.CurrentFrame;
				switch (currentFrame.nearestObstacle)
				{
				case VehicleModel.ObstacleType.None:
					return true;
				case VehicleModel.ObstacleType.Target:
					zero += vehicleModel.targetDistanceAlongLastLane - currentFrame.distanceAlongLane - VehicleMovementProcess.VehicleLength;
					vehicleModel = null;
					break;
				case VehicleModel.ObstacleType.BlockingIntersection:
				case VehicleModel.ObstacleType.HotswappingLane:
					zero += currentFrame.distanceToBlockingLane;
					vehicleModel = null;
					break;
				case VehicleModel.ObstacleType.LeadingVehicle:
				{
					VehicleModel leadingVehicle = currentFrame.leadingVehicle;
					Fix64 distanceToLeadingVehicle = currentFrame.distanceToLeadingVehicle;
					LaneModel lane = leadingVehicle.CurrentFrame.lane;
					if (lane.roadChunk == this)
					{
						distanceToLeadingVehicle -= lane.Length - VehicleMovementProcess.VehicleLength;
					}
					zero += Fix64.Max(distanceToLeadingVehicle - VehicleMovementProcess.VehicleLength, Fix64.Zero);
					vehicleModel = leadingVehicle;
					break;
				}
				}
				if (zero > VehicleMovementProcess.VehicleLength * Fix64Consts.Two)
				{
					return true;
				}
			}
			return false;
		}

		private bool SharesExitToIntersection(LaneModel laneA, LaneModel laneB)
		{
			return laneA.connection.output.direction == laneB.connection.output.direction;
		}

		private InboundVehicle InboundVehicleForVehicle(VehicleModel vehicle)
		{
			InboundVehicle inboundVehicle = null;
			foreach (InboundVehicle inboundVehicle2 in inboundVehicles)
			{
				if (inboundVehicle2.vehicle == vehicle && (inboundVehicle == null || inboundVehicle.timestamp > inboundVehicle2.timestamp))
				{
					inboundVehicle = inboundVehicle2;
				}
			}
			return inboundVehicle;
		}

		public bool DoesLaneHaveAnyInboundVehicles(LaneModel laneModel)
		{
			foreach (InboundVehicle inboundVehicle in inboundVehicles)
			{
				if (inboundVehicle.chosenLane == laneModel)
				{
					return true;
				}
			}
			foreach (InboundVehicle returningInboundVehicle in returningInboundVehicles)
			{
				if (returningInboundVehicle.chosenLane == laneModel)
				{
					return true;
				}
			}
			return false;
		}

		public bool DoesLaneHaveAnyCommittedVehicles(LaneModel laneModel)
		{
			foreach (InboundVehicle inboundVehicle in inboundVehicles)
			{
				if (inboundVehicle.chosenLane == laneModel)
				{
					return inboundVehicle.vehicle.IsCommittedToLane(laneModel);
				}
			}
			return false;
		}

		public bool HasLaneForConnection(RoadTileConnection connection)
		{
			foreach (LaneModel lane in lanes)
			{
				if (lane.connection.Equals(connection))
				{
					return true;
				}
			}
			return false;
		}

		public LaneModel AddLane(RoadTileConnection connection, RoadTileDefinition definition, RoadState initialState, Vector2Fixed position, bool isEndpointLane)
		{
			Log.Info("Adding {0} lane for connection {1} at position {2}.", initialState, connection, position);
			foreach (LaneModel lane in lanes)
			{
				if (lane.connection.Equals(connection) && !Diagnostics.Verify(!lane.connection.Equals(connection), "Please don't add a new {0} lane for with the same connection as {1}.", initialState, lane))
				{
					return lane;
				}
			}
			LaneModel laneModel = _scope.Get<LaneModel>();
			laneModel.Initialize(this, definition, connection, position, isEndpointLane);
			laneModel.state = initialState;
			AddLaneModel(laneModel);
			return laneModel;
		}

		public LaneModel AddBespokeLane(RoadTileConnection connection, List<Vector2Fixed> path, RoadState initialState, bool isCarparkLane = false, bool isEndpointLane = false)
		{
			LaneModel laneModel = _scope.Get<LaneModel>();
			laneModel.Initialize(this, connection, path, isEndpointLane, isCarparkLane);
			laneModel.state = initialState;
			AddLaneModel(laneModel);
			return laneModel;
		}

		public bool RemoveLane(LaneModel lane)
		{
			if (!Diagnostics.Verify(lanes.Contains(lane), "Unable to remove lane from a road chunk it is not part of."))
			{
				return false;
			}
			if (lane.isTemporary)
			{
				_tilemap.TemporaryLanes.Remove(lane);
			}
			else if (TrainCrossingModel != null)
			{
				_simulation.RemoveModel(TrainCrossingModel);
				TrainCrossingModel = null;
			}
			lane.RemoveInboundAndOutboundLanes();
			lanes.Remove(lane);
			_simulation.RemoveModel(lane);
			TrafficLight?.OnLanesChanged();
			return true;
		}

		public void RemoveAllLanes()
		{
			for (int num = lanes.Count - 1; num >= 0; num--)
			{
				LaneModel lane = lanes[num];
				RemoveLane(lane);
			}
		}

		public void ConnectInboundLane(LaneModel inboundLane)
		{
			foreach (LaneModel item in GetLanesEnteringFromDirection(TileUtilities.GetOppositeDirection(inboundLane.connection.output.direction)))
			{
				item.AddInboundLane(inboundLane);
				inboundLane.AddOutboundLane(item);
			}
		}

		public void ConnectOutboundLane(LaneModel outboundLane)
		{
			foreach (LaneModel item in GetLanesExitingInDirection(TileUtilities.GetOppositeDirection(outboundLane.connection.input.direction)))
			{
				item.AddOutboundLane(outboundLane);
				outboundLane.AddInboundLane(item);
			}
		}

		public TileDirectionBitfield GetInboundDirections()
		{
			List<TileDirection> list = new List<TileDirection>();
			foreach (LaneModel lane in lanes)
			{
				list.Add(lane.connection.input.direction);
			}
			return new TileDirectionBitfield(list);
		}

		public List<LaneModel> GetLanesConnectedToDirection(RoadState states, TileDirection direction)
		{
			return GetLanesConnectedToDirections(states, new TileDirectionBitfield { [direction] = true });
		}

		public List<LaneModel> GetLanesConnectedToDirections(RoadState states, TileDirectionBitfield directions)
		{
			List<LaneModel> list = new List<LaneModel>();
			foreach (LaneModel lane in lanes)
			{
				if ((lane.state & states) == lane.state && (directions[lane.connection.input.direction] || directions[lane.connection.output.direction]))
				{
					list.Add(lane);
				}
			}
			return list;
		}

		public List<LaneModel> GetLanesEnteringFromDirection(TileDirection direction)
		{
			List<LaneModel> list = new List<LaneModel>();
			foreach (LaneModel lane in lanes)
			{
				if (lane.connection.input.direction == direction)
				{
					list.Add(lane);
				}
			}
			return list;
		}

		public List<LaneModel> GetLanesExitingInDirection(TileDirection direction)
		{
			List<LaneModel> list = new List<LaneModel>();
			foreach (LaneModel lane in lanes)
			{
				if (lane.connection.output.direction == direction)
				{
					list.Add(lane);
				}
			}
			return list;
		}

		public int GetNumberOfRoadsInIntersectionForSlowingVehicles()
		{
			TileDirectionBitfield tileDirectionBitfield = default(TileDirectionBitfield);
			int num = 0;
			foreach (LaneModel lane in lanes)
			{
				TileDirection direction = lane.connection.output.direction;
				if (tileDirectionBitfield[direction] || (lane.state == RoadState.Mothballed && lane.connection.IsUTurn))
				{
					continue;
				}
				if (_constants.IgnoreHousesForIntersectionSlowDown)
				{
					bool flag = false;
					if (TileUtilities.IsDirectionDiagonal(direction))
					{
						foreach (LaneModel outboundLane in lane.OutboundLanes)
						{
							if (outboundLane.connection.output.direction == direction && outboundLane.OutboundLanes.Count == 1 && outboundLane.OutboundLanes[0].connection.IsUTurn && outboundLane.OutboundLanes[0].connection.input.type == RoadType.Driveway)
							{
								flag = true;
								break;
							}
						}
					}
					else
					{
						flag = lane.OutboundLanes.Count == 1 && lane.OutboundLanes[0].connection.IsUTurn && lane.OutboundLanes[0].connection.input.type == RoadType.Driveway;
					}
					if (flag)
					{
						continue;
					}
				}
				if ((!_constants.IgnoreDestinationsForIntersectionSlowDown || !Diagnostics.Verify(lane.OutboundLanes.Count > 0) || lane.OutboundLanes[0].connection.output.type != RoadType.Carpark) && lane.connection.output.type != RoadType.Roundabout && lane.connection.input.type != RoadType.Roundabout)
				{
					tileDirectionBitfield[direction] = true;
					num++;
				}
			}
			return num;
		}

		public IEnumerable<InboundVehicle> InboundVehiclesEnteringFromDirection(TileDirection direction, Fix64 withinDistance)
		{
			foreach (InboundVehicle inboundVehicle in inboundVehicles)
			{
				if (inboundVehicle.vehicle.IsCommittedToLane(inboundVehicle.chosenLane) && inboundVehicle.chosenLane.connection.input.direction == direction)
				{
					if (withinDistance <= Fix64.Zero)
					{
						yield return inboundVehicle;
					}
					else if (inboundVehicle.vehicle.DistanceToLane(inboundVehicle.chosenLane) < withinDistance)
					{
						yield return inboundVehicle;
					}
				}
			}
		}

		public int NumberOfCarsEnteringFromDirection(TileDirection direction, bool ignoreBlockedVehicles, Fix64 withinDistance)
		{
			int num = 0;
			foreach (InboundVehicle inboundVehicle in inboundVehicles)
			{
				if (!inboundVehicle.vehicle.IsCommittedToLane(inboundVehicle.chosenLane))
				{
					continue;
				}
				if (ignoreBlockedVehicles && (inboundVehicle.vehicle.CurrentFrame.nearestObstacle == VehicleModel.ObstacleType.HotswappingLane || inboundVehicle.vehicle.CurrentFrame.blockingLane?.roadChunk == this))
				{
					break;
				}
				if (inboundVehicle.chosenLane.connection.input.direction == direction)
				{
					if (withinDistance <= Fix64.Zero)
					{
						num++;
					}
					else if (inboundVehicle.vehicle.DistanceToLane(inboundVehicle.chosenLane) < withinDistance)
					{
						num++;
					}
				}
			}
			return num;
		}

		public void SetLaneSpeedLimitScale(Fix64 newSpeedScale)
		{
			_laneSpeedLimitScale = newSpeedScale;
			foreach (LaneModel lane in lanes)
			{
				lane.SetSpeedLimitScale(_laneSpeedLimitScale);
			}
		}

		public void SetSpeedLimitScaleOnDirections(TileDirectionBitfield directions, Fix64 newSpeedScale, bool resetOtherDirections)
		{
			foreach (LaneModel lane in lanes)
			{
				if (directions[lane.connection.output.direction])
				{
					lane.SetSpeedLimitScale(newSpeedScale);
				}
				else if (resetOtherDirections)
				{
					lane.SetSpeedLimitScale(Fix64.One);
				}
			}
		}

		public void UpdateLaneCosts()
		{
			foreach (LaneModel lane in lanes)
			{
				if (lane.PathfindingStartNodeId != -1 && lane.PathfindingEndNodeId != -1)
				{
					lane.UpdateLaneCost(lane.PathfindingCost);
				}
			}
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			foreach (InboundVehicle inboundVehicle in inboundVehicles)
			{
				scope.Release(inboundVehicle);
			}
			inboundVehicles.Clear();
			foreach (InboundVehicle returningInboundVehicle in returningInboundVehicles)
			{
				scope.Release(returningInboundVehicle);
			}
			returningInboundVehicles.Clear();
		}

		public void OnDeserialized(IScope context)
		{
			foreach (LaneModel lane in lanes)
			{
				lane.roadChunk = this;
				lane.SetSpeedLimitScale(_laneSpeedLimitScale);
			}
		}

		private void AddLaneModel(LaneModel newLane)
		{
			newLane.SetSpeedLimitScale(_laneSpeedLimitScale);
			lanes.Add(newLane);
			_simulation.AddModel(newLane);
			if (TrafficLight != null)
			{
				TrafficLight.OnLanesChanged();
			}
		}

		public TileDirectionBitfield GetOutboundDirections()
		{
			if (_outboundDirections.Count != lanes.Count)
			{
				List<TileDirection> list = new List<TileDirection>();
				foreach (LaneModel lane in lanes)
				{
					list.Add(lane.connection.output.direction);
				}
				_outboundDirections = new TileDirectionBitfield(list);
			}
			return _outboundDirections;
		}

		private bool IsDirectionGreenFromTrafficLight(TileDirection direction)
		{
			if (TrafficLight != null)
			{
				return !_trafficLightModel.BlockedLanes[direction];
			}
			return false;
		}

		public bool ConnectionCrossesLane(TileDirection directionEnteringIntersection, TileDirection directionExitingIntersection)
		{
			if (_constants.americanRedLightRules)
			{
				TileDirectionBitfield outboundDirections = GetOutboundDirections();
				for (int i = 1; i <= 3; i++)
				{
					TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(directionEnteringIntersection, -i);
					if (outboundDirections[rotatedDirection])
					{
						return rotatedDirection != directionExitingIntersection;
					}
				}
				return true;
			}
			return true;
		}

		private bool IsDirectionBlockedByTrafficLight(TileDirection directionEnteringIntersection, TileDirection directionExitingIntersection)
		{
			if (TrafficLight != null)
			{
				if (_trafficLightModel.BlockedLanes[directionEnteringIntersection])
				{
					return ConnectionCrossesLane(directionEnteringIntersection, directionExitingIntersection);
				}
				return false;
			}
			return false;
		}

		public RoadChunkModel()
			: base(1)
		{
		}
	}
}
