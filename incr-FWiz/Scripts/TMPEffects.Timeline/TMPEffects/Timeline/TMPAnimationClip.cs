using System;
using System.ComponentModel;
using TMPEffects.Parameters;
using TMPEffects.TMPAnimations;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline
{
	[DisplayName("TMPEffects Clip/TMPAnimation Clip")]
	public class TMPAnimationClip : TMPEffectsClip, ITimelineClipAsset
	{
		public UnityEngine.Object animation;

		[NonSerialized]
		public TimelineClip Clip;

		[HideInInspector]
		public TMPBlendCurve entryCurve;

		public float entryDuration;

		[HideInInspector]
		public TMPBlendCurve exitCurve;

		public float exitDuration;

		public ITMPAnimation Animation => null;

		public ClipCaps clipCaps => default(ClipCaps);

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return default(Playable);
		}

		private void OnValidate()
		{
		}
	}
}
