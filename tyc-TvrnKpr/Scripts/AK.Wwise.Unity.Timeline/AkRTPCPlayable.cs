using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
public class AkRTPCPlayable : PlayableAsset, ITimelineClipAsset
{
	public bool overrideTrackObject;

	public ExposedReference<GameObject> RTPCObject;

	public bool setRTPCGlobally;

	public AkRTPCPlayableBehaviour template;

	public RTPC Parameter { get; set; }

	public TimelineClip OwningClip { get; set; }

	ClipCaps ITimelineClipAsset.clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
	{
		return default(Playable);
	}
}
