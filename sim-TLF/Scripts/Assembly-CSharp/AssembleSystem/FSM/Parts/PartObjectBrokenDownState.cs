using Player;
using UnityHFSM;

namespace AssembleSystem.FSM.Parts
{
	public class PartObjectBrokenDownState : StateBase<StateIdentifier>
	{
		private readonly PartObject _partObject;

		private readonly PlayerPartProgressor _playerPartProgressor;

		public PartObjectBrokenDownState(PartObject part, PlayerPartProgressor playerPartProgressor, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_partObject = part;
			_playerPartProgressor = playerPartProgressor;
		}

		public override void OnEnter()
		{
			_playerPartProgressor.UnsubscribeFromProgressables();
			_partObject.StateMachine.Tightened = false;
			_partObject.StateMachine.Placed = false;
			_partObject.SetProgress(0f);
			_partObject.transform.parent = null;
		}

		public override void OnExit()
		{
			_playerPartProgressor.UnsubscribeFromProgressables();
			_partObject.StateMachine.Placed = false;
			_partObject.SetProgress(0f);
		}
	}
}
