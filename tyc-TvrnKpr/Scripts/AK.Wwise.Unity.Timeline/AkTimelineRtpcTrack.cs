using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.32f, 0.13f, 0.13f)]
[TrackClipType(typeof(AkTimelineRtpcPlayable))]
[TrackBindingType(typeof(GameObject))]
public class AkTimelineRtpcTrack : TrackAsset
{
	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject gameObject, int inputCount)
	{
		return default(Playable);
	}

	public void OnValidate()
	{
	}
}
