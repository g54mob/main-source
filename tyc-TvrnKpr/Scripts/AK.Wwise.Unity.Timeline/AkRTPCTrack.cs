using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.32f, 0.13f, 0.13f)]
[TrackClipType(typeof(AkRTPCPlayable))]
[TrackBindingType(typeof(GameObject))]
[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
[HideInMenu]
public class AkRTPCTrack : TrackAsset
{
	public RTPC Parameter;

	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
	{
		return default(Playable);
	}

	public void setPlayableProperties()
	{
	}

	public void OnValidate()
	{
	}
}
