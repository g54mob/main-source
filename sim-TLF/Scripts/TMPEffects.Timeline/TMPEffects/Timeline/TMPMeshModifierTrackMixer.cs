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

		private Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset inOffset, GenericAnimationUtility.CachedOffset outOffset)> cachedOffsets = new Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset, GenericAnimationUtility.CachedOffset)>();

		private ITMPSegmentData mocked;

		public override void OnBehaviourPause(Playable playable, FrameData info)
		{
			if (!(animator == null))
			{
				animator.OnTextChanged -= UpdateSegmentData;
				mocked = null;
			}
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			animator = playerData as TMPAnimator;
			if (animator == null)
			{
				return;
			}
			if (active == null)
			{
				active = new List<ScriptPlayable<TMPMeshModifierBehaviour>>();
			}
			active.Clear();
			animator.OnTextChanged -= UpdateSegmentData;
			animator.OnTextChanged += UpdateSegmentData;
			animator.UnregisterPostAnimationHook(OnAnimatedCallback);
			int inputCount = playable.GetInputCount();
			for (int i = 0; i < inputCount; i++)
			{
				if (!(playable.GetInputWeight(i) <= 0f))
				{
					ScriptPlayable<TMPMeshModifierBehaviour> item = (ScriptPlayable<TMPMeshModifierBehaviour>)playable.GetInput(i);
					active.Add(item);
				}
			}
			time = (float)playable.GetTime();
			if (active.Count > 0)
			{
				animator.UnregisterPostAnimationHook(OnAnimatedCallback);
				animator.RegisterPostAnimationHook(OnAnimatedCallback);
			}
			else if (needsReset)
			{
				needsReset = false;
				animator.QueueCharacterReset();
			}
		}

		private void OnAnimatedCallback(CharData cData)
		{
			if (modifiersStorage == null)
			{
				modifiersStorage = new CharDataModifiers();
			}
			if (modifiersStorage2 == null)
			{
				modifiersStorage2 = new CharDataModifiers();
			}
			if (accModifier == null)
			{
				accModifier = new CharDataModifiers();
			}
			if (current == null)
			{
				current = new CharDataModifiers();
			}
			if (mocked == null)
			{
				UpdateSegmentData();
			}
			for (int i = 0; i < active.Count; i++)
			{
				if (!active[i].IsValid())
				{
					continue;
				}
				TMPMeshModifierBehaviour behaviour = active[i].GetBehaviour();
				if (behaviour != null)
				{
					float timeValue = (float)active[i].GetTime();
					float duration = (float)behaviour.Clip.duration;
					AnimationStep step = behaviour.Step.Step;
					if (!cachedOffsets.TryGetValue(step, out (GenericAnimationUtility.CachedOffset, GenericAnimationUtility.CachedOffset) value))
					{
						step.entryCurve.provider.GetMinMaxOffset(out var min, out var max, mocked, animator.AnimatorContext);
						step.exitCurve.provider.GetMinMaxOffset(out var min2, out var max2, mocked, animator.AnimatorContext);
						value = (new GenericAnimationUtility.CachedOffset
						{
							minOffset = min,
							maxOffset = max,
							offset = new Dictionary<CharData, float>()
						}, new GenericAnimationUtility.CachedOffset
						{
							minOffset = min2,
							maxOffset = max2,
							offset = new Dictionary<CharData, float>()
						});
						cachedOffsets[step] = value;
					}
					if (!value.Item1.offset.TryGetValue(cData, out var value2))
					{
						value2 = step.entryCurve.provider.GetOffset(cData, mocked, animator.AnimatorContext);
						value.Item1.offset[cData] = value2;
					}
					if (!value.Item2.offset.TryGetValue(cData, out var value3))
					{
						value3 = step.entryCurve.provider.GetOffset(cData, mocked, animator.AnimatorContext);
						value.Item2.offset[cData] = value3;
					}
					float weight = AnimationStep.CalcWeight(behaviour.Step.Step, timeValue, duration, cData, animator.AnimatorContext, mocked);
					AnimationStep.LerpAnimationStepWeighted(behaviour.Step.Step, weight, cData, animator.AnimatorContext, modifiersStorage, modifiersStorage2, current);
					cData.CharacterModifiers.Combine(current.CharacterModifiers);
					cData.MeshModifiers.Combine(current.MeshModifiers);
					needsReset = true;
				}
			}
		}

		private void UpdateSegmentData(bool _ = false)
		{
			mocked = TMPAnimationUtility.GetMockedSegment(animator.TextComponent.GetParsedText().Length, animator.CharData);
			cachedOffsets = new Dictionary<AnimationStep, (GenericAnimationUtility.CachedOffset, GenericAnimationUtility.CachedOffset)>();
		}
	}
}
