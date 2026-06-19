using System;
using JSAM;
using UnityHFSM;
using Vehicles.Lifter;

namespace AssembleSystem.FSM.Lifter.States
{
	internal class MoveUpState : State<StateIdentifier>
	{
		private readonly PlaneLifter _planeLifter;

		public MoveUpState(PlaneLifter planeLifter)
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
			_planeLifter = planeLifter;
		}

		public override void OnEnter()
		{
			base.OnEnter();
			AudioManager.PlaySound(InteractionLibrarySounds.Forklift);
		}

		public override void OnLogic()
		{
			_planeLifter.LiftUp();
		}

		public override void OnExit()
		{
			base.OnExit();
			AudioManager.StopSoundIfPlaying(InteractionLibrarySounds.Forklift);
		}
	}
}
