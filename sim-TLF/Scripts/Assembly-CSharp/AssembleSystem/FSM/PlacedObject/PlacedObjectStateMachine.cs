using AssembleSystem.FSM.ParentObject.States;
using AssembleSystem.FSM.ParentObjesct;
using Loxodon.Framework.Contexts;
using MyBox;
using Player;
using Player.FSM;
using UI.HUD.Assistant;
using UI.Inventory;
using UnityEngine;
using UnityHFSM;
using Zenject;

namespace AssembleSystem.FSM.PlacedObject
{
	[RequireComponent(typeof(AssembleObjectParent))]
	public class PlacedObjectStateMachine : ParentPartStateMachine
	{
		public Vector3 PlacedPosition;

		public Quaternion PlacedRotation;

		public Transform PlacedParent;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private string _placedStateDEBUG;

		private StateMachine<StateIdentifier> fsm;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerBehaviour;

		[Inject]
		private DiContainer _diContainer;

		private AssistantPopupViewModel _assistantPopupViewModel;

		public AssembleObjectParent RootAssemble => _rootAssemble;

		private void Awake()
		{
			_assistantPopupViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetContainer().Resolve<AssistantPopupViewModel>();
		}

		private void Start()
		{
			CreateNewStateMachine();
			PopulateStates();
			InitStateMachine();
		}

		private void Update()
		{
			fsm.OnLogic();
			_placedStateDEBUG = fsm.ActiveStateName.Name;
		}

		private void InitStateMachine()
		{
			fsm.Init();
		}

		private void CreateNewStateMachine()
		{
			fsm = new StateMachine<StateIdentifier>();
		}

		private void PopulateStates()
		{
			MonoBehaviour monoBehaviour = _playerBehaviour as MonoBehaviour;
			PlacedParentDefaultState state = new PlacedParentDefaultState(_rootAssemble, this, needsExitTime: false);
			StateIdentifier stateIdentifier = new StateIdentifier("default");
			PlacedParentReadyToBePlacedState state2 = new PlacedParentReadyToBePlacedState(this, needsExitTime: false);
			StateIdentifier stateIdentifier2 = new StateIdentifier("readyToBePlaced");
			PlacedParentPlacedState state3 = new PlacedParentPlacedState(this, monoBehaviour.GetComponentInParent<PlayerBehaviour>(), _assistantPopupViewModel, _craftUIService, _inventoryUIService, _inventoryService, _rootAssemble, needsExitTime: false);
			StateIdentifier stateIdentifier3 = new StateIdentifier("placed");
			AssembleParentAssembledState assembleParentAssembledState = new AssembleParentAssembledState(_rootAssemble, OnAssembled, needsExitTime: false);
			StateIdentifier to = new StateIdentifier("assembled");
			_diContainer.Inject(assembleParentAssembledState);
			Transition<StateIdentifier> transition = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier2, (Transition<StateIdentifier> t) => ReadyToBuild || Placed);
			Transition<StateIdentifier> transition2 = new Transition<StateIdentifier>(stateIdentifier2, stateIdentifier3, (Transition<StateIdentifier> t) => Placed, InvokeOnPlaced);
			Transition<StateIdentifier> transition3 = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier3, (Transition<StateIdentifier> t) => Placed || _rootAssemble.TightenedItems > 0, InvokeOnPlaced);
			Transition<StateIdentifier> transition4 = new Transition<StateIdentifier>(stateIdentifier3, stateIdentifier, (Transition<StateIdentifier> t) => _rootAssemble.TightenedItems == 0 && !Placed);
			Transition<StateIdentifier> transition5 = new Transition<StateIdentifier>(stateIdentifier3, to, (Transition<StateIdentifier> t) => base.Assembled);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTransition(transition2);
			fsm.AddTransition(transition3);
			fsm.AddTransition(transition4);
			fsm.AddTwoWayTransition(transition5);
			fsm.AddState(stateIdentifier, state);
			fsm.AddState(stateIdentifier2, state2);
			fsm.AddState(stateIdentifier3, state3);
			fsm.AddState(to, assembleParentAssembledState);
			fsm.SetStartState(stateIdentifier);
		}

		public void InvokeOnPlaced(Transition<StateIdentifier> transition)
		{
			OnPlaced?.Invoke();
		}
	}
}
