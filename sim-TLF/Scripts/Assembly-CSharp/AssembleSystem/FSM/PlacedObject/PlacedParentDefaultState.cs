using AssembleSystem.FSM.Parts;
using UnityEngine;
using UnityHFSM;

namespace AssembleSystem.FSM.PlacedObject
{
	public class PlacedParentDefaultState : StateBase<StateIdentifier>
	{
		protected PlacedObjectStateMachine _placedFSM;

		protected AssembleObjectParent _assembleParent;

		public PlacedParentDefaultState(AssembleObjectParent assembleParent, PlacedObjectStateMachine fsm, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_placedFSM = fsm;
			_assembleParent = assembleParent;
		}

		public override void OnEnter()
		{
			_placedFSM.Placed = false;
			foreach (GameObject part in _assembleParent.Parts)
			{
				PartObjectStateMachine component = part.GetComponent<PartObjectStateMachine>();
				if (component != null)
				{
					component.InInventoryParentPlaced = false;
					if (!component.Placed)
					{
						part.transform.parent = null;
					}
				}
			}
		}
	}
}
