using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;
using TMPEffects.Parameters;
using TMPEffects.TMPAnimations;
using UnityEngine.Playables;

namespace TMPEffects.Timeline
{
	public class TMPAnimatorTrackMixer : PlayableBehaviour
	{
		private class MockedAnimationContext : IAnimationContext, IAnimationData, IAnimationFinished, IAnimationFinisher
		{
			private Dictionary<int, bool> finishedDict;

			public IAnimatorContext AnimatorContext { get; set; }

			public SegmentData SegmentData { get; set; }

			public object CustomData { get; set; }

			public bool Finished(int index)
			{
				return false;
			}

			public bool Finished(CharData cData)
			{
				return false;
			}

			public void FinishAnimation(CharData cData)
			{
			}

			public MockedAnimationContext(IAnimatorContext context, object customData)
			{
			}

			private void UpdateSegmentData()
			{
			}
		}

		private List<ScriptPlayable<TMPAnimationBehaviour>> active;

		private TMPAnimator animator;

		private bool needsReset;

		private CharDataModifiers modifiersStorage;

		private CharDataModifiers modifiersStorage2;

		private CharDataModifiers accModifier;

		private CharDataModifiers current;

		private TMPCharacterModifiers result;

		private TMPMeshModifiers resultMesh;

		private float time;

		private MockedAnimationContext mocked;

		private ITMPAnimation lastActive;

		public override void OnBehaviourPause(Playable playable, FrameData info)
		{
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
		}

		private void OnAnimatedCallback(CharData cdata)
		{
		}

		private void UpdateContext(bool _ = false)
		{
		}

		public static float CalcWeight(float entryDuration, float exitDuration, TMPBlendCurve inCurve, TMPBlendCurve outCurve, float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData)
		{
			return 0f;
		}
	}
}
