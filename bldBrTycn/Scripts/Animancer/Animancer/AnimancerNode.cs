using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine.Playables;

namespace Animancer
{
	public abstract class AnimancerNode : Key, IUpdatable, Key.IListItem, IEnumerable<AnimancerState>, IEnumerable, IEnumerator, IPlayableWrapper, ICopyable<AnimancerNode>
	{
		protected internal Playable _Playable;

		private AnimancerPlayable _Root;

		private float _Weight;

		private bool _IsWeightDirty = true;

		private float _Speed = 1f;

		public Playable Playable => _Playable;

		public bool IsValid => _Playable.IsValid();

		public AnimancerPlayable Root
		{
			get
			{
				return _Root;
			}
			internal set
			{
				_Root = value;
			}
		}

		public abstract AnimancerLayer Layer { get; }

		public abstract IPlayableWrapper Parent { get; }

		public int Index { get; internal set; } = int.MinValue;

		object IEnumerator.Current => null;

		public virtual int ChildCount => 0;

		public virtual bool KeepChildrenConnected => false;

		public float Weight
		{
			get
			{
				return _Weight;
			}
			set
			{
				SetWeight(value);
				TargetWeight = value;
				FadeSpeed = 0f;
			}
		}

		public float EffectiveWeight
		{
			get
			{
				float num = Weight;
				for (IPlayableWrapper parent = Parent; parent != null; parent = parent.Parent)
				{
					num *= parent.Weight;
				}
				return num;
			}
		}

		public float TargetWeight { get; set; }

		public float FadeSpeed { get; set; }

		public float Speed
		{
			get
			{
				return _Speed;
			}
			set
			{
				if (_Speed != value)
				{
					_Speed = value;
					if (_Playable.IsValid())
					{
						_Playable.SetSpeed(value);
					}
				}
			}
		}

		private float ParentEffectiveSpeed
		{
			get
			{
				IPlayableWrapper parent = Parent;
				if (parent == null)
				{
					return 1f;
				}
				float num = parent.Speed;
				while ((parent = parent.Parent) != null)
				{
					num *= parent.Speed;
				}
				return num;
			}
		}

		public float EffectiveSpeed
		{
			get
			{
				return Speed * ParentEffectiveSpeed;
			}
			set
			{
				Speed = value / ParentEffectiveSpeed;
			}
		}

		public static bool ApplyParentAnimatorIK { get; set; } = true;

		public static bool ApplyParentFootIK { get; set; } = true;

		public virtual bool ApplyAnimatorIK
		{
			get
			{
				for (int num = ChildCount - 1; num >= 0; num--)
				{
					AnimancerState child = GetChild(num);
					if (child != null && child.ApplyAnimatorIK)
					{
						return true;
					}
				}
				return false;
			}
			set
			{
				for (int num = ChildCount - 1; num >= 0; num--)
				{
					AnimancerState child = GetChild(num);
					if (child != null)
					{
						child.ApplyAnimatorIK = value;
					}
				}
			}
		}

		public virtual bool ApplyFootIK
		{
			get
			{
				for (int num = ChildCount - 1; num >= 0; num--)
				{
					AnimancerState child = GetChild(num);
					if (child != null && child.ApplyFootIK)
					{
						return true;
					}
				}
				return false;
			}
			set
			{
				for (int num = ChildCount - 1; num >= 0; num--)
				{
					AnimancerState child = GetChild(num);
					if (child != null)
					{
						child.ApplyFootIK = value;
					}
				}
			}
		}

		public virtual void CreatePlayable()
		{
			CreatePlayable(out _Playable);
			if (_Speed != 1f)
			{
				_Playable.SetSpeed(_Speed);
			}
			IPlayableWrapper parent = Parent;
			if (parent != null)
			{
				ApplyConnectedState(parent);
			}
		}

		protected abstract void CreatePlayable(out Playable playable);

		public void DestroyPlayable()
		{
			if (_Playable.IsValid())
			{
				Root._Graph.DestroyPlayable(_Playable);
			}
		}

		public virtual void RecreatePlayable()
		{
			DestroyPlayable();
			CreatePlayable();
		}

		public void RecreatePlayableRecursive()
		{
			RecreatePlayable();
			for (int num = ChildCount - 1; num >= 0; num--)
			{
				GetChild(num)?.RecreatePlayableRecursive();
			}
		}

		void ICopyable<AnimancerNode>.CopyFrom(AnimancerNode copyFrom)
		{
			_Weight = copyFrom._Weight;
			_IsWeightDirty = true;
			TargetWeight = copyFrom.TargetWeight;
			FadeSpeed = copyFrom.FadeSpeed;
			Speed = copyFrom.Speed;
			CopyIKFlags(copyFrom);
		}

		internal void ConnectToGraph()
		{
			IPlayableWrapper parent = Parent;
			if (parent != null)
			{
				Playable playable = parent.Playable;
				Root._Graph.Connect(_Playable, 0, playable, Index);
				playable.SetInputWeight(Index, _Weight);
				_IsWeightDirty = false;
			}
		}

		internal void DisconnectFromGraph()
		{
			IPlayableWrapper parent = Parent;
			if (parent != null)
			{
				Playable playable = parent.Playable;
				if (playable.GetInput(Index).IsValid())
				{
					Root._Graph.Disconnect(playable, Index);
				}
			}
		}

		private void ApplyConnectedState(IPlayableWrapper parent)
		{
			_IsWeightDirty = true;
			if (_Weight != 0f || parent.KeepChildrenConnected)
			{
				ConnectToGraph();
			}
			else
			{
				Root.RequirePreUpdate(this);
			}
		}

		protected void RequireUpdate()
		{
			Root?.RequirePreUpdate(this);
		}

		void IUpdatable.Update()
		{
			if (_Playable.IsValid())
			{
				Update(out var needsMoreUpdates);
				if (needsMoreUpdates)
				{
					return;
				}
			}
			Root.CancelPreUpdate(this);
		}

		protected internal virtual void Update(out bool needsMoreUpdates)
		{
			UpdateFade(out needsMoreUpdates);
			ApplyWeight();
		}

		public abstract bool IsPlayingAndNotEnding();

		bool IEnumerator.MoveNext()
		{
			return IsPlayingAndNotEnding();
		}

		void IEnumerator.Reset()
		{
		}

		AnimancerNode IPlayableWrapper.GetChild(int index)
		{
			return GetChild(index);
		}

		public virtual AnimancerState GetChild(int index)
		{
			throw new NotSupportedException(this?.ToString() + " can't have children.");
		}

		protected internal virtual void OnAddChild(AnimancerState state)
		{
			state.SetParentInternal(null);
			throw new NotSupportedException(this?.ToString() + " can't have children.");
		}

		protected internal virtual void OnRemoveChild(AnimancerState state)
		{
			state.SetParentInternal(null);
			throw new NotSupportedException(this?.ToString() + " can't have children.");
		}

		protected void OnAddChild(IList<AnimancerState> states, AnimancerState state)
		{
			int index = state.Index;
			if (states[index] != null)
			{
				state.SetParentInternal(null);
				throw new InvalidOperationException($"Tried to add a state to an already occupied port on {this}:" + string.Format("\n• {0}: {1}", "Index", index) + $"\n• Old State: {states[index]} " + $"\n• New State: {state}");
			}
			states[index] = state;
			if (Root != null)
			{
				state.ApplyConnectedState(this);
			}
		}

		internal void ConnectAllChildrenToGraph()
		{
			if (!Parent.Playable.GetInput(Index).IsValid())
			{
				ConnectToGraph();
			}
			for (int num = ChildCount - 1; num >= 0; num--)
			{
				GetChild(num)?.ConnectAllChildrenToGraph();
			}
		}

		internal void DisconnectWeightlessChildrenFromGraph()
		{
			if (Weight == 0f)
			{
				DisconnectFromGraph();
			}
			for (int num = ChildCount - 1; num >= 0; num--)
			{
				GetChild(num)?.DisconnectWeightlessChildrenFromGraph();
			}
		}

		public virtual FastEnumerator<AnimancerState> GetEnumerator()
		{
			return default(FastEnumerator<AnimancerState>);
		}

		IEnumerator<AnimancerState> IEnumerable<AnimancerState>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void SetWeight(float value)
		{
			if (_Weight != value)
			{
				_Weight = value;
				SetWeightDirty();
			}
		}

		protected internal void SetWeightDirty()
		{
			_IsWeightDirty = true;
			RequireUpdate();
		}

		public void ApplyWeight()
		{
			if (!_IsWeightDirty)
			{
				return;
			}
			_IsWeightDirty = false;
			IPlayableWrapper parent = Parent;
			if (parent == null)
			{
				return;
			}
			Playable playable;
			if (!parent.KeepChildrenConnected)
			{
				if (_Weight == 0f)
				{
					DisconnectFromGraph();
					return;
				}
				playable = parent.Playable;
				if (!playable.GetInput(Index).IsValid())
				{
					ConnectToGraph();
				}
			}
			else
			{
				playable = parent.Playable;
			}
			playable.SetInputWeight(Index, _Weight);
		}

		public void StartFade(float targetWeight)
		{
			StartFade(targetWeight, AnimancerPlayable.DefaultFadeDuration);
		}

		public void StartFade(float targetWeight, float fadeDuration)
		{
			TargetWeight = targetWeight;
			if (targetWeight == Weight)
			{
				if (targetWeight == 0f)
				{
					Stop();
					return;
				}
				FadeSpeed = 0f;
				OnStartFade();
				return;
			}
			if (fadeDuration <= 0f)
			{
				FadeSpeed = float.PositiveInfinity;
			}
			else
			{
				FadeSpeed = Math.Abs(Weight - targetWeight) / fadeDuration;
			}
			OnStartFade();
			RequireUpdate();
		}

		protected internal abstract void OnStartFade();

		public virtual void Stop()
		{
			Weight = 0f;
		}

		private void UpdateFade(out bool needsMoreUpdates)
		{
			float fadeSpeed = FadeSpeed;
			if (fadeSpeed == 0f)
			{
				needsMoreUpdates = false;
				return;
			}
			_IsWeightDirty = true;
			fadeSpeed *= ParentEffectiveSpeed * AnimancerPlayable.DeltaTime;
			if (fadeSpeed < 0f)
			{
				fadeSpeed = 0f - fadeSpeed;
			}
			float targetWeight = TargetWeight;
			float weight = _Weight;
			float num = targetWeight - weight;
			if (num > 0f)
			{
				if (num > fadeSpeed)
				{
					_Weight = weight + fadeSpeed;
					needsMoreUpdates = true;
					return;
				}
			}
			else if (0f - num > fadeSpeed)
			{
				_Weight = weight - fadeSpeed;
				needsMoreUpdates = true;
				return;
			}
			_Weight = targetWeight;
			needsMoreUpdates = false;
			if (targetWeight == 0f)
			{
				Stop();
			}
			else
			{
				FadeSpeed = 0f;
			}
		}

		public virtual void CopyIKFlags(AnimancerNode copyFrom)
		{
			if (Root != null)
			{
				if (ApplyParentAnimatorIK)
				{
					ApplyAnimatorIK = copyFrom.ApplyAnimatorIK;
				}
				if (ApplyParentFootIK)
				{
					ApplyFootIK = copyFrom.ApplyFootIK;
				}
			}
		}

		public override string ToString()
		{
			return base.ToString();
		}

		[Conditional("UNITY_ASSERTIONS")]
		public void SetDebugName(string name)
		{
		}

		public string GetDescription(string separator = "\n")
		{
			StringBuilder stringBuilder = ObjectPool.AcquireStringBuilder();
			AppendDescription(stringBuilder, separator);
			return stringBuilder.ReleaseToString();
		}

		public void AppendDescription(StringBuilder text, string separator = "\n")
		{
			text.Append(ToString());
			AppendDetails(text, separator);
			if (ChildCount <= 0)
			{
				return;
			}
			text.Append(separator).Append("ChildCount: ").Append(ChildCount);
			string separator2 = separator + "    ";
			int num = 0;
			using FastEnumerator<AnimancerState> fastEnumerator = GetEnumerator();
			while (fastEnumerator.MoveNext())
			{
				AnimancerState current = fastEnumerator.Current;
				text.Append(separator).Append('[').Append(num++)
					.Append("] ");
				if (current != null)
				{
					current.AppendDescription(text, separator2);
				}
				else
				{
					text.Append("null");
				}
			}
		}

		protected virtual void AppendDetails(StringBuilder text, string separator)
		{
			text.Append(separator).Append("Playable: ");
			if (_Playable.IsValid())
			{
				text.Append(_Playable.GetPlayableType());
			}
			else
			{
				text.Append("Invalid");
			}
			text.Append(separator).Append("Index: ").Append(Index);
			double num = (_Playable.IsValid() ? _Playable.GetSpeed() : ((double)_Speed));
			if (num == (double)_Speed)
			{
				text.Append(separator).Append("Speed: ").Append(_Speed);
			}
			else
			{
				text.Append(separator).Append("Speed (Real): ").Append(_Speed)
					.Append(" (")
					.Append(num)
					.Append(')');
			}
			text.Append(separator).Append("Weight: ").Append(Weight);
			if (Weight != TargetWeight)
			{
				text.Append(separator).Append("TargetWeight: ").Append(TargetWeight);
				text.Append(separator).Append("FadeSpeed: ").Append(FadeSpeed);
			}
			AppendIKDetails(text, separator, this);
		}

		public static void AppendIKDetails(StringBuilder text, string separator, IPlayableWrapper node)
		{
			if (!node.Playable.IsValid())
			{
				return;
			}
			text.Append(separator).Append("InverseKinematics: ");
			if (node.ApplyAnimatorIK)
			{
				text.Append("OnAnimatorIK");
				if (node.ApplyFootIK)
				{
					text.Append(", FootIK");
				}
			}
			else if (node.ApplyFootIK)
			{
				text.Append("FootIK");
			}
			else
			{
				text.Append("None");
			}
		}
	}
}
