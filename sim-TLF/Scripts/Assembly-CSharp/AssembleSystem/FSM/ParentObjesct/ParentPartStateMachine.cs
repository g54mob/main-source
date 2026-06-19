using System.Collections.Generic;
using AssembleSystem.FSM.ParentObject.States;
using AssembleSystem.Utils;
using MyBox;
using UI.Inventory;
using UnityEngine;
using UnityEngine.Events;
using UnityHFSM;
using Zenject;

namespace AssembleSystem.FSM.ParentObjesct
{
	[RequireComponent(typeof(AssembleObjectParent))]
	public class ParentPartStateMachine : MonoBehaviour
	{
		public bool ReadyToBuild;

		public bool Placed;

		public bool PlacedFromTheStart;

		private bool _canCheckAfterTightening;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private string _stateDEBUG;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private string _debug;

		[Header("Links")]
		[SerializeField]
		protected AssembleObjectParent _rootAssemble;

		[SerializeField]
		protected UnityEvent OnAssembled;

		[SerializeField]
		protected UnityEvent OnPlaced;

		private StateMachine<StateIdentifier> fsm;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		public bool Assembled => _rootAssemble.TightenedItems == _rootAssemble.ItemConfig.PartsConfig.Count;

		public bool AnyBaseIsNotInstalled => _rootAssemble.ItemConfig.PartsConfig.Exists(delegate(PartConfig partConfig)
		{
			if (partConfig.NecessaryAssembleParts.Count == 0)
			{
				List<PartObject> partsObjects = _rootAssemble.GetPartsObjects(new List<PartConfig> { partConfig });
				if (partsObjects.Count == 0 || !partsObjects[0].StateMachine.Placed)
				{
					return true;
				}
			}
			return false;
		});

		private void Start()
		{
			CreateNewStateMachine();
			PopulateStates();
			InitStateMachine();
		}

		private void Update()
		{
			fsm.OnLogic();
		}

		public void SetCanCheckAfterTight(bool value)
		{
			_canCheckAfterTightening = value;
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
			AssembleParentDefaultState state = new AssembleParentDefaultState(_rootAssemble, this, needsExitTime: false);
			StateIdentifier stateIdentifier = new StateIdentifier("default");
			AssembleParentReadyToBePlacedState state2 = new AssembleParentReadyToBePlacedState(_rootAssemble, needsExitTime: false);
			StateIdentifier stateIdentifier2 = new StateIdentifier("readyToBePlaced");
			AssembleParentPlacedState state3 = new AssembleParentPlacedState(OnPlaced, _craftUIService, _inventoryUIService, _inventoryService, _rootAssemble, needsExitTime: false);
			StateIdentifier stateIdentifier3 = new StateIdentifier("placed");
			AssembleParentAssembledState assembleParentAssembledState = new AssembleParentAssembledState(_rootAssemble, OnAssembled, needsExitTime: false);
			StateIdentifier to = new StateIdentifier("assembled");
			_diContainer.Inject(assembleParentAssembledState);
			Transition<StateIdentifier> transition = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier2, (Transition<StateIdentifier> t) => ReadyToBuild);
			Transition<StateIdentifier> transition2 = new Transition<StateIdentifier>(stateIdentifier2, stateIdentifier3, (Transition<StateIdentifier> t) => Placed);
			Transition<StateIdentifier> transition3 = new Transition<StateIdentifier>(stateIdentifier3, to, (Transition<StateIdentifier> t) => Assembled);
			Transition<StateIdentifier> transition4 = new Transition<StateIdentifier>(stateIdentifier3, stateIdentifier, (Transition<StateIdentifier> t) => _rootAssemble.TightenedItems == 0 && !Placed);
			Transition<StateIdentifier> transition5 = new Transition<StateIdentifier>(stateIdentifier, to, (Transition<StateIdentifier> t) => Assembled);
			fsm.AddTransition(transition4);
			fsm.AddTransition(transition5);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddTwoWayTransition(transition3);
			fsm.AddState(stateIdentifier, state);
			fsm.AddState(stateIdentifier2, state2);
			fsm.AddState(stateIdentifier3, state3);
			fsm.AddState(to, assembleParentAssembledState);
			fsm.SetStartState(stateIdentifier);
		}
	}
}
