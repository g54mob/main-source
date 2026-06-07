using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimeDilationClip : PlayableAsset, ITimelineClipAsset
{
	public TimeDilationBehaviour template;

	public ClipCaps clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		return default(Playable);
	}
}
