using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class NavMeshAgentControlClip : PlayableAsset, ITimelineClipAsset
{
	public ExposedReference<Transform> destination;

	[HideInInspector]
	public NavMeshAgentControlBehaviour template;

	public ClipCaps clipCaps => default(ClipCaps);

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		return default(Playable);
	}
}
