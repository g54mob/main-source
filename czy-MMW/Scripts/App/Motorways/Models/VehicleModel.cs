using System;
using System.Collections.Generic;
using Factory;
using FixMath;
using Server;
using Unity.Profiling;

namespace Motorways.Models
{
	public class VehicleModel : Model<VehicleModel.Frame, VehicleModel.IObserver>, ICreatedInScopeHandler
	{
		public enum ObstacleType
		{
			None = 0,
			Target = 1,
			LeadingVehicle = 2,
			BlockingIntersection = 3,
			HotswappingLane = 4
		}

		public enum PathfindUrgency
		{
			NotRequired = 0,
			WhenPossible = 1,
			AsSoonAsPossible = 2
		}

		public enum BehaviorState
		{
			WaitingForDestination = 0,
			DrivingToDestination = 1,
			ParkingAtDestination = 2,
			ParkedAtDestination = 3,
			DrivingHome = 4,
			RealigningDriveway = 5
		}

		public class Frame : IFrame
		{
			public LaneModel lane;

			public Fix64 distanceAlongLane;

			public Fix64 speed;

			public Fix64 acceleration;

			public ObstacleType nearestObstacle;

			public VehicleModel leadingVehicle;

			public Fix64 distanceToLeadingVehicle = Fix64.MaxValue;

			public LaneModel blockingLane;

			public Fix64 distanceToBlockingLane = Fix64.MaxValue;

			public bool CloneInto(IFrame cloneFrame, IScope scope)
			{
				Frame obj = (Frame)cloneFrame;
				obj.lane = lane;
				obj.distanceAlongLane = distanceAlongLane;
				obj.acceleration = acceleration;
				obj.speed = speed;
				obj.nearestObstacle = nearestObstacle;
				obj.leadingVehicle = leadingVehicle;
				obj.distanceToLeadingVehicle = distanceToLeadingVehicle;
				obj.blockingLane = blockingLane;
				obj.distanceToBlockingLane = distanceToBlockingLane;
				return true;
			}

			public void Reset()
			{
				lane = null;
				distanceAlongLane = Fix64.Zero;
				speed = Fix64.Zero;
				acceleration = Fix64.Zero;
				nearestObstacle = ObstacleType.None;
				leadingVehicle = null;
				distanceToLeadingVehicle = Fix64.MaxValue;
				blockingLane = null;
				distanceToBlockingLane = Fix64.MaxValue;
			}
		}

		public interface IObserver
		{
			void OnVehicleMovedToNewLane(LaneModel newLane, LaneModel oldLane);

			void OnVehicleEnteredCarpark(VehicleModel vehicle, DestinationModel destination);

			void OnVehicleArrivedAtDestination(VehicleModel vehicle, DestinationModel destination);

			void OnVehicleDepartedDestination(VehicleModel vehicle, DestinationModel fromDestination);

			void OnVehicleArrivedAtHouse(VehicleModel vehicle);

			void OnVehicleDepartedHouse(VehicleModel vehicle, DestinationModel toDestination);

			void OnRemoved();
		}

		[Dependency]
		private Simulation _simulation;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private SimulationConstantsData _constants;

		[Serialize(false, null)]
		public int id = -1;

		private static int NextId = 1;

		public const int NumberOfLanesToCommitTo = 2;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("VehicleModel");

		public int latestAttemptedPathfindFrame;

		public HouseModel house;

		public DestinationModel destination;

		public DestinationModel lastVisitedDestination;

		public BehaviorState behaviorState;

		public BehaviorState lastNotifiedBehaviorState;

		public readonly List<LaneModel> path = new List<LaneModel>();

		public PathfindUrgency repathUrgency;

		public Fix64 targetDistanceAlongLastLane;

		public Fix64 pathLength;

		public Fix64 pathLengthAtStartOfJourney;

		public bool isShovingIntoNextIntersection;

		public VehicleModel vehiclePushingInto;

		[Serialize(false, null)]
		public VehicleModel blockingVehicle;

		[Serialize(false, null)]
		public int frameBlockingChainLastChecked;

		private Fix64 _timeWhenArrivedAtHouse;

		public readonly List<LaneModel> returnPath = new List<LaneModel>();

		public PathfindUrgency returnRepathUrgency;

		private static readonly ProfilerMarker Profiler_AssignPath = new ProfilerMarker(ProfilerUtility.CategoryModel, "VehicleModel.AssignPath");

		private static readonly ProfilerMarker Profiler_AssignReturnPath = new ProfilerMarker(ProfilerUtility.CategoryModel, "VehicleModel.AssignReturnPath");

		private static readonly ProfilerMarker Profiler_DistanceToLane = new ProfilerMarker(ProfilerUtility.CategoryModel, "VehicleModel.DistanceToLane");

		private static readonly ProfilerMarker Profiler_ClearNonCommittedLanes = new ProfilerMarker(ProfilerUtility.CategoryModel, "VehicleModel.ClearNonCommittedLanes");

		private static readonly ProfilerMarker Profiler_ClearReturnPath = new ProfilerMarker(ProfilerUtility.CategoryModel, "VehicleModel.ClearReturnPath");

		public bool IsParkedAtDestination => behaviorState == BehaviorState.ParkedAtDestination;

		public bool IsWaitingAtHouse => behaviorState == BehaviorState.WaitingForDestination;

		public bool IsRealigningOnDriveway => behaviorState == BehaviorState.RealigningDriveway;

		public bool IsAvailableAtHouse
		{
			get
			{
				if (behaviorState == BehaviorState.WaitingForDestination)
				{
					return _clock.Time - _timeWhenArrivedAtHouse > _constants.TimeAtHouseBeforeCarIsAvailable;
				}
				return false;
			}
		}

		public bool IsDrivingToDestination => behaviorState == BehaviorState.DrivingToDestination;

		public LaneModel LastCommittedLane
		{
			get
			{
				if (path.Count > 0)
				{
					return path[Math.Min(1, path.Count - 1)];
				}
				return base.CurrentFrame.lane;
			}
		}

		public void Remove()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnRemoved();
			}
			if (destination != null)
			{
				destination.unassignedDemand.Add(destination.waitingDemand[0]);
				destination.waitingDemand.RemoveAt(0);
				destination.Carpark.vehiclesEntering.Remove(this);
			}
			if (lastVisitedDestination != null)
			{
				foreach (CarparkModel.ParkingSpace space in lastVisitedDestination.Carpark.spaces)
				{
					if (space.vehicle == this)
					{
						space.vehicle = null;
					}
				}
				lastVisitedDestination.Carpark.vehiclesDrivingThrough.Remove(this);
			}
			ClearReturnPath();
			ClearLeadingVehicles();
			ClearForwardPath();
			foreach (LaneModel item in returnPath)
			{
				item.roadChunk.RemoveInboundVehicle(this, item);
				item.RemoveVehicle(this);
			}
			_simulation.RemoveModel(this);
		}

		public void MoveToLane(LaneModel newLane, Fix64 distanceAlongNewLane)
		{
			base.CurrentFrame.lane?.RemoveVehicle(this);
			base.CurrentFrame.lane = newLane;
			base.NextFrame.lane = newLane;
			base.CurrentFrame.distanceAlongLane = distanceAlongNewLane;
			base.NextFrame.distanceAlongLane = distanceAlongNewLane;
			targetDistanceAlongLastLane = distanceAlongNewLane;
			newLane.AddVehicle(this);
			OnMovedToNewLane(newLane, null);
		}

		public void OnCreatedInScope(IScope scope)
		{
			id = NextId;
			NextId++;
		}

		public void OnMovedToNewLane(LaneModel newLane, LaneModel oldLane)
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnVehicleMovedToNewLane(newLane, oldLane);
			}
		}

		public void ResetToHouse()
		{
			ClearReturnPath();
			ClearForwardPath();
			ClearLeadingVehicles();
			repathUrgency = PathfindUrgency.NotRequired;
			returnRepathUrgency = PathfindUrgency.NotRequired;
			base.NextFrame.lane = house.DrivewayLane;
			base.CurrentFrame.lane = house.DrivewayLane;
			house.DrivewayLane.AddVehicle(this);
			house.waitingVehicles.Add(this);
			Fix64 distanceAlongLane = ((house.waitingVehicles.Count == 0) ? house.GetLaneDistanceAtFrontOfDriveway(house.DrivewayLane) : house.GetLaneDistanceAtBackOfDriveway(house.DrivewayLane));
			base.NextFrame.distanceAlongLane = distanceAlongLane;
			base.CurrentFrame.distanceAlongLane = distanceAlongLane;
			if (destination != null && (behaviorState == BehaviorState.DrivingToDestination || behaviorState == BehaviorState.ParkingAtDestination))
			{
				destination.RemoveVehicleAssignment();
			}
			if (destination != null)
			{
				foreach (CarparkModel.ParkingSpace space in destination.Carpark.spaces)
				{
					if (space.vehicle == this)
					{
						space.vehicle = null;
					}
				}
				destination.Carpark.vehiclesDrivingThrough.Remove(this);
			}
			destination = null;
			lastVisitedDestination = null;
			behaviorState = BehaviorState.WaitingForDestination;
		}

		public void AssignPath(IReadOnlyList<LaneModel> newPath, Fix64 newTargetDistanceAlongLastLane)
		{
			Log.Info("Assigning new path of length {0} to vehicle {1}", newPath.Count, this);
			int count = newPath.Count;
			int count2 = path.Count;
			int i;
			for (i = 0; i < count && i + 2 < count2 && newPath[i] == path[i + 2]; i++)
			{
			}
			if (i >= count && count2 == count + 2)
			{
				return;
			}
			int num = count2 - (i + 2);
			if (num > 0)
			{
				for (int j = i + 2; j < count2; j++)
				{
					LaneModel laneModel = path[j];
					pathLength -= laneModel.Length;
					laneModel.roadChunk.RemoveInboundVehicle(this, laneModel);
				}
				pathLength += path[count2 - 1].Length - targetDistanceAlongLastLane;
				path.RemoveRange(i + 2, num);
			}
			else if (count2 > 0)
			{
				pathLength += path[count2 - 1].Length - targetDistanceAlongLastLane;
			}
			else
			{
				pathLength = base.CurrentFrame.lane.Length - base.CurrentFrame.distanceAlongLane;
			}
			for (int k = i; k < newPath.Count; k++)
			{
				LaneModel laneModel2 = newPath[k];
				path.Add(laneModel2);
				laneModel2.roadChunk.AddInboundVehicle(this, laneModel2, path.Count);
				pathLength += laneModel2.Length;
			}
			if (newTargetDistanceAlongLastLane < Fix64.Zero)
			{
				targetDistanceAlongLastLane = ((path.Count > 0) ? path[path.Count - 1].Length : Fix64.Zero);
			}
			else
			{
				targetDistanceAlongLastLane = newTargetDistanceAlongLastLane;
				if (path.Count > 0)
				{
					pathLength -= path[path.Count - 1].Length - newTargetDistanceAlongLastLane;
				}
			}
			if (behaviorState == BehaviorState.DrivingHome)
			{
				ClearReturnPath();
			}
			repathUrgency = PathfindUrgency.NotRequired;
			latestAttemptedPathfindFrame = 0;
		}

		public void AssignReturnPath(IReadOnlyList<LaneModel> newReturnPath)
		{
			int count = newReturnPath.Count;
			int count2 = returnPath.Count;
			int i;
			for (i = 0; i < count && i < count2 && newReturnPath[i] == returnPath[i]; i++)
			{
			}
			if (i >= count && count == count2)
			{
				return;
			}
			int num = count2 - i;
			if (num > 0)
			{
				for (int j = i; j < count2; j++)
				{
					LaneModel lane = returnPath[j];
					returnPath[j].roadChunk.RemoveInboundVehicle(this, lane, returningVehicle: true);
				}
				returnPath.RemoveRange(i, num);
			}
			for (int k = i; k < count; k++)
			{
				LaneModel laneModel = newReturnPath[k];
				if (Diagnostics.Verify(laneModel.roadChunk != null, "Tried to add a return lane with no road chunk; might be a carpark. ({0})", laneModel))
				{
					laneModel.roadChunk.AddInboundVehicle(this, laneModel, 0, returningInboundVehicle: true);
					returnPath.Add(laneModel);
				}
			}
			returnRepathUrgency = PathfindUrgency.NotRequired;
		}

		public void RequestPathfind(PathfindUrgency urgency = PathfindUrgency.WhenPossible)
		{
			if (urgency > repathUrgency)
			{
				repathUrgency = urgency;
			}
		}

		public void RequestReturnPathfind(PathfindUrgency urgency = PathfindUrgency.WhenPossible)
		{
			if (urgency > returnRepathUrgency)
			{
				returnRepathUrgency = urgency;
			}
		}

		public void NotifyBehaviorChange()
		{
			if (lastNotifiedBehaviorState == behaviorState || path.Count <= 0)
			{
				return;
			}
			lastNotifiedBehaviorState = behaviorState;
			if (behaviorState == BehaviorState.DrivingToDestination)
			{
				ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnVehicleDepartedHouse(this, destination);
				}
			}
			else if (behaviorState == BehaviorState.DrivingHome)
			{
				ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnVehicleDepartedDestination(this, lastVisitedDestination);
				}
			}
		}

		public void OnArrivedAtHouse()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnVehicleArrivedAtHouse(this);
			}
			_timeWhenArrivedAtHouse = _clock.Time;
		}

		public void OnArrivedAtDestination()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnVehicleArrivedAtDestination(this, destination);
			}
			if (Diagnostics.Verify(destination != null, "Vehicle arrived at null destination."))
			{
				destination.AcceptVehicleArrival(this);
				lastVisitedDestination = destination;
				destination = null;
			}
		}

		public void OnEnteredCarpark()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnVehicleEnteredCarpark(this, destination);
			}
			lastVisitedDestination = destination;
		}

		public void OnDepartedHouse()
		{
			lastVisitedDestination = null;
		}

		public void OnDepartedDestination()
		{
		}

		public Fix64 DistanceToLane(LaneModel laneOnPath)
		{
			return DistanceToLane(laneOnPath, Fix64.Zero);
		}

		public Fix64 DistanceToLane(LaneModel laneOnPath, Fix64 distanceAlongLane)
		{
			if (base.CurrentFrame.lane == laneOnPath && distanceAlongLane >= base.CurrentFrame.distanceAlongLane)
			{
				return distanceAlongLane - base.CurrentFrame.distanceAlongLane;
			}
			Fix64 fix = base.CurrentFrame.lane.Length - base.CurrentFrame.distanceAlongLane;
			for (int i = 0; i < path.Count; i++)
			{
				if (path[i] == laneOnPath)
				{
					return fix + distanceAlongLane;
				}
				fix += path[i].Length;
			}
			return -Fix64.One;
		}

		public bool IsCommittedToLane(LaneModel lane)
		{
			int num = Math.Min(path.Count, 2);
			for (int i = 0; i < num; i++)
			{
				if (lane == path[i])
				{
					return true;
				}
			}
			return false;
		}

		public void ClearNonCommittedLanes()
		{
			if (path.Count > 2)
			{
				for (int num = path.Count - 1; num >= 2; num--)
				{
					path[num].roadChunk.RemoveInboundVehicle(this, path[num]);
					path.RemoveAt(num);
				}
			}
		}

		public override void Reset()
		{
			base.Reset();
			id = -1;
			house = null;
			destination = null;
			lastVisitedDestination = null;
			behaviorState = BehaviorState.WaitingForDestination;
			lastNotifiedBehaviorState = BehaviorState.WaitingForDestination;
			latestAttemptedPathfindFrame = 0;
			path.Clear();
			repathUrgency = PathfindUrgency.NotRequired;
			returnPath.Clear();
			returnRepathUrgency = PathfindUrgency.NotRequired;
			targetDistanceAlongLastLane = Fix64.Zero;
			pathLength = Fix64.Zero;
			pathLengthAtStartOfJourney = Fix64.Zero;
			_timeWhenArrivedAtHouse = Fix64.Zero;
			isShovingIntoNextIntersection = false;
			vehiclePushingInto = null;
			blockingVehicle = null;
			frameBlockingChainLastChecked = 0;
		}

		public override string ToString()
		{
			return $"[Vehicle Id={id}, BehaviorState={behaviorState}]";
		}

		public void ClearReturnPath()
		{
			foreach (LaneModel item in returnPath)
			{
				if (Diagnostics.Verify(item.roadChunk != null, "Tried to remove ourselves from a return lane with no road chunk. ({0})", item))
				{
					item.roadChunk.RemoveInboundVehicle(this, item, returningVehicle: true);
				}
			}
			returnPath.Clear();
		}

		private void ClearForwardPath()
		{
			foreach (LaneModel item in path)
			{
				item.roadChunk.RemoveInboundVehicle(this, item);
				item.RemoveVehicle(this);
			}
			base.CurrentFrame.lane.RemoveVehicle(this);
			path.Clear();
			foreach (LaneModel outboundLane in base.CurrentFrame.lane.OutboundLanes)
			{
				if (outboundLane.Vehicles.Contains(this))
				{
					outboundLane.RemoveVehicle(this);
				}
			}
		}

		private void ClearLeadingVehicles()
		{
			ModelListEnumerator<VehicleModel> enumerator = _simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				VehicleModel current = enumerator.Current;
				if (current.blockingVehicle == this)
				{
					current.blockingVehicle = null;
					current.CurrentFrame.nearestObstacle = ObstacleType.None;
					current.CurrentFrame.leadingVehicle = null;
					current.NextFrame.nearestObstacle = ObstacleType.None;
					current.NextFrame.leadingVehicle = null;
				}
			}
			blockingVehicle = null;
			base.CurrentFrame.nearestObstacle = ObstacleType.None;
			base.NextFrame.nearestObstacle = ObstacleType.None;
			base.CurrentFrame.leadingVehicle = null;
			base.NextFrame.leadingVehicle = null;
		}

		public VehicleModel()
			: base(1)
		{
		}
	}
}
