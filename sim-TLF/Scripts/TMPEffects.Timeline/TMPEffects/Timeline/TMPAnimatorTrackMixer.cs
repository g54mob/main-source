using System.Collections.Generic;
using System.Linq;
using TMPEffects.CharacterData;
using TMPEffects.Components;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;
using TMPEffects.Parameters;
using TMPEffects.TMPAnimations;
using TMPEffects.Tags;
using UnityEngine.Playables;

namespace TMPEffects.Timeline
{
	public class TMPAnimatorTrackMixer : PlayableBehaviour
	{
		private class MockedAnimationContext : IAnimationContext, IAnimationData, IAnimationFinished, IAnimationFinisher
		{
			private Dictionary<int, bool> finishedDict = new Dictionary<int, bool>();

			public IAnimatorContext AnimatorContext { get; set; }

			public SegmentData SegmentData { get; set; }

			public object CustomData { get; set; }

			public bool Finished(int index)
			{
				return finishedDict[index];
			}

			public bool Finished(CharData cData)
			{
				return finishedDict[cData.info.index];
			}

			public void FinishAnimation(CharData cData)
			{
			}

			public MockedAnimationContext(IAnimatorContext context, object customData)
			{
				AnimatorContext = context;
				CustomData = customData;
				UpdateSegmentData();
			}

			private void UpdateSegmentData()
			{
				TMPEffectTagIndices indices = new TMPEffectTagIndices(0, AnimatorContext.Animator.TextComponent.GetParsedText().Length, 0);
				SegmentData = new SegmentData(indices, AnimatorContext.Animator.CharData, (char cd) => true);
				for (int num = 0; num < AnimatorContext.Animator.CharData.Count(); num++)
				{
					finishedDict[num] = false;
				}
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
			if (!(animator == null))
			{
				animator.OnTextChanged -= UpdateContext;
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
				active = new List<ScriptPlayable<TMPAnimationBehaviour>>();
			}
			active.Clear();
			animator.OnTextChanged -= UpdateContext;
			animator.OnTextChanged += UpdateContext;
			animator.UnregisterPostAnimationHook(OnAnimatedCallback);
			int inputCount = playable.GetInputCount();
			for (int i = 0; i < inputCount; i++)
			{
				if (!(playable.GetInputWeight(i) <= 0f))
				{
					ScriptPlayable<TMPAnimationBehaviour> item = (ScriptPlayable<TMPAnimationBehaviour>)playable.GetInput(i);
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

		private void OnAnimatedCallback(CharData cdata)
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
			for (int i = 0; i < active.Count; i++)
			{
				if (!active[i].IsValid())
				{
					continue;
				}
				TMPAnimationBehaviour behaviour = active[i].GetBehaviour();
				if (behaviour != null && behaviour.animation != null)
				{
					float timeValue = ((!((double)time < behaviour.Clip.start)) ? ((float)active[i].GetTime()) : (time - (float)behaviour.Clip.start));
					float duration = (float)behaviour.Clip.duration;
					if (mocked == null || lastActive != behaviour.animation)
					{
						object newCustomData = behaviour.animation.GetNewCustomData();
						mocked = new MockedAnimationContext(animator.AnimatorContext, newCustomData);
						behaviour.animation.SetParameters(newCustomData, new Dictionary<string, string>(), null);
						lastActive = behaviour.animation;
					}
					behaviour.animation.Animate(cdata, mocked);
					float t = CalcWeight(behaviour.entryDuration, behaviour.exitDuration, behaviour.entryCurve, behaviour.exitCurve, timeValue, duration, cdata, animator.AnimatorContext, mocked.SegmentData);
					if (result == null)
					{
						result = new TMPCharacterModifiers();
					}
					if (resultMesh == null)
					{
						resultMesh = new TMPMeshModifiers();
					}
					result.ClearModifiers();
					resultMesh.ClearModifiers();
					CharDataModifiers.LerpCharacterModifiersUnclamped(cdata, cdata.CharacterModifiers, t, result);
					CharDataModifiers.LerpMeshModifiersUnclamped(cdata, cdata.MeshModifiers, t, resultMesh);
					cdata.CharacterModifiers.CopyFrom(result);
					cdata.MeshModifiers.CopyFrom(resultMesh);
					needsReset = true;
				}
			}
		}

		private void UpdateContext(bool _ = false)
		{
			mocked = null;
		}

		public static float CalcWeight(float entryDuration, float exitDuration, TMPBlendCurve inCurve, TMPBlendCurve outCurve, float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData)
		{
			float num = 1f;
			if (entryDuration > 0f)
			{
				num = inCurve.EvaluateIn(timeValue, entryDuration, cData, context, segmentData);
			}
			if (exitDuration > 0f)
			{
				float preTime = duration - exitDuration;
				float num2 = outCurve.EvaluateOut(timeValue, exitDuration, preTime, cData, context, segmentData);
				num *= num2;
			}
			return num;
		}
	}
}
