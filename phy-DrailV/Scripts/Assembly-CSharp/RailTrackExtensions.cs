using DV.Logic.Job;
using DV.Utils;

public static class RailTrackExtensions
{
	public static RailTrack RailTrack(this Track logicTrack)
	{
		if (RailTrackRegistry.LogicToRailTrack.TryGetValue(logicTrack, out var value))
		{
			return value;
		}
		return null;
	}

	public static Track LogicTrack(this RailTrack railTrack)
	{
		_ = (RailTrackRegistry)SingletonBehaviour<RailTrackRegistryBase>.Instance;
		if (RailTrackRegistry.RailTrackToLogicTrack.TryGetValue(railTrack, out var value))
		{
			return value;
		}
		return null;
	}
}
