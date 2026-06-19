using System;
using JSAM;
using UnityHFSM;
using Vehicles.Lifter;

namespace AssembleSystem.FSM.Lifter
{
	internal class MoveDownState : State<StateIdentifier>
	{
		private readonly PlaneLifter _planeLifter;

		public MoveDownState(PlaneLifter planeLifter)
			: base((Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Action<State<StateIdentifier, string>>)null, (Func<State<StateIdentifier, string>, bool>)null, false, false)
		{
			_planeLifter = planeLifter;
		}

		public override void OnEnter()
		{
			AudioManager.PlaySound(InteractionLibrarySounds.Forklift);
		}

		public override void OnLogic()
		{
			_planeLifter.LiftDown();
		}

		public override void OnExit()
		{
			AudioManager.StopSoundIfPlaying(InteractionLibrarySounds.Forklift);
		}
	}
}
