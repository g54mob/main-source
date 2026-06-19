using Items;
using UI.Inventory;
using UnityEngine;
using UnityEngine.Events;
using UnityHFSM;

namespace AssembleSystem.FSM.ParentObject.States
{
	public class AssembleParentPlacedState : StateBase<StateIdentifier>
	{
		private readonly UnityEvent _onEnter;

		private readonly AssembleObjectParent _parent;

		private readonly ICraftUIService _craftService;

		private readonly IInventoryService _inventoryService;

		private readonly IInventoryUIService _inventoryUIService;

		public AssembleParentPlacedState(UnityEvent onEnter, ICraftUIService craftService, IInventoryUIService inventoryUIService, IInventoryService inventoryService, AssembleObjectParent parent, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_onEnter = onEnter;
			_inventoryService = inventoryService;
			_inventoryUIService = inventoryUIService;
			_craftService = craftService;
			_parent = parent;
		}

		public override void OnEnter()
		{
			ClearGhostAndPlaceRealObjects();
			_craftService.RemoveCraftItem(_parent);
			_onEnter?.Invoke();
		}

		private void ClearGhostAndPlaceRealObjects()
		{
			_parent.transform.SetPositionAndRotation(_parent.TestMovingPoint.position + _parent.Offset, _parent.TestMovingPoint.rotation);
			foreach (GameObject part in _parent.Parts)
			{
				PartObject component = part.GetComponent<PartObject>();
				if (component != null && component.IsBase)
				{
					component.StateMachine.Tightened = true;
					component.StateMachine.Placed = true;
					((IProgressable)component)?.SetProgress(1f);
					component.enabled = false;
				}
			}
		}
	}
}
