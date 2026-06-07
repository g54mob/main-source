using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TransformTweenClip : PlayableAsset, ITimelineClipAsset
{
	public TransformTweenBehaviour template;

	public ExposedReference<Transform> startLocation;

	public ExposedReference<Transform> endLocation;

	public ClipCaps clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		return default(Playable);
	}
}
