using System;
using PajamaLlama.Flotsam.World;

public class MapEvent : GameEvent
{
	private static MapEvent _instance;

	private bool _isBeingDispatched;

	public MapPath.State State { get; private set; }

	public IWorldMapCompassBearingTarget BearingTarget { get; private set; }

	public WorldTile WorldTile { get; private set; }

	public IWorldRegion Region { get; private set; }

	public PointOfInterestSpawner PointOfInterestSpawner { get; private set; }

	private MapEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void DispatchMapPathStateUpdated(MapPath.State state)
	{
		MapEvent mapEvent = ReturnInstance(GameEventType.MapPathStateUpdated);
		mapEvent.State = state;
		mapEvent.Dispatch();
	}

	public static void DispatchCompassBearingTargetEvent(IWorldMapCompassBearingTarget sender)
	{
		MapEvent mapEvent = ReturnInstance(GameEventType.CompassBearingTargetUpdate);
		mapEvent.BearingTarget = sender;
		mapEvent.Dispatch();
	}

	public static void DispatchDeactivateCompassBearingTarget(IWorldMapCompassBearingTarget sender)
	{
		MapEvent mapEvent = ReturnInstance(GameEventType.DeactivateCompassBearingTarget);
		mapEvent.BearingTarget = sender;
		mapEvent.Dispatch();
	}

	public static void DispatchWorldTiledAddedEvent(WorldTile worldTile)
	{
		MapEvent mapEvent = ReturnInstance(GameEventType.WorldTileAdded);
		mapEvent.WorldTile = worldTile;
		mapEvent.Dispatch();
	}

	public static void DispatchWorldTileRemovedEvent(WorldTile worldTile)
	{
		MapEvent mapEvent = ReturnInstance(GameEventType.WorldTileRemoved);
		mapEvent.WorldTile = worldTile;
		mapEvent.Dispatch();
	}

	public static void DispatchRegionEntered(IWorldRegion region)
	{
		MapEvent mapEvent = ReturnInstance(region.Flags.HasFlag(WorldRegionFlags.Visited) ? GameEventType.RegionReentered : GameEventType.RegionEntered);
		mapEvent.Region = region;
		mapEvent.Dispatch();
	}

	public static void DispatchPointOfInterestSpawned(WorldTile worldTile, PointOfInterestSpawner pointOfInterestSpawner)
	{
		MapEvent mapEvent = ReturnInstance(GameEventType.PointOfInterestSpawned);
		mapEvent.WorldTile = worldTile;
		mapEvent.PointOfInterestSpawner = pointOfInterestSpawner;
		mapEvent.Dispatch();
	}

	private static MapEvent ReturnInstance(GameEventType eventType)
	{
		if (_instance == null)
		{
			_instance = new MapEvent(eventType);
		}
		else
		{
			if (_instance._isBeingDispatched)
			{
				throw new NotSupportedException();
			}
			_instance.EventType = eventType;
		}
		return _instance;
	}
}
