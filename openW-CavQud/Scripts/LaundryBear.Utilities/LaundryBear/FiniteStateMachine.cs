using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear
{
	public abstract class FiniteStateMachine<TStateEnum, TTransitionEnum, TOwner> : ISerializationCallbackReceiver where TOwner : Object
	{
		public delegate void StateChangeDelegate(TStateEnum enterState, TTransitionEnum transition);

		[SerializeField]
		private ScriptableObject[] m_states;

		private Dictionary<TStateEnum, State<TStateEnum, TTransitionEnum, TOwner>> m_stateDictionary;

		public bool Initialized { get; private set; }

		public bool Paused { get; set; }

		public TOwner Owner { get; private set; }

		public TStateEnum CurrentState { get; private set; }

		public event StateChangeDelegate StateChangeEvent;

		public FiniteStateMachine(TOwner owner)
		{
			Debug.LogWarning("Creating FSM withot an IEquality comparer.  If you are using a value type this will result in boxing");
			m_stateDictionary = new Dictionary<TStateEnum, State<TStateEnum, TTransitionEnum, TOwner>>();
			m_states = new ScriptableObject[0];
			Owner = owner;
		}

		public FiniteStateMachine(TOwner owner, IEqualityComparer<TStateEnum> comparer)
		{
			m_stateDictionary = new Dictionary<TStateEnum, State<TStateEnum, TTransitionEnum, TOwner>>(comparer);
			m_states = new ScriptableObject[0];
			Owner = owner;
		}

		public void Initialize(TStateEnum startState, object userData = null)
		{
			CurrentState = startState;
			m_stateDictionary[CurrentState].OnEnterState(default(TStateEnum), Owner, userData);
			Initialized = true;
		}

		public TState AddState<TState>() where TState : State<TStateEnum, TTransitionEnum, TOwner>
		{
			ScriptableObject[] array = new ScriptableObject[m_states.Length + 1];
			m_states.CopyTo(array, 0);
			TState val = ScriptableObject.CreateInstance<TState>();
			array[^1] = val;
			m_stateDictionary.Add(val.GetEnum(), val);
			m_states = array;
			return val;
		}

		public void ReloadStates()
		{
		}

		public void FixedUpdate(TOwner owner, object userData = null)
		{
			if (Initialized && !Paused)
			{
				m_stateDictionary[CurrentState].FixedUpdateState(owner, userData);
			}
		}

		public void Update(TOwner owner, object userData = null)
		{
			if (Initialized && !Paused)
			{
				m_stateDictionary[CurrentState].UpdateState(owner, userData);
			}
		}

		public void AnimatorMove(TOwner owner, object userData = null)
		{
			if (Initialized && !Paused)
			{
				m_stateDictionary[CurrentState].OnOwnerAnimatorMove(owner, userData);
			}
		}

		public void AnimatorIK(TOwner owner, object userData = null)
		{
			if (Initialized && !Paused)
			{
				m_stateDictionary[CurrentState].OnOwnerAnimatorIK(owner, userData);
			}
		}

		public void LateUpdate(TOwner owner, object userData = null)
		{
			if (Initialized && !Paused)
			{
				m_stateDictionary[CurrentState].LateUpdateState(owner, userData);
			}
		}

		public bool Transition(TTransitionEnum transition, object userData = null)
		{
			if (m_stateDictionary[CurrentState].CanTransition(transition))
			{
				m_stateDictionary[CurrentState].OnExitState(Owner, userData);
				TStateEnum currentState = CurrentState;
				CurrentState = m_stateDictionary[CurrentState].HandleTransition(transition);
				m_stateDictionary[CurrentState].OnEnterState(currentState, Owner, userData);
				if (this.StateChangeEvent != null)
				{
					this.StateChangeEvent(CurrentState, transition);
				}
				return true;
			}
			return false;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			ReloadStates();
		}
	}
}
