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

		public ClipCaps clipCaps => ClipCaps.Extrapolation;

		public TimelineAnimationStep Step => step;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<TMPMeshModifierBehaviour> scriptPlayable = ScriptPlayable<TMPMeshModifierBehaviour>.Create(graph);
			TMPMeshModifierBehaviour behaviour = scriptPlayable.GetBehaviour();
			scriptPlayable.GetDuration();
			behaviour.Step = step;
			behaviour.Clip = Clip;
			PlayableDirector value = (PlayableDirector)graph.GetResolver();
			scriptPlayable.GetGraph().GetResolver().SetReferenceValue(director.exposedName, value);
			return scriptPlayable;
		}
	}
}
