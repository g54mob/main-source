using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ScreenFaderClip : PlayableAsset, ITimelineClipAsset
{
	public ScreenFaderBehaviour template;

	public ClipCaps clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		return default(Playable);
	}
}
