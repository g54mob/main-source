using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using JetBrains.Annotations;
using Motorways.Models;
using Server;

[Serializable(1)]
public class IntersectionEntryDecision : IReusable, IReleasedFromScopeHandler
{
	private int _id = -1;

	private int _earliestFrameCount;

	private int _latestFrameCount;

	private RoadChunkModel _intersection;

	private LaneModel _targetLane;

	private VehicleModel _vehicle;

	private LaneModel _currentLane;

	private Fix64 _distanceAlongCurrentLane;

	private Fix64 _waitTime;

	private readonly List<IntersectionEntryVehicleContext> _vehicleContexts = new List<IntersectionEntryVehicleContext>();

	private IntersectionEntryVerdict _verdict;

	[Dependency]
	private IScope _scope;

	[Dependency]
	private Clock _clock;

	public int Id => _id;

	[CanBeNull]
	public VehicleModel FirstBlockingVehicle
	{
		get
		{
			foreach (IntersectionEntryVehicleContext vehicleContext in _vehicleContexts)
			{
				if (vehicleContext.WasBlocking)
				{
					return vehicleContext.Vehicle;
				}
			}
			return null;
		}
	}

	[ItemNotNull]
	[NotNull]
	public List<VehicleModel> BlockingVehicles
	{
		get
		{
			List<VehicleModel> list = new List<VehicleModel>();
			foreach (IntersectionEntryVehicleContext vehicleContext in _vehicleContexts)
			{
				if (vehicleContext.WasBlocking)
				{
					list.Add(vehicleContext.Vehicle);
				}
			}
			return list;
		}
	}

	public int EarliestFrameCount => _earliestFrameCount;

	public int LatestFrameCount => _latestFrameCount;

	public IntersectionEntryVerdict Verdict => _verdict;

	public bool WasEntryApproved
	{
		get
		{
			if (_verdict != IntersectionEntryVerdict.NoIntersectingLanes && _verdict != IntersectionEntryVerdict.Shoved && _verdict != IntersectionEntryVerdict.NoBlockingVehicles)
			{
				return _verdict == IntersectionEntryVerdict.ExceededMaximumWaitTime;
			}
			return true;
		}
	}

	public VehicleModel QueryingVehicle => _vehicle;

	public LaneModel CurrentLane => _currentLane;

	public Fix64 DistanceAlongCurrentLane => _distanceAlongCurrentLane;

	public LaneModel TargetLane => _targetLane;

	public Fix64 WaitTime => _waitTime;

	public IReadOnlyList<IntersectionEntryVehicleContext> OtherVehicleContexts => _vehicleContexts;

	public void Initialize(RoadChunkModel.InboundVehicle inboundVehicle)
	{
		_earliestFrameCount = _clock.FrameCount;
		_latestFrameCount = _clock.FrameCount;
		_vehicle = inboundVehicle.vehicle;
		_currentLane = inboundVehicle.vehicle.CurrentFrame.lane;
		_distanceAlongCurrentLane = inboundVehicle.vehicle.CurrentFrame.distanceAlongLane;
		_targetLane = inboundVehicle.chosenLane;
		_intersection = _targetLane.roadChunk;
		_waitTime = _clock.Time - inboundVehicle.committedTimestamp;
		_verdict = IntersectionEntryVerdict.Unknown;
		foreach (VehicleModel traversingVehicle in _intersection.traversingVehicles)
		{
			IntersectionEntryVehicleContext intersectionEntryVehicleContext = _scope.Get<IntersectionEntryVehicleContext>();
			intersectionEntryVehicleContext.Initialize(traversingVehicle);
			_vehicleContexts.Add(intersectionEntryVehicleContext);
		}
	}

	public void SetId(int id)
	{
		_id = id;
	}

	public bool IsRepeatOfEarlierDecision(IntersectionEntryDecision earlierDecision)
	{
		if (_intersection == earlierDecision._intersection && _vehicle == earlierDecision._vehicle && _verdict == earlierDecision._verdict)
		{
			return FirstBlockingVehicle == earlierDecision.FirstBlockingVehicle;
		}
		return false;
	}

	public void ExtendDuration(int newEndFrameCount)
	{
		_latestFrameCount = newEndFrameCount;
	}

	public void SetVerdict(IntersectionEntryVerdict value)
	{
		_verdict = value;
	}

	public void RemoveCurrentLane()
	{
		_currentLane = null;
	}

	public void RemoveTargetLane()
	{
		_targetLane = null;
	}

	public void SetTraversingVehicleInfluence(VehicleModel vehicle, IntersectionEntryVehicleInfluence influence)
	{
		foreach (IntersectionEntryVehicleContext vehicleContext in _vehicleContexts)
		{
			if (vehicleContext.Vehicle == vehicle)
			{
				vehicleContext.Influence = influence;
				return;
			}
		}
		Diagnostics.FailAssert($"{vehicle} is not part of an intersection that it is having an influence on.");
	}

	public void SetInboundVehicleInfluence(RoadChunkModel.InboundVehicle inboundVehicle, IntersectionEntryVehicleInfluence influence)
	{
		IntersectionEntryVehicleContext intersectionEntryVehicleContext = _scope.Get<IntersectionEntryVehicleContext>();
		intersectionEntryVehicleContext.Initialize(inboundVehicle.vehicle);
		intersectionEntryVehicleContext.Influence = influence;
		_vehicleContexts.Add(intersectionEntryVehicleContext);
	}

	public void Reset()
	{
		_id = -1;
		_earliestFrameCount = 0;
		_latestFrameCount = 0;
		_intersection = null;
		_targetLane = null;
		_vehicle = null;
		_currentLane = null;
		_distanceAlongCurrentLane = default(Fix64);
		_waitTime = default(Fix64);
		_vehicleContexts.Clear();
		_verdict = IntersectionEntryVerdict.Unknown;
	}

	public void OnReleasedFromScope(IScope scope)
	{
		foreach (IntersectionEntryVehicleContext vehicleContext in _vehicleContexts)
		{
			scope.Release(vehicleContext);
		}
		_vehicleContexts.Clear();
	}
}
