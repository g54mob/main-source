using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;
using TMPEffects.TMPAnimations;
using UnityEngine.Playables;

namespace TMPEffects.Timeline
{
	public class TMPMeshModifierTrackMixer : PlayableBehaviour
	{
		private List<ScriptPlayable<TMPMeshModifierBehaviour>> active;

		private TMPAnimator animator;

		private bool needsReset;

		private CharDataModifiers modifiersStorage;

		private CharDataModifiers modifiersStorage2;

		private CharDataModifiers accModifier;

		private CharDataModifiers current;

		private float time;

		private Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset inOffset, GenericAnimationUtility.CachedOffset outOffset)> cachedOffsets;

		private ITMPSegmentData mocked;

		public override void OnBehaviourPause(Playable playable, FrameData info)
		{
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
		}

		private void OnAnimatedCallback(CharData cData)
		{
		}

		private void UpdateSegmentData(bool _ = false)
		{
		}
	}
}
