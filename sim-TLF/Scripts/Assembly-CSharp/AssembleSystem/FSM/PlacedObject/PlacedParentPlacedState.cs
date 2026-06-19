using System.Threading;
using AssembleSystem.FSM.Parts;
using Items;
using JSAM;
using Player;
using UI.HUD.Assistant;
using UI.Inventory;
using UnityEngine;
using UnityHFSM;

namespace AssembleSystem.FSM.PlacedObject
{
	public class PlacedParentPlacedState : StateBase<StateIdentifier>
	{
		private const string HintText = "The object has been placed successfully! \nDirection: ";

		private readonly PlacedObjectStateMachine _fsm;

		private readonly AssembleObjectParent _parent;

		private readonly ICraftUIService _craftService;

		private readonly IInventoryService _inventoryService;

		private readonly IInventoryUIService _inventoryUIService;

		private readonly AssistantPopupViewModel _assistantPopupViewModel;

		private readonly PlayerBehaviour _playerBehaviour;

		private CancellationTokenSource _directionCts;

		public PlacedParentPlacedState(PlacedObjectStateMachine fsm, PlayerBehaviour playerBehaviour, AssistantPopupViewModel assistantPopupViewModel, ICraftUIService craftService, IInventoryUIService inventoryUIService, IInventoryService inventoryService, AssembleObjectParent parent, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_fsm = fsm;
			_inventoryService = inventoryService;
			_inventoryUIService = inventoryUIService;
			_craftService = craftService;
			_parent = parent;
			_assistantPopupViewModel = assistantPopupViewModel;
			_playerBehaviour = playerBehaviour;
		}

		public override void OnEnter()
		{
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePlacingComplete);
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePlacingCompleteAdd);
			_fsm.Placed = true;
			ClearGhostAndPlaceRealObjects();
			_craftService.RemoveCraftItem(_parent);
			if (_fsm.PlacedParent != null)
			{
				_fsm.transform.SetParent(_fsm.PlacedParent, worldPositionStays: false);
				_fsm.transform.localPosition = _fsm.PlacedPosition;
				_fsm.transform.localRotation = _fsm.PlacedRotation;
			}
			SetBuildText();
		}

		public override void OnLogic()
		{
		}

		private void ClearGhostAndPlaceRealObjects()
		{
			foreach (GameObject part in _parent.Parts)
			{
				PartObject component = part.GetComponent<PartObject>();
				if (component.IsBase)
				{
					part.GetComponent<PartObjectStateMachine>().Placed = true;
					((IProgressable)component).SetProgress(1f);
					component.enabled = false;
				}
			}
		}

		private void SetBuildText()
		{
		}
	}
}
