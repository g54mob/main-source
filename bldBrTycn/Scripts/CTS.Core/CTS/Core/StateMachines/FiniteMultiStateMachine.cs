using System;
using System.Collections.Generic;

namespace CTS.Core.StateMachines
{
	public abstract class FiniteMultiStateMachine<TEnum, TAgent> : BaseStateMachine<TAgent> where TEnum : Enum
	{
		private readonly Dictionary<TEnum, IState<TEnum, TAgent>> _possibleStates = new Dictionary<TEnum, IState<TEnum, TAgent>>();

		public bool HasStates(TEnum key1, TEnum key2, TEnum key3)
		{
			if (HasState(key1) && HasState(key2))
			{
				return HasState(key3);
			}
			return false;
		}

		public bool HasStates(TEnum key1, TEnum key2)
		{
			if (HasState(key1))
			{
				return HasState(key2);
			}
			return false;
		}

		public bool HasAnyState(TEnum key, TEnum key2, TEnum key3)
		{
			if (!HasState(key) && !HasState(key2))
			{
				return HasState(key3);
			}
			return true;
		}

		public bool HasAnyState(TEnum key1, TEnum key2)
		{
			if (!HasState(key1))
			{
				return HasState(key2);
			}
			return true;
		}

		public bool HasState(TEnum key)
		{
			if (!_possibleStates.TryGetValue(key, out var value))
			{
				return false;
			}
			return HasState(value);
		}

		public void AddPossibleState(TEnum key, IState<TEnum, TAgent> state)
		{
			if (!_possibleStates.TryGetValue(key, out var _))
			{
				_possibleStates[key] = state;
			}
		}

		public void RemovePossibleState(TEnum key)
		{
			if (_possibleStates.TryGetValue(key, out var value))
			{
				ExitState(value);
				_possibleStates.Remove(key);
			}
		}

		public void EnterState(TEnum key)
		{
			if (_possibleStates.TryGetValue(key, out var value))
			{
				EnterState(value);
			}
		}

		public void ExitState(TEnum key)
		{
			if (_possibleStates.TryGetValue(key, out var value))
			{
				ExitState(value);
			}
		}
	}
}
