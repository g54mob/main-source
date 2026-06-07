using UnityEngine.AI;
using __Project__.Scripts.Janitor.Interfaces;

namespace __Project__.Scripts.Janitor.States
{
	public class MoveTargetState : IState
	{
		private Janitor _janitor;

		private NavMeshAgent _agent;

		private ICleanable _cleanable;

		public MoveTargetState(Janitor janitor)
		{
		}

		public void Enter()
		{
		}

		private void OnCleaned()
		{
		}

		public void Update()
		{
		}

		public void Exit()
		{
		}
	}
}
