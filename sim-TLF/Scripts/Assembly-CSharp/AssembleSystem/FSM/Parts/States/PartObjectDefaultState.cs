using UnityEngine;
using UnityHFSM;

namespace AssembleSystem.FSM.Parts.States
{
	public class PartObjectDefaultState : StateBase<StateIdentifier>
	{
		protected PartObject _part;

		protected Rigidbody _partRb;

		protected PartObjectStateMachine _FSM;

		public PartObjectDefaultState(PartObjectStateMachine fsm, PartObject part, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_FSM = fsm;
			_part = part;
			_partRb = part.GetComponent<Rigidbody>();
		}

		public override void OnEnter()
		{
			base.OnEnter();
			_part.enabled = true;
			_partRb.isKinematic = false;
			_FSM.InInventoryParentPlaced = false;
			foreach (PartObject dependantPart in _part.GetDependantParts())
			{
				if (dependantPart.StateMachine.InInventoryParentPlaced)
				{
					dependantPart.StateMachine.InInventoryParentPlaced = false;
				}
			}
		}

		public override void OnExit()
		{
			base.OnExit();
		}

		public override void OnLogic()
		{
			base.OnLogic();
		}
	}
}
