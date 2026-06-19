using System;
using AssembleSystem;
using MyBox;
using Player.Animations;
using Player.FSM.States;
using UI.Craft;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityHFSM;
using Zenject;

namespace Player.FSM
{
	public class PlayerBehaviourStateMachine : MonoBehaviour, IPlayerStateMachineParametersManipulator
	{
		public AssembleObjectParent ParentBeingPlaced;

		[SerializeField]
		private RaycasterInfo _playerRaycaster;

		[SerializeField]
		private Vector3 _moveOffset;

		[SerializeField]
		private PlayerItemPicker _playerItemPicker;

		[SerializeField]
		private PlayerItemHolder _playerItemHolder;

		[SerializeField]
		private ArmsAnimator _armsAnimator;

		[SerializeField]
		private Transform _inventoryItemsSpawnPoint;

		[SerializeField]
		private BasicRigidBodyPush _pushLogic;

		[SerializeField]
		[ReadOnly(new string[] { })]
		private bool _placingItem;

		private StateMachine<StateIdentifier, StateIdentifier> fsm;

		private bool _inPlaceState;

		private bool _placingItemFromInventory;

		private bool _leftHandConsuming;

		private bool _rightHandConsuming;

		private bool _pushing;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IPlayerInputService _playerInputService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IPlayerConsumeService _playerConsumeService;

		[Inject]
		private IPlayerEquipService _playerEquipToolService;

		private bool bothHandsFree
		{
			get
			{
				if (_playerEquipToolService.GetEquipableAt(EquipSide.LEFT_HAND) == null)
				{
					return _playerEquipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) == null;
				}
				return false;
			}
		}

		public bool Pushing => _pushing;

		public bool LeftHandConsuming => _leftHandConsuming;

		public bool RightHandConsuming => _rightHandConsuming;

		public bool CancelPlacingRequested { get; set; }

		private bool AnyHandConsuming
		{
			get
			{
				if (!_leftHandConsuming)
				{
					return _rightHandConsuming;
				}
				return true;
			}
		}

		bool IPlayerStateMachineParametersManipulator.IsPlacing
		{
			get
			{
				if (!_inPlaceState)
				{
					return _placingItemFromInventory;
				}
				return true;
			}
		}

		public event Action<EquipSide, bool> OnConsumingSideStateChange;

		private void Start()
		{
			CreateNewStateMachine();
			PopulateStates();
			InitStateMachine();
		}

		private void OnEnable()
		{
			_craftUIService.OnItemButtonCliked += StartPlacingItem;
			_playerInputService.OnPlayerUse += PlaceItem;
			_playerInputService.OnPush += TryChangePushState;
			IInventoryService inventoryService = _inventoryService;
			inventoryService.OnItemDropped = (Action<IInventoryManagable>)Delegate.Combine(inventoryService.OnItemDropped, new Action<IInventoryManagable>(OnInventoryItemDropped));
		}

		private void OnDisable()
		{
			_craftUIService.OnItemButtonCliked -= StartPlacingItem;
			_playerInputService.OnPlayerUse -= PlaceItem;
			_playerInputService.OnPush -= TryChangePushState;
			IInventoryService inventoryService = _inventoryService;
			inventoryService.OnItemDropped = (Action<IInventoryManagable>)Delegate.Remove(inventoryService.OnItemDropped, new Action<IInventoryManagable>(OnInventoryItemDropped));
		}

		private void OnInventoryItemDropped(IInventoryManagable dropped)
		{
			if (_inPlaceState && !(ParentBeingPlaced == null) && dropped is PartObject partObject && !(partObject.AssembleParent != ParentBeingPlaced.gameObject))
			{
				CancelPlacingRequested = true;
				_inPlaceState = false;
			}
		}

		private void TryChangePushState(InputAction.CallbackContext context)
		{
			if (context.performed && bothHandsFree)
			{
				_pushing = !_pushing;
			}
		}

		private void Update()
		{
			fsm.OnLogic();
			if (!bothHandsFree && _pushing)
			{
				_pushing = false;
			}
		}

		private void InitStateMachine()
		{
			fsm.Init();
		}

		private void CreateNewStateMachine()
		{
			fsm = new StateMachine<StateIdentifier, StateIdentifier>();
		}

		private void PopulateStates()
		{
			PlayerDefaultState state = new PlayerDefaultState(needsExitTime: false);
			StateIdentifier stateIdentifier = new StateIdentifier("default");
			PlayerPushState state2 = new PlayerPushState(_armsAnimator, _pushLogic, needsExitTime: false);
			StateIdentifier to = new StateIdentifier("push");
			PlayerPlaceState playerPlaceState = new PlayerPlaceState(_playerInputService, this, _playerRaycaster, needsExitTime: false);
			StateIdentifier to2 = new StateIdentifier("place");
			_diContainer.Inject(playerPlaceState);
			PlayerInventoryItemPacingState state3 = new PlayerInventoryItemPacingState(_playerInputService, _playerRaycaster, _inventoryUIService, this, _inventoryService, _moveOffset, _playerItemHolder, _inventoryItemsSpawnPoint, _playerItemPicker, needsExitTime: false);
			StateIdentifier to3 = new StateIdentifier("inventory_item_placing");
			Transition<StateIdentifier> transition = new Transition<StateIdentifier>(stateIdentifier, to, (Transition<StateIdentifier> t) => _pushing && bothHandsFree);
			Transition<StateIdentifier> transition2 = new Transition<StateIdentifier>(stateIdentifier, to2, (Transition<StateIdentifier> t) => _inPlaceState);
			Transition<StateIdentifier> transition3 = new Transition<StateIdentifier>(stateIdentifier, to3, (Transition<StateIdentifier> t) => _placingItemFromInventory);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddTwoWayTransition(transition3);
			fsm.AddTwoWayTransition(transition);
			fsm.AddState(stateIdentifier, state);
			fsm.AddState(to, state2);
			fsm.AddState(to2, playerPlaceState);
			fsm.AddState(to3, state3);
			fsm.SetStartState(stateIdentifier);
		}

		private void StartPlacingItem(CraftItemViewModel vm)
		{
			ParentBeingPlaced = vm.Parent;
			_inPlaceState = true;
		}

		private void PlaceItem(InputAction.CallbackContext context)
		{
			_inPlaceState = false;
		}

		void IPlayerStateMachineParametersManipulator.SetInPlaceState(bool inPlace)
		{
			_inPlaceState = inPlace;
		}

		void IPlayerStateMachineParametersManipulator.SetPlacingItemFromInventory(bool inPlace)
		{
			_placingItemFromInventory = inPlace;
		}

		void IPlayerStateMachineParametersManipulator.SetPushing(bool pushing)
		{
			_pushing = pushing;
		}
	}
}
