using System;
using AssembleSystem.FSM.Parts.States;
using Items;
using JSAM;
using MyBox;
using Player;
using Player.FSM;
using UI.Inventory;
using UnityEngine;
using UnityHFSM;
using Zenject;

namespace AssembleSystem.FSM.Parts
{
	public class PartObjectStateMachine : MonoBehaviour
	{
		public bool InInventoryParentPlaced;

		public bool Placed;

		public bool Tightened;

		public bool IsHeldByPlayer;

		public bool IsInRangeOfTempPart;

		public bool AllNecessaryPartsTightened;

		private AssembleObjectParent _rootAssemble;

		private PartObject _part;

		private PlayerPartProgressor _playerPartProgressor;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private string _currentStateDEBUG;

		private StateMachine<StateIdentifier> fsm;

		private IInventoryService _inventoryService;

		private IInventoryUIService _inventoryUIService;

		private IPlayerStateMachineParametersManipulator _playerFSMManipulator;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private void Construct(IInventoryService inventoryService, IInventoryUIService inventoryUIService, IPlayerStateMachineParametersManipulator playerFSM)
		{
			_inventoryService = inventoryService;
			_inventoryUIService = inventoryUIService;
			_playerFSMManipulator = playerFSM;
		}

		private void Awake()
		{
			_rootAssemble = GetComponentInParent<AssembleObjectParent>();
			_part = GetComponent<PartObject>();
			if (_playerFSMManipulator is MonoBehaviour monoBehaviour)
			{
				_playerPartProgressor = monoBehaviour.transform.root.GetComponentInChildren<PlayerPartProgressor>();
			}
		}

		private void Start()
		{
			if (!GetComponent<TempPart>())
			{
				CreateNewStateMachine();
				PopulateStates();
				InitStateMachine();
				if (_rootAssemble != null && fsm != null)
				{
					AssembleObjectParent rootAssemble = _rootAssemble;
					rootAssemble.OnUpdate = (Action)Delegate.Combine(rootAssemble.OnUpdate, new Action(fsm.OnLogic));
				}
			}
		}

		private void InitStateMachine()
		{
			fsm.Init();
		}

		private void CreateNewStateMachine()
		{
			fsm = new StateMachine<StateIdentifier>();
		}

		private void Update()
		{
			if (fsm != null)
			{
				_currentStateDEBUG = fsm.ActiveState.name.Name;
			}
		}

		private void PopulateStates()
		{
			PartObjectDefaultState state = new PartObjectDefaultState(this, _part, needsExitTime: false);
			StateIdentifier stateIdentifier = new StateIdentifier("PartDefault");
			PartObjectReadyToBePlacedState state2 = new PartObjectReadyToBePlacedState(_rootAssemble, _part, needsExitTime: false);
			StateIdentifier stateIdentifier2 = new StateIdentifier("readyToBePlaced");
			PartObjectPlacedState partObjectPlacedState = new PartObjectPlacedState(_inventoryService, _inventoryUIService, _part, _rootAssemble, needsExitTime: false);
			StateIdentifier stateIdentifier3 = new StateIdentifier("Placed");
			_diContainer.Inject(partObjectPlacedState);
			PartObjectTightenedState partObjectTightenedState = new PartObjectTightenedState(_part, _rootAssemble, needsExitTime: false);
			StateIdentifier stateIdentifier4 = new StateIdentifier("Tightened");
			_diContainer.Inject(partObjectTightenedState);
			PartObjectBrokenDownState state3 = new PartObjectBrokenDownState(_part, _playerPartProgressor, needsExitTime: false);
			StateIdentifier stateIdentifier5 = new StateIdentifier("BrokenDown");
			Transition<StateIdentifier> transition = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier2, (Transition<StateIdentifier> t) => IsHeldByPlayer && AllNecessaryPartsTightened && _rootAssemble.StateMachine.Placed && _rootAssemble.StateMachine.enabled);
			Transition<StateIdentifier> transition2 = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier3, (Transition<StateIdentifier> t) => Placed, OnItemPlaced);
			Transition<StateIdentifier> transition3 = new Transition<StateIdentifier>(stateIdentifier2, stateIdentifier3, (Transition<StateIdentifier> t) => Placed, OnItemPlaced);
			Transition<StateIdentifier> transition4 = new Transition<StateIdentifier>(stateIdentifier3, stateIdentifier4, (Transition<StateIdentifier> t) => ((IProgressable)_part).CurrentProgress >= 1f);
			Transition<StateIdentifier> transition5 = new Transition<StateIdentifier>(stateIdentifier4, stateIdentifier, (Transition<StateIdentifier> t) => ((IProgressable)_part).CurrentProgress == 0f);
			Transition<StateIdentifier> transition6 = new Transition<StateIdentifier>(stateIdentifier4, stateIdentifier5, (Transition<StateIdentifier> t) => ((IProgressable)_part).CurrentProgress >= 2f);
			Transition<StateIdentifier> transition7 = new Transition<StateIdentifier>(stateIdentifier5, stateIdentifier);
			Transition<StateIdentifier> transition8 = new Transition<StateIdentifier>(stateIdentifier3, stateIdentifier, (Transition<StateIdentifier> t) => !Placed, OnItemRemoved);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddTwoWayTransition(transition3);
			fsm.AddTransition(transition8);
			fsm.AddTransition(transition4);
			fsm.AddTransition(transition5);
			fsm.AddTransition(transition6);
			fsm.AddTransition(transition7);
			fsm.AddState(stateIdentifier, state);
			fsm.AddState(stateIdentifier2, state2);
			fsm.AddState(stateIdentifier3, partObjectPlacedState);
			fsm.AddState(stateIdentifier4, partObjectTightenedState);
			fsm.AddState(stateIdentifier5, state3);
			fsm.SetStartState(stateIdentifier);
			fsm.StateChanged += NotifyOnStateChanged;
		}

		private void NotifyOnStateChanged(StateBase<StateIdentifier> @base)
		{
			_part.InvokeOnStateChanged();
		}

		private void OnItemPlaced(Transition<StateIdentifier> transition)
		{
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePartConnected);
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePartConnectedAdd);
		}

		private void OnItemRemoved(Transition<StateIdentifier> transition)
		{
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePartDisconnected);
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePartDisconnectedAdd);
		}
	}
}
