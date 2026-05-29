using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public abstract class FSMState : FSMNode, IState
	{
		public enum TransitionEvaluationMode
		{
			CheckContinuously = 0,
			CheckAfterStateFinished = 1,
			CheckManually = 2
		}

		[SerializeField]
		private TransitionEvaluationMode _transitionEvaluation;

		private bool _hasInit;

		public override bool allowAsPrime => false;

		public override bool canSelfConnect => false;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public TransitionEvaluationMode transitionEvaluation
		{
			get
			{
				return default(TransitionEvaluationMode);
			}
			set
			{
			}
		}

		string IState.tag => null;

		float IState.elapsedTime => 0f;

		public FSMConnection[] GetTransitions()
		{
			return null;
		}

		public void Finish()
		{
		}

		public void Finish(bool inSuccess)
		{
		}

		public void Finish(Status status)
		{
		}

		public override void OnGraphPaused()
		{
		}

		protected override bool CanConnectFromSource(Node sourceNode)
		{
			return false;
		}

		protected override bool CanConnectToTarget(Node targetNode)
		{
			return false;
		}

		protected sealed override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}

		public bool CheckTransitions()
		{
			return false;
		}

		protected sealed override void OnReset()
		{
		}

		protected virtual void OnInit()
		{
		}

		protected virtual void OnEnter()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnExit()
		{
		}

		protected virtual void OnPause()
		{
		}
	}
}
