using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tantawowa.TimelineEvents
{
	[Serializable]
	public class TimelineEventClip : PlayableAsset, ITimelineClipAsset
	{
		public TimelineEventBehaviour template;

		public GameObject TrackTargetObject { get; set; }

		public ClipCaps clipCaps => default(ClipCaps);

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return default(Playable);
		}
	}
}
