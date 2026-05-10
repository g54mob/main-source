using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	public sealed class AnimancerLayer : AnimancerNode, IAnimationClipCollection
	{
		private readonly List<AnimancerState> States = new List<AnimancerState>();

		private AnimancerState _CurrentState;

		private bool _ApplyAnimatorIK;

		private bool _ApplyFootIK;

		public override AnimancerLayer Layer => this;

		public override IPlayableWrapper Parent => base.Root;

		public override bool KeepChildrenConnected => base.Root.KeepChildrenConnected;

		public AnimancerState CurrentState
		{
			get
			{
				return _CurrentState;
			}
			private set
			{
				_CurrentState = value;
				CommandCount++;
			}
		}

		public int CommandCount { get; private set; }

		public bool IsAdditive
		{
			get
			{
				return base.Root.Layers.IsAdditive(base.Index);
			}
			set
			{
				base.Root.Layers.SetAdditive(base.Index, value);
			}
		}

		public Vector3 AverageVelocity
		{
			get
			{
				Vector3 result = default(Vector3);
				for (int num = States.Count - 1; num >= 0; num--)
				{
					AnimancerState animancerState = States[num];
					result += animancerState.AverageVelocity * animancerState.Weight;
				}
				return result;
			}
		}

		public override int ChildCount => States.Count;

		public AnimancerState this[int index] => States[index];

		public static float WeightlessThreshold { get; set; } = 0.1f;

		public static int MaxCloneCount { get; private set; } = 3;

		public override bool ApplyAnimatorIK
		{
			get
			{
				return _ApplyAnimatorIK;
			}
			set
			{
				base.ApplyAnimatorIK = (_ApplyAnimatorIK = value);
			}
		}

		public override bool ApplyFootIK
		{
			get
			{
				return _ApplyFootIK;
			}
			set
			{
				base.ApplyFootIK = (_ApplyFootIK = value);
			}
		}

		internal AnimancerLayer(AnimancerPlayable root, int index)
		{
			base.Root = root;
			base.Index = index;
			CreatePlayable();
			if (AnimancerNode.ApplyParentAnimatorIK)
			{
				_ApplyAnimatorIK = root.ApplyAnimatorIK;
			}
			if (AnimancerNode.ApplyParentFootIK)
			{
				_ApplyFootIK = root.ApplyFootIK;
			}
		}

		protected override void CreatePlayable(out Playable playable)
		{
			playable = AnimationMixerPlayable.Create(base.Root._Graph);
		}

		public void SetMask(AvatarMask mask)
		{
			base.Root.Layers.SetMask(base.Index, mask);
		}

		public override AnimancerState GetChild(int index)
		{
			return States[index];
		}

		public void AddChild(AnimancerState state)
		{
			if (state.Parent != this)
			{
				state.SetRoot(base.Root);
				int count = States.Count;
				States.Add(null);
				_Playable.SetInputCount(count + 1);
				state.SetParent(this, count);
			}
		}

		protected internal override void OnAddChild(AnimancerState state)
		{
			OnAddChild(States, state);
		}

		protected internal override void OnRemoveChild(AnimancerState state)
		{
			int index = state.Index;
			if (_Playable.GetInput(index).IsValid())
			{
				base.Root._Graph.Disconnect(_Playable, index);
			}
			int num = States.Count - 1;
			if (index < num)
			{
				state = States[num];
				state.DisconnectFromGraph();
				States[index] = state;
				state.Index = index;
				if (state.Weight != 0f || base.Root.KeepChildrenConnected)
				{
					state.ConnectToGraph();
				}
			}
			States.RemoveAt(num);
			_Playable.SetInputCount(num);
		}

		public override FastEnumerator<AnimancerState> GetEnumerator()
		{
			return new FastEnumerator<AnimancerState>(States);
		}

		public ClipState CreateState(AnimationClip clip)
		{
			return CreateState(base.Root.GetKey(clip), clip);
		}

		public ClipState CreateState(object key, AnimationClip clip)
		{
			ClipState clipState = new ClipState(clip)
			{
				_Key = key
			};
			AddChild(clipState);
			return clipState;
		}

		public AnimancerState GetState(ref object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			for (object obj = key; obj is AnimancerState animancerState; obj = animancerState.Key)
			{
				if (animancerState.Parent == this)
				{
					key = animancerState.Key;
					return animancerState;
				}
				if (animancerState.Parent == null)
				{
					key = animancerState.Key;
					AddChild(animancerState);
					return animancerState;
				}
			}
			AnimancerState state;
			while (true)
			{
				if (!base.Root.States.TryGet(key, out state))
				{
					return null;
				}
				if (state.Parent == this)
				{
					return state;
				}
				if (state.Parent == null)
				{
					break;
				}
				key = state;
			}
			AddChild(state);
			return state;
		}

		public void CreateIfNew(AnimationClip clip0, AnimationClip clip1)
		{
			GetOrCreateState(clip0);
			GetOrCreateState(clip1);
		}

		public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2)
		{
			GetOrCreateState(clip0);
			GetOrCreateState(clip1);
			GetOrCreateState(clip2);
		}

		public void CreateIfNew(AnimationClip clip0, AnimationClip clip1, AnimationClip clip2, AnimationClip clip3)
		{
			GetOrCreateState(clip0);
			GetOrCreateState(clip1);
			GetOrCreateState(clip2);
			GetOrCreateState(clip3);
		}

		public void CreateIfNew(params AnimationClip[] clips)
		{
			if (clips == null)
			{
				return;
			}
			int num = clips.Length;
			for (int i = 0; i < num; i++)
			{
				AnimationClip animationClip = clips[i];
				if (animationClip != null)
				{
					GetOrCreateState(animationClip);
				}
			}
		}

		public AnimancerState GetOrCreateState(AnimationClip clip, bool allowSetClip = false)
		{
			return GetOrCreateState(base.Root.GetKey(clip), clip, allowSetClip);
		}

		public AnimancerState GetOrCreateState(ITransition transition)
		{
			object key = transition.Key;
			AnimancerState animancerState = GetState(ref key);
			if (animancerState == null)
			{
				animancerState = transition.CreateState();
				animancerState.Key = key;
				AddChild(animancerState);
			}
			return animancerState;
		}

		public AnimancerState GetOrCreateState(object key, AnimationClip clip, bool allowSetClip = false)
		{
			AnimancerState state = GetState(ref key);
			if (state == null)
			{
				return CreateState(key, clip);
			}
			if ((object)state.Clip != clip)
			{
				if (!allowSetClip)
				{
					throw new ArgumentException(AnimancerPlayable.StateDictionary.GetClipMismatchError(key, state.Clip, clip));
				}
				state.Clip = clip;
			}
			return state;
		}

		public AnimancerState GetOrCreateState(AnimancerState state)
		{
			if (state.Parent == this)
			{
				return state;
			}
			if (state.Parent == null)
			{
				AddChild(state);
				return state;
			}
			object key = state.Key;
			if (key == null)
			{
				key = state;
			}
			AnimancerState animancerState = GetState(ref key);
			if (animancerState == null)
			{
				animancerState = state.Clone(base.Root);
				animancerState.Key = key;
				AddChild(animancerState);
			}
			return animancerState;
		}

		public AnimancerState GetOrCreateWeightlessState(AnimancerState state)
		{
			if (state.Parent == null)
			{
				state.Weight = 0f;
			}
			else if (state.Parent != this || !(state.Weight <= WeightlessThreshold))
			{
				float num = float.PositiveInfinity;
				AnimancerState animancerState = null;
				int num2 = 0;
				AnimancerState animancerState2 = state;
				while (true)
				{
					animancerState2 = animancerState2.Key as AnimancerState;
					if (animancerState2 != null)
					{
						if (animancerState2.Parent == this)
						{
							if (animancerState2.Weight <= WeightlessThreshold)
							{
								state = animancerState2;
								break;
							}
							if (num > animancerState2.Weight)
							{
								num = animancerState2.Weight;
								animancerState = animancerState2;
							}
						}
						else if (animancerState2.Parent == null)
						{
							AddChild(animancerState2);
							break;
						}
						num2++;
						continue;
					}
					if (state.Parent == this)
					{
						num = state.Weight;
						animancerState = state;
					}
					animancerState2 = state;
					while (true)
					{
						object key = state;
						if (!base.Root.States.TryGet(key, out state))
						{
							if (num2 >= MaxCloneCount && animancerState != null)
							{
								state = animancerState;
								break;
							}
							state = animancerState2.Clone(base.Root);
							state.Weight = 0f;
							state._Key = key;
							base.Root.States.Register(state);
							AddChild(state);
							break;
						}
						if (state.Parent == this)
						{
							if (state.Weight <= WeightlessThreshold)
							{
								break;
							}
							if (num > state.Weight)
							{
								num = state.Weight;
								animancerState = state;
							}
						}
						else if (state.Parent == null)
						{
							AddChild(state);
							break;
						}
						num2++;
					}
					break;
				}
			}
			state.TimeD = 0.0;
			return state;
		}

		public void DestroyStates()
		{
			for (int num = States.Count - 1; num >= 0; num--)
			{
				States[num].Destroy();
			}
			States.Clear();
		}

		protected internal override void OnStartFade()
		{
			for (int num = States.Count - 1; num >= 0; num--)
			{
				States[num].OnStartFade();
			}
		}

		public AnimancerState Play(AnimationClip clip)
		{
			return Play(GetOrCreateState(clip));
		}

		public AnimancerState Play(AnimancerState state)
		{
			if (base.Weight == 0f && base.TargetWeight == 0f)
			{
				base.Weight = 1f;
			}
			state = GetOrCreateState(state);
			CurrentState = state;
			state.Play();
			for (int num = States.Count - 1; num >= 0; num--)
			{
				AnimancerState animancerState = States[num];
				if (animancerState != state)
				{
					animancerState.Stop();
				}
			}
			return state;
		}

		public AnimancerState Play(AnimationClip clip, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			return Play(GetOrCreateState(clip), fadeDuration, mode);
		}

		public AnimancerState Play(AnimancerState state, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			if (fadeDuration <= 0f || (base.Root.SkipFirstFade && base.Index == 0 && base.Weight == 0f))
			{
				base.Weight = 1f;
				state = Play(state);
				if (mode == FadeMode.FromStart || mode == FadeMode.NormalizedFromStart)
				{
					state.TimeD = 0.0;
				}
				return state;
			}
			EvaluateFadeMode(mode, ref state, ref fadeDuration, out var layerFadeDuration);
			StartFade(1f, layerFadeDuration);
			if (base.Weight == 0f)
			{
				return Play(state);
			}
			state = GetOrCreateState(state);
			CurrentState = state;
			if (state.IsPlaying && state.TargetWeight == 1f && (state.Weight == 1f || state.FadeSpeed * fadeDuration > Math.Abs(1f - state.Weight)))
			{
				OnStartFade();
			}
			else
			{
				state.IsPlaying = true;
				state.StartFade(1f, fadeDuration);
				for (int num = States.Count - 1; num >= 0; num--)
				{
					AnimancerState animancerState = States[num];
					if (animancerState != state)
					{
						animancerState.StartFade(0f, fadeDuration);
					}
				}
			}
			return state;
		}

		public AnimancerState Play(ITransition transition)
		{
			return Play(transition, transition.FadeDuration, transition.FadeMode);
		}

		public AnimancerState Play(ITransition transition, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			AnimancerState orCreateState = GetOrCreateState(transition);
			orCreateState = Play(orCreateState, fadeDuration, mode);
			transition.Apply(orCreateState);
			return orCreateState;
		}

		public AnimancerState TryPlay(object key)
		{
			if (!base.Root.States.TryGet(key, out var state))
			{
				return null;
			}
			return Play(state);
		}

		public AnimancerState TryPlay(object key, float fadeDuration, FadeMode mode = FadeMode.FixedSpeed)
		{
			if (!base.Root.States.TryGet(key, out var state))
			{
				return null;
			}
			return Play(state, fadeDuration, mode);
		}

		private void EvaluateFadeMode(FadeMode mode, ref AnimancerState state, ref float fadeDuration, out float layerFadeDuration)
		{
			layerFadeDuration = fadeDuration;
			switch (mode)
			{
			case FadeMode.FixedSpeed:
				fadeDuration *= Math.Abs(1f - state.Weight);
				layerFadeDuration *= Math.Abs(1f - base.Weight);
				break;
			case FadeMode.FromStart:
				state = GetOrCreateWeightlessState(state);
				break;
			case FadeMode.NormalizedSpeed:
			{
				float length3 = state.Length;
				fadeDuration *= Math.Abs(1f - state.Weight) * length3;
				layerFadeDuration *= Math.Abs(1f - base.Weight) * length3;
				break;
			}
			case FadeMode.NormalizedDuration:
			{
				float length2 = state.Length;
				fadeDuration *= length2;
				layerFadeDuration *= length2;
				break;
			}
			case FadeMode.NormalizedFromStart:
			{
				state = GetOrCreateWeightlessState(state);
				float length = state.Length;
				fadeDuration *= length;
				layerFadeDuration *= length;
				break;
			}
			default:
				throw AnimancerUtilities.CreateUnsupportedArgumentException(mode);
			case FadeMode.FixedDuration:
				break;
			}
		}

		public override void Stop()
		{
			base.Stop();
			CurrentState = null;
			for (int num = States.Count - 1; num >= 0; num--)
			{
				States[num].Stop();
			}
		}

		public bool IsPlayingClip(AnimationClip clip)
		{
			for (int num = States.Count - 1; num >= 0; num--)
			{
				AnimancerState animancerState = States[num];
				if (animancerState.Clip == clip && animancerState.IsPlaying)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAnyStatePlaying()
		{
			for (int num = States.Count - 1; num >= 0; num--)
			{
				if (States[num].IsPlaying)
				{
					return true;
				}
			}
			return false;
		}

		public override bool IsPlayingAndNotEnding()
		{
			if (_CurrentState != null)
			{
				return _CurrentState.IsPlayingAndNotEnding();
			}
			return false;
		}

		public float GetTotalWeight()
		{
			float num = 0f;
			for (int num2 = States.Count - 1; num2 >= 0; num2--)
			{
				num += States[num2].Weight;
			}
			return num;
		}

		public void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			clips.GatherFromSource(States);
		}

		public override string ToString()
		{
			return "Layer " + base.Index;
		}

		protected override void AppendDetails(StringBuilder text, string separator)
		{
			base.AppendDetails(text, separator);
			text.Append(separator).Append("CurrentState: ").Append(CurrentState);
			text.Append(separator).Append("CommandCount: ").Append(CommandCount);
			text.Append(separator).Append("IsAdditive: ").Append(IsAdditive);
		}
	}
}
