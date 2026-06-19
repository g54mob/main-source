using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Entities;

public struct StateInfoCD : IComponentData, IQueryTypeParameter
{
	public StateID currentState;

	public StateID newState;

	public StateID previousState;

	public bool locked;

	public void Lock()
	{
		newState = currentState;
		locked = true;
	}

	public void Unlock()
	{
		locked = false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool IsCurrentState(StateID state)
	{
		return currentState == state;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool IsPreviousState(StateID state)
	{
		return previousState == state;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool IsCurrentOrPreviousState(StateID state)
	{
		if (!IsCurrentState(state))
		{
			return IsPreviousState(state);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool HasState(StateID state, bool ignoreNew = false)
	{
		if (Hint.Unlikely(locked || (newState != StateID.Idle && !ignoreNew)))
		{
			return true;
		}
		if (Hint.Unlikely(currentState == state))
		{
			newState = state;
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void EnterState(StateID state)
	{
		newState = state;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void LeaveState()
	{
		previousState = currentState;
		currentState = StateID.Idle;
		locked = false;
	}
}
