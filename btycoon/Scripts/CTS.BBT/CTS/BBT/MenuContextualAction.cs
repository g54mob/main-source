using CTS.BBT.AI;

namespace CTS.BBT
{
	public abstract class MenuContextualAction<T> : ContextualAction<T> where T : class, IContextActor
	{
		public override bool IsWorkerAction { get; }

		public sealed override bool CanBePerformed(Worker p_worker)
		{
			return CanBePerformed();
		}

		protected sealed override void Execution(Worker p_worker)
		{
			Execution();
		}

		protected abstract bool CanBePerformed();

		protected abstract void Execution();
	}
}
