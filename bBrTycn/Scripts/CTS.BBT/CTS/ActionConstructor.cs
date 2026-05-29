using CTS.BBT.AI;

namespace CTS
{
	public abstract class ActionConstructor : SequenceAction
	{
		private AgentAction _constructedAction;

		public AgentAction GetAction()
		{
			return _constructedAction ?? (_constructedAction = Construct());
		}

		public override void Play(ActionSequence sequence)
		{
			AgentAction action = GetAction();
			sequence.PlayerAgent.ActionPlayer.AddAction(action);
		}

		public override bool IsValid()
		{
			return GetAction() != null;
		}

		protected abstract AgentAction Construct();

		protected void SetupAction(AgentAction action)
		{
			action.ActionStarting += OnActionStarting;
			action.ActionStarted += OnActionStarted;
			action.OnActionCancelled += OnActionCancelled;
			action.OnActionComplete += OnActionCompleted;
		}

		private void OnActionStarting()
		{
			SendStartEvent(started: false);
			GetAction().ActionStarting -= OnActionStarting;
		}

		private void OnActionStarted()
		{
			SendStartEvent(started: true);
			GetAction().ActionStarted -= OnActionStarted;
		}

		private void OnActionCancelled(AgentAction action)
		{
			InvokeCompletion(action, success: false);
		}

		private void OnActionCompleted(AgentAction action)
		{
			InvokeCompletion(action, success: true);
		}

		private void InvokeCompletion(AgentAction action, bool success)
		{
			FinishAction(success);
			action.ActionStarting -= OnActionStarting;
			action.ActionStarted -= OnActionStarted;
			action.OnActionComplete -= OnActionCompleted;
			action.OnActionCancelled -= OnActionCancelled;
		}
	}
	public abstract class ActionConstructor<TAction> : ActionConstructor where TAction : AgentAction
	{
		protected TAction action => (TAction)GetAction();

		protected override AgentAction Construct()
		{
			TAction result = ConstructAction();
			SetupAction(result);
			return result;
		}

		protected abstract TAction ConstructAction();
	}
}
