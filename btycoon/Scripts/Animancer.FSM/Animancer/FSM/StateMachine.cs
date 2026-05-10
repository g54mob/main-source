using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Animancer.FSM
{
	[Serializable]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer.FSM/StateMachine_1")]
	public class StateMachine<TState> : IStateMachine where TState : class, IState
	{
		public class InputBuffer : InputBuffer<StateMachine<TState>>
		{
			public InputBuffer()
			{
			}

			public InputBuffer(StateMachine<TState> stateMachine)
				: base(stateMachine)
			{
			}
		}

		public class InputBuffer<TStateMachine> where TStateMachine : StateMachine<TState>
		{
			private TStateMachine _StateMachine;

			public TStateMachine StateMachine
			{
				get
				{
					return _StateMachine;
				}
				set
				{
					_StateMachine = value;
					Clear();
				}
			}

			public TState State { get; set; }

			public float TimeOut { get; set; }

			public bool IsActive => State != null;

			public InputBuffer()
			{
			}

			public InputBuffer(TStateMachine stateMachine)
			{
				_StateMachine = stateMachine;
			}

			public void Buffer(TState state, float timeOut)
			{
				State = state;
				TimeOut = timeOut;
			}

			protected virtual bool TryEnterState()
			{
				return StateMachine.TryResetState(State);
			}

			public bool Update()
			{
				return Update(Time.deltaTime);
			}

			public bool Update(float deltaTime)
			{
				if (IsActive)
				{
					if (TryEnterState())
					{
						Clear();
						return true;
					}
					TimeOut -= deltaTime;
					if (TimeOut < 0f)
					{
						Clear();
					}
				}
				return false;
			}

			public virtual void Clear()
			{
				State = null;
				TimeOut = 0f;
			}
		}

		public class StateSelector : SortedList<float, TState>
		{
			public StateSelector()
				: base((IComparer<float>)ReverseComparer<float>.Instance)
			{
			}

			public void Add<TPrioritizable>(TPrioritizable state) where TPrioritizable : TState, IPrioritizable
			{
				Add(state.Priority, (TState)(object)state);
			}
		}

		[Serializable]
		public class WithDefault : StateMachine<TState>
		{
			[SerializeField]
			private TState _DefaultState;

			public readonly Action ForceSetDefaultState;

			public TState DefaultState
			{
				get
				{
					return _DefaultState;
				}
				set
				{
					_DefaultState = value;
					if (_CurrentState == null && value != null)
					{
						ForceSetState(value);
					}
				}
			}

			public WithDefault()
			{
				ForceSetDefaultState = delegate
				{
					ForceSetState(_DefaultState);
				};
			}

			public WithDefault(TState defaultState)
				: this()
			{
				_DefaultState = defaultState;
				ForceSetState(defaultState);
			}

			public override void InitializeAfterDeserialize()
			{
				StateChange<TState> stateChange;
				if (_CurrentState != null)
				{
					stateChange = new StateChange<TState>(this, null, _CurrentState);
					try
					{
						_CurrentState.OnEnterState();
						return;
					}
					finally
					{
						((IDisposable)stateChange/*cast due to .constrained prefix*/).Dispose();
					}
				}
				if (_DefaultState != null)
				{
					stateChange = new StateChange<TState>(this, null, base.CurrentState);
					try
					{
						_CurrentState = _DefaultState;
						_CurrentState.OnEnterState();
					}
					finally
					{
						((IDisposable)stateChange/*cast due to .constrained prefix*/).Dispose();
					}
				}
			}

			public bool TrySetDefaultState()
			{
				return TrySetState(DefaultState);
			}

			public bool TryResetDefaultState()
			{
				return TryResetState(DefaultState);
			}
		}

		[SerializeField]
		private TState _CurrentState;

		public TState CurrentState => _CurrentState;

		public TState PreviousState => StateChange<TState>.PreviousState;

		public TState NextState => StateChange<TState>.NextState;

		object IStateMachine.CurrentState => _CurrentState;

		object IStateMachine.PreviousState => PreviousState;

		object IStateMachine.NextState => NextState;

		public StateMachine()
		{
		}

		public StateMachine(TState state)
		{
			StateChange<TState> stateChange = new StateChange<TState>(this, null, state);
			try
			{
				_CurrentState = state;
				state.OnEnterState();
			}
			finally
			{
				((IDisposable)stateChange/*cast due to .constrained prefix*/).Dispose();
			}
		}

		public virtual void InitializeAfterDeserialize()
		{
			if (_CurrentState != null)
			{
				StateChange<TState> stateChange = new StateChange<TState>(this, null, _CurrentState);
				try
				{
					_CurrentState.OnEnterState();
				}
				finally
				{
					((IDisposable)stateChange/*cast due to .constrained prefix*/).Dispose();
				}
			}
		}

		public bool CanSetState(TState state)
		{
			using (new StateChange<TState>(this, _CurrentState, state))
			{
				if (_CurrentState != null && !_CurrentState.CanExitState)
				{
					return false;
				}
				if (state != null && !state.CanEnterState)
				{
					return false;
				}
				return true;
			}
		}

		public TState CanSetState(IList<TState> states)
		{
			int count = states.Count;
			for (int i = 0; i < count; i++)
			{
				TState val = states[i];
				if (CanSetState(val))
				{
					return val;
				}
			}
			return null;
		}

		public bool TrySetState(TState state)
		{
			if (_CurrentState == state)
			{
				return true;
			}
			return TryResetState(state);
		}

		public bool TrySetState(IList<TState> states)
		{
			int count = states.Count;
			for (int i = 0; i < count; i++)
			{
				if (TrySetState(states[i]))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryResetState(TState state)
		{
			if (!CanSetState(state))
			{
				return false;
			}
			ForceSetState(state);
			return true;
		}

		public bool TryResetState(IList<TState> states)
		{
			int count = states.Count;
			for (int i = 0; i < count; i++)
			{
				if (TryResetState(states[i]))
				{
					return true;
				}
			}
			return false;
		}

		public void ForceSetState(TState state)
		{
			using (new StateChange<TState>(this, _CurrentState, state))
			{
				_CurrentState?.OnExitState();
				_CurrentState = state;
				state?.OnEnterState();
			}
		}

		public override string ToString()
		{
			return $"{GetType().Name} -> {_CurrentState}";
		}

		[Conditional("UNITY_ASSERTIONS")]
		public void SetAllowNullStates(bool allow = true)
		{
		}

		object IStateMachine.CanSetState(IList states)
		{
			return CanSetState((List<TState>)states);
		}

		bool IStateMachine.CanSetState(object state)
		{
			return CanSetState((TState)state);
		}

		void IStateMachine.ForceSetState(object state)
		{
			ForceSetState((TState)state);
		}

		bool IStateMachine.TryResetState(IList states)
		{
			return TryResetState((List<TState>)states);
		}

		bool IStateMachine.TryResetState(object state)
		{
			return TryResetState((TState)state);
		}

		bool IStateMachine.TrySetState(IList states)
		{
			return TrySetState((List<TState>)states);
		}

		bool IStateMachine.TrySetState(object state)
		{
			return TrySetState((TState)state);
		}

		void IStateMachine.SetAllowNullStates(bool allow)
		{
		}
	}
	[Serializable]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer.FSM/StateMachine_2")]
	public class StateMachine<TKey, TState> : StateMachine<TState>, IKeyedStateMachine<TKey>, IDictionary<TKey, TState>, ICollection<KeyValuePair<TKey, TState>>, IEnumerable<KeyValuePair<TKey, TState>>, IEnumerable where TState : class, IState
	{
		public new class InputBuffer : InputBuffer<StateMachine<TKey, TState>>
		{
			public TKey Key { get; set; }

			public InputBuffer()
			{
			}

			public InputBuffer(StateMachine<TKey, TState> stateMachine)
				: base(stateMachine)
			{
			}

			public bool Buffer(TKey key, float timeOut)
			{
				if (base.StateMachine.TryGetValue(key, out var state))
				{
					Buffer(key, state, timeOut);
					return true;
				}
				return false;
			}

			public void Buffer(TKey key, TState state, float timeOut)
			{
				Key = key;
				Buffer(state, timeOut);
			}

			protected override bool TryEnterState()
			{
				return base.StateMachine.TryResetState(Key, base.State);
			}

			public override void Clear()
			{
				base.Clear();
				Key = default(TKey);
			}
		}

		[Serializable]
		public new class WithDefault : StateMachine<TKey, TState>
		{
			[SerializeField]
			private TKey _DefaultKey;

			public readonly Action ForceSetDefaultState;

			public TKey DefaultKey
			{
				get
				{
					return _DefaultKey;
				}
				set
				{
					_DefaultKey = value;
					if (base.CurrentState == null && value != null)
					{
						ForceSetState(value);
					}
				}
			}

			public WithDefault()
			{
				ForceSetDefaultState = delegate
				{
					ForceSetState(_DefaultKey);
				};
			}

			public WithDefault(TKey defaultKey)
				: this()
			{
				_DefaultKey = defaultKey;
				ForceSetState(defaultKey);
			}

			public override void InitializeAfterDeserialize()
			{
				if (base.CurrentState != null)
				{
					KeyChange<TKey> keyChange = new KeyChange<TKey>(this, default(TKey), _DefaultKey);
					try
					{
						using (new StateChange<TState>(this, null, base.CurrentState))
						{
							base.CurrentState.OnEnterState();
							return;
						}
					}
					finally
					{
						((IDisposable)keyChange/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ForceSetState(_DefaultKey);
			}

			public TState TrySetDefaultState()
			{
				return TrySetState(_DefaultKey);
			}

			public TState TryResetDefaultState()
			{
				return TryResetState(_DefaultKey);
			}
		}

		[SerializeField]
		private TKey _CurrentKey;

		public IDictionary<TKey, TState> Dictionary { get; set; }

		public TKey CurrentKey => _CurrentKey;

		public TKey PreviousKey => KeyChange<TKey>.PreviousKey;

		public TKey NextKey => KeyChange<TKey>.NextKey;

		public TState this[TKey key]
		{
			get
			{
				return Dictionary[key];
			}
			set
			{
				Dictionary[key] = value;
			}
		}

		public ICollection<TKey> Keys => Dictionary.Keys;

		public ICollection<TState> Values => Dictionary.Values;

		public int Count => Dictionary.Count;

		bool ICollection<KeyValuePair<TKey, TState>>.IsReadOnly => Dictionary.IsReadOnly;

		public StateMachine()
		{
			Dictionary = new Dictionary<TKey, TState>();
		}

		public StateMachine(IDictionary<TKey, TState> dictionary)
		{
			Dictionary = dictionary;
		}

		public StateMachine(TKey defaultKey, TState defaultState)
		{
			Dictionary = new Dictionary<TKey, TState> { { defaultKey, defaultState } };
			ForceSetState(defaultKey, defaultState);
		}

		public StateMachine(IDictionary<TKey, TState> dictionary, TKey defaultKey, TState defaultState)
		{
			Dictionary = dictionary;
			dictionary.Add(defaultKey, defaultState);
			ForceSetState(defaultKey, defaultState);
		}

		public override void InitializeAfterDeserialize()
		{
			if (base.CurrentState != null)
			{
				KeyChange<TKey> keyChange = new KeyChange<TKey>(this, default(TKey), _CurrentKey);
				try
				{
					using (new StateChange<TState>(this, null, base.CurrentState))
					{
						base.CurrentState.OnEnterState();
						return;
					}
				}
				finally
				{
					((IDisposable)keyChange/*cast due to .constrained prefix*/).Dispose();
				}
			}
			if (Dictionary.TryGetValue(_CurrentKey, out var value))
			{
				ForceSetState(_CurrentKey, value);
			}
		}

		public bool TrySetState(TKey key, TState state)
		{
			if (base.CurrentState == state)
			{
				return true;
			}
			return TryResetState(key, state);
		}

		public TState TrySetState(TKey key)
		{
			if (EqualityComparer<TKey>.Default.Equals(_CurrentKey, key))
			{
				return base.CurrentState;
			}
			return TryResetState(key);
		}

		object IKeyedStateMachine<TKey>.TrySetState(TKey key)
		{
			return TrySetState(key);
		}

		public bool TryResetState(TKey key, TState state)
		{
			using (new KeyChange<TKey>(this, _CurrentKey, key))
			{
				if (!CanSetState(state))
				{
					return false;
				}
				_CurrentKey = key;
				ForceSetState(state);
				return true;
			}
		}

		public TState TryResetState(TKey key)
		{
			if (Dictionary.TryGetValue(key, out var value) && TryResetState(key, value))
			{
				return value;
			}
			return null;
		}

		object IKeyedStateMachine<TKey>.TryResetState(TKey key)
		{
			return TryResetState(key);
		}

		public void ForceSetState(TKey key, TState state)
		{
			using (new KeyChange<TKey>(this, _CurrentKey, key))
			{
				_CurrentKey = key;
				ForceSetState(state);
			}
		}

		public TState ForceSetState(TKey key)
		{
			Dictionary.TryGetValue(key, out var value);
			ForceSetState(key, value);
			return value;
		}

		object IKeyedStateMachine<TKey>.ForceSetState(TKey key)
		{
			return ForceSetState(key);
		}

		public bool TryGetValue(TKey key, out TState state)
		{
			return Dictionary.TryGetValue(key, out state);
		}

		public void Add(TKey key, TState state)
		{
			Dictionary.Add(key, state);
		}

		public void Add(KeyValuePair<TKey, TState> item)
		{
			Dictionary.Add(item);
		}

		public bool Remove(TKey key)
		{
			return Dictionary.Remove(key);
		}

		public bool Remove(KeyValuePair<TKey, TState> item)
		{
			return Dictionary.Remove(item);
		}

		public void Clear()
		{
			Dictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TState> item)
		{
			return Dictionary.Contains(item);
		}

		public bool ContainsKey(TKey key)
		{
			return Dictionary.ContainsKey(key);
		}

		public IEnumerator<KeyValuePair<TKey, TState>> GetEnumerator()
		{
			return Dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void CopyTo(KeyValuePair<TKey, TState>[] array, int arrayIndex)
		{
			Dictionary.CopyTo(array, arrayIndex);
		}

		public TState GetState(TKey key)
		{
			TryGetValue(key, out var state);
			return state;
		}

		public void AddRange(TKey[] keys, TState[] states)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				Dictionary.Add(keys[i], states[i]);
			}
		}

		public void SetFakeKey(TKey key)
		{
			_CurrentKey = key;
		}

		public override string ToString()
		{
			return string.Format("{0} -> {1} -> {2}", GetType().FullName, _CurrentKey, (base.CurrentState != null) ? base.CurrentState.ToString() : "null");
		}
	}
}
