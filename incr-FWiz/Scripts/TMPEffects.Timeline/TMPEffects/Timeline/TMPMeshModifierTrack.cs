using System.ComponentModel;
using TMPEffects.Components;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline
{
	[TrackBindingType(typeof(TMPAnimator))]
	[TrackClipType(typeof(TMPMeshModifierClip))]
	[DisplayName("TMPEffects/TMPMeshModifier Track")]
	public class TMPMeshModifierTrack : TMPEffectsTrack
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return default(Playable);
		}
	}
}
