using System.ComponentModel;
using TMPEffects.Components;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline
{
	[TrackBindingType(typeof(TMPAnimator))]
	[TrackClipType(typeof(TMPAnimationClip))]
	[DisplayName("TMPEffects/TMPAnimatorTrack")]
	public class TMPAnimatorTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			foreach (TimelineClip clip in GetClips())
			{
				(clip.asset as TMPAnimationClip).Clip = clip;
			}
			return ScriptPlayable<TMPAnimatorTrackMixer>.Create(graph, inputCount);
		}
	}
}
