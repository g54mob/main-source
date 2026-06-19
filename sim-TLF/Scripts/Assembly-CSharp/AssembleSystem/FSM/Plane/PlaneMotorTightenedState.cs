using System;
using UnityHFSM;

namespace AssembleSystem.FSM.Plane
{
	internal class PlaneMotorTightenedState : State<StateIdentifier>
	{
		private readonly PlaneStateMachine _fsm;

		public PlaneMotorTightenedState(PlaneStateMachine fsm)
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
			_fsm = fsm;
		}

		public override void OnEnter()
		{
			_fsm.MotorPlaced = true;
			_fsm.MotorTightened = true;
		}
	}
}
