using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class AkTimelineEventPlayable : PlayableAsset, ITimelineClipAsset
{
	public Event akEvent;

	[SerializeField]
	private AkCurveInterpolation blendInCurve;

	[SerializeField]
	private AkCurveInterpolation blendOutCurve;

	public float eventDurationMax;

	public float eventDurationMin;

	[NonSerialized]
	public TimelineClip owningClip;

	[SerializeField]
	private bool retriggerEvent;

	public bool UseWwiseEventDuration;

	public bool PrintDebugInformation;

	[SerializeField]
	private bool StopEventAtClipEnd;

	ClipCaps ITimelineClipAsset.clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		return default(Playable);
	}
}
