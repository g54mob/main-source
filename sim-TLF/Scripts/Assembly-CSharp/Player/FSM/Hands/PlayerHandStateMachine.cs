using Player.FSM.Hands.States;
using UnityEngine;
using UnityHFSM;

namespace Player.FSM.Hands
{
	public class PlayerHandStateMachine : MonoBehaviour
	{
		protected StateMachine fsm;

		private void Awake()
		{
			CreateNewStateMachine();
			PopulateStates();
			InitStateMachine();
		}

		protected virtual void Update()
		{
			fsm.OnLogic();
		}

		private void InitStateMachine()
		{
			fsm.Init();
		}

		private void CreateNewStateMachine()
		{
			fsm = new StateMachine();
		}

		protected virtual void PopulateStates()
		{
			PlayerHandIdleState playerHandIdleState = new PlayerHandIdleState();
			PlayerHandHoldingState playerHandHoldingState = new PlayerHandHoldingState();
			PlayerHandUsingState playerHandUsingState = new PlayerHandUsingState();
			Transition transition = new Transition(playerHandIdleState.name, playerHandHoldingState.name);
			Transition transition2 = new Transition(playerHandHoldingState.name, playerHandUsingState.name);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddState(playerHandIdleState.name);
			fsm.AddState(playerHandHoldingState.name);
			fsm.AddState(playerHandUsingState.name);
			fsm.SetStartState(playerHandIdleState.name);
		}
	}
}
