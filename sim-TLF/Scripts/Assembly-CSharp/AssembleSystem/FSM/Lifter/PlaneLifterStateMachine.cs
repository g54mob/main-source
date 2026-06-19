using AssembleSystem.FSM.Lifter.States;
using UnityEngine;
using UnityHFSM;
using Vehicles.Lifter;

namespace AssembleSystem.FSM.Lifter
{
	public class PlaneLifterStateMachine : MonoBehaviour
	{
		private StateMachine<StateIdentifier> fsm;

		[SerializeField]
		private LiftingObjectTrigger _mountChecker;

		[SerializeField]
		private PlaneLifter _planeLifter;

		[SerializeField]
		private bool _movingUp;

		[SerializeField]
		private bool _movingDown;

		private void Awake()
		{
			CreateNewStateMachine();
			PopulateStates();
			InitStateMachine();
		}

		private void Update()
		{
			fsm.OnLogic();
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
			EmptyLifterState state = new EmptyLifterState();
			StateIdentifier stateIdentifier = new StateIdentifier("empty");
			CanConnectState state2 = new CanConnectState(_mountChecker);
			StateIdentifier stateIdentifier2 = new StateIdentifier("canConnect");
			ConnectedState state3 = new ConnectedState(_mountChecker);
			StateIdentifier to = new StateIdentifier("connected");
			MoveUpState state4 = new MoveUpState(_planeLifter);
			StateIdentifier stateIdentifier3 = new StateIdentifier("moveUp");
			MoveDownState state5 = new MoveDownState(_planeLifter);
			StateIdentifier stateIdentifier4 = new StateIdentifier("moveDown");
			Transition<StateIdentifier> transition = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier2, (Transition<StateIdentifier> transit) => _mountChecker.IsObjectInTrigger, OnCanConnect);
			Transition<StateIdentifier> transition2 = new Transition<StateIdentifier>(stateIdentifier2, to, (Transition<StateIdentifier> transit) => _mountChecker.IsGripped, OnConnected);
			Transition<StateIdentifier> transition3 = new Transition<StateIdentifier>(null, stateIdentifier3, (Transition<StateIdentifier> transit) => _movingUp);
			Transition<StateIdentifier> transition4 = new Transition<StateIdentifier>(null, stateIdentifier4, (Transition<StateIdentifier> transit) => _movingDown);
			Transition<StateIdentifier> transition5 = new Transition<StateIdentifier>(stateIdentifier3, stateIdentifier, (Transition<StateIdentifier> transit) => !_movingUp);
			Transition<StateIdentifier> transition6 = new Transition<StateIdentifier>(stateIdentifier4, stateIdentifier, (Transition<StateIdentifier> transit) => !_movingDown);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddTransitionFromAny(transition3);
			fsm.AddTransitionFromAny(transition4);
			fsm.AddTransition(transition5);
			fsm.AddTransition(transition6);
			fsm.AddState(stateIdentifier, state);
			fsm.AddState(stateIdentifier2, state2);
			fsm.AddState(to, state3);
			fsm.AddState(stateIdentifier3, state4);
			fsm.AddState(stateIdentifier4, state5);
			fsm.SetStartState(stateIdentifier);
		}

		public void SetMovingUp(bool value)
		{
			_movingUp = value;
		}

		public void SetMovingDown(bool value)
		{
			_movingDown = value;
		}

		private void OnCanConnect(Transition<StateIdentifier> transition)
		{
		}

		private void OnConnected(Transition<StateIdentifier> transition)
		{
		}
	}
}
