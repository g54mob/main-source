using System.Collections.Generic;

public static class RailTrackOnTrackBogiesExtensions
{
	public static HashSet<Bogie> BogiesOnTrack(this RailTrack rt)
	{
		if (!rt.TryGetComponent<RailTrackBogiesOnTrack>(out var component))
		{
			component = rt.gameObject.AddComponent<RailTrackBogiesOnTrack>();
		}
		return component.bogiesOnTrack;
	}
}
