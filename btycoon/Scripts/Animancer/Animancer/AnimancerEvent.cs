using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Animancer
{
	public struct AnimancerEvent : IEquatable<AnimancerEvent>
	{
		public class Sequence : IEnumerable<AnimancerEvent>, IEnumerable, ICopyable<Sequence>
		{
			[Serializable]
			public class Serializable : ICopyable<Serializable>
			{
				[SerializeField]
				private float[] _NormalizedTimes;

				[SerializeField]
				private UnityEvent[] _Callbacks;

				[SerializeField]
				private string[] _Names;

				private Sequence _Events;

				public ref float[] NormalizedTimes => ref _NormalizedTimes;

				public ref UnityEvent[] Callbacks => ref _Callbacks;

				public ref string[] Names => ref _Names;

				public Sequence Events
				{
					get
					{
						if (_Events == null)
						{
							GetEventsOptional();
							if (_Events == null)
							{
								_Events = new Sequence();
							}
						}
						return _Events;
					}
					set
					{
						_Events = value;
					}
				}

				internal Sequence InitializedEvents => _Events;

				public Sequence GetEventsOptional()
				{
					if (_Events != null || _NormalizedTimes == null)
					{
						return _Events;
					}
					int num = _NormalizedTimes.Length;
					if (num == 0)
					{
						return null;
					}
					int num2 = ((_Callbacks != null) ? _Callbacks.Length : 0);
					Action callback = ((num2 >= num--) ? GetInvoker(_Callbacks[num]) : null);
					AnimancerEvent endEvent = new AnimancerEvent(_NormalizedTimes[num], callback);
					_Events = new Sequence(num)
					{
						EndEvent = endEvent,
						Count = num,
						_Names = _Names
					};
					for (int i = 0; i < num; i++)
					{
						callback = ((i < num2) ? GetInvoker(_Callbacks[i]) : DummyCallback);
						_Events._Events[i] = new AnimancerEvent(_NormalizedTimes[i], callback);
					}
					return _Events;
				}

				public static implicit operator Sequence(Serializable serializable)
				{
					return serializable?.GetEventsOptional();
				}

				public static Action GetInvoker(UnityEvent callback)
				{
					if (!HasPersistentCalls(callback))
					{
						return DummyCallback;
					}
					return callback.Invoke;
				}

				public static bool HasPersistentCalls(UnityEvent callback)
				{
					if (callback == null)
					{
						return false;
					}
					return callback.GetPersistentEventCount() > 0;
				}

				public float GetNormalizedEndTime(float speed = 1f)
				{
					if (_NormalizedTimes.IsNullOrEmpty())
					{
						return GetDefaultNormalizedEndTime(speed);
					}
					return _NormalizedTimes[_NormalizedTimes.Length - 1];
				}

				public void SetNormalizedEndTime(float normalizedTime)
				{
					if (_NormalizedTimes.IsNullOrEmpty())
					{
						_NormalizedTimes = new float[1] { normalizedTime };
					}
					else
					{
						_NormalizedTimes[_NormalizedTimes.Length - 1] = normalizedTime;
					}
				}

				public void CopyFrom(Serializable copyFrom)
				{
					if (copyFrom == null)
					{
						_NormalizedTimes = null;
						_Callbacks = null;
						_Names = null;
					}
					else
					{
						AnimancerUtilities.CopyExactArray(copyFrom._NormalizedTimes, ref _NormalizedTimes);
						AnimancerUtilities.CopyExactArray(copyFrom._Callbacks, ref _Callbacks);
						AnimancerUtilities.CopyExactArray(copyFrom._Names, ref _Names);
					}
				}
			}

			internal const string IndexOutOfRangeError = "index must be within the range of 0 <= index < Count";

			private AnimancerEvent[] _Events;

			public const int DefaultCapacity = 8;

			private int _Version;

			private AnimancerEvent _EndEvent = new AnimancerEvent(float.NaN, null);

			private string[] _Names;

			public int Count { get; private set; }

			public bool IsEmpty
			{
				get
				{
					if (_EndEvent.callback == null && float.IsNaN(_EndEvent.normalizedTime))
					{
						return Count == 0;
					}
					return false;
				}
			}

			public int Capacity
			{
				get
				{
					return _Events.Length;
				}
				set
				{
					if (value < Count)
					{
						throw new ArgumentOutOfRangeException("value", "Capacity cannot be set lower than Count");
					}
					if (value == _Events.Length)
					{
						return;
					}
					if (value > 0)
					{
						AnimancerEvent[] array = new AnimancerEvent[value];
						if (Count > 0)
						{
							Array.Copy(_Events, 0, array, 0, Count);
						}
						_Events = array;
					}
					else
					{
						_Events = Array.Empty<AnimancerEvent>();
					}
				}
			}

			public int Version
			{
				get
				{
					return _Version;
				}
				private set
				{
					_Version = value;
				}
			}

			public AnimancerEvent EndEvent
			{
				get
				{
					return _EndEvent;
				}
				set
				{
					_EndEvent = value;
				}
			}

			public Action OnEnd
			{
				get
				{
					return _EndEvent.callback;
				}
				set
				{
					_EndEvent.callback = value;
				}
			}

			public float NormalizedEndTime
			{
				get
				{
					return _EndEvent.normalizedTime;
				}
				set
				{
					_EndEvent.normalizedTime = value;
				}
			}

			public ref string[] Names => ref _Names;

			public AnimancerEvent this[int index] => _Events[index];

			public AnimancerEvent this[string name] => this[IndexOfRequired(name)];

			[Conditional("UNITY_ASSERTIONS")]
			public void SetShouldNotModifyReason(string reason)
			{
			}

			[Conditional("UNITY_ASSERTIONS")]
			public void OnSequenceModified()
			{
			}

			public static float GetDefaultNormalizedStartTime(float speed)
			{
				return (speed < 0f) ? 1 : 0;
			}

			public static float GetDefaultNormalizedEndTime(float speed)
			{
				return (!(speed < 0f)) ? 1 : 0;
			}

			public string GetName(int index)
			{
				if (_Names == null || _Names.Length <= index)
				{
					return null;
				}
				return _Names[index];
			}

			public void SetName(int index, string name)
			{
				if (_Names == null)
				{
					_Names = new string[Capacity];
				}
				else if (_Names.Length <= index)
				{
					string[] array = new string[Capacity];
					Array.Copy(_Names, array, _Names.Length);
					_Names = array;
				}
				_Names[index] = name;
			}

			public int IndexOf(string name, int startIndex = 0)
			{
				if (_Names == null)
				{
					return -1;
				}
				int num = Mathf.Min(Count, _Names.Length);
				while (startIndex < num)
				{
					if (_Names[startIndex] == name)
					{
						return startIndex;
					}
					startIndex++;
				}
				return -1;
			}

			public int IndexOfRequired(string name, int startIndex = 0)
			{
				startIndex = IndexOf(name, startIndex);
				if (startIndex >= 0)
				{
					return startIndex;
				}
				throw new ArgumentException("No event exists with the name '" + name + "'.");
			}

			public Sequence()
			{
				_Events = Array.Empty<AnimancerEvent>();
			}

			public Sequence(int capacity)
			{
				_Events = ((capacity > 0) ? new AnimancerEvent[capacity] : Array.Empty<AnimancerEvent>());
			}

			public Sequence(Sequence copyFrom)
			{
				_Events = Array.Empty<AnimancerEvent>();
				if (copyFrom != null)
				{
					CopyFrom(copyFrom);
				}
			}

			[Conditional("UNITY_ASSERTIONS")]
			public void AssertNormalizedTimes(AnimancerState state)
			{
				if (Count == 0 || (_Events[0].normalizedTime >= 0f && _Events[Count - 1].normalizedTime < 1f))
				{
					return;
				}
				throw new ArgumentOutOfRangeException("normalizedTime", "Events on looping animations are triggered every loop and must be" + string.Format(" within the range of 0 <= {0} < 1.\n{1}\n{2}", "normalizedTime", state, DeepToString()));
			}

			[Conditional("UNITY_ASSERTIONS")]
			public void AssertNormalizedTimes(AnimancerState state, bool isLooping)
			{
			}

			public string DeepToString(bool multiLine = true)
			{
				StringBuilder stringBuilder = ObjectPool.AcquireStringBuilder().Append(ToString()).Append('[')
					.Append(Count)
					.Append(']');
				stringBuilder.Append(multiLine ? "\n{" : " {");
				for (int i = 0; i < Count; i++)
				{
					if (multiLine)
					{
						stringBuilder.Append("\n   ");
					}
					else if (i > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(" [");
					stringBuilder.Append(i).Append("] ");
					this[i].AppendDetails(stringBuilder);
					string name = GetName(i);
					if (name != null)
					{
						stringBuilder.Append(", Name: '").Append(name).Append('\'');
					}
				}
				if (multiLine)
				{
					stringBuilder.Append("\n    [End] ");
				}
				else
				{
					if (Count > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(" [End] ");
				}
				_EndEvent.AppendDetails(stringBuilder);
				if (multiLine)
				{
					stringBuilder.Append("\n}\n");
				}
				else
				{
					stringBuilder.Append(" }");
				}
				return stringBuilder.ReleaseToString();
			}

			public FastEnumerator<AnimancerEvent> GetEnumerator()
			{
				return new FastEnumerator<AnimancerEvent>(_Events, Count);
			}

			IEnumerator<AnimancerEvent> IEnumerable<AnimancerEvent>.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public int IndexOf(AnimancerEvent animancerEvent)
			{
				return IndexOf(Count / 2, animancerEvent);
			}

			public int IndexOfRequired(AnimancerEvent animancerEvent)
			{
				return IndexOfRequired(Count / 2, animancerEvent);
			}

			public int IndexOf(int indexHint, AnimancerEvent animancerEvent)
			{
				if (Count == 0)
				{
					return -1;
				}
				if (indexHint >= Count)
				{
					indexHint = Count - 1;
				}
				AnimancerEvent animancerEvent2 = _Events[indexHint];
				if (animancerEvent2 == animancerEvent)
				{
					return indexHint;
				}
				if (animancerEvent2.normalizedTime > animancerEvent.normalizedTime)
				{
					while (--indexHint >= 0)
					{
						animancerEvent2 = _Events[indexHint];
						if (animancerEvent2.normalizedTime < animancerEvent.normalizedTime)
						{
							return -1;
						}
						if (animancerEvent2.normalizedTime == animancerEvent.normalizedTime && animancerEvent2.callback == animancerEvent.callback)
						{
							return indexHint;
						}
					}
				}
				else
				{
					while (animancerEvent2.normalizedTime == animancerEvent.normalizedTime)
					{
						indexHint--;
						if (indexHint < 0)
						{
							break;
						}
						animancerEvent2 = _Events[indexHint];
					}
					while (++indexHint < Count)
					{
						animancerEvent2 = _Events[indexHint];
						if (animancerEvent2.normalizedTime > animancerEvent.normalizedTime)
						{
							return -1;
						}
						if (animancerEvent2.normalizedTime == animancerEvent.normalizedTime && animancerEvent2.callback == animancerEvent.callback)
						{
							return indexHint;
						}
					}
				}
				return -1;
			}

			public int IndexOfRequired(int indexHint, AnimancerEvent animancerEvent)
			{
				indexHint = IndexOf(indexHint, animancerEvent);
				if (indexHint >= 0)
				{
					return indexHint;
				}
				throw new ArgumentException(string.Format("Event not found in {0} '{1}'.", "Sequence", animancerEvent));
			}

			public int Add(AnimancerEvent animancerEvent)
			{
				int num = Insert(animancerEvent.normalizedTime);
				_Events[num] = animancerEvent;
				return num;
			}

			public int Add(float normalizedTime, Action callback)
			{
				return Add(new AnimancerEvent(normalizedTime, callback));
			}

			public int Add(int indexHint, AnimancerEvent animancerEvent)
			{
				indexHint = Insert(indexHint, animancerEvent.normalizedTime);
				_Events[indexHint] = animancerEvent;
				return indexHint;
			}

			public int Add(int indexHint, float normalizedTime, Action callback)
			{
				return Add(indexHint, new AnimancerEvent(normalizedTime, callback));
			}

			public void AddRange(IEnumerable<AnimancerEvent> enumerable)
			{
				foreach (AnimancerEvent item in enumerable)
				{
					Add(item);
				}
			}

			public void AddCallback(int index, Action callback)
			{
				ref Action callback2 = ref _Events[index].callback;
				callback2 = (Action)Delegate.Combine(callback2, callback);
				Version++;
			}

			public void AddCallback(string name, Action callback)
			{
				AddCallback(IndexOfRequired(name), callback);
			}

			public void RemoveCallback(int index, Action callback)
			{
				ref AnimancerEvent reference = ref _Events[index];
				ref Action callback2 = ref reference.callback;
				callback2 = (Action)Delegate.Remove(callback2, callback);
				if (reference.callback == null)
				{
					reference.callback = DummyCallback;
				}
				Version++;
			}

			public void RemoveCallback(string name, Action callback)
			{
				RemoveCallback(IndexOfRequired(name), callback);
			}

			public void SetCallback(int index, Action callback)
			{
				_Events[index].callback = callback;
				Version++;
			}

			public void SetCallback(string name, Action callback)
			{
				SetCallback(IndexOfRequired(name), callback);
			}

			[Conditional("UNITY_ASSERTIONS")]
			private static void AssertCallbackUniqueness(Action oldCallback, Action newCallback, string target)
			{
			}

			[Conditional("UNITY_ASSERTIONS")]
			private void AssertEventUniqueness(int index, AnimancerEvent newEvent)
			{
			}

			public int SetNormalizedTime(int index, float normalizedTime)
			{
				AnimancerEvent animancerEvent = _Events[index];
				if (animancerEvent.normalizedTime == normalizedTime)
				{
					return index;
				}
				int i = index;
				if (animancerEvent.normalizedTime < normalizedTime)
				{
					for (; i < Count - 1 && !(_Events[i + 1].normalizedTime >= normalizedTime); i++)
					{
					}
				}
				else
				{
					while (i > 0 && !(_Events[i - 1].normalizedTime <= normalizedTime))
					{
						i--;
					}
				}
				if (index != i)
				{
					string name = GetName(index);
					Remove(index);
					index = i;
					Insert(index);
					if (!string.IsNullOrEmpty(name))
					{
						SetName(index, name);
					}
				}
				animancerEvent.normalizedTime = normalizedTime;
				_Events[index] = animancerEvent;
				Version++;
				return index;
			}

			public int SetNormalizedTime(string name, float normalizedTime)
			{
				return SetNormalizedTime(IndexOfRequired(name), normalizedTime);
			}

			public int SetNormalizedTime(AnimancerEvent animancerEvent, float normalizedTime)
			{
				return SetNormalizedTime(IndexOfRequired(animancerEvent), normalizedTime);
			}

			private int Insert(float normalizedTime)
			{
				int num = Count;
				while (num > 0 && _Events[num - 1].normalizedTime > normalizedTime)
				{
					num--;
				}
				Insert(num);
				return num;
			}

			private int Insert(int indexHint, float normalizedTime)
			{
				if (Count == 0)
				{
					Count = 0;
				}
				else
				{
					if (indexHint >= Count)
					{
						indexHint = Count - 1;
					}
					if (_Events[indexHint].normalizedTime > normalizedTime)
					{
						while (indexHint > 0 && _Events[indexHint - 1].normalizedTime > normalizedTime)
						{
							indexHint--;
						}
					}
					else
					{
						while (indexHint < Count && _Events[indexHint].normalizedTime <= normalizedTime)
						{
							indexHint++;
						}
					}
				}
				Insert(indexHint);
				return indexHint;
			}

			private void Insert(int index)
			{
				int num = _Events.Length;
				if (Count == num)
				{
					if (num == 0)
					{
						num = 8;
						_Events = new AnimancerEvent[8];
					}
					else
					{
						num *= 2;
						if (num < 8)
						{
							num = 8;
						}
						AnimancerEvent[] array = new AnimancerEvent[num];
						Array.Copy(_Events, 0, array, 0, index);
						if (Count > index)
						{
							Array.Copy(_Events, index, array, index + 1, Count - index);
						}
						_Events = array;
					}
				}
				else if (Count > index)
				{
					Array.Copy(_Events, index, _Events, index + 1, Count - index);
				}
				if (_Names != null)
				{
					if (_Names.Length < num)
					{
						string[] array2 = new string[num];
						Array.Copy(_Names, 0, array2, 0, Math.Min(_Names.Length, index));
						if (index <= Count && index < _Names.Length)
						{
							Array.Copy(_Names, index, array2, index + 1, Count - index);
						}
						_Names = array2;
					}
					else
					{
						if (Count > index)
						{
							Array.Copy(_Names, index, _Names, index + 1, Count - index);
						}
						_Names[index] = null;
					}
				}
				Count++;
				Version++;
			}

			public void Remove(int index)
			{
				Count--;
				if (index < Count)
				{
					Array.Copy(_Events, index + 1, _Events, index, Count - index);
					if (_Names != null)
					{
						int num = Mathf.Min(Count + 1, _Names.Length);
						if (index + 1 < num)
						{
							Array.Copy(_Names, index + 1, _Names, index, num - index - 1);
						}
						_Names[num - 1] = null;
					}
				}
				else if (_Names != null && index < _Names.Length)
				{
					_Names[index] = null;
				}
				_Events[Count] = default(AnimancerEvent);
				Version++;
			}

			public bool Remove(string name)
			{
				int num = IndexOf(name);
				if (num >= 0)
				{
					Remove(num);
					return true;
				}
				return false;
			}

			public bool Remove(AnimancerEvent animancerEvent)
			{
				int num = IndexOf(animancerEvent);
				if (num >= 0)
				{
					Remove(num);
					return true;
				}
				return false;
			}

			public void Clear()
			{
				if (_Names != null)
				{
					Array.Clear(_Names, 0, _Names.Length);
				}
				Array.Clear(_Events, 0, Count);
				Count = 0;
				Version++;
				_EndEvent = new AnimancerEvent(float.NaN, null);
			}

			public void CopyFrom(Sequence copyFrom)
			{
				if (copyFrom == null)
				{
					if (_Names != null)
					{
						Array.Clear(_Names, 0, _Names.Length);
					}
					Array.Clear(_Events, 0, Count);
					Count = 0;
					Capacity = 0;
					_EndEvent = default(AnimancerEvent);
					return;
				}
				AnimancerUtilities.CopyExactArray(copyFrom._Names, ref _Names);
				int count = copyFrom.Count;
				if (Count > count)
				{
					Array.Clear(_Events, Count, count - Count);
				}
				else if (_Events.Length < count)
				{
					Capacity = count;
				}
				Count = count;
				Array.Copy(copyFrom._Events, 0, _Events, 0, count);
				_EndEvent = copyFrom._EndEvent;
			}

			public void AddAllEvents(AnimationClip animation)
			{
				if (!(animation == null))
				{
					float length = animation.length;
					AnimationEvent[] events = animation.events;
					Capacity += events.Length;
					int num = -1;
					foreach (AnimationEvent animationEvent in events)
					{
						num = Add(num + 1, new AnimancerEvent(animationEvent.time / length, DummyCallback));
						SetName(num, animationEvent.functionName);
					}
				}
			}

			public void CopyTo(AnimancerEvent[] array, int index)
			{
				Array.Copy(_Events, 0, array, index, Count);
			}

			public bool ContentsAreEqual(Sequence other)
			{
				if (_EndEvent != other._EndEvent)
				{
					return false;
				}
				if (Count != other.Count)
				{
					return false;
				}
				for (int num = Count - 1; num >= 0; num--)
				{
					if (this[num] != other[num])
					{
						return false;
					}
				}
				return true;
			}
		}

		public float normalizedTime;

		public Action callback;

		public const float AlmostOne = MathF.PI * 113f / 355f;

		public static readonly Action DummyCallback = Dummy;

		private static AnimancerState _CurrentState;

		private static AnimancerEvent _CurrentEvent;

		public static AnimancerState CurrentState => _CurrentState;

		public static ref readonly AnimancerEvent CurrentEvent => ref _CurrentEvent;

		private static void Dummy()
		{
		}

		public static bool IsNullOrDummy(Action callback)
		{
			if (callback != null)
			{
				return callback == DummyCallback;
			}
			return true;
		}

		public AnimancerEvent(float normalizedTime, Action callback)
		{
			this.normalizedTime = normalizedTime;
			this.callback = callback;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = ObjectPool.AcquireStringBuilder();
			stringBuilder.Append("AnimancerEvent(");
			AppendDetails(stringBuilder);
			stringBuilder.Append(')');
			return stringBuilder.ReleaseToString();
		}

		public void AppendDetails(StringBuilder text)
		{
			text.Append("NormalizedTime: ").Append(normalizedTime).Append(", Callback: ");
			if (callback == null)
			{
				text.Append("null");
			}
			else if (callback.Target == null)
			{
				text.Append(callback.Method.DeclaringType.FullName).Append('.').Append(callback.Method.Name);
			}
			else
			{
				text.Append("(Target: '").Append(callback.Target).Append("', Method: ")
					.Append(callback.Method.DeclaringType.FullName)
					.Append('.')
					.Append(callback.Method.Name)
					.Append(')');
			}
		}

		public void Invoke(AnimancerState state)
		{
			AnimancerState currentState = _CurrentState;
			AnimancerEvent currentEvent = _CurrentEvent;
			_CurrentState = state;
			_CurrentEvent = this;
			try
			{
				callback();
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception, state?.Root?.Component as UnityEngine.Object);
			}
			_CurrentState = currentState;
			_CurrentEvent = currentEvent;
		}

		public static float GetFadeOutDuration()
		{
			return GetFadeOutDuration(CurrentState, AnimancerPlayable.DefaultFadeDuration);
		}

		public static float GetFadeOutDuration(float minDuration)
		{
			return GetFadeOutDuration(CurrentState, minDuration);
		}

		public static float GetFadeOutDuration(AnimancerState state, float minDuration)
		{
			if (state == null)
			{
				return minDuration;
			}
			float time = state.Time;
			float effectiveSpeed = state.EffectiveSpeed;
			if (effectiveSpeed == 0f)
			{
				return minDuration;
			}
			if (state.IsLooping)
			{
				float num = time - effectiveSpeed * Time.deltaTime;
				float num2 = 1f / state.Length;
				if (Math.Floor(time * num2) != Math.Floor(num * num2))
				{
					return minDuration;
				}
			}
			float val = ((!(effectiveSpeed > 0f)) ? (time / (0f - effectiveSpeed)) : ((state.Length - time) / effectiveSpeed));
			return Math.Max(minDuration, val);
		}

		public static bool operator ==(AnimancerEvent a, AnimancerEvent b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(AnimancerEvent a, AnimancerEvent b)
		{
			return !a.Equals(b);
		}

		public bool Equals(AnimancerEvent other)
		{
			if (callback == other.callback)
			{
				if (normalizedTime != other.normalizedTime)
				{
					if (float.IsNaN(normalizedTime))
					{
						return float.IsNaN(other.normalizedTime);
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is AnimancerEvent other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = -78069441;
			num = num * -1521134295 + normalizedTime.GetHashCode();
			if (callback != null)
			{
				num = num * -1521134295 + callback.GetHashCode();
			}
			return num;
		}
	}
}
