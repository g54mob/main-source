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

		public ITMPAnimation Animation => animation as ITMPAnimation;

		public ClipCaps clipCaps => ClipCaps.Extrapolation;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<TMPAnimationBehaviour> scriptPlayable = ScriptPlayable<TMPAnimationBehaviour>.Create(graph);
			TMPAnimationBehaviour behaviour = scriptPlayable.GetBehaviour();
			behaviour.Clip = Clip;
			behaviour.animation = Animation;
			behaviour.entryCurve = entryCurve;
			behaviour.exitCurve = exitCurve;
			behaviour.entryDuration = entryDuration;
			behaviour.exitDuration = exitDuration;
			return scriptPlayable;
		}

		private void OnValidate()
		{
			if (animation != null && !(animation is ITMPAnimation))
			{
				animation = null;
			}
		}
	}
}
