using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UMA.Timeline
{
	[Serializable]
	public class UmaWardrobeClip : PlayableAsset, ITimelineClipAsset
	{
		public UmaWardrobeBehaviour template;

		public ClipCaps clipCaps => default(ClipCaps);

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return default(Playable);
		}
	}
}
