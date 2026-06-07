namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces
{
	public interface IManeuverNodeEventsProvider
	{
		event ManeuverNodeScript.ManeuverNodeAdjustmentChangeDelegate ManeuverNodeAdjustmentChangeBeginEvent;

		event ManeuverNodeScript.ManeuverNodeAdjustmentChangeDelegate ManeuverNodeAdjustmentChangeEndEvent;

		event ManeuverNodeScript.ManeuverNodeAdjustmentChangeDelegate ManeuverNodeAdjustmentChangingEvent;
	}
}
