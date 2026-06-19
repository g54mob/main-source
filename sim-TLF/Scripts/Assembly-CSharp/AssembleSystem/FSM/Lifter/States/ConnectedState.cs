using System;
using UnityHFSM;
using Vehicles.Lifter;

namespace AssembleSystem.FSM.Lifter.States
{
	internal class ConnectedState : State<StateIdentifier>
	{
		private readonly LiftingObjectTrigger _mountChecker;

		public ConnectedState(LiftingObjectTrigger mountChecker)
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
			_mountChecker = mountChecker;
		}

		public override void OnEnter()
		{
			base.OnEnter();
			_mountChecker.AttachRigidbody();
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
