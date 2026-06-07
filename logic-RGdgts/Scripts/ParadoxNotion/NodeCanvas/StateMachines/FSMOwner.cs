using NodeCanvas.Framework;

namespace NodeCanvas.StateMachines
{
	public class FSMOwner : GraphOwner<FSM>
	{
		public string currentRootStateName => null;

		public string previousRootStateName => null;

		public string currentDeepStateName => null;

		public string previousDeepStateName => null;

		public IState GetCurrentState(bool includeSubFSMs = true)
		{
			return null;
		}

		public IState GetPreviousState(bool includeSubFSMs = true)
		{
			return null;
		}

		public IState TriggerState(string stateName)
		{
			return null;
		}

		public IState TriggerState(string stateName, FSM.TransitionCallMode callMode)
		{
			return null;
		}

		public string[] GetStateNames()
		{
			return null;
		}
	}
}
