using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animancer
{
	public class ManualMixerState : AnimancerState, ICopyable<ManualMixerState>
	{
		public interface ITransition : ITransition<ManualMixerState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		public interface ITransition2D : ITransition<MixerState<Vector2>>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private int _ChildCount;

		private List<AnimancerState> _SynchronizedChildren;

		private bool _ApplyAnimatorIK;

		private bool _ApplyFootIK;

		public override bool KeepChildrenConnected => true;

		public override AnimationClip Clip => null;

		protected AnimancerState[] ChildStates { get; private set; } = Array.Empty<AnimancerState>();

		public sealed override int ChildCount => _ChildCount;

		public int ChildCapacity
		{
			get
			{
				return ChildStates.Length;
			}
			set
			{
				if (value == ChildStates.Length)
				{
					return;
				}
				AnimancerState[] array = new AnimancerState[value];
				if (value > _ChildCount)
				{
					Array.Copy(ChildStates, array, _ChildCount);
				}
				else
				{
					for (int i = value; i < _ChildCount; i++)
					{
						ChildStates[i].Destroy();
					}
					Array.Copy(ChildStates, array, value);
					_ChildCount = value;
				}
				ChildStates = array;
				if (_Playable.IsValid())
				{
					_Playable.SetInputCount(value);
				}
				else if (base.Root != null)
				{
					CreatePlayable();
				}
				OnChildCapacityChanged();
			}
		}

		public static int DefaultChildCapacity { get; set; } = 8;

		public override bool IsLooping
		{
			get
			{
				for (int num = _ChildCount - 1; num >= 0; num--)
				{
					if (ChildStates[num].IsLooping)
					{
						return true;
					}
				}
				return false;
			}
		}

		public override double RawTime
		{
			get
			{
				RecalculateWeights();
				if (!GetSynchronizedTimeDetails(out var totalWeight, out var normalizedTime, out var length))
				{
					GetTimeDetails(out totalWeight, out normalizedTime, out length);
				}
				if (totalWeight == 0f)
				{
					return base.RawTime;
				}
				totalWeight *= totalWeight;
				return normalizedTime * length / totalWeight;
			}
			set
			{
				if (value != 0.0)
				{
					float length = Length;
					if (length != 0f)
					{
						value /= (double)length;
						for (int num = _ChildCount - 1; num >= 0; num--)
						{
							ChildStates[num].NormalizedTimeD = value;
						}
						return;
					}
				}
				for (int num2 = _ChildCount - 1; num2 >= 0; num2--)
				{
					ChildStates[num2].TimeD = 0.0;
				}
			}
		}

		public override float Length
		{
			get
			{
				RecalculateWeights();
				float num = 0f;
				float num2 = 0f;
				if (_SynchronizedChildren != null)
				{
					for (int num3 = _SynchronizedChildren.Count - 1; num3 >= 0; num3--)
					{
						AnimancerState animancerState = _SynchronizedChildren[num3];
						float weight = animancerState.Weight;
						if (weight != 0f)
						{
							float length = animancerState.Length;
							if (length != 0f)
							{
								num2 += weight;
								num += length * weight;
							}
						}
					}
				}
				if (num2 > 0f)
				{
					return num / num2;
				}
				num2 = CalculateTotalWeight(ChildStates, _ChildCount);
				if (num2 <= 0f)
				{
					return 0f;
				}
				for (int num4 = _ChildCount - 1; num4 >= 0; num4--)
				{
					AnimancerState animancerState2 = ChildStates[num4];
					num += animancerState2.Length * animancerState2.Weight;
				}
				return num / num2;
			}
		}

		public bool WeightsAreDirty { get; set; }

		public static bool SynchronizeNewChildren { get; set; } = true;

		public static float MinimumSynchronizeChildrenWeight { get; set; } = 0.01f;

		public AnimancerState[] SynchronizedChildren
		{
			get
			{
				if (SynchronizedChildCount <= 0)
				{
					return Array.Empty<AnimancerState>();
				}
				return _SynchronizedChildren.ToArray();
			}
			set
			{
				if (_SynchronizedChildren == null)
				{
					_SynchronizedChildren = new List<AnimancerState>();
				}
				else
				{
					_SynchronizedChildren.Clear();
				}
				for (int i = 0; i < value.Length; i++)
				{
					Synchronize(value[i]);
				}
			}
		}

		public int SynchronizedChildCount
		{
			get
			{
				if (_SynchronizedChildren == null)
				{
					return 0;
				}
				return _SynchronizedChildren.Count;
			}
		}

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

		public override Vector3 AverageVelocity
		{
			get
			{
				Vector3 result = default(Vector3);
				RecalculateWeights();
				for (int num = _ChildCount - 1; num >= 0; num--)
				{
					AnimancerState animancerState = ChildStates[num];
					result += animancerState.AverageVelocity * animancerState.Weight;
				}
				return result;
			}
		}

		protected virtual int ParameterCount => 0;

		protected virtual void OnChildCapacityChanged()
		{
		}

		public void EnsureRemainingChildCapacity(int minimumCapacity)
		{
			minimumCapacity += _ChildCount;
			if (ChildCapacity < minimumCapacity)
			{
				int num;
				for (num = Math.Max(ChildCapacity, DefaultChildCapacity); num < minimumCapacity; num *= 2)
				{
				}
				ChildCapacity = num;
			}
		}

		public sealed override AnimancerState GetChild(int index)
		{
			return ChildStates[index];
		}

		public sealed override FastEnumerator<AnimancerState> GetEnumerator()
		{
			return new FastEnumerator<AnimancerState>(ChildStates, _ChildCount);
		}

		protected override void OnSetIsPlaying()
		{
			for (int num = _ChildCount - 1; num >= 0; num--)
			{
				ChildStates[num].IsPlaying = base.IsPlaying;
			}
		}

		public override void MoveTime(double time, bool normalized)
		{
			base.MoveTime(time, normalized);
			for (int num = _ChildCount - 1; num >= 0; num--)
			{
				ChildStates[num].MoveTime(time, normalized);
			}
		}

		private bool GetSynchronizedTimeDetails(out float totalWeight, out float normalizedTime, out float length)
		{
			totalWeight = 0f;
			normalizedTime = 0f;
			length = 0f;
			if (_SynchronizedChildren != null)
			{
				for (int num = _SynchronizedChildren.Count - 1; num >= 0; num--)
				{
					AnimancerState animancerState = _SynchronizedChildren[num];
					float weight = animancerState.Weight;
					if (weight != 0f)
					{
						float length2 = animancerState.Length;
						if (length2 != 0f)
						{
							totalWeight += weight;
							normalizedTime += animancerState.Time / length2 * weight;
							length += length2 * weight;
						}
					}
				}
			}
			return totalWeight > MinimumSynchronizeChildrenWeight;
		}

		private void GetTimeDetails(out float totalWeight, out float normalizedTime, out float length)
		{
			totalWeight = 0f;
			normalizedTime = 0f;
			length = 0f;
			for (int num = _ChildCount - 1; num >= 0; num--)
			{
				AnimancerState animancerState = ChildStates[num];
				float weight = animancerState.Weight;
				if (weight != 0f)
				{
					float length2 = animancerState.Length;
					if (length2 != 0f)
					{
						totalWeight += weight;
						normalizedTime += animancerState.Time / length2 * weight;
						length += length2 * weight;
					}
				}
			}
		}

		protected override void CreatePlayable(out Playable playable)
		{
			playable = AnimationMixerPlayable.Create(base.Root._Graph, ChildCapacity);
			RecalculateWeights();
		}

		protected internal override void OnAddChild(AnimancerState state)
		{
			if (state.Index != _ChildCount)
			{
				throw new ArgumentException("Mixer child index out of order. Mixer children must be added in sequence starting from 0 to ensure that they contain no nulls.");
			}
			int childCapacity = ChildCapacity;
			if (_ChildCount >= childCapacity)
			{
				ChildCapacity = Math.Max(DefaultChildCapacity, childCapacity * 2);
			}
			OnAddChild(ChildStates, state);
			_ChildCount++;
			if (SynchronizeNewChildren)
			{
				Synchronize(state);
			}
		}

		protected internal override void OnRemoveChild(AnimancerState state)
		{
			DontSynchronize(state);
			if (base.Root == null)
			{
				Array.Copy(ChildStates, state.Index + 1, ChildStates, state.Index, _ChildCount - state.Index - 1);
				for (int i = state.Index; i < _ChildCount - 1; i++)
				{
					ChildStates[i].Index = i;
				}
			}
			else
			{
				base.Root._Graph.Disconnect(_Playable, state.Index);
				for (int j = state.Index + 1; j < _ChildCount; j++)
				{
					AnimancerState animancerState = ChildStates[j];
					base.Root._Graph.Disconnect(_Playable, animancerState.Index);
					animancerState.Index = j - 1;
					ChildStates[j - 1] = animancerState;
					animancerState.ConnectToGraph();
				}
			}
			_ChildCount--;
			ChildStates[_ChildCount] = null;
		}

		public override void Destroy()
		{
			DestroyChildren();
			base.Destroy();
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			ManualMixerState manualMixerState = new ManualMixerState();
			manualMixerState.SetNewCloneRoot(root);
			((ICopyable<ManualMixerState>)manualMixerState).CopyFrom(this);
			return manualMixerState;
		}

		void ICopyable<ManualMixerState>.CopyFrom(ManualMixerState copyFrom)
		{
			((ICopyable<AnimancerState>)this).CopyFrom((AnimancerState)copyFrom);
			DestroyChildren();
			bool synchronizeNewChildren = SynchronizeNewChildren;
			int childCount = copyFrom.ChildCount;
			EnsureRemainingChildCapacity(childCount);
			for (int i = 0; i < childCount; i++)
			{
				AnimancerState animancerState = copyFrom.ChildStates[i];
				SynchronizeNewChildren = copyFrom.IsSynchronized(animancerState);
				animancerState = animancerState.Clone(base.Root);
				Add(animancerState);
			}
			SynchronizeNewChildren = synchronizeNewChildren;
		}

		public void Add(AnimancerState state)
		{
			state.SetParent(this, _ChildCount);
			state.IsPlaying = base.IsPlaying;
		}

		public ClipState Add(AnimationClip clip)
		{
			ClipState clipState = new ClipState(clip);
			Add(clipState);
			return clipState;
		}

		public AnimancerState Add(Animancer.ITransition transition)
		{
			AnimancerState animancerState = transition.CreateStateAndApply(base.Root);
			Add(animancerState);
			return animancerState;
		}

		public AnimancerState Add(object child)
		{
			if (child is AnimationClip clip)
			{
				return Add(clip);
			}
			if (child is Animancer.ITransition transition)
			{
				return Add(transition);
			}
			if (child is AnimancerState animancerState)
			{
				Add(animancerState);
				return animancerState;
			}
			throw new ArgumentException("Failed to Add '" + AnimancerUtilities.ToStringOrNull(child) + "'" + $" as child of '{this}' because it isn't an" + " AnimationClip, ITransition, or AnimancerState.");
		}

		public void AddRange(IList<AnimationClip> clips)
		{
			int count = clips.Count;
			EnsureRemainingChildCapacity(count);
			for (int i = 0; i < count; i++)
			{
				Add(clips[i]);
			}
		}

		public void AddRange(params AnimationClip[] clips)
		{
			AddRange((IList<AnimationClip>)clips);
		}

		public void AddRange(IList<Animancer.ITransition> transitions)
		{
			int count = transitions.Count;
			EnsureRemainingChildCapacity(count);
			for (int i = 0; i < count; i++)
			{
				Add(transitions[i]);
			}
		}

		public void AddRange(params Animancer.ITransition[] clips)
		{
			AddRange((IList<Animancer.ITransition>)clips);
		}

		public void AddRange(IList<object> children)
		{
			int count = children.Count;
			EnsureRemainingChildCapacity(count);
			for (int i = 0; i < count; i++)
			{
				Add(children[i]);
			}
		}

		public void AddRange(params object[] clips)
		{
			AddRange((IList<object>)clips);
		}

		public void Remove(int index, bool destroy)
		{
			Remove(ChildStates[index], destroy);
		}

		public void Remove(AnimancerState child, bool destroy)
		{
			if (destroy)
			{
				child.Destroy();
			}
			else
			{
				child.SetParent(null, -1);
			}
		}

		public void Set(int index, AnimancerState child, bool destroyPrevious)
		{
			child.SetParent(null, -1);
			AnimancerState animancerState = ChildStates[index];
			DontSynchronize(animancerState);
			animancerState.SetParentInternal(null);
			child.SetRoot(base.Root);
			ChildStates[index] = child;
			child.SetParentInternal(this, index);
			if (base.Root != null)
			{
				base.Root._Graph.Disconnect(_Playable, child.Index);
				child.ConnectToGraph();
			}
			child.CopyIKFlags(this);
			if (SynchronizeNewChildren)
			{
				Synchronize(child);
			}
			if (destroyPrevious)
			{
				animancerState.Destroy();
			}
		}

		public ClipState Set(int index, AnimationClip clip, bool destroyPrevious)
		{
			ClipState clipState = new ClipState(clip);
			Set(index, clipState, destroyPrevious);
			return clipState;
		}

		public AnimancerState Set(int index, Animancer.ITransition transition, bool destroyPrevious)
		{
			AnimancerState animancerState = transition.CreateStateAndApply(base.Root);
			Set(index, animancerState, destroyPrevious);
			return animancerState;
		}

		public AnimancerState Set(int index, object child, bool destroyPrevious)
		{
			if (child is AnimationClip clip)
			{
				return Set(index, clip, destroyPrevious);
			}
			if (child is Animancer.ITransition transition)
			{
				return Set(index, transition, destroyPrevious);
			}
			if (child is AnimancerState animancerState)
			{
				Set(index, animancerState, destroyPrevious);
				return animancerState;
			}
			throw new ArgumentException("Failed to Set '" + AnimancerUtilities.ToStringOrNull(child) + "'" + $" as child of '{this}' because it isn't an" + " AnimationClip, ITransition, or AnimancerState.");
		}

		public int IndexOf(AnimancerState child)
		{
			return Array.IndexOf(ChildStates, child, 0, _ChildCount);
		}

		public void DestroyChildren()
		{
			for (int num = _ChildCount - 1; num >= 0; num--)
			{
				ChildStates[num].Destroy();
			}
			Array.Clear(ChildStates, 0, _ChildCount);
			_ChildCount = 0;
		}

		public AnimationScriptPlayable CreatePlayable<T>(AnimancerPlayable root, T job, bool processInputs = false) where T : struct, IAnimationJob
		{
			SetRoot(null);
			base.Root = root;
			root.States.Register(this);
			AnimationScriptPlayable result = AnimationScriptPlayable.Create(root._Graph, job, _ChildCount);
			if (!processInputs)
			{
				result.SetProcessInputs(value: false);
			}
			for (int num = _ChildCount - 1; num >= 0; num--)
			{
				ChildStates[num].SetRoot(root);
			}
			return result;
		}

		protected void CreatePlayable<T>(out Playable playable, T job, bool processInputs = false) where T : struct, IAnimationJob
		{
			AnimationScriptPlayable animationScriptPlayable = AnimationScriptPlayable.Create(base.Root._Graph, job, ChildCount);
			if (!processInputs)
			{
				animationScriptPlayable.SetProcessInputs(value: false);
			}
			playable = animationScriptPlayable;
		}

		public T GetJobData<T>() where T : struct, IAnimationJob
		{
			return ((AnimationScriptPlayable)_Playable).GetJobData<T>();
		}

		public void SetJobData<T>(T value) where T : struct, IAnimationJob
		{
			((AnimationScriptPlayable)_Playable).SetJobData(value);
		}

		protected internal override void Update(out bool needsMoreUpdates)
		{
			base.Update(out needsMoreUpdates);
			if (RecalculateWeights())
			{
				for (int num = _ChildCount - 1; num >= 0; num--)
				{
					ChildStates[num].ApplyWeight();
				}
			}
			ApplySynchronizeChildren(ref needsMoreUpdates);
		}

		public bool RecalculateWeights()
		{
			if (!WeightsAreDirty)
			{
				return false;
			}
			ForceRecalculateWeights();
			return true;
		}

		protected virtual void ForceRecalculateWeights()
		{
		}

		public bool IsSynchronized(AnimancerState state)
		{
			ManualMixerState parentMixer = GetParentMixer();
			if (parentMixer._SynchronizedChildren != null)
			{
				return parentMixer._SynchronizedChildren.Contains(state);
			}
			return false;
		}

		public void Synchronize(AnimancerState state)
		{
			if (state != null)
			{
				GetParentMixer().SynchronizeDirect(state);
			}
		}

		private void SynchronizeDirect(AnimancerState state)
		{
			if (state == null)
			{
				return;
			}
			if (state is ManualMixerState manualMixerState)
			{
				if (manualMixerState._SynchronizedChildren != null)
				{
					for (int i = 0; i < manualMixerState._SynchronizedChildren.Count; i++)
					{
						Synchronize(manualMixerState._SynchronizedChildren[i]);
					}
					manualMixerState._SynchronizedChildren.Clear();
				}
			}
			else
			{
				if (_SynchronizedChildren == null)
				{
					_SynchronizedChildren = new List<AnimancerState>();
				}
				_SynchronizedChildren.Add(state);
				RequireUpdate();
			}
		}

		public void DontSynchronize(AnimancerState state)
		{
			ManualMixerState parentMixer = GetParentMixer();
			if (parentMixer._SynchronizedChildren != null && parentMixer._SynchronizedChildren.Remove(state) && state._Playable.IsValid())
			{
				state._Playable.SetSpeed(state.Speed);
			}
		}

		public void DontSynchronizeChildren()
		{
			ManualMixerState parentMixer = GetParentMixer();
			List<AnimancerState> synchronizedChildren = parentMixer._SynchronizedChildren;
			if (synchronizedChildren == null)
			{
				return;
			}
			if (parentMixer == this)
			{
				for (int num = synchronizedChildren.Count - 1; num >= 0; num--)
				{
					AnimancerState animancerState = synchronizedChildren[num];
					if (animancerState._Playable.IsValid())
					{
						animancerState._Playable.SetSpeed(animancerState.Speed);
					}
				}
				synchronizedChildren.Clear();
				return;
			}
			for (int num2 = synchronizedChildren.Count - 1; num2 >= 0; num2--)
			{
				AnimancerState animancerState2 = synchronizedChildren[num2];
				if (IsChildOf(animancerState2, this))
				{
					if (animancerState2._Playable.IsValid())
					{
						animancerState2._Playable.SetSpeed(animancerState2.Speed);
					}
					synchronizedChildren.RemoveAt(num2);
				}
			}
		}

		public void InitializeSynchronizedChildren(params bool[] synchronizeChildren)
		{
			int num;
			if (synchronizeChildren != null)
			{
				num = synchronizeChildren.Length;
				for (int i = 0; i < num; i++)
				{
					if (synchronizeChildren[i])
					{
						SynchronizeDirect(ChildStates[i]);
					}
				}
			}
			else
			{
				num = 0;
			}
			for (int j = num; j < _ChildCount; j++)
			{
				SynchronizeDirect(ChildStates[j]);
			}
		}

		public ManualMixerState GetParentMixer()
		{
			ManualMixerState result = this;
			for (IPlayableWrapper parent = Parent; parent != null; parent = parent.Parent)
			{
				if (parent is ManualMixerState manualMixerState)
				{
					result = manualMixerState;
				}
			}
			return result;
		}

		public static ManualMixerState GetParentMixer(IPlayableWrapper node)
		{
			ManualMixerState result = null;
			while (node != null)
			{
				if (node is ManualMixerState manualMixerState)
				{
					result = manualMixerState;
				}
				node = node.Parent;
			}
			return result;
		}

		public static bool IsChildOf(IPlayableWrapper child, IPlayableWrapper parent)
		{
			do
			{
				child = child.Parent;
				if (child == parent)
				{
					return true;
				}
			}
			while (child != null);
			return false;
		}

		protected void ApplySynchronizeChildren(ref bool needsMoreUpdates)
		{
			if (base.Weight == 0f || !base.IsPlaying || _SynchronizedChildren == null || _SynchronizedChildren.Count <= 1)
			{
				return;
			}
			needsMoreUpdates = true;
			float num = AnimancerPlayable.DeltaTime * CalculateRealEffectiveSpeed();
			if (num == 0f)
			{
				return;
			}
			int count = _SynchronizedChildren.Count;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < count; i++)
			{
				AnimancerState animancerState = _SynchronizedChildren[i];
				float weight = animancerState.Weight;
				if (weight != 0f)
				{
					float length = animancerState.Length;
					if (length != 0f)
					{
						num2 += weight;
						weight /= length;
						num3 += animancerState.Time * weight;
						num4 += animancerState.Speed * weight;
					}
				}
			}
			if (num2 < MinimumSynchronizeChildrenWeight)
			{
				num3 = 0f;
				num4 = 0f;
				int num5 = 0;
				for (int j = 0; j < count; j++)
				{
					AnimancerState animancerState2 = _SynchronizedChildren[j];
					float length2 = animancerState2.Length;
					if (length2 != 0f)
					{
						length2 = 1f / length2;
						num3 += animancerState2.Time * length2;
						num4 += animancerState2.Speed * length2;
						num5++;
					}
				}
				num2 = num5;
			}
			num3 += num * num4;
			num3 /= num2;
			float num6 = 1f / num;
			for (int k = 0; k < count; k++)
			{
				AnimancerState animancerState3 = _SynchronizedChildren[k];
				float length3 = animancerState3.Length;
				if (length3 != 0f)
				{
					float num7 = animancerState3.Time / length3;
					float num8 = (num3 - num7) * length3 * num6;
					animancerState3._Playable.SetSpeed(num8);
				}
			}
		}

		public float CalculateRealEffectiveSpeed()
		{
			double num = _Playable.GetSpeed();
			for (IPlayableWrapper parent = Parent; parent != null; parent = parent.Parent)
			{
				num *= parent.Playable.GetSpeed();
			}
			return (float)num;
		}

		public static float CalculateTotalWeight(AnimancerState[] states, int count)
		{
			float num = 0f;
			for (int num2 = count - 1; num2 >= 0; num2--)
			{
				num += states[num2].Weight;
			}
			return num;
		}

		public void SetChildrenTime(float value, bool normalized = false)
		{
			for (int num = _ChildCount - 1; num >= 0; num--)
			{
				AnimancerState animancerState = ChildStates[num];
				if (normalized)
				{
					animancerState.NormalizedTime = value;
				}
				else
				{
					animancerState.Time = value;
				}
			}
		}

		protected void DisableRemainingStates(int previousIndex)
		{
			for (int i = previousIndex + 1; i < _ChildCount; i++)
			{
				ChildStates[i].Weight = 0f;
			}
		}

		public void NormalizeWeights(float totalWeight)
		{
			if (totalWeight != 1f)
			{
				totalWeight = 1f / totalWeight;
				for (int num = _ChildCount - 1; num >= 0; num--)
				{
					ChildStates[num].Weight *= totalWeight;
				}
			}
		}

		public virtual string GetDisplayKey(AnimancerState state)
		{
			return $"[{state.Index}]";
		}

		public void NormalizeDurations()
		{
			int num = 0;
			float num2 = 0f;
			for (int i = 0; i < _ChildCount; i++)
			{
				num++;
				num2 += ChildStates[i].Duration;
			}
			num2 /= (float)num;
			for (int j = 0; j < _ChildCount; j++)
			{
				ChildStates[j].Duration = num2;
			}
		}

		public override string ToString()
		{
			List<string> list = ObjectPool.AcquireList<string>();
			bool flag = true;
			for (int i = 0; i < _ChildCount; i++)
			{
				AnimancerState animancerState = ChildStates[i];
				if (animancerState != null)
				{
					if (animancerState.MainObject != null)
					{
						list.Add(animancerState.MainObject.name);
						continue;
					}
					list.Add(animancerState.ToString());
					flag = false;
				}
			}
			int num = 0;
			int count = list.Count;
			if (count <= 1 || !flag)
			{
				num = 0;
			}
			else
			{
				string text = list[0];
				int num2 = (num = text.Length);
				for (int j = 0; j < count; j++)
				{
					string text2 = list[j];
					if (num2 > text2.Length)
					{
						num2 = (num = text2.Length);
					}
					for (int k = 0; k < num; k++)
					{
						if (text2[k] != text[k])
						{
							num = k;
							break;
						}
					}
				}
				if (num < 3 || num >= num2)
				{
					num = 0;
				}
			}
			StringBuilder stringBuilder = ObjectPool.AcquireStringBuilder();
			if (count > 0)
			{
				if (num > 0)
				{
					stringBuilder.Append(list[0], 0, num).Append('[');
				}
				for (int l = 0; l < count; l++)
				{
					if (l > 0)
					{
						stringBuilder.Append(", ");
					}
					string text3 = list[l];
					stringBuilder.Append(text3, num, text3.Length - num);
				}
				stringBuilder.Append((num > 0) ? "] (" : " (");
			}
			ObjectPool.Release(list);
			string fullName = GetType().FullName;
			if (fullName.EndsWith("State"))
			{
				stringBuilder.Append(fullName, 0, fullName.Length - 5);
			}
			else
			{
				stringBuilder.Append(fullName);
			}
			if (count > 0)
			{
				stringBuilder.Append(')');
			}
			return stringBuilder.ReleaseToString();
		}

		protected override void AppendDetails(StringBuilder text, string separator)
		{
			base.AppendDetails(text, separator);
			text.Append(separator).Append("SynchronizedChildren: ");
			if (SynchronizedChildCount == 0)
			{
				text.Append("0");
				return;
			}
			text.Append(_SynchronizedChildren.Count);
			separator += "    ";
			for (int i = 0; i < _SynchronizedChildren.Count; i++)
			{
				text.Append(separator).Append(_SynchronizedChildren[i]);
			}
		}

		public override void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			clips.GatherFromSource(ChildStates);
		}

		protected virtual string GetParameterName(int index)
		{
			throw new NotSupportedException();
		}

		protected virtual AnimatorControllerParameterType GetParameterType(int index)
		{
			throw new NotSupportedException();
		}

		protected virtual object GetParameterValue(int index)
		{
			throw new NotSupportedException();
		}

		protected virtual void SetParameterValue(int index, object value)
		{
			throw new NotSupportedException();
		}
	}
}
