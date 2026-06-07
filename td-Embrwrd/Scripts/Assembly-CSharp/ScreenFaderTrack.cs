using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[TrackClipType(typeof(ScreenFaderClip))]
[TrackColor(0.875f, 0.5944853f, 0.1737132f)]
[TrackBindingType(typeof(Image))]
public class ScreenFaderTrack : TrackAsset
{
	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
	{
		return default(Playable);
	}

	public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
	{
	}
}
