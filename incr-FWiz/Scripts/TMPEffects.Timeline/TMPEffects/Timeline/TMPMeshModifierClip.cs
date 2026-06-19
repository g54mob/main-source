using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline
{
	[DisplayName("TMPEffects Clip/TMPMeshModifier Clip")]
	public class TMPMeshModifierClip : TMPEffectsClip, ITimelineClipAsset
	{
		[NonSerialized]
		public TimelineClip Clip;

		private ExposedReference<PlayableDirector> director;

		[SerializeField]
		private TimelineAnimationStep step;

		public ClipCaps clipCaps => default(ClipCaps);

		public TimelineAnimationStep Step => null;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return default(Playable);
		}
	}
}
