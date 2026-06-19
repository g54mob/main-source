using Player.Animations;
using Player.FSM.Hands.States.Right;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityHFSM;
using Zenject;

namespace Player.FSM.Hands
{
	public class PlayerRightHandStateMachine : PlayerHandStateMachine
	{
		[SerializeField]
		private ArmsAnimator _armsAnimator;

		[SerializeField]
		private PlayerItemDropper _itemDropper;

		private bool _using;

		[Inject]
		private IPlayerEquipService _equipToolService;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private DiContainer _diContainer;

		private bool Holding => _equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) != null;

		private bool Using => _using;

		private void OnEnable()
		{
			_inputService.OnDrop += OnInteract;
		}

		private void OnDisable()
		{
			_inputService.OnDrop -= OnInteract;
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
			PlayerRightHandIdleState playerRightHandIdleState = new PlayerRightHandIdleState(_itemDropper, _armsAnimator);
			PlayerRightHandHoldingState playerRightHandHoldingState = new PlayerRightHandHoldingState(_itemDropper, _armsAnimator);
			PlayerRightHandUsingState playerRightHandUsingState = new PlayerRightHandUsingState(_armsAnimator);
			_diContainer.Inject(playerRightHandIdleState);
			_diContainer.Inject(playerRightHandHoldingState);
			_diContainer.Inject(playerRightHandUsingState);
			Transition transition = new Transition(playerRightHandIdleState.name, playerRightHandHoldingState.name, (Transition<string> t) => Holding);
			Transition transition2 = new Transition(playerRightHandHoldingState.name, playerRightHandUsingState.name, (Transition<string> t) => Using);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddState(playerRightHandIdleState.name, playerRightHandIdleState);
			fsm.AddState(playerRightHandHoldingState.name, playerRightHandHoldingState);
			fsm.AddState(playerRightHandUsingState.name, playerRightHandUsingState);
			fsm.SetStartState(playerRightHandIdleState.name);
		}
	}
}
