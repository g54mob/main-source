using System;
using UnityHFSM;

namespace AssembleSystem.FSM.Lifter.States
{
	internal class EmptyLifterState : State<StateIdentifier>
	{
		public EmptyLifterState()
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
		}
	}
}
