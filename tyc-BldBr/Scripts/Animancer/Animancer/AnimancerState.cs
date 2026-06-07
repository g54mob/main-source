using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;

namespace Animancer
{
	public abstract class AnimancerState : AnimancerNode, IAnimationClipCollection, ICopyable<AnimancerState>
	{
		public class DelayedPause : Key, IUpdatable, IListItem
		{
			public AnimancerPlayable Root { get; set; }

			public AnimancerState State { get; set; }

			public static void Register(AnimancerState state)
			{
				AnimancerPlayable root = state.Root;
				if (root != null)
				{
					DelayedPause delayedPause = ObjectPool.Acquire<DelayedPause>();
					delayedPause.Root = root;
					delayedPause.State = state;
					root.RequirePostUpdate(delayedPause);
				}
			}

			public void Update()
			{
				if (!State.IsPlaying)
				{
					State._Playable.Pause();
				}
				Root.CancelPostUpdate(this);
				Root = null;
				State = null;
				ObjectPool.Release(this);
			}
		}

		public class EventDispatcher : Key, IUpdatable, IListItem
		{
			private AnimancerState _State;

			private AnimancerEvent.Sequence _Events;

			private bool _GotEventsFromPool;

			private bool _IsLooping;

			private float _PreviousTime;

			private int _NextEventIndex = int.MinValue;

			private int _SequenceVersion;

			private bool _WasPlayingForwards;

			private const int RecalculateEventIndex = int.MinValue;

			private const string SequenceVersionException = "AnimancerState.Events sequence was modified while iterating through it. Events in a sequence must not modify that sequence.";

			public bool HasEvents => _Events != null;

			internal AnimancerEvent.Sequence Events
			{
				get
				{
					if (_Events == null)
					{
						ObjectPool.Acquire<AnimancerEvent.Sequence>(out _Events);
						_GotEventsFromPool = true;
					}
					return _Events;
				}
				set
				{
					if (_GotEventsFromPool)
					{
						_Events.Clear();
						ObjectPool.Release(_Events);
						_GotEventsFromPool = false;
					}
					_Events = value;
					_NextEventIndex = int.MinValue;
				}
			}

			internal static void Acquire(AnimancerState state)
			{
				ref EventDispatcher eventDispatcher = ref state._EventDispatcher;
				if (eventDispatcher == null)
				{
					ObjectPool.Acquire<EventDispatcher>(out eventDispatcher);
					eventDispatcher._IsLooping = state.IsLooping;
					eventDispatcher._PreviousTime = state.NormalizedTime;
					eventDispatcher._State = state;
					state.Root?.RequirePostUpdate(eventDispatcher);
				}
			}

			private void Release()
			{
				if (_State != null)
				{
					_State.Root?.CancelPostUpdate(this);
					_State._EventDispatcher = null;
					_State = null;
					Events = null;
					ObjectPool.Release(this);
				}
			}

			internal static void TryClear(EventDispatcher events)
			{
				if (events != null)
				{
					events.Events = null;
				}
			}

			void IUpdatable.Update()
			{
				if (_Events == null || _Events.IsEmpty)
				{
					Release();
					return;
				}
				float length = _State.Length;
				if (length == 0f)
				{
					UpdateZeroLength();
					return;
				}
				float num = _State.Time / length;
				if (_PreviousTime == num)
				{
					return;
				}
				CheckGeneralEvents(num);
				if (_Events == null)
				{
					Release();
					return;
				}
				AnimancerEvent endEvent = _Events.EndEvent;
				if (endEvent.callback != null)
				{
					if (num > _PreviousTime)
					{
						float num2 = (float.IsNaN(endEvent.normalizedTime) ? 1f : endEvent.normalizedTime);
						if (num > num2)
						{
							endEvent.Invoke(_State);
						}
					}
					else
					{
						float num3 = (float.IsNaN(endEvent.normalizedTime) ? 0f : endEvent.normalizedTime);
						if (num < num3)
						{
							endEvent.Invoke(_State);
						}
					}
				}
				if (_NextEventIndex != int.MinValue)
				{
					_PreviousTime = num;
				}
			}

			[Conditional("UNITY_ASSERTIONS")]
			private void ValidateBeforeEndEvent()
			{
			}

			[Conditional("UNITY_ASSERTIONS")]
			private void ValidateAfterEndEvent(Action callback)
			{
			}

			internal void OnTimeChanged()
			{
				_PreviousTime = _State.NormalizedTime;
				_NextEventIndex = int.MinValue;
			}

			private void UpdateZeroLength()
			{
				float effectiveSpeed = _State.EffectiveSpeed;
				if (effectiveSpeed == 0f)
				{
					return;
				}
				if (_Events.Count > 0)
				{
					int version = _Events.Version;
					int playDirectionInt;
					if (effectiveSpeed < 0f)
					{
						playDirectionInt = -1;
						if (_NextEventIndex == int.MinValue || _SequenceVersion != version || _WasPlayingForwards)
						{
							_NextEventIndex = Events.Count - 1;
							_SequenceVersion = version;
							_WasPlayingForwards = false;
						}
					}
					else
					{
						playDirectionInt = 1;
						if (_NextEventIndex == int.MinValue || _SequenceVersion != version || !_WasPlayingForwards)
						{
							_NextEventIndex = 0;
							_SequenceVersion = version;
							_WasPlayingForwards = true;
						}
					}
					if (!InvokeAllEvents(1, playDirectionInt))
					{
						return;
					}
				}
				AnimancerEvent endEvent = _Events.EndEvent;
				if (endEvent.callback != null)
				{
					endEvent.Invoke(_State);
				}
			}

			private void CheckGeneralEvents(float currentTime)
			{
				int count = _Events.Count;
				if (count == 0)
				{
					_NextEventIndex = 0;
					return;
				}
				ValidateNextEventIndex(ref currentTime, out var playDirectionFloat, out var playDirectionInt);
				if (_IsLooping)
				{
					AnimancerEvent animancerEvent = _Events[_NextEventIndex];
					float eventTime = animancerEvent.normalizedTime * playDirectionFloat;
					int loopDelta = GetLoopDelta(_PreviousTime, currentTime, eventTime);
					if (loopDelta == 0 || !InvokeAllEvents(loopDelta - 1, playDirectionInt))
					{
						return;
					}
					int nextEventIndex = _NextEventIndex;
					do
					{
						animancerEvent.Invoke(_State);
						if (!NextEventLooped(playDirectionInt) || _NextEventIndex == nextEventIndex)
						{
							break;
						}
						animancerEvent = _Events[_NextEventIndex];
						eventTime = animancerEvent.normalizedTime * playDirectionFloat;
					}
					while (loopDelta == GetLoopDelta(_PreviousTime, currentTime, eventTime));
					return;
				}
				while ((uint)_NextEventIndex < (uint)count)
				{
					AnimancerEvent animancerEvent2 = _Events[_NextEventIndex];
					float num = animancerEvent2.normalizedTime * playDirectionFloat;
					if (currentTime <= num)
					{
						break;
					}
					animancerEvent2.Invoke(_State);
					if (!NextEvent(playDirectionInt))
					{
						break;
					}
				}
			}

			private void ValidateNextEventIndex(ref float currentTime, out float playDirectionFloat, out int playDirectionInt)
			{
				int version = _Events.Version;
				if (currentTime < _PreviousTime)
				{
					float num = _PreviousTime;
					_PreviousTime = 0f - num;
					currentTime = 0f - currentTime;
					playDirectionFloat = -1f;
					playDirectionInt = -1;
					if (_NextEventIndex != int.MinValue && _SequenceVersion == version && !_WasPlayingForwards)
					{
						return;
					}
					_NextEventIndex = _Events.Count - 1;
					_SequenceVersion = version;
					_WasPlayingForwards = false;
					if (_IsLooping)
					{
						num = AnimancerUtilities.Wrap01(num);
					}
					while (_Events[_NextEventIndex].normalizedTime > num)
					{
						_NextEventIndex--;
						if (_NextEventIndex < 0)
						{
							if (_IsLooping)
							{
								_NextEventIndex = _Events.Count - 1;
							}
							break;
						}
					}
					return;
				}
				playDirectionFloat = 1f;
				playDirectionInt = 1;
				if (_NextEventIndex != int.MinValue && _SequenceVersion == version && _WasPlayingForwards)
				{
					return;
				}
				_NextEventIndex = 0;
				_SequenceVersion = version;
				_WasPlayingForwards = true;
				float num2 = _PreviousTime;
				if (_IsLooping)
				{
					num2 = AnimancerUtilities.Wrap01(num2);
				}
				int num3 = _Events.Count - 1;
				while (_Events[_NextEventIndex].normalizedTime < num2)
				{
					_NextEventIndex++;
					if (_NextEventIndex > num3)
					{
						if (_IsLooping)
						{
							_NextEventIndex = 0;
						}
						break;
					}
				}
			}

			private static int GetLoopDelta(float previousTime, float nextTime, float eventTime)
			{
				previousTime -= eventTime;
				nextTime -= eventTime;
				int num = Mathf.FloorToInt(previousTime);
				int num2 = Mathf.FloorToInt(nextTime);
				int num3 = num2 - num;
				if (previousTime == (float)num)
				{
					num3++;
				}
				if (nextTime == (float)num2)
				{
					num3--;
				}
				return num3;
			}

			private bool InvokeAllEvents(int count, int playDirectionInt)
			{
				int nextEventIndex = _NextEventIndex;
				while (count-- > 0)
				{
					do
					{
						_Events[_NextEventIndex].Invoke(_State);
						if (!NextEventLooped(playDirectionInt))
						{
							return false;
						}
					}
					while (_NextEventIndex != nextEventIndex);
				}
				return true;
			}

			private bool NextEvent(int playDirectionInt)
			{
				if (_NextEventIndex == int.MinValue)
				{
					return false;
				}
				if (_Events.Version != _SequenceVersion)
				{
					throw new InvalidOperationException("AnimancerState.Events sequence was modified while iterating through it. Events in a sequence must not modify that sequence.");
				}
				_NextEventIndex += playDirectionInt;
				return true;
			}

			private bool NextEventLooped(int playDirectionInt)
			{
				if (!NextEvent(playDirectionInt))
				{
					return false;
				}
				int count = _Events.Count;
				if (_NextEventIndex >= count)
				{
					_NextEventIndex = 0;
				}
				else if (_NextEventIndex < 0)
				{
					_NextEventIndex = count - 1;
				}
				return true;
			}

			public override string ToString()
			{
				if (_State == null)
				{
					return "EventDispatcher (No Target State)";
				}
				return string.Format("{0} ({1})", "EventDispatcher", _State);
			}
		}

		private AnimancerNode _Parent;

		internal object _Key;

		private bool _IsPlaying;

		private bool _IsPlayingDirty = true;

		private double _Time;

		private bool _MustSetTime;

		private ulong _TimeFrameID;

		private EventDispatcher _EventDispatcher;

		public sealed override IPlayableWrapper Parent => _Parent;

		public override AnimancerLayer Layer => _Parent?.Layer;

		public int LayerIndex
		{
			get
			{
				if (_Parent == null)
				{
					return -1;
				}
				return _Parent.Layer?.Index ?? (-1);
			}
			set
			{
				base.Root.Layers[value].AddChild(this);
			}
		}

		public object Key
		{
			get
			{
				return _Key;
			}
			set
			{
				if (base.Root == null)
				{
					_Key = value;
					return;
				}
				base.Root.States.Unregister(this);
				_Key = value;
				base.Root.States.Register(this);
			}
		}

		public virtual AnimationClip Clip
		{
			get
			{
				return null;
			}
			set
			{
				throw new NotSupportedException(string.Format("{0} does not support setting the {1}.", GetType(), "Clip"));
			}
		}

		public virtual UnityEngine.Object MainObject
		{
			get
			{
				return null;
			}
			set
			{
				throw new NotSupportedException(string.Format("{0} does not support setting the {1}.", GetType(), "MainObject"));
			}
		}

		public virtual Vector3 AverageVelocity => default(Vector3);

		public bool IsPlaying
		{
			get
			{
				return _IsPlaying;
			}
			set
			{
				if (_IsPlaying != value)
				{
					_IsPlaying = value;
					if (_IsPlayingDirty)
					{
						_IsPlayingDirty = false;
					}
					else
					{
						_IsPlayingDirty = true;
						RequireUpdate();
					}
					OnSetIsPlaying();
				}
			}
		}

		public bool IsActive
		{
			get
			{
				if (_IsPlaying)
				{
					return base.TargetWeight > 0f;
				}
				return false;
			}
		}

		public bool IsStopped
		{
			get
			{
				if (!_IsPlaying)
				{
					return base.Weight == 0f;
				}
				return false;
			}
		}

		public float Time
		{
			get
			{
				return (float)TimeD;
			}
			set
			{
				TimeD = value;
			}
		}

		public double TimeD
		{
			get
			{
				AnimancerPlayable root = base.Root;
				if (root == null || _MustSetTime)
				{
					return _Time;
				}
				ulong frameID = root.FrameID;
				if (_TimeFrameID != frameID)
				{
					_TimeFrameID = frameID;
					_Time = RawTime;
				}
				return _Time;
			}
			set
			{
				_Time = value;
				AnimancerPlayable root = base.Root;
				if (root == null)
				{
					_MustSetTime = true;
				}
				else
				{
					_TimeFrameID = root.FrameID;
					if (AnimancerPlayable.IsRunningPostUpdate(root))
					{
						_MustSetTime = true;
						root.RequirePreUpdate(this);
					}
					else
					{
						RawTime = value;
					}
				}
				_EventDispatcher?.OnTimeChanged();
			}
		}

		public virtual double RawTime
		{
			get
			{
				return _Playable.GetTime();
			}
			set
			{
				_Playable.SetTime(value);
				_Playable.SetTime(value);
			}
		}

		public float NormalizedTime
		{
			get
			{
				return (float)NormalizedTimeD;
			}
			set
			{
				NormalizedTimeD = value;
			}
		}

		public double NormalizedTimeD
		{
			get
			{
				if (Length != 0f)
				{
					return TimeD / (double)Length;
				}
				return 0.0;
			}
			set
			{
				TimeD = value * (double)Length;
			}
		}

		public float NormalizedEndTime
		{
			get
			{
				if (_EventDispatcher != null)
				{
					float normalizedEndTime = _EventDispatcher.Events.NormalizedEndTime;
					if (!float.IsNaN(normalizedEndTime))
					{
						return normalizedEndTime;
					}
				}
				return AnimancerEvent.Sequence.GetDefaultNormalizedEndTime(base.EffectiveSpeed);
			}
			set
			{
				Events.NormalizedEndTime = value;
			}
		}

		public float Duration
		{
			get
			{
				float effectiveSpeed = base.EffectiveSpeed;
				if (_EventDispatcher != null)
				{
					float normalizedEndTime = _EventDispatcher.Events.NormalizedEndTime;
					if (!float.IsNaN(normalizedEndTime))
					{
						if (effectiveSpeed > 0f)
						{
							return Length * normalizedEndTime / effectiveSpeed;
						}
						return Length * (1f - normalizedEndTime) / (0f - effectiveSpeed);
					}
				}
				return Length / Math.Abs(effectiveSpeed);
			}
			set
			{
				float num = Length;
				if (_EventDispatcher != null)
				{
					float normalizedEndTime = _EventDispatcher.Events.NormalizedEndTime;
					if (!float.IsNaN(normalizedEndTime))
					{
						num = ((!(base.EffectiveSpeed > 0f)) ? (num * (1f - normalizedEndTime)) : (num * normalizedEndTime));
					}
				}
				base.EffectiveSpeed = num / value;
			}
		}

		public float RemainingDuration
		{
			get
			{
				return (Length * NormalizedEndTime - Time) / base.EffectiveSpeed;
			}
			set
			{
				base.EffectiveSpeed = (Length * NormalizedEndTime - Time) / value;
			}
		}

		public abstract float Length { get; }

		public virtual bool IsLooping => false;

		public AnimancerEvent.Sequence Events
		{
			get
			{
				EventDispatcher.Acquire(this);
				return _EventDispatcher.Events;
			}
			set
			{
				if (value != null)
				{
					EventDispatcher.Acquire(this);
					_EventDispatcher.Events = value;
				}
				else if (_EventDispatcher != null)
				{
					_EventDispatcher.Events = null;
				}
			}
		}

		public bool HasEvents
		{
			get
			{
				if (_EventDispatcher != null)
				{
					return _EventDispatcher.HasEvents;
				}
				return false;
			}
		}

		public static bool AutomaticallyClearEvents { get; set; } = true;

		public void SetRoot(AnimancerPlayable root)
		{
			if (base.Root == root)
			{
				return;
			}
			if (base.Root != null)
			{
				base.Root.CancelPreUpdate(this);
				base.Root.States.Unregister(this);
				if (_EventDispatcher != null)
				{
					base.Root.CancelPostUpdate(_EventDispatcher);
				}
				if (_Parent != null && _Parent.Root != root)
				{
					_Parent.OnRemoveChild(this);
					_Parent = null;
					base.Index = -1;
				}
				DestroyPlayable();
			}
			base.Root = root;
			if (root != null)
			{
				root.States.Register(this);
				if (_EventDispatcher != null)
				{
					root.RequirePostUpdate(_EventDispatcher);
				}
				CreatePlayable();
			}
			for (int num = ChildCount - 1; num >= 0; num--)
			{
				GetChild(num)?.SetRoot(root);
			}
			if (_Parent != null)
			{
				CopyIKFlags(_Parent);
			}
		}

		public void SetParent(AnimancerNode parent, int index)
		{
			if (_Parent != null)
			{
				_Parent.OnRemoveChild(this);
				_Parent = null;
			}
			if (parent == null)
			{
				base.Index = -1;
				return;
			}
			SetRoot(parent.Root);
			base.Index = index;
			_Parent = parent;
			parent.OnAddChild(this);
			CopyIKFlags(parent);
		}

		internal void SetParentInternal(AnimancerNode parent, int index = -1)
		{
			_Parent = parent;
			base.Index = index;
		}

		protected void ChangeMainObject<T>(ref T currentObject, T newObject) where T : UnityEngine.Object
		{
			if (newObject == null)
			{
				throw new ArgumentNullException("newObject");
			}
			if ((object)currentObject != newObject)
			{
				if (_Key == currentObject)
				{
					Key = newObject;
				}
				currentObject = newObject;
				RecreatePlayable();
			}
		}

		protected virtual void OnSetIsPlaying()
		{
		}

		public sealed override void CreatePlayable()
		{
			base.CreatePlayable();
			if (_MustSetTime)
			{
				_MustSetTime = false;
				RawTime = _Time;
			}
			if (!_IsPlaying)
			{
				_Playable.Pause();
			}
			_IsPlayingDirty = false;
		}

		public void Play()
		{
			IsPlaying = true;
			base.Weight = 1f;
			if (AutomaticallyClearEvents)
			{
				EventDispatcher.TryClear(_EventDispatcher);
			}
		}

		public override void Stop()
		{
			base.Stop();
			IsPlaying = false;
			TimeD = 0.0;
			if (AutomaticallyClearEvents)
			{
				EventDispatcher.TryClear(_EventDispatcher);
			}
		}

		protected internal override void OnStartFade()
		{
			if (AutomaticallyClearEvents)
			{
				EventDispatcher.TryClear(_EventDispatcher);
			}
		}

		public void MoveTime(float time, bool normalized)
		{
			MoveTime((double)time, normalized);
		}

		public virtual void MoveTime(double time, bool normalized)
		{
			AnimancerPlayable root = base.Root;
			if (root != null)
			{
				_TimeFrameID = root.FrameID;
			}
			if (normalized)
			{
				time *= (double)Length;
			}
			_Time = time;
			_Playable.SetTime(time);
		}

		protected void CancelSetTime()
		{
			_MustSetTime = false;
		}

		protected internal override void Update(out bool needsMoreUpdates)
		{
			base.Update(out needsMoreUpdates);
			if (_IsPlayingDirty)
			{
				_IsPlayingDirty = false;
				if (_IsPlaying)
				{
					_Playable.Play();
				}
				else
				{
					_Playable.Pause();
				}
			}
			if (_MustSetTime)
			{
				_MustSetTime = false;
				RawTime = _Time;
			}
		}

		public virtual void Destroy()
		{
			if (_Parent != null)
			{
				_Parent.OnRemoveChild(this);
				_Parent = null;
			}
			base.Index = -1;
			EventDispatcher.TryClear(_EventDispatcher);
			AnimancerPlayable root = base.Root;
			if (root != null)
			{
				root.States.Unregister(this);
				if (_Playable.IsValid())
				{
					root._Graph.DestroyPlayable(_Playable);
				}
			}
		}

		public AnimancerState Clone()
		{
			return Clone(base.Root);
		}

		public abstract AnimancerState Clone(AnimancerPlayable root);

		protected void SetNewCloneRoot(AnimancerPlayable root)
		{
			if (root != null)
			{
				base.Root = root;
				CreatePlayable();
			}
		}

		void ICopyable<AnimancerState>.CopyFrom(AnimancerState copyFrom)
		{
			Events = (copyFrom.HasEvents ? copyFrom.Events : null);
			TimeD = copyFrom.TimeD;
			((ICopyable<AnimancerNode>)this).CopyFrom((AnimancerNode)copyFrom);
		}

		public virtual void GatherAnimationClips(ICollection<AnimationClip> clips)
		{
			clips.Gather(Clip);
			for (int num = ChildCount - 1; num >= 0; num--)
			{
				GetChild(num).GatherAnimationClips(clips);
			}
		}

		public override bool IsPlayingAndNotEnding()
		{
			if (!IsPlaying || !_Playable.IsValid())
			{
				return false;
			}
			float effectiveSpeed = base.EffectiveSpeed;
			if (effectiveSpeed > 0f)
			{
				float normalizedEndTime;
				if (_EventDispatcher != null)
				{
					normalizedEndTime = _EventDispatcher.Events.NormalizedEndTime;
					normalizedEndTime = ((!float.IsNaN(normalizedEndTime)) ? (normalizedEndTime * Length) : Length);
				}
				else
				{
					normalizedEndTime = Length;
				}
				return Time <= normalizedEndTime;
			}
			if (effectiveSpeed < 0f)
			{
				float normalizedEndTime2;
				if (_EventDispatcher != null)
				{
					normalizedEndTime2 = _EventDispatcher.Events.NormalizedEndTime;
					normalizedEndTime2 = ((!float.IsNaN(normalizedEndTime2)) ? (normalizedEndTime2 * Length) : 0f);
				}
				else
				{
					normalizedEndTime2 = 0f;
				}
				return Time >= normalizedEndTime2;
			}
			return true;
		}

		public override string ToString()
		{
			string name = GetType().Name;
			UnityEngine.Object mainObject = MainObject;
			if (mainObject != null)
			{
				return mainObject.name + " (" + name + ")";
			}
			return name;
		}

		protected override void AppendDetails(StringBuilder text, string separator)
		{
			text.Append(separator).Append("Key: ").Append(AnimancerUtilities.ToStringOrNull(_Key));
			UnityEngine.Object mainObject = MainObject;
			if (mainObject != _Key as UnityEngine.Object)
			{
				text.Append(separator).Append("MainObject: ").Append(AnimancerUtilities.ToStringOrNull(mainObject));
			}
			base.AppendDetails(text, separator);
			text.Append(separator).Append("IsPlaying: ").Append(IsPlaying);
			try
			{
				text.Append(separator).Append("Time (Normalized): ").Append(Time);
				text.Append(" (").Append(NormalizedTime).Append(')');
				text.Append(separator).Append("Length: ").Append(Length);
				text.Append(separator).Append("IsLooping: ").Append(IsLooping);
			}
			catch (Exception value)
			{
				text.Append(separator).Append(value);
			}
			text.Append(separator).Append("Events: ");
			if (_EventDispatcher != null && _EventDispatcher.Events != null)
			{
				text.Append(_EventDispatcher.Events.DeepToString(multiLine: false));
			}
			else
			{
				text.Append("null");
			}
		}

		public string GetPath()
		{
			if (_Parent == null)
			{
				return null;
			}
			StringBuilder stringBuilder = ObjectPool.AcquireStringBuilder();
			AppendPath(stringBuilder, _Parent);
			AppendPortAndType(stringBuilder);
			return stringBuilder.ReleaseToString();
		}

		private static void AppendPath(StringBuilder path, AnimancerNode parent)
		{
			if (parent is AnimancerState { _Parent: not null } animancerState)
			{
				AppendPath(path, animancerState._Parent);
				if (parent is AnimancerState animancerState2)
				{
					animancerState2.AppendPortAndType(path);
				}
				else
				{
					path.Append(" -> ").Append(parent.GetType());
				}
			}
			else
			{
				path.Append("Layers[").Append(parent.Layer.Index).Append("].States");
			}
		}

		private void AppendPortAndType(StringBuilder path)
		{
			path.Append('[').Append(base.Index).Append("] -> ")
				.Append(GetType().Name);
		}
	}
}
