using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(AkTimelineEventPlayable))]
[TrackBindingType(typeof(GameObject))]
public class AkTimelineEventTrack : TrackAsset
{
	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
	{
		return default(Playable);
	}

	public List<WwiseEventReference> GetEventReferences()
	{
		return null;
	}
}
