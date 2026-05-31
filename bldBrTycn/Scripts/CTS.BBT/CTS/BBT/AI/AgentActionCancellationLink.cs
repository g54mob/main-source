namespace CTS.BBT.AI
{
	public sealed class AgentActionCancellationLink
	{
		private AgentAction _target;

		public AgentAction Parent { get; private set; }

		public bool Cancelled { get; private set; }

		public AgentActionCancellationLink(AgentAction parent, AgentAction target)
		{
			Parent = parent;
			Parent.CancellationLinks.Add(this);
			_target = target;
			_target.CancellationLinks.Add(this);
			Parent.OnActionComplete += OnActionCompleted;
			Parent.OnActionCancelled += OnActionCancelled;
		}

		private void OnActionCancelled(AgentAction cancelledAction)
		{
			Cancelled = true;
			_target.CancelAction("Synced action cancelled");
			OnActionCompleted(cancelledAction);
		}

		private void OnActionCompleted(AgentAction completedAction)
		{
			Parent.OnActionComplete -= OnActionCompleted;
			Parent.OnActionCancelled -= OnActionCancelled;
			Parent.CancellationLinks.Remove(this);
			Parent = null;
			_target.CancellationLinks.Remove(this);
			_target = null;
		}
	}
}
