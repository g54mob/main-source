using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[AddComponentMenu("NodeCanvas/FSM Owner")]
	public class FSMOwner : GraphOwner<FSM>
	{
		public string currentRootStateName => base.behaviour?.currentStateName;

		public string previousRootStateName => base.behaviour?.previousStateName;

		public string currentDeepStateName => GetCurrentState()?.name;

		public string previousDeepStateName => GetPreviousState()?.name;

		public IState GetCurrentState(bool includeSubFSMs = true)
		{
			if (base.behaviour == null)
			{
				return null;
			}
			FSMState fSMState = base.behaviour.currentState;
			if (includeSubFSMs)
			{
				while (fSMState is NestedFSMState nestedFSMState)
				{
					fSMState = nestedFSMState.currentInstance?.currentState;
				}
			}
			return fSMState;
		}

		public IState GetPreviousState(bool includeSubFSMs = true)
		{
			if (base.behaviour == null)
			{
				return null;
			}
			FSMState fSMState = base.behaviour.currentState;
			FSMState result = base.behaviour.previousState;
			if (includeSubFSMs)
			{
				while (fSMState is NestedFSMState nestedFSMState)
				{
					fSMState = nestedFSMState.currentInstance?.currentState;
					result = nestedFSMState.currentInstance?.previousState;
				}
			}
			return result;
		}

		public IState TriggerState(string stateName)
		{
			return TriggerState(stateName, FSM.TransitionCallMode.Normal);
		}

		public IState TriggerState(string stateName, FSM.TransitionCallMode callMode)
		{
			return base.behaviour?.TriggerState(stateName, callMode);
		}

		public string[] GetStateNames()
		{
			return base.behaviour?.GetStateNames();
		}
	}
}
