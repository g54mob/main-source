using System;
using UnityHFSM;

namespace AssembleSystem.FSM.Plane.States
{
	internal class PlaneMotorPlacedState : State<StateIdentifier>
	{
		private readonly PlaneStateMachine _fsm;

		public PlaneMotorPlacedState(PlaneStateMachine fsm)
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
			_fsm = fsm;
		}

		public override void OnEnter()
		{
			_fsm.MotorPlaced = true;
		}
	}
}
