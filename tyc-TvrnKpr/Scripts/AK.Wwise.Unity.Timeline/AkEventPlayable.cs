using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
public class AkEventPlayable : PlayableAsset, ITimelineClipAsset
{
	public Event akEvent;

	[SerializeField]
	private AkCurveInterpolation blendInCurve;

	[SerializeField]
	private AkCurveInterpolation blendOutCurve;

	[SerializeField]
	private ExposedReference<GameObject> emitterObjectRef;

	public float eventDurationMax;

	public float eventDurationMin;

	[NonSerialized]
	public TimelineClip owningClip;

	[SerializeField]
	private bool retriggerEvent;

	public bool UseWwiseEventDuration;

	[SerializeField]
	private bool StopEventAtClipEnd;

	ClipCaps ITimelineClipAsset.clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		return default(Playable);
	}
}
