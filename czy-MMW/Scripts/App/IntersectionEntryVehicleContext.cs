using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;

[Serializable(1)]
public class IntersectionEntryVehicleContext : IReusable
{
	private VehicleModel _vehicle;

	private LaneModel _lane;

	private Fix64 _speed;

	private Fix64 _distanceAlongLane;

	private IntersectionEntryVehicleInfluence _influence;

	public VehicleModel Vehicle => _vehicle;

	public Fix64 Speed => _speed;

	public LaneModel Lane => _lane;

	public Fix64 DistanceAlongLane => _distanceAlongLane;

	public IntersectionEntryVehicleInfluence Influence
	{
		get
		{
			return _influence;
		}
		set
		{
			_influence = value;
		}
	}

	public bool WasBlocking
	{
		get
		{
			if (_influence != IntersectionEntryVehicleInfluence.OnIntersectingLane && _influence != IntersectionEntryVehicleInfluence.SameExitNoSpace)
			{
				return _influence == IntersectionEntryVehicleInfluence.ReservedIntersectingLane;
			}
			return true;
		}
	}

	public void Initialize(VehicleModel vehicle)
	{
		_vehicle = vehicle;
		_lane = _vehicle.CurrentFrame.lane;
		_speed = _vehicle.CurrentFrame.speed;
		_distanceAlongLane = _vehicle.CurrentFrame.distanceAlongLane;
		_influence = IntersectionEntryVehicleInfluence.Unknown;
	}

	public void Reset()
	{
		_vehicle = null;
		_lane = null;
		_speed = default(Fix64);
		_distanceAlongLane = default(Fix64);
		_influence = IntersectionEntryVehicleInfluence.Unknown;
	}
}
