using System;
using UnityHFSM;
using Vehicles.Lifter;

namespace AssembleSystem.FSM.Lifter.States
{
	internal class CanConnectState : State<StateIdentifier>
	{
		private readonly LiftingObjectTrigger _mountChecker;

		public CanConnectState(LiftingObjectTrigger mountChecker)
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
			_mountChecker = mountChecker;
		}

		public override void OnEnter()
		{
			_mountChecker.DetachRigidbody();
		}

		public override void OnLogic()
		{
			base.OnLogic();
		}

		public override void OnExit()
		{
			base.OnExit();
		}
	}
}
