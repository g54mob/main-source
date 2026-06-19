using AssembleSystem.FSM.ParentObjesct;
using AssembleSystem.FSM.Parts;
using UnityEngine;
using UnityHFSM;

namespace AssembleSystem.FSM.ParentObject.States
{
	public class AssembleParentDefaultState : StateBase<StateIdentifier>
	{
		protected ParentPartStateMachine _fsm;

		protected AssembleObjectParent _assembleParent;

		public AssembleParentDefaultState(AssembleObjectParent assembleParent, ParentPartStateMachine fsm, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_fsm = fsm;
			_assembleParent = assembleParent;
		}

		public override void OnEnter()
		{
			_fsm.Placed = false;
			_fsm.ReadyToBuild = false;
			_fsm.SetCanCheckAfterTight(value: false);
			foreach (GameObject part in _assembleParent.Parts)
			{
				PartObjectStateMachine component = part.GetComponent<PartObjectStateMachine>();
				component.InInventoryParentPlaced = false;
				if (!component.Placed)
				{
					part.transform.parent = null;
				}
			}
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
