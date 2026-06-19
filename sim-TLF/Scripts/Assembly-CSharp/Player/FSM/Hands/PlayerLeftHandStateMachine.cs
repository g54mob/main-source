using Player.Animations;
using Player.FSM.Hands.States.Left;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityHFSM;
using Zenject;

namespace Player.FSM.Hands
{
	public class PlayerLeftHandStateMachine : PlayerHandStateMachine
	{
		[SerializeField]
		private ArmsAnimator _armsAnimator;

		[SerializeField]
		private PlayerItemPicker _itemPicker;

		[Inject]
		private IInventoryUIService _inventoryItemService;

		private bool _using;

		[Inject]
		private IPlayerEquipService _equipToolService;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private DiContainer _diContainer;

		private bool Holding => _equipToolService.GetEquipableAt(EquipSide.LEFT_HAND) != null;

		private bool Using => _using;

		private void OnEnable()
		{
			_inputService.OnInteract += OnInteract;
		}

		private void OnDisable()
		{
			_inputService.OnInteract -= OnInteract;
		}

		private void OnInteract(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				_using = true;
			}
			else if (context.canceled)
			{
				_using = false;
			}
		}

		protected override void PopulateStates()
		{
			PlayerLeftHandIdleState playerLeftHandIdleState = new PlayerLeftHandIdleState(_itemPicker, _inventoryItemService.GetItemMover(), _armsAnimator);
			PlayerLeftHandHoldingState playerLeftHandHoldingState = new PlayerLeftHandHoldingState(_itemPicker, _inventoryItemService.GetItemMover(), _armsAnimator);
			PlayerLeftHandUsingState playerLeftHandUsingState = new PlayerLeftHandUsingState(_armsAnimator);
			_diContainer.Inject(playerLeftHandIdleState);
			_diContainer.Inject(playerLeftHandHoldingState);
			_diContainer.Inject(playerLeftHandUsingState);
			Transition transition = new Transition(playerLeftHandIdleState.name, playerLeftHandHoldingState.name, (Transition<string> t) => Holding);
			Transition transition2 = new Transition(playerLeftHandHoldingState.name, playerLeftHandUsingState.name, (Transition<string> t) => Using);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddState(playerLeftHandIdleState.name, playerLeftHandIdleState);
			fsm.AddState(playerLeftHandHoldingState.name, playerLeftHandHoldingState);
			fsm.AddState(playerLeftHandUsingState.name, playerLeftHandUsingState);
			fsm.SetStartState(playerLeftHandIdleState.name);
		}
	}
}
